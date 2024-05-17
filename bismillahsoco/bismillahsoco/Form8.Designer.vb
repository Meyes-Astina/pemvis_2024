<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form8
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btnWishlist = New System.Windows.Forms.Button()
        Me.btnKembali = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.GridColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.DataGridView1.Location = New System.Drawing.Point(64, 128)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(916, 385)
        Me.DataGridView1.TabIndex = 0
        '
        'btnWishlist
        '
        Me.btnWishlist.BackColor = System.Drawing.Color.Transparent
        Me.btnWishlist.BackgroundImage = Global.bismillahsoco.My.Resources.Resources.wishlist
        Me.btnWishlist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnWishlist.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWishlist.ForeColor = System.Drawing.Color.Transparent
        Me.btnWishlist.Location = New System.Drawing.Point(867, 551)
        Me.btnWishlist.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnWishlist.Name = "btnWishlist"
        Me.btnWishlist.Size = New System.Drawing.Size(31, 43)
        Me.btnWishlist.TabIndex = 1
        Me.btnWishlist.UseVisualStyleBackColor = False
        '
        'btnKembali
        '
        Me.btnKembali.BackColor = System.Drawing.Color.Transparent
        Me.btnKembali.BackgroundImage = Global.bismillahsoco.My.Resources.Resources.kembali
        Me.btnKembali.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnKembali.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnKembali.ForeColor = System.Drawing.Color.Transparent
        Me.btnKembali.Location = New System.Drawing.Point(948, 551)
        Me.btnKembali.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnKembali.Name = "btnKembali"
        Me.btnKembali.Size = New System.Drawing.Size(43, 37)
        Me.btnKembali.TabIndex = 4
        Me.btnKembali.UseVisualStyleBackColor = False
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.Transparent
        Me.btnSearch.BackgroundImage = Global.bismillahsoco.My.Resources.Resources.blacksearch
        Me.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.ForeColor = System.Drawing.Color.Transparent
        Me.btnSearch.Location = New System.Drawing.Point(941, 39)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(49, 36)
        Me.btnSearch.TabIndex = 7
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'txtSearch
        '
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSearch.Location = New System.Drawing.Point(139, 49)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(805, 15)
        Me.txtSearch.TabIndex = 6
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = Global.bismillahsoco.My.Resources.Resources.sebelumnya
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.Transparent
        Me.Button1.Location = New System.Drawing.Point(60, 39)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(43, 37)
        Me.Button1.TabIndex = 8
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Form8
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.bismillahsoco.My.Resources.Resources.Background2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1052, 609)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.btnKembali)
        Me.Controls.Add(Me.btnWishlist)
        Me.Controls.Add(Me.DataGridView1)
        Me.DoubleBuffered = True
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Form8"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form8"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btnWishlist As Button
    Friend WithEvents btnKembali As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Button1 As Button
End Class
