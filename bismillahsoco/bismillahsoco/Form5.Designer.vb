<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form5
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
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.txtPw = New System.Windows.Forms.TextBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.btnRegister = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'btnLogin
        '
        Me.btnLogin.BackColor = System.Drawing.Color.Transparent
        Me.btnLogin.BackgroundImage = Global.bismillahsoco.My.Resources.Resources.Desain_tanpa_judul__7_
        Me.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogin.ForeColor = System.Drawing.Color.Transparent
        Me.btnLogin.Location = New System.Drawing.Point(196, 409)
        Me.btnLogin.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(116, 21)
        Me.btnLogin.TabIndex = 11
        Me.btnLogin.UseVisualStyleBackColor = False
        '
        'txtPw
        '
        Me.txtPw.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.txtPw.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPw.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPw.Location = New System.Drawing.Point(192, 340)
        Me.txtPw.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtPw.Name = "txtPw"
        Me.txtPw.Size = New System.Drawing.Size(154, 17)
        Me.txtPw.TabIndex = 10
        '
        'txtUsername
        '
        Me.txtUsername.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUsername.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsername.Location = New System.Drawing.Point(192, 296)
        Me.txtUsername.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(154, 17)
        Me.txtUsername.TabIndex = 9
        '
        'btnRegister
        '
        Me.btnRegister.BackColor = System.Drawing.Color.Transparent
        Me.btnRegister.BackgroundImage = Global.bismillahsoco.My.Resources.Resources.Desain_tanpa_judul__8_
        Me.btnRegister.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRegister.ForeColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.btnRegister.Location = New System.Drawing.Point(274, 365)
        Me.btnRegister.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnRegister.Name = "btnRegister"
        Me.btnRegister.Size = New System.Drawing.Size(63, 23)
        Me.btnRegister.TabIndex = 14
        Me.btnRegister.UseVisualStyleBackColor = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBox1.Location = New System.Drawing.Point(358, 342)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(12, 11)
        Me.CheckBox1.TabIndex = 16
        Me.CheckBox1.UseVisualStyleBackColor = False
        '
        'Form5
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.bismillahsoco.My.Resources.Resources.Desain_tanpa_judul__5_
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(916, 570)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.btnRegister)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.txtPw)
        Me.Controls.Add(Me.txtUsername)
        Me.DoubleBuffered = True
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "Form5"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form5"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnLogin As Button
    Friend WithEvents txtPw As TextBox
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents btnRegister As Button
    Friend WithEvents CheckBox1 As CheckBox
End Class
