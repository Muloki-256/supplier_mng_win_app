<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DashboardForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DashboardForm))
        pnlSidebar = New Panel()
        logoPanel = New Panel()
        picSidebarLogo = New PictureBox()
        lblCompanyName = New Label()
        lblSidebarUserName = New Label()
        lblRole = New Label()
        btnLogout = New Button()
        btnRefresh = New Button()
        btnReports = New Button()
        btnUsers = New Button()
        btnInvoicesPayments = New Button()
        btnDeliveries = New Button()
        btnOrders = New Button()
        btnProducts = New Button()
        btnSuppliers = New Button()
        btnHome = New Button()
        lblOrders = New Label()
        lblProducts = New Label()
        lblSuppliers = New Label()
        pnlContent = New Panel()
        pnlDashboard = New Panel()
        CardRecentOrders = New Panel()
        dgvRecentOrders = New DataGridView()
        lblRecentTitle = New Label()
        CardOutstanding = New Panel()
        lblOutstandingTotal = New Label()
        lblOutstandingTitle = New Label()
        CardInvoices = New Panel()
        lblInvoicesTotal = New Label()
        lblInvoicesTitle = New Label()
        CardOrders = New Panel()
        lblOrdersCount = New Label()
        lblOrdersTitle = New Label()
        CardProducts = New Panel()
        lblProductsCount = New Label()
        lblProductsTitle = New Label()
        CardSuppliers = New Panel()
        lblSuppliersCount = New Label()
        lblSuppliersTitle = New Label()
        lblDate = New Label()
        lblWelcome = New Label()
        pnlSidebar.SuspendLayout()
        logoPanel.SuspendLayout()
        CType(picSidebarLogo, ComponentModel.ISupportInitialize).BeginInit()
        pnlContent.SuspendLayout()
        pnlDashboard.SuspendLayout()
        CardRecentOrders.SuspendLayout()
        CType(dgvRecentOrders, ComponentModel.ISupportInitialize).BeginInit()
        CardOutstanding.SuspendLayout()
        CardInvoices.SuspendLayout()
        CardOrders.SuspendLayout()
        CardProducts.SuspendLayout()
        CardSuppliers.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlSidebar
        ' 
        pnlSidebar.BackColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        pnlSidebar.Controls.Add(logoPanel)
        pnlSidebar.Controls.Add(btnLogout)
        pnlSidebar.Controls.Add(btnRefresh)
        pnlSidebar.Controls.Add(btnReports)
        pnlSidebar.Controls.Add(btnUsers)
        pnlSidebar.Controls.Add(btnInvoicesPayments)
        pnlSidebar.Controls.Add(btnDeliveries)
        pnlSidebar.Controls.Add(btnOrders)
        pnlSidebar.Controls.Add(btnProducts)
        pnlSidebar.Controls.Add(btnHome)
        pnlSidebar.Controls.Add(btnSuppliers)
        pnlSidebar.Controls.Add(lblOrders)
        pnlSidebar.Controls.Add(lblProducts)
        pnlSidebar.Controls.Add(lblSuppliers)
        pnlSidebar.Dock = DockStyle.Left
        pnlSidebar.Location = New Point(0, 0)
        pnlSidebar.Name = "pnlSidebar"
        pnlSidebar.Size = New Size(250, 700)
        pnlSidebar.TabIndex = 0
        ' 
        ' logoPanel
        ' 
        logoPanel.BackColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        logoPanel.Controls.Add(picSidebarLogo)
        logoPanel.Controls.Add(lblCompanyName)
        logoPanel.Controls.Add(lblSidebarUserName)
        logoPanel.Controls.Add(lblRole)
        logoPanel.Location = New Point(0, 0)
        logoPanel.Name = "logoPanel"
        logoPanel.Size = New Size(250, 108)
        logoPanel.TabIndex = 12
        ' 
        ' picSidebarLogo
        ' 
        picSidebarLogo.Image = CType(resources.GetObject("picSidebarLogo.Image"), Image)
        picSidebarLogo.Location = New Point(100, 8)
        picSidebarLogo.Name = "picSidebarLogo"
        picSidebarLogo.Size = New Size(50, 50)
        picSidebarLogo.SizeMode = PictureBoxSizeMode.StretchImage
        picSidebarLogo.TabIndex = 0
        picSidebarLogo.TabStop = False
        ' 
        ' lblCompanyName
        ' 
        lblCompanyName.AutoSize = False
        lblCompanyName.BackColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        lblCompanyName.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold)
        lblCompanyName.ForeColor = Color.White
        lblCompanyName.Location = New Point(10, 58)
        lblCompanyName.Name = "lblCompanyName"
        lblCompanyName.Size = New Size(230, 13)
        lblCompanyName.TabIndex = 1
        lblCompanyName.Text = "MASAKA AGRI-SUPPLIES LTD"
        lblCompanyName.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblSidebarUserName
        ' 
        lblSidebarUserName.BackColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        lblSidebarUserName.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular)
        lblSidebarUserName.ForeColor = Color.WhiteSmoke
        lblSidebarUserName.Location = New Point(10, 74)
        lblSidebarUserName.Name = "lblSidebarUserName"
        lblSidebarUserName.Size = New Size(230, 18)
        lblSidebarUserName.TabIndex = 3
        lblSidebarUserName.Text = "Logged-in user"
        lblSidebarUserName.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblRole
        ' 
        lblRole.AutoSize = False
        lblRole.BackColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        lblRole.Font = New Font("Segoe UI", 8.0F, FontStyle.Italic)
        lblRole.ForeColor = Color.FromArgb(CByte(23), CByte(162), CByte(184))
        lblRole.Location = New Point(10, 94)
        lblRole.Name = "lblRole"
        lblRole.Size = New Size(230, 14)
        lblRole.TabIndex = 2
        lblRole.Text = "Role: ADMIN"
        lblRole.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' btnLogout
        ' 
        btnLogout.BackColor = Color.FromArgb(CByte(220), CByte(53), CByte(69))
        btnLogout.FlatStyle = FlatStyle.Flat
        btnLogout.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnLogout.ForeColor = Color.White
        btnLogout.Location = New Point(15, 640)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(220, 40)
        btnLogout.TabIndex = 11
        btnLogout.Text = "LOGOUT"
        btnLogout.UseVisualStyleBackColor = False
        ' 
        ' btnRefresh
        ' 
        btnRefresh.BackColor = Color.FromArgb(CByte(23), CByte(162), CByte(184))
        btnRefresh.FlatStyle = FlatStyle.Flat
        btnRefresh.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnRefresh.ForeColor = Color.White
        btnRefresh.Location = New Point(15, 580)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(220, 40)
        btnRefresh.TabIndex = 10
        btnRefresh.Text = "REFRESH STATS"
        btnRefresh.UseVisualStyleBackColor = False
        ' 
        ' btnReports
        ' 
        btnReports.BackColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        btnReports.FlatStyle = FlatStyle.Flat
        btnReports.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnReports.ForeColor = Color.White
        btnReports.Location = New Point(15, 401)
        btnReports.Name = "btnReports"
        btnReports.Size = New Size(220, 45)
        btnReports.TabIndex = 9
        btnReports.Text = "REPORTS"
        btnReports.UseVisualStyleBackColor = False
        ' 
        ' btnUsers
        ' 
        btnUsers.BackColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        btnUsers.FlatStyle = FlatStyle.Flat
        btnUsers.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnUsers.ForeColor = Color.White
        btnUsers.Location = New Point(15, 446)
        btnUsers.Name = "btnUsers"
        btnUsers.Size = New Size(220, 45)
        btnUsers.TabIndex = 12
        btnUsers.Text = "USER MANAGEMENT"
        btnUsers.UseVisualStyleBackColor = False
        ' 
        ' btnInvoicesPayments
        ' 
        btnInvoicesPayments.BackColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        btnInvoicesPayments.FlatStyle = FlatStyle.Flat
        btnInvoicesPayments.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnInvoicesPayments.ForeColor = Color.White
        btnInvoicesPayments.Location = New Point(15, 311)
        btnInvoicesPayments.Name = "btnInvoicesPayments"
        btnInvoicesPayments.Size = New Size(220, 45)
        btnInvoicesPayments.TabIndex = 8
        btnInvoicesPayments.Text = "INVOICES & PAYMENTS"
        btnInvoicesPayments.UseVisualStyleBackColor = False
        ' 
        ' btnDeliveries
        ' 
        btnDeliveries.BackColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        btnDeliveries.FlatStyle = FlatStyle.Flat
        btnDeliveries.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnDeliveries.ForeColor = Color.White
        btnDeliveries.Location = New Point(15, 356)
        btnDeliveries.Name = "btnDeliveries"
        btnDeliveries.Size = New Size(220, 45)
        btnDeliveries.TabIndex = 7
        btnDeliveries.Text = "DELIVERIES"
        btnDeliveries.UseVisualStyleBackColor = False
        ' 
        ' btnOrders
        ' 
        btnOrders.BackColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        btnOrders.FlatStyle = FlatStyle.Flat
        btnOrders.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnOrders.ForeColor = Color.White
        btnOrders.Location = New Point(15, 266)
        btnOrders.Name = "btnOrders"
        btnOrders.Size = New Size(220, 45)
        btnOrders.TabIndex = 6
        btnOrders.Text = "PURCHASE ORDERS"
        btnOrders.UseVisualStyleBackColor = False
        ' 
        ' btnProducts
        ' 
        btnProducts.BackColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        btnProducts.FlatStyle = FlatStyle.Flat
        btnProducts.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnProducts.ForeColor = Color.White
        btnProducts.Location = New Point(15, 221)
        btnProducts.Name = "btnProducts"
        btnProducts.Size = New Size(220, 45)
        btnProducts.TabIndex = 5
        btnProducts.Text = "PRODUCTS"
        btnProducts.UseVisualStyleBackColor = False
        ' 
        ' btnHome
        ' 
        btnHome.BackColor = Color.FromArgb(CByte(40), CByte(167), CByte(69))
        btnHome.FlatStyle = FlatStyle.Flat
        btnHome.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnHome.ForeColor = Color.White
        btnHome.Location = New Point(15, 131)
        btnHome.Name = "btnHome"
        btnHome.Size = New Size(220, 45)
        btnHome.TabIndex = 3
        btnHome.Text = "HOME / DASHBOARD"
        btnHome.UseVisualStyleBackColor = False
        ' 
        ' btnSuppliers
        ' 
        btnSuppliers.BackColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        btnSuppliers.FlatStyle = FlatStyle.Flat
        btnSuppliers.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnSuppliers.ForeColor = Color.White
        btnSuppliers.Location = New Point(15, 176)
        btnSuppliers.Name = "btnSuppliers"
        btnSuppliers.Size = New Size(220, 45)
        btnSuppliers.TabIndex = 4
        btnSuppliers.Text = "SUPPLIERS"
        btnSuppliers.UseVisualStyleBackColor = False
        ' 
        ' lblOrders
        ' 
        lblOrders.AutoSize = True
        lblOrders.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        lblOrders.ForeColor = Color.WhiteSmoke
        lblOrders.Location = New Point(15, 540)
        lblOrders.Name = "lblOrders"
        lblOrders.Size = New Size(71, 19)
        lblOrders.TabIndex = 3
        lblOrders.Text = "Orders: 0"
        ' 
        ' lblProducts
        ' 
        lblProducts.AutoSize = True
        lblProducts.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        lblProducts.ForeColor = Color.WhiteSmoke
        lblProducts.Location = New Point(15, 515)
        lblProducts.Name = "lblProducts"
        lblProducts.Size = New Size(84, 19)
        lblProducts.TabIndex = 2
        lblProducts.Text = "Products: 0"
        ' 
        ' lblSuppliers
        ' 
        lblSuppliers.AutoSize = True
        lblSuppliers.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        lblSuppliers.ForeColor = Color.WhiteSmoke
        lblSuppliers.Location = New Point(15, 490)
        lblSuppliers.Name = "lblSuppliers"
        lblSuppliers.Size = New Size(87, 19)
        lblSuppliers.TabIndex = 1
        lblSuppliers.Text = "Suppliers: 0"
        ' 
        ' pnlContent
        ' 
        pnlContent.AutoScroll = True
        pnlContent.BackColor = Color.FromArgb(CByte(240), CByte(242), CByte(245))
        pnlContent.Controls.Add(pnlDashboard)
        pnlContent.Dock = DockStyle.Fill
        pnlContent.Location = New Point(250, 0)
        pnlContent.Name = "pnlContent"
        pnlContent.Size = New Size(950, 700)
        pnlContent.TabIndex = 1
        ' 
        ' pnlDashboard
        ' 
        pnlDashboard.Controls.Add(CardRecentOrders)
        pnlDashboard.Controls.Add(CardOutstanding)
        pnlDashboard.Controls.Add(CardInvoices)
        pnlDashboard.Controls.Add(CardOrders)
        pnlDashboard.Controls.Add(CardProducts)
        pnlDashboard.Controls.Add(CardSuppliers)
        pnlDashboard.Controls.Add(lblDate)
        pnlDashboard.Controls.Add(lblWelcome)
        pnlDashboard.Dock = DockStyle.Fill
        pnlDashboard.Location = New Point(0, 0)
        pnlDashboard.Name = "pnlDashboard"
        pnlDashboard.Padding = New Padding(25)
        pnlDashboard.Size = New Size(950, 700)
        pnlDashboard.TabIndex = 0
        ' 
        ' CardRecentOrders
        ' 
        CardRecentOrders.BackColor = Color.White
        CardRecentOrders.BorderStyle = BorderStyle.FixedSingle
        CardRecentOrders.Controls.Add(dgvRecentOrders)
        CardRecentOrders.Controls.Add(lblRecentTitle)
        CardRecentOrders.Location = New Point(25, 310)
        CardRecentOrders.Name = "CardRecentOrders"
        CardRecentOrders.Size = New Size(725, 320)
        CardRecentOrders.TabIndex = 7
        ' 
        ' dgvRecentOrders
        ' 
        dgvRecentOrders.AllowUserToAddRows = False
        dgvRecentOrders.AllowUserToDeleteRows = False
        dgvRecentOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvRecentOrders.BackgroundColor = Color.White
        dgvRecentOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvRecentOrders.Location = New Point(15, 50)
        dgvRecentOrders.Name = "dgvRecentOrders"
        dgvRecentOrders.ReadOnly = True
        dgvRecentOrders.RowHeadersVisible = False
        dgvRecentOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvRecentOrders.Size = New Size(695, 250)
        dgvRecentOrders.TabIndex = 1
        ' 
        ' lblRecentTitle
        ' 
        lblRecentTitle.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        lblRecentTitle.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        lblRecentTitle.Location = New Point(15, 15)
        lblRecentTitle.Name = "lblRecentTitle"
        lblRecentTitle.Size = New Size(250, 30)
        lblRecentTitle.TabIndex = 0
        lblRecentTitle.Text = "Recent Purchase Orders"
        ' 
        ' CardOutstanding
        ' 
        CardOutstanding.BackColor = Color.FromArgb(CByte(220), CByte(53), CByte(69))
        CardOutstanding.BorderStyle = BorderStyle.FixedSingle
        CardOutstanding.Controls.Add(lblOutstandingTotal)
        CardOutstanding.Controls.Add(lblOutstandingTitle)
        CardOutstanding.Location = New Point(25, 220)
        CardOutstanding.Name = "CardOutstanding"
        CardOutstanding.Size = New Size(380, 70)
        CardOutstanding.TabIndex = 6
        ' 
        ' lblOutstandingTotal
        ' 
        lblOutstandingTotal.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold)
        lblOutstandingTotal.ForeColor = Color.White
        lblOutstandingTotal.Location = New Point(180, 15)
        lblOutstandingTotal.Name = "lblOutstandingTotal"
        lblOutstandingTotal.Size = New Size(190, 40)
        lblOutstandingTotal.TabIndex = 1
        lblOutstandingTotal.Text = "UGX 0"
        lblOutstandingTotal.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' lblOutstandingTitle
        ' 
        lblOutstandingTitle.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        lblOutstandingTitle.ForeColor = Color.White
        lblOutstandingTitle.Location = New Point(15, 15)
        lblOutstandingTitle.Name = "lblOutstandingTitle"
        lblOutstandingTitle.Size = New Size(160, 40)
        lblOutstandingTitle.TabIndex = 0
        lblOutstandingTitle.Text = "Outstanding Balance"
        lblOutstandingTitle.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' CardInvoices
        ' 
        CardInvoices.BackColor = Color.White
        CardInvoices.BorderStyle = BorderStyle.FixedSingle
        CardInvoices.Controls.Add(lblInvoicesTotal)
        CardInvoices.Controls.Add(lblInvoicesTitle)
        CardInvoices.Location = New Point(580, 110)
        CardInvoices.Name = "CardInvoices"
        CardInvoices.Size = New Size(170, 90)
        CardInvoices.TabIndex = 5
        ' 
        ' lblInvoicesTotal
        ' 
        lblInvoicesTotal.Font = New Font("Segoe UI", 14.0F, FontStyle.Bold)
        lblInvoicesTotal.ForeColor = Color.FromArgb(CByte(23), CByte(162), CByte(184))
        lblInvoicesTotal.Location = New Point(10, 45)
        lblInvoicesTotal.Name = "lblInvoicesTotal"
        lblInvoicesTotal.Size = New Size(150, 40)
        lblInvoicesTotal.TabIndex = 1
        lblInvoicesTotal.Text = "UGX 0"
        lblInvoicesTotal.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblInvoicesTitle
        ' 
        lblInvoicesTitle.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        lblInvoicesTitle.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        lblInvoicesTitle.Location = New Point(10, 15)
        lblInvoicesTitle.Name = "lblInvoicesTitle"
        lblInvoicesTitle.Size = New Size(150, 30)
        lblInvoicesTitle.TabIndex = 0
        lblInvoicesTitle.Text = "Total Invoices"
        lblInvoicesTitle.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' CardOrders
        ' 
        CardOrders.BackColor = Color.White
        CardOrders.BorderStyle = BorderStyle.FixedSingle
        CardOrders.Controls.Add(lblOrdersCount)
        CardOrders.Controls.Add(lblOrdersTitle)
        CardOrders.Location = New Point(395, 110)
        CardOrders.Name = "CardOrders"
        CardOrders.Size = New Size(170, 90)
        CardOrders.TabIndex = 4
        ' 
        ' lblOrdersCount
        ' 
        lblOrdersCount.Font = New Font("Segoe UI", 20.0F, FontStyle.Bold)
        lblOrdersCount.ForeColor = Color.FromArgb(CByte(255), CByte(193), CByte(7))
        lblOrdersCount.Location = New Point(10, 45)
        lblOrdersCount.Name = "lblOrdersCount"
        lblOrdersCount.Size = New Size(150, 40)
        lblOrdersCount.TabIndex = 1
        lblOrdersCount.Text = "0"
        lblOrdersCount.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblOrdersTitle
        ' 
        lblOrdersTitle.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        lblOrdersTitle.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        lblOrdersTitle.Location = New Point(10, 15)
        lblOrdersTitle.Name = "lblOrdersTitle"
        lblOrdersTitle.Size = New Size(150, 30)
        lblOrdersTitle.TabIndex = 0
        lblOrdersTitle.Text = "Total Orders"
        lblOrdersTitle.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' CardProducts
        ' 
        CardProducts.BackColor = Color.White
        CardProducts.BorderStyle = BorderStyle.FixedSingle
        CardProducts.Controls.Add(lblProductsCount)
        CardProducts.Controls.Add(lblProductsTitle)
        CardProducts.Location = New Point(210, 110)
        CardProducts.Name = "CardProducts"
        CardProducts.Size = New Size(170, 90)
        CardProducts.TabIndex = 3
        ' 
        ' lblProductsCount
        ' 
        lblProductsCount.Font = New Font("Segoe UI", 20.0F, FontStyle.Bold)
        lblProductsCount.ForeColor = Color.FromArgb(CByte(0), CByte(123), CByte(255))
        lblProductsCount.Location = New Point(10, 45)
        lblProductsCount.Name = "lblProductsCount"
        lblProductsCount.Size = New Size(150, 40)
        lblProductsCount.TabIndex = 1
        lblProductsCount.Text = "0"
        lblProductsCount.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblProductsTitle
        ' 
        lblProductsTitle.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        lblProductsTitle.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        lblProductsTitle.Location = New Point(10, 15)
        lblProductsTitle.Name = "lblProductsTitle"
        lblProductsTitle.Size = New Size(150, 30)
        lblProductsTitle.TabIndex = 0
        lblProductsTitle.Text = "Total Products"
        lblProductsTitle.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' CardSuppliers
        ' 
        CardSuppliers.BackColor = Color.White
        CardSuppliers.BorderStyle = BorderStyle.FixedSingle
        CardSuppliers.Controls.Add(lblSuppliersCount)
        CardSuppliers.Controls.Add(lblSuppliersTitle)
        CardSuppliers.Location = New Point(25, 110)
        CardSuppliers.Name = "CardSuppliers"
        CardSuppliers.Size = New Size(170, 90)
        CardSuppliers.TabIndex = 2
        ' 
        ' lblSuppliersCount
        ' 
        lblSuppliersCount.Font = New Font("Segoe UI", 20.0F, FontStyle.Bold)
        lblSuppliersCount.ForeColor = Color.FromArgb(CByte(40), CByte(167), CByte(69))
        lblSuppliersCount.Location = New Point(10, 45)
        lblSuppliersCount.Name = "lblSuppliersCount"
        lblSuppliersCount.Size = New Size(150, 40)
        lblSuppliersCount.TabIndex = 1
        lblSuppliersCount.Text = "0"
        lblSuppliersCount.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblSuppliersTitle
        ' 
        lblSuppliersTitle.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        lblSuppliersTitle.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        lblSuppliersTitle.Location = New Point(10, 15)
        lblSuppliersTitle.Name = "lblSuppliersTitle"
        lblSuppliersTitle.Size = New Size(150, 30)
        lblSuppliersTitle.TabIndex = 0
        lblSuppliersTitle.Text = "Total Suppliers"
        lblSuppliersTitle.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblDate
        ' 
        lblDate.Font = New Font("Segoe UI", 11.0F)
        lblDate.ForeColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        lblDate.Location = New Point(25, 60)
        lblDate.Name = "lblDate"
        lblDate.Size = New Size(300, 25)
        lblDate.TabIndex = 1
        lblDate.Text = "Monday, May 4, 2026"
        ' 
        ' lblWelcome
        ' 
        lblWelcome.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold)
        lblWelcome.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        lblWelcome.Location = New Point(25, 20)
        lblWelcome.Name = "lblWelcome"
        lblWelcome.Size = New Size(500, 40)
        lblWelcome.TabIndex = 0
        lblWelcome.Text = "Welcome back, Admin!"
        ' 
        ' DashboardForm
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1200, 700)
        Controls.Add(pnlContent)
        Controls.Add(pnlSidebar)
        Name = "DashboardForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "MASAKA AGRI-SUPPLIES LTD - Dashboard"
        WindowState = FormWindowState.Maximized
        pnlSidebar.ResumeLayout(False)
        pnlSidebar.PerformLayout()
        logoPanel.ResumeLayout(False)
        logoPanel.PerformLayout()
        CType(picSidebarLogo, ComponentModel.ISupportInitialize).EndInit()
        pnlContent.ResumeLayout(False)
        pnlDashboard.ResumeLayout(False)
        CardRecentOrders.ResumeLayout(False)
        CType(dgvRecentOrders, ComponentModel.ISupportInitialize).EndInit()
        CardOutstanding.ResumeLayout(False)
        CardInvoices.ResumeLayout(False)
        CardOrders.ResumeLayout(False)
        CardProducts.ResumeLayout(False)
        CardSuppliers.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents logoPanel As Panel
    Friend WithEvents picSidebarLogo As PictureBox
    Friend WithEvents lblCompanyName As Label
    Friend WithEvents lblSidebarUserName As Label
    Friend WithEvents lblRole As Label
    Friend WithEvents pnlContent As Panel
    Friend WithEvents btnHome As Button
    Friend WithEvents btnSuppliers As Button
    Friend WithEvents btnProducts As Button
    Friend WithEvents btnOrders As Button
    Friend WithEvents btnDeliveries As Button
    Friend WithEvents btnInvoicesPayments As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnReports As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents btnUsers As Button
    Friend WithEvents lblSuppliers As Label
    Friend WithEvents lblProducts As Label
    Friend WithEvents lblOrders As Label
    Friend WithEvents pnlDashboard As Panel
    Friend WithEvents lblWelcome As Label
    Friend WithEvents lblDate As Label
    Friend WithEvents CardSuppliers As Panel
    Friend WithEvents lblSuppliersCount As Label
    Friend WithEvents lblSuppliersTitle As Label
    Friend WithEvents CardProducts As Panel
    Friend WithEvents lblProductsCount As Label
    Friend WithEvents lblProductsTitle As Label
    Friend WithEvents CardOrders As Panel
    Friend WithEvents lblOrdersCount As Label
    Friend WithEvents lblOrdersTitle As Label
    Friend WithEvents CardInvoices As Panel
    Friend WithEvents lblInvoicesTotal As Label
    Friend WithEvents lblInvoicesTitle As Label
    Friend WithEvents CardOutstanding As Panel
    Friend WithEvents lblOutstandingTotal As Label
    Friend WithEvents lblOutstandingTitle As Label
    Friend WithEvents CardRecentOrders As Panel
    Friend WithEvents dgvRecentOrders As DataGridView
    Friend WithEvents lblRecentTitle As Label
End Class