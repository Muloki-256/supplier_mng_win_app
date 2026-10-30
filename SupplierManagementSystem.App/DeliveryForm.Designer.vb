<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DeliveryForm
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
        dgvDeliveries = New DataGridView()
        lblOrder = New Label()
        lblDate = New Label()
        lblStatus = New Label()
        lblRemarks = New Label()
        cboOrder = New ComboBox()
        dtpDeliveryDate = New DateTimePicker()
        cboStatus = New ComboBox()
        txtRemarks = New TextBox()
        btnAdd = New Button()
        btnDelete = New Button()
        btnRefresh = New Button()
        lblSearch = New Label()
        txtSearch = New TextBox()
        CType(dgvDeliveries, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblHeader
        ' 
        lblHeader.AutoSize = True
        lblHeader.Font = New Font("Segoe UI", 13F, FontStyle.Bold)
        lblHeader.Location = New Point(18, 14)
        lblHeader.Name = "lblHeader"
        lblHeader.Size = New Size(363, 25)
        lblHeader.TabIndex = 0
        lblHeader.Text = "MASAKA AGRI-SUPPLIES LTD - Deliveries"
        ' 
        ' dgvDeliveries
        ' 
        dgvDeliveries.AllowUserToAddRows = False
        dgvDeliveries.AllowUserToDeleteRows = False
        dgvDeliveries.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvDeliveries.BackgroundColor = Color.White
        dgvDeliveries.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvDeliveries.Location = New Point(18, 110)
        dgvDeliveries.MultiSelect = False
        dgvDeliveries.Name = "dgvDeliveries"
        dgvDeliveries.ReadOnly = True
        dgvDeliveries.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvDeliveries.Size = New Size(760, 200)
        dgvDeliveries.TabIndex = 1
        ' 
        ' lblOrder
        ' 
        lblOrder.AutoSize = True
        lblOrder.Location = New Point(18, 330)
        lblOrder.Name = "lblOrder"
        lblOrder.Size = New Size(71, 15)
        lblOrder.TabIndex = 2
        lblOrder.Text = "Order (PO#)"
        ' 
        ' lblDate
        ' 
        lblDate.AutoSize = True
        lblDate.Location = New Point(18, 366)
        lblDate.Name = "lblDate"
        lblDate.Size = New Size(76, 15)
        lblDate.TabIndex = 3
        lblDate.Text = "Delivery Date"
        ' 
        ' lblStatus
        ' 
        lblStatus.AutoSize = True
        lblStatus.Location = New Point(390, 330)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(39, 15)
        lblStatus.TabIndex = 4
        lblStatus.Text = "Status"
        ' 
        ' lblRemarks
        ' 
        lblRemarks.AutoSize = True
        lblRemarks.Location = New Point(390, 366)
        lblRemarks.Name = "lblRemarks"
        lblRemarks.Size = New Size(52, 15)
        lblRemarks.TabIndex = 5
        lblRemarks.Text = "Remarks"
        ' 
        ' cboOrder
        ' 
        cboOrder.DropDownStyle = ComboBoxStyle.DropDownList
        cboOrder.FormattingEnabled = True
        cboOrder.Location = New Point(120, 326)
        cboOrder.Name = "cboOrder"
        cboOrder.Size = New Size(250, 23)
        cboOrder.TabIndex = 6
        ' 
        ' dtpDeliveryDate
        ' 
        dtpDeliveryDate.Format = DateTimePickerFormat.Short
        dtpDeliveryDate.Location = New Point(120, 362)
        dtpDeliveryDate.Name = "dtpDeliveryDate"
        dtpDeliveryDate.Size = New Size(250, 23)
        dtpDeliveryDate.TabIndex = 7
        ' 
        ' cboStatus
        ' 
        cboStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cboStatus.FormattingEnabled = True
        cboStatus.Items.AddRange(New Object() {"COMPLETE", "PARTIAL", "PENDING"})
        cboStatus.Location = New Point(490, 326)
        cboStatus.Name = "cboStatus"
        cboStatus.Size = New Size(150, 23)
        cboStatus.TabIndex = 8
        ' 
        ' txtRemarks
        ' 
        txtRemarks.Location = New Point(490, 362)
        txtRemarks.Name = "txtRemarks"
        txtRemarks.Size = New Size(288, 23)
        txtRemarks.TabIndex = 9
        ' 
        ' btnAdd
        ' 
        btnAdd.BackColor = Color.FromArgb(CByte(40), CByte(167), CByte(69))
        btnAdd.FlatStyle = FlatStyle.Flat
        btnAdd.ForeColor = Color.White
        btnAdd.Location = New Point(120, 410)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(100, 34)
        btnAdd.TabIndex = 10
        btnAdd.Text = "Add Delivery"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' btnDelete
        ' 
        btnDelete.BackColor = Color.FromArgb(CByte(220), CByte(53), CByte(69))
        btnDelete.FlatStyle = FlatStyle.Flat
        btnDelete.ForeColor = Color.White
        btnDelete.Location = New Point(230, 410)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(100, 34)
        btnDelete.TabIndex = 11
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = False
        ' 
        ' btnRefresh
        ' 
        btnRefresh.BackColor = Color.FromArgb(CByte(23), CByte(162), CByte(184))
        btnRefresh.FlatStyle = FlatStyle.Flat
        btnRefresh.ForeColor = Color.White
        btnRefresh.Location = New Point(340, 410)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(100, 34)
        btnRefresh.TabIndex = 12
        btnRefresh.Text = "Refresh"
        btnRefresh.UseVisualStyleBackColor = False
        ' 
        ' lblSearch
        ' 
        lblSearch.AutoSize = True
        lblSearch.Location = New Point(18, 82)
        lblSearch.Name = "lblSearch"
        lblSearch.Size = New Size(45, 15)
        lblSearch.TabIndex = 13
        lblSearch.Text = "Search:"
        ' 
        ' txtSearch
        ' 
        txtSearch.Location = New Point(78, 78)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(300, 23)
        txtSearch.TabIndex = 14
        ' 
        ' DeliveryForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 470)
        Controls.Add(txtSearch)
        Controls.Add(lblSearch)
        Controls.Add(btnRefresh)
        Controls.Add(btnDelete)
        Controls.Add(btnAdd)
        Controls.Add(txtRemarks)
        Controls.Add(cboStatus)
        Controls.Add(dtpDeliveryDate)
        Controls.Add(cboOrder)
        Controls.Add(lblRemarks)
        Controls.Add(lblStatus)
        Controls.Add(lblDate)
        Controls.Add(lblOrder)
        Controls.Add(dgvDeliveries)
        Controls.Add(lblHeader)
        Name = "DeliveryForm"
        StartPosition = FormStartPosition.CenterParent
        Text = "MASAKA AGRI-SUPPLIES LTD - Delivery Module"
        CType(dgvDeliveries, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblHeader As Label
    Friend WithEvents dgvDeliveries As DataGridView
    Friend WithEvents lblOrder As Label
    Friend WithEvents lblDate As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblRemarks As Label
    Friend WithEvents cboOrder As ComboBox
    Friend WithEvents dtpDeliveryDate As DateTimePicker
    Friend WithEvents cboStatus As ComboBox
    Friend WithEvents txtRemarks As TextBox
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents lblSearch As Label
    Friend WithEvents txtSearch As TextBox
End Class