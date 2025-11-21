<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UC_Delivery
    Inherits System.Windows.Forms.UserControl

    Private components As System.ComponentModel.IContainer

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

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        dgvDeliveries = New DataGridView()
        grpDetails = New GroupBox()
        cmbStatus = New ComboBox()
        cmbPayment = New ComboBox()
        txtCustomer = New TextBox()
        txtContact = New TextBox()
        txtAddress = New TextBox()
        btnSave = New Button()
        lblPayment = New Label()
        lblStatus = New Label()
        lblCustomer = New Label()
        lblContact = New Label()
        lblAddress = New Label()
        pnlStatus = New Panel()
        lblStatusDisplay = New Label()
        WebViewMap = New Microsoft.Web.WebView2.WinForms.WebView2()
        Panel1 = New Panel()
        Label3 = New Label()
        Label1 = New Label()
        Label4 = New Label()
        cmbFilter = New ComboBox()
        txtSearch = New TextBox()
        cmbSort = New ComboBox()
        Label5 = New Label()
        btnNewEntry = New Button()
        btnCreateOrder = New Button()
        CType(dgvDeliveries, ComponentModel.ISupportInitialize).BeginInit()
        grpDetails.SuspendLayout()
        pnlStatus.SuspendLayout()
        CType(WebViewMap, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' dgvDeliveries
        ' 
        dgvDeliveries.AllowUserToDeleteRows = False
        dgvDeliveries.AllowUserToResizeColumns = False
        dgvDeliveries.AllowUserToResizeRows = False
        dgvDeliveries.BackgroundColor = Color.White
        dgvDeliveries.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvDeliveries.GridColor = Color.Black
        dgvDeliveries.Location = New Point(15, 124)
        dgvDeliveries.Margin = New Padding(3, 2, 3, 2)
        dgvDeliveries.MultiSelect = False
        dgvDeliveries.Name = "dgvDeliveries"
        dgvDeliveries.ReadOnly = True
        dgvDeliveries.RowHeadersWidth = 51
        dgvDeliveries.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvDeliveries.Size = New Size(784, 188)
        dgvDeliveries.TabIndex = 0
        ' 
        ' grpDetails
        ' 
        grpDetails.Controls.Add(cmbStatus)
        grpDetails.Controls.Add(cmbPayment)
        grpDetails.Controls.Add(txtCustomer)
        grpDetails.Controls.Add(txtContact)
        grpDetails.Controls.Add(txtAddress)
        grpDetails.Controls.Add(btnSave)
        grpDetails.Controls.Add(lblPayment)
        grpDetails.Controls.Add(lblStatus)
        grpDetails.Controls.Add(lblCustomer)
        grpDetails.Controls.Add(lblContact)
        grpDetails.Controls.Add(lblAddress)
        grpDetails.Location = New Point(18, 389)
        grpDetails.Margin = New Padding(3, 2, 3, 2)
        grpDetails.Name = "grpDetails"
        grpDetails.Padding = New Padding(3, 2, 3, 2)
        grpDetails.Size = New Size(719, 261)
        grpDetails.TabIndex = 1
        grpDetails.TabStop = False
        grpDetails.Text = "Delivery Details"
        ' 
        ' cmbStatus
        ' 
        cmbStatus.Items.AddRange(New Object() {"Pending", "Delivered", "Failed"})
        cmbStatus.Location = New Point(525, 60)
        cmbStatus.Margin = New Padding(3, 2, 3, 2)
        cmbStatus.Name = "cmbStatus"
        cmbStatus.Size = New Size(163, 23)
        cmbStatus.TabIndex = 9
        ' 
        ' cmbPayment
        ' 
        cmbPayment.Items.AddRange(New Object() {"Cash on Delivery", "GCash"})
        cmbPayment.Location = New Point(525, 38)
        cmbPayment.Margin = New Padding(3, 2, 3, 2)
        cmbPayment.Name = "cmbPayment"
        cmbPayment.Size = New Size(163, 23)
        cmbPayment.TabIndex = 10
        ' 
        ' txtCustomer
        ' 
        txtCustomer.Location = New Point(88, 39)
        txtCustomer.Margin = New Padding(3, 2, 3, 2)
        txtCustomer.Name = "txtCustomer"
        txtCustomer.Size = New Size(337, 23)
        txtCustomer.TabIndex = 12
        ' 
        ' txtContact
        ' 
        txtContact.Location = New Point(88, 62)
        txtContact.Margin = New Padding(3, 2, 3, 2)
        txtContact.Name = "txtContact"
        txtContact.Size = New Size(337, 23)
        txtContact.TabIndex = 13
        ' 
        ' txtAddress
        ' 
        txtAddress.Location = New Point(88, 84)
        txtAddress.Margin = New Padding(3, 2, 3, 2)
        txtAddress.Name = "txtAddress"
        txtAddress.Size = New Size(337, 23)
        txtAddress.TabIndex = 14
        ' 
        ' btnSave
        ' 
        btnSave.BackColor = Color.LimeGreen
        btnSave.Font = New Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSave.Location = New Point(78, 206)
        btnSave.Margin = New Padding(3, 2, 3, 2)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(79, 32)
        btnSave.TabIndex = 21
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' lblPayment
        ' 
        lblPayment.Location = New Point(455, 40)
        lblPayment.Name = "lblPayment"
        lblPayment.Size = New Size(88, 17)
        lblPayment.TabIndex = 22
        lblPayment.Text = "Payment:"
        ' 
        ' lblStatus
        ' 
        lblStatus.Location = New Point(455, 62)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(88, 17)
        lblStatus.TabIndex = 23
        lblStatus.Text = "Status:"
        ' 
        ' lblCustomer
        ' 
        lblCustomer.Location = New Point(18, 41)
        lblCustomer.Name = "lblCustomer"
        lblCustomer.Size = New Size(88, 17)
        lblCustomer.TabIndex = 25
        lblCustomer.Text = "Customer:"
        ' 
        ' lblContact
        ' 
        lblContact.Location = New Point(18, 64)
        lblContact.Name = "lblContact"
        lblContact.Size = New Size(88, 17)
        lblContact.TabIndex = 26
        lblContact.Text = "Contact:"
        ' 
        ' lblAddress
        ' 
        lblAddress.Location = New Point(18, 86)
        lblAddress.Name = "lblAddress"
        lblAddress.Size = New Size(88, 17)
        lblAddress.TabIndex = 27
        lblAddress.Text = "Address:"
        ' 
        ' pnlStatus
        ' 
        pnlStatus.BackColor = Color.LightGray
        pnlStatus.BorderStyle = BorderStyle.FixedSingle
        pnlStatus.Controls.Add(lblStatusDisplay)
        pnlStatus.Location = New Point(829, 67)
        pnlStatus.Margin = New Padding(3, 2, 3, 2)
        pnlStatus.Name = "pnlStatus"
        pnlStatus.Size = New Size(556, 121)
        pnlStatus.TabIndex = 23
        ' 
        ' lblStatusDisplay
        ' 
        lblStatusDisplay.Font = New Font("Microsoft Sans Serif", 21.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblStatusDisplay.ForeColor = Color.Black
        lblStatusDisplay.Location = New Point(-1, 0)
        lblStatusDisplay.Name = "lblStatusDisplay"
        lblStatusDisplay.Size = New Size(556, 119)
        lblStatusDisplay.TabIndex = 0
        lblStatusDisplay.Text = "No Delivery Selected"
        lblStatusDisplay.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' WebViewMap
        ' 
        WebViewMap.AllowExternalDrop = True
        WebViewMap.CreationProperties = Nothing
        WebViewMap.DefaultBackgroundColor = Color.White
        WebViewMap.Location = New Point(829, 225)
        WebViewMap.Margin = New Padding(3, 2, 3, 2)
        WebViewMap.Name = "WebViewMap"
        WebViewMap.Padding = New Padding(3, 2, 3, 2)
        WebViewMap.Size = New Size(556, 459)
        WebViewMap.TabIndex = 2
        WebViewMap.ZoomFactor = 1R
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = SystemColors.ControlDarkDark
        Panel1.Location = New Point(-36, 900)
        Panel1.Margin = New Padding(3, 2, 3, 2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1710, 161)
        Panel1.TabIndex = 24
        ' 
        ' Label3
        ' 
        Label3.Font = New Font("Times New Roman", 28.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = SystemColors.ActiveCaptionText
        Label3.Location = New Point(18, 15)
        Label3.Name = "Label3"
        Label3.Size = New Size(550, 46)
        Label3.TabIndex = 1
        Label3.Text = "Delivery  Management"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(31, 93)
        Label1.Name = "Label1"
        Label1.Size = New Size(45, 15)
        Label1.TabIndex = 26
        Label1.Text = "Search:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(360, 93)
        Label4.Name = "Label4"
        Label4.Size = New Size(36, 15)
        Label4.TabIndex = 27
        Label4.Text = "FIlter:"
        ' 
        ' cmbFilter
        ' 
        cmbFilter.FormattingEnabled = True
        cmbFilter.Items.AddRange(New Object() {"Pending", "Delivered", "Failed"})
        cmbFilter.Location = New Point(404, 91)
        cmbFilter.Margin = New Padding(3, 2, 3, 2)
        cmbFilter.Name = "cmbFilter"
        cmbFilter.Size = New Size(164, 23)
        cmbFilter.TabIndex = 28
        ' 
        ' txtSearch
        ' 
        txtSearch.Location = New Point(85, 92)
        txtSearch.Margin = New Padding(3, 2, 3, 2)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(239, 23)
        txtSearch.TabIndex = 29
        ' 
        ' cmbSort
        ' 
        cmbSort.FormattingEnabled = True
        cmbSort.Items.AddRange(New Object() {"Newest First", "Oldest First"})
        cmbSort.Location = New Point(659, 90)
        cmbSort.Margin = New Padding(3, 2, 3, 2)
        cmbSort.Name = "cmbSort"
        cmbSort.Size = New Size(133, 23)
        cmbSort.TabIndex = 30
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(607, 94)
        Label5.Name = "Label5"
        Label5.Size = New Size(31, 15)
        Label5.TabIndex = 31
        Label5.Text = "Sort:"
        ' 
        ' btnNewEntry
        ' 
        btnNewEntry.BackColor = SystemColors.InactiveCaption
        btnNewEntry.Font = New Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnNewEntry.Location = New Point(18, 319)
        btnNewEntry.Margin = New Padding(3, 2, 3, 2)
        btnNewEntry.Name = "btnNewEntry"
        btnNewEntry.Size = New Size(119, 45)
        btnNewEntry.TabIndex = 32
        btnNewEntry.Text = "Create New Entry"
        btnNewEntry.UseVisualStyleBackColor = False
        ' 
        ' btnCreateOrder
        ' 
        btnCreateOrder.BackColor = SystemColors.AppWorkspace
        btnCreateOrder.Font = New Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCreateOrder.Location = New Point(485, 319)
        btnCreateOrder.Margin = New Padding(3, 2, 3, 2)
        btnCreateOrder.Name = "btnCreateOrder"
        btnCreateOrder.Size = New Size(118, 45)
        btnCreateOrder.TabIndex = 33
        btnCreateOrder.Text = "Create Order"
        btnCreateOrder.UseVisualStyleBackColor = False
        ' 
        ' UC_Delivery
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BorderStyle = BorderStyle.FixedSingle
        Controls.Add(btnCreateOrder)
        Controls.Add(btnNewEntry)
        Controls.Add(Label5)
        Controls.Add(cmbSort)
        Controls.Add(Label3)
        Controls.Add(txtSearch)
        Controls.Add(cmbFilter)
        Controls.Add(Label4)
        Controls.Add(Label1)
        Controls.Add(Panel1)
        Controls.Add(pnlStatus)
        Controls.Add(WebViewMap)
        Controls.Add(dgvDeliveries)
        Controls.Add(grpDetails)
        Margin = New Padding(3, 2, 3, 2)
        Name = "UC_Delivery"
        Size = New Size(1670, 1020)
        CType(dgvDeliveries, ComponentModel.ISupportInitialize).EndInit()
        grpDetails.ResumeLayout(False)
        grpDetails.PerformLayout()
        pnlStatus.ResumeLayout(False)
        CType(WebViewMap, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents dgvDeliveries As DataGridView
    Friend WithEvents grpDetails As GroupBox
    Friend WithEvents txtCustomer As TextBox
    Friend WithEvents txtContact As TextBox
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents txtItems As TextBox
    Friend WithEvents cmbPayment As ComboBox
    Friend WithEvents cmbStatus As ComboBox
    Friend WithEvents btnSave As Button
    Friend WithEvents lblCustomer As Label
    Friend WithEvents lblContact As Label
    Friend WithEvents lblAddress As Label
    Friend WithEvents lblPayment As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents WebViewMap As Microsoft.Web.WebView2.WinForms.WebView2
    Friend WithEvents pnlStatus As Panel
    Friend WithEvents lblStatusDisplay As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbFilter As ComboBox
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents cmbSort As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnNewEntry As Button
    Friend WithEvents btnCreateOrder As Button
End Class
