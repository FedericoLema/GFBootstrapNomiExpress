<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRMreglas
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
        Me.DGVcampos = New System.Windows.Forms.DataGridView()
        Me.BTNactualiza = New System.Windows.Forms.Button()
        CType(Me.DGVcampos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGVcampos
        '
        Me.DGVcampos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVcampos.Location = New System.Drawing.Point(2, 39)
        Me.DGVcampos.Name = "DGVcampos"
        Me.DGVcampos.Size = New System.Drawing.Size(1307, 631)
        Me.DGVcampos.TabIndex = 0
        '
        'BTNactualiza
        '
        Me.BTNactualiza.Location = New System.Drawing.Point(2, 12)
        Me.BTNactualiza.Name = "BTNactualiza"
        Me.BTNactualiza.Size = New System.Drawing.Size(128, 21)
        Me.BTNactualiza.TabIndex = 1
        Me.BTNactualiza.Text = "Actualiza"
        Me.BTNactualiza.UseVisualStyleBackColor = True
        '
        'FRMreglas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1321, 682)
        Me.Controls.Add(Me.BTNactualiza)
        Me.Controls.Add(Me.DGVcampos)
        Me.Name = "FRMreglas"
        Me.Text = "Form1"
        CType(Me.DGVcampos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DGVcampos As DataGridView
    Friend WithEvents BTNactualiza As Button
End Class
