Imports MySql.Data.MySqlClient

Public Class InvoicePaymentForm
    Private invoiceTable As DataTable
    Private paymentTable As DataTable
    Private currentUserRole As String = ""
    Private activationSyncCount As Integer

    Public Sub New(Optional userRole As String = "CLERK")
        InitializeComponent()
        currentUserRole = userRole
    End Sub

    Private Sub InvoicePaymentForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UiBranding.ApplyModuleHeader(Me, "Invoice and Payment Management")

        If currentUserRole <> "ADMIN" Then
            btnAddInvoice.Enabled = False
            btnAddPayment.Enabled = False
        End If

        LoadSuppliers()
        LoadInvoices()
        LoadPayments()
        If cboPaymentMethod.Items.Count > 0 Then
            cboPaymentMethod.SelectedIndex = 0
        End If
    End Sub

    Private Sub InvoicePaymentForm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        If DesignMode Then
            Return
        End If

        activationSyncCount += 1
        If activationSyncCount = 1 Then
            Return
        End If

        LoadSuppliers()
        LoadInvoices()
        LoadPayments()
    End Sub

    Private Sub LoadSuppliers()
        Try
            Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                Dim sql As String = "SELECT supplier_id, supplier_name FROM suppliers ORDER BY supplier_name"
                Using cmd As New MySqlCommand(sql, conn)
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

    Private Sub LoadInvoices()
        Try
            Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                Dim sql As String = "SELECT i.invoice_id, s.supplier_name, i.invoice_number, DATE_FORMAT(i.invoice_date, '%Y-%m-%d') AS invoice_date, i.invoice_amount, i.status FROM supplier_invoices i INNER JOIN suppliers s ON s.supplier_id = i.supplier_id ORDER BY i.invoice_id DESC"
                Using adapter As New MySqlDataAdapter(sql, conn)
                    invoiceTable = New DataTable()
                    adapter.Fill(invoiceTable)
                    dgvInvoices.DataSource = invoiceTable
                    dgvInvoices.Columns("invoice_id").Visible = False
                End Using

                Dim comboSql As String = "SELECT invoice_id, invoice_number FROM supplier_invoices ORDER BY invoice_id DESC"
                Using comboCmd As New MySqlCommand(comboSql, conn)
                    Using reader As MySqlDataReader = comboCmd.ExecuteReader()
                        Dim comboTable As New DataTable()
                        comboTable.Load(reader)
                        cboInvoice.DataSource = comboTable
                        cboInvoice.DisplayMember = "invoice_number"
                        cboInvoice.ValueMember = "invoice_id"
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Failed to load invoices: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadPayments()
        Try
            Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                Dim sql As String = "SELECT p.payment_id, i.invoice_number, DATE_FORMAT(p.payment_date, '%Y-%m-%d') AS payment_date, p.amount_paid, p.payment_method FROM payments p INNER JOIN supplier_invoices i ON i.invoice_id = p.invoice_id ORDER BY p.payment_id DESC"
                Using adapter As New MySqlDataAdapter(sql, conn)
                    paymentTable = New DataTable()
                    adapter.Fill(paymentTable)
                    dgvPayments.DataSource = paymentTable
                    dgvPayments.Columns("payment_id").Visible = False
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Failed to load payments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function IsValidInvoice() As Boolean
        If cboSupplier.SelectedIndex = -1 Then
            MessageBox.Show("Please select a supplier.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If txtInvoiceNo.Text.Trim() = "" Then
            MessageBox.Show("Invoice number is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Dim amount As Decimal
        If Not Decimal.TryParse(txtInvoiceAmount.Text.Trim(), amount) OrElse amount <= 0 Then
            MessageBox.Show("Enter a valid invoice amount.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function

    Private Function IsValidPayment() As Boolean
        If cboInvoice.SelectedIndex = -1 Then
            MessageBox.Show("Please select an invoice.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Dim paymentAmount As Decimal
        If Not Decimal.TryParse(txtPaymentAmount.Text.Trim(), paymentAmount) OrElse paymentAmount <= 0 Then
            MessageBox.Show("Enter a valid payment amount.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function

    Private Sub btnAddInvoice_Click(sender As Object, e As EventArgs) Handles btnAddInvoice.Click
        If currentUserRole <> "ADMIN" Then
            MessageBox.Show("Access Denied. Only Administrators can add invoices.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If Not IsValidInvoice() Then
            Return
        End If

        Try
            Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                Dim sql As String = "INSERT INTO supplier_invoices (supplier_id, invoice_number, invoice_date, invoice_amount, status) VALUES (@supplier, @number, @date, @amount, 'UNPAID')"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@supplier", Convert.ToInt32(cboSupplier.SelectedValue))
                    cmd.Parameters.AddWithValue("@number", txtInvoiceNo.Text.Trim())
                    cmd.Parameters.AddWithValue("@date", dtpInvoiceDate.Value.Date)
                    cmd.Parameters.AddWithValue("@amount", Convert.ToDecimal(txtInvoiceAmount.Text))
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            txtInvoiceNo.Clear()
            txtInvoiceAmount.Clear()
            LoadInvoices()
            LoadPayments()
            MessageBox.Show("Invoice added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As MySqlException
            If ex.Number = 1062 Then
                MessageBox.Show("Invoice number already exists for this supplier.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show($"Failed to add invoice: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show($"Failed to add invoice: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAddPayment_Click(sender As Object, e As EventArgs) Handles btnAddPayment.Click
        If currentUserRole <> "ADMIN" Then
            MessageBox.Show("Access Denied. Only Administrators can record payments.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If Not IsValidPayment() Then
            Return
        End If

        Try
            Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                Dim insertPayment As String = "INSERT INTO payments (invoice_id, payment_date, amount_paid, payment_method) VALUES (@invoice, @date, @amount, @method)"
                Using cmd As New MySqlCommand(insertPayment, conn)
                    cmd.Parameters.AddWithValue("@invoice", Convert.ToInt32(cboInvoice.SelectedValue))
                    cmd.Parameters.AddWithValue("@date", dtpPaymentDate.Value.Date)
                    cmd.Parameters.AddWithValue("@amount", Convert.ToDecimal(txtPaymentAmount.Text))
                    cmd.Parameters.AddWithValue("@method", cboPaymentMethod.Text)
                    cmd.ExecuteNonQuery()
                End Using

                Dim updateInvoiceStatus As String = "UPDATE supplier_invoices i LEFT JOIN (SELECT invoice_id, IFNULL(SUM(amount_paid), 0) total_paid FROM payments GROUP BY invoice_id) p ON p.invoice_id = i.invoice_id SET i.status = CASE WHEN IFNULL(p.total_paid, 0) = 0 THEN 'UNPAID' WHEN IFNULL(p.total_paid, 0) < i.invoice_amount THEN 'PARTIAL' ELSE 'PAID' END WHERE i.invoice_id = @invoiceId"
                Using updateCmd As New MySqlCommand(updateInvoiceStatus, conn)
                    updateCmd.Parameters.AddWithValue("@invoiceId", Convert.ToInt32(cboInvoice.SelectedValue))
                    updateCmd.ExecuteNonQuery()
                End Using
            End Using

            txtPaymentAmount.Clear()
            LoadInvoices()
            LoadPayments()
            MessageBox.Show("Payment recorded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show($"Failed to record payment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadSuppliers()
        LoadInvoices()
        LoadPayments()
    End Sub

    Private Sub txtSearchInvoice_TextChanged(sender As Object, e As EventArgs) Handles txtSearchInvoice.TextChanged
        If invoiceTable Is Nothing Then
            Return
        End If

        Dim keyword As String = txtSearchInvoice.Text.Trim().Replace("'", "''")
        If keyword = "" Then
            invoiceTable.DefaultView.RowFilter = ""
        Else
            invoiceTable.DefaultView.RowFilter = $"supplier_name LIKE '%{keyword}%' OR invoice_number LIKE '%{keyword}%' OR status LIKE '%{keyword}%'"
        End If
    End Sub

    Private Sub txtSearchPayment_TextChanged(sender As Object, e As EventArgs) Handles txtSearchPayment.TextChanged
        If paymentTable Is Nothing Then
            Return
        End If

        Dim keyword As String = txtSearchPayment.Text.Trim().Replace("'", "''")
        If keyword = "" Then
            paymentTable.DefaultView.RowFilter = ""
        Else
            paymentTable.DefaultView.RowFilter = $"invoice_number LIKE '%{keyword}%' OR payment_method LIKE '%{keyword}%'"
        End If
    End Sub

    Private Sub dgvInvoices_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInvoices.CellContentClick

    End Sub
End Class