<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRMgenerador
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.COBtablas = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DBtextbox = New System.Windows.Forms.TextBox()
        Me.DGVcampos = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.NombreFormatexbox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TituloFormatexbox = New System.Windows.Forms.TextBox()
        Me.BTNgenerar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Plantilla1texbox = New System.Windows.Forms.TextBox()
        Me.Plantilla2texbox = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.DGVcampos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tablas"
        '
        'COBtablas
        '
        Me.COBtablas.FormattingEnabled = True
        Me.COBtablas.Location = New System.Drawing.Point(83, 18)
        Me.COBtablas.Name = "COBtablas"
        Me.COBtablas.Size = New System.Drawing.Size(153, 21)
        Me.COBtablas.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Base de datos"
        '
        'DBtextbox
        '
        Me.DBtextbox.Location = New System.Drawing.Point(83, 45)
        Me.DBtextbox.Name = "DBtextbox"
        Me.DBtextbox.Size = New System.Drawing.Size(153, 20)
        Me.DBtextbox.TabIndex = 3
        Me.DBtextbox.Text = "local_20220708"
        '
        'DGVcampos
        '
        Me.DGVcampos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVcampos.Location = New System.Drawing.Point(12, 66)
        Me.DGVcampos.Name = "DGVcampos"
        Me.DGVcampos.Size = New System.Drawing.Size(1182, 338)
        Me.DGVcampos.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(258, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Nombre Forma"
        '
        'NombreFormatexbox
        '
        Me.NombreFormatexbox.Location = New System.Drawing.Point(338, 19)
        Me.NombreFormatexbox.Name = "NombreFormatexbox"
        Me.NombreFormatexbox.Size = New System.Drawing.Size(150, 20)
        Me.NombreFormatexbox.TabIndex = 6
        Me.NombreFormatexbox.Text = "FRM"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(258, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Titulo Forma"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'TituloFormatexbox
        '
        Me.TituloFormatexbox.Location = New System.Drawing.Point(338, 45)
        Me.TituloFormatexbox.Name = "TituloFormatexbox"
        Me.TituloFormatexbox.Size = New System.Drawing.Size(224, 20)
        Me.TituloFormatexbox.TabIndex = 8
        '
        'BTNgenerar
        '
        Me.BTNgenerar.Location = New System.Drawing.Point(599, 415)
        Me.BTNgenerar.Name = "BTNgenerar"
        Me.BTNgenerar.Size = New System.Drawing.Size(164, 23)
        Me.BTNgenerar.TabIndex = 9
        Me.BTNgenerar.Text = "Genera Formas"
        Me.BTNgenerar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(578, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Plantilla 1"
        '
        'Plantilla1texbox
        '
        Me.Plantilla1texbox.Location = New System.Drawing.Point(637, 18)
        Me.Plantilla1texbox.Name = "Plantilla1texbox"
        Me.Plantilla1texbox.Size = New System.Drawing.Size(150, 20)
        Me.Plantilla1texbox.TabIndex = 11
        Me.Plantilla1texbox.Text = "Plantilla1.txt"
        '
        'Plantilla2texbox
        '
        Me.Plantilla2texbox.Location = New System.Drawing.Point(637, 45)
        Me.Plantilla2texbox.Name = "Plantilla2texbox"
        Me.Plantilla2texbox.Size = New System.Drawing.Size(150, 20)
        Me.Plantilla2texbox.TabIndex = 13
        Me.Plantilla2texbox.Text = "Plantilla2.txt"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(578, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Plantilla 2"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(35, 417)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(85, 20)
        Me.DateTimePicker1.TabIndex = 14
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(906, 23)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(152, 20)
        Me.TextBox1.TabIndex = 15
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(331, 410)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(81, 17)
        Me.CheckBox1.TabIndex = 16
        Me.CheckBox1.Text = "CheckBox1"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(414, 446)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(73, 21)
        Me.Button1.TabIndex = 17
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FRMgenerador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1206, 482)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Plantilla2texbox)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Plantilla1texbox)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.BTNgenerar)
        Me.Controls.Add(Me.TituloFormatexbox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.NombreFormatexbox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DGVcampos)
        Me.Controls.Add(Me.DBtextbox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.COBtablas)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FRMgenerador"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Generador de Formas MySQL"
        CType(Me.DGVcampos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents COBtablas As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents DBtextbox As TextBox
    Friend WithEvents DGVcampos As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents NombreFormatexbox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TituloFormatexbox As TextBox
    Friend WithEvents BTNgenerar As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Plantilla1texbox As TextBox
    Friend WithEvents Plantilla2texbox As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Button1 As Button
End Class
