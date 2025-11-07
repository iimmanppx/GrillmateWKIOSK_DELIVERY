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
        txtDeliveryID = New TextBox()
        txtCustomer = New TextBox()
        txtContact = New TextBox()
        txtAddress = New TextBox()
        txtItems = New TextBox()
        btnDelivered = New Button()
        btnFailed = New Button()
        btnSave = New Button()
        lblPayment = New Label()
        lblStatus = New Label()
        lblID = New Label()
        lblCustomer = New Label()
        lblContact = New Label()
        lblAddress = New Label()
        lblItems = New Label()
        pnlStatus = New Panel()
        lblStatusDisplay = New Label()
        WebViewMap = New Microsoft.Web.WebView2.WinForms.WebView2()
        Panel1 = New Panel()
        Label3 = New Label()
        PB_Logo = New PictureBox()
        Panel2 = New Panel()
        Label2 = New Label()
        CType(dgvDeliveries, ComponentModel.ISupportInitialize).BeginInit()
        grpDetails.SuspendLayout()
        pnlStatus.SuspendLayout()
        CType(WebViewMap, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        CType(PB_Logo, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' dgvDeliveries
        ' 
        dgvDeliveries.BackgroundColor = Color.White
        dgvDeliveries.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvDeliveries.Location = New Point(20, 20)
        dgvDeliveries.Name = "dgvDeliveries"
        dgvDeliveries.RowHeadersWidth = 51
        dgvDeliveries.Size = New Size(896, 250)
        dgvDeliveries.TabIndex = 0
        ' 
        ' grpDetails
        ' 
        grpDetails.Controls.Add(cmbStatus)
        grpDetails.Controls.Add(cmbPayment)
        grpDetails.Controls.Add(txtDeliveryID)
        grpDetails.Controls.Add(txtCustomer)
        grpDetails.Controls.Add(txtContact)
        grpDetails.Controls.Add(txtAddress)
        grpDetails.Controls.Add(txtItems)
        grpDetails.Controls.Add(btnDelivered)
        grpDetails.Controls.Add(btnFailed)
        grpDetails.Controls.Add(btnSave)
        grpDetails.Controls.Add(lblPayment)
        grpDetails.Controls.Add(lblStatus)
        grpDetails.Controls.Add(lblID)
        grpDetails.Controls.Add(lblCustomer)
        grpDetails.Controls.Add(lblContact)
        grpDetails.Controls.Add(lblAddress)
        grpDetails.Controls.Add(lblItems)
        grpDetails.Location = New Point(20, 335)
        grpDetails.Name = "grpDetails"
        grpDetails.Size = New Size(822, 519)
        grpDetails.TabIndex = 1
        grpDetails.TabStop = False
        grpDetails.Text = "Delivery Details"
        ' 
        ' cmbStatus
        ' 
        cmbStatus.Items.AddRange(New Object() {"Pending", "Preparing", "In Transit", "Delivered", "Failed"})
        cmbStatus.Location = New Point(602, 50)
        cmbStatus.Name = "cmbStatus"
        cmbStatus.Size = New Size(186, 28)
        cmbStatus.TabIndex = 9
        ' 
        ' cmbPayment
        ' 
        cmbPayment.Items.AddRange(New Object() {"Cash on Delivery", "GCash"})
        cmbPayment.Location = New Point(602, 20)
        cmbPayment.Name = "cmbPayment"
        cmbPayment.Size = New Size(186, 28)
        cmbPayment.TabIndex = 10
        ' 
        ' txtDeliveryID
        ' 
        txtDeliveryID.Location = New Point(100, 22)
        txtDeliveryID.Name = "txtDeliveryID"
        txtDeliveryID.Size = New Size(385, 27)
        txtDeliveryID.TabIndex = 11
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
        ' btnDelivered
        ' 
        btnDelivered.BackColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        btnDelivered.Location = New Point(183, 325)
        btnDelivered.Name = "btnDelivered"
        btnDelivered.Size = New Size(156, 40)
        btnDelivered.TabIndex = 19
        btnDelivered.Text = "Mark as Delivered"
        btnDelivered.UseVisualStyleBackColor = False
        ' 
        ' btnFailed
        ' 
        btnFailed.BackColor = Color.FromArgb(CByte(231), CByte(76), CByte(60))
        btnFailed.Location = New Point(345, 325)
        btnFailed.Name = "btnFailed"
        btnFailed.Size = New Size(117, 40)
        btnFailed.TabIndex = 20
        btnFailed.Text = "Mark as Failed"
        btnFailed.UseVisualStyleBackColor = False
        ' 
        ' btnSave
        ' 
        btnSave.BackColor = Color.LimeGreen
        btnSave.Location = New Point(87, 325)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(90, 42)
        btnSave.TabIndex = 21
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' lblPayment
        ' 
        lblPayment.Location = New Point(522, 23)
        lblPayment.Name = "lblPayment"
        lblPayment.Size = New Size(100, 23)
        lblPayment.TabIndex = 22
        lblPayment.Text = "Payment:"
        ' 
        ' lblStatus
        ' 
        lblStatus.Location = New Point(522, 53)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(100, 23)
        lblStatus.TabIndex = 23
        lblStatus.Text = "Status:"
        ' 
        ' lblID
        ' 
        lblID.Location = New Point(20, 25)
        lblID.Name = "lblID"
        lblID.Size = New Size(100, 23)
        lblID.TabIndex = 24
        lblID.Text = "Delivery ID:"
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
        pnlStatus.Location = New Point(947, 20)
        pnlStatus.Name = "pnlStatus"
        pnlStatus.Size = New Size(283, 173)
        pnlStatus.TabIndex = 23
        ' 
        ' lblStatusDisplay
        ' 
        lblStatusDisplay.Font = New Font("Castellar", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblStatusDisplay.ForeColor = Color.Black
        lblStatusDisplay.Location = New Point(-1, 0)
        lblStatusDisplay.Name = "lblStatusDisplay"
        lblStatusDisplay.Size = New Size(283, 173)
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
        WebViewMap.ZoomFactor = 1.0R
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = SystemColors.ControlDarkDark
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(PB_Logo)
        Panel1.Location = New Point(-33, 860)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1781, 302)
        Panel1.TabIndex = 24
        ' 
        ' Label3
        ' 
        Label3.Font = New Font("Stencil", 28.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = SystemColors.ButtonHighlight
        Label3.Location = New Point(73, 43)
        Label3.Name = "Label3"
        Label3.Size = New Size(629, 61)
        Label3.TabIndex = 1
        Label3.Text = "Delivery  Management"
        ' 
        ' PB_Logo
        ' 
        PB_Logo.Image = My.Resources.Resources.Mookbang_grill_logo
        PB_Logo.InitialImage = Nothing
        PB_Logo.Location = New Point(1427, 0)
        PB_Logo.Name = "PB_Logo"
        PB_Logo.Size = New Size(283, 136)
        PB_Logo.SizeMode = PictureBoxSizeMode.Zoom
        PB_Logo.TabIndex = 0
        PB_Logo.TabStop = False
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = SystemColors.ControlLight
        Panel2.Controls.Add(Label2)
        Panel2.Location = New Point(1236, 21)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(168, 172)
        Panel2.TabIndex = 25
        ' 
        ' Label2
        ' 
        Label2.Location = New Point(27, 68)
        Label2.Name = "Label2"
        Label2.Size = New Size(138, 59)
        Label2.TabIndex = 0
        Label2.Text = "gonna add icons here (soon)"
        ' 
        ' UC_Delivery
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        BorderStyle = BorderStyle.FixedSingle
        Controls.Add(Panel2)
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
        Panel2.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents dgvDeliveries As DataGridView
    Friend WithEvents grpDetails As GroupBox
    Friend WithEvents txtDeliveryID As TextBox
    Friend WithEvents txtCustomer As TextBox
    Friend WithEvents txtContact As TextBox
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents txtItems As TextBox
    Friend WithEvents cmbPayment As ComboBox
    Friend WithEvents cmbStatus As ComboBox
    Friend WithEvents btnDelivered As Button
    Friend WithEvents btnFailed As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents lblID As Label
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
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents PB_Logo As PictureBox
    Friend WithEvents Label3 As Label
End Class
