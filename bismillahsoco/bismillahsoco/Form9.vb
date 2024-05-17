Imports MySql.Data.MySqlClient

Public Class Form9
    Dim selectedProductId As Integer

    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadWishlistData()
    End Sub

    Public Sub LoadWishlistData()
        Try
            Module1.koneksi()
            Dim query As String = "SELECT f.id, f.brand, f.jenis, f.shade, f.harga, f.kategori, f.gambar, f.deskripsi FROM tbwishlist w JOIN tbform1 f ON w.id_makeup = f.id WHERE w.id = @username"
            Using cmd As New MySqlCommand(query, Module1.CONN)
                cmd.Parameters.AddWithValue("@username", Module1.LoggedInUsername)
                Dim adapter As New MySqlDataAdapter(cmd)
                Dim table As New DataTable()
                adapter.Fill(table)
                DataGridView1.DataSource = table
            End Using
            DataGridView1.Columns("id").Visible = False

            DataGridView1.RowTemplate.Height = 155
            For Each row As DataGridViewRow In DataGridView1.Rows
                row.Height = 155
            Next

            Dim imgColumn As DataGridViewImageColumn = TryCast(DataGridView1.Columns("gambar"), DataGridViewImageColumn)
            If imgColumn IsNot Nothing Then
                imgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading wishlist: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnKembali_Click(sender As Object, e As EventArgs) Handles btnKembali.Click
        Me.Hide()
        Form7.Show()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            Dim cellValue = DataGridView1.Rows(e.RowIndex).Cells("id").Value
            If Not IsDBNull(cellValue) Then
                selectedProductId = Convert.ToInt32(cellValue)
            Else
                selectedProductId = 0
            End If
        End If
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        If selectedProductId <> 0 Then
            Dim confirmResult As DialogResult = MessageBox.Show("Apakah Anda Yakin Ingin Menghapus Produk Ini Dari Wishlist?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If confirmResult = DialogResult.Yes Then
                DeleteProductFromWishlist(selectedProductId)
            End If
        Else
            MessageBox.Show("Pilih Produk Yang Ingin Dihapus Dari Wishlist Anda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub DeleteProductFromWishlist(productId As Integer)
        Try
            Module1.koneksi()
            Dim query As String = "DELETE FROM tbwishlist WHERE id_makeup = @productId AND id = @username"
            Using cmd As New MySqlCommand(query, Module1.CONN)
                cmd.Parameters.AddWithValue("@productId", productId)
                cmd.Parameters.AddWithValue("@username", Module1.LoggedInUsername)
                cmd.ExecuteNonQuery()
            End Using
            MessageBox.Show("Produk Berhasil Dihapus Dari Wishlist Anda", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadWishlistData() ' Refresh the wishlist data
        Catch ex As Exception
            MessageBox.Show("Error deleting product: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class

