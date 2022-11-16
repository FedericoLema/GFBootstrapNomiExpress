Imports System.IO

Public Class @NOMBREFORMA
    Private dv As DataView
    Private dt As DataTable
    Private TipoCampo() As String
    
    Private Sub @NOMBREFORMA_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.AcceptButton = BTNbuscar
        Me.KeyPreview = True
        Carga_Registros()
        DGV@NOMBRETABLA.BringToFront()
        COBoperador.Items.Add("=")
        COBoperador.Items.Add("not =")
        COBoperador.Items.Add(">=")
        COBoperador.Items.Add(">")
        COBoperador.Items.Add("<=")
        COBoperador.Items.Add("<")
        COBoperador.Items.Add("like")
        COBoperador.Items.Add("not like")

        COBconector.Items.Add("or")
        COBconector.Items.Add("and")

        Dim TTayuda As New ToolTip()
        TTayuda.UseAnimation = True
        TTayuda.ShowAlways = True
        TTayuda.IsBalloon = True
        TTayuda.AutoPopDelay = 2000
        TTayuda.InitialDelay = 100
        TTayuda.ReshowDelay = 500
        TTayuda.ShowAlways = True
        TTayuda.SetToolTip(Me.BTNcrear, "Adicionar un registro (Ctrl-a)")
        TTayuda.SetToolTip(Me.BTNmodificar, "Modificar registro (Ctrl-m)")
        TTayuda.SetToolTip(Me.BTNborrar, "Borra registro (Ctrl-e)")
        TTayuda.SetToolTip(Me.BTNbuscar, "Busca registro (Ctrl-b)")
        TTayuda.SetToolTip(Me.BTNdeshacer, "Borra filtros de busqueda (Ctrl-d)")
        TTayuda.SetToolTip(Me.BTNcopiar, "Copia registro (Ctrl-c)")
        TTayuda.SetToolTip(Me.BTNexportar, "Exporta archivo a excel formato cvs (Ctrl-x)")
    End Sub

    Private Sub FRMdepartamentos2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(1) Then
            BTNcrear_Click(sender, e)
        End If
        If e.KeyChar = ChrW(13) Then
            BTNmodificar_Click(sender, e)
        End If
        If e.KeyChar = ChrW(5) Then
            BTNborrar_Click(sender, e)
        End If
        If e.KeyChar = ChrW(4) Then
            BTNdeshacer_Click(sender, e)
        End If
        If e.KeyChar = ChrW(2) Then
            BTNbuscar_Click(sender, e)
        End If
        If e.KeyChar = ChrW(3) Then
            BTNcopiar_Click(sender, e)
        End If
        If e.KeyChar = ChrW(24) Then
            BTNexportar_Click(sender, e)
        End If
    End Sub

    Private Sub Carga_Registros()
        Dim Sql As String
        'Dim dt As DataTable

        'Sql = "SELECT * from @NOMBRETABLA"
@LEEDBID
        'dt = DBcmd(Sql)
        dv = DBVcmd(Sql)
        DGV@NOMBRETABLA.DataSource = dv
        'CamposBuscar()

@FORMATEADTGV
        COBcampos.Items.Clear()
        For i = 0 To DGV@NOMBRETABLA.ColumnCount - 1
            DGV@NOMBRETABLA.Columns(i).ReadOnly = True
            COBcampos.Items.Add(DGV@NOMBRETABLA.Columns.Item(i).Name)
        Next

        Try
            If (dv.Count = 0) Then
                MsgBox("No hay @NOMBRETABLA definidas")
                BTNborrar.Enabled = False
                Exit Sub
            Else
                BTNborrar.Enabled = True
            End If
        Catch ex As Exception
            MsgBox("No hay @NOMBRETABLA definidas")
            Exit Sub
        End Try

    End Sub
    Private Sub BTNcrear_Click(sender As Object, e As EventArgs) Handles BTNcrear.Click
        'Dim FRMconfiguracion As New FRMconfiguracion()
        @LLAMAFORMA2.LABop.Text = "Ingresa"
        'PubPara_1_string = "I"
        @LLAMAFORMA2.ShowDialog()
        Carga_Registros()
    End Sub

    Private Sub BTNmodificar_Click(sender As Object, e As EventArgs) Handles BTNmodificar.Click
        'MsgBox(DGV@NOMBRETABLA.CurrentRow.Cells("id").Value)
        @LLAMAFORMA2.LABop.Text = "Modifica"
@PASAPARAMETROS
        'PubPara_1_string = "M" & DGV@NOMBRETABLA.CurrentRow.Cells(0).Value
        @LLAMAFORMA2.ShowDialog()
        Carga_Registros()
    End Sub

    Private Sub BTNcopiar_Click(sender As Object, e As EventArgs) Handles BTNcopiar.Click
        'MsgBox(DGV@NOMBRETABLA.CurrentRow.Cells("id").Value)
        @LLAMAFORMA2.LABop.Text = "Copia"
@PASAPARAMETROS
        'PubPara_1_string = "M" & DGV@NOMBRETABLA.CurrentRow.Cells(0).Value
        @LLAMAFORMA2.ShowDialog()
        Carga_Registros()
    End Sub

    Private Sub BTNborrar_Click(sender As Object, e As EventArgs) Handles BTNborrar.Click
        'PubPara_1_string = "B" & DGV@NOMBRETABLA.CurrentRow.Cells(0).Value
        @LLAMAFORMA2.LABop.Text = "Borra"
@PASAPARAMETROS
        @LLAMAFORMA2.ShowDialog()
        Carga_Registros()
    End Sub

    Private Sub BTNbuscar_Click(sender As Object, e As EventArgs) Handles BTNbuscar.Click
        'dv.RowFilter = String.Format("Nombre like '%{0}%'", "Feder")
        'dv.RowFilter = String.Format("Nombre like '%fede%' or id like '%0%'")
        'dv.RowFilter = "nit >='71641' "
        Dim filtro As String
        
        If COBcampos.Text.Length = 0 Or COBoperador.Text.Length = 0 Or (LBLfiltro.Text.Length > 0 And COBconector.Text.Length = 0) Then
            MsgBox("Por favor revise los paremtros de busqueda")
            Exit Sub
        End If

        If (DGV@NOMBRETABLA.Columns.Item(COBcampos.SelectedIndex).ValueType.Name.ToString = "String" or
           DGV@NOMBRETABLA.Columns.Item(COBcampos.SelectedIndex).ValueType.Name.ToString = "DateTime")  Then
            filtro = COBcampos.Text & " " & COBoperador.Text & " '" & ValorBuscar.Text & "'"
        Else
            filtro = COBcampos.Text & " " & COBoperador.Text & " " & ValorBuscar.Text
        End If
        If LBLfiltro.Text.Length > 0 Then
            If COBconector.Text.Length = 0 Then
                MsgBox("Debe seleccionar un conector")
                COBconector.Focus()
                Exit Sub
            End If
            LBLfiltro.Text = LBLfiltro.Text & " " & COBconector.Text & " " & filtro
        Else
            LBLfiltro.Text = filtro
        End If
        Try
            dv.RowFilter = LBLfiltro.Text
        Catch ex As Exception
            MsgBox("Fallo en consulta")
        End Try

        COBcampos.ResetText()
        COBoperador.ResetText()
        COBconector.ResetText()
        ValorBuscar.ResetText()

    End Sub

    Private Sub BTNdeshacer_Click(sender As Object, e As EventArgs) Handles BTNdeshacer.Click
        dv.RowFilter = String.Empty
        COBcampos.ResetText()
        COBoperador.ResetText()
        COBconector.ResetText()
        ValorBuscar.ResetText()
        LBLfiltro.Text = String.Empty
    End Sub

    Private Sub BTNexportar_Click(sender As Object, e As EventArgs) Handles BTNexportar.Click
        Dim objStreamWriter As StreamWriter
        Dim strLine As String
        If MsgBox("Esta seguro de exportar a excel?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        objStreamWriter = New StreamWriter(System.AppDomain.CurrentDomain.BaseDirectory() & "Formas\@NOMBRETABLA.csv")
        For j = 0 To DGV@NOMBRETABLA.ColumnCount - 1
            strLine = strLine & """" & DGV@NOMBRETABLA.Columns(j).Name & ""","
        Next
        objStreamWriter.WriteLine(strLine)
        For i = 0 To DGV@NOMBRETABLA.RowCount - 2
            strLine = ""
            For j = 0 To DGV@NOMBRETABLA.ColumnCount - 1
                strLine = strLine & """" & DGV@NOMBRETABLA(j, i).Value.ToString() & ""","
            Next
            objStreamWriter.WriteLine(strLine)
        Next
        objStreamWriter.Close()
        MsgBox("Archivo con formato cvs exportado en: " & System.AppDomain.CurrentDomain.BaseDirectory() & "Formas\@NOMBRETABLA.csv")
    End Sub

End Class