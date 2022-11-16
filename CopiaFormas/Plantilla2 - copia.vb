Imports System.ComponentModel

Public Class FRMconfiguracion
    Public op As String
    Public id As String
    Public NroErr As Integer



    Private Sub FRMconfiguracion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'Erp_liteDataSet1.empresas' Puede moverla o quitarla según sea necesario.
        'Me.EmpresasTableAdapter1.Fill(Me.Erp_liteDataSet1.empresas)
        'TODO: esta línea de código carga datos en la tabla 'Erp_liteDataSet.empresas' Puede moverla o quitarla según sea necesario.
        'Me.EmpresasTableAdapter.Fill(Me.Erp_liteDataSet.empresas)
        Errores.Clear()
        IdTextBox.MaxLength = 5
        NitTextBox.MaxLength = 15
        DvTextBox.MaxLength = 1
        NombreTextBox.MaxLength = 50
        DireccionTextBox.MaxLength = 50
        CiudadTextBox.MaxLength = 20
        TelefonoTextBox.MaxLength = 30
        CIIU1TextBox.MaxLength = 15
        CIIU2TextBox.MaxLength = 15
        CIIU3TextBox.MaxLength = 15

        Dim sql As String
        Dim dt As DataTable

        op = Mid(PubPara_1_string, 1, 1)
        id = Mid(PubPara_1_string, 2, Len(PubPara_1_string) - 1)
        If op = "B" Then
            BTNactualizar.Enabled = False
            BTNdeshacer.Enabled = False
        End If
        If op = "M" Then
            IdTextBox.Enabled = False
        End If
        If op IsNot "I" Then
            sql = "select * from empresas where id = '" & id & "'"
            dt = DBcmd(sql)
            Try
                If (dt.Rows.Count = 0) Then
                    MsgBox("Empresa no exite")
                    Exit Sub
                End If
            Catch ex As Exception
                MsgBox("Usuario o clave no exite")
                Exit Sub
            End Try
            IdTextBox.Text = dt.Rows(0)(0).ToString
            NitTextBox.Text = dt.Rows(0)(1).ToString
            DvTextBox.Text = dt.Rows(0)(2).ToString
            NombreTextBox.Text = dt.Rows(0)(3).ToString
            DireccionTextBox.Text = dt.Rows(0)(4).ToString
            CiudadTextBox.Text = dt.Rows(0)(5).ToString
            TelefonoTextBox.Text = dt.Rows(0)(6).ToString
            CIIU1TextBox.Text = dt.Rows(0)(7).ToString
            CIIU2TextBox.Text = dt.Rows(0)(8).ToString
            CIIU3TextBox.Text = dt.Rows(0)(9).ToString
        Else
            IdTextBox.Enabled = True
            NitTextBox.Enabled = True
            DvTextBox.Enabled = True
            NombreTextBox.Enabled = True
            DireccionTextBox.Enabled = True
            CiudadTextBox.Enabled = True
            TelefonoTextBox.Enabled = True
            CIIU1TextBox.Enabled = True
            CIIU2TextBox.Enabled = True
            CIIU3TextBox.Enabled = True
            IdTextBox.Text = ""
            NitTextBox.Text = ""
            DvTextBox.Text = ""
            NombreTextBox.Text = ""
            DireccionTextBox.Text = ""
            CiudadTextBox.Text = ""
            TelefonoTextBox.Text = ""
            CIIU1TextBox.Text = ""
            CIIU2TextBox.Text = ""
            CIIU3TextBox.Text = ""
            BTNactualizar.Enabled = True
            BTNdeshacer.Enabled = True
        End If
        If op = "B" Then
            IdTextBox.Enabled = False
            NitTextBox.Enabled = False
            DvTextBox.Enabled = False
            NombreTextBox.Enabled = False
            DireccionTextBox.Enabled = False
            CiudadTextBox.Enabled = False
            TelefonoTextBox.Enabled = False
            CIIU1TextBox.Enabled = False
            CIIU2TextBox.Enabled = False
            CIIU3TextBox.Enabled = False
            BTNdeshacer.Enabled = False
            BTNactualizar.Enabled = False
        End If
        If op = "M" Then
            IdTextBox.Enabled = False
            BTNactualizar.Enabled = True
            BTNdeshacer.Enabled = True
        End If

    End Sub

    Private Sub BTNdeshacer_Click(sender As Object, e As EventArgs) Handles BTNdeshacer.Click
        If MsgBox("Esta seguro de deshacer lo que lleva?", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub BTNactualizar_Click(sender As Object, e As EventArgs) Handles BTNactualizar.Click
        Dim sql As String
        Dim dt As DataTable
        Try
            NroErr = 0
            If Not Me.ValidateChildren Then
                MsgBox("Error al validar los campos")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            NroErr += 1
        End Try

        If NroErr > 0 Then
            MsgBox("Arregle las inconsistencias en el formulario")
            Exit Sub
        End If

        If Trim(op) = "I" Then
            sql = "select * from empresas where id = '" & IdTextBox.Text & "'"
            dt = DBcmd(sql)
            Try
                If (dt.Rows.Count > 0) Then
                    Errores.SetError(sender, "El id ya existe!")
                    Exit Sub
                Else
                    Errores.SetError(sender, "")
                End If
            Catch ex As Exception
                Errores.SetError(sender, ex.Message)
                Exit Sub
            End Try
        End If
        'Dim sql As String
        If Trim(op) = "I" Then
            sql = "insert into empresas (id, Nit, Dv, Nombre, Direccion, Telefono, Ciudad, CIIU1, CIIU2, CIIU3) VALUES ('"
            sql = sql & IdTextBox.Text & "', " & NitTextBox.Text & ", " & DvTextBox.Text & ",'" & NombreTextBox.Text & "','"
            sql = sql & DireccionTextBox.Text & "', '" & TelefonoTextBox.Text & "','" & CiudadTextBox.Text & "', '"
            sql = sql & CIIU1TextBox.Text & "', '" & CIIU2TextBox.Text & "', '" & CIIU3TextBox.Text & "')"
            'MsgBox(sql)
            If DBcmdEx(sql) Then
                'MsgBox("Ingreso Ok")
                Me.Close()
            Else
                MsgBox("No se actualizo")
            End If
        Else
            sql = "update empresas set Nit = " & NitTextBox.Text
            sql = sql & ", Dv = " & DvTextBox.Text
            sql = sql & ", Nombre = '" & NombreTextBox.Text
            sql = sql & "', Direccion = '" & DireccionTextBox.Text
            sql = sql & "', Telefono = '" & TelefonoTextBox.Text
            sql = sql & "', Ciudad = '" & CiudadTextBox.Text
            sql = sql & "', CIIU1 = '" & CIIU1TextBox.Text
            sql = sql & "', CIIU2 = '" & CIIU2TextBox.Text
            sql = sql & "', CIIU3 = '" & CIIU3TextBox.Text
            sql = sql & "' where id = '" & IdTextBox.Text & "'"
            If DBcmdEx(sql) Then
                'MsgBox("Ingreso Ok")
                Me.Close()
            Else
                MsgBox("No se actualizo")
            End If
        End If
    End Sub

    Private Sub FRMconfiguracion_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Dim Sql As String
        If op = "B" Then
            If MsgBox("Esta seguro de borrar este registro", MsgBoxStyle.YesNo) = vbYes Then
                Sql = "delete from empresas where id = '" & id & "'"
                If DBcmdEx(Sql) Then
                    'MsgBox("Ingreso Ok")
                    Me.Close()
                Else
                    MsgBox("Imposible borrarlo")
                End If
            Else
                Me.Close()
            End If
        End If

    End Sub

    Private Sub NitTextBox_Validating(sender As Object, e As CancelEventArgs) 
        If IsNumeric(NitTextBox.Text) Then
            Errores.SetError(sender, "")
        Else
            Errores.SetError(sender, "El id es un campo obligatorio")
            NroErr += 1
            Exit Sub
        End If
        If Val(NitTextBox.Text) - Int(NitTextBox.Text) = 0 Then
            Errores.SetError(sender, "")
        Else
            Errores.SetError(sender, "El nit es un campo entero")
            NroErr += 1
        End If
    End Sub

    Private Sub IdTextBox_Validating(sender As Object, e As CancelEventArgs) 
        Dim sql As String
        Dim dt As DataTable

        If DirectCast(sender, TextBox).TextLength > 0 Then
            Errores.SetError(sender, "")
        Else
            Errores.SetError(sender, "El id es un campo obligatorio")
            NroErr += 1
            Exit Sub
        End If
        If op = "I" Then
            sql = "select * from empresas where id = '" & IdTextBox.Text & "'"
            dt = DBcmd(Sql)
            Try
                If (dt.Rows.Count > 0) Then
                    Errores.SetError(sender, "El id ya existe!")
                    NroErr += 1
                    Exit Sub
                Else
                    Errores.SetError(sender, "")
                End If
            Catch ex As Exception
                Errores.SetError(sender, ex.Message)
                NroErr += 1
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub DvTextBox_Validating(sender As Object, e As CancelEventArgs) 
        If DvTextBox.Text.Length = 0 Then
            Errores.SetError(sender, "El digito de verificación es obligatorio")
            NroErr += 1
            Exit Sub
        End If
        If Not IsNumeric(DvTextBox.Text) Then
            Errores.SetError(sender, "El dv debe ser numerico")
            NroErr += 1
            Exit Sub
        End If
    End Sub
End Class