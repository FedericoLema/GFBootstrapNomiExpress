Imports System.ComponentModel

Public Class @NOMBREFORMA2
    Private op As String
    Private NroErr As Integer
    Public var1 as string
    public var2 as string
    public var3 as string
    public var4 as string

    Private Sub @NOMBREFORMA2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Errores.Clear()

        Dim TTayuda As New ToolTip()
        TTayuda.UseAnimation = True
        TTayuda.ShowAlways = True
        TTayuda.IsBalloon = True
        TTayuda.AutoPopDelay = 2000
        TTayuda.InitialDelay = 100
        TTayuda.ReshowDelay = 500
        TTayuda.ShowAlways = True
        TTayuda.SetToolTip(Me.BTNactualizar, "Guarda (Ctrl-g)")
        TTayuda.SetToolTip(Me.BTNdeshacer, "Deshace cambios (Ctrl-d)")

@TAMAÑOTEXBOX
        Me.AcceptButton = BTNactualizar
        Me.KeyPreview = True
        
        Dim sql As String
        Dim dt As DataTable
        Dim dv As DataView
        Me.AcceptButton = BTNactualizar
@CARGACOMBOBOX        
        op = Mid(LABop.Text, 1, 1)

        If op <> "I" Then
@LEEDBID
            dt = DBcmd(sql)
            Try
                If (dt.Rows.Count = 0) Then
                    MsgBox("@NOMBRETABLA no exite")
                    Exit Sub
                End If
            Catch ex As Exception
                MsgBox(ex.message)
                Exit Sub
            End Try
@ASIGNAVALORESDBTBO
        Else
@HABILITACAMPOS
@LIMPIACAMPOS
            BTNactualizar.Enabled = True
            BTNdeshacer.Enabled = True
        End If
        If op = "B" Then
@DESHABILITACAMPOS
            BTNdeshacer.Enabled = False
            BTNactualizar.Enabled = False
        End If
        If op = "M" Then
@HABILITACAMPOS
@DESABILITACAMPOSCLAVES
            BTNactualizar.Enabled = True
            BTNdeshacer.Enabled = True
        End If
        If op = "C" then
@HABILITACAMPOS
            BTNactualizar.Enabled = True
            BTNdeshacer.Enabled = True
        End If

    End Sub

    Private Sub FRMdepartamentos2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(7) Then
            BTNactualizar_Click(sender, e)
        End If
        If e.KeyChar = ChrW(4) Then
            BTNdeshacer_Click(sender, e)
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

        If Trim(op) = "I" or Trim(op) = "C" Then
@LEEDB           
            dt = DBcmd(sql)
            Try
                If (dt.Rows.Count > 0) Then
                    Errores.SetError(sender, "El registro ya existe!")
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
        If Trim(op) = "I" or Trim(op) = "C" Then
@INSERTADB
            'MsgBox(sql)
            If DBcmdEx(sql) Then
                'MsgBox("Ingreso Ok")
                Me.Close()
            Else
                MsgBox("No se actualizo")
            End If
        Else
@ACTUALIZADB
            If DBcmdEx(sql) Then
                'MsgBox("Ingreso Ok")
                Me.Close()
            Else
                MsgBox("No se actualizo")
            End If
        End If
    End Sub

    Private Sub @NOMBREFORMA2_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Dim Sql As String
        If op = "B" Then
            If MsgBox("Esta seguro de borrar este registro", MsgBoxStyle.YesNo) = vbYes Then
@BORRADB
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

@VALIDATEXBOX

@VALIDATEXBOXNUMERICOS

End Class