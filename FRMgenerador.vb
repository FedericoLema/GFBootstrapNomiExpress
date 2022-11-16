Imports MySql.Data.MySqlClient
Imports System.ComponentModel
Imports System.Data
Imports System.IO
'Imports Excel = Microsoft.Office.Interop.Excel
'Imports System.Reflection.Assembly.GetExecutingAssembly().Location

Public Class FRMgenerador
    Public cndb As MySqlConnection
    Public appath As String

    Private Sub FRMgenerador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Sql As String
        Dim i As Integer
        DateTimePicker1.Format = DateTimePickerFormat.Short ' = "short"
        Dim cndb As New MySqlConnection("server=127.0.0.1; port=3306; userid=rednel; password=expres2021*; database=erp; SslMode=none")
        Dim dt As New DataTable()
        'appath = System.AppDomain.CurrentDomain.BaseDirectory()
        'appath = "C:\Trabajo\Proyectos\VisualEstudio2019\GeneradorFormasPython"
        appath = "D:\Trabajo\Proyectos\VisualEstudio2019\GFBootstrapNomiExpress"
        Sql = "SELECT * FROM INFORMATION_SCHEMA.tables WHERE TABLE_SCHEMA='" & DBtextbox.Text & "'"
        'Sql = "SELECT COLUMNS.* FROM COLUMNS where TABLE_SCHEMA = 'erp_lite' and TABLE_NAME = 'empresas'"
        'Sql = Sql & " ORDER BY TABLA_NAME"
        'MsgBox(Sql)
        Dim cmd As New MySqlCommand(Sql, cndb)
        Try
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(dt)
            'COBtablas.DataSource = da
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
        'MsgBox(dt.Rows.Count)

        For i = 0 To dt.Rows.Count - 1
            COBtablas.Items.Add(dt.Rows(i)(2).ToString)
        Next i
        COBtablas.Text = dt.Rows(0)(2).ToString
        CargaCampos(COBtablas.Text)
    End Sub
    Private Function CargaCampos(NombreTabla As String)
        Dim Sql As String
        Dim label As String
        Dim tamano As Integer
        Dim formato As String
        Dim cndb As New MySqlConnection("server=127.0.0.1; port=3306; userid=rednel; password=expres2021*; database=erp; SslMode=none")
        Dim dt As New DataTable()
        Sql = "SELECT COLUMNS.* FROM INFORMATION_SCHEMA.COLUMNS where TABLE_SCHEMA = '" & DBtextbox.Text & "' and TABLE_NAME = '" & NombreTabla & "'"
        Dim cmd As New MySqlCommand(Sql, cndb)
        Try
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(dt)
            'DGVcampos.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Function
        End Try

        DGVcampos.Columns.Clear()

        DGVcampos.ColumnCount = 16
        DGVcampos.Columns(0).Name = "Campo"
        DGVcampos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'DGVcampos.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        DGVcampos.Columns(1).Name = "Clave"
        DGVcampos.Columns(2).Name = "Tipo"
        DGVcampos.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVcampos.Columns(3).Name = "Tamaño"
        DGVcampos.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGVcampos.Columns(4).Name = "Valida"
        DGVcampos.Columns(5).Name = "Tabla Combo"
        DGVcampos.Columns(6).Name = "Clave combo"
        DGVcampos.Columns(7).Name = "Campo muestra Combo"
        DGVcampos.Columns(8).Name = "Formato"
        'DGVcampos.Columns(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        DGVcampos.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGVcampos.Columns(9).Name = "Enteros"
        DGVcampos.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGVcampos.Columns(10).Name = "Decimales"
        DGVcampos.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGVcampos.Columns(11).Name = "Muestra"
        DGVcampos.Columns(12).Name = "descripcion"
        DGVcampos.Columns(13).Name = "Label"
        DGVcampos.Columns(14).Name = "minimo"
        DGVcampos.Columns(15).Name = "maximo"

        'For i = 0 To dt.Rows.Count - 1
        ' DGVcampos.Rows.Add(dt.Rows(i)(2).ToString, dt.Rows(i)(3).ToString, dt.Rows(i)(4).ToString, dt.Rows(i)(5).ToString, dt.Rows(i)(6).ToString, dt.Rows(i)(7).ToString, dt.Rows(i)(8).ToString, dt.Rows(i)(9).ToString, dt.Rows(i)(10).ToString, dt.Rows(i)(11).ToString, dt.Rows(i)(12).ToString, dt.Rows(i)(13).ToString, dt.Rows(i)(14).ToString, dt.Rows(i)(15).ToString, dt.Rows(i)(16).ToString, dt.Rows(i)(17).ToString)
        'Next i

        For i = 0 To dt.Rows.Count - 1
            If dt.Rows(i)(7).ToString = "date" Then
                tamano = 8
                formato = "yyyy-MM-dd"
            End If

            If dt.Rows(i)(7).ToString = "decimal" Then
                tamano = Val(dt.Rows(i)(10).ToString) + Val(dt.Rows(i)(11).ToString) + 1
                If Val(dt.Rows(i)(11).ToString) = 0 Then
                    Select Case Val(dt.Rows(i)(10).ToString)
                        Case 1
                            formato = "0"
                        Case 2
                            formato = "#0"
                        Case 3
                            formato = "##0"
                        Case 4
                            formato = "###0"
                        Case Else
                            formato = "#,###,###,###,##0"
                    End Select
                Else
                    Select Case Val(dt.Rows(i)(10).ToString)
                        Case 1
                            formato = "0"
                        Case 2
                            formato = "#0"
                        Case 3
                            formato = "##0"
                        Case 4
                            formato = "#,##0"
                        Case 5
                            formato = "##,##0"
                        Case 6
                            formato = "###,##0"
                        Case 7
                            formato = "###,##0"
                        Case Else
                            formato = "#,###,###,###,##0"
                    End Select
                    formato = formato & "."
                    For j = 1 To Val(dt.Rows(i)(11).ToString)
                        formato = formato & "0"
                    Next j
                End If

            End If

            If dt.Rows(i)(7).ToString = "double" Then
                tamano = Val(dt.Rows(i)(10).ToString) + Val(dt.Rows(i)(11).ToString) + 1
                formato = "###,###,###,##0.########"
            End If
            If dt.Rows(i)(7).ToString = "varchar" Then
                tamano = dt.Rows(i)(8).ToString
                formato = ""
            End If

            DGVcampos.Rows.Add(dt.Rows(i)(3).ToString, dt.Rows(i)(16).ToString, dt.Rows(i)(7).ToString, tamano.ToString, "", "", "", "", formato, dt.Rows(i)(10).ToString, dt.Rows(i)(11).ToString, "", dt.Rows(i)(3).ToString, dt.Rows(i)(3).ToString, "0", "")
        Next i

    End Function

    Private Sub COBtablas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles COBtablas.SelectedIndexChanged
        CargaCampos(COBtablas.Text)
        NombreFormatexbox.Text = "FRM" & COBtablas.Text
        TituloFormatexbox.Text = Replace(Mid(COBtablas.Text.Trim, 1, 1).ToUpper & Mid(COBtablas.Text.Trim, 2, Len(COBtablas.Text.Trim)), "_", " ")
    End Sub

    Private Sub BTNgenerar_Click(sender As Object, e As EventArgs) Handles BTNgenerar.Click
        Dim objStreamReader As StreamReader
        Dim objStreamWriter As StreamWriter
        Dim strLine As String
        Dim strLine1 As String
        Dim strLine2 As String
        Dim Blancos As Integer
        Dim y As Integer
        Dim operador As String
        Dim operador1 As String
        Dim Tamaño As String
        Dim tipo As String
        Dim tipocampo As String
        Dim MaxLabel As Integer
        Dim LABcampo As String
        Dim titulo_columna As String
        Dim max As Long
        Dim parametros As String
        Dim primary As String
        Dim nombretabla As String
        Dim strcampos As String
        Dim requerido As String
        Dim paso As String

        objStreamReader = New StreamReader(appath & "\Plantilla_list.txt")
        objStreamWriter = New StreamWriter(appath & "\Formas\templates\frm_" & COBtablas.Text & "_list.html")
        nombretabla = COBtablas.Text
        strLine = objStreamReader.ReadLine
        primary = ""
        Do While Not strLine Is Nothing
            strLine = Replace(strLine, "@TABLA", nombretabla)
            'strLine = Replace(strLine, "@PRIMARY", primary)
            Blancos = InStr(1, strLine, "@PRIMARY")
            If Blancos > 0 Then
                strcampos = ""
                For i = 0 To DGVcampos.Rows.Count - 2
                    If DGVcampos.Rows.Item(i).Cells(1).Value.trim = "PRI" Then
                        strCampos = strCampos & ", " & DGVcampos.Rows.Item(i).Cells(0).Value.trim & "= order['" & DGVcampos.Rows.Item(i).Cells(0).Value.trim & "']"
                    End If
                Next i
                strLine = Replace(strLine, "@PRIMARY", strCampos)
            End If
            Blancos = InStr(1, strLine, "@PRICREAR")
            If Blancos > 0 Then
                strCampos = ""
                For i = 0 To DGVcampos.Rows.Count - 2
                    If DGVcampos.Rows.Item(i).Cells(1).Value.trim = "PRI" Then
                        strCampos = strCampos & ", " & DGVcampos.Rows.Item(i).Cells(0).Value.trim & "= '0'"
                        'If DGVcampos.Rows.Item(i).Cells(0).Value.trim = "id_empresa" Then
                        '    strCampos = strCampos & ", " & DGVcampos.Rows.Item(i).Cells(0).Value.trim & "=session['id_empresa']"
                        'Else
                        '    strCampos = strCampos & ", " & DGVcampos.Rows.Item(i).Cells(0).Value.trim & "= '0'"
                        'End If
                    End If
                Next i
                strLine = Replace(strLine, "@PRICREAR", strCampos)
            End If
            strLine = Replace(strLine, "@NOMBRE", Replace(Mid(nombretabla, 1, 1).ToUpper & Mid(nombretabla, 2, Len(nombretabla.Trim)), "_", " "))
            Blancos = InStr(1, strLine, "@TITULOS")
            If Blancos > 0 Then
                For i = 0 To DGVcampos.Rows.Count - 2
                    'If DGVcampos.Rows.Item(i).Cells(1).Value.trim = "PRI" Then
                    'primary = DGVcampos.Rows.Item(i).Cells(0).Value.trim
                    'End If
                    'titulo_columna = Replace(Mid(DGVcampos.Rows.Item(i).Cells(0).Value.trim, 1, 1).ToUpper & Mid(DGVcampos.Rows.Item(i).Cells(0).Value.trim, 2, Len(nombretabla.Trim)), "_", " ")
                    strLine = Space(Blancos - 1) & "<th>" & DGVcampos.Rows.Item(i).Cells(13).Value.trim & "</th>"
                    objStreamWriter.WriteLine(strLine)
                    strLine = ""
                Next i
            End If
            Blancos = InStr(1, strLine, "@DETALLE")
            If Blancos > 0 Then
                For i = 0 To DGVcampos.Rows.Count - 2
                    strLine = Space(Blancos - 1) & "<td align='left'>{{order." & DGVcampos.Rows.Item(i).Cells(0).Value.trim & "}}</td>"
                    objStreamWriter.WriteLine(strLine)
                    strLine = ""
                Next i
            End If
            If Len(strLine) > 0 Then
                objStreamWriter.WriteLine(strLine)
            End If
            strLine = objStreamReader.ReadLine
        Loop
        objStreamReader.Close()
        objStreamWriter.Close()


        objStreamReader = New StreamReader(appath & "\Plantilla_show.txt")
        objStreamWriter = New StreamWriter(appath & "\Formas\templates\frm_" & COBtablas.Text & "_show.html")
        nombretabla = COBtablas.Text
        strLine = objStreamReader.ReadLine
        Do While Not strLine Is Nothing
            strLine = Replace(strLine, "@TABLA", nombretabla)
            strLine = Replace(strLine, "@NOMBRE", Replace(nombretabla, "_", " "))
            Blancos = InStr(1, strLine, "@DETALLE")
            If Blancos > 0 Then
                For i = 0 To DGVcampos.Rows.Count - 2
                    'titulo_columna = Replace(Mid(DGVcampos.Rows.Item(i).Cells(0).Value.trim, 1, 1).ToUpper & Mid(DGVcampos.Rows.Item(i).Cells(0).Value.trim, 2, Len(nombretabla.Trim)), "_", " ")
                    strLine = Space(Blancos - 1) & "<div Class='form-group'>"
                    objStreamWriter.WriteLine(strLine)
                    strLine = Space(Blancos - 1) & "   <label for='" & DGVcampos.Rows.Item(i).Cells(0).Value & "'>" & DGVcampos.Rows.Item(i).Cells(13).Value.trim & "</label>"
                    objStreamWriter.WriteLine(strLine)
                    If Len(DGVcampos.Rows.Item(i).Cells(5).Value.trim) > 0 Then
                        'strLine = Space(Blancos - 1) & "<tr><th align = 'right'>" & DGVcampos.Rows.Item(i).Cells(13).Value.trim & "</td><td>"
                        'objStreamWriter.WriteLine(strLine)
                        strLine = Space(Blancos + 2) & "<select name=" & DGVcampos.Rows.Item(i).Cells(0).Value & " class='form-control simple-select' id=" & DGVcampos.Rows.Item(i).Cells(0).Value & " {{bloquea_claves}}>"
                        objStreamWriter.WriteLine(strLine)
                        If Mid(DGVcampos.Rows.Item(i).Cells(4).Value, 1, 1) > "0" Then
                            strLine = Space(Blancos + 2) & "{% for opt in " & DGVcampos.Rows.Item(i).Cells(5).Value & Mid(DGVcampos.Rows.Item(i).Cells(4).Value, 1, 1) & " %}"
                            objStreamWriter.WriteLine(strLine)
                        Else
                            strLine = Space(Blancos + 2) & "{% for opt in " & DGVcampos.Rows.Item(i).Cells(5).Value & " %}"
                            objStreamWriter.WriteLine(strLine)
                        End If
                        strLine = Space(Blancos + 2) & "  {% if opt." & DGVcampos.Rows.Item(i).Cells(6).Value & " == reg." & DGVcampos.Rows.Item(i).Cells(0).Value & " %}"
                        objStreamWriter.WriteLine(strLine)
                        strLine = Space(Blancos + 2) & "    <option selected value='{{opt." & DGVcampos.Rows.Item(i).Cells(6).Value & "}}'>{{opt." & DGVcampos.Rows.Item(i).Cells(7).Value & "}}</option>"
                        objStreamWriter.WriteLine(strLine)
                        strLine = Space(Blancos + 2) & "  {% else %}"
                        objStreamWriter.WriteLine(strLine)
                        strLine = Space(Blancos + 2) & "    <option value='{{opt." & DGVcampos.Rows.Item(i).Cells(6).Value & "}}'>{{opt." & DGVcampos.Rows.Item(i).Cells(7).Value & "}}</option>"
                        objStreamWriter.WriteLine(strLine)
                        strLine = Space(Blancos + 2) & "  {% endif %}"
                        objStreamWriter.WriteLine(strLine)
                        strLine = Space(Blancos + 2) & "{% endfor %}"
                        objStreamWriter.WriteLine(strLine)
                        '<option value="volvo"> Volvo</Option>
                        strLine = Space(Blancos + 2) & "</select>"
                        objStreamWriter.WriteLine(strLine)
                        strLine = ""
                    Else
                        requerido = ""
                        Select Case DGVcampos.Rows.Item(i).Cells(2).Value.trim
                            Case "date"
                                tipocampo = "'date'"
                                requerido = " required "
                            Case "tinyint"
                                tipocampo = "'checkbox'"
                            Case "varchar"
                                tipocampo = "'text'"
                            Case "int"
                                'max = 0
                                'For j = i To Val(DGVcampos.Rows.Item(i).Cells(9).Value.trim)
                                '    max = max + 9 * 10 ^ (j - 1)
                                'Next j
                                tipocampo = "'number' step='1' min=" & DGVcampos.Rows.Item(i).Cells(14).Value.trim & " max='" & DGVcampos.Rows.Item(i).Cells(15).Value.trim & "'"
                                requerido = " required "
                            Case "decimal"
                                'max = 0
                                'For j = i To Val(DGVcampos.Rows.Item(i).Cells(9).Value.trim)
                                '    max = max + 9 * 10 ^ (j - 1)
                                'Next j
                                If DGVcampos.Rows.Item(i).Cells(10).Value = 2 Then
                                    paso = "0.01"
                                Else
                                    If DGVcampos.Rows.Item(i).Cells(10).Value = 3 Then
                                        paso = "0.001"
                                    Else
                                        If DGVcampos.Rows.Item(i).Cells(10).Value = 1 Then
                                            paso = "0.1"
                                        Else
                                            If DGVcampos.Rows.Item(i).Cells(10).Value = 0 Then
                                                paso = "1"
                                            Else
                                                If DGVcampos.Rows.Item(i).Cells(10).Value = 4 Then
                                                    paso = "0.0001"
                                                Else
                                                    paso = "0.01"
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                                tipocampo = "'number' step='" & paso & "' min='" & DGVcampos.Rows.Item(i).Cells(14).Value.trim & "' max='" & DGVcampos.Rows.Item(i).Cells(15).Value.trim & "'"
                                requerido = " required "
                            Case Else
                                tipocampo = "'text'"
                        End Select

                        If DGVcampos.Rows.Item(i).Cells(1).Value.trim = "PRI" Then
                            If DGVcampos.Rows.Item(i).Cells(0).Value.trim = "id_empresa" Then
                                strLine = Space(Blancos + 2) & "<input type=" & tipocampo & " class=form-control id=" & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " name=" & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " size=" & Val(DGVcampos.Rows.Item(i).Cells(3).Value.trim) + 10 & " maxlenght=" & DGVcampos.Rows.Item(i).Cells(3).Value.trim & " value='{{reg." & DGVcampos.Rows.Item(i).Cells(0).Value.trim & "}}' required readonly>"
                                objStreamWriter.WriteLine(strLine)
                            Else
                                strLine = Space(Blancos + 2) & "<input type=" & tipocampo & " class=form-control id=" & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " name=" & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " size=" & Val(DGVcampos.Rows.Item(i).Cells(3).Value.trim) + 10 & " maxlenght=" & DGVcampos.Rows.Item(i).Cells(3).Value.trim & " value='{{reg." & DGVcampos.Rows.Item(i).Cells(0).Value.trim & "}}' {{bloquea_claves}} required>"
                                objStreamWriter.WriteLine(strLine)
                            End If
                        Else
                            If tipocampo = "'checkbox'" Then
                                strLine = Space(Blancos + 2) & "<input type=" & tipocampo & " class=form-control id=" & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " name=" & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " value='{{reg." & DGVcampos.Rows.Item(i).Cells(0).Value.trim & "}}' {{bloquea_campos}}"
                                objStreamWriter.WriteLine(strLine)
                                strLine = Space(Blancos + 2 + 5) & "{% if reg." & DGVcampos.Rows.Item(i).Cells(0).Value.trim & "> 0 %}"
                                objStreamWriter.WriteLine(strLine)
                                strLine = Space(Blancos + 2 + 10) & "checked"
                                objStreamWriter.WriteLine(strLine)
                                strLine = Space(Blancos + 2 + 10) & "{% endif %}"
                                objStreamWriter.WriteLine(strLine)
                                strLine = ">"
                                objStreamWriter.WriteLine(strLine)
                            Else
                                strLine = Space(Blancos + 2) & "<input type=" & tipocampo & " class=form-control id=" & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " name=" & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " size=" & Val(DGVcampos.Rows.Item(i).Cells(3).Value.trim) + 10 & " maxlenght=" & DGVcampos.Rows.Item(i).Cells(3).Value.trim & " value='{{reg." & DGVcampos.Rows.Item(i).Cells(0).Value.trim & "}}' {{bloquea_campos}} " & requerido & ">"
                                objStreamWriter.WriteLine(strLine)
                            End If
                        End If
                        'objStreamWriter.WriteLine(strLine)
                        strLine = ""
                    End If
                    strLine = Space(Blancos + 3) & "</div>"
                    objStreamWriter.WriteLine(strLine)

                Next i
            End If
            If Len(strLine) > 0 Then
                objStreamWriter.WriteLine(strLine)
            End If
            strLine = objStreamReader.ReadLine
        Loop
        objStreamReader.Close()
        objStreamWriter.Close()

        objStreamReader = New StreamReader(appath & "\Plantilla_py.txt")
        objStreamWriter = New StreamWriter(appath & "\Formas\frm_" & COBtablas.Text & ".py")

        strLine = objStreamReader.ReadLine
        Do While Not strLine Is Nothing
            strLine = Replace(strLine, "@TABLA", nombretabla)
            strLine = Replace(strLine, "@PARAMETROS", parametros)
            Blancos = InStr(1, strLine, "@REQUEST")
            If Blancos > 0 Then
                For i = 0 To DGVcampos.Rows.Count - 2
                    If DGVcampos.Rows.Item(i).Cells(2).Value.trim = "tinyint" Then
                        strLine = Space(Blancos - 1) & "if request.form.get('" & DGVcampos.Rows.Item(i).Cells(0).Value.trim & "'):"
                        objStreamWriter.WriteLine(strLine)
                        strLine = Space(Blancos - 1 + 3) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & "='1'"
                        objStreamWriter.WriteLine(strLine)
                        strLine = Space(Blancos - 1) & "else:"
                        objStreamWriter.WriteLine(strLine)
                        strLine = Space(Blancos - 1 + 3) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & "='0'"
                        objStreamWriter.WriteLine(strLine)
                    Else
                        strLine = Space(Blancos - 1) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & "=str(request.form['" & DGVcampos.Rows.Item(i).Cells(0).Value.trim & "'])"
                        objStreamWriter.WriteLine(strLine)
                    End If
                Next i
                strLine = ""
            End If
            Blancos = InStr(1, strLine, "@COMBOS")
            If Blancos > 0 Then
                parametros = ""
                For i = 0 To DGVcampos.Rows.Count - 2
                    If Len(DGVcampos.Rows.Item(i).Cells(5).Value.trim) > 0 Then
                        strLine = Space(Blancos - 1) & "sql = ""select " & DGVcampos.Rows.Item(i).Cells(6).Value & ", " & DGVcampos.Rows.Item(i).Cells(7).Value & " from " & DGVcampos.Rows.Item(i).Cells(5).Value & """"
                        If Trim(DGVcampos.Rows.Item(i).Cells(5).Value) = "municipios" Or Trim(DGVcampos.Rows.Item(i).Cells(5).Value) = "categorias_arl" Then
                            If Len(DGVcampos.Rows.Item(i).Cells(4).Value.trim) > 0 Then
                                If Len(DGVcampos.Rows.Item(i).Cells(4).Value.trim) > 15 Then
                                    strLine = strLine & " + "" where 1 "" " & Replace(Mid(DGVcampos.Rows.Item(i).Cells(4).Value.trim, 3, 30), "?", "'") & " """
                                Else
                                    strLine = strLine & " + "" where 1 "" "
                                End If
                            End If
                            strLine = strLine & " +  "" ORDER BY nombre "" "
                        Else
                            If Len(DGVcampos.Rows.Item(i).Cells(4).Value.trim) > 0 Then
                                If Len(DGVcampos.Rows.Item(i).Cells(4).Value.trim) > 15 Then
                                    strLine = strLine & " + "" where id_empresa = "" + str(session['id_empresa']) + "" " & Replace(Mid(DGVcampos.Rows.Item(i).Cells(4).Value.trim, 3, 30), "?", "'") & " """
                                Else
                                    strLine = strLine & " + "" where id_empresa = "" + str(session['id_empresa']) "
                                End If
                            End If
                        End If
                        objStreamWriter.WriteLine(strLine)
                        strLine = Space(Blancos - 1) & "cur = mysql.connection.cursor()"
                        objStreamWriter.WriteLine(strLine)
                        strLine = Space(Blancos - 1) & "print('sql:',sql)"
                        objStreamWriter.WriteLine(strLine)
                        strLine = Space(Blancos - 1) & "cur.execute(sql)"
                        objStreamWriter.WriteLine(strLine)
                        If Len(DGVcampos.Rows.Item(i).Cells(4).Value.trim) > 0 Then
                            If Mid(DGVcampos.Rows.Item(i).Cells(4).Value.trim, 1, 1) = "0" Then
                                strLine = Space(Blancos - 1) & DGVcampos.Rows.Item(i).Cells(5).Value & " = cur.fetchall()"
                                objStreamWriter.WriteLine(strLine)
                                '<option value="volvo"> Volvo</Option>
                                parametros = parametros & ", " & DGVcampos.Rows.Item(i).Cells(5).Value & " = " & DGVcampos.Rows.Item(i).Cells(5).Value
                            Else
                                strLine = Space(Blancos - 1) & DGVcampos.Rows.Item(i).Cells(5).Value & Mid(DGVcampos.Rows.Item(i).Cells(4).Value.trim, 1, 1) & " = cur.fetchall()"
                                objStreamWriter.WriteLine(strLine)
                                '<option value="volvo"> Volvo</Option>
                                parametros = parametros & ", " & DGVcampos.Rows.Item(i).Cells(5).Value & Mid(DGVcampos.Rows.Item(i).Cells(4).Value.trim, 1, 1) & " = " & DGVcampos.Rows.Item(i).Cells(5).Value & Mid(DGVcampos.Rows.Item(i).Cells(4).Value.trim, 1, 1)
                            End If
                        Else
                            strLine = Space(Blancos - 1) & DGVcampos.Rows.Item(i).Cells(5).Value & " = cur.fetchall()"
                            objStreamWriter.WriteLine(strLine)
                            '<option value="volvo"> Volvo</Option>
                            parametros = parametros & ", " & DGVcampos.Rows.Item(i).Cells(5).Value & " = " & DGVcampos.Rows.Item(i).Cells(5).Value
                        End If
                        strLine = ""
                    End If
                Next i
            End If

            Blancos = InStr(1, strLine, "@ROUTE")
            If Blancos > 0 Then
                strCampos = ""
                For i = 0 To DGVcampos.Rows.Count - 2
                    If DGVcampos.Rows.Item(i).Cells(1).Value.trim = "PRI" Then
                        strCampos = strCampos & "/<" & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ">"
                    End If
                Next i
                strLine = Replace(strLine, "@ROUTE", strCampos)
            End If
            Blancos = InStr(1, strLine, "@CLAVE")
            If Blancos > 0 Then
                strCampos = ""
                For i = 0 To DGVcampos.Rows.Count - 2
                    If DGVcampos.Rows.Item(i).Cells(1).Value.trim = "PRI" Then
                        strCampos = strCampos & ", " & DGVcampos.Rows.Item(i).Cells(0).Value.trim
                    End If
                Next i
                strLine = Replace(strLine, "@CLAVE", strCampos)
            End If


            strLine = Replace(strLine, "@COMBOS", "")

            Blancos = InStr(1, strLine, "@INSERT")
            If Blancos > 0 Then
                strLine = Space(Blancos - 1) & "sql = ""insert into " & nombretabla & " ("
                strLine1 = " values ("""
                operador = ""
                operador1 = ""
                For i = 0 To DGVcampos.Rows.Count - 2
                    strLine = strLine & operador & DGVcampos.Rows.Item(i).Cells(0).Value.trim
                    operador = ", "
                    If DGVcampos.Rows.Item(i).Cells(2).Value.trim = "varchar" Or DGVcampos.Rows.Item(i).Cells(2).Value.trim = "date" Then
                        If Len(DGVcampos.Rows.Item(i).Cells(5).Value.trim) > 0 Then
                            strLine1 = strLine1 & operador1 & " + ""'""" & " + " & val_empresa(DGVcampos.Rows.Item(i).Cells(0).Value.trim) & " + ""'"""
                        Else
                            strLine1 = strLine1 & operador1 & " + ""'""" & " + " & val_empresa(DGVcampos.Rows.Item(i).Cells(0).Value.trim) & " + ""'"""
                        End If
                    Else
                        If Len(DGVcampos.Rows.Item(i).Cells(5).Value.trim) > 0 Then
                            strLine1 = strLine1 & operador1 & " + " & val_empresa(DGVcampos.Rows.Item(i).Cells(0).Value.trim)
                        Else
                            If DGVcampos.Rows.Item(i).Cells(2).Value.trim = "tinyint" Then
                                strLine1 = strLine1 & operador1 & " + " & val_empresa(DGVcampos.Rows.Item(i).Cells(0).Value.trim)
                            Else
                                strLine1 = strLine1 & operador1 & " + " & val_empresa(DGVcampos.Rows.Item(i).Cells(0).Value.trim)
                            End If
                        End If
                    End If
                    operador1 = " + "","" "
                Next i
                objStreamWriter.WriteLine(strLine & ")" & strLine1 & " + "")""")
                strLine = ""
            End If

            Blancos = InStr(1, strLine, "@UPDATE")
            If Blancos > 0 Then
                operador = ""
                operador1 = ""
                strLine = Space(Blancos - 1) & "sql = ""update " & nombretabla & " set "
                strLine1 = " + "" where "
                For i = 0 To DGVcampos.Rows.Count - 2
                    If DGVcampos.Rows.Item(i).Cells(1).Value.trim <> "PRI" Then
                        If DGVcampos.Rows.Item(i).Cells(2).Value.trim = "varchar" Or DGVcampos.Rows.Item(i).Cells(2).Value.trim = "date" Then
                            If Len(DGVcampos.Rows.Item(i).Cells(5).Value.trim) > 0 Then
                                strLine = strLine & operador & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " = '"" +  " & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " + ""'"""
                            Else
                                strLine = strLine & operador & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " = '"" +  " & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " + ""'"""
                            End If
                        Else
                            If DGVcampos.Rows.Item(i).Cells(2).Value.trim = "tinyint" Then
                                strLine = strLine & operador & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " = "" + " & DGVcampos.Rows.Item(i).Cells(0).Value.trim
                            Else
                                If Len(DGVcampos.Rows.Item(i).Cells(5).Value.trim) > 0 Then
                                    strLine = strLine & operador & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " = "" +  " & DGVcampos.Rows.Item(i).Cells(0).Value.trim
                                Else
                                    strLine = strLine & operador & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " = "" +  " & DGVcampos.Rows.Item(i).Cells(0).Value.trim
                                End If
                            End If
                        End If
                        operador = " + "","" + "" "
                    Else
                        If DGVcampos.Rows.Item(i).Cells(2).Value.trim = "varchar" Or DGVcampos.Rows.Item(i).Cells(2).Value.trim = "date" Then
                            If Len(DGVcampos.Rows.Item(i).Cells(5).Value.trim) > 0 Then
                                strLine1 = strLine1 & operador1 & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " = '"" +  " & val_empresa(DGVcampos.Rows.Item(i).Cells(0).Value.trim) & " + ""'"""
                            Else
                                strLine1 = strLine1 & operador1 & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " = '"" +  " & val_empresa(DGVcampos.Rows.Item(i).Cells(0).Value.trim) & " + ""'"""
                            End If
                        Else
                            If Len(DGVcampos.Rows.Item(i).Cells(5).Value.trim) > 0 Then
                                strLine1 = strLine1 & operador1 & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " = "" +  " & val_empresa(DGVcampos.Rows.Item(i).Cells(0).Value.trim)
                            Else
                                strLine1 = strLine1 & operador1 & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " = "" +  " & val_empresa(DGVcampos.Rows.Item(i).Cells(0).Value.trim)
                            End If
                        End If
                        operador1 = " + "" and  "
                    End If
                Next i
                objStreamWriter.WriteLine(strLine & " " & strLine1)

                strLine = ""
            End If

            Blancos = InStr(1, strLine, "@DELETE")
            If Blancos > 0 Then
                operador = ""
                strLine = Space(Blancos - 1) & "sql = ""delete from  " & nombretabla & " where "
                operador = ""
                y = 1
                For i = 0 To DGVcampos.Rows.Count - 2
                    If DGVcampos.Rows.Item(i).Cells(1).Value.trim = "PRI" Then
                        If DGVcampos.Rows.Item(i).Cells(2).Value.trim = "varchar" Then
                            strLine = strLine & operador & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " = '"" + " & val_empresa(DGVcampos.Rows.Item(i).Cells(0).Value.trim) & " + ""'"""
                        Else
                            strLine = strLine & operador & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " = "" + " & val_empresa(DGVcampos.Rows.Item(i).Cells(0).Value.trim)
                        End If
                        y = y + 1
                        operador = " + "" and  "
                    End If
                Next i
                objStreamWriter.WriteLine(strLine)
                strLine = ""
            End If

            Blancos = InStr(1, strLine, "@SELECT")
            If Blancos > 0 Then
                'For i = 0 To DGVcampos.Rows.Count - 2
                '    If DGVcampos.Rows.Item(i).Cells(1).Value.trim = "PRI" Then
                '        strLine = Space(Blancos - 1) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & "=str(request.form['" & DGVcampos.Rows.Item(i).Cells(0).Value.trim & "'])"
                '        objStreamWriter.WriteLine(strLine)
                '    End If
                'Next
                strLine = Space(Blancos - 1) & "sql = ""select * from " & nombretabla & " where "
                operador = ""
                For i = 0 To DGVcampos.Rows.Count - 2
                    If DGVcampos.Rows.Item(i).Cells(1).Value.trim = "PRI" Then
                        If TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) = "COB" Then
                            strLine = strLine & operador & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " = '"" + " & val_empresa(DGVcampos.Rows.Item(i).Cells(0).Value.trim) & " + ""'"""
                        Else
                            If DGVcampos.Rows.Item(i).Cells(2).Value.trim = "varchar" Then
                                'strLine = strLine & operador & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " = '"" + str(" & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ") + ""'"""
                                strLine = strLine & operador & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " = '"" + " & val_empresa(DGVcampos.Rows.Item(i).Cells(0).Value.trim) & "+ ""'"""
                            Else
                                strLine = strLine & operador & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " = "" + " & val_empresa(DGVcampos.Rows.Item(i).Cells(0).Value.trim)
                            End If
                        End If
                        operador = " + "" and  "
                    End If
                Next i
                objStreamWriter.WriteLine(strLine)
                strLine = ""
            End If

            Blancos = InStr(1, strLine, "@LLENA_REG")
            If Blancos > 0 Then
                For i = 0 To DGVcampos.Rows.Count - 2
                    strLine = Space(Blancos - 1) & "reg['" & DGVcampos.Rows.Item(i).Cells(0).Value.trim & "']=" & DGVcampos.Rows.Item(i).Cells(0).Value.trim
                    objStreamWriter.WriteLine(strLine)
                Next i
                strLine = ""
            End If

            Blancos = InStr(1, strLine, "@FILTRO")
            If Blancos > 0 Then
                operador = "fil = "" and  ( "
                For i = 0 To DGVcampos.Rows.Count - 2
                    If DGVcampos.Rows.Item(i).Cells(0).Value.trim <> "id_empresa" Then
                        strLine = Space(Blancos - 1) & operador & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " like '%"" + filtro + ""%'"" "
                        operador = "fil = fil + "" or "
                        objStreamWriter.WriteLine(strLine)
                        strLine = ""
                    End If
                Next i
                strLine = Space(Blancos - 1) & "fil = fil + "")"" "
                objStreamWriter.WriteLine(strLine)
                strLine = ""
            End If

            Blancos = InStr(1, strLine, "@INICIALIZA_CHECKBOX")
            If Blancos > 0 Then
                For i = 0 To DGVcampos.Rows.Count - 2
                    If DGVcampos.Rows.Item(i).Cells(2).Value.trim = "tinyint" Then
                        strLine = Space(Blancos - 1) & "registro['" & DGVcampos.Rows.Item(i).Cells(0).Value.trim & "']=0"
                        objStreamWriter.WriteLine(strLine)
                        strLine = ""
                    End If
                Next i
                strLine = ""
            End If

            If Len(strLine) > 0 Then
                objStreamWriter.WriteLine(strLine)
            End If
            strLine = objStreamReader.ReadLine
        Loop
        objStreamReader.Close()
        objStreamWriter.Close()

        'MsgBox("Aqui vamos")

        'For i = 0 To DGVcampos.Rows.Count - 2
        '    If (Len(DGVcampos.Rows.Item(i).Cells(0).Value.trim) > Maxlabel) Then
        '        MaxLabel = Len(DGVcampos.Rows.Item(i).Cells(0).Value.trim)
        '    End If
        'Next i
        'MaxLabel = MaxLabel * 5

        'objStreamReader = New StreamReader(appath & "\Plantilla1.Designer.vb")
        'objStreamWriter = New StreamWriter(appath & "\Formas\" & NombreFormatexbox.Text & "1.Designer.vb")

        'strLine = objStreamReader.ReadLine
        'Do While Not strLine Is Nothing
        '    strLine = Replace(strLine, "@NOMBRETABLA", COBtablas.Text)
        '    strLine = Replace(strLine, "@NOMBREFORMA", NombreFormatexbox.Text & "1")
        '    strLine = Replace(strLine, "@LLAMAFORMA", NombreFormatexbox.Text)
        '    strLine = Replace(strLine, "@TITULOFORMA", TituloFormatexbox.Text)
        '    objStreamWriter.WriteLine(strLine)
        '    strLine = objStreamReader.ReadLine
        'Loop
        'objStreamReader.Close()
        'objStreamWriter.Close()
        ''MsgBox("Forma: " & appath & "\Formas\" & NombreFormatexbox.Text & ".Designer.vb" & " Generada!")

        'objStreamReader = New StreamReader(appath & "\Plantilla1.vb")
        'objStreamWriter = New StreamWriter(appath & "\Formas\" & NombreFormatexbox.Text & "1.vb")

        'strLine = objStreamReader.ReadLine
        'Do While Not strLine Is Nothing
        '    Select Case Trim(strLine)
        '        Case "@LEEDBID"
        '            strLine = "        sql = ""select "
        '            'strLine1 = " where "
        '            operador = ""
        '            operador1 = ""
        '            For i = 0 To DGVcampos.Rows.Count - 2
        '                strLine = strLine & operador & COBtablas.Text & "." & DGVcampos.Rows.Item(i).Cells(0).Value.trim
        '                operador = ", "
        '                If Len(DGVcampos.Rows.Item(i).Cells(7).Value.trim) > 1 Then
        '                    strLine = strLine & operador & DGVcampos.Rows.Item(i).Cells(5).Value.trim & "." & DGVcampos.Rows.Item(i).Cells(7).Value.trim
        '                    strLine2 = strLine2 & " inner join " & DGVcampos.Rows.Item(i).Cells(5).Value.trim & " on " & COBtablas.Text & "." & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " = " & DGVcampos.Rows.Item(i).Cells(5).Value.trim & "." & DGVcampos.Rows.Item(i).Cells(6).Value.trim
        '                    'Else
        '                    '    strLine = strLine & operador & COBtablas.Text & "." & DGVcampos.Rows.Item(i).Cells(0).Value.trim
        '                End If

        '            Next i
        '            'strLine = strLine & " from " & COBtablas.Text & " " & strLine2 & strLine1
        '            strLine = strLine & " from " & COBtablas.Text & " " & strLine2 & """"
        '            'MsgBox(strLine)
        '            objStreamWriter.WriteLine(strLine)
        '        Case "@FORMATEADTGV"
        '            strLine = "        DGV" & COBtablas.Text & ".ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter"
        '            objStreamWriter.WriteLine(strLine)
        '            y = 0
        '            For i = 0 To DGVcampos.Rows.Count - 2
        '                strLine = "        DGV" & COBtablas.Text & ".columns(" & y & ").DefaultCellStyle.format = """ & DGVcampos.Rows.Item(i).Cells(8).Value.trim & """"
        '                objStreamWriter.WriteLine(strLine)
        '                If InStr(1, DGVcampos.Rows.Item(i).Cells(8).Value.trim, "#") > 0 Then
        '                    strLine = "        DGV" & COBtablas.Text & ".columns(" & y & ").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight "
        '                Else
        '                    strLine = "        DGV" & COBtablas.Text & ".columns(" & y & ").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter "
        '                End If
        '                objStreamWriter.WriteLine(strLine)
        '                y = y + 1
        '                If Len(DGVcampos.Rows.Item(i).Cells(5).Value.trim) > 0 Then
        '                    y = y + 1
        '                End If
        '            Next i
        '        Case "@PASAPARAMETROS"
        '            y = 1
        '            For i = 0 To DGVcampos.Rows.Count - 2
        '                If DGVcampos.Rows.Item(i).Cells(1).Value.trim = "PRI" Then
        '                    strLine = "        " & NombreFormatexbox.Text & "2.var" & y & " = DGV" & COBtablas.Text & ".CurrentRow.Cells(""" & DGVcampos.Rows.Item(i).Cells(0).Value.trim & """).Value"
        '                    y = y + 1
        '                    objStreamWriter.WriteLine(strLine)
        '                End If
        '            Next i
        '        Case Else
        '            strLine = Replace(strLine, "@NOMBRETABLA", COBtablas.Text)
        '            strLine = Replace(strLine, "@NOMBREFORMA", NombreFormatexbox.Text & "1")
        '            strLine = Replace(strLine, "@LLAMAFORMA", NombreFormatexbox.Text)
        '            strLine = Replace(strLine, "@TITULOFORMA", TituloFormatexbox.Text)
        '            objStreamWriter.WriteLine(strLine)
        '    End Select
        '    strLine = objStreamReader.ReadLine
        'Loop
        'objStreamReader.Close()
        'objStreamWriter.Close()
        'MsgBox("Forma: " & appath & "\Formas\" & NombreFormatexbox.Text & "1.vb" & " Generada!")

        'Try
        '    My.Computer.FileSystem.CopyFile(appath & "\Plantilla2.resx", appath & "\Formas\" & NombreFormatexbox.Text & "2.resx")
        'Catch ex As Exception

        'End Try


        'objStreamReader = New StreamReader(appath & "\Plantilla2.Designer.vb")
        'objStreamWriter = New StreamWriter(appath & "\Formas\" & NombreFormatexbox.Text & "2.Designer.vb")

        'strLine = objStreamReader.ReadLine

        'Do While Not strLine Is Nothing
        '    Select Case Trim(strLine)
        '        Case "@DEFINICIONLABEL"
        '            'For i = 0 To DGVcampos.Rows.Count - 2
        '            'strLine = "        Dim LAB" & DGVcampos.Rows.Item(i).Cells(0).Value.trim & "  As System.Windows.Forms.Label"
        '            'objStreamWriter.WriteLine(strLine)
        '            'Next i
        '        Case "@DEFINICIONTEXTBOX"
        '            For i = 0 To DGVcampos.Rows.Count - 2
        '                Select Case DGVcampos.Rows.Item(i).Cells(2).Value.trim
        '                    Case "date"
        '                        strLine = "        Me.DTP" & DGVcampos.Rows.Item(i).Cells(0).Value.trim & "   = New System.Windows.Forms.DateTimePicker()"
        '                    Case "tinyint"
        '                        strLine = "        Me.CHB" & DGVcampos.Rows.Item(i).Cells(0).Value.trim & "   = New System.Windows.Forms.CheckBox()"
        '                    Case "varchar"
        '                        If Len(DGVcampos.Rows.Item(i).Cells(5).Value.trim) > 0 Then
        '                            strLine = "        Me.COB" & DGVcampos.Rows.Item(i).Cells(0).Value.trim & "   = New System.Windows.Forms.ComboBox()"
        '                        Else
        '                            strLine = "        Me.TBO" & DGVcampos.Rows.Item(i).Cells(0).Value.trim & "   = New System.Windows.Forms.TextBox()"
        '                        End If
        '                    Case Else
        '                        If Len(DGVcampos.Rows.Item(i).Cells(5).Value.trim) > 0 Then
        '                            strLine = "        Me.COB" & DGVcampos.Rows.Item(i).Cells(0).Value.trim & "   = New System.Windows.Forms.ComboBox()"
        '                        Else
        '                            strLine = "        Me.TBO" & DGVcampos.Rows.Item(i).Cells(0).Value.trim & "   = New System.Windows.Forms.TextBox()"
        '                        End If
        '                End Select
        '                'strLine = "        Me." & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & "   = New System.Windows.Forms.TextBox()"
        '                objStreamWriter.WriteLine(strLine)
        '            Next i
        '        Case "@DEFINICIONNEWLABEL"
        '            For i = 0 To DGVcampos.Rows.Count - 2
        '                strLine = "     Me.LAB" & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " = New System.Windows.Forms.Label()"
        '                objStreamWriter.WriteLine(strLine)
        '            Next i
        '        Case "@DETALLELABEL"
        '            y = 0
        '            For i = 0 To DGVcampos.Rows.Count - 2
        '                y += 26
        '                strLine = "        '"
        '                objStreamWriter.WriteLine(strLine)
        '                strLine = "        'LAB" & DGVcampos.Rows.Item(i).Cells(0).Value.trim
        '                objStreamWriter.WriteLine(strLine)
        '                strLine = "        '"
        '                objStreamWriter.WriteLine(strLine)
        '                strLine = "     Me.LAB" & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".AutoSize = False"
        '                objStreamWriter.WriteLine(strLine)
        '                strLine = "     Me.LAB" & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".TextAlign = System.Drawing.ContentAlignment.BottomRight"
        '                objStreamWriter.WriteLine(strLine)
        '                strLine = "     Me.LAB" & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".Location = New System.Drawing.Point(15, " & y & ")"
        '                objStreamWriter.WriteLine(strLine)
        '                strLine = "     Me.LAB" & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".Name = ""LAB" & DGVcampos.Rows.Item(i).Cells(0).Value.trim & """"
        '                objStreamWriter.WriteLine(strLine)
        '                strLine = "     Me.LAB" & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".Size = New System.Drawing.Size(" & MaxLabel & ", 13)"
        '                objStreamWriter.WriteLine(strLine)
        '                strLine = "     Me.LAB" & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".TabIndex = 30"
        '                objStreamWriter.WriteLine(strLine)

        '                LABcampo = Replace(DGVcampos.Rows.Item(i).Cells(0).Value.trim, "_", " ")
        '                LABcampo = Mid(LABcampo, 1, 1).ToUpper & Mid(LABcampo, 2, Len(LABcampo))
        '                strLine = "     Me.LAB" & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".Text = """ & LABcampo & ":"""
        '                objStreamWriter.WriteLine(strLine)
        '            Next i
        '        Case "@DETALLETEXBOX"
        '            y = 0
        '            For i = 0 To DGVcampos.Rows.Count - 2
        '                y += 26
        '                tipo = TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i)
        '                strLine = "        '"
        '                objStreamWriter.WriteLine(strLine)
        '                'strLine = "        'TBO" & DGVcampos.Rows.Item(i).Cells(0).Value.trim
        '                strLine = "        '" & tipo & DGVcampos.Rows.Item(i).Cells(0).Value.trim
        '                objStreamWriter.WriteLine(strLine)
        '                strLine = "        '"
        '                objStreamWriter.WriteLine(strLine)
        '                If tipo = "TBO" Then
        '                    strLine = "     Me." & tipo & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".AutoSize = True"
        '                    objStreamWriter.WriteLine(strLine)
        '                End If
        '                If tipo = "COB" Then
        '                    strLine = "     Me." & tipo & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".FormattingEnabled = True"
        '                    objStreamWriter.WriteLine(strLine)
        '                End If
        '                strLine = "     Me." & tipo & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".Location = New System.Drawing.Point(" & MaxLabel + 20 & ", " & y & ")"
        '                objStreamWriter.WriteLine(strLine)
        '                strLine = "     Me." & tipo & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".Name = """ & tipo & DGVcampos.Rows.Item(i).Cells(0).Value.trim & """"
        '                objStreamWriter.WriteLine(strLine)
        '                If tipo = "DTP" Then
        '                    strLine = "     Me." & tipo & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".Size = New System.Drawing.Size(" & MaxLabel + 20 & ", 20)"
        '                    objStreamWriter.WriteLine(strLine)
        '                Else
        '                    If tipo = "COB" Then
        '                        strLine = "     Me." & tipo & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".Size = New System.Drawing.Size(300, 20)"
        '                        objStreamWriter.WriteLine(strLine)
        '                    Else
        '                        strLine = "     Me." & tipo & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".Size = New System.Drawing.Size( " & IIf(Val(DGVcampos.Rows.Item(i).Cells(3).Value.trim) < 10, 10, Val(DGVcampos.Rows.Item(i).Cells(3).Value.trim)) * 5 & ", 20)"
        '                        objStreamWriter.WriteLine(strLine)
        '                    End If
        '                End If
        '                strLine = "     Me." & tipo & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".TabIndex = " & i
        '                objStreamWriter.WriteLine(strLine)
        '            Next i
        '        Case "@ADDCONTROLES"
        '            For i = 0 To DGVcampos.Rows.Count - 2
        '                strLine = "        Me.Controls.Add(Me.LAB" & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ")"
        '                objStreamWriter.WriteLine(strLine)
        '                strLine = "        Me.Controls.Add(Me." & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ")"
        '                objStreamWriter.WriteLine(strLine)
        '            Next i
        '        Case "@FRIENDTEXBOX"
        '            For i = 0 To DGVcampos.Rows.Count - 2
        '                tipo = TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i)
        '                Select Case tipo
        '                    Case "COB"
        '                        tipocampo = "ComboBox"
        '                    Case "TBO"
        '                        tipocampo = "TextBox"
        '                    Case "DTP"
        '                        tipocampo = "DateTimePicker"
        '                    Case "CHB"
        '                        tipocampo = "CheckBox"
        '                End Select
        '                strLine = "    Friend WithEvents " & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " As " & tipocampo
        '                objStreamWriter.WriteLine(strLine)
        '                strLine = "    Friend WithEvents LAB" & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " As Label"
        '                objStreamWriter.WriteLine(strLine)
        '            Next i
        '        Case Else
        '            strLine = Replace(strLine, "@NOMBRETABLA", COBtablas.Text)
        '            strLine = Replace(strLine, "@NOMBREFORMA", NombreFormatexbox.Text)
        '            strLine = Replace(strLine, "@LLAMAFORMA", NombreFormatexbox.Text)
        '            strLine = Replace(strLine, "@TITULOFORMA", TituloFormatexbox.Text)
        '            objStreamWriter.WriteLine(strLine)
        '    End Select
        '    strLine = objStreamReader.ReadLine
        'Loop
        'objStreamReader.Close()
        'objStreamWriter.Close()
        ''MsgBox("Forma: " & appath & "\Formas\" & NombreFormatexbox.Text & "2.vb" & " Generada!")

        'objStreamReader = New StreamReader(appath & "\Plantilla2.vb")
        'objStreamWriter = New StreamWriter(appath & "\Formas\" & NombreFormatexbox.Text & "2.vb")

        'strLine = objStreamReader.ReadLine

        'Do While Not strLine Is Nothing
        '    Select Case Trim(strLine)
        '        Case "@TAMAÑOTEXBOX"
        '            For i = 0 To DGVcampos.Rows.Count - 2
        '                Try
        '                    If DGVcampos.Rows.Item(i).Cells(3).Value = 0 Then
        '                        Tamaño = 15
        '                    Else
        '                        Tamaño = DGVcampos.Rows.Item(i).Cells(3).Value
        '                    End If
        '                Catch ex As Exception
        '                    Tamaño = 15
        '                End Try

        '                If DGVcampos.Rows.Item(i).Cells(2).Value.ToString <> "date" Then
        '                    strLine = "        " & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".MaxLength = " & Tamaño
        '                Else
        '                    If DGVcampos.Rows.Item(i).Cells(2).Value.ToString <> "tinyint" Then
        '                        strLine = "        " & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".Format = DateTimePickerFormat.Short"
        '                        objStreamWriter.WriteLine(strLine)
        '                    End If
        '                End If
        '                If (DGVcampos.Rows.Item(i).Cells(2).Value.trim = "decimal" Or
        '                    DGVcampos.Rows.Item(i).Cells(2).Value.trim = "double" Or
        '                    DGVcampos.Rows.Item(i).Cells(2).Value.trim = "int") And Len(DGVcampos.Rows.Item(i).Cells(5).Value.trim) = 0 Then
        '                    strLine = "        " & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".TextAlign = HorizontalAlignment.Right"
        '                    objStreamWriter.WriteLine(strLine)
        '                End If
        '            Next i
        '        Case "@CARGACOMBOBOX"
        '            For i = 0 To DGVcampos.Rows.Count - 2
        '                If DGVcampos.Rows.Item(i).Cells(5).Value.trim <> "" Then
        '                    strLine = "     sql = ""select * from " & DGVcampos.Rows.Item(i).Cells(5).Value.trim & " " & DGVcampos.Rows.Item(i).Cells(4).Value.trim & """"
        '                    objStreamWriter.WriteLine(strLine)
        '                    strLine = "     dv = DBVcmd(sql)"
        '                    objStreamWriter.WriteLine(strLine)
        '                    strLine = "     COB" & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".DataSource = dv"
        '                    objStreamWriter.WriteLine(strLine)
        '                    strLine = "     COB" & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".DisplayMember = " & """" & DGVcampos.Rows.Item(i).Cells(7).Value.trim & """"
        '                    objStreamWriter.WriteLine(strLine)
        '                    strLine = "     COB" & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".ValueMember = " & """" & DGVcampos.Rows.Item(i).Cells(6).Value.trim & """"
        '                    objStreamWriter.WriteLine(strLine)
        '                    strLine = "     COB" & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".AutoCompleteMode = AutoCompleteMode.Suggest"
        '                    objStreamWriter.WriteLine(strLine)
        '                    strLine = "     COB" & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".AutoCompleteSource = AutoCompleteSource.ListItems"
        '                    objStreamWriter.WriteLine(strLine)
        '                    strLine = "     COB" & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".DropDownStyle = ComboBoxStyle.DropDownList"
        '                    objStreamWriter.WriteLine(strLine)
        '                End If
        '            Next i
        '        Case "@RECIBECLAVES"
        '            'For i = 0 To DGVcampos.Rows.Count - 2
        '            'If DGVcampos.Rows.Item(i).Cells(1).Value.trim = "PRI" Then
        '            'strLine = "        " & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".Text =  Mid(PubPara_1_string, 2, Len(PubPara_1_string) - 1)    "
        '            'objStreamWriter.WriteLine(strLine)
        '            'End If
        '            'Next i
        '        Case "@DESABILITACAMPOSCLAVES"
        '            For i = 0 To DGVcampos.Rows.Count - 2
        '                If DGVcampos.Rows.Item(i).Cells(1).Value.trim = "PRI" Then
        '                    strLine = "           " & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".Enabled = False"
        '                    objStreamWriter.WriteLine(strLine)
        '                End If
        '            Next i
        '        Case "@LEEDBID"
        '            strLine = "            sql = ""select * from " & COBtablas.Text & " where "
        '            operador = ""
        '            y = 1
        '            For i = 0 To DGVcampos.Rows.Count - 2
        '                If DGVcampos.Rows.Item(i).Cells(1).Value.trim = "PRI" Then
        '                    If DGVcampos.Rows.Item(i).Cells(2).Value.trim = "varchar" Then
        '                        strLine = strLine & operador & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " = '"" & " & "var" & y & " & ""'"""
        '                    Else
        '                        strLine = strLine & operador & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " = "" & " & "var" & y
        '                    End If
        '                    y = y + 1
        '                    'If DGVcampos.Rows.Item(i).Cells(2).Value.trim = "varchar" Then
        '                    '    strLine = strLine & operador & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " = '"" & " & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".Text & ""'"""
        '                    'Else
        '                    '    strLine = strLine & operador & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " = "" & " & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".Text "
        '                    'End If
        '                    operador = " & "" and  "
        '                End If
        '            Next i
        '            objStreamWriter.WriteLine(strLine)
        '        Case "@ASIGNAVALORESDBTBO"
        '            For i = 0 To DGVcampos.Rows.Count - 2
        '                tipo = TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i)
        '                Select Case tipo
        '                    Case "COB"
        '                        strLine = "            " & tipo & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".SelectedValue = dt.Rows(0)(" & i & ").ToString"
        '                    Case "CHB"
        '                        strLine = "            " & tipo & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".Checked = dt.Rows(0)(" & i & ").ToString"
        '                    Case Else
        '                        strLine = "            " & tipo & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".Text = dt.Rows(0)(" & i & ").ToString"
        '                End Select
        '                objStreamWriter.WriteLine(strLine)
        '            Next i
        '        Case "@HABILITACAMPOS"
        '            For i = 0 To DGVcampos.Rows.Count - 2
        '                strLine = "            " & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".Enabled = True"
        '                objStreamWriter.WriteLine(strLine)
        '            Next i
        '        Case "@LIMPIACAMPOS"
        '            For i = 0 To DGVcampos.Rows.Count - 2
        '                If (DGVcampos.Rows.Item(i).Cells(2).Value.trim = "decimal" Or
        '                    DGVcampos.Rows.Item(i).Cells(2).Value.trim = "double" Or
        '                    DGVcampos.Rows.Item(i).Cells(2).Value.trim = "int") Then
        '                    strLine = "           " & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".Text = 0"
        '                    objStreamWriter.WriteLine(strLine)
        '                Else
        '                    strLine = "           " & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".Text = """""
        '                    objStreamWriter.WriteLine(strLine)
        '                    If DGVcampos.Rows.Item(i).Cells(2).Value.trim = "tinyint" Then
        '                        strLine = "           " & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".Checked = 0 "
        '                        objStreamWriter.WriteLine(strLine)
        '                    End If
        '                End If
        '            Next i
        '        Case "@DESHABILITACAMPOS"
        '            For i = 0 To DGVcampos.Rows.Count - 2
        '                strLine = "            " & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".Enabled = False"
        '                objStreamWriter.WriteLine(strLine)
        '            Next i
        '        Case "@LEEDB"
        '            strLine = "            sql = ""select * from " & COBtablas.Text & " where "
        '            operador = ""
        '            For i = 0 To DGVcampos.Rows.Count - 2
        '                If DGVcampos.Rows.Item(i).Cells(1).Value.trim = "PRI" Then
        '                    If TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) = "COB" Then
        '                        strLine = strLine & operador & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " = '"" & " & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".SelectedValue.ToString & ""'"""
        '                    Else
        '                        If DGVcampos.Rows.Item(i).Cells(2).Value.trim = "varchar" Then
        '                            strLine = strLine & operador & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " = '"" & " & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".Text & ""'"""
        '                        Else
        '                            strLine = strLine & operador & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " = "" & " & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".Text "
        '                        End If
        '                    End If
        '                    operador = " & "" and  "
        '                End If
        '            Next i
        '            objStreamWriter.WriteLine(strLine)
        '        Case "@INSERTADB"
        '            strLine = "            sql = ""insert into " & COBtablas.Text & " ("
        '            strLine1 = " values ("""
        '            operador = ""
        '            operador1 = ""
        '            For i = 0 To DGVcampos.Rows.Count - 2
        '                strLine = strLine & operador & DGVcampos.Rows.Item(i).Cells(0).Value.trim
        '                operador = ","
        '                If DGVcampos.Rows.Item(i).Cells(2).Value.trim = "varchar" Or DGVcampos.Rows.Item(i).Cells(2).Value.trim = "date" Then
        '                    If Len(DGVcampos.Rows.Item(i).Cells(5).Value.trim) > 0 Then
        '                        strLine1 = strLine1 & operador1 & " & ""'""" & " & " & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".SelectedValue.ToString & ""'"""
        '                    Else
        '                        strLine1 = strLine1 & operador1 & " & ""'""" & " & " & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".Text & " & """'"""
        '                    End If
        '                Else
        '                    If Len(DGVcampos.Rows.Item(i).Cells(5).Value.trim) > 0 Then
        '                        strLine1 = strLine1 & operador1 & " & " & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".SelectedValue.ToString"
        '                    Else
        '                        If DGVcampos.Rows.Item(i).Cells(2).Value.trim = "tinyint" Then
        '                            strLine1 = strLine1 & operador1 & " & val(" & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".Checked) "
        '                        Else
        '                            strLine1 = strLine1 & operador1 & " & QC(" & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".Text) "
        '                        End If
        '                    End If
        '                End If
        '                operador1 = " & "","" "
        '            Next i
        '            objStreamWriter.WriteLine(strLine & ")" & strLine1 & " & "")""")
        '        Case "@ACTUALIZADB"
        '            operador = ""
        '            operador1 = ""
        '            strLine = "            sql = ""update " & COBtablas.Text & " set "
        '            strLine1 = " & "" where "
        '            For i = 0 To DGVcampos.Rows.Count - 2
        '                If DGVcampos.Rows.Item(i).Cells(1).Value.trim <> "PRI" Then
        '                    If DGVcampos.Rows.Item(i).Cells(2).Value.trim = "varchar" Or DGVcampos.Rows.Item(i).Cells(2).Value.trim = "date" Then
        '                        If Len(DGVcampos.Rows.Item(i).Cells(5).Value.trim) > 0 Then
        '                            strLine = strLine & operador & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " = '"" &  " & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".SelectedValue.ToString & ""'"""
        '                        Else
        '                            strLine = strLine & operador & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " = '"" &  " & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".Text & ""'"""
        '                        End If
        '                    Else
        '                        If DGVcampos.Rows.Item(i).Cells(2).Value.trim = "tinyint" Then
        '                            strLine = strLine & operador & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " = "" & Val(" & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".Checked)"
        '                        Else
        '                            If Len(DGVcampos.Rows.Item(i).Cells(5).Value.trim) > 0 Then
        '                                strLine = strLine & operador & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " = &  " & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".SelectedValue.ToString"
        '                            Else
        '                                strLine = strLine & operador & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " = "" &  QC(" & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".Text)"
        '                            End If
        '                        End If
        '                    End If
        '                        operador = " & "","" & "" "
        '                Else
        '                    If DGVcampos.Rows.Item(i).Cells(2).Value.trim = "varchar" Or DGVcampos.Rows.Item(i).Cells(2).Value.trim = "date" Then
        '                        If Len(DGVcampos.Rows.Item(i).Cells(5).Value.trim) > 0 Then
        '                            strLine1 = strLine1 & operador1 & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " = '"" &  " & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".SelectedValue.ToString & ""'"""
        '                        Else
        '                            strLine1 = strLine1 & operador1 & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " = '"" &  " & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".Text & ""'"""
        '                        End If
        '                    Else
        '                        If Len(DGVcampos.Rows.Item(i).Cells(5).Value.trim) > 0 Then
        '                            strLine1 = strLine1 & operador1 & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " = "" &  " & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".SelectedValue.ToString"
        '                        Else
        '                            strLine1 = strLine1 & operador1 & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " = "" &  QC(" & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".Text)"
        '                        End If
        '                    End If
        '                    operador1 = " & "" and  "
        '                End If
        '            Next i
        '            objStreamWriter.WriteLine(strLine & " " & strLine1)
        '        Case "@BORRADB"
        '            operador = ""
        '            strLine = "             sql = ""delete from  " & COBtablas.Text & " where "
        '            operador = ""
        '            y = 1
        '            For i = 0 To DGVcampos.Rows.Count - 2
        '                If DGVcampos.Rows.Item(i).Cells(1).Value.trim = "PRI" Then
        '                    If DGVcampos.Rows.Item(i).Cells(2).Value.trim = "varchar" Then
        '                        strLine = strLine & operador & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " = '"" & " & "var" & y & " & ""'"""
        '                    Else
        '                        strLine = strLine & operador & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " = "" & " & "var" & y
        '                    End If
        '                    y = y + 1
        '                    'If DGVcampos.Rows.Item(i).Cells(2).Value.trim = "varchar" Then
        '                    '    strLine = strLine & operador & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " = '"" & " & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".Text & ""'"""
        '                    'Else
        '                    '    strLine = strLine & operador & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " = "" & " & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".Text "
        '                    'End If
        '                    operador = " & "" and  "
        '                End If
        '            Next i
        '            objStreamWriter.WriteLine(strLine)
        '            'For i = 0 To DGVcampos.Rows.Count - 2
        '            '    If DGVcampos.Rows.Item(i).Cells(1).Value.trim = "PRI" Then
        '            '        If DGVcampos.Rows.Item(i).Cells(2).Value.trim = "varchar" Then
        '            '            strLine = strLine & operador & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " = '"" &  " & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".Text & ""'"""
        '            '        Else
        '            '            strLine = strLine & operador & DGVcampos.Rows.Item(i).Cells(0).Value.trim & " = ""  &  " & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".Text"
        '            '        End If
        '            '        operador = " & "" and "
        '            '    End If
        '            'Next i
        '            'objStreamWriter.WriteLine(strLine)
        '        Case "@VALIDATEXBOX"
        '            For i = 0 To DGVcampos.Rows.Count - 2
        '                If DGVcampos.Rows.Item(i).Cells(1).Value.trim = "PRI" Then
        '                    strLine = "    Private Sub " & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & "_Validating(sender As Object, e As CancelEventArgs) Handles " & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".Validating"
        '                    objStreamWriter.WriteLine(strLine)
        '                    strLine = "        Dim sql As String"
        '                    objStreamWriter.WriteLine(strLine)
        '                    strLine = "        Dim dt As DataTable"
        '                    objStreamWriter.WriteLine(strLine)
        '                    If DGVcampos.Rows.Item(i).Cells(2).Value.trim = "varchar" Then
        '                        If TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) <> "COB" Then
        '                            strLine = "        If DirectCast(sender, TextBox).TextLength = 0 Then"
        '                            objStreamWriter.WriteLine(strLine)
        '                            strLine = "            Errores.SetError(sender, ""Campo obligatorio"")"
        '                            objStreamWriter.WriteLine(strLine)
        '                            strLine = "            NroErr += 1"
        '                            objStreamWriter.WriteLine(strLine)
        '                            strLine = "            Exit Sub"
        '                            objStreamWriter.WriteLine(strLine)
        '                            strLine = "         Else"
        '                            objStreamWriter.WriteLine(strLine)
        '                            strLine = "            Errores.SetError(sender, """")"
        '                            objStreamWriter.WriteLine(strLine)
        '                            strLine = "         End If"
        '                            objStreamWriter.WriteLine(strLine)
        '                        End If
        '                        strLine = "         If op = ""I"" Then"
        '                        objStreamWriter.WriteLine(strLine)

        '                        strLine = "            sql = ""select * from " & COBtablas.Text & " where "
        '                        operador = ""
        '                        For j = 0 To DGVcampos.Rows.Count - 2
        '                            If DGVcampos.Rows.Item(j).Cells(1).Value.trim = "PRI" Then
        '                                If TraeTipo(DGVcampos.Rows.Item(j).Cells(2).Value.trim, j) = "COB" Then
        '                                    strLine = strLine & operador & DGVcampos.Rows.Item(j).Cells(0).Value.trim & " = '"" & " & TraeTipo(DGVcampos.Rows.Item(j).Cells(2).Value.trim, j) & DGVcampos.Rows.Item(j).Cells(0).Value.trim & ".SelectedValue.ToString & ""'"""
        '                                Else
        '                                    If DGVcampos.Rows.Item(j).Cells(2).Value.trim = "varchar" Then
        '                                        strLine = strLine & operador & DGVcampos.Rows.Item(j).Cells(0).Value.trim & " = '"" & " & TraeTipo(DGVcampos.Rows.Item(j).Cells(2).Value.trim, j) & DGVcampos.Rows.Item(j).Cells(0).Value.trim & ".Text & ""'"""
        '                                    Else
        '                                        strLine = strLine & operador & DGVcampos.Rows.Item(j).Cells(0).Value.trim & " = "" & " & TraeTipo(DGVcampos.Rows.Item(j).Cells(2).Value.trim, j) & DGVcampos.Rows.Item(j).Cells(0).Value.trim & ".Text "
        '                                    End If
        '                                End If
        '                                operador = " & "" and  "
        '                            End If
        '                        Next j
        '                        objStreamWriter.WriteLine(strLine)

        '                        strLine = "            dt = DBcmd(Sql)"
        '                        objStreamWriter.WriteLine(strLine)
        '                        strLine = "            Try"
        '                        objStreamWriter.WriteLine(strLine)
        '                        strLine = "                If (dt.Rows.Count > 0) Then"
        '                        objStreamWriter.WriteLine(strLine)
        '                        strLine = "                    Errores.SetError(sender, ""Registro ya existe!"")"
        '                        objStreamWriter.WriteLine(strLine)
        '                        strLine = "                    NroErr += 1"
        '                        objStreamWriter.WriteLine(strLine)
        '                        strLine = "                    Exit Sub"
        '                        objStreamWriter.WriteLine(strLine)
        '                        strLine = "                End If"
        '                        objStreamWriter.WriteLine(strLine)
        '                        strLine = "                Errores.SetError(sender, """")"
        '                        objStreamWriter.WriteLine(strLine)
        '                        strLine = "            Catch ex As Exception"
        '                        objStreamWriter.WriteLine(strLine)
        '                        'strLine = "                Errores.SetError(sender, ex.Message)"
        '                        'objStreamWriter.WriteLine(strLine)
        '                        'strLine = "                NroErr += 1"
        '                        'objStreamWriter.WriteLine(strLine)
        '                        strLine = "                Exit Sub"
        '                        objStreamWriter.WriteLine(strLine)
        '                        strLine = "            End Try"
        '                        objStreamWriter.WriteLine(strLine)
        '                        strLine = "        End If"
        '                        objStreamWriter.WriteLine(strLine)
        '                        strLine = "    End Sub"
        '                        objStreamWriter.WriteLine(strLine)
        '                    Else
        '                        If TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) <> "COB" Then
        '                            strLine = "        If DirectCast(sender, TextBox).TextLength = 0 Then"
        '                            objStreamWriter.WriteLine(strLine)
        '                            strLine = "            Errores.SetError(sender, ""Campo obligatorio"")"
        '                            objStreamWriter.WriteLine(strLine)
        '                            strLine = "            NroErr += 1"
        '                            objStreamWriter.WriteLine(strLine)
        '                            strLine = "            Exit Sub"
        '                            objStreamWriter.WriteLine(strLine)
        '                            strLine = "         Else"
        '                            objStreamWriter.WriteLine(strLine)
        '                            strLine = "            Errores.SetError(sender, """")"
        '                            objStreamWriter.WriteLine(strLine)
        '                            strLine = "         End If"
        '                            objStreamWriter.WriteLine(strLine)
        '                            strLine = "        If not IsNumeric( " & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".text) Then"
        '                            objStreamWriter.WriteLine(strLine)
        '                            strLine = "            Errores.SetError(sender, ""Este campo es obligatorio"")"
        '                            objStreamWriter.WriteLine(strLine)
        '                            strLine = "            NroErr += 1"
        '                            objStreamWriter.WriteLine(strLine)
        '                            strLine = "            Exit Sub"
        '                            objStreamWriter.WriteLine(strLine)
        '                            strLine = "         Else"
        '                            objStreamWriter.WriteLine(strLine)
        '                            strLine = "            Errores.SetError(sender, """")"
        '                            objStreamWriter.WriteLine(strLine)
        '                            strLine = "        End If"
        '                            objStreamWriter.WriteLine(strLine)
        '                        End If
        '                        strLine = "         If op = ""I"" Then"
        '                        objStreamWriter.WriteLine(strLine)

        '                        strLine = "            sql = ""Select * from " & COBtablas.Text & " where "
        '                        operador = ""
        '                        For j = 0 To DGVcampos.Rows.Count - 2
        '                            If DGVcampos.Rows.Item(j).Cells(1).Value.trim = "PRI" Then
        '                                If DGVcampos.Rows.Item(j).Cells(2).Value.trim = "varchar" Then
        '                                    strLine = strLine & operador & DGVcampos.Rows.Item(j).Cells(0).Value.trim & " = '"" & " & TraeTipo(DGVcampos.Rows.Item(j).Cells(2).Value.trim, j) & DGVcampos.Rows.Item(j).Cells(0).Value.trim & ".Text & ""'"""
        '                                Else
        '                                    If TraeTipo(DGVcampos.Rows.Item(j).Cells(2).Value.trim, j) = "COB" Then
        '                                        strLine = strLine & operador & DGVcampos.Rows.Item(j).Cells(0).Value.trim & " = "" & val(" & TraeTipo(DGVcampos.Rows.Item(j).Cells(2).Value.trim, j) & DGVcampos.Rows.Item(j).Cells(0).Value.trim & ".SelectedValue.ToString)"
        '                                    Else
        '                                        strLine = strLine & operador & DGVcampos.Rows.Item(j).Cells(0).Value.trim & " = "" & val(" & TraeTipo(DGVcampos.Rows.Item(j).Cells(2).Value.trim, j) & DGVcampos.Rows.Item(j).Cells(0).Value.trim & ".Text)"
        '                                    End If
        '                                End If
        '                                    operador = " & "" and "
        '                            End If
        '                        Next
        '                        strLine = strLine
        '                        objStreamWriter.WriteLine(strLine)

        '                        strLine = "            dt = DBcmd(Sql)"
        '                        objStreamWriter.WriteLine(strLine)
        '                        strLine = "            Try"
        '                        objStreamWriter.WriteLine(strLine)
        '                        strLine = "                If (dt.Rows.Count > 0) Then"
        '                        objStreamWriter.WriteLine(strLine)
        '                        strLine = "                    Errores.SetError(sender, ""Registro ya existe!"")"
        '                        objStreamWriter.WriteLine(strLine)
        '                        strLine = "                    NroErr += 1"
        '                        objStreamWriter.WriteLine(strLine)
        '                        strLine = "                    Exit Sub"
        '                        objStreamWriter.WriteLine(strLine)
        '                        strLine = "                End If"
        '                        objStreamWriter.WriteLine(strLine)
        '                        strLine = "                Errores.SetError(sender, """")"
        '                        objStreamWriter.WriteLine(strLine)
        '                        strLine = "            Catch ex As Exception"
        '                        objStreamWriter.WriteLine(strLine)
        '                        strLine = "                Errores.SetError(sender, ex.Message)"
        '                        objStreamWriter.WriteLine(strLine)
        '                        strLine = "                NroErr += 1"
        '                        objStreamWriter.WriteLine(strLine)
        '                        strLine = "                Exit Sub"
        '                        objStreamWriter.WriteLine(strLine)
        '                        strLine = "            End Try"
        '                        objStreamWriter.WriteLine(strLine)
        '                        strLine = "        End If"
        '                        objStreamWriter.WriteLine(strLine)
        '                        strLine = "    End Sub"
        '                        objStreamWriter.WriteLine(strLine)
        '                    End If
        '                Else
        '                    'MsgBox("Modulo no implementado")
        '                End If
        '            Next i
        '        Case "@VALIDATEXBOXNUMERICOS"
        '            For i = 0 To DGVcampos.Rows.Count - 2
        '                If (DGVcampos.Rows.Item(i).Cells(2).Value.trim = "decimal" Or
        '                    DGVcampos.Rows.Item(i).Cells(2).Value.trim = "double" Or
        '                    DGVcampos.Rows.Item(i).Cells(2).Value.trim = "int") Then
        '                    strLine = "     Private Sub " & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & "_Validated(sender As Object, e As EventArgs) Handles " & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".Validated"
        '                    objStreamWriter.WriteLine(strLine)
        '                    strLine = "             " & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".Text = Format(Val(" & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".Text), """ & DGVcampos.Rows.Item(i).Cells(8).Value.trim & """)"
        '                    objStreamWriter.WriteLine(strLine)
        '                    strLine = "     End Sub"
        '                    objStreamWriter.WriteLine(strLine)

        '                    objStreamWriter.WriteLine(" ")
        '                    strLine = "     Private Sub " & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & "_GotFocus(sender As Object, e As EventArgs) Handles " & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".GotFocus"
        '                    objStreamWriter.WriteLine(strLine)
        '                    strLine = "             " & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".text = " & TraeTipo(DGVcampos.Rows.Item(i).Cells(2).Value.trim, i) & DGVcampos.Rows.Item(i).Cells(0).Value.trim & ".Text.Replace("","", """")"
        '                    objStreamWriter.WriteLine(strLine)
        '                    strLine = "     End Sub"
        '                    objStreamWriter.WriteLine(strLine)
        '                    objStreamWriter.WriteLine(" ")
        '                End If
        '            Next i
        '        Case Else
        '            strLine = Replace(strLine, "@NOMBRETABLA", COBtablas.Text)
        '            strLine = Replace(strLine, "@NOMBREFORMA", NombreFormatexbox.Text)
        '            strLine = Replace(strLine, "@LLAMAFORMA", NombreFormatexbox.Text)
        '            strLine = Replace(strLine, "@TITULOFORMA", TituloFormatexbox.Text)
        '            objStreamWriter.WriteLine(strLine)
        '    End Select
        '    strLine = objStreamReader.ReadLine
        'Loop
        'objStreamReader.Close()
        'objStreamWriter.Close()
        MsgBox("Formas Generadas!")

    End Sub

    Private Function val_empresa(campo As String) As String
        If campo = "id_empresa" Then
            val_empresa = "str(session['id_empresa'])"
        Else
            val_empresa = campo
        End If
    End Function

    Private Function TraeTipo(Tipo As String, j As Integer) As String
        Select Case Tipo
            Case "date"
                TraeTipo = "DTP"
            Case "varchar"
                If Len(DGVcampos.Rows.Item(j).Cells(5).Value.trim) > 0 Then
                    TraeTipo = "COB"
                Else
                    TraeTipo = "TBO"
                End If
            Case "double"
                If Len(DGVcampos.Rows.Item(j).Cells(5).Value.trim) > 0 Then
                    TraeTipo = "COB"
                Else
                    TraeTipo = "TBO"
                End If

            Case "int"
                If Len(DGVcampos.Rows.Item(j).Cells(5).Value.trim) > 0 Then
                    TraeTipo = "COB"
                Else
                    TraeTipo = "TBO"
                End If
            Case "decimal"
                If Len(DGVcampos.Rows.Item(j).Cells(5).Value.trim) > 0 Then
                    TraeTipo = "COB"
                Else
                    TraeTipo = "TBO"
                End If
            Case "tinyint"
                TraeTipo = "CHB"
            Case Else
                TraeTipo = "TBO"
        End Select
    End Function
    Private Sub TextBox1_Validated(sender As Object, e As EventArgs) Handles TextBox1.Validated
        TextBox1.Text = Format(Val(TextBox1.Text), "#,###,###,###.##")
    End Sub

    Private Sub TextBox1_GotFocus(sender As Object, e As EventArgs) Handles TextBox1.GotFocus
        TextBox1.Text = TextBox1.Text.Replace(",", "")
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        MsgBox(CheckBox1.CheckState)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim objStreamWriter As StreamWriter
        Dim strLine As String
        If MsgBox("Esta seguro de exportar a excel?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        objStreamWriter = New StreamWriter(System.AppDomain.CurrentDomain.BaseDirectory() & "Formas\" & COBtablas.Text & ".csv")
        For j = 0 To DGVcampos.ColumnCount - 1
            strLine = strLine & """" & DGVcampos.Columns(j).Name & ""","
        Next
        objStreamWriter.WriteLine(strLine)
        For i = 0 To DGVcampos.RowCount - 2
            strLine = ""
            For j = 0 To DGVcampos.ColumnCount - 1
                strLine = strLine & """" & DGVcampos(j, i).Value.ToString() & ""","
            Next
            objStreamWriter.WriteLine(strLine)
        Next
        objStreamWriter.Close()
        MsgBox("Archivo exportado ")
    End Sub

End Class
