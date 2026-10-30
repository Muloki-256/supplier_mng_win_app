Imports MySql.Data.MySqlClient

Public Class ProductForm
    Private selectedProductId As Integer = -1
    Private productTable As DataTable
    Private currentUserRole As String = ""
    Private activationSyncCount As Integer

    Public Sub New(Optional userRole As String = "CLERK")
        InitializeComponent()
        currentUserRole = userRole
    End Sub

    Private Sub ProductForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UiBranding.ApplyModuleHeader(Me, "Product Management")

        If currentUserRole <> "ADMIN" Then
            btnDelete.Enabled = False
            btnDelete.Visible = False
        End If

        LoadProducts()
    End Sub

    Private Sub ProductForm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        If DesignMode Then
            Return
        End If

        activationSyncCount += 1
        If activationSyncCount = 1 Then
            Return
        End If

        Dim savedId As Integer = selectedProductId
        LoadProducts()
        If savedId > 0 Then
            RestoreProductRow(savedId)
        End If
    End Sub

    Private Sub RestoreProductRow(productId As Integer)
        For Each r As DataGridViewRow In dgvProducts.Rows
            If r.IsNewRow Then
                Continue For
            End If

            If Convert.ToInt32(r.Cells("product_id").Value) = productId Then
                dgvProducts_CellClick(dgvProducts, New DataGridViewCellEventArgs(0, r.Index))
                Return
            End If
        Next
    End Sub

    Private Sub LoadProducts()
        Try
            Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                Dim query As String = "SELECT product_id, product_name, unit, reorder_level FROM products ORDER BY product_id DESC"
                Using adapter As New MySqlDataAdapter(query, conn)
                    productTable = New DataTable()
                    adapter.Fill(productTable)
                    dgvProducts.DataSource = productTable
                    dgvProducts.Columns("product_id").Visible = False
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Failed to load products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function IsValidInput() As Boolean
        If txtProductName.Text.Trim() = "" Then
            MessageBox.Show("Product name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If txtUnit.Text.Trim() = "" Then
            MessageBox.Show("Unit is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not IsValidInput() Then
            Return
        End If

        Try
            Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                Dim query As String = "INSERT INTO products (product_name, unit, reorder_level) VALUES (@name, @unit, @reorder)"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@name", txtProductName.Text.Trim())
                    cmd.Parameters.AddWithValue("@unit", txtUnit.Text.Trim())
                    cmd.Parameters.AddWithValue("@reorder", Convert.ToInt32(nudReorderLevel.Value))
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Product added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearInputs()
            LoadProducts()
        Catch ex As Exception
            MessageBox.Show($"Failed to add product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If selectedProductId = -1 Then
            MessageBox.Show("Select a product to update.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not IsValidInput() Then
            Return
        End If

        Try
            Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                Dim query As String = "UPDATE products SET product_name = @name, unit = @unit, reorder_level = @reorder WHERE product_id = @id"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@name", txtProductName.Text.Trim())
                    cmd.Parameters.AddWithValue("@unit", txtUnit.Text.Trim())
                    cmd.Parameters.AddWithValue("@reorder", Convert.ToInt32(nudReorderLevel.Value))
                    cmd.Parameters.AddWithValue("@id", selectedProductId)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Product updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearInputs()
            LoadProducts()
        Catch ex As Exception
            MessageBox.Show($"Failed to update product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If currentUserRole <> "ADMIN" Then
            MessageBox.Show("Access Denied. Only Administrators can delete products.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If selectedProductId = -1 Then
            MessageBox.Show("Select a product to delete.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim confirmDelete As DialogResult = MessageBox.Show("Delete selected product?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirmDelete <> DialogResult.Yes Then
            Return
        End If

        Try
            Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                Dim query As String = "DELETE FROM products WHERE product_id = @id"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", selectedProductId)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Product deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearInputs()
            LoadProducts()
        Catch ex As Exception
            MessageBox.Show($"Failed to delete product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearInputs()
    End Sub

    Private Sub ClearInputs()
        selectedProductId = -1
        txtProductName.Clear()
        txtUnit.Clear()
        nudReorderLevel.Value = 10
        dgvProducts.ClearSelection()
        txtProductName.Focus()
    End Sub

    Private Sub dgvProducts_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProducts.CellClick
        If e.RowIndex < 0 Then
            Return
        End If

        Dim row As DataGridViewRow = dgvProducts.Rows(e.RowIndex)
        selectedProductId = Convert.ToInt32(row.Cells("product_id").Value)
        txtProductName.Text = Convert.ToString(row.Cells("product_name").Value)
        txtUnit.Text = Convert.ToString(row.Cells("unit").Value)
        nudReorderLevel.Value = Convert.ToDecimal(row.Cells("reorder_level").Value)
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If productTable Is Nothing Then
            Return
        End If

        Dim keyword As String = txtSearch.Text.Trim().Replace("'", "''")
        If keyword = "" Then
            productTable.DefaultView.RowFilter = ""
        Else
            productTable.DefaultView.RowFilter = $"product_name LIKE '%{keyword}%' OR unit LIKE '%{keyword}%'"
        End If
    End Sub
End Class