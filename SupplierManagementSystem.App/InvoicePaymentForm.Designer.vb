<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class InvoicePaymentForm
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
        dgvInvoices = New DataGridView()
        dgvPayments = New DataGridView()
        lblSupplier = New Label()
        lblInvoiceNo = New Label()
        lblInvoiceAmount = New Label()
        cboSupplier = New ComboBox()
        txtInvoiceNo = New TextBox()
        txtInvoiceAmount = New TextBox()
        dtpInvoiceDate = New DateTimePicker()
        lblInvoiceDate = New Label()
        btnAddInvoice = New Button()
        lblInvoiceForPayment = New Label()
        cboInvoice = New ComboBox()
        lblPaymentAmount = New Label()
        txtPaymentAmount = New TextBox()
        lblPaymentMethod = New Label()
        cboPaymentMethod = New ComboBox()
        btnAddPayment = New Button()
        dtpPaymentDate = New DateTimePicker()
        lblPaymentDate = New Label()
        lblSearchInvoice = New Label()
        txtSearchInvoice = New TextBox()
        lblSearchPayment = New Label()
        txtSearchPayment = New TextBox()
        btnRefresh = New Button()
        CType(dgvInvoices, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvPayments, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblHeader
        ' 
        lblHeader.AutoSize = True
        lblHeader.Font = New Font("Segoe UI", 13F, FontStyle.Bold)
        lblHeader.Location = New Point(18, 14)
        lblHeader.Name = "lblHeader"
        lblHeader.Size = New Size(458, 25)
        lblHeader.TabIndex = 0
        lblHeader.Text = "MASAKA AGRI-SUPPLIES LTD - Invoices && Payments"
        ' 
        ' dgvInvoices
        ' 
        dgvInvoices.AllowUserToAddRows = False
        dgvInvoices.AllowUserToDeleteRows = False
        dgvInvoices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvInvoices.BackgroundColor = Color.White
        dgvInvoices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvInvoices.Location = New Point(18, 110)
        dgvInvoices.Name = "dgvInvoices"
        dgvInvoices.ReadOnly = True
        dgvInvoices.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvInvoices.Size = New Size(860, 150)
        dgvInvoices.TabIndex = 1
        ' 
        ' dgvPayments
        ' 
        dgvPayments.AllowUserToAddRows = False
        dgvPayments.AllowUserToDeleteRows = False
        dgvPayments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvPayments.BackgroundColor = Color.White
        dgvPayments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvPayments.Location = New Point(18, 430)
        dgvPayments.Name = "dgvPayments"
        dgvPayments.ReadOnly = True
        dgvPayments.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvPayments.Size = New Size(860, 150)
        dgvPayments.TabIndex = 2
        ' 
        ' lblSupplier
        ' 
        lblSupplier.AutoSize = True
        lblSupplier.Location = New Point(18, 280)
        lblSupplier.Name = "lblSupplier"
        lblSupplier.Size = New Size(50, 15)
        lblSupplier.TabIndex = 3
        lblSupplier.Text = "Supplier"
        ' 
        ' lblInvoiceNo
        ' 
        lblInvoiceNo.AutoSize = True
        lblInvoiceNo.Location = New Point(258, 280)
        lblInvoiceNo.Name = "lblInvoiceNo"
        lblInvoiceNo.Size = New Size(92, 15)
        lblInvoiceNo.TabIndex = 4
        lblInvoiceNo.Text = "Invoice Number"
        ' 
        ' lblInvoiceAmount
        ' 
        lblInvoiceAmount.AutoSize = True
        lblInvoiceAmount.Location = New Point(494, 280)
        lblInvoiceAmount.Name = "lblInvoiceAmount"
        lblInvoiceAmount.Size = New Size(92, 15)
        lblInvoiceAmount.TabIndex = 5
        lblInvoiceAmount.Text = "Invoice Amount"
        ' 
        ' cboSupplier
        ' 
        cboSupplier.DropDownStyle = ComboBoxStyle.DropDownList
        cboSupplier.FormattingEnabled = True
        cboSupplier.Location = New Point(78, 276)
        cboSupplier.Name = "cboSupplier"
        cboSupplier.Size = New Size(170, 23)
        cboSupplier.TabIndex = 6
        ' 
        ' txtInvoiceNo
        ' 
        txtInvoiceNo.Location = New Point(356, 276)
        txtInvoiceNo.Name = "txtInvoiceNo"
        txtInvoiceNo.Size = New Size(130, 23)
        txtInvoiceNo.TabIndex = 7
        ' 
        ' txtInvoiceAmount
        ' 
        txtInvoiceAmount.Location = New Point(588, 276)
        txtInvoiceAmount.Name = "txtInvoiceAmount"
        txtInvoiceAmount.Size = New Size(130, 23)
        txtInvoiceAmount.TabIndex = 8
        ' 
        ' dtpInvoiceDate
        ' 
        dtpInvoiceDate.Format = DateTimePickerFormat.Short
        dtpInvoiceDate.Location = New Point(78, 312)
        dtpInvoiceDate.Name = "dtpInvoiceDate"
        dtpInvoiceDate.Size = New Size(170, 23)
        dtpInvoiceDate.TabIndex = 9
        ' 
        ' lblInvoiceDate
        ' 
        lblInvoiceDate.AutoSize = True
        lblInvoiceDate.Location = New Point(18, 316)
        lblInvoiceDate.Name = "lblInvoiceDate"
        lblInvoiceDate.Size = New Size(72, 15)
        lblInvoiceDate.TabIndex = 10
        lblInvoiceDate.Text = "Invoice Date"
        ' 
        ' btnAddInvoice
        ' 
        btnAddInvoice.BackColor = Color.FromArgb(CByte(40), CByte(167), CByte(69))
        btnAddInvoice.FlatStyle = FlatStyle.Flat
        btnAddInvoice.ForeColor = Color.White
        btnAddInvoice.Location = New Point(728, 276)
        btnAddInvoice.Name = "btnAddInvoice"
        btnAddInvoice.Size = New Size(150, 30)
        btnAddInvoice.TabIndex = 11
        btnAddInvoice.Text = "Add Invoice"
        btnAddInvoice.UseVisualStyleBackColor = False
        ' 
        ' lblInvoiceForPayment
        ' 
        lblInvoiceForPayment.AutoSize = True
        lblInvoiceForPayment.Location = New Point(18, 360)
        lblInvoiceForPayment.Name = "lblInvoiceForPayment"
        lblInvoiceForPayment.Size = New Size(121, 15)
        lblInvoiceForPayment.TabIndex = 12
        lblInvoiceForPayment.Text = "Invoice (for payment)"
        ' 
        ' cboInvoice
        ' 
        cboInvoice.DropDownStyle = ComboBoxStyle.DropDownList
        cboInvoice.FormattingEnabled = True
        cboInvoice.Location = New Point(150, 356)
        cboInvoice.Name = "cboInvoice"
        cboInvoice.Size = New Size(180, 23)
        cboInvoice.TabIndex = 13
        ' 
        ' lblPaymentAmount
        ' 
        lblPaymentAmount.AutoSize = True
        lblPaymentAmount.Location = New Point(344, 360)
        lblPaymentAmount.Name = "lblPaymentAmount"
        lblPaymentAmount.Size = New Size(101, 15)
        lblPaymentAmount.TabIndex = 14
        lblPaymentAmount.Text = "Payment Amount"
        ' 
        ' txtPaymentAmount
        ' 
        txtPaymentAmount.Location = New Point(444, 356)
        txtPaymentAmount.Name = "txtPaymentAmount"
        txtPaymentAmount.Size = New Size(120, 23)
        txtPaymentAmount.TabIndex = 15
        ' 
        ' lblPaymentMethod
        ' 
        lblPaymentMethod.AutoSize = True
        lblPaymentMethod.Location = New Point(574, 360)
        lblPaymentMethod.Name = "lblPaymentMethod"
        lblPaymentMethod.Size = New Size(99, 15)
        lblPaymentMethod.TabIndex = 16
        lblPaymentMethod.Text = "Payment Method"
        ' 
        ' cboPaymentMethod
        ' 
        cboPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList
        cboPaymentMethod.FormattingEnabled = True
        cboPaymentMethod.Items.AddRange(New Object() {"CASH", "MOBILE_MONEY", "BANK_TRANSFER"})
        cboPaymentMethod.Location = New Point(674, 356)
        cboPaymentMethod.Name = "cboPaymentMethod"
        cboPaymentMethod.Size = New Size(130, 23)
        cboPaymentMethod.TabIndex = 17
        ' 
        ' btnAddPayment
        ' 
        btnAddPayment.BackColor = Color.FromArgb(CByte(0), CByte(123), CByte(255))
        btnAddPayment.FlatStyle = FlatStyle.Flat
        btnAddPayment.ForeColor = Color.White
        btnAddPayment.Location = New Point(814, 354)
        btnAddPayment.Name = "btnAddPayment"
        btnAddPayment.Size = New Size(64, 27)
        btnAddPayment.TabIndex = 18
        btnAddPayment.Text = "Add"
        btnAddPayment.UseVisualStyleBackColor = False
        ' 
        ' dtpPaymentDate
        ' 
        dtpPaymentDate.Format = DateTimePickerFormat.Short
        dtpPaymentDate.Location = New Point(150, 392)
        dtpPaymentDate.Name = "dtpPaymentDate"
        dtpPaymentDate.Size = New Size(180, 23)
        dtpPaymentDate.TabIndex = 19
        ' 
        ' lblPaymentDate
        ' 
        lblPaymentDate.AutoSize = True
        lblPaymentDate.Location = New Point(18, 396)
        lblPaymentDate.Name = "lblPaymentDate"
        lblPaymentDate.Size = New Size(81, 15)
        lblPaymentDate.TabIndex = 20
        lblPaymentDate.Text = "Payment Date"
        ' 
        ' lblSearchInvoice
        ' 
        lblSearchInvoice.AutoSize = True
        lblSearchInvoice.Location = New Point(18, 82)
        lblSearchInvoice.Name = "lblSearchInvoice"
        lblSearchInvoice.Size = New Size(91, 15)
        lblSearchInvoice.TabIndex = 21
        lblSearchInvoice.Text = "Search Invoices:"
        ' 
        ' txtSearchInvoice
        ' 
        txtSearchInvoice.Location = New Point(120, 78)
        txtSearchInvoice.Name = "txtSearchInvoice"
        txtSearchInvoice.Size = New Size(300, 23)
        txtSearchInvoice.TabIndex = 22
        ' 
        ' lblSearchPayment
        ' 
        lblSearchPayment.AutoSize = True
        lblSearchPayment.Location = New Point(426, 396)
        lblSearchPayment.Name = "lblSearchPayment"
        lblSearchPayment.Size = New Size(100, 15)
        lblSearchPayment.TabIndex = 23
        lblSearchPayment.Text = "Search Payments:"
        ' 
        ' txtSearchPayment
        ' 
        txtSearchPayment.Location = New Point(578, 392)
        txtSearchPayment.Name = "txtSearchPayment"
        txtSearchPayment.Size = New Size(300, 23)
        txtSearchPayment.TabIndex = 24
        ' 
        ' btnRefresh
        ' 
        btnRefresh.BackColor = Color.FromArgb(CByte(23), CByte(162), CByte(184))
        btnRefresh.FlatStyle = FlatStyle.Flat
        btnRefresh.ForeColor = Color.White
        btnRefresh.Location = New Point(728, 320)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(150, 30)
        btnRefresh.TabIndex = 25
        btnRefresh.Text = "Refresh"
        btnRefresh.UseVisualStyleBackColor = False
        ' 
        ' InvoicePaymentForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(900, 600)
        Controls.Add(btnRefresh)
        Controls.Add(txtSearchPayment)
        Controls.Add(lblSearchPayment)
        Controls.Add(txtSearchInvoice)
        Controls.Add(lblSearchInvoice)
        Controls.Add(lblPaymentDate)
        Controls.Add(dtpPaymentDate)
        Controls.Add(btnAddPayment)
        Controls.Add(cboPaymentMethod)
        Controls.Add(lblPaymentMethod)
        Controls.Add(txtPaymentAmount)
        Controls.Add(lblPaymentAmount)
        Controls.Add(cboInvoice)
        Controls.Add(lblInvoiceForPayment)
        Controls.Add(btnAddInvoice)
        Controls.Add(lblInvoiceDate)
        Controls.Add(dtpInvoiceDate)
        Controls.Add(txtInvoiceAmount)
        Controls.Add(txtInvoiceNo)
        Controls.Add(cboSupplier)
        Controls.Add(lblInvoiceAmount)
        Controls.Add(lblInvoiceNo)
        Controls.Add(lblSupplier)
        Controls.Add(dgvPayments)
        Controls.Add(dgvInvoices)
        Controls.Add(lblHeader)
        Name = "InvoicePaymentForm"
        StartPosition = FormStartPosition.CenterParent
        Text = "MASAKA AGRI-SUPPLIES LTD - Finance Module"
        CType(dgvInvoices, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvPayments, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblHeader As Label
    Friend WithEvents dgvInvoices As DataGridView
    Friend WithEvents dgvPayments As DataGridView
    Friend WithEvents lblSupplier As Label
    Friend WithEvents lblInvoiceNo As Label
    Friend WithEvents lblInvoiceAmount As Label
    Friend WithEvents cboSupplier As ComboBox
    Friend WithEvents txtInvoiceNo As TextBox
    Friend WithEvents txtInvoiceAmount As TextBox
    Friend WithEvents dtpInvoiceDate As DateTimePicker
    Friend WithEvents lblInvoiceDate As Label
    Friend WithEvents btnAddInvoice As Button
    Friend WithEvents lblInvoiceForPayment As Label
    Friend WithEvents cboInvoice As ComboBox
    Friend WithEvents lblPaymentAmount As Label
    Friend WithEvents txtPaymentAmount As TextBox
    Friend WithEvents lblPaymentMethod As Label
    Friend WithEvents cboPaymentMethod As ComboBox
    Friend WithEvents btnAddPayment As Button
    Friend WithEvents dtpPaymentDate As DateTimePicker
    Friend WithEvents lblPaymentDate As Label
    Friend WithEvents lblSearchInvoice As Label
    Friend WithEvents txtSearchInvoice As TextBox
    Friend WithEvents lblSearchPayment As Label
    Friend WithEvents txtSearchPayment As TextBox
    Friend WithEvents btnRefresh As Button
End Class