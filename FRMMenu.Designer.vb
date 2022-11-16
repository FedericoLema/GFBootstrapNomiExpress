<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRMMenu
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.EscogerTablasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IngresarPropiedadesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GeneradorPorTablaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EscogerTablasToolStripMenuItem, Me.IngresarPropiedadesToolStripMenuItem, Me.SalirToolStripMenuItem, Me.GeneradorPorTablaToolStripMenuItem, Me.SalirToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'EscogerTablasToolStripMenuItem
        '
        Me.EscogerTablasToolStripMenuItem.Name = "EscogerTablasToolStripMenuItem"
        Me.EscogerTablasToolStripMenuItem.Size = New System.Drawing.Size(94, 20)
        Me.EscogerTablasToolStripMenuItem.Text = "Escoger tablas"
        '
        'IngresarPropiedadesToolStripMenuItem
        '
        Me.IngresarPropiedadesToolStripMenuItem.Name = "IngresarPropiedadesToolStripMenuItem"
        Me.IngresarPropiedadesToolStripMenuItem.Size = New System.Drawing.Size(129, 20)
        Me.IngresarPropiedadesToolStripMenuItem.Text = "ingresar propiedades"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(124, 20)
        Me.SalirToolStripMenuItem.Text = "Generador proyecto"
        '
        'GeneradorPorTablaToolStripMenuItem
        '
        Me.GeneradorPorTablaToolStripMenuItem.Name = "GeneradorPorTablaToolStripMenuItem"
        Me.GeneradorPorTablaToolStripMenuItem.Size = New System.Drawing.Size(124, 20)
        Me.GeneradorPorTablaToolStripMenuItem.Text = "Generador por tabla"
        '
        'SalirToolStripMenuItem1
        '
        Me.SalirToolStripMenuItem1.Name = "SalirToolStripMenuItem1"
        Me.SalirToolStripMenuItem1.Size = New System.Drawing.Size(41, 20)
        Me.SalirToolStripMenuItem1.Text = "Salir"
        '
        'FRMMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FRMMenu"
        Me.Text = "Form1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents EscogerTablasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents IngresarPropiedadesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GeneradorPorTablaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem1 As ToolStripMenuItem
End Class
