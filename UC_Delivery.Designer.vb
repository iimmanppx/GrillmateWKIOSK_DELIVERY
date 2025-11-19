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
        txtItems = New TextBox()
        btnSave = New Button()
        lblPayment = New Label()
        lblStatus = New Label()
        lblCustomer = New Label()
        lblContact = New Label()
        lblAddress = New Label()
        lblItems = New Label()
        pnlStatus = New Panel()
        lblStatusDisplay = New Label()
        WebViewMap = New Microsoft.Web.WebView2.WinForms.WebView2()
        Panel1 = New Panel()
        PB_Logo = New PictureBox()
        Label3 = New Label()
        Label1 = New Label()
        Label4 = New Label()
        cmbFilter = New ComboBox()
        txtSearch = New TextBox()
        cmbSort = New ComboBox()
        Label5 = New Label()
        btnNewEntry = New Button()
        Button1 = New Button()
        CType(dgvDeliveries, ComponentModel.ISupportInitialize).BeginInit()
        grpDetails.SuspendLayout()
        pnlStatus.SuspendLayout()
        CType(WebViewMap, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        CType(PB_Logo, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' dgvDeliveries
        ' 
        dgvDeliveries.AllowUserToDeleteRows = False
        dgvDeliveries.AllowUserToResizeColumns = False
        dgvDeliveries.AllowUserToResizeRows = False
        dgvDeliveries.BackgroundColor = Color.White
        dgvDeliveries.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvDeliveries.Location = New Point(20, 166)
        dgvDeliveries.MultiSelect = False
        dgvDeliveries.Name = "dgvDeliveries"
        dgvDeliveries.ReadOnly = True
        dgvDeliveries.RowHeadersWidth = 51
        dgvDeliveries.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvDeliveries.Size = New Size(896, 250)
        dgvDeliveries.TabIndex = 0
        ' 
        ' grpDetails
        ' 
        grpDetails.Controls.Add(cmbStatus)
        grpDetails.Controls.Add(cmbPayment)
        grpDetails.Controls.Add(txtCustomer)
        grpDetails.Controls.Add(txtContact)
        grpDetails.Controls.Add(txtAddress)
        grpDetails.Controls.Add(txtItems)
        grpDetails.Controls.Add(btnSave)
        grpDetails.Controls.Add(lblPayment)
        grpDetails.Controls.Add(lblStatus)
        grpDetails.Controls.Add(lblCustomer)
        grpDetails.Controls.Add(lblContact)
        grpDetails.Controls.Add(lblAddress)
        grpDetails.Controls.Add(lblItems)
        grpDetails.Location = New Point(20, 476)
        grpDetails.Name = "grpDetails"
        grpDetails.Size = New Size(822, 348)
        grpDetails.TabIndex = 1
        grpDetails.TabStop = False
        grpDetails.Text = "Delivery Details"
        ' 
        ' cmbStatus
        ' 
        cmbStatus.Items.AddRange(New Object() {"Pending", "Delivered", "Failed"})
        cmbStatus.Location = New Point(600, 80)
        cmbStatus.Name = "cmbStatus"
        cmbStatus.Size = New Size(186, 28)
        cmbStatus.TabIndex = 9
        ' 
        ' cmbPayment
        ' 
        cmbPayment.Items.AddRange(New Object() {"Cash on Delivery", "GCash"})
        cmbPayment.Location = New Point(600, 50)
        cmbPayment.Name = "cmbPayment"
        cmbPayment.Size = New Size(186, 28)
        cmbPayment.TabIndex = 10
        ' 
        ' txtCustomer
        ' 
        txtCustomer.Location = New Point(100, 52)
        txtCustomer.Name = "txtCustomer"
        txtCustomer.Size = New Size(385, 27)
        txtCustomer.TabIndex = 12
        ' 
        ' txtContact
        ' 
        txtContact.Location = New Point(100, 82)
        txtContact.Name = "txtContact"
        txtContact.Size = New Size(385, 27)
        txtContact.TabIndex = 13
        ' 
        ' txtAddress
        ' 
        txtAddress.Location = New Point(100, 112)
        txtAddress.Name = "txtAddress"
        txtAddress.Size = New Size(385, 27)
        txtAddress.TabIndex = 14
        ' 
        ' txtItems
        ' 
        txtItems.Location = New Point(100, 142)
        txtItems.Name = "txtItems"
        txtItems.Size = New Size(385, 27)
        txtItems.TabIndex = 15
        ' 
        ' btnSave
        ' 
        btnSave.BackColor = Color.LimeGreen
        btnSave.Font = New Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSave.Location = New Point(89, 275)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(90, 42)
        btnSave.TabIndex = 21
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' lblPayment
        ' 
        lblPayment.Location = New Point(520, 53)
        lblPayment.Name = "lblPayment"
        lblPayment.Size = New Size(100, 23)
        lblPayment.TabIndex = 22
        lblPayment.Text = "Payment:"
        ' 
        ' lblStatus
        ' 
        lblStatus.Location = New Point(520, 83)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(100, 23)
        lblStatus.TabIndex = 23
        lblStatus.Text = "Status:"
        ' 
        ' lblCustomer
        ' 
        lblCustomer.Location = New Point(20, 55)
        lblCustomer.Name = "lblCustomer"
        lblCustomer.Size = New Size(100, 23)
        lblCustomer.TabIndex = 25
        lblCustomer.Text = "Customer:"
        ' 
        ' lblContact
        ' 
        lblContact.Location = New Point(20, 85)
        lblContact.Name = "lblContact"
        lblContact.Size = New Size(100, 23)
        lblContact.TabIndex = 26
        lblContact.Text = "Contact:"
        ' 
        ' lblAddress
        ' 
        lblAddress.Location = New Point(20, 115)
        lblAddress.Name = "lblAddress"
        lblAddress.Size = New Size(100, 23)
        lblAddress.TabIndex = 27
        lblAddress.Text = "Address:"
        ' 
        ' lblItems
        ' 
        lblItems.Location = New Point(20, 145)
        lblItems.Name = "lblItems"
        lblItems.Size = New Size(100, 23)
        lblItems.TabIndex = 28
        lblItems.Text = "Items:"
        ' 
        ' pnlStatus
        ' 
        pnlStatus.BackColor = Color.LightGray
        pnlStatus.BorderStyle = BorderStyle.FixedSingle
        pnlStatus.Controls.Add(lblStatusDisplay)
        pnlStatus.Location = New Point(947, 89)
        pnlStatus.Name = "pnlStatus"
        pnlStatus.Size = New Size(457, 104)
        pnlStatus.TabIndex = 23
        ' 
        ' lblStatusDisplay
        ' 
        lblStatusDisplay.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblStatusDisplay.ForeColor = Color.Black
        lblStatusDisplay.Location = New Point(-1, 0)
        lblStatusDisplay.Name = "lblStatusDisplay"
        lblStatusDisplay.Size = New Size(457, 102)
        lblStatusDisplay.TabIndex = 0
        lblStatusDisplay.Text = "No Delivery Selected"
        lblStatusDisplay.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' WebViewMap
        ' 
        WebViewMap.AllowExternalDrop = True
        WebViewMap.CreationProperties = Nothing
        WebViewMap.DefaultBackgroundColor = Color.White
        WebViewMap.Location = New Point(947, 228)
        WebViewMap.Name = "WebViewMap"
        WebViewMap.Padding = New Padding(3)
        WebViewMap.Size = New Size(457, 539)
        WebViewMap.TabIndex = 2
        WebViewMap.ZoomFactor = 1R
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = SystemColors.ControlDarkDark
        Panel1.Controls.Add(PB_Logo)
        Panel1.Location = New Point(-33, 908)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1781, 254)
        Panel1.TabIndex = 24
        ' 
        ' PB_Logo
        ' 
        PB_Logo.InitialImage = Nothing
        PB_Logo.Location = New Point(1427, 0)
        PB_Logo.Name = "PB_Logo"
        PB_Logo.Size = New Size(283, 136)
        PB_Logo.SizeMode = PictureBoxSizeMode.Zoom
        PB_Logo.TabIndex = 0
        PB_Logo.TabStop = False
        ' 
        ' Label3
        ' 
        Label3.Font = New Font("Times New Roman", 28.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = SystemColors.ActiveCaptionText
        Label3.Location = New Point(20, 20)
        Label3.Name = "Label3"
        Label3.Size = New Size(629, 61)
        Label3.TabIndex = 1
        Label3.Text = "Delivery  Management"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(35, 124)
        Label1.Name = "Label1"
        Label1.Size = New Size(56, 20)
        Label1.TabIndex = 26
        Label1.Text = "Search:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(411, 124)
        Label4.Name = "Label4"
        Label4.Size = New Size(45, 20)
        Label4.TabIndex = 27
        Label4.Text = "FIlter:"
        ' 
        ' cmbFilter
        ' 
        cmbFilter.FormattingEnabled = True
        cmbFilter.Items.AddRange(New Object() {"Pending", "Delivered", "Failed"})
        cmbFilter.Location = New Point(462, 121)
        cmbFilter.Name = "cmbFilter"
        cmbFilter.Size = New Size(187, 28)
        cmbFilter.TabIndex = 28
        ' 
        ' txtSearch
        ' 
        txtSearch.Location = New Point(97, 122)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(273, 27)
        txtSearch.TabIndex = 29
        ' 
        ' cmbSort
        ' 
        cmbSort.FormattingEnabled = True
        cmbSort.Items.AddRange(New Object() {"Newest First", "Oldest First"})
        cmbSort.Location = New Point(753, 120)
        cmbSort.Name = "cmbSort"
        cmbSort.Size = New Size(151, 28)
        cmbSort.TabIndex = 30
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(694, 125)
        Label5.Name = "Label5"
        Label5.Size = New Size(39, 20)
        Label5.TabIndex = 31
        Label5.Text = "Sort:"
        ' 
        ' btnNewEntry
        ' 
        btnNewEntry.BackColor = SystemColors.InactiveCaption
        btnNewEntry.Font = New Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnNewEntry.Location = New Point(20, 422)
        btnNewEntry.Name = "btnNewEntry"
        btnNewEntry.Size = New Size(140, 35)
        btnNewEntry.TabIndex = 32
        btnNewEntry.Text = "Create New Entry"
        btnNewEntry.UseVisualStyleBackColor = False
        ' 
        ' Button1
        ' 
        Button1.BackColor = SystemColors.AppWorkspace
        Button1.Font = New Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button1.Location = New Point(554, 425)
        Button1.Name = "Button1"
        Button1.Size = New Size(121, 29)
        Button1.TabIndex = 33
        Button1.Text = "Create Order"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' UC_Delivery
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BorderStyle = BorderStyle.FixedSingle
        Controls.Add(Button1)
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
        Name = "UC_Delivery"
        Size = New Size(1747, 1124)
        CType(dgvDeliveries, ComponentModel.ISupportInitialize).EndInit()
        grpDetails.ResumeLayout(False)
        grpDetails.PerformLayout()
        pnlStatus.ResumeLayout(False)
        CType(WebViewMap, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        CType(PB_Logo, ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents lblItems As Label
    Friend WithEvents lblPayment As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents WebViewMap As Microsoft.Web.WebView2.WinForms.WebView2
    Friend WithEvents pnlStatus As Panel
    Friend WithEvents lblStatusDisplay As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PB_Logo As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbFilter As ComboBox
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents cmbSort As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnNewEntry As Button
    Friend WithEvents Button1 As Button
End Class
