<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form10
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form10))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.DataMakeUpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TambahBrandMakeUpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TambahDataMakeUpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KeluarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.laporansoco = New System.Windows.Forms.ToolStripMenuItem()
        Me.cetakdata = New System.Windows.Forms.ToolStripMenuItem()
        Me.KeluarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintDataMakeup = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.btnKeluar = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.MenuStrip1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DataMakeUpToolStripMenuItem, Me.KeluarToolStripMenuItem, Me.KeluarToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(3, 2)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1046, 31)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'DataMakeUpToolStripMenuItem
        '
        Me.DataMakeUpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TambahBrandMakeUpToolStripMenuItem, Me.TambahDataMakeUpToolStripMenuItem})
        Me.DataMakeUpToolStripMenuItem.Name = "DataMakeUpToolStripMenuItem"
        Me.DataMakeUpToolStripMenuItem.Size = New System.Drawing.Size(118, 24)
        Me.DataMakeUpToolStripMenuItem.Text = "Data Make Up"
        '
        'TambahBrandMakeUpToolStripMenuItem
        '
        Me.TambahBrandMakeUpToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.TambahBrandMakeUpToolStripMenuItem.Name = "TambahBrandMakeUpToolStripMenuItem"
        Me.TambahBrandMakeUpToolStripMenuItem.Size = New System.Drawing.Size(250, 26)
        Me.TambahBrandMakeUpToolStripMenuItem.Text = "Tambah Brand Make Up"
        '
        'TambahDataMakeUpToolStripMenuItem
        '
        Me.TambahDataMakeUpToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.TambahDataMakeUpToolStripMenuItem.Name = "TambahDataMakeUpToolStripMenuItem"
        Me.TambahDataMakeUpToolStripMenuItem.Size = New System.Drawing.Size(250, 26)
        Me.TambahDataMakeUpToolStripMenuItem.Text = "Tambah  Data Make Up"
        '
        'KeluarToolStripMenuItem
        '
        Me.KeluarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.laporansoco, Me.cetakdata})
        Me.KeluarToolStripMenuItem.Name = "KeluarToolStripMenuItem"
        Me.KeluarToolStripMenuItem.Size = New System.Drawing.Size(89, 24)
        Me.KeluarToolStripMenuItem.Text = "Print Data"
        '
        'laporansoco
        '
        Me.laporansoco.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.laporansoco.Name = "laporansoco"
        Me.laporansoco.Size = New System.Drawing.Size(224, 26)
        Me.laporansoco.Text = "Data Makeup"
        '
        'cetakdata
        '
        Me.cetakdata.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.cetakdata.Name = "cetakdata"
        Me.cetakdata.Size = New System.Drawing.Size(224, 26)
        Me.cetakdata.Text = "Cetak Data Makeup"
        '
        'KeluarToolStripMenuItem1
        '
        Me.KeluarToolStripMenuItem1.Name = "KeluarToolStripMenuItem1"
        Me.KeluarToolStripMenuItem1.Size = New System.Drawing.Size(65, 24)
        Me.KeluarToolStripMenuItem1.Text = "Keluar"
        '
        'PrintDataMakeup
        '
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'btnKeluar
        '
        Me.btnKeluar.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.btnKeluar.BackgroundImage = Global.bismillahsoco.My.Resources.Resources.Desain_tanpa_judul__22_
        Me.btnKeluar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnKeluar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnKeluar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.btnKeluar.Location = New System.Drawing.Point(999, 2)
        Me.btnKeluar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnKeluar.Name = "btnKeluar"
        Me.btnKeluar.Size = New System.Drawing.Size(43, 28)
        Me.btnKeluar.TabIndex = 1
        Me.btnKeluar.UseVisualStyleBackColor = False
        '
        'Form10
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.bismillahsoco.My.Resources.Resources.background5
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1052, 609)
        Me.Controls.Add(Me.btnKeluar)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.Color.DeepPink
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Form10"
        Me.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form10"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents DataMakeUpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TambahBrandMakeUpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TambahDataMakeUpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents KeluarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents KeluarToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents PrintDataMakeup As Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents laporansoco As ToolStripMenuItem
    Friend WithEvents cetakdata As ToolStripMenuItem
    Friend WithEvents btnKeluar As Button
End Class
