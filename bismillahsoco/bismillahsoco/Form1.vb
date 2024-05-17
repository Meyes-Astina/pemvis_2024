Imports MySql.Data.MySqlClient
Imports System.IO

Public Class Form1
    Public Property DataGridView1 As DataGridView

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Panggil metode koneksi dari Module1
        Module1.koneksi()

        ' Inisialisasi DataGridView1 dengan DataGridView dari Form2
        DataGridView1 = Form2.DataGridView1

        ' Tambahkan KeyDown event handler untuk semua inputan
        AddHandler txtJenis.KeyDown, AddressOf Input_KeyDown
        AddHandler txtShade.KeyDown, AddressOf Input_KeyDown
        AddHandler txtHarga.KeyDown, AddressOf Input_KeyDown
        AddHandler txtStok.KeyDown, AddressOf Input_KeyDown
        AddHandler cbBrand.KeyDown, AddressOf Input_KeyDown
        AddHandler rbEye.KeyDown, AddressOf Input_KeyDown
        AddHandler rbFace.KeyDown, AddressOf Input_KeyDown
        AddHandler rbLips.KeyDown, AddressOf Input_KeyDown
        AddHandler PictureBox1.KeyDown, AddressOf Input_KeyDown
        AddHandler RichTextBox1.KeyDown, AddressOf Input_KeyDown
        AddHandler DateTimePicker1.KeyDown, AddressOf Input_KeyDown

        RefreshDataGridView()
        FillComboBoxFromForm4()
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Panggil metode TutupKoneksi dari Module1 sebelum form ditutup
        Module1.TutupKoneksi()
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        Try
            ' Membuka koneksi jika belum terbuka
            If Module1.CONN.State = ConnectionState.Closed Then
                Module1.koneksi()
            End If

            ' Validasi input
            If cbBrand.SelectedItem Is Nothing OrElse
               String.IsNullOrEmpty(cbBrand.SelectedItem.ToString()) OrElse
               String.IsNullOrEmpty(txtJenis.Text) OrElse
               String.IsNullOrEmpty(txtShade.Text) OrElse
               String.IsNullOrEmpty(txtHarga.Text) OrElse
               String.IsNullOrEmpty(txtStok.Text) OrElse
               String.IsNullOrEmpty(GetSelectedRadioButtonText()) OrElse
               PictureBox1 Is Nothing OrElse
               PictureBox1.Image Is Nothing OrElse
               String.IsNullOrEmpty(RichTextBox1.Text) Then
                MessageBox.Show("Semua kolom harus diisi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Validasi bahwa jenis hanya berisi huruf
            If Not txtJenis.Text.All(Function(c) Char.IsLetter(c) Or Char.IsWhiteSpace(c)) Then
                MessageBox.Show("Jenis hanya boleh berisi huruf dan spasi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Validasi shadeValue kosong atau hanya berisi huruf dan angka
            Dim shade As String = txtShade.Text.Trim()
            If String.IsNullOrWhiteSpace(shade) OrElse Not System.Text.RegularExpressions.Regex.IsMatch(shade, "^[a-zA-Z0-9]+$") Then
                MessageBox.Show("Shade hanya boleh berisi huruf dan angka.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            ' Validasi shadeValue tidak sama dengan 0
            If shade = "0" Then
                MessageBox.Show("Shade tidak boleh bernilai 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Validasi bahwa harga hanya berisi angka dan tidak boleh 0
            Dim harga As Decimal
            If Not Decimal.TryParse(txtHarga.Text, harga) OrElse harga <= 0 Then
                MessageBox.Show("Harga harus berupa angka dan > 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Validasi bahwa stok hanya berisi angka dan tidak boleh 0
            Dim stok As Integer
            If Not Integer.TryParse(txtStok.Text, stok) OrElse stok <= 0 Then
                MessageBox.Show("Stok harus berupa angka bulat dan > 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Melanjutkan dengan operasi insert jika semua validasi berhasil
            Dim [date] As Date = DateTimePicker1.Value
            Dim kategori As String = GetSelectedRadioButtonText()
            Using CMD As New MySqlCommand("INSERT INTO tbform1 (Brand, Jenis, Shade, Harga, Tanggal, Stok, Kategori, Gambar, Deskripsi) 
            VALUES (@Brand, @Jenis, @Shade, @Harga, @Tanggal, @Stok, @Kategori, @Gambar, @Deskripsi)", Module1.CONN)
                CMD.Parameters.AddWithValue("@Brand", cbBrand.SelectedItem.ToString())
                CMD.Parameters.AddWithValue("@Jenis", txtJenis.Text)
                CMD.Parameters.AddWithValue("@Shade", txtShade.Text)
                CMD.Parameters.AddWithValue("@Harga", Convert.ToDecimal(txtHarga.Text))
                CMD.Parameters.AddWithValue("@Tanggal", [date].ToString("yyyy-MM-dd"))
                CMD.Parameters.AddWithValue("@Stok", Convert.ToInt32(txtStok.Text))
                CMD.Parameters.AddWithValue("@Kategori", kategori)

                Using ms As New MemoryStream()
                    PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
                    Dim img As Byte() = ms.ToArray()
                    CMD.Parameters.AddWithValue("@Gambar", img)
                End Using

                CMD.Parameters.AddWithValue("@Deskripsi", RichTextBox1.Text)

                CMD.ExecuteNonQuery()
            End Using

            MessageBox.Show("Data berhasil ditambahkan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

            RefreshDataGridView()

            ClearInputFields()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Tutup koneksi dalam blok finally untuk memastikan bahwa koneksi ditutup, baik terjadi kesalahan maupun tidak
            Module1.TutupKoneksi()
        End Try
    End Sub

    Private Function GetSelectedRadioButtonText() As String
        If rbEye.Checked Then
            Return "Eye"
        ElseIf rbFace.Checked Then
            Return "Face"
        ElseIf rbLips.Checked Then
            Return "Lips"
        Else
            Return ""
        End If
    End Function

    Private Sub FillComboBoxFromForm4()
        Try
            Dim query As String = "SELECT Brand FROM tbbrand"
            Using cmd As New MySqlCommand(query, Module1.CONN)
                Using RD As MySqlDataReader = cmd.ExecuteReader()
                    cbBrand.Items.Clear()
                    While RD.Read()
                        cbBrand.Items.Add(RD("Brand").ToString())
                    End While
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Public Sub RefreshDataGridView()
        Try
            ' Membuka koneksi jika belum terbuka
            If Module1.CONN.State = ConnectionState.Closed Then
                Module1.koneksi()
            End If

            Dim query As String = "SELECT * FROM tbform1"
            Using cmd As New MySqlCommand(query, Module1.CONN)
                Dim table As New DataTable()
                DA = New MySqlDataAdapter(cmd)
                DA.Fill(table)
                DataGridView1.DataSource = table
                DataGridView1.RowTemplate.Height = 50
            End Using
        Catch ex As Exception
            MessageBox.Show("Error refreshing DataGridView: " & ex.Message)
        End Try
    End Sub

    Private Sub ClearInputFields()
        cbBrand.SelectedIndex = -1
        txtJenis.Clear()
        txtShade.Clear()
        txtHarga.Clear()
        txtStok.Clear()
        rbEye.Checked = False
        rbFace.Checked = False
        rbLips.Checked = False
        PictureBox1.Image = Nothing
        RichTextBox1.Clear()
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Dim openFileDialog1 As New OpenFileDialog
        openFileDialog1.Filter = "Images|*.jpg;*.png;*.jpeg"
        If openFileDialog1.ShowDialog = DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(openFileDialog1.FileName)
        End If
    End Sub

    Private Sub btnLihat_Click(sender As Object, e As EventArgs) Handles btnLihat.Click
        Me.Hide()
        Form2.Show()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Hide()
        Form10.Show()
    End Sub

    Private Sub Input_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
        ElseIf e.KeyCode = Keys.Down Then
            ' Jika menekan tombol bawah, navigasi ke kontrol berikutnya
            Me.SelectNextControl(sender, True, True, True, True)
        End If
    End Sub

End Class
