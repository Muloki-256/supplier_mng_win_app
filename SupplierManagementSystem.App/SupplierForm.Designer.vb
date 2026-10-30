<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SupplierForm
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
        dgvSuppliers = New DataGridView()
        lblName = New Label()
        lblContact = New Label()
        lblPhone = New Label()
        lblLocation = New Label()
        txtSupplierName = New TextBox()
        txtContactPerson = New TextBox()
        txtPhone = New TextBox()
        txtLocation = New TextBox()
        btnAdd = New Button()
        btnUpdate = New Button()
        btnDelete = New Button()
        btnClear = New Button()
        lblSearch = New Label()
        txtSupplierSearch = New TextBox()
        CType(dgvSuppliers, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblHeader
        ' 
        lblHeader.AutoSize = True
        lblHeader.Font = New Font("Segoe UI", 13.0!, FontStyle.Bold, GraphicsUnit.Point)
        lblHeader.Location = New Point(18, 15)
        lblHeader.Name = "lblHeader"
        lblHeader.Size = New Size(216, 25)
        lblHeader.TabIndex = 0
        lblHeader.Text = "MASAKA AGRI-SUPPLIES LTD - Suppliers"
        ' 
        ' dgvSuppliers
        ' 
        dgvSuppliers.AllowUserToAddRows = False
        dgvSuppliers.AllowUserToDeleteRows = False
        dgvSuppliers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvSuppliers.BackgroundColor = Color.White
        dgvSuppliers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvSuppliers.Location = New Point(18, 110)
        dgvSuppliers.MultiSelect = False
        dgvSuppliers.Name = "dgvSuppliers"
        dgvSuppliers.ReadOnly = True
        dgvSuppliers.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvSuppliers.Size = New Size(740, 200)
        dgvSuppliers.TabIndex = 1
        ' 
        ' lblName
        ' 
        lblName.AutoSize = True
        lblName.Location = New Point(20, 330)
        lblName.Name = "lblName"
        lblName.Size = New Size(82, 15)
        lblName.TabIndex = 2
        lblName.Text = "Supplier Name"
        ' 
        ' lblContact
        ' 
        lblContact.AutoSize = True
        lblContact.Location = New Point(20, 366)
        lblContact.Name = "lblContact"
        lblContact.Size = New Size(82, 15)
        lblContact.TabIndex = 3
        lblContact.Text = "Contact Person"
        ' 
        ' lblPhone
        ' 
        lblPhone.AutoSize = True
        lblPhone.Location = New Point(390, 330)
        lblPhone.Name = "lblPhone"
        lblPhone.Size = New Size(41, 15)
        lblPhone.TabIndex = 4
        lblPhone.Text = "Phone"
        ' 
        ' lblLocation
        ' 
        lblLocation.AutoSize = True
        lblLocation.Location = New Point(390, 366)
        lblLocation.Name = "lblLocation"
        lblLocation.Size = New Size(53, 15)
        lblLocation.TabIndex = 5
        lblLocation.Text = "Location"
        ' 
        ' txtSupplierName
        ' 
        txtSupplierName.Location = New Point(120, 326)
        txtSupplierName.Name = "txtSupplierName"
        txtSupplierName.Size = New Size(250, 23)
        txtSupplierName.TabIndex = 6
        ' 
        ' txtContactPerson
        ' 
        txtContactPerson.Location = New Point(120, 362)
        txtContactPerson.Name = "txtContactPerson"
        txtContactPerson.Size = New Size(250, 23)
        txtContactPerson.TabIndex = 7
        ' 
        ' txtPhone
        ' 
        txtPhone.Location = New Point(490, 326)
        txtPhone.Name = "txtPhone"
        txtPhone.Size = New Size(250, 23)
        txtPhone.TabIndex = 8
        ' 
        ' txtLocation
        ' 
        txtLocation.Location = New Point(490, 362)
        txtLocation.Name = "txtLocation"
        txtLocation.Size = New Size(250, 23)
        txtLocation.TabIndex = 9
        ' 
        ' btnAdd
        ' 
        btnAdd.BackColor = Color.FromArgb(40, 167, 69)
        btnAdd.FlatStyle = FlatStyle.Flat
        btnAdd.ForeColor = Color.White
        btnAdd.Location = New Point(120, 410)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(100, 34)
        btnAdd.TabIndex = 10
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
        btnUpdate.TabIndex = 11
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
        btnDelete.TabIndex = 12
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
        btnClear.TabIndex = 13
        btnClear.Text = "Clear"
        btnClear.UseVisualStyleBackColor = False
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
        ' txtSupplierSearch
        ' 
        txtSupplierSearch.Location = New Point(78, 78)
        txtSupplierSearch.Name = "txtSupplierSearch"
        txtSupplierSearch.Size = New Size(300, 23)
        txtSupplierSearch.TabIndex = 15
        ' 
        ' SupplierForm
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(780, 470)
        Controls.Add(txtSupplierSearch)
        Controls.Add(lblSearch)
        Controls.Add(btnClear)
        Controls.Add(btnDelete)
        Controls.Add(btnUpdate)
        Controls.Add(btnAdd)
        Controls.Add(txtLocation)
        Controls.Add(txtPhone)
        Controls.Add(txtContactPerson)
        Controls.Add(txtSupplierName)
        Controls.Add(lblLocation)
        Controls.Add(lblPhone)
        Controls.Add(lblContact)
        Controls.Add(lblName)
        Controls.Add(dgvSuppliers)
        Controls.Add(lblHeader)
        Name = "SupplierForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "MASAKA AGRI-SUPPLIES LTD - Supplier Module"
        CType(dgvSuppliers, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblHeader As Label
    Friend WithEvents dgvSuppliers As DataGridView
    Friend WithEvents lblName As Label
    Friend WithEvents lblContact As Label
    Friend WithEvents lblPhone As Label
    Friend WithEvents lblLocation As Label
    Friend WithEvents txtSupplierName As TextBox
    Friend WithEvents txtContactPerson As TextBox
    Friend WithEvents txtPhone As TextBox
    Friend WithEvents txtLocation As TextBox
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents lblSearch As Label
    Friend WithEvents txtSupplierSearch As TextBox
End Class