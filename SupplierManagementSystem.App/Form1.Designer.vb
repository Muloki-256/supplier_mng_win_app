<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        pnlLeft = New Panel()
        lblCompanyName = New Label()
        picLogo = New PictureBox()
        pnlRight = New Panel()
        btnExit = New Button()
        btnLogin = New Button()
        txtPassword = New TextBox()
        txtUsername = New TextBox()
        lblPassword = New Label()
        lblUsername = New Label()
        lblSubtitle = New Label()
        lblAppTitle = New Label()
        pnlLeft.SuspendLayout()
        CType(picLogo, ComponentModel.ISupportInitialize).BeginInit()
        pnlRight.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlLeft
        ' 
        pnlLeft.BackColor = Color.FromArgb(CByte(40), CByte(167), CByte(69))
        pnlLeft.Controls.Add(lblCompanyName)
        pnlLeft.Controls.Add(picLogo)
        pnlLeft.Dock = DockStyle.Left
        pnlLeft.Location = New Point(0, 0)
        pnlLeft.Name = "pnlLeft"
        pnlLeft.Size = New Size(380, 500)
        pnlLeft.TabIndex = 0
        ' 
        ' lblCompanyName
        ' 
        lblCompanyName.Font = New Font("Segoe UI", 16F, FontStyle.Bold)
        lblCompanyName.ForeColor = Color.White
        lblCompanyName.Location = New Point(40, 300)
        lblCompanyName.Name = "lblCompanyName"
        lblCompanyName.Size = New Size(300, 40)
        lblCompanyName.TabIndex = 1
        lblCompanyName.Text = "MASAKA AGRI-SUPPLIES"
        lblCompanyName.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' picLogo
        ' 
        picLogo.BackColor = Color.FromArgb(CByte(40), CByte(167), CByte(69))
        picLogo.Image = CType(resources.GetObject("picLogo.Image"), Image)
        picLogo.Location = New Point(90, 130)
        picLogo.Name = "picLogo"
        picLogo.Size = New Size(200, 160)
        picLogo.SizeMode = PictureBoxSizeMode.StretchImage
        picLogo.TabIndex = 0
        picLogo.TabStop = False
        ' 
        ' pnlRight
        ' 
        pnlRight.BackColor = Color.White
        pnlRight.Controls.Add(btnExit)
        pnlRight.Controls.Add(btnLogin)
        pnlRight.Controls.Add(txtPassword)
        pnlRight.Controls.Add(txtUsername)
        pnlRight.Controls.Add(lblPassword)
        pnlRight.Controls.Add(lblUsername)
        pnlRight.Controls.Add(lblSubtitle)
        pnlRight.Controls.Add(lblAppTitle)
        pnlRight.Dock = DockStyle.Fill
        pnlRight.Location = New Point(380, 0)
        pnlRight.Name = "pnlRight"
        pnlRight.Padding = New Padding(50, 60, 50, 40)
        pnlRight.Size = New Size(500, 500)
        pnlRight.TabIndex = 1
        ' 
        ' btnExit
        ' 
        btnExit.BackColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        btnExit.FlatStyle = FlatStyle.Flat
        btnExit.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        btnExit.ForeColor = Color.White
        btnExit.Location = New Point(260, 260)
        btnExit.Name = "btnExit"
        btnExit.Size = New Size(190, 45)
        btnExit.TabIndex = 7
        btnExit.Text = "EXIT"
        btnExit.UseVisualStyleBackColor = False
        ' 
        ' btnLogin
        ' 
        btnLogin.BackColor = Color.FromArgb(CByte(40), CByte(167), CByte(69))
        btnLogin.FlatStyle = FlatStyle.Flat
        btnLogin.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        btnLogin.ForeColor = Color.White
        btnLogin.Location = New Point(50, 260)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(190, 45)
        btnLogin.TabIndex = 6
        btnLogin.Text = "LOGIN"
        btnLogin.UseVisualStyleBackColor = False
        ' 
        ' txtPassword
        ' 
        txtPassword.Font = New Font("Segoe UI", 11F)
        txtPassword.Location = New Point(50, 205)
        txtPassword.Name = "txtPassword"
        txtPassword.PasswordChar = "●"c
        txtPassword.Size = New Size(400, 27)
        txtPassword.TabIndex = 5
        ' 
        ' txtUsername
        ' 
        txtUsername.Font = New Font("Segoe UI", 11F)
        txtUsername.Location = New Point(50, 135)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(400, 27)
        txtUsername.TabIndex = 3
        ' 
        ' lblPassword
        ' 
        lblPassword.AutoSize = True
        lblPassword.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblPassword.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        lblPassword.Location = New Point(50, 180)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(73, 19)
        lblPassword.TabIndex = 4
        lblPassword.Text = "Password"
        ' 
        ' lblUsername
        ' 
        lblUsername.AutoSize = True
        lblUsername.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblUsername.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        lblUsername.Location = New Point(50, 110)
        lblUsername.Name = "lblUsername"
        lblUsername.Size = New Size(76, 19)
        lblUsername.TabIndex = 2
        lblUsername.Text = "Username"
        ' 
        ' lblSubtitle
        ' 
        lblSubtitle.Font = New Font("Segoe UI", 11F)
        lblSubtitle.ForeColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        lblSubtitle.Location = New Point(50, 45)
        lblSubtitle.Name = "lblSubtitle"
        lblSubtitle.Size = New Size(400, 30)
        lblSubtitle.TabIndex = 1
        lblSubtitle.Text = "Sign in to access your dashboard"
        lblSubtitle.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblAppTitle
        ' 
        lblAppTitle.Font = New Font("Segoe UI", 18F, FontStyle.Bold)
        lblAppTitle.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        lblAppTitle.Location = New Point(50, 0)
        lblAppTitle.Name = "lblAppTitle"
        lblAppTitle.Size = New Size(400, 45)
        lblAppTitle.TabIndex = 0
        lblAppTitle.Text = "Supplier Management System"
        lblAppTitle.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(880, 500)
        Controls.Add(pnlRight)
        Controls.Add(pnlLeft)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "MASAKA AGRI-SUPPLIES LTD - Login"
        pnlLeft.ResumeLayout(False)
        CType(picLogo, ComponentModel.ISupportInitialize).EndInit()
        pnlRight.ResumeLayout(False)
        pnlRight.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlLeft As Panel
    Friend WithEvents picLogo As PictureBox
    Friend WithEvents lblCompanyName As Label
    Friend WithEvents pnlRight As Panel
    Friend WithEvents btnExit As Button
    Friend WithEvents btnLogin As Button
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents lblPassword As Label
    Friend WithEvents lblUsername As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents lblAppTitle As Label
End Class