Imports MySql.Data.MySqlClient
Imports System.ComponentModel
Imports System.Data
Imports System.IO

Public Class FRMtablas
    Private Sub FRMtablas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Sql As String
        Dim i As Integer
        'DateTimePicker1.Format = DateTimePickerFormat.Short ' = "short"
        'Dim cndb As New MySqlConnection("server='localhost'; userid='rednel'; password='emision2021*'; database='erp'")
        Dim cndb As New MySqlConnection("server=127.0.0.1; port=3306; userid=rednel; password=expres2021*; database=erp; SslMode=none")
        Dim dt As New DataTable()
        'appath = System.AppDomain.CurrentDomain.BaseDirectory()
        'appath = "C:\Trabajo\Proyectos\VisualEstudio2019\GeneradorFormasPythonProyectoWeb"
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


        DGVtablas.Columns.Clear()

        DGVtablas.ColumnCount = 2
        DGVtablas.Columns(0).Name = "Tabla"
        'DGBtablas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'DGBtablas.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        DGVtablas.Columns(1).Name = "In"
        DGVtablas.Columns(1).Width = 40


        For i = 0 To dt.Rows.Count - 1
            DGVtablas.Rows.Add(dt.Rows(i)(2).ToString, 1)
        Next i


        'CargaCampos(COBtablas.Text)
    End Sub

    Private Sub BTNgenera_Click(sender As Object, e As EventArgs) Handles BTNgenera.Click
        DGVcampos.Columns.Clear()

        DGVcampos.ColumnCount = 17
        DGVcampos.Columns(0).Name = "tabla"
        DGVcampos.Columns(1).Name = "Campo"
        DGVcampos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'DGVcampos.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        DGVcampos.Columns(2).Name = "Clave"
        DGVcampos.Columns(3).Name = "Tipo"
        DGVcampos.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVcampos.Columns(4).Name = "Tamaño"
        DGVcampos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGVcampos.Columns(5).Name = "Valida"
        DGVcampos.Columns(6).Name = "Tabla Combo"
        DGVcampos.Columns(7).Name = "Clave combo"
        DGVcampos.Columns(8).Name = "Campo muestra Combo"
        DGVcampos.Columns(9).Name = "Formato"
        'DGVcampos.Columns(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        DGVcampos.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGVcampos.Columns(10).Name = "Enteros"
        DGVcampos.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGVcampos.Columns(11).Name = "Decimales"
        DGVcampos.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGVcampos.Columns(12).Name = "Muestra"
        DGVcampos.Columns(13).Name = "descripcion"
        DGVcampos.Columns(14).Name = "Label"
        DGVcampos.Columns(15).Name = "minimo"
        DGVcampos.Columns(16).Name = "maximo"

        For i = 0 To DGVtablas.Rows.Count - 2
            If DGVtablas.Rows.Item(i).Cells(1).Value = "1" Then
                'MsgBox(DGVtablas.Rows.Item(i).Cells(0).Value)
                CargaCampos(DGVtablas.Rows.Item(i).Cells(0).Value.trim)
            End If
        Next
    End Sub

    Private Function CargaCampos(NombreTabla As String)
        Dim Sql As String
        Dim label As String
        Dim tamano As Integer
        Dim formato As String
        Dim maximo As String
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
            If dt.Rows(i)(7).ToString = "int" Or dt.Rows(i)(7).ToString = "decimal" Then
                maximo = Replace(Replace(Replace(formato, ",", ""), "#", "9"), "0", "9")
            Else
                maximo = ""
            End If
            'If maximo = "" Then
            'maximo = 0
            'End If
            'If entero = "" Then
            ' entero = 0
            ' End If
            'label = Replace(Mid(DGVcampos.Rows.Item(i).Cells(0).Value.trim, 1, 1).ToUpper & Mid(DGVcampos.Rows.Item(i).Cells(0).Value.trim, 2, Len(DGVcampos.Rows.Item(i).Cells(0).Value.trim)), "_", " ")
            label = Replace(Mid(dt.Rows(i)(3).ToString, 1, 1).ToUpper & Mid(dt.Rows(i)(3).ToString, 2, Len(dt.Rows(i)(3).ToString)), "_", " ")
            DGVcampos.Rows.Add(NombreTabla, dt.Rows(i)(3).ToString, dt.Rows(i)(16).ToString, dt.Rows(i)(7).ToString, tamano.ToString, "", "", "", "", formato, dt.Rows(i)(10).ToString, dt.Rows(i)(11).ToString, "", label, label, "0", maximo)
        Next i

    End Function

    Private Sub BTNgraba_Click(sender As Object, e As EventArgs) Handles BTNgraba.Click
        Dim Sql As String
        Dim cndb As New MySqlConnection("server=127.0.0.1; port=3306; userid=rednel; password=expres2021*; database=erp; SslMode=none")
        Sql = "delete from tablas"
        Try
            cndb.Open()
            Dim cmd As New MySqlCommand(Sql, cndb)
            cmd.ExecuteNonQuery()
            cndb.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        For i = 0 To DGVcampos.Rows.Count - 2
            Sql = "insert into tablas (tabla, orden, campo, clave, tipo, tamano, valida, tabla_combo, clave_combo, muestra_combo, formato, enteros, decimales, muestra, descripcion, label, minimo, maximo) "
            'Sql = Sql & " values ('" & DGVcampos.Rows.Item(i).Cells(0).Value.trim & "', " & i & ", '" & DGVcampos.Rows.Item(i).Cells(1).Value.trim & "', '" & DGVcampos.Rows.Item(i).Cells(2).Value.trim & "', '" & DGVcampos.Rows.Item(i).Cells(3).Value.trim & "', '" & DGVcampos.Rows.Item(i).Cells(4).Value.trim & "', '" & DGVcampos.Rows.Item(i).Cells(5).Value.trim & "', '" & DGVcampos.Rows.Item(i).Cells(6).Value.trim & "', '" & DGVcampos.Rows.Item(i).Cells(7).Value.trim & "', '" & DGVcampos.Rows.Item(i).Cells(8).Value.trim & "', '" & DGVcampos.Rows.Item(i).Cells(9).Value.trim & "', '" & DGVcampos.Rows.Item(i).Cells(10).Value.trim & "', '" & DGVcampos.Rows.Item(i).Cells(11).Value.trim & "', '" & DGVcampos.Rows.Item(i).Cells(12).Value.trim & "', '" & DGVcampos.Rows.Item(i).Cells(13).Value.trim & "', '" & DGVcampos.Rows.Item(i).Cells(14).Value.trim & "', '" & DGVcampos.Rows.Item(i).Cells(15).Value.trim & "')"
            Sql = Sql & " values ('" & DGVcampos.Rows.Item(i).Cells(0).Value & "', " & i & ", '" & DGVcampos.Rows.Item(i).Cells(1).Value & "', '" & DGVcampos.Rows.Item(i).Cells(2).Value & "', '" & DGVcampos.Rows.Item(i).Cells(3).Value & "', '" & DGVcampos.Rows.Item(i).Cells(4).Value & "', '" & DGVcampos.Rows.Item(i).Cells(5).Value & "', '" & DGVcampos.Rows.Item(i).Cells(6).Value & "', '" & DGVcampos.Rows.Item(i).Cells(7).Value & "', '" & DGVcampos.Rows.Item(i).Cells(8).Value & "', '" & DGVcampos.Rows.Item(i).Cells(9).Value & "', '" & DGVcampos.Rows.Item(i).Cells(10).Value & "', '" & DGVcampos.Rows.Item(i).Cells(11).Value & "', '" & DGVcampos.Rows.Item(i).Cells(12).Value & "', '" & DGVcampos.Rows.Item(i).Cells(13).Value & "', '" & DGVcampos.Rows.Item(i).Cells(14).Value & "', '" & DGVcampos.Rows.Item(i).Cells(15).Value & "', '" & DGVcampos.Rows.Item(i).Cells(16).Value & "')"

            Dim cmd As New MySqlCommand(Sql, cndb)
            Try
                cndb.Open()
                cmd.ExecuteNonQuery()
                cndb.Close()
            Catch ex As Exception
                MsgBox(Sql)
                MsgBox(ex.Message)
            End Try
        Next
        MsgBox("termino ")
    End Sub
End Class