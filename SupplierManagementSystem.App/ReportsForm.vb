Imports MySql.Data.MySqlClient

Public Class ReportsForm
    Private reportTable As DataTable
    Private currentUserRole As String = ""
    Private activationSyncCount As Integer

    Public Sub New(Optional userRole As String = "CLERK")
        InitializeComponent()
        currentUserRole = userRole
    End Sub

    Private Sub ReportsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UiBranding.ApplyModuleHeader(Me, "Reports and Financial Summary")
        LoadReportData()
    End Sub

    Private Sub ReportsForm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        If DesignMode Then
            Return
        End If

        activationSyncCount += 1
        If activationSyncCount = 1 Then
            Return
        End If

        LoadReportData()
        ApplyFilters()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadReportData()
    End Sub

    Private Sub LoadReportData()
        Try
            Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                Dim totalsSql As String = "SELECT IFNULL(SUM(invoice_amount), 0) AS total_invoice_amount, IFNULL((SELECT SUM(amount_paid) FROM payments), 0) AS total_paid_amount FROM supplier_invoices"
                Using totalCmd As New MySqlCommand(totalsSql, conn)
                    Using reader As MySqlDataReader = totalCmd.ExecuteReader()
                        If reader.Read() Then
                            Dim totalInvoices As Decimal = Convert.ToDecimal(reader("total_invoice_amount"))
                            Dim totalPaid As Decimal = Convert.ToDecimal(reader("total_paid_amount"))
                            Dim outstanding As Decimal = totalInvoices - totalPaid

                            lblTotalInvoices.Text = $"Total Invoices: UGX {totalInvoices:N0}"
                            lblTotalPaid.Text = $"Total Paid: UGX {totalPaid:N0}"
                            lblOutstanding.Text = $"Outstanding: UGX {outstanding:N0}"
                        End If
                    End Using
                End Using

                Dim outstandingSql As String = "SELECT s.supplier_name, i.invoice_number, DATE_FORMAT(i.invoice_date, '%Y-%m-%d') AS invoice_date, i.invoice_amount, IFNULL(SUM(p.amount_paid), 0) AS paid_amount, (i.invoice_amount - IFNULL(SUM(p.amount_paid), 0)) AS balance, i.status FROM supplier_invoices i INNER JOIN suppliers s ON s.supplier_id = i.supplier_id LEFT JOIN payments p ON p.invoice_id = i.invoice_id GROUP BY i.invoice_id, s.supplier_name, i.invoice_number, i.invoice_date, i.invoice_amount, i.status ORDER BY balance DESC, i.invoice_date DESC"
                Using adapter As New MySqlDataAdapter(outstandingSql, conn)
                    reportTable = New DataTable()
                    adapter.Fill(reportTable)
                    dgvOutstanding.DataSource = reportTable
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Failed to load report data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ApplyFilters()
    End Sub

    Private Sub cboStatusFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStatusFilter.SelectedIndexChanged
        ApplyFilters()
    End Sub

    Private Sub ApplyFilters()
        If reportTable Is Nothing Then
            Return
        End If

        Dim keyword As String = txtSearch.Text.Trim().Replace("'", "''")
        Dim statusValue As String = If(cboStatusFilter.SelectedItem, "ALL").ToString()
        Dim conditions As New List(Of String)

        If keyword <> "" Then
            conditions.Add($"supplier_name LIKE '%{keyword}%' OR invoice_number LIKE '%{keyword}%'")
        End If

        If statusValue <> "ALL" Then
            conditions.Add($"status = '{statusValue}'")
        End If

        If conditions.Count > 0 Then
            reportTable.DefaultView.RowFilter = String.Join(" AND ", conditions)
        Else
            reportTable.DefaultView.RowFilter = ""
        End If
    End Sub
End Class