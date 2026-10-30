Imports MySql.Data.MySqlClient

Public Class DeliveryForm
    Private selectedDeliveryId As Integer = -1
    Private deliveryTable As DataTable
    Private currentUserRole As String = ""
    Private activationSyncCount As Integer

    Public Sub New(Optional userRole As String = "CLERK")
        InitializeComponent()
        currentUserRole = userRole
    End Sub

    Private Sub DeliveryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UiBranding.ApplyModuleHeader(Me, "Delivery Tracking")

        If currentUserRole <> "ADMIN" Then
            btnDelete.Enabled = False
            btnDelete.Visible = False
        End If

        LoadOrders()
        LoadDeliveries()
        If cboStatus.Items.Count > 0 Then
            cboStatus.SelectedIndex = 0
        End If
    End Sub

    Private Sub DeliveryForm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        If DesignMode Then
            Return
        End If

        activationSyncCount += 1
        If activationSyncCount = 1 Then
            Return
        End If

        Dim savedId As Integer = selectedDeliveryId
        LoadOrders()
        LoadDeliveries()
        If savedId > 0 Then
            RestoreDeliveryRow(savedId)
        End If
    End Sub

    Private Sub RestoreDeliveryRow(deliveryId As Integer)
        For Each r As DataGridViewRow In dgvDeliveries.Rows
            If r.IsNewRow Then
                Continue For
            End If

            If Convert.ToInt32(r.Cells("delivery_id").Value) = deliveryId Then
                dgvDeliveries_CellClick(dgvDeliveries, New DataGridViewCellEventArgs(0, r.Index))
                Return
            End If
        Next
    End Sub

    Private Sub LoadOrders()
        Try
            Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                Dim sql As String = "SELECT po_id, po_number FROM purchase_orders ORDER BY po_id DESC"
                Using cmd As New MySqlCommand(sql, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        Dim table As New DataTable()
                        table.Load(reader)
                        cboOrder.DataSource = table
                        cboOrder.DisplayMember = "po_number"
                        cboOrder.ValueMember = "po_id"
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Failed to load purchase orders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadDeliveries()
        Try
            Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                Dim sql As String = "SELECT d.delivery_id, po.po_number, DATE_FORMAT(d.delivery_date, '%Y-%m-%d') AS delivery_date, d.status, d.remarks FROM deliveries d INNER JOIN purchase_orders po ON po.po_id = d.po_id ORDER BY d.delivery_id DESC"
                Using adapter As New MySqlDataAdapter(sql, conn)
                    deliveryTable = New DataTable()
                    adapter.Fill(deliveryTable)
                    dgvDeliveries.DataSource = deliveryTable
                    dgvDeliveries.Columns("delivery_id").Visible = False
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Failed to load deliveries: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function IsValidInput() As Boolean
        If cboOrder.SelectedIndex = -1 Then
            MessageBox.Show("Please select an order.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
                Dim sql As String = "INSERT INTO deliveries (po_id, delivery_date, status, remarks) VALUES (@po, @date, @status, @remarks)"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@po", Convert.ToInt32(cboOrder.SelectedValue))
                    cmd.Parameters.AddWithValue("@date", dtpDeliveryDate.Value.Date)
                    cmd.Parameters.AddWithValue("@status", cboStatus.Text)
                    cmd.Parameters.AddWithValue("@remarks", txtRemarks.Text.Trim())
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            txtRemarks.Clear()
            If cboStatus.Items.Count > 0 Then
                cboStatus.SelectedIndex = 0
            End If
            LoadDeliveries()
            MessageBox.Show("Delivery saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show($"Failed to save delivery: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If currentUserRole <> "ADMIN" Then
            MessageBox.Show("Access Denied. Only Administrators can delete deliveries.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If selectedDeliveryId = -1 Then
            MessageBox.Show("Select a delivery to delete.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim confirmResult As DialogResult = MessageBox.Show("Delete selected delivery?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirmResult <> DialogResult.Yes Then
            Return
        End If

        Try
            Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                Dim sql As String = "DELETE FROM deliveries WHERE delivery_id = @id"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id", selectedDeliveryId)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            selectedDeliveryId = -1
            LoadDeliveries()
            MessageBox.Show("Delivery deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show($"Failed to delete delivery: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadOrders()
        LoadDeliveries()
    End Sub

    Private Sub dgvDeliveries_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDeliveries.CellClick
        If e.RowIndex < 0 Then
            Return
        End If

        Dim row As DataGridViewRow = dgvDeliveries.Rows(e.RowIndex)
        selectedDeliveryId = Convert.ToInt32(row.Cells("delivery_id").Value)
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If deliveryTable Is Nothing Then
            Return
        End If

        Dim keyword As String = txtSearch.Text.Trim().Replace("'", "''")
        If keyword = "" Then
            deliveryTable.DefaultView.RowFilter = ""
        Else
            deliveryTable.DefaultView.RowFilter = $"po_number LIKE '%{keyword}%' OR status LIKE '%{keyword}%' OR remarks LIKE '%{keyword}%'"
        End If
    End Sub

    Private Sub dgvDeliveries_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDeliveries.CellContentClick

    End Sub
End Class