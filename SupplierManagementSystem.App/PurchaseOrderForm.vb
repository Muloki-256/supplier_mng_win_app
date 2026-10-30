Imports MySql.Data.MySqlClient

Public Class PurchaseOrderForm
    Private selectedPoId As Integer = -1
    Private selectedItemId As Integer = -1
    Private orderTable As DataTable
    Private itemsTable As DataTable
    Private currentUserRole As String = ""
    Private activationSyncCount As Integer

    Public Sub New(Optional userRole As String = "CLERK")
        InitializeComponent()
        currentUserRole = userRole
    End Sub

    Private Sub PurchaseOrderForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UiBranding.ApplyModuleHeader(Me, "Purchase Order Management")

        If currentUserRole <> "ADMIN" Then
            btnDeleteOrder.Enabled = False
            btnDeleteOrder.Visible = False
            btnRemoveItem.Enabled = False
            btnRemoveItem.Visible = False
        End If

        LoadSuppliers()
        LoadProducts()
        LoadOrders()
    End Sub

    Private Sub PurchaseOrderForm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        If DesignMode Then
            Return
        End If

        activationSyncCount += 1
        If activationSyncCount = 1 Then
            Return
        End If

        ReloadPurchaseOrderDataFromDatabase(False)
    End Sub

    Private Sub LoadSuppliers()
        Try
            Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                Dim query As String = "SELECT supplier_id, supplier_name FROM suppliers ORDER BY supplier_name"
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        Dim table As New DataTable()
                        table.Load(reader)
                        cboSupplier.DataSource = table
                        cboSupplier.DisplayMember = "supplier_name"
                        cboSupplier.ValueMember = "supplier_id"
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Failed to load suppliers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadProducts()
        Try
            Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                Dim query As String = "SELECT product_id, product_name, unit FROM products ORDER BY product_name"
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        Dim table As New DataTable()
                        table.Load(reader)
                        cboProduct.DataSource = table
                        cboProduct.DisplayMember = "product_name"
                        cboProduct.ValueMember = "product_id"
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Failed to load products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadOrders()
        Try
            Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                Dim query As String = "SELECT po.po_id, po.po_number, s.supplier_name, DATE_FORMAT(po.order_date, '%Y-%m-%d') AS order_date FROM purchase_orders po INNER JOIN suppliers s ON s.supplier_id = po.supplier_id ORDER BY po.po_id DESC"
                Using adapter As New MySqlDataAdapter(query, conn)
                    orderTable = New DataTable()
                    adapter.Fill(orderTable)
                    dgvOrders.DataSource = orderTable
                    dgvOrders.Columns("po_id").Visible = False
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Failed to load orders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadOrderItems()
        If selectedPoId = -1 Then
            itemsTable = New DataTable()
            dgvItems.DataSource = itemsTable
            lblOrderTotal.Text = "Total: UGX 0"
            Return
        End If

        Try
            Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                Dim query As String = "SELECT i.item_id, p.product_name, i.quantity, i.unit_price, i.total_price FROM po_items i INNER JOIN products p ON p.product_id = i.product_id WHERE i.po_id = @poId ORDER BY i.item_id ASC"
                Using adapter As New MySqlDataAdapter(query, conn)
                    adapter.SelectCommand.Parameters.AddWithValue("@poId", selectedPoId)
                    itemsTable = New DataTable()
                    adapter.Fill(itemsTable)
                    dgvItems.DataSource = itemsTable
                    dgvItems.Columns("item_id").Visible = False
                End Using

                Dim total As Decimal = 0
                For Each row As DataRow In itemsTable.Rows
                    total += Convert.ToDecimal(row("total_price"))
                Next
                lblOrderTotal.Text = $"Total: UGX {total:N0}"
            End Using
        Catch ex As Exception
            MessageBox.Show($"Failed to load order items: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function IsValidOrderInput() As Boolean
        If txtPoNumber.Text.Trim() = "" Then
            MessageBox.Show("PO Number is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If cboSupplier.SelectedIndex = -1 Then
            MessageBox.Show("Please select a supplier.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function

    Private Function IsValidItemInput() As Boolean
        If selectedPoId = -1 Then
            MessageBox.Show("Please save the order first before adding items.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If cboProduct.SelectedIndex = -1 Then
            MessageBox.Show("Please select a product.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Dim price As Decimal
        If Not Decimal.TryParse(txtUnitPrice.Text, price) OrElse price <= 0 Then
            MessageBox.Show("Enter a valid unit price.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If nudQuantity.Value <= 0 Then
            MessageBox.Show("Quantity must be greater than zero.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function

    Private Sub btnAddOrder_Click(sender As Object, e As EventArgs) Handles btnAddOrder.Click
        If Not IsValidOrderInput() Then
            Return
        End If

        Try
            Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                Dim query As String = "INSERT INTO purchase_orders (po_number, supplier_id, order_date) VALUES (@poNumber, @supplierId, @orderDate)"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@poNumber", txtPoNumber.Text.Trim())
                    cmd.Parameters.AddWithValue("@supplierId", Convert.ToInt32(cboSupplier.SelectedValue))
                    cmd.Parameters.AddWithValue("@orderDate", dtpOrderDate.Value.Date)
                    cmd.ExecuteNonQuery()
                    selectedPoId = Convert.ToInt32(cmd.LastInsertedId)
                End Using
            End Using

            MessageBox.Show("Purchase order added successfully. You can now add items.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearOrderInputs()
            LoadOrders()
            LoadOrderItems()
        Catch ex As MySqlException
            If ex.Number = 1062 Then
                MessageBox.Show("PO Number already exists. Please use a unique number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show($"Failed to add order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show($"Failed to add order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAddItem_Click(sender As Object, e As EventArgs) Handles btnAddItem.Click
        If Not IsValidItemInput() Then
            Return
        End If

        Try
            Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                Dim query As String = "INSERT INTO po_items (po_id, product_id, quantity, unit_price) VALUES (@poId, @productId, @qty, @price)"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@poId", selectedPoId)
                    cmd.Parameters.AddWithValue("@productId", Convert.ToInt32(cboProduct.SelectedValue))
                    cmd.Parameters.AddWithValue("@qty", Convert.ToInt32(nudQuantity.Value))
                    cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(txtUnitPrice.Text))
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            nudQuantity.Value = 1
            txtUnitPrice.Text = "0"
            If cboProduct.Items.Count > 0 Then
                cboProduct.SelectedIndex = 0
            End If

            LoadOrderItems()
            MessageBox.Show("Item added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show($"Failed to add item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRemoveItem_Click(sender As Object, e As EventArgs) Handles btnRemoveItem.Click
        If currentUserRole <> "ADMIN" Then
            MessageBox.Show("Access Denied. Only Administrators can remove items.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If selectedItemId = -1 Then
            MessageBox.Show("Please select an item to remove.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim confirmResult As DialogResult = MessageBox.Show("Remove selected item?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirmResult <> DialogResult.Yes Then
            Return
        End If

        Try
            Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                Dim query As String = "DELETE FROM po_items WHERE item_id = @id"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", selectedItemId)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            selectedItemId = -1
            LoadOrderItems()
            MessageBox.Show("Item removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show($"Failed to remove item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDeleteOrder_Click(sender As Object, e As EventArgs) Handles btnDeleteOrder.Click
        If currentUserRole <> "ADMIN" Then
            MessageBox.Show("Access Denied. Only Administrators can delete orders.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If selectedPoId = -1 Then
            MessageBox.Show("Please select an order to delete.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim confirmDelete As DialogResult = MessageBox.Show("Delete selected order? All items will also be deleted.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirmDelete <> DialogResult.Yes Then
            Return
        End If

        Try
            Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                Dim query As String = "DELETE FROM purchase_orders WHERE po_id = @id"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", selectedPoId)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Purchase order deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearOrderInputs()
            LoadOrders()
            LoadOrderItems()
        Catch ex As Exception
            MessageBox.Show($"Failed to delete order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearOrderInputs()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        ReloadPurchaseOrderDataFromDatabase(True)
    End Sub

    Private Sub ReloadPurchaseOrderDataFromDatabase(showMessage As Boolean)
        Dim savedPo As Integer = selectedPoId
        LoadSuppliers()
        LoadProducts()
        LoadOrders()

        If savedPo > 0 Then
            Dim found As Boolean = False
            For Each r As DataGridViewRow In dgvOrders.Rows
                If r.IsNewRow Then
                    Continue For
                End If

                If Convert.ToInt32(r.Cells("po_id").Value) = savedPo Then
                    dgvOrders_CellClick(dgvOrders, New DataGridViewCellEventArgs(0, r.Index))
                    found = True
                    Exit For
                End If
            Next

            If Not found Then
                selectedPoId = -1
                selectedItemId = -1
                LoadOrderItems()
            End If
        Else
            LoadOrderItems()
        End If

        If showMessage Then
            MessageBox.Show("Data refreshed successfully.", "Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ClearOrderInputs()
        selectedPoId = -1
        selectedItemId = -1
        txtPoNumber.Clear()
        If cboSupplier.Items.Count > 0 Then
            cboSupplier.SelectedIndex = 0
        End If
        dtpOrderDate.Value = Date.Today
        dgvOrders.ClearSelection()
        nudQuantity.Value = 1
        txtUnitPrice.Text = "0"
        If cboProduct.Items.Count > 0 Then
            cboProduct.SelectedIndex = 0
        End If
    End Sub

    Private Sub dgvOrders_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvOrders.CellClick
        If e.RowIndex < 0 Then
            Return
        End If

        Dim row As DataGridViewRow = dgvOrders.Rows(e.RowIndex)
        selectedPoId = Convert.ToInt32(row.Cells("po_id").Value)
        txtPoNumber.Text = Convert.ToString(row.Cells("po_number").Value)
        cboSupplier.Text = Convert.ToString(row.Cells("supplier_name").Value)

        Dim orderDate As DateTime
        If DateTime.TryParse(Convert.ToString(row.Cells("order_date").Value), orderDate) Then
            dtpOrderDate.Value = orderDate
        End If

        LoadOrderItems()
    End Sub

    Private Sub dgvItems_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItems.CellClick
        If e.RowIndex < 0 Then
            Return
        End If

        Dim row As DataGridViewRow = dgvItems.Rows(e.RowIndex)
        selectedItemId = Convert.ToInt32(row.Cells("item_id").Value)
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If orderTable Is Nothing Then
            Return
        End If

        Dim keyword As String = txtSearch.Text.Trim().Replace("'", "''")
        If keyword = "" Then
            orderTable.DefaultView.RowFilter = ""
        Else
            orderTable.DefaultView.RowFilter = $"po_number LIKE '%{keyword}%' OR supplier_name LIKE '%{keyword}%'"
        End If
    End Sub
End Class