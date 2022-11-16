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
@DEFINICIONLABEL
        Dim CIIU1Label As System.Windows.Forms.Label
        Dim CIIU2Label As System.Windows.Forms.Label
        Dim CIIU3Label As System.Windows.Forms.Label
        Dim NitLabel As System.Windows.Forms.Label
        Dim DvLabel As System.Windows.Forms.Label
        Dim NombreLabel As System.Windows.Forms.Label
        Dim DireccionLabel As System.Windows.Forms.Label
        Dim CiudadLabel As System.Windows.Forms.Label
        Dim TelefonoLabel As System.Windows.Forms.Label
        Dim IdLabel As System.Windows.Forms.Label
@DEFINICIONTEXTBOX
        Me.IdTextBox = New System.Windows.Forms.TextBox()
        Me.NitTextBox = New System.Windows.Forms.TextBox()
        Me.DvTextBox = New System.Windows.Forms.TextBox()
        Me.NombreTextBox = New System.Windows.Forms.TextBox()
        Me.DireccionTextBox = New System.Windows.Forms.TextBox()
        Me.CiudadTextBox = New System.Windows.Forms.TextBox()
        Me.TelefonoTextBox = New System.Windows.Forms.TextBox()
        Me.CIIU1TextBox = New System.Windows.Forms.TextBox()
        Me.CIIU2TextBox = New System.Windows.Forms.TextBox()
        Me.CIIU3TextBox = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
!QUEDASI
        Me.BTNactualizar = New System.Windows.Forms.Button()
        Me.BTNdeshacer = New System.Windows.Forms.Button()
        Me.Errores = New System.Windows.Forms.ErrorProvider(Me.components)
@DEFINICIONNEWLABEL
        CIIU1Label = New System.Windows.Forms.Label()
        CIIU2Label = New System.Windows.Forms.Label()
        CIIU3Label = New System.Windows.Forms.Label()
        NitLabel = New System.Windows.Forms.Label()
        DvLabel = New System.Windows.Forms.Label()
        NombreLabel = New System.Windows.Forms.Label()
        DireccionLabel = New System.Windows.Forms.Label()
        CiudadLabel = New System.Windows.Forms.Label()
        TelefonoLabel = New System.Windows.Forms.Label()
        IdLabel = New System.Windows.Forms.Label()
QUEDASI
        CType(Me.Errores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
@DETALLELABEL
        '
        'CIIU1Label
        '
        CIIU1Label.AutoSize = True
        CIIU1Label.Location = New System.Drawing.Point(15, 220)
        CIIU1Label.Name = "CIIU1Label"
        CIIU1Label.Size = New System.Drawing.Size(37, 13)
        CIIU1Label.TabIndex = 30
        CIIU1Label.Text = "CIIU1:"
        '
        'CIIU2Label
        '
        CIIU2Label.AutoSize = True
        CIIU2Label.Location = New System.Drawing.Point(15, 246)
        CIIU2Label.Name = "CIIU2Label"
        CIIU2Label.Size = New System.Drawing.Size(37, 13)
        CIIU2Label.TabIndex = 32
        CIIU2Label.Text = "CIIU2:"
        '
        'CIIU3Label
        '
        CIIU3Label.AutoSize = True
        CIIU3Label.Location = New System.Drawing.Point(15, 272)
        CIIU3Label.Name = "CIIU3Label"
        CIIU3Label.Size = New System.Drawing.Size(37, 13)
        CIIU3Label.TabIndex = 34
        CIIU3Label.Text = "CIIU3:"
        '
        'NitLabel
        '
        NitLabel.AutoSize = True
        NitLabel.Location = New System.Drawing.Point(9, 56)
        NitLabel.Name = "NitLabel"
        NitLabel.Size = New System.Drawing.Size(23, 13)
        NitLabel.TabIndex = 30
        NitLabel.Text = "Nit:"
        '
        'DvLabel
        '
        DvLabel.AutoSize = True
        DvLabel.Location = New System.Drawing.Point(237, 56)
        DvLabel.Name = "DvLabel"
        DvLabel.Size = New System.Drawing.Size(24, 13)
        DvLabel.TabIndex = 32
        DvLabel.Text = "Dv:"
        '
        'NombreLabel
        '
        NombreLabel.AutoSize = True
        NombreLabel.Location = New System.Drawing.Point(10, 82)
        NombreLabel.Name = "NombreLabel"
        NombreLabel.Size = New System.Drawing.Size(47, 13)
        NombreLabel.TabIndex = 34
        NombreLabel.Text = "Nombre:"
        '
        'DireccionLabel
        '
        DireccionLabel.AutoSize = True
        DireccionLabel.Location = New System.Drawing.Point(9, 108)
        DireccionLabel.Name = "DireccionLabel"
        DireccionLabel.Size = New System.Drawing.Size(55, 13)
        DireccionLabel.TabIndex = 36
        DireccionLabel.Text = "Direccion:"
        '
        'CiudadLabel
        '
        CiudadLabel.AutoSize = True
        CiudadLabel.Location = New System.Drawing.Point(10, 160)
        CiudadLabel.Name = "CiudadLabel"
        CiudadLabel.Size = New System.Drawing.Size(43, 13)
        CiudadLabel.TabIndex = 38
        CiudadLabel.Text = "Ciudad:"
        '
        'TelefonoLabel
        '
        TelefonoLabel.AutoSize = True
        TelefonoLabel.Location = New System.Drawing.Point(10, 134)
        TelefonoLabel.Name = "TelefonoLabel"
        TelefonoLabel.Size = New System.Drawing.Size(52, 13)
        TelefonoLabel.TabIndex = 40
        TelefonoLabel.Text = "Telefono:"
        '
        'IdLabel
        '
        IdLabel.AutoSize = True
        IdLabel.Location = New System.Drawing.Point(10, 27)
        IdLabel.Name = "IdLabel"
        IdLabel.Size = New System.Drawing.Size(18, 13)
        IdLabel.TabIndex = 41
        IdLabel.Text = "id:"
@DETALLETEXBOX
        '
        'IdTextBox
        '
        Me.IdTextBox.Location = New System.Drawing.Point(70, 27)
        Me.IdTextBox.Name = "IdTextBox"
        Me.IdTextBox.Size = New System.Drawing.Size(100, 20)
        Me.IdTextBox.TabIndex = 30
        '
        'NitTextBox
        '
        Me.NitTextBox.Location = New System.Drawing.Point(71, 53)
        Me.NitTextBox.Name = "NitTextBox"
        Me.NitTextBox.Size = New System.Drawing.Size(100, 20)
        Me.NitTextBox.TabIndex = 31
        '
        'DvTextBox
        '
        Me.DvTextBox.Location = New System.Drawing.Point(298, 53)
        Me.DvTextBox.Name = "DvTextBox"
        Me.DvTextBox.Size = New System.Drawing.Size(24, 20)
        Me.DvTextBox.TabIndex = 33
        '
        'NombreTextBox
        '
        Me.NombreTextBox.Location = New System.Drawing.Point(71, 79)
        Me.NombreTextBox.Name = "NombreTextBox"
        Me.NombreTextBox.Size = New System.Drawing.Size(414, 20)
        Me.NombreTextBox.TabIndex = 35
        '
        'DireccionTextBox
        '
        Me.DireccionTextBox.Location = New System.Drawing.Point(70, 105)
        Me.DireccionTextBox.Name = "DireccionTextBox"
        Me.DireccionTextBox.Size = New System.Drawing.Size(414, 20)
        Me.DireccionTextBox.TabIndex = 37
        '
        'CiudadTextBox
        '
        Me.CiudadTextBox.Location = New System.Drawing.Point(71, 157)
        Me.CiudadTextBox.Name = "CiudadTextBox"
        Me.CiudadTextBox.Size = New System.Drawing.Size(100, 20)
        Me.CiudadTextBox.TabIndex = 41
        '
        'TelefonoTextBox
        '
        Me.TelefonoTextBox.Location = New System.Drawing.Point(71, 131)
        Me.TelefonoTextBox.Name = "TelefonoTextBox"
        Me.TelefonoTextBox.Size = New System.Drawing.Size(100, 20)
        Me.TelefonoTextBox.TabIndex = 39
        '
        'CIIU1TextBox
        '
        Me.CIIU1TextBox.Location = New System.Drawing.Point(76, 217)
        Me.CIIU1TextBox.Name = "CIIU1TextBox"
        Me.CIIU1TextBox.Size = New System.Drawing.Size(100, 20)
        Me.CIIU1TextBox.TabIndex = 42
        '
        'CIIU2TextBox
        '
        Me.CIIU2TextBox.Location = New System.Drawing.Point(76, 243)
        Me.CIIU2TextBox.Name = "CIIU2TextBox"
        Me.CIIU2TextBox.Size = New System.Drawing.Size(100, 20)
        Me.CIIU2TextBox.TabIndex = 43
        '
        'CIIU3TextBox
        '
        Me.CIIU3TextBox.Location = New System.Drawing.Point(76, 269)
        Me.CIIU3TextBox.Name = "CIIU3TextBox"
        Me.CIIU3TextBox.Size = New System.Drawing.Size(100, 20)
        Me.CIIU3TextBox.TabIndex = 44
@QUEDASI
        '
        'BTNactualizar
        '
        Me.BTNactualizar.Image = Global.PruebaNomina.My.Resources.Resources.Guardar
        Me.BTNactualizar.Location = New System.Drawing.Point(53, 350)
        Me.BTNactualizar.Name = "BTNactualizar"
        Me.BTNactualizar.Size = New System.Drawing.Size(30, 28)
        Me.BTNactualizar.TabIndex = 2
        Me.BTNactualizar.UseVisualStyleBackColor = True
        '
        'BTNdeshacer
        '
        Me.BTNdeshacer.Image = Global.PruebaNomina.My.Resources.Resources.Deshacer
        Me.BTNdeshacer.Location = New System.Drawing.Point(11, 350)
        Me.BTNdeshacer.Name = "BTNdeshacer"
        Me.BTNdeshacer.Size = New System.Drawing.Size(30, 28)
        Me.BTNdeshacer.TabIndex = 1
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
        Me.Controls.Add(Me.BTNactualizar)
        Me.Controls.Add(Me.BTNdeshacer)
        Me.Controls.Add(Me.TABconfiguracion)
        Me.Name = "@NOMBREFORMA2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "@TITULOFORMA"
        CType(Me.Errores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
@FRIENDTEXBOX
    Friend WithEvents CIIU1TextBox As TextBox
    Friend WithEvents CIIU2TextBox As TextBox
    Friend WithEvents CIIU3TextBox As TextBox
    Friend WithEvents NitTextBox As TextBox
    Friend WithEvents DvTextBox As TextBox
    Friend WithEvents NombreTextBox As TextBox
    Friend WithEvents CiudadTextBox As TextBox
    Friend WithEvents TelefonoTextBox As TextBox
    Friend WithEvents IdTextBox As TextBox
@QUEDASI
    Friend WithEvents BTNdeshacer As Button
    Friend WithEvents BTNactualizar As Button
    Friend WithEvents Errores As ErrorProvider
End Class
