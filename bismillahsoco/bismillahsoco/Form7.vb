Public Class Form7
    Public Property loggedInid As String
    Private Sub btnlihat_Click(sender As Object, e As EventArgs) Handles btnlihat.Click
        ' Buka Form8 saat tombol btnlihat diklik
        Dim form8 As New Form8()
        form8.Show()
        Me.Hide() ' Sembunyikan Form7 saat Form8 ditampilkan
    End Sub

    Private Sub btnWishlist_Click(sender As Object, e As EventArgs) Handles btnWishlist.Click
        ' Buka Form9 saat tombol btnWishlist diklik
        Dim form9 As New Form9()
        form9.Show()
        Me.Hide() ' Sembunyikan Form7 saat Form9 ditampilkan
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Close()
        Form5.Show()
    End Sub
End Class
