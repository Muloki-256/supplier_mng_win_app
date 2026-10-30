Imports MySql.Data.MySqlClient

Public Class UserManagementForm
    Private selectedUserId As Integer = -1
    Private userTable As DataTable
    Private currentUserRole As String = ""
    Private activationSyncCount As Integer

    Public Sub New(Optional userRole As String = "ADMIN")
        InitializeComponent()
        currentUserRole = userRole
    End Sub

    Private Sub UserManagementForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If DesignMode Then
            Return
        End If

        If Not String.Equals(currentUserRole, "ADMIN", StringComparison.OrdinalIgnoreCase) Then
            MessageBox.Show("Access Denied. Only Administrators can access User Management.", "Access Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Close()
            Return
        End If

        UiBranding.ApplyModuleHeader(Me, "User Management")
        LoadUsers()
        cboRole.SelectedIndex = 0
        cboStatus.SelectedIndex = 0
    End Sub

    Private Sub UserManagementForm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        If DesignMode Then
            Return
        End If

        activationSyncCount += 1
        If activationSyncCount = 1 Then
            Return
        End If

        Dim savedId As Integer = selectedUserId
        LoadUsers()
        If savedId > 0 Then
            RestoreUserRow(savedId)
        End If
    End Sub

    Private Sub RestoreUserRow(userId As Integer)
        For Each r As DataGridViewRow In dgvUsers.Rows
            If r.IsNewRow Then
                Continue For
            End If

            If Convert.ToInt32(r.Cells("user_id").Value) = userId Then
                dgvUsers_CellClick(dgvUsers, New DataGridViewCellEventArgs(0, r.Index))
                Return
            End If
        Next
    End Sub

    Private Sub LoadUsers()
        Try
            Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                Dim query As String = "SELECT user_id, full_name, username, role, is_active FROM users ORDER BY user_id DESC"
                Using adapter As New MySqlDataAdapter(query, conn)
                    userTable = New DataTable()
                    adapter.Fill(userTable)
                    dgvUsers.DataSource = userTable
                    dgvUsers.Columns("user_id").Visible = False
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Failed to load users: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function IsValidInput() As Boolean
        If txtFullName.Text.Trim() = "" Then
            MessageBox.Show("Full name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If txtUsername.Text.Trim() = "" Then
            MessageBox.Show("Username is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If selectedUserId = -1 AndAlso txtPassword.Text.Trim() = "" Then
            MessageBox.Show("Password is required for new users.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If currentUserRole <> "ADMIN" Then
            MessageBox.Show("Access Denied.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If Not IsValidInput() Then
            Return
        End If

        Try
            Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                Dim query As String = "INSERT INTO users (full_name, username, password_hash, role, is_active) VALUES (@name, @user, @pass, @role, @active)"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@name", txtFullName.Text.Trim())
                    cmd.Parameters.AddWithValue("@user", txtUsername.Text.Trim())
                    cmd.Parameters.AddWithValue("@pass", txtPassword.Text.Trim())
                    cmd.Parameters.AddWithValue("@role", cboRole.Text)
                    cmd.Parameters.AddWithValue("@active", If(cboStatus.Text = "Active", 1, 0))
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("User added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearInputs()
            LoadUsers()
        Catch ex As MySqlException
            If ex.Number = 1062 Then
                MessageBox.Show("Username already exists. Please choose another.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show($"Failed to add user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show($"Failed to add user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If currentUserRole <> "ADMIN" Then
            MessageBox.Show("Access Denied.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If selectedUserId = -1 Then
            MessageBox.Show("Select a user to update.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not IsValidInput() Then
            Return
        End If

        Try
            Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                Dim newPassword As String = txtPassword.Text.Trim()
                Dim query As String =
                    "UPDATE users SET full_name = @name, username = @user, role = @role, is_active = @active" &
                    If(newPassword <> "", ", password_hash = @pass", "") &
                    " WHERE user_id = @id"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@name", txtFullName.Text.Trim())
                    cmd.Parameters.AddWithValue("@user", txtUsername.Text.Trim())
                    cmd.Parameters.AddWithValue("@role", cboRole.Text)
                    cmd.Parameters.AddWithValue("@active", If(cboStatus.Text = "Active", 1, 0))
                    cmd.Parameters.AddWithValue("@id", selectedUserId)
                    If newPassword <> "" Then
                        cmd.Parameters.AddWithValue("@pass", newPassword)
                    End If
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("User updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearInputs()
            LoadUsers()
        Catch ex As Exception
            MessageBox.Show($"Failed to update user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If currentUserRole <> "ADMIN" Then
            MessageBox.Show("Access Denied.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If selectedUserId = -1 Then
            MessageBox.Show("Select a user to delete.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Prevent deleting the main admin account (ID 1)
        If selectedUserId = 1 Then
            MessageBox.Show("Cannot delete the main administrator account.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim confirmResult As DialogResult = MessageBox.Show("Delete selected user?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirmResult <> DialogResult.Yes Then
            Return
        End If

        Try
            Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                Dim query As String = "DELETE FROM users WHERE user_id = @id"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", selectedUserId)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("User deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearInputs()
            LoadUsers()
        Catch ex As Exception
            MessageBox.Show($"Failed to delete user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnResetPassword_Click(sender As Object, e As EventArgs) Handles btnResetPassword.Click
        If currentUserRole <> "ADMIN" Then
            MessageBox.Show("Access Denied.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If selectedUserId = -1 Then
            MessageBox.Show("Select a user to reset password.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim newPassword As String = InputBox("Enter new password for user:", "Reset Password", "password123")
        If newPassword = "" Then
            Return
        End If

        Try
            Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                Dim query As String = "UPDATE users SET password_hash = @pass WHERE user_id = @id"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@pass", newPassword)
                    cmd.Parameters.AddWithValue("@id", selectedUserId)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Password reset successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show($"Failed to reset password: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearInputs()
    End Sub

    Private Sub ClearInputs()
        selectedUserId = -1
        txtFullName.Clear()
        txtUsername.Clear()
        txtPassword.Clear()
        cboRole.SelectedIndex = 0
        cboStatus.SelectedIndex = 0
        dgvUsers.ClearSelection()
        txtFullName.Focus()
    End Sub

    Private Sub dgvUsers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsers.CellClick
        If e.RowIndex < 0 Then
            Return
        End If

        Dim row As DataGridViewRow = dgvUsers.Rows(e.RowIndex)
        selectedUserId = Convert.ToInt32(row.Cells("user_id").Value)
        txtFullName.Text = Convert.ToString(row.Cells("full_name").Value)
        txtUsername.Text = Convert.ToString(row.Cells("username").Value)
        txtPassword.Clear()
        txtPassword.PlaceholderText = "Leave blank to keep current password"

        Dim role As String = Convert.ToString(row.Cells("role").Value)
        cboRole.Text = role

        Dim isActive As Integer = Convert.ToInt32(row.Cells("is_active").Value)
        cboStatus.SelectedIndex = If(isActive = 1, 0, 1)
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If userTable Is Nothing Then
            Return
        End If

        Dim keyword As String = txtSearch.Text.Trim().Replace("'", "''")
        If keyword = "" Then
            userTable.DefaultView.RowFilter = ""
        Else
            userTable.DefaultView.RowFilter = $"full_name LIKE '%{keyword}%' OR username LIKE '%{keyword}%' OR role LIKE '%{keyword}%'"
        End If
    End Sub
End Class