<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class @NOMBREFORMA
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.DGV@NOMBRETABLA = New System.Windows.Forms.DataGridView()
        Me.COBcampos = New System.Windows.Forms.ComboBox()
        Me.COBoperador = New System.Windows.Forms.ComboBox()
        Me.ValorBuscar = New System.Windows.Forms.TextBox()
        Me.GRBbuscar = New System.Windows.Forms.GroupBox()
        Me.BTNdeshacer = New System.Windows.Forms.Button()
        Me.COBconector = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LBLfiltro = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BTNbuscar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BTNexportar = New System.Windows.Forms.Button()
        Me.BTNcopiar = New System.Windows.Forms.Button()
        Me.BTNmodificar = New System.Windows.Forms.Button()
        Me.BTNborrar = New System.Windows.Forms.Button()
        Me.BTNcrear = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.DGV@NOMBRETABLA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GRBbuscar.SuspendLayout()
        Me.SuspendLayout()
        '
        'DGV@NOMBRETABLA
        '
        Me.DGV@NOMBRETABLA.AllowUserToAddRows = False
        Me.DGV@NOMBRETABLA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV@NOMBRETABLA.Location = New System.Drawing.Point(12, 12)
        Me.DGV@NOMBRETABLA.MultiSelect = False
        Me.DGV@NOMBRETABLA.Name = "DGV@NOMBRETABLA"
        Me.DGV@NOMBRETABLA.ReadOnly = True
        Me.DGV@NOMBRETABLA.Size = New System.Drawing.Size(776, 267)
        Me.DGV@NOMBRETABLA.TabIndex = 0
        '
        'COBcampos
        '
        Me.COBcampos.FormattingEnabled = True
        Me.COBcampos.Location = New System.Drawing.Point(47, 21)
        Me.COBcampos.Name = "COBcampos"
        Me.COBcampos.Size = New System.Drawing.Size(122, 21)
        Me.COBcampos.TabIndex = 5
        '
        'COBoperador
        '
        Me.COBoperador.FormattingEnabled = True
        Me.COBoperador.Location = New System.Drawing.Point(226, 21)
        Me.COBoperador.Name = "COBoperador"
        Me.COBoperador.Size = New System.Drawing.Size(121, 21)
        Me.COBoperador.TabIndex = 6
        '
        'ValorBuscar
        '
        Me.ValorBuscar.Location = New System.Drawing.Point(383, 21)
        Me.ValorBuscar.Name = "ValorBuscar"
        Me.ValorBuscar.Size = New System.Drawing.Size(113, 20)
        Me.ValorBuscar.TabIndex = 7
        '
        'GRBbuscar
        '
        Me.GRBbuscar.Controls.Add(Me.Label4)
        Me.GRBbuscar.Controls.Add(Me.BTNdeshacer)
        Me.GRBbuscar.Controls.Add(Me.COBconector)
        Me.GRBbuscar.Controls.Add(Me.Label5)
        Me.GRBbuscar.Controls.Add(Me.LBLfiltro)
        Me.GRBbuscar.Controls.Add(Me.Label3)
        Me.GRBbuscar.Controls.Add(Me.BTNbuscar)
        Me.GRBbuscar.Controls.Add(Me.Label2)
        Me.GRBbuscar.Controls.Add(Me.ValorBuscar)
        Me.GRBbuscar.Controls.Add(Me.Label1)
        Me.GRBbuscar.Controls.Add(Me.COBoperador)
        Me.GRBbuscar.Controls.Add(Me.COBcampos)
        Me.GRBbuscar.Location = New System.Drawing.Point(126, 283)
        Me.GRBbuscar.Name = "GRBbuscar"
        Me.GRBbuscar.Size = New System.Drawing.Size(662, 76)
        Me.GRBbuscar.TabIndex = 8
        Me.GRBbuscar.TabStop = False
        Me.GRBbuscar.Text = "Buscar"
'
        'BTNexportar
        '
        Me.BTNexportar.Image = Global.PruebaNomina.My.Resources.Resources.excel
        Me.BTNexportar.Location = New System.Drawing.Point(84, 324)
        Me.BTNexportar.Name = "BTNexportar"
        Me.BTNexportar.Size = New System.Drawing.Size(30, 28)
        Me.BTNexportar.TabIndex = 14
        Me.BTNexportar.UseVisualStyleBackColor = True
        '
        'BTNcopiar
        '
        Me.BTNcopiar.Image = Global.PruebaNomina.My.Resources.Resources.Copiar
        Me.BTNcopiar.Location = New System.Drawing.Point(12, 324)
        Me.BTNcopiar.Name = "BTNcopiar"
        Me.BTNcopiar.Size = New System.Drawing.Size(30, 28)
        Me.BTNcopiar.TabIndex = 9
        Me.BTNcopiar.UseVisualStyleBackColor = True        '
        'BTNdeshacer
        '
        Me.BTNdeshacer.Image = Global.PruebaNomina.My.Resources.Resources.Deshacer
        Me.BTNdeshacer.Location = New System.Drawing.Point(632, 13)
        Me.BTNdeshacer.Name = "BTNdeshacer"
        Me.BTNdeshacer.Size = New System.Drawing.Size(30, 28)
        Me.BTNdeshacer.TabIndex = 12
        Me.BTNdeshacer.UseVisualStyleBackColor = True
        '
        'COBconector
        '
        Me.COBconector.FormattingEnabled = True
        Me.COBconector.Location = New System.Drawing.Point(548, 21)
        Me.COBconector.Name = "COBconector"
        Me.COBconector.Size = New System.Drawing.Size(47, 21)
        Me.COBconector.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(498, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Conector"
        '
        'LBLfiltro
        '
        Me.LBLfiltro.AutoSize = True
        Me.LBLfiltro.Location = New System.Drawing.Point(53, 53)
        Me.LBLfiltro.Name = "LBLfiltro"
        Me.LBLfiltro.Size = New System.Drawing.Size(0, 13)
        Me.LBLfiltro.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(350, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Valor"
        '
        'BTNbuscar
        '
        Me.BTNbuscar.Image = Global.PruebaNomina.My.Resources.Resources.Buscar
        Me.BTNbuscar.Location = New System.Drawing.Point(600, 13)
        Me.BTNbuscar.Name = "BTNbuscar"
        Me.BTNbuscar.Size = New System.Drawing.Size(30, 28)
        Me.BTNbuscar.TabIndex = 4
        Me.BTNbuscar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(172, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Operador"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Campo"
        '
        'BTNmodificar
        '
        Me.BTNmodificar.Image = Global.PruebaNomina.My.Resources.Resources.Modificar
        Me.BTNmodificar.Location = New System.Drawing.Point(48, 285)
        Me.BTNmodificar.Name = "BTNmodificar"
        Me.BTNmodificar.Size = New System.Drawing.Size(30, 28)
        Me.BTNmodificar.TabIndex = 3
        Me.BTNmodificar.UseVisualStyleBackColor = True
        '
        'BTNborrar
        '
        Me.BTNborrar.Image = Global.PruebaNomina.My.Resources.Resources.Borrar
        Me.BTNborrar.Location = New System.Drawing.Point(84, 285)
        Me.BTNborrar.Name = "BTNborrar"
        Me.BTNborrar.Size = New System.Drawing.Size(30, 28)
        Me.BTNborrar.TabIndex = 2
        Me.BTNborrar.UseVisualStyleBackColor = True
        '
        'BTNcrear
        '
        Me.BTNcrear.Image = Global.PruebaNomina.My.Resources.Resources.Nuevo
        Me.BTNcrear.Location = New System.Drawing.Point(12, 285)
        Me.BTNcrear.Name = "BTNcrear"
        Me.BTNcrear.Size = New System.Drawing.Size(30, 28)
        Me.BTNcrear.TabIndex = 1
        Me.BTNcrear.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Filtro"
        '
        '@NOMBREFORMA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 363)
        Me.Controls.Add(Me.BTNexportar)
        Me.Controls.Add(Me.BTNcopiar)
        Me.Controls.Add(Me.GRBbuscar)
        Me.Controls.Add(Me.BTNmodificar)
        Me.Controls.Add(Me.BTNborrar)
        Me.Controls.Add(Me.BTNcrear)
        Me.Controls.Add(Me.DGV@NOMBRETABLA)
        Me.Name = "@NOMBREFORMA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "@TITULOFORMA"
        CType(Me.DGV@NOMBRETABLA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GRBbuscar.ResumeLayout(False)
        Me.GRBbuscar.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DGV@NOMBRETABLA As DataGridView
    Friend WithEvents BTNcrear As Button
    Friend WithEvents BTNborrar As Button
    Friend WithEvents BTNmodificar As Button
    Friend WithEvents BTNbuscar As Button
    Friend WithEvents BTNcopiar As Button
    Friend WithEvents COBcampos As ComboBox
    Friend WithEvents COBoperador As ComboBox
    Friend WithEvents ValorBuscar As TextBox
    Friend WithEvents GRBbuscar As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LBLfiltro As Label
    Friend WithEvents COBconector As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents BTNdeshacer As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents BTNexportar As Button
End Class
