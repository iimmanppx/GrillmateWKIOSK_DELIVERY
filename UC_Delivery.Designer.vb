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
        components = New ComponentModel.Container()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UC_Delivery))
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
        pnlMapBorder = New Panel()
        lblMapPlaceholder = New Label()
        Panel1 = New Panel()
        PictureBox1 = New PictureBox()
        Label3 = New Label()
        Label1 = New Label()
        Label4 = New Label()
        cmbFilter = New ComboBox()
        txtSearch = New TextBox()
        cmbSort = New ComboBox()
        Label5 = New Label()
        btnNewEntry = New Button()
        btnCreateOrder = New Button()
        lblSearchIcon = New Label()
        lblFilterIcon = New Label()
        lblSortIcon = New Label()
        ToolTip1 = New ToolTip(components)
        CType(dgvDeliveries, ComponentModel.ISupportInitialize).BeginInit()
        grpDetails.SuspendLayout()
        pnlStatus.SuspendLayout()
        CType(WebViewMap, ComponentModel.ISupportInitialize).BeginInit()
        pnlMapBorder.SuspendLayout()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' dgvDeliveries
        ' 
        dgvDeliveries.AllowUserToDeleteRows = False
        dgvDeliveries.AllowUserToResizeColumns = False
        dgvDeliveries.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(250), CByte(250), CByte(250))
        DataGridViewCellStyle1.ForeColor = Color.FromArgb(CByte(60), CByte(60), CByte(60))
        dgvDeliveries.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        dgvDeliveries.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvDeliveries.BackgroundColor = Color.White
        dgvDeliveries.BorderStyle = BorderStyle.None
        dgvDeliveries.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.WhiteSmoke
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = Color.FromArgb(CByte(60), CByte(60), CByte(60))
        dgvDeliveries.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        dgvDeliveries.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = SystemColors.Window
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 9.0F)
        DataGridViewCellStyle3.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(CByte(39), CByte(174), CByte(96))
        DataGridViewCellStyle3.SelectionForeColor = Color.White
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.False
        dgvDeliveries.DefaultCellStyle = DataGridViewCellStyle3
        dgvDeliveries.EnableHeadersVisualStyles = False
        dgvDeliveries.GridColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        dgvDeliveries.Location = New Point(32, 164)
        dgvDeliveries.Margin = New Padding(3, 2, 3, 2)
        dgvDeliveries.MultiSelect = False
        dgvDeliveries.Name = "dgvDeliveries"
        dgvDeliveries.ReadOnly = True
        dgvDeliveries.RowHeadersVisible = False
        dgvDeliveries.RowTemplate.Height = 32
        dgvDeliveries.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvDeliveries.Size = New Size(780, 420)
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
        grpDetails.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        grpDetails.Location = New Point(820, 164)
        grpDetails.Margin = New Padding(3, 2, 3, 2)
        grpDetails.Name = "grpDetails"
        grpDetails.Padding = New Padding(12)
        grpDetails.Size = New Size(830, 216)
        grpDetails.TabIndex = 1
        grpDetails.TabStop = False
        grpDetails.Text = "Delivery Details"
        ' 
        ' cmbStatus
        ' 
        cmbStatus.Font = New Font("Segoe UI", 9.0F)
        cmbStatus.Items.AddRange(New Object() {"Pending", "Delivered", "Failed"})
        cmbStatus.Location = New Point(620, 68)
        cmbStatus.Margin = New Padding(3, 2, 3, 2)
        cmbStatus.Name = "cmbStatus"
        cmbStatus.Size = New Size(180, 23)
        cmbStatus.TabIndex = 9
        ' 
        ' cmbPayment
        ' 
        cmbPayment.Font = New Font("Segoe UI", 9.0F)
        cmbPayment.Items.AddRange(New Object() {"Cash on Delivery", "GCash"})
        cmbPayment.Location = New Point(620, 36)
        cmbPayment.Margin = New Padding(3, 2, 3, 2)
        cmbPayment.Name = "cmbPayment"
        cmbPayment.Size = New Size(180, 23)
        cmbPayment.TabIndex = 10
        ' 
        ' txtCustomer
        ' 
        txtCustomer.BorderStyle = BorderStyle.FixedSingle
        txtCustomer.Font = New Font("Segoe UI", 9.0F)
        txtCustomer.Location = New Point(110, 38)
        txtCustomer.Margin = New Padding(3, 2, 3, 2)
        txtCustomer.Name = "txtCustomer"
        txtCustomer.Size = New Size(375, 23)
        txtCustomer.TabIndex = 12
        ' 
        ' txtContact
        ' 
        txtContact.BorderStyle = BorderStyle.FixedSingle
        txtContact.Font = New Font("Segoe UI", 9.0F)
        txtContact.Location = New Point(110, 74)
        txtContact.Margin = New Padding(3, 2, 3, 2)
        txtContact.Name = "txtContact"
        txtContact.Size = New Size(280, 23)
        txtContact.TabIndex = 13
        ' 
        ' txtAddress
        ' 
        txtAddress.BorderStyle = BorderStyle.FixedSingle
        txtAddress.Font = New Font("Segoe UI", 9.0F)
        txtAddress.Location = New Point(110, 108)
        txtAddress.Margin = New Padding(3, 2, 3, 2)
        txtAddress.Name = "txtAddress"
        txtAddress.Size = New Size(375, 23)
        txtAddress.TabIndex = 14
        ' 
        ' btnSave
        ' 
        btnSave.BackColor = Color.FromArgb(CByte(39), CByte(174), CByte(96))
        btnSave.Cursor = Cursors.Hand
        btnSave.FlatAppearance.BorderColor = Color.FromArgb(CByte(30), CByte(130), CByte(76))
        btnSave.FlatAppearance.BorderSize = 0
        btnSave.FlatStyle = FlatStyle.Flat
        btnSave.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnSave.ForeColor = Color.White
        btnSave.Location = New Point(110, 150)
        btnSave.Margin = New Padding(3, 2, 3, 2)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(120, 36)
        btnSave.TabIndex = 21
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' lblPayment
        ' 
        lblPayment.Font = New Font("Segoe UI", 9.0F)
        lblPayment.ForeColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        lblPayment.Location = New Point(545, 36)
        lblPayment.Name = "lblPayment"
        lblPayment.Size = New Size(68, 23)
        lblPayment.TabIndex = 22
        lblPayment.Text = "Payment:"
        ' 
        ' lblStatus
        ' 
        lblStatus.Font = New Font("Segoe UI", 9.0F)
        lblStatus.ForeColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        lblStatus.Location = New Point(545, 71)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(68, 23)
        lblStatus.TabIndex = 23
        lblStatus.Text = "Status:"
        ' 
        ' lblCustomer
        ' 
        lblCustomer.Font = New Font("Segoe UI", 9.0F)
        lblCustomer.ForeColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        lblCustomer.Location = New Point(18, 36)
        lblCustomer.Name = "lblCustomer"
        lblCustomer.Size = New Size(80, 23)
        lblCustomer.TabIndex = 25
        lblCustomer.Text = "Customer:"
        ' 
        ' lblContact
        ' 
        lblContact.Font = New Font("Segoe UI", 9.0F)
        lblContact.ForeColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        lblContact.Location = New Point(18, 72)
        lblContact.Name = "lblContact"
        lblContact.Size = New Size(80, 23)
        lblContact.TabIndex = 26
        lblContact.Text = "Contact:"
        ' 
        ' lblAddress
        ' 
        lblAddress.Font = New Font("Segoe UI", 9.0F)
        lblAddress.ForeColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        lblAddress.Location = New Point(18, 108)
        lblAddress.Name = "lblAddress"
        lblAddress.Size = New Size(80, 23)
        lblAddress.TabIndex = 27
        lblAddress.Text = "Address:"
        ' 
        ' pnlStatus
        ' 
        pnlStatus.BackColor = Color.LightGray
        pnlStatus.BorderStyle = BorderStyle.FixedSingle
        pnlStatus.Controls.Add(lblStatusDisplay)
        pnlStatus.Location = New Point(870, 394)
        pnlStatus.Margin = New Padding(3, 2, 3, 2)
        pnlStatus.Name = "pnlStatus"
        pnlStatus.Size = New Size(750, 92)
        pnlStatus.TabIndex = 23
        ' 
        ' lblStatusDisplay
        ' 
        lblStatusDisplay.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold)
        lblStatusDisplay.ForeColor = Color.Black
        lblStatusDisplay.Location = New Point(-1, -2)
        lblStatusDisplay.Name = "lblStatusDisplay"
        lblStatusDisplay.Size = New Size(750, 92)
        lblStatusDisplay.TabIndex = 0
        lblStatusDisplay.Text = "No Delivery Selected"
        lblStatusDisplay.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' WebViewMap
        ' 
        WebViewMap.AllowExternalDrop = True
        WebViewMap.CreationProperties = Nothing
        WebViewMap.DefaultBackgroundColor = Color.White
        WebViewMap.Dock = DockStyle.Fill
        WebViewMap.Location = New Point(4, 4)
        WebViewMap.Margin = New Padding(3, 2, 3, 2)
        WebViewMap.Name = "WebViewMap"
        WebViewMap.Padding = New Padding(3, 2, 3, 2)
        WebViewMap.Size = New Size(722, 447)
        WebViewMap.TabIndex = 2
        WebViewMap.ZoomFactor = 1.0R
        ' 
        ' pnlMapBorder
        ' 
        pnlMapBorder.BackColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        pnlMapBorder.BorderStyle = BorderStyle.FixedSingle
        pnlMapBorder.Controls.Add(WebViewMap)
        pnlMapBorder.Controls.Add(lblMapPlaceholder)
        pnlMapBorder.Location = New Point(879, 501)
        pnlMapBorder.Margin = New Padding(3, 2, 3, 2)
        pnlMapBorder.Name = "pnlMapBorder"
        pnlMapBorder.Padding = New Padding(4)
        pnlMapBorder.Size = New Size(732, 457)
        pnlMapBorder.TabIndex = 3
        ' 
        ' lblMapPlaceholder
        ' 
        lblMapPlaceholder.BackColor = Color.WhiteSmoke
        lblMapPlaceholder.Dock = DockStyle.Fill
        lblMapPlaceholder.Font = New Font("Segoe UI", 10.0F)
        lblMapPlaceholder.ForeColor = Color.FromArgb(CByte(120), CByte(120), CByte(120))
        lblMapPlaceholder.Location = New Point(4, 4)
        lblMapPlaceholder.Name = "lblMapPlaceholder"
        lblMapPlaceholder.Size = New Size(722, 447)
        lblMapPlaceholder.TabIndex = 3
        lblMapPlaceholder.Text = "No Location to Show"
        lblMapPlaceholder.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(39), CByte(174), CByte(96))
        Panel1.Controls.Add(PictureBox1)
        Panel1.Controls.Add(Label3)
        Panel1.Location = New Point(0, 0)
        Panel1.Margin = New Padding(0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1670, 99)
        Panel1.TabIndex = 24
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        PictureBox1.Image = My.Resources.Resources.MookbanGrill_LOGO
        PictureBox1.InitialImage = CType(resources.GetObject("PictureBox1.InitialImage"), Image)
        PictureBox1.Location = New Point(14, 3)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(95, 93)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 2
        PictureBox1.TabStop = False
        ' 
        ' Label3
        ' 
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Segoe UI Black", 27.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.White
        Label3.Location = New Point(115, 25)
        Label3.Name = "Label3"
        Label3.Size = New Size(459, 47)
        Label3.TabIndex = 1
        Label3.Text = "Delivery Management              " & vbCrLf
        Label3.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 9.0F)
        Label1.Location = New Point(18, 140)
        Label1.Name = "Label1"
        Label1.Size = New Size(45, 15)
        Label1.TabIndex = 26
        Label1.Text = "Search:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 9.0F)
        Label4.Location = New Point(390, 140)
        Label4.Name = "Label4"
        Label4.Size = New Size(36, 15)
        Label4.TabIndex = 27
        Label4.Text = "Filter:"
        ' 
        ' cmbFilter
        ' 
        cmbFilter.Font = New Font("Segoe UI", 9.0F)
        cmbFilter.FormattingEnabled = True
        cmbFilter.Items.AddRange(New Object() {"No Filters", "Pending", "Delivered", "Failed"})
        cmbFilter.Location = New Point(466, 136)
        cmbFilter.Margin = New Padding(3, 2, 3, 2)
        cmbFilter.Name = "cmbFilter"
        cmbFilter.Size = New Size(140, 23)
        cmbFilter.TabIndex = 28
        ToolTip1.SetToolTip(cmbFilter, "Filter deliveries by status or payment method")
        ' 
        ' txtSearch
        ' 
        txtSearch.BorderStyle = BorderStyle.FixedSingle
        txtSearch.Font = New Font("Segoe UI", 9.0F)
        txtSearch.Location = New Point(100, 136)
        txtSearch.Margin = New Padding(3, 2, 3, 2)
        txtSearch.Name = "txtSearch"
        txtSearch.PlaceholderText = "Search deliveries..."
        txtSearch.Size = New Size(270, 23)
        txtSearch.TabIndex = 29
        ToolTip1.SetToolTip(txtSearch, "Type to search by Delivery ID, Customer name, Address or Contact")
        ' 
        ' cmbSort
        ' 
        cmbSort.Font = New Font("Segoe UI", 9.0F)
        cmbSort.FormattingEnabled = True
        cmbSort.Items.AddRange(New Object() {"Newest First", "Oldest First"})
        cmbSort.Location = New Point(688, 136)
        cmbSort.Margin = New Padding(3, 2, 3, 2)
        cmbSort.Name = "cmbSort"
        cmbSort.Size = New Size(120, 23)
        cmbSort.TabIndex = 30
        ToolTip1.SetToolTip(cmbSort, "Sort deliveries by date")
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 9.0F)
        Label5.Location = New Point(620, 140)
        Label5.Name = "Label5"
        Label5.Size = New Size(31, 15)
        Label5.TabIndex = 31
        Label5.Text = "Sort:"
        ' 
        ' btnNewEntry
        ' 
        btnNewEntry.BackColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        btnNewEntry.Cursor = Cursors.Hand
        btnNewEntry.FlatAppearance.BorderColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
        btnNewEntry.FlatAppearance.BorderSize = 0
        btnNewEntry.FlatStyle = FlatStyle.Flat
        btnNewEntry.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnNewEntry.ForeColor = Color.White
        btnNewEntry.Location = New Point(18, 596)
        btnNewEntry.Margin = New Padding(3, 2, 3, 2)
        btnNewEntry.Name = "btnNewEntry"
        btnNewEntry.Size = New Size(160, 40)
        btnNewEntry.TabIndex = 32
        btnNewEntry.Text = "Create New Entry"
        btnNewEntry.UseVisualStyleBackColor = False
        ' 
        ' btnCreateOrder
        ' 
        btnCreateOrder.BackColor = Color.FromArgb(CByte(155), CByte(89), CByte(182))
        btnCreateOrder.Cursor = Cursors.Hand
        btnCreateOrder.FlatAppearance.BorderColor = Color.FromArgb(CByte(142), CByte(68), CByte(173))
        btnCreateOrder.FlatAppearance.BorderSize = 0
        btnCreateOrder.FlatStyle = FlatStyle.Flat
        btnCreateOrder.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnCreateOrder.ForeColor = Color.White
        btnCreateOrder.Location = New Point(190, 596)
        btnCreateOrder.Margin = New Padding(3, 2, 3, 2)
        btnCreateOrder.Name = "btnCreateOrder"
        btnCreateOrder.Size = New Size(160, 40)
        btnCreateOrder.TabIndex = 33
        btnCreateOrder.Text = "Create Order"
        btnCreateOrder.UseVisualStyleBackColor = False
        ' 
        ' lblSearchIcon
        ' 
        lblSearchIcon.Font = New Font("Segoe MDL2 Assets", 12.0F)
        lblSearchIcon.ForeColor = Color.FromArgb(CByte(125), CByte(125), CByte(125))
        lblSearchIcon.Location = New Point(76, 136)
        lblSearchIcon.Name = "lblSearchIcon"
        lblSearchIcon.Size = New Size(20, 20)
        lblSearchIcon.TabIndex = 60
        lblSearchIcon.Text = ""
        lblSearchIcon.TextAlign = ContentAlignment.MiddleCenter
        ToolTip1.SetToolTip(lblSearchIcon, "Search")
        ' 
        ' lblFilterIcon
        ' 
        lblFilterIcon.Font = New Font("Segoe MDL2 Assets", 12.0F)
        lblFilterIcon.ForeColor = Color.FromArgb(CByte(125), CByte(125), CByte(125))
        lblFilterIcon.Location = New Point(442, 136)
        lblFilterIcon.Name = "lblFilterIcon"
        lblFilterIcon.Size = New Size(20, 20)
        lblFilterIcon.TabIndex = 61
        lblFilterIcon.Text = ""
        lblFilterIcon.TextAlign = ContentAlignment.MiddleCenter
        ToolTip1.SetToolTip(lblFilterIcon, "Filter")
        ' 
        ' lblSortIcon
        ' 
        lblSortIcon.Font = New Font("Segoe MDL2 Assets", 12.0F)
        lblSortIcon.ForeColor = Color.FromArgb(CByte(125), CByte(125), CByte(125))
        lblSortIcon.Location = New Point(662, 136)
        lblSortIcon.Name = "lblSortIcon"
        lblSortIcon.Size = New Size(20, 20)
        lblSortIcon.TabIndex = 62
        lblSortIcon.Text = ""
        lblSortIcon.TextAlign = ContentAlignment.MiddleCenter
        ToolTip1.SetToolTip(lblSortIcon, "Sort")
        ' 
        ' UC_Delivery
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(lblSortIcon)
        Controls.Add(lblFilterIcon)
        Controls.Add(lblSearchIcon)
        Controls.Add(btnCreateOrder)
        Controls.Add(btnNewEntry)
        Controls.Add(Label5)
        Controls.Add(cmbSort)
        Controls.Add(Label1)
        Controls.Add(txtSearch)
        Controls.Add(cmbFilter)
        Controls.Add(Label4)
        Controls.Add(Panel1)
        Controls.Add(pnlStatus)
        Controls.Add(pnlMapBorder)
        Controls.Add(dgvDeliveries)
        Controls.Add(grpDetails)
        Margin = New Padding(3, 2, 3, 2)
        Name = "UC_Delivery"
        Size = New Size(1670, 1080)
        CType(dgvDeliveries, ComponentModel.ISupportInitialize).EndInit()
        grpDetails.ResumeLayout(False)
        grpDetails.PerformLayout()
        pnlStatus.ResumeLayout(False)
        CType(WebViewMap, ComponentModel.ISupportInitialize).EndInit()
        pnlMapBorder.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
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

    ' Icon labels
    Friend WithEvents lblSearchIcon As Label
    Friend WithEvents lblFilterIcon As Label
    Friend WithEvents lblSortIcon As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents pnlMapBorder As Panel
    ' placeholder label for map (no WithEvents to avoid ENC issues)
    Friend lblMapPlaceholder As Label
End Class
