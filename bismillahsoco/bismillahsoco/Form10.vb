Imports System.Drawing.Printing
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Tab
Imports MySql.Data.MySqlClient
Imports System.IO

Public Class Form10
    Dim pageWidth As Integer = 827
    Dim pageHeight As Integer = 1169
    Dim listmakeup As New List(Of List(Of String))()
    Dim currentPage, totalPage, totalItem, marginPixels, y, x, marginRight As Integer

    Private Sub Form10_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Module1.koneksi()
    End Sub

    Private Sub cetakdata_Click(sender As Object, e As EventArgs) Handles cetakdata.Click
        readdatamakeup()
        currentPage = 1
        PrintDataMakeup.Print()
    End Sub

    Private Sub laporansoco_Click(sender As Object, e As EventArgs) Handles laporansoco.Click
        readdatamakeup()
        currentPage = 1
        PrintPreviewDialog1.Document = PrintDataMakeup
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Me.Close()
        Form5.Show()
    End Sub

    Public Property loggedInid As String

    Private Sub TambahBrandMakeUpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TambahBrandMakeUpToolStripMenuItem.Click
        Me.Hide()
        Form4.Show()
    End Sub

    Private Sub KeluarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles KeluarToolStripMenuItem1.Click
        End
    End Sub

    Private Sub TambahDataMakeUpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TambahDataMakeUpToolStripMenuItem.Click
        Me.Hide()
        Dim dataForm As New Form2() ' Create an instance of Form2
        dataForm.Show() ' Show the instance of Form2
    End Sub

    Private Sub readdatamakeup()
        Module1.CMD = New MySqlCommand("SELECT ID, Brand, Jenis, Shade, Harga, Kategori, Gambar, Deskripsi FROM tbform1 ORDER BY ID", Module1.CONN)
        Module1.RD = CMD.ExecuteReader
        totalItem = 0
        listmakeup.Clear() ' Clear the list before populating

        Do While RD.Read
            Dim form2 As New List(Of String)()
            form2.Add(RD("ID").ToString)
            form2.Add(RD("Brand").ToString)
            form2.Add(RD("Jenis").ToString)
            form2.Add(RD("Shade").ToString)
            form2.Add(RD("Harga").ToString)
            form2.Add(RD("Kategori").ToString)

            ' Read the image data as byte array (BLOB)
            Dim imageData() As Byte = If(Not IsDBNull(RD("Gambar")), CType(RD("Gambar"), Byte()), Nothing)
            Dim imageDataString As String = If(imageData IsNot Nothing, Convert.ToBase64String(imageData), "")
            form2.Add(imageDataString)
            form2.Add(RD("Deskripsi").ToString)
            listmakeup.Add(form2)
            totalItem += 1
        Loop
        totalPage = Math.Ceiling(totalItem / 3)
        RD.Close()
    End Sub

    Private Sub PrintDataMakeup_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDataMakeup.PrintPage
        Dim Fheader As New Font("Times New Roman", 24, FontStyle.Bold) ' Font for header
        Dim FBodyB As New Font("Times New Roman", 14, FontStyle.Bold) ' Font for body (bold)
        Dim FBody As New Font("Times New Roman", 14, FontStyle.Regular) ' Font for body (regular)
        Dim black As New SolidBrush(Color.Black) ' Text color

        ' Alignment
        Dim center As New StringFormat() With {.Alignment = StringAlignment.Center}
        Dim posY, i As Integer
        Dim hitung As Integer = 0

        If currentPage <= 1 Then
            Dim marginInch As Single = 1.5F ' Margin 1 inch/2.54 cm
            marginPixels = CInt(e.PageSettings.PrinterResolution.X * marginInch) ' Convert margin to pixels
            e.PageSettings.Margins = New Margins(marginPixels, marginPixels, marginPixels, marginPixels) ' Initialize margin
            ' Initial coordinates
            x = e.MarginBounds.Left
            y = e.MarginBounds.Top
            marginRight = e.MarginBounds.Right
            ' Title
            e.Graphics.DrawString("Data Make Up", Fheader, black, pageWidth / 2, y, center)
            posY = y + 70
        Else
            posY = y
        End If

        e.Graphics.DrawLine(Pens.Black, x, posY, marginRight, posY)
        For i = (currentPage - 1) * 3 To totalItem - 1
            e.Graphics.DrawString("id", FBody, black, x + 20, posY + 30)
            e.Graphics.DrawString(": " & listmakeup(i)(0), FBody, black, x + 200, posY + 30)
            e.Graphics.DrawString("brand", FBody, black, x + 20, posY + 60)
            e.Graphics.DrawString(": " & listmakeup(i)(1), FBody, black, x + 200, posY + 60)
            e.Graphics.DrawString("Jenis", FBody, black, x + 20, posY + 90)
            e.Graphics.DrawString(": " & listmakeup(i)(2), FBody, black, x + 200, posY + 90)
            e.Graphics.DrawString("shade", FBody, black, x + 20, posY + 120)
            e.Graphics.DrawString(": " & listmakeup(i)(3), FBody, black, x + 200, posY + 120)
            e.Graphics.DrawString("harga", FBody, black, x + 20, posY + 150)
            e.Graphics.DrawString(": " & listmakeup(i)(4), FBody, black, x + 200, posY + 150)
            e.Graphics.DrawString("kategori", FBody, black, x + 20, posY + 180
)
            e.Graphics.DrawString(": " & listmakeup(i)(5), FBody, black, x + 200, posY + 180)

            ' Drawing the image
            Dim imageDataString As String = listmakeup(i)(6)
            If Not String.IsNullOrEmpty(imageDataString) Then
                Try
                    ' Log the image data string
                    Debug.WriteLine("Image data string: " & imageDataString)

                    Dim imageData As Byte() = Convert.FromBase64String(imageDataString)

                    ' Log the image data length
                    Debug.WriteLine("Image data length: " & imageData.Length)

                    ' Check if the image size is greater than 1MB
                    If imageData.Length > 1048576 Then ' 1MB = 1024 * 1024 bytes
                        e.Graphics.DrawString("Image size exceeds 1MB", FBody, black, x + 200, posY + 210)
                    Else
                        Using ms As New MemoryStream(imageData)
                            Using img As Image = Image.FromStream(ms)
                                ' Calculate the target dimensions while maintaining aspect ratio
                                Dim targetWidth As Integer = 100
                                Dim targetHeight As Integer = 100
                                Dim aspectRatio As Double = CDbl(img.Width) / img.Height

                                If img.Width > img.Height Then
                                    targetHeight = CInt(targetWidth / aspectRatio)
                                Else
                                    targetWidth = CInt(targetHeight * aspectRatio)
                                End If

                                ' Calculate the position for the image
                                Dim imagePosX As Integer = marginRight - targetWidth - 20 ' Adjusted position from the right edge
                                Dim imagePosY As Integer = posY + 100 ' Fixed position for image Y

                                e.Graphics.DrawImage(img, imagePosX, imagePosY, targetWidth, targetHeight)
                            End Using
                        End Using
                    End If
                Catch ex As Exception
                    ' Handle the exception if the image cannot be converted or loaded
                    e.Graphics.DrawString("Image load error", FBody, black, x + 200, posY + 210)
                    ' Log the exception message
                    Debug.WriteLine("Exception: " & ex.Message)
                End Try
            End If

            e.Graphics.DrawString("Deskripsi", FBody, black, x + 20, posY + 220)
            e.Graphics.DrawString(": " & listmakeup(i)(7), FBody, black, x + 200, posY + 220)
            e.Graphics.DrawLine(Pens.Black, x, posY + 280, marginRight, posY + 280)

            posY += 300
            hitung += 1
            If hitung >= 3 Then
                Exit For
            End If
        Next

        If currentPage <= 1 Then
            e.Graphics.DrawLine(Pens.Black, x, y + 70, x, posY + 10)
            e.Graphics.DrawLine(Pens.Black, marginRight, y + 70, marginRight, posY + 10)
        Else
            e.Graphics.DrawLine(Pens.Black, x, y, x, posY + 10)
            e.Graphics.DrawLine(Pens.Black, marginRight, y, marginRight, posY + 10)
        End If
        currentPage += 1
        e.HasMorePages = currentPage <= totalPage
    End Sub

End Class
