<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UserManagementForm
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
        lblHeader = New Label()
        dgvUsers = New DataGridView()
        lblFullName = New Label()
        lblUsername = New Label()
        lblPassword = New Label()
        lblRole = New Label()
        lblStatus = New Label()
        txtFullName = New TextBox()
        txtUsername = New TextBox()
        txtPassword = New TextBox()
        cboRole = New ComboBox()
        cboStatus = New ComboBox()
        btnAdd = New Button()
        btnUpdate = New Button()
        btnDelete = New Button()
        btnClear = New Button()
        btnResetPassword = New Button()
        lblSearch = New Label()
        txtSearch = New TextBox()
        CType(dgvUsers, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblHeader
        ' 
        lblHeader.AutoSize = True
        lblHeader.Font = New Font("Segoe UI", 13.0!, FontStyle.Bold, GraphicsUnit.Point)
        lblHeader.Location = New Point(18, 14)
        lblHeader.Name = "lblHeader"
        lblHeader.Size = New Size(160, 25)
        lblHeader.TabIndex = 0
        lblHeader.Text = "User Management"
        ' 
        ' dgvUsers
        ' 
        dgvUsers.AllowUserToAddRows = False
        dgvUsers.AllowUserToDeleteRows = False
        dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvUsers.BackgroundColor = Color.White
        dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvUsers.Location = New Point(18, 110)
        dgvUsers.MultiSelect = False
        dgvUsers.Name = "dgvUsers"
        dgvUsers.ReadOnly = True
        dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvUsers.Size = New Size(760, 200)
        dgvUsers.TabIndex = 1
        ' 
        ' lblFullName
        ' 
        lblFullName.AutoSize = True
        lblFullName.Location = New Point(18, 330)
        lblFullName.Name = "lblFullName"
        lblFullName.Size = New Size(58, 15)
        lblFullName.TabIndex = 2
        lblFullName.Text = "Full Name"
        ' 
        ' lblUsername
        ' 
        lblUsername.AutoSize = True
        lblUsername.Location = New Point(18, 366)
        lblUsername.Name = "lblUsername"
        lblUsername.Size = New Size(60, 15)
        lblUsername.TabIndex = 3
        lblUsername.Text = "Username"
        ' 
        ' lblPassword
        ' 
        lblPassword.AutoSize = True
        lblPassword.Location = New Point(18, 402)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(57, 15)
        lblPassword.TabIndex = 4
        lblPassword.Text = "Password"
        ' 
        ' lblRole
        ' 
        lblRole.AutoSize = True
        lblRole.Location = New Point(390, 330)
        lblRole.Name = "lblRole"
        lblRole.Size = New Size(30, 15)
        lblRole.TabIndex = 5
        lblRole.Text = "Role"
        ' 
        ' lblStatus
        ' 
        lblStatus.AutoSize = True
        lblStatus.Location = New Point(390, 366)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(39, 15)
        lblStatus.TabIndex = 6
        lblStatus.Text = "Status"
        ' 
        ' txtFullName
        ' 
        txtFullName.Location = New Point(120, 326)
        txtFullName.Name = "txtFullName"
        txtFullName.Size = New Size(250, 23)
        txtFullName.TabIndex = 7
        ' 
        ' txtUsername
        ' 
        txtUsername.Location = New Point(120, 362)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(250, 23)
        txtUsername.TabIndex = 8
        ' 
        ' txtPassword
        ' 
        txtPassword.Location = New Point(120, 398)
        txtPassword.Name = "txtPassword"
        txtPassword.PasswordChar = "*"c
        txtPassword.Size = New Size(250, 23)
        txtPassword.TabIndex = 9
        ' 
        ' cboRole
        ' 
        cboRole.DropDownStyle = ComboBoxStyle.DropDownList
        cboRole.FormattingEnabled = True
        cboRole.Items.AddRange(New Object() {"ADMIN", "MANAGER", "CLERK"})
        cboRole.Location = New Point(480, 326)
        cboRole.Name = "cboRole"
        cboRole.Size = New Size(150, 23)
        cboRole.TabIndex = 10
        ' 
        ' cboStatus
        ' 
        cboStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cboStatus.FormattingEnabled = True
        cboStatus.Items.AddRange(New Object() {"Active", "Inactive"})
        cboStatus.Location = New Point(480, 362)
        cboStatus.Name = "cboStatus"
        cboStatus.Size = New Size(150, 23)
        cboStatus.TabIndex = 11
        ' 
        ' btnAdd
        ' 
        btnAdd.BackColor = Color.FromArgb(40, 167, 69)
        btnAdd.FlatStyle = FlatStyle.Flat
        btnAdd.ForeColor = Color.White
        btnAdd.Location = New Point(120, 440)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(100, 34)
        btnAdd.TabIndex = 12
        btnAdd.Text = "Add User"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' btnUpdate
        ' 
        btnUpdate.BackColor = Color.FromArgb(0, 123, 255)
        btnUpdate.FlatStyle = FlatStyle.Flat
        btnUpdate.ForeColor = Color.White
        btnUpdate.Location = New Point(230, 440)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(100, 34)
        btnUpdate.TabIndex = 13
        btnUpdate.Text = "Update"
        btnUpdate.UseVisualStyleBackColor = False
        ' 
        ' btnDelete
        ' 
        btnDelete.BackColor = Color.FromArgb(220, 53, 69)
        btnDelete.FlatStyle = FlatStyle.Flat
        btnDelete.ForeColor = Color.White
        btnDelete.Location = New Point(340, 440)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(100, 34)
        btnDelete.TabIndex = 14
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = False
        ' 
        ' btnClear
        ' 
        btnClear.BackColor = Color.FromArgb(108, 117, 125)
        btnClear.FlatStyle = FlatStyle.Flat
        btnClear.ForeColor = Color.White
        btnClear.Location = New Point(450, 440)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(100, 34)
        btnClear.TabIndex = 15
        btnClear.Text = "Clear"
        btnClear.UseVisualStyleBackColor = False
        ' 
        ' btnResetPassword
        ' 
        btnResetPassword.BackColor = Color.FromArgb(255, 193, 7)
        btnResetPassword.FlatStyle = FlatStyle.Flat
        btnResetPassword.ForeColor = Color.Black
        btnResetPassword.Location = New Point(560, 440)
        btnResetPassword.Name = "btnResetPassword"
        btnResetPassword.Size = New Size(130, 34)
        btnResetPassword.TabIndex = 16
        btnResetPassword.Text = "Reset Password"
        btnResetPassword.UseVisualStyleBackColor = False
        ' 
        ' lblSearch
        ' 
        lblSearch.AutoSize = True
        lblSearch.Location = New Point(18, 82)
        lblSearch.Name = "lblSearch"
        lblSearch.Size = New Size(46, 15)
        lblSearch.TabIndex = 17
        lblSearch.Text = "Search:"
        ' 
        ' txtSearch
        ' 
        txtSearch.Location = New Point(78, 78)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(300, 23)
        txtSearch.TabIndex = 18
        ' 
        ' UserManagementForm
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 500)
        Controls.Add(txtSearch)
        Controls.Add(lblSearch)
        Controls.Add(btnResetPassword)
        Controls.Add(btnClear)
        Controls.Add(btnDelete)
        Controls.Add(btnUpdate)
        Controls.Add(btnAdd)
        Controls.Add(cboStatus)
        Controls.Add(cboRole)
        Controls.Add(txtPassword)
        Controls.Add(txtUsername)
        Controls.Add(txtFullName)
        Controls.Add(lblStatus)
        Controls.Add(lblRole)
        Controls.Add(lblPassword)
        Controls.Add(lblUsername)
        Controls.Add(lblFullName)
        Controls.Add(dgvUsers)
        Controls.Add(lblHeader)
        Name = "UserManagementForm"
        StartPosition = FormStartPosition.CenterParent
        Text = "User Management"
        CType(dgvUsers, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblHeader As Label
    Friend WithEvents dgvUsers As DataGridView
    Friend WithEvents lblFullName As Label
    Friend WithEvents lblUsername As Label
    Friend WithEvents lblPassword As Label
    Friend WithEvents lblRole As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents txtFullName As TextBox
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents cboRole As ComboBox
    Friend WithEvents cboStatus As ComboBox
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnResetPassword As Button
    Friend WithEvents lblSearch As Label
    Friend WithEvents txtSearch As TextBox
End Class