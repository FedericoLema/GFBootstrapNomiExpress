Public Class FRMMenu
    Private Sub EscogerTablasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EscogerTablasToolStripMenuItem.Click
        FRMtablas.Show()
    End Sub

    Private Sub IngresarPropiedadesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresarPropiedadesToolStripMenuItem.Click
        FRMreglas.Show()
    End Sub

    Private Sub GeneradorPorTablaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GeneradorPorTablaToolStripMenuItem.Click
        FRMgenerador.Show()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        FRMgen_proy.Show()
    End Sub

    Private Sub FRMMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class