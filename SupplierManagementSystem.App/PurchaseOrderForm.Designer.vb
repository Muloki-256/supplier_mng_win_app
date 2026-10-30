<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PurchaseOrderForm
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
        dgvOrders = New DataGridView()
        lblPoNumber = New Label()
        lblSupplier = New Label()
        lblOrderDate = New Label()
        txtPoNumber = New TextBox()
        cboSupplier = New ComboBox()
        dtpOrderDate = New DateTimePicker()
        btnAddOrder = New Button()
        btnDeleteOrder = New Button()
        btnClear = New Button()
        grpOrderItems = New GroupBox()
        btnRemoveItem = New Button()
        btnAddItem = New Button()
        txtUnitPrice = New TextBox()
        nudQuantity = New NumericUpDown()
        cboProduct = New ComboBox()
        lblUnitPrice = New Label()
        lblQuantity = New Label()
        lblProduct = New Label()
        dgvItems = New DataGridView()
        lblOrderTotal = New Label()
        lblSearch = New Label()
        txtSearch = New TextBox()
        btnRefresh = New Button()
        CType(dgvOrders, ComponentModel.ISupportInitialize).BeginInit()
        grpOrderItems.SuspendLayout()
        CType(nudQuantity, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvItems, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblHeader
        ' 
        lblHeader.AutoSize = True
        lblHeader.Font = New Font("Segoe UI", 13.0!, FontStyle.Bold, GraphicsUnit.Point)
        lblHeader.Location = New Point(18, 14)
        lblHeader.Name = "lblHeader"
        lblHeader.Size = New Size(209, 25)
        lblHeader.TabIndex = 0
        lblHeader.Text = "MASAKA AGRI-SUPPLIES LTD - Purchase Orders"
        ' 
        ' dgvOrders
        ' 
        dgvOrders.AllowUserToAddRows = False
        dgvOrders.AllowUserToDeleteRows = False
        dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvOrders.BackgroundColor = Color.White
        dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvOrders.Location = New Point(18, 110)
        dgvOrders.MultiSelect = False
        dgvOrders.Name = "dgvOrders"
        dgvOrders.ReadOnly = True
        dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvOrders.Size = New Size(340, 200)
        dgvOrders.TabIndex = 1
        ' 
        ' lblPoNumber
        ' 
        lblPoNumber.AutoSize = True
        lblPoNumber.Location = New Point(18, 330)
        lblPoNumber.Name = "lblPoNumber"
        lblPoNumber.Size = New Size(69, 15)
        lblPoNumber.TabIndex = 2
        lblPoNumber.Text = "PO Number"
        ' 
        ' lblSupplier
        ' 
        lblSupplier.AutoSize = True
        lblSupplier.Location = New Point(18, 366)
        lblSupplier.Name = "lblSupplier"
        lblSupplier.Size = New Size(50, 15)
        lblSupplier.TabIndex = 3
        lblSupplier.Text = "Supplier"
        ' 
        ' lblOrderDate
        ' 
        lblOrderDate.AutoSize = True
        lblOrderDate.Location = New Point(18, 402)
        lblOrderDate.Name = "lblOrderDate"
        lblOrderDate.Size = New Size(61, 15)
        lblOrderDate.TabIndex = 4
        lblOrderDate.Text = "Order Date"
        ' 
        ' txtPoNumber
        ' 
        txtPoNumber.Location = New Point(120, 326)
        txtPoNumber.Name = "txtPoNumber"
        txtPoNumber.Size = New Size(220, 23)
        txtPoNumber.TabIndex = 5
        ' 
        ' cboSupplier
        ' 
        cboSupplier.DropDownStyle = ComboBoxStyle.DropDownList
        cboSupplier.FormattingEnabled = True
        cboSupplier.Location = New Point(120, 362)
        cboSupplier.Name = "cboSupplier"
        cboSupplier.Size = New Size(220, 23)
        cboSupplier.TabIndex = 6
        ' 
        ' dtpOrderDate
        ' 
        dtpOrderDate.Format = DateTimePickerFormat.Short
        dtpOrderDate.Location = New Point(120, 398)
        dtpOrderDate.Name = "dtpOrderDate"
        dtpOrderDate.Size = New Size(220, 23)
        dtpOrderDate.TabIndex = 7
        ' 
        ' btnAddOrder
        ' 
        btnAddOrder.BackColor = Color.FromArgb(40, 167, 69)
        btnAddOrder.FlatStyle = FlatStyle.Flat
        btnAddOrder.ForeColor = Color.White
        btnAddOrder.Location = New Point(120, 440)
        btnAddOrder.Name = "btnAddOrder"
        btnAddOrder.Size = New Size(100, 34)
        btnAddOrder.TabIndex = 8
        btnAddOrder.Text = "Add Order"
        btnAddOrder.UseVisualStyleBackColor = False
        ' 
        ' btnDeleteOrder
        ' 
        btnDeleteOrder.BackColor = Color.FromArgb(220, 53, 69)
        btnDeleteOrder.FlatStyle = FlatStyle.Flat
        btnDeleteOrder.ForeColor = Color.White
        btnDeleteOrder.Location = New Point(230, 440)
        btnDeleteOrder.Name = "btnDeleteOrder"
        btnDeleteOrder.Size = New Size(100, 34)
        btnDeleteOrder.TabIndex = 9
        btnDeleteOrder.Text = "Delete Order"
        btnDeleteOrder.UseVisualStyleBackColor = False
        ' 
        ' btnClear
        ' 
        btnClear.BackColor = Color.FromArgb(108, 117, 125)
        btnClear.FlatStyle = FlatStyle.Flat
        btnClear.ForeColor = Color.White
        btnClear.Location = New Point(18, 440)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(90, 34)
        btnClear.TabIndex = 10
        btnClear.Text = "Clear"
        btnClear.UseVisualStyleBackColor = False
        ' 
        ' grpOrderItems
        ' 
        grpOrderItems.Controls.Add(btnRemoveItem)
        grpOrderItems.Controls.Add(btnAddItem)
        grpOrderItems.Controls.Add(txtUnitPrice)
        grpOrderItems.Controls.Add(nudQuantity)
        grpOrderItems.Controls.Add(cboProduct)
        grpOrderItems.Controls.Add(lblUnitPrice)
        grpOrderItems.Controls.Add(lblQuantity)
        grpOrderItems.Controls.Add(lblProduct)
        grpOrderItems.Location = New Point(380, 110)
        grpOrderItems.Name = "grpOrderItems"
        grpOrderItems.Size = New Size(420, 150)
        grpOrderItems.TabIndex = 11
        grpOrderItems.TabStop = False
        grpOrderItems.Text = "Order Items"
        ' 
        ' btnRemoveItem
        ' 
        btnRemoveItem.BackColor = Color.FromArgb(220, 53, 69)
        btnRemoveItem.FlatStyle = FlatStyle.Flat
        btnRemoveItem.ForeColor = Color.White
        btnRemoveItem.Location = New Point(210, 105)
        btnRemoveItem.Name = "btnRemoveItem"
        btnRemoveItem.Size = New Size(110, 30)
        btnRemoveItem.TabIndex = 7
        btnRemoveItem.Text = "Remove Item"
        btnRemoveItem.UseVisualStyleBackColor = False
        ' 
        ' btnAddItem
        ' 
        btnAddItem.BackColor = Color.FromArgb(0, 123, 255)
        btnAddItem.FlatStyle = FlatStyle.Flat
        btnAddItem.ForeColor = Color.White
        btnAddItem.Location = New Point(90, 105)
        btnAddItem.Name = "btnAddItem"
        btnAddItem.Size = New Size(110, 30)
        btnAddItem.TabIndex = 6
        btnAddItem.Text = "Add Item"
        btnAddItem.UseVisualStyleBackColor = False
        ' 
        ' txtUnitPrice
        ' 
        txtUnitPrice.Location = New Point(290, 66)
        txtUnitPrice.Name = "txtUnitPrice"
        txtUnitPrice.Size = New Size(110, 23)
        txtUnitPrice.TabIndex = 5
        txtUnitPrice.Text = "0"
        ' 
        ' nudQuantity
        ' 
        nudQuantity.Location = New Point(90, 66)
        nudQuantity.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        nudQuantity.Name = "nudQuantity"
        nudQuantity.Size = New Size(110, 23)
        nudQuantity.TabIndex = 4
        nudQuantity.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' cboProduct
        ' 
        cboProduct.DropDownStyle = ComboBoxStyle.DropDownList
        cboProduct.FormattingEnabled = True
        cboProduct.Location = New Point(90, 26)
        cboProduct.Name = "cboProduct"
        cboProduct.Size = New Size(310, 23)
        cboProduct.TabIndex = 3
        ' 
        ' lblUnitPrice
        ' 
        lblUnitPrice.AutoSize = True
        lblUnitPrice.Location = New Point(220, 70)
        lblUnitPrice.Name = "lblUnitPrice"
        lblUnitPrice.Size = New Size(57, 15)
        lblUnitPrice.TabIndex = 2
        lblUnitPrice.Text = "Unit Price"
        ' 
        ' lblQuantity
        ' 
        lblQuantity.AutoSize = True
        lblQuantity.Location = New Point(16, 70)
        lblQuantity.Name = "lblQuantity"
        lblQuantity.Size = New Size(53, 15)
        lblQuantity.TabIndex = 1
        lblQuantity.Text = "Quantity"
        ' 
        ' lblProduct
        ' 
        lblProduct.AutoSize = True
        lblProduct.Location = New Point(16, 30)
        lblProduct.Name = "lblProduct"
        lblProduct.Size = New Size(49, 15)
        lblProduct.TabIndex = 0
        lblProduct.Text = "Product"
        ' 
        ' dgvItems
        ' 
        dgvItems.AllowUserToAddRows = False
        dgvItems.AllowUserToDeleteRows = False
        dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvItems.BackgroundColor = Color.White
        dgvItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvItems.Location = New Point(380, 270)
        dgvItems.MultiSelect = False
        dgvItems.Name = "dgvItems"
        dgvItems.ReadOnly = True
        dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvItems.Size = New Size(420, 170)
        dgvItems.TabIndex = 12
        ' 
        ' lblOrderTotal
        ' 
        lblOrderTotal.AutoSize = True
        lblOrderTotal.Font = New Font("Segoe UI", 11.0!, FontStyle.Bold, GraphicsUnit.Point)
        lblOrderTotal.ForeColor = Color.FromArgb(40, 167, 69)
        lblOrderTotal.Location = New Point(600, 450)
        lblOrderTotal.Name = "lblOrderTotal"
        lblOrderTotal.Size = New Size(108, 20)
        lblOrderTotal.TabIndex = 13
        lblOrderTotal.Text = "Total: UGX 0"
        ' 
        ' lblSearch
        ' 
        lblSearch.AutoSize = True
        lblSearch.Location = New Point(18, 82)
        lblSearch.Name = "lblSearch"
        lblSearch.Size = New Size(46, 15)
        lblSearch.TabIndex = 14
        lblSearch.Text = "Search:"
        ' 
        ' txtSearch
        ' 
        txtSearch.Location = New Point(78, 78)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(280, 23)
        txtSearch.TabIndex = 15
        ' 
        ' btnRefresh
        ' 
        btnRefresh.BackColor = Color.FromArgb(23, 162, 184)
        btnRefresh.FlatStyle = FlatStyle.Flat
        btnRefresh.ForeColor = Color.White
        btnRefresh.Location = New Point(340, 440)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(100, 34)
        btnRefresh.TabIndex = 16
        btnRefresh.Text = "Refresh"
        btnRefresh.UseVisualStyleBackColor = False
        ' 
        ' PurchaseOrderForm
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(820, 500)
        Controls.Add(btnRefresh)
        Controls.Add(txtSearch)
        Controls.Add(lblSearch)
        Controls.Add(lblOrderTotal)
        Controls.Add(dgvItems)
        Controls.Add(grpOrderItems)
        Controls.Add(btnClear)
        Controls.Add(btnDeleteOrder)
        Controls.Add(btnAddOrder)
        Controls.Add(dtpOrderDate)
        Controls.Add(cboSupplier)
        Controls.Add(txtPoNumber)
        Controls.Add(lblOrderDate)
        Controls.Add(lblSupplier)
        Controls.Add(lblPoNumber)
        Controls.Add(dgvOrders)
        Controls.Add(lblHeader)
        Name = "PurchaseOrderForm"
        StartPosition = FormStartPosition.CenterParent
        Text = "MASAKA AGRI-SUPPLIES LTD - Orders Module"
        CType(dgvOrders, ComponentModel.ISupportInitialize).EndInit()
        grpOrderItems.ResumeLayout(False)
        grpOrderItems.PerformLayout()
        CType(nudQuantity, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvItems, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblHeader As Label
    Friend WithEvents dgvOrders As DataGridView
    Friend WithEvents lblPoNumber As Label
    Friend WithEvents lblSupplier As Label
    Friend WithEvents lblOrderDate As Label
    Friend WithEvents txtPoNumber As TextBox
    Friend WithEvents cboSupplier As ComboBox
    Friend WithEvents dtpOrderDate As DateTimePicker
    Friend WithEvents btnAddOrder As Button
    Friend WithEvents btnDeleteOrder As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents grpOrderItems As GroupBox
    Friend WithEvents btnRemoveItem As Button
    Friend WithEvents btnAddItem As Button
    Friend WithEvents txtUnitPrice As TextBox
    Friend WithEvents nudQuantity As NumericUpDown
    Friend WithEvents cboProduct As ComboBox
    Friend WithEvents lblUnitPrice As Label
    Friend WithEvents lblQuantity As Label
    Friend WithEvents lblProduct As Label
    Friend WithEvents dgvItems As DataGridView
    Friend WithEvents lblOrderTotal As Label
    Friend WithEvents lblSearch As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnRefresh As Button
End Class