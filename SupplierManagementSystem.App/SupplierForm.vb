Imports MySql.Data.MySqlClient

Public Class SupplierForm
    Private selectedSupplierId As Integer = -1
    Private supplierTable As DataTable
    Private currentUserRole As String = ""
    Private activationSyncCount As Integer

    Public Sub New(Optional userRole As String = "CLERK")
        InitializeComponent()
        currentUserRole = userRole
    End Sub

    Private Sub SupplierForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If DesignMode Then
            Return
        End If

        UiBranding.ApplyModuleHeader(Me, "Supplier Management")

        If currentUserRole <> "ADMIN" Then
            btnDelete.Enabled = False
            btnDelete.Visible = False
        End If

        LoadSuppliers()
    End Sub

    Private Sub SupplierForm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        If DesignMode Then
            Return
        End If

        activationSyncCount += 1
        If activationSyncCount = 1 Then
            Return
        End If

        Dim savedId As Integer = selectedSupplierId
        LoadSuppliers()
        If savedId > 0 Then
            RestoreSupplierRow(savedId)
        End If
    End Sub

    Private Sub RestoreSupplierRow(supplierId As Integer)
        For Each r As DataGridViewRow In dgvSuppliers.Rows
            If r.IsNewRow Then
                Continue For
            End If

            If Convert.ToInt32(r.Cells("supplier_id").Value) = supplierId Then
                dgvSuppliers_CellClick(dgvSuppliers, New DataGridViewCellEventArgs(0, r.Index))
                Return
            End If
        Next
    End Sub

    Private Sub LoadSuppliers()
        If DesignMode Then
            Return
        End If

        Try
            Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                Dim query As String = "SELECT supplier_id, supplier_name, contact_person, phone, location_area FROM suppliers ORDER BY supplier_id DESC"
                Using adapter As New MySqlDataAdapter(query, conn)
                    supplierTable = New DataTable()
                    adapter.Fill(supplierTable)
                    dgvSuppliers.DataSource = supplierTable
                    dgvSuppliers.Columns("supplier_id").Visible = False
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Failed to load suppliers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function IsInputValid() As Boolean
        If txtSupplierName.Text.Trim() = "" Then
            MessageBox.Show("Supplier name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If txtPhone.Text.Trim() = "" Then
            MessageBox.Show("Phone is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not IsInputValid() Then
            Return
        End If

        Try
            Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                Dim query As String = "INSERT INTO suppliers (supplier_name, contact_person, phone, location_area) VALUES (@name, @contact, @phone, @location)"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@name", txtSupplierName.Text.Trim())
                    cmd.Parameters.AddWithValue("@contact", txtContactPerson.Text.Trim())
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim())
                    cmd.Parameters.AddWithValue("@location", txtLocation.Text.Trim())
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Supplier added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearInputs()
            LoadSuppliers()
        Catch ex As Exception
            MessageBox.Show($"Failed to add supplier: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If selectedSupplierId = -1 Then
            MessageBox.Show("Select a supplier to update.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not IsInputValid() Then
            Return
        End If

        Try
            Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                Dim query As String = "UPDATE suppliers SET supplier_name = @name, contact_person = @contact, phone = @phone, location_area = @location WHERE supplier_id = @id"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@name", txtSupplierName.Text.Trim())
                    cmd.Parameters.AddWithValue("@contact", txtContactPerson.Text.Trim())
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim())
                    cmd.Parameters.AddWithValue("@location", txtLocation.Text.Trim())
                    cmd.Parameters.AddWithValue("@id", selectedSupplierId)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Supplier updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearInputs()
            LoadSuppliers()
        Catch ex As Exception
            MessageBox.Show($"Failed to update supplier: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If currentUserRole <> "ADMIN" Then
            MessageBox.Show("Access Denied. Only Administrators can delete suppliers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If selectedSupplierId = -1 Then
            MessageBox.Show("Select a supplier to delete.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim confirmResult As DialogResult = MessageBox.Show("Delete selected supplier?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirmResult <> DialogResult.Yes Then
            Return
        End If

        Try
            Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                Dim query As String = "DELETE FROM suppliers WHERE supplier_id = @id"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", selectedSupplierId)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Supplier deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearInputs()
            LoadSuppliers()
        Catch ex As Exception
            MessageBox.Show($"Failed to delete supplier: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearInputs()
    End Sub

    Private Sub ClearInputs()
        selectedSupplierId = -1
        txtSupplierName.Clear()
        txtContactPerson.Clear()
        txtPhone.Clear()
        txtLocation.Clear()
        dgvSuppliers.ClearSelection()
        txtSupplierName.Focus()
    End Sub

    Private Sub dgvSuppliers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSuppliers.CellClick
        If e.RowIndex < 0 Then
            Return
        End If

        Dim row As DataGridViewRow = dgvSuppliers.Rows(e.RowIndex)
        selectedSupplierId = Convert.ToInt32(row.Cells("supplier_id").Value)
        txtSupplierName.Text = Convert.ToString(row.Cells("supplier_name").Value)
        txtContactPerson.Text = Convert.ToString(row.Cells("contact_person").Value)
        txtPhone.Text = Convert.ToString(row.Cells("phone").Value)
        txtLocation.Text = Convert.ToString(row.Cells("location_area").Value)
    End Sub

    Private Sub txtSupplierSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSupplierSearch.TextChanged
        If supplierTable Is Nothing Then
            Return
        End If

        Dim keyword As String = txtSupplierSearch.Text.Trim().Replace("'", "''")
        If keyword = "" Then
            supplierTable.DefaultView.RowFilter = ""
        Else
            supplierTable.DefaultView.RowFilter = $"supplier_name LIKE '%{keyword}%' OR contact_person LIKE '%{keyword}%' OR phone LIKE '%{keyword}%' OR location_area LIKE '%{keyword}%'"
        End If
    End Sub
End Class