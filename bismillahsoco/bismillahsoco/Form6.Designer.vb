<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form6
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
        Me.btnRegis = New System.Windows.Forms.Button()
        Me.txtPw = New System.Windows.Forms.TextBox()
        Me.btnkembali = New System.Windows.Forms.Button()
        Me.txtusername = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnRegis
        '
        Me.btnRegis.BackColor = System.Drawing.Color.Transparent
        Me.btnRegis.BackgroundImage = Global.bismillahsoco.My.Resources.Resources.REGISTER
        Me.btnRegis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnRegis.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRegis.ForeColor = System.Drawing.Color.Transparent
        Me.btnRegis.Location = New System.Drawing.Point(198, 408)
        Me.btnRegis.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnRegis.Name = "btnRegis"
        Me.btnRegis.Size = New System.Drawing.Size(113, 24)
        Me.btnRegis.TabIndex = 11
        Me.btnRegis.UseVisualStyleBackColor = False
        '
        'txtPw
        '
        Me.txtPw.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.txtPw.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPw.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPw.Location = New System.Drawing.Point(190, 340)
        Me.txtPw.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtPw.Name = "txtPw"
        Me.txtPw.Size = New System.Drawing.Size(154, 17)
        Me.txtPw.TabIndex = 10
        '
        'btnkembali
        '
        Me.btnkembali.BackColor = System.Drawing.Color.Transparent
        Me.btnkembali.BackgroundImage = Global.bismillahsoco.My.Resources.Resources.REGISTER__1_
        Me.btnkembali.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnkembali.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnkembali.ForeColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.btnkembali.Location = New System.Drawing.Point(262, 365)
        Me.btnkembali.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnkembali.Name = "btnkembali"
        Me.btnkembali.Size = New System.Drawing.Size(63, 23)
        Me.btnkembali.TabIndex = 14
        Me.btnkembali.UseVisualStyleBackColor = False
        '
        'txtusername
        '
        Me.txtusername.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.txtusername.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtusername.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtusername.Location = New System.Drawing.Point(190, 296)
        Me.txtusername.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtusername.Name = "txtusername"
        Me.txtusername.Size = New System.Drawing.Size(154, 17)
        Me.txtusername.TabIndex = 16
        '
        'Form6
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.bismillahsoco.My.Resources.Resources.Desain_tanpa_judul__6_
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(916, 570)
        Me.Controls.Add(Me.txtusername)
        Me.Controls.Add(Me.btnkembali)
        Me.Controls.Add(Me.btnRegis)
        Me.Controls.Add(Me.txtPw)
        Me.DoubleBuffered = True
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "Form6"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form6"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnRegis As Button
    Friend WithEvents txtPw As TextBox
    Friend WithEvents btnkembali As Button
    Friend WithEvents txtusername As TextBox
End Class
