Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Drawing.Imaging

Public Class Form3
    Dim selectedID As String = ""
    Private txtId As Object

    Public Sub New(ByVal id As String)
        InitializeComponent()
        selectedID = id
        LoadbrandFromForm4()
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDataToControls()
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
    End Sub

    Private Sub LoadDataToControls()
        Try
            Module1.koneksi()
            Using command As New MySqlCommand("SELECT * FROM tbform1 WHERE ID = @ID", Module1.CONN)
                command.Parameters.AddWithValue("@ID", selectedID)
                Dim reader As MySqlDataReader = command.ExecuteReader()
                If reader.Read() Then
                    'txtId.Text = reader("ID").ToString()
                    cbBrand.SelectedItem = reader("Brand").ToString()
                    txtJenis.Text = reader("Jenis").ToString()
                    txtShade.Text = reader("Shade").ToString()
                    txtHarga.Text = reader("Harga").ToString()
                    DateTimePicker1.Value = DateTime.Parse(reader("Tanggal").ToString())
                    txtStok.Text = reader("Stok").ToString()

                    Dim kategori As String = reader("Kategori").ToString()
                    If kategori = "Eye" Then
                        rbEye.Checked = True
                    ElseIf kategori = "Face" Then
                        rbFace.Checked = True
                    ElseIf kategori = "Lips" Then
                        rbLips.Checked = True
                    End If

                    ' Memuat gambar dari database ke PictureBox
                    Dim img As Byte() = TryCast(reader("Gambar"), Byte())
                    If img IsNot Nothing Then
                        Dim ms As New MemoryStream(img)
                        PictureBox1.Image = Image.FromStream(ms)
                    End If

                    RichTextBox1.Text = reader("Deskripsi").ToString()
                End If
                reader.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message)
        End Try
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        ' Validasi input
        If String.IsNullOrEmpty(cbBrand.SelectedItem?.ToString()) OrElse
           String.IsNullOrEmpty(txtJenis.Text) OrElse
           String.IsNullOrEmpty(txtShade.Text) OrElse
           String.IsNullOrEmpty(txtHarga.Text) OrElse
           String.IsNullOrEmpty(txtStok.Text) OrElse
           String.IsNullOrEmpty(GetSelectedRadioButtonText()) OrElse
           PictureBox1.Image Is Nothing OrElse
           String.IsNullOrEmpty(RichTextBox1.Text) Then

            MessageBox.Show("Semua field harus diisi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim shadeValue As String = txtShade.Text.Trim()

        ' validasi shadeValue kosong atau hanya berisi huruf dan angka
        If String.IsNullOrWhiteSpace(shadeValue) OrElse Not System.Text.RegularExpressions.Regex.IsMatch(shadeValue, "^[a-zA-Z0-9]+$") Then
            MessageBox.Show("Shade hanya boleh berisi huruf dan angka", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' validasi shadeValue tidak sama dengan 0
        If shadeValue = "0" Then
            MessageBox.Show("Shade tidak boleh bernilai 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Validasi bahwa jenis hanya berisi huruf
        If Not txtJenis.Text.All(Function(c) Char.IsLetter(c) Or Char.IsWhiteSpace(c)) Then
            MessageBox.Show("Jenis hanya boleh berisi huruf.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Validasi bahwa harga hanya berupa angka dan tidak boleh 0
        Dim hargaValue As Decimal
        If Not Decimal.TryParse(txtHarga.Text, hargaValue) OrElse hargaValue <= 0 Then
            MessageBox.Show("Harga harus berupa angka dan lebih besar dari 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Validasi bahwa stok hanya berupa angka dan tidak boleh 0
        Dim stokValue As Integer
        If Not Integer.TryParse(txtStok.Text, stokValue) OrElse stokValue <= 0 Then
            MessageBox.Show("Stok harus berupa angka bulat dan lebih besar dari 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Melanjutkan dengan operasi update jika semua validasi berhasil
        Dim [date] As Date = DateTimePicker1.Value
        Dim kategori As String = GetSelectedRadioButtonText()
        Dim id As String = selectedID ' Gunakan selectedID yang telah diset saat konstruksi Form3

        Try
            Module1.koneksi()
            Using command As New MySqlCommand("UPDATE tbform1 SET Brand = @Brand, Jenis = @Jenis, Shade = @Shade, Harga = @Harga,
            Tanggal = @Tanggal, Stok = @Stok, Kategori = @Kategori, Gambar = @Gambar, Deskripsi = @Deskripsi WHERE ID = @ID", Module1.CONN)
                command.Parameters.AddWithValue("@ID", id)
                command.Parameters.AddWithValue("@Brand", If(cbBrand.SelectedItem IsNot Nothing, cbBrand.SelectedItem.ToString(), ""))
                command.Parameters.AddWithValue("@Jenis", txtJenis.Text)
                command.Parameters.AddWithValue("@Shade", shadeValue)
                command.Parameters.AddWithValue("@Harga", hargaValue)
                command.Parameters.AddWithValue("@Tanggal", [date].ToString("yyyy-MM-dd"))
                command.Parameters.AddWithValue("@Stok", stokValue)

                command.Parameters.AddWithValue("@Kategori", kategori)
                ' Simpan gambar ke database
                Dim ms As New MemoryStream()
                PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
                Dim img As Byte() = ms.ToArray()
                command.Parameters.AddWithValue("@Gambar", img)

                command.Parameters.AddWithValue("@Deskripsi", RichTextBox1.Text)

                command.ExecuteNonQuery()
            End Using
            MessageBox.Show("Data Berhasil Diubah")
            ' Tutup Form3 setelah berhasil menyimpan data
            Me.Close()
            Form2.Show()
        Catch ex As Exception
            MessageBox.Show("Error updating data: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadbrandFromForm4()
        Try
            Module1.koneksi()
            Using cmd As New MySqlCommand("SELECT Brand FROM tbbrand", Module1.CONN)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    cbBrand.Items.Add(reader("Brand").ToString())
                End While
                reader.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
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

    Private Sub Input_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            btnSimpan.PerformClick()
        ElseIf e.KeyCode = Keys.Down Then
            SelectNextControl(ActiveControl, True, True, True, True)
        End If
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Hide()
        Form10.Show()
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Dim openFileDialog1 As New OpenFileDialog
        openFileDialog1.Filter = "Images|*.jpg;*.png;*.jpeg"
        If openFileDialog1.ShowDialog = DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(openFileDialog1.FileName)
        End If
    End Sub

End Class
