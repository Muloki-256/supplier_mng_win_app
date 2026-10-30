<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReportsForm
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
        lblTotalInvoices = New Label()
        lblTotalPaid = New Label()
        lblOutstanding = New Label()
        dgvOutstanding = New DataGridView()
        btnRefresh = New Button()
        lblSearch = New Label()
        txtSearch = New TextBox()
        lblStatus = New Label()
        cboStatusFilter = New ComboBox()
        lblReportTitle = New Label()
        CType(dgvOutstanding, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblHeader
        ' 
        lblHeader.AutoSize = True
        lblHeader.Font = New Font("Segoe UI", 13.0!, FontStyle.Bold, GraphicsUnit.Point)
        lblHeader.Location = New Point(18, 14)
        lblHeader.Name = "lblHeader"
        lblHeader.Size = New Size(444, 25)
        lblHeader.TabIndex = 0
        lblHeader.Text = "MASAKA AGRI-SUPPLIES LTD - Reports Dashboard"
        ' 
        ' lblTotalInvoices
        ' 
        lblTotalInvoices.AutoSize = True
        lblTotalInvoices.Font = New Font("Segoe UI", 10.0!, FontStyle.Bold, GraphicsUnit.Point)
        lblTotalInvoices.Location = New Point(18, 65)
        lblTotalInvoices.Name = "lblTotalInvoices"
        lblTotalInvoices.Size = New Size(149, 19)
        lblTotalInvoices.TabIndex = 1
        lblTotalInvoices.Text = "Total Invoices: UGX 0"
        ' 
        ' lblTotalPaid
        ' 
        lblTotalPaid.AutoSize = True
        lblTotalPaid.Font = New Font("Segoe UI", 10.0!, FontStyle.Bold, GraphicsUnit.Point)
        lblTotalPaid.Location = New Point(280, 65)
        lblTotalPaid.Name = "lblTotalPaid"
        lblTotalPaid.Size = New Size(125, 19)
        lblTotalPaid.TabIndex = 2
        lblTotalPaid.Text = "Total Paid: UGX 0"
        ' 
        ' lblOutstanding
        ' 
        lblOutstanding.AutoSize = True
        lblOutstanding.Font = New Font("Segoe UI", 10.0!, FontStyle.Bold, GraphicsUnit.Point)
        lblOutstanding.Location = New Point(542, 65)
        lblOutstanding.Name = "lblOutstanding"
        lblOutstanding.Size = New Size(139, 19)
        lblOutstanding.TabIndex = 3
        lblOutstanding.Text = "Outstanding: UGX 0"
        ' 
        ' dgvOutstanding
        ' 
        dgvOutstanding.AllowUserToAddRows = False
        dgvOutstanding.AllowUserToDeleteRows = False
        dgvOutstanding.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvOutstanding.BackgroundColor = Color.White
        dgvOutstanding.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvOutstanding.Location = New Point(18, 160)
        dgvOutstanding.Name = "dgvOutstanding"
        dgvOutstanding.ReadOnly = True
        dgvOutstanding.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvOutstanding.Size = New Size(860, 350)
        dgvOutstanding.TabIndex = 4
        ' 
        ' btnRefresh
        ' 
        btnRefresh.BackColor = Color.FromArgb(23, 162, 184)
        btnRefresh.FlatStyle = FlatStyle.Flat
        btnRefresh.ForeColor = Color.White
        btnRefresh.Location = New Point(790, 14)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(88, 30)
        btnRefresh.TabIndex = 5
        btnRefresh.Text = "Refresh"
        btnRefresh.UseVisualStyleBackColor = False
        ' 
        ' lblSearch
        ' 
        lblSearch.AutoSize = True
        lblSearch.Location = New Point(18, 125)
        lblSearch.Name = "lblSearch"
        lblSearch.Size = New Size(46, 15)
        lblSearch.TabIndex = 6
        lblSearch.Text = "Search:"
        ' 
        ' txtSearch
        ' 
        txtSearch.Location = New Point(78, 121)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(250, 23)
        txtSearch.TabIndex = 7
        ' 
        ' lblStatus
        ' 
        lblStatus.AutoSize = True
        lblStatus.Location = New Point(350, 125)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(42, 15)
        lblStatus.TabIndex = 8
        lblStatus.Text = "Status:"
        ' 
        ' cboStatusFilter
        ' 
        cboStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList
        cboStatusFilter.FormattingEnabled = True
        cboStatusFilter.Items.AddRange(New Object() {"ALL", "UNPAID", "PARTIAL", "PAID"})
        cboStatusFilter.Location = New Point(410, 121)
        cboStatusFilter.Name = "cboStatusFilter"
        cboStatusFilter.Size = New Size(150, 23)
        cboStatusFilter.TabIndex = 9
        cboStatusFilter.SelectedIndex = 0
        ' 
        ' lblReportTitle
        ' 
        lblReportTitle.Font = New Font("Segoe UI", 11.0!, FontStyle.Bold, GraphicsUnit.Point)
        lblReportTitle.ForeColor = Color.FromArgb(33, 37, 41)
        lblReportTitle.Location = New Point(18, 95)
        lblReportTitle.Name = "lblReportTitle"
        lblReportTitle.Size = New Size(400, 20)
        lblReportTitle.TabIndex = 10
        lblReportTitle.Text = "Outstanding Invoice Report"
        ' 
        ' ReportsForm
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(900, 530)
        Controls.Add(lblReportTitle)
        Controls.Add(cboStatusFilter)
        Controls.Add(lblStatus)
        Controls.Add(txtSearch)
        Controls.Add(lblSearch)
        Controls.Add(btnRefresh)
        Controls.Add(dgvOutstanding)
        Controls.Add(lblOutstanding)
        Controls.Add(lblTotalPaid)
        Controls.Add(lblTotalInvoices)
        Controls.Add(lblHeader)
        Name = "ReportsForm"
        StartPosition = FormStartPosition.CenterParent
        Text = "MASAKA AGRI-SUPPLIES LTD - Reports"
        CType(dgvOutstanding, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblHeader As Label
    Friend WithEvents lblTotalInvoices As Label
    Friend WithEvents lblTotalPaid As Label
    Friend WithEvents lblOutstanding As Label
    Friend WithEvents dgvOutstanding As DataGridView
    Friend WithEvents btnRefresh As Button
    Friend WithEvents lblSearch As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents lblStatus As Label
    Friend WithEvents cboStatusFilter As ComboBox
    Friend WithEvents lblReportTitle As Label
End Class