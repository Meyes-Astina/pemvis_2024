<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form9
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
        Me.btnKembali = New System.Windows.Forms.Button()
        Me.btnHapus = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.GridColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.DataGridView1.Location = New System.Drawing.Point(77, 64)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(895, 442)
        Me.DataGridView1.TabIndex = 0
        '
        'btnKembali
        '
        Me.btnKembali.BackColor = System.Drawing.Color.Transparent
        Me.btnKembali.BackgroundImage = Global.bismillahsoco.My.Resources.Resources.kembali
        Me.btnKembali.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnKembali.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnKembali.ForeColor = System.Drawing.Color.Transparent
        Me.btnKembali.Location = New System.Drawing.Point(945, 550)
        Me.btnKembali.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnKembali.Name = "btnKembali"
        Me.btnKembali.Size = New System.Drawing.Size(44, 38)
        Me.btnKembali.TabIndex = 1
        Me.btnKembali.UseVisualStyleBackColor = False
        '
        'btnHapus
        '
        Me.btnHapus.BackColor = System.Drawing.Color.Transparent
        Me.btnHapus.BackgroundImage = Global.bismillahsoco.My.Resources.Resources.hapus
        Me.btnHapus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnHapus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHapus.ForeColor = System.Drawing.Color.Transparent
        Me.btnHapus.Location = New System.Drawing.Point(860, 551)
        Me.btnHapus.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnHapus.Name = "btnHapus"
        Me.btnHapus.Size = New System.Drawing.Size(37, 38)
        Me.btnHapus.TabIndex = 2
        Me.btnHapus.UseVisualStyleBackColor = False
        '
        'Form9
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.bismillahsoco.My.Resources.Resources.Background4
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1049, 608)
        Me.Controls.Add(Me.btnHapus)
        Me.Controls.Add(Me.btnKembali)
        Me.Controls.Add(Me.DataGridView1)
        Me.DoubleBuffered = True
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Form9"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form9"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btnKembali As Button
    Friend WithEvents btnHapus As Button
End Class
