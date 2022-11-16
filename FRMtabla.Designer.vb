<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRMtablas
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
        Me.DGVtablas = New System.Windows.Forms.DataGridView()
        Me.DBtextbox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BTNgenera = New System.Windows.Forms.Button()
        Me.DGVcampos = New System.Windows.Forms.DataGridView()
        Me.BTNgraba = New System.Windows.Forms.Button()
        CType(Me.DGVtablas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGVcampos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGVtablas
        '
        Me.DGVtablas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVtablas.Location = New System.Drawing.Point(12, 32)
        Me.DGVtablas.Name = "DGVtablas"
        Me.DGVtablas.Size = New System.Drawing.Size(176, 705)
        Me.DGVtablas.TabIndex = 0
        '
        'DBtextbox
        '
        Me.DBtextbox.Location = New System.Drawing.Point(86, 6)
        Me.DBtextbox.Name = "DBtextbox"
        Me.DBtextbox.Size = New System.Drawing.Size(153, 20)
        Me.DBtextbox.TabIndex = 5
        Me.DBtextbox.Text = "erp"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Base de datos"
        '
        'BTNgenera
        '
        Me.BTNgenera.Location = New System.Drawing.Point(312, 1)
        Me.BTNgenera.Name = "BTNgenera"
        Me.BTNgenera.Size = New System.Drawing.Size(101, 28)
        Me.BTNgenera.TabIndex = 6
        Me.BTNgenera.Text = "Genera archivo"
        Me.BTNgenera.UseVisualStyleBackColor = True
        '
        'DGVcampos
        '
        Me.DGVcampos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVcampos.Location = New System.Drawing.Point(194, 32)
        Me.DGVcampos.Name = "DGVcampos"
        Me.DGVcampos.Size = New System.Drawing.Size(1040, 705)
        Me.DGVcampos.TabIndex = 7
        '
        'BTNgraba
        '
        Me.BTNgraba.Location = New System.Drawing.Point(466, 1)
        Me.BTNgraba.Name = "BTNgraba"
        Me.BTNgraba.Size = New System.Drawing.Size(102, 27)
        Me.BTNgraba.TabIndex = 8
        Me.BTNgraba.Text = "Graba base"
        Me.BTNgraba.UseVisualStyleBackColor = True
        '
        'FRMtablas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1246, 749)
        Me.Controls.Add(Me.BTNgraba)
        Me.Controls.Add(Me.DGVcampos)
        Me.Controls.Add(Me.BTNgenera)
        Me.Controls.Add(Me.DBtextbox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DGVtablas)
        Me.Name = "FRMtablas"
        Me.Text = "Form1"
        CType(Me.DGVtablas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGVcampos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DGVtablas As DataGridView
    Friend WithEvents DBtextbox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents BTNgenera As Button
    Friend WithEvents DGVcampos As DataGridView
    Friend WithEvents BTNgraba As Button
End Class
