<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ProductForm
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
        dgvProducts = New DataGridView()
        lblName = New Label()
        lblUnit = New Label()
        lblReorder = New Label()
        txtProductName = New TextBox()
        txtUnit = New TextBox()
        nudReorderLevel = New NumericUpDown()
        btnAdd = New Button()
        btnUpdate = New Button()
        btnDelete = New Button()
        btnClear = New Button()
        lblSearch = New Label()
        txtSearch = New TextBox()
        CType(dgvProducts, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudReorderLevel, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblHeader
        ' 
        lblHeader.AutoSize = True
        lblHeader.Font = New Font("Segoe UI", 13.0!, FontStyle.Bold, GraphicsUnit.Point)
        lblHeader.Location = New Point(18, 14)
        lblHeader.Name = "lblHeader"
        lblHeader.Size = New Size(190, 25)
        lblHeader.TabIndex = 0
        lblHeader.Text = "MASAKA AGRI-SUPPLIES LTD - Products"
        ' 
        ' dgvProducts
        ' 
        dgvProducts.AllowUserToAddRows = False
        dgvProducts.AllowUserToDeleteRows = False
        dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvProducts.BackgroundColor = Color.White
        dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvProducts.Location = New Point(18, 110)
        dgvProducts.MultiSelect = False
        dgvProducts.Name = "dgvProducts"
        dgvProducts.ReadOnly = True
        dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvProducts.Size = New Size(680, 200)
        dgvProducts.TabIndex = 1
        ' 
        ' lblName
        ' 
        lblName.AutoSize = True
        lblName.Location = New Point(18, 330)
        lblName.Name = "lblName"
        lblName.Size = New Size(79, 15)
        lblName.TabIndex = 2
        lblName.Text = "Product Name"
        ' 
        ' lblUnit
        ' 
        lblUnit.AutoSize = True
        lblUnit.Location = New Point(18, 366)
        lblUnit.Name = "lblUnit"
        lblUnit.Size = New Size(29, 15)
        lblUnit.TabIndex = 3
        lblUnit.Text = "Unit"
        ' 
        ' lblReorder
        ' 
        lblReorder.AutoSize = True
        lblReorder.Location = New Point(360, 330)
        lblReorder.Name = "lblReorder"
        lblReorder.Size = New Size(79, 15)
        lblReorder.TabIndex = 4
        lblReorder.Text = "Reorder Level"
        ' 
        ' txtProductName
        ' 
        txtProductName.Location = New Point(120, 326)
        txtProductName.Name = "txtProductName"
        txtProductName.Size = New Size(220, 23)
        txtProductName.TabIndex = 5
        ' 
        ' txtUnit
        ' 
        txtUnit.Location = New Point(120, 362)
        txtUnit.Name = "txtUnit"
        txtUnit.Size = New Size(220, 23)
        txtUnit.TabIndex = 6
        ' 
        ' nudReorderLevel
        ' 
        nudReorderLevel.Location = New Point(472, 326)
        nudReorderLevel.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        nudReorderLevel.Name = "nudReorderLevel"
        nudReorderLevel.Size = New Size(190, 23)
        nudReorderLevel.TabIndex = 7
        nudReorderLevel.Value = New Decimal(New Integer() {10, 0, 0, 0})
        ' 
        ' btnAdd
        ' 
        btnAdd.BackColor = Color.FromArgb(40, 167, 69)
        btnAdd.FlatStyle = FlatStyle.Flat
        btnAdd.ForeColor = Color.White
        btnAdd.Location = New Point(120, 410)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(100, 34)
        btnAdd.TabIndex = 8
        btnAdd.Text = "Add"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' btnUpdate
        ' 
        btnUpdate.BackColor = Color.FromArgb(0, 123, 255)
        btnUpdate.FlatStyle = FlatStyle.Flat
        btnUpdate.ForeColor = Color.White
        btnUpdate.Location = New Point(230, 410)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(100, 34)
        btnUpdate.TabIndex = 9
        btnUpdate.Text = "Update"
        btnUpdate.UseVisualStyleBackColor = False
        ' 
        ' btnDelete
        ' 
        btnDelete.BackColor = Color.FromArgb(220, 53, 69)
        btnDelete.FlatStyle = FlatStyle.Flat
        btnDelete.ForeColor = Color.White
        btnDelete.Location = New Point(340, 410)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(100, 34)
        btnDelete.TabIndex = 10
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = False
        ' 
        ' btnClear
        ' 
        btnClear.BackColor = Color.FromArgb(108, 117, 125)
        btnClear.FlatStyle = FlatStyle.Flat
        btnClear.ForeColor = Color.White
        btnClear.Location = New Point(450, 410)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(100, 34)
        btnClear.TabIndex = 11
        btnClear.Text = "Clear"
        btnClear.UseVisualStyleBackColor = False
        ' 
        ' lblSearch
        ' 
        lblSearch.AutoSize = True
        lblSearch.Location = New Point(18, 82)
        lblSearch.Name = "lblSearch"
        lblSearch.Size = New Size(46, 15)
        lblSearch.TabIndex = 12
        lblSearch.Text = "Search:"
        ' 
        ' txtSearch
        ' 
        txtSearch.Location = New Point(78, 78)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(300, 23)
        txtSearch.TabIndex = 13
        ' 
        ' ProductForm
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(720, 470)
        Controls.Add(txtSearch)
        Controls.Add(lblSearch)
        Controls.Add(btnClear)
        Controls.Add(btnDelete)
        Controls.Add(btnUpdate)
        Controls.Add(btnAdd)
        Controls.Add(nudReorderLevel)
        Controls.Add(txtUnit)
        Controls.Add(txtProductName)
        Controls.Add(lblReorder)
        Controls.Add(lblUnit)
        Controls.Add(lblName)
        Controls.Add(dgvProducts)
        Controls.Add(lblHeader)
        Name = "ProductForm"
        StartPosition = FormStartPosition.CenterParent
        Text = "MASAKA AGRI-SUPPLIES LTD - Product Module"
        CType(dgvProducts, ComponentModel.ISupportInitialize).EndInit()
        CType(nudReorderLevel, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblHeader As Label
    Friend WithEvents dgvProducts As DataGridView
    Friend WithEvents lblName As Label
    Friend WithEvents lblUnit As Label
    Friend WithEvents lblReorder As Label
    Friend WithEvents txtProductName As TextBox
    Friend WithEvents txtUnit As TextBox
    Friend WithEvents nudReorderLevel As NumericUpDown
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents lblSearch As Label
    Friend WithEvents txtSearch As TextBox
End Class