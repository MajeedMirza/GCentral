Public Class MainScreen

    Private Sub Zmbi_Click(sender As Object, e As EventArgs) Handles Zmbi.Click
        Dim zmb As New Main
        zmb.ShowDialog()
    End Sub

    Private Sub btnBMTron_Click(sender As Object, e As EventArgs) Handles btnBMTron.Click
        Dim BM As New BMTron
        BMTron.ShowDialog()
    End Sub

    Private Sub btnSudoku_Click(sender As Object, e As EventArgs) Handles btnSudoku.Click
        Dim sd As New SDKU
        sd.ShowDialog()
    End Sub

    Private Sub btnPops_Click(sender As Object, e As EventArgs) Handles btnPops.Click
        Dim pop As New Pops
        Pops.ShowDialog()
    End Sub

    Private Sub btnSnake_Click(sender As Object, e As EventArgs) Handles btnSnake.Click
        Dim sn As New Sk
        Sk.ShowDialog()
    End Sub

    Private Sub btnTanks_Click(sender As Object, e As EventArgs) Handles btnTanks.Click
        Dim t As New cnn
        cnn.ShowDialog()
    End Sub
End Class