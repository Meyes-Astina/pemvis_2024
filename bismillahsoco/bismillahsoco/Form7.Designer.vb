<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form7
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnlihat = New System.Windows.Forms.Button()
        Me.btnWishlist = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnlihat
        '
        Me.btnlihat.BackColor = System.Drawing.Color.Transparent
        Me.btnlihat.BackgroundImage = Global.bismillahsoco.My.Resources.Resources.Desain_tanpa_judul__23_
        Me.btnlihat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnlihat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnlihat.ForeColor = System.Drawing.Color.Transparent
        Me.btnlihat.Location = New System.Drawing.Point(309, 260)
        Me.btnlihat.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnlihat.Name = "btnlihat"
        Me.btnlihat.Size = New System.Drawing.Size(215, 213)
        Me.btnlihat.TabIndex = 0
        Me.btnlihat.UseVisualStyleBackColor = False
        '
        'btnWishlist
        '
        Me.btnWishlist.BackColor = System.Drawing.Color.Transparent
        Me.btnWishlist.BackgroundImage = Global.bismillahsoco.My.Resources.Resources.Desain_tanpa_judul__24_
        Me.btnWishlist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnWishlist.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWishlist.ForeColor = System.Drawing.Color.Transparent
        Me.btnWishlist.Location = New System.Drawing.Point(704, 260)
        Me.btnWishlist.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnWishlist.Name = "btnWishlist"
        Me.btnWishlist.Size = New System.Drawing.Size(215, 213)
        Me.btnWishlist.TabIndex = 1
        Me.btnWishlist.UseVisualStyleBackColor = False
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.Transparent
        Me.btnBack.BackgroundImage = Global.bismillahsoco.My.Resources.Resources.Desain_tanpa_judul__22_
        Me.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBack.ForeColor = System.Drawing.Color.Transparent
        Me.btnBack.Location = New System.Drawing.Point(1116, 2)
        Me.btnBack.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(83, 76)
        Me.btnBack.TabIndex = 2
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(119, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(362, 489)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 34)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Produk"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(119, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(758, 489)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 34)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Wishlist"
        '
        'Form7
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.bismillahsoco.My.Resources.Resources.Desain_tanpa_judul__21_
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1224, 702)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnWishlist)
        Me.Controls.Add(Me.btnlihat)
        Me.DoubleBuffered = True
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Form7"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form7"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnlihat As Button
    Friend WithEvents btnWishlist As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
