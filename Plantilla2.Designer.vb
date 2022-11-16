<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class @NOMBREFORMA2
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
        Me.components = New System.ComponentModel.Container()
        Me.LABop = New System.Windows.Forms.Label()
@DEFINICIONLABEL
@DEFINICIONTEXTBOX
        Me.BTNactualizar = New System.Windows.Forms.Button()
        Me.BTNdeshacer = New System.Windows.Forms.Button()
        Me.Errores = New System.Windows.Forms.ErrorProvider(Me.components)
@DEFINICIONNEWLABEL
        CType(Me.Errores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
@DETALLELABEL
        '
        'LABop
        '
        Me.LABop.AutoSize = True
        Me.LABop.Location = New System.Drawing.Point(240, 10)
        Me.LABop.Name = "LABop"
        Me.LABop.Size = New System.Drawing.Size(50, 13)
        Me.LABop.TabIndex = 60
        Me.LABop.Text = "Operacion"
@DETALLETEXBOX
        '
        'BTNactualizar
        '
        Me.BTNactualizar.Image = Global.PruebaNomina.My.Resources.Resources.Guardar
        Me.BTNactualizar.Location = New System.Drawing.Point(53, 350)
        Me.BTNactualizar.Name = "BTNactualizar"
        Me.BTNactualizar.Size = New System.Drawing.Size(30, 28)
        Me.BTNactualizar.TabIndex = 40
        Me.BTNactualizar.UseVisualStyleBackColor = True
        '
        'BTNdeshacer
        '
        Me.BTNdeshacer.Image = Global.PruebaNomina.My.Resources.Resources.Deshacer
        Me.BTNdeshacer.Location = New System.Drawing.Point(11, 350)
        Me.BTNdeshacer.Name = "BTNdeshacer"
        Me.BTNdeshacer.Size = New System.Drawing.Size(30, 28)
        Me.BTNdeshacer.TabIndex = 41
        Me.BTNdeshacer.UseVisualStyleBackColor = True
        '
        'Errores
        '
        Me.Errores.ContainerControl = Me
        '
        '@NOMBREFORMA2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(554, 383)
@ADDCONTROLES
        Me.Controls.Add(Me.LABop)
        Me.Controls.Add(Me.BTNactualizar)
        Me.Controls.Add(Me.BTNdeshacer)
        Me.Name = "@NOMBREFORMA2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "@TITULOFORMA"
        CType(Me.Errores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
@FRIENDTEXBOX
    Friend WithEvents LABop As Label
    Friend WithEvents BTNdeshacer As Button
    Friend WithEvents BTNactualizar As Button
    Friend WithEvents Errores As ErrorProvider
End Class
