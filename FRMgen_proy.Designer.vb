<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRMgen_proy
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
        Me.Plantilla2texbox = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Plantilla1texbox = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BTNgenerar = New System.Windows.Forms.Button()
        Me.TituloFormatexbox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NombreFormatexbox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DGVcampos = New System.Windows.Forms.DataGridView()
        Me.DBtextbox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.COBtablas = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.DGVcampos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Plantilla2texbox
        '
        Me.Plantilla2texbox.Location = New System.Drawing.Point(636, 28)
        Me.Plantilla2texbox.Name = "Plantilla2texbox"
        Me.Plantilla2texbox.Size = New System.Drawing.Size(150, 20)
        Me.Plantilla2texbox.TabIndex = 31
        Me.Plantilla2texbox.Text = "Plantilla2.txt"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(577, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Plantilla 2"
        '
        'Plantilla1texbox
        '
        Me.Plantilla1texbox.Location = New System.Drawing.Point(636, 1)
        Me.Plantilla1texbox.Name = "Plantilla1texbox"
        Me.Plantilla1texbox.Size = New System.Drawing.Size(150, 20)
        Me.Plantilla1texbox.TabIndex = 29
        Me.Plantilla1texbox.Text = "Plantilla1.txt"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(577, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Plantilla 1"
        '
        'BTNgenerar
        '
        Me.BTNgenerar.Location = New System.Drawing.Point(1011, 608)
        Me.BTNgenerar.Name = "BTNgenerar"
        Me.BTNgenerar.Size = New System.Drawing.Size(164, 23)
        Me.BTNgenerar.TabIndex = 27
        Me.BTNgenerar.Text = "Genera Formas"
        Me.BTNgenerar.UseVisualStyleBackColor = True
        '
        'TituloFormatexbox
        '
        Me.TituloFormatexbox.Location = New System.Drawing.Point(337, 28)
        Me.TituloFormatexbox.Name = "TituloFormatexbox"
        Me.TituloFormatexbox.Size = New System.Drawing.Size(224, 20)
        Me.TituloFormatexbox.TabIndex = 26
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(257, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Titulo Forma"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'NombreFormatexbox
        '
        Me.NombreFormatexbox.Location = New System.Drawing.Point(337, 2)
        Me.NombreFormatexbox.Name = "NombreFormatexbox"
        Me.NombreFormatexbox.Size = New System.Drawing.Size(150, 20)
        Me.NombreFormatexbox.TabIndex = 24
        Me.NombreFormatexbox.Text = "FRM"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(257, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 13)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Nombre Forma"
        '
        'DGVcampos
        '
        Me.DGVcampos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVcampos.Location = New System.Drawing.Point(11, 49)
        Me.DGVcampos.Name = "DGVcampos"
        Me.DGVcampos.Size = New System.Drawing.Size(1232, 550)
        Me.DGVcampos.TabIndex = 22
        '
        'DBtextbox
        '
        Me.DBtextbox.Location = New System.Drawing.Point(82, 28)
        Me.DBtextbox.Name = "DBtextbox"
        Me.DBtextbox.Size = New System.Drawing.Size(153, 20)
        Me.DBtextbox.TabIndex = 21
        Me.DBtextbox.Text = "local_20220708"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Base de datos"
        '
        'COBtablas
        '
        Me.COBtablas.FormattingEnabled = True
        Me.COBtablas.Location = New System.Drawing.Point(82, 1)
        Me.COBtablas.Name = "COBtablas"
        Me.COBtablas.Size = New System.Drawing.Size(153, 21)
        Me.COBtablas.TabIndex = 19
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Tablas"
        '
        'FRMgen_proy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1255, 640)
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
        Me.Name = "FRMgen_proy"
        Me.Text = "Genera proyecto completo"
        CType(Me.DGVcampos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Plantilla2texbox As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Plantilla1texbox As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents BTNgenerar As Button
    Friend WithEvents TituloFormatexbox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents NombreFormatexbox As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents DGVcampos As DataGridView
    Friend WithEvents DBtextbox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents COBtablas As ComboBox
    Friend WithEvents Label1 As Label
End Class
