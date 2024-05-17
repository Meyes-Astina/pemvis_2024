Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Drawing.Imaging

Public Class Form2
    Dim pictureBoxFromForm1 As PictureBox
    Dim selectedID As String = ""

    Public Sub New()
        InitializeComponent()
        DataGridView1.RowTemplate.Height = 75 ' ketinggian kolom 
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Memuat data ke dalam DataGridView saat Formulir2 dimuat
        RefreshDataGridView()
        ' Memuat data ke dalam DataGridView saat Formulir2 dimuat
        RefreshDataGridView()

        ' Atur warna latar belakang dan warna teks DataGridView
        DataGridView1.DefaultCellStyle.ForeColor = Color.Black

        DataGridView1.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black

        DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DeepPink

        DataGridView1.EnableHeadersVisualStyles = False

    End Sub

    Public Sub RefreshDataGridView()
        Try
            ' Buka Koneksi
            Module1.koneksi()
            Dim query As String = "SELECT * FROM tbform1"
            Using cmd As New MySqlCommand(query, Module1.CONN)
                Using adapter As New MySqlDataAdapter(cmd)
                    Dim table As New DataTable()
                    adapter.Fill(table)

                    DataGridView1.DataSource = table

                    ' Mengatur Kolom Gambar
                    Dim imgColumn As DataGridViewImageColumn = TryCast(DataGridView1.Columns("Gambar"), DataGridViewImageColumn)
                    If imgColumn IsNot Nothing Then
                        imgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
                        imgColumn.DefaultCellStyle.NullValue = Nothing
                        imgColumn.Width = 155 ' Ukuran lebar
                    End If

                    ' Sesuaikan kolom lain sesuai kebutuhan
                    For Each column As DataGridViewColumn In DataGridView1.Columns
                        If column.Name <> "Gambar" Then
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        End If
                    Next
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error refreshing DataGridView: " & ex.Message)
        Finally
            ' Close database connection
            Module1.TutupKoneksi()
        End Try
    End Sub

    ' Method called when an error occurs in DataGridView data
    Private Sub DataGridView1_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        ' Show custom error message
        MessageBox.Show("An error occurred while processing the data. Please try again.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        ' Optionally, you can handle the error and prevent the default error dialog from appearing
        e.ThrowException = False
        e.Cancel = True
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim idSkincareToDelete As String = DataGridView1.SelectedRows(0).Cells("ID").Value.ToString()

            If MessageBox.Show("Anda yakin ingin menghapus data ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim query As String = "DELETE FROM tbform1 WHERE ID = @ID"

                Try
                    ' Open database connection
                    Module1.koneksi()

                    Using CMD As New MySqlCommand(query, Module1.CONN)
                        CMD.Parameters.AddWithValue("@ID", idSkincareToDelete)
                        CMD.ExecuteNonQuery()
                    End Using

                    ' Refresh DataGridView after deletion
                    RefreshDataGridView()
                    MsgBox("Data berhasil dihapus!")
                Catch ex As Exception
                    MessageBox.Show("Error deleting data: " & ex.Message)
                Finally
                    ' Close database connection
                    Module1.TutupKoneksi()
                End Try
            End If
        Else
            MsgBox("Pilih baris yang ingin dihapus")
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Module1.koneksi()
        ' Check if a row is selected in DataGridView
        If Not String.IsNullOrEmpty(selectedID) Then
            ' Open Form3 with the selected ID
            Dim form3 As New Form3(selectedID)
            AddHandler form3.FormClosed, AddressOf Me.Form3_FormClosed
            Me.Hide()
            form3.Show()
        Else
            MessageBox.Show("Pilih baris yang ingin diedit")
        End If
        Module1.TutupKoneksi()
    End Sub

    Private Sub Form3_FormClosed(sender As Object, e As FormClosedEventArgs)
        RefreshDataGridView()
    End Sub


    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            selectedID = row.Cells("ID").Value.ToString()
            btnEdit.Enabled = True
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim keyword As String = txtSearch.Text.Trim()
        If Not String.IsNullOrEmpty(keyword) Then
            Try
                Module1.koneksi()

                Dim query As String = "SELECT * FROM tbform1 WHERE brand LIKE @Brand"
                Using CMD As New MySqlCommand(query, Module1.CONN)
                    CMD.Parameters.AddWithValue("@Brand", "%" & keyword & "%")

                    Using adapter As New MySqlDataAdapter(CMD)
                        Dim table As New DataTable()
                        adapter.Fill(table)
                        DataGridView1.DataSource = table
                    End Using
                End Using
            Catch ex As Exception
                ' Handle the error if any
                MessageBox.Show("Gagal Mencari data: " & ex.Message, "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                ' Close database connection
                Module1.TutupKoneksi()
            End Try
        Else
            ' Show a message if the search box is empty
            MessageBox.Show("Silakan masukkan kata kunci pencarian.", "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnKembali_Click(sender As Object, e As EventArgs) Handles btnKembali.Click
        Dim form10 As New Form10()
        form10.Show()
        Me.Hide()
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        Dim form1 As New Form1()
        form1.Show()
        Me.Hide()
        RefreshDataGridView()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Dim form10 As New Form10()
        form10.Show()
        Me.Hide()
    End Sub
End Class
