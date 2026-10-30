Imports MySql.Data.MySqlClient

Public Class DashboardForm
    Private currentModuleForm As Form
    Private ReadOnly loggedInUser As String
    Private ReadOnly loggedInRole As String
    Private dashboardActivationSyncCount As Integer

    Public Sub New(displayName As String, userRole As String)
        InitializeComponent()
        loggedInUser = If(String.IsNullOrWhiteSpace(displayName), "User", displayName.Trim())
        loggedInRole = If(String.IsNullOrWhiteSpace(userRole), "CLERK", userRole.Trim().ToUpperInvariant())
    End Sub

    Private Sub DashboardForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSidebarLogoImage()
        UpdateUserDisplay()
        ApplyRoleBasedAccess()
        LoadDashboardStats()
        LoadRecentOrders()
    End Sub

    Private Sub DashboardForm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        If DesignMode Then
            Return
        End If

        dashboardActivationSyncCount += 1
        If dashboardActivationSyncCount = 1 Then
            Return
        End If

        If currentModuleForm Is Nothing Then
            LoadDashboardStats()
            LoadRecentOrders()
        End If
    End Sub

    Private Sub UpdateUserDisplay()
        lblWelcome.Text = $"Welcome back, {loggedInUser}!"
        lblDate.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy")

        lblSidebarUserName.Text = loggedInUser
        lblRole.Text = $"Role: {loggedInRole}"
    End Sub

    Private Function IsAdministrator() As Boolean
        Return String.Equals(loggedInRole, "ADMIN", StringComparison.OrdinalIgnoreCase)
    End Function

    Private Sub ApplyRoleBasedAccess()
        Dim admin As Boolean = IsAdministrator()
        btnUsers.Visible = admin
        btnUsers.Enabled = admin
    End Sub

    Private Sub LoadDashboardStats()
        Try
            Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                lblSuppliers.Text = $"Suppliers: {GetCount(conn, "suppliers")}"
                lblProducts.Text = $"Products: {GetCount(conn, "products")}"
                lblOrders.Text = $"Orders: {GetCount(conn, "purchase_orders")}"

                lblSuppliersCount.Text = GetCount(conn, "suppliers").ToString()
                lblProductsCount.Text = GetCount(conn, "products").ToString()
                lblOrdersCount.Text = GetCount(conn, "purchase_orders").ToString()

                Dim invoiceTotal As Decimal = 0
                Dim paidTotal As Decimal = 0

                Dim invoiceCmd As New MySqlCommand("SELECT IFNULL(SUM(invoice_amount), 0) FROM supplier_invoices", conn)
                invoiceTotal = Convert.ToDecimal(invoiceCmd.ExecuteScalar())

                Dim paidCmd As New MySqlCommand("SELECT IFNULL(SUM(amount_paid), 0) FROM payments", conn)
                paidTotal = Convert.ToDecimal(paidCmd.ExecuteScalar())

                Dim outstanding As Decimal = invoiceTotal - paidTotal

                lblInvoicesTotal.Text = $"UGX {invoiceTotal:N0}"
                lblOutstandingTotal.Text = $"UGX {outstanding:N0}"

                If outstanding > 0 Then
                    CardOutstanding.BackColor = Color.FromArgb(220, 53, 69)
                Else
                    CardOutstanding.BackColor = Color.FromArgb(40, 167, 69)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show($"Failed to load dashboard statistics: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetCount(conn As MySqlConnection, tableName As String) As Integer
        Using cmd As New MySqlCommand($"SELECT COUNT(*) FROM {tableName}", conn)
            Return Convert.ToInt32(cmd.ExecuteScalar())
        End Using
    End Function

    Private Sub LoadRecentOrders()
        Try
            Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                Dim query As String = "
                    SELECT 
                        po.po_number,
                        s.supplier_name,
                        DATE_FORMAT(po.order_date, '%Y-%m-%d') AS order_date,
                        COUNT(i.item_id) AS items,
                        SUM(i.total_price) AS total_amount
                    FROM purchase_orders po
                    INNER JOIN suppliers s ON s.supplier_id = po.supplier_id
                    LEFT JOIN po_items i ON i.po_id = po.po_id
                    GROUP BY po.po_id, s.supplier_name, po.order_date
                    ORDER BY po.order_date DESC
                    LIMIT 10"

                Dim adapter As New MySqlDataAdapter(query, conn)
                Dim dt As New DataTable()
                adapter.Fill(dt)
                dgvRecentOrders.DataSource = dt

                If dt.Rows.Count > 0 Then
                    dgvRecentOrders.Columns("po_number").HeaderText = "PO Number"
                    dgvRecentOrders.Columns("supplier_name").HeaderText = "Supplier"
                    dgvRecentOrders.Columns("order_date").HeaderText = "Order Date"
                    dgvRecentOrders.Columns("items").HeaderText = "Items"
                    dgvRecentOrders.Columns("total_amount").HeaderText = "Total Amount"
                    dgvRecentOrders.Columns("total_amount").DefaultCellStyle.Format = "N0"
                    dgvRecentOrders.Columns("total_amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End If
            End Using
        Catch ex As Exception
            Console.WriteLine($"Failed to load recent orders: {ex.Message}")
        End Try
    End Sub

    Private Sub btnSuppliers_Click(sender As Object, e As EventArgs) Handles btnSuppliers.Click
        OpenModule(New SupplierForm(loggedInRole))
    End Sub

    Private Sub btnProducts_Click(sender As Object, e As EventArgs) Handles btnProducts.Click
        OpenModule(New ProductForm(loggedInRole))
    End Sub

    Private Sub btnOrders_Click(sender As Object, e As EventArgs) Handles btnOrders.Click
        OpenModule(New PurchaseOrderForm(loggedInRole))
    End Sub

    Private Sub btnDeliveries_Click(sender As Object, e As EventArgs) Handles btnDeliveries.Click
        OpenModule(New DeliveryForm(loggedInRole))
    End Sub

    Private Sub btnInvoicesPayments_Click(sender As Object, e As EventArgs) Handles btnInvoicesPayments.Click
        OpenModule(New InvoicePaymentForm(loggedInRole))
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadDashboardStats()
        LoadRecentOrders()
    End Sub

    Private Sub btnReports_Click(sender As Object, e As EventArgs) Handles btnReports.Click
        OpenModule(New ReportsForm(loggedInRole))
    End Sub

    Private Sub btnUsers_Click(sender As Object, e As EventArgs) Handles btnUsers.Click
        If Not IsAdministrator() Then
            MessageBox.Show("Access denied. Only an Administrator can open User Management.", "Access restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        OpenModule(New UserManagementForm("ADMIN"))
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Me.Close()
    End Sub

    Private Sub OpenModule(moduleForm As Form)
        pnlDashboard.Visible = False

        If currentModuleForm IsNot Nothing Then
            pnlContent.Controls.Remove(currentModuleForm)
            currentModuleForm.Dispose()
            currentModuleForm = Nothing
        End If

        moduleForm.TopLevel = False
        moduleForm.FormBorderStyle = FormBorderStyle.None
        moduleForm.Dock = DockStyle.Fill
        currentModuleForm = moduleForm
        pnlContent.Controls.Add(moduleForm)
        moduleForm.BringToFront()
        moduleForm.Show()
    End Sub

    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        If currentModuleForm IsNot Nothing Then
            pnlContent.Controls.Remove(currentModuleForm)
            currentModuleForm.Dispose()
            currentModuleForm = Nothing
        End If

        pnlDashboard.Visible = True
        pnlDashboard.BringToFront()
        LoadDashboardStats()
        LoadRecentOrders()
    End Sub

    Private Sub LoadSidebarLogoImage()
        Dim logoPath As String = System.IO.Path.Combine(Application.StartupPath, "logo_small.png")
        If System.IO.File.Exists(logoPath) Then
            Using loaded As Image = Image.FromFile(logoPath)
                picSidebarLogo.Image = New Bitmap(loaded)
            End Using
        ElseIf picSidebarLogo.Image Is Nothing Then
            picSidebarLogo.Image = UiBranding.GetLogoImage()
        End If
    End Sub
End Class