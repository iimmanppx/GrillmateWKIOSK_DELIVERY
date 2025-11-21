Imports System.Data.SqlClient
Imports Microsoft.Web.WebView2.WinForms
Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports System.Threading.Tasks
Imports System.Drawing
Imports System.Windows.Forms

Public Class UC_Delivery
    Private connectionString As String = "Data Source=PC\SQLEXPRESS;Initial Catalog=POS;Integrated Security=True;"

    'Private connectionString As String = "Server=192.168.1.1\SQLEXPRESS01;Database=POS;User Id=sa;Password=123456;TrustServerCertificate=True;"
    Private newRowIndex As Integer = -1

    ' UI helpers for hover effects
    Private controlOriginalColors As New Dictionary(Of Control, Color)()
    Private controlOriginalForeColors As New Dictionary(Of Control, Color)()
    Private buttonIconMap As New Dictionary(Of Button, Label)()

    Private Sub UC_Delivery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If LicenseManager.UsageMode = LicenseUsageMode.Designtime Then Return

        ' Wire hover handlers for inputs (safe - ignore at design time)
        Try
            AddHandler txtSearch.MouseEnter, AddressOf OnInputMouseEnter
            AddHandler txtSearch.MouseLeave, AddressOf OnInputMouseLeave
            AddHandler cmbFilter.MouseEnter, AddressOf OnInputMouseEnter
            AddHandler cmbFilter.MouseLeave, AddressOf OnInputMouseLeave
            AddHandler cmbSort.MouseEnter, AddressOf OnInputMouseEnter
            AddHandler cmbSort.MouseLeave, AddressOf OnInputMouseLeave
        Catch
        End Try

        ' Map buttons to their icon labels (labels created in designer)
        Try


            ' Wire hover handlers for buttons (designer also wires but safe to ensure)
            AddHandler btnNewEntry.MouseEnter, AddressOf OnButtonMouseEnter
            AddHandler btnNewEntry.MouseLeave, AddressOf OnButtonMouseLeave
            AddHandler btnCreateOrder.MouseEnter, AddressOf OnButtonMouseEnter
            AddHandler btnCreateOrder.MouseLeave, AddressOf OnButtonMouseLeave
            AddHandler btnSave.MouseEnter, AddressOf OnButtonMouseEnter
            AddHandler btnSave.MouseLeave, AddressOf OnButtonMouseLeave
        Catch
        End Try

        LoadDeliveries()

        cmbStatus.Items.Clear()
        cmbStatus.Items.AddRange(New String() {"Pending", "Delivered", "Failed"})
        cmbStatus.SelectedIndex = 0

        cmbFilter.Items.Clear()
        cmbFilter.Items.AddRange(New String() {"No Filters", "Pending", "Delivered", "Failed"})
        cmbFilter.SelectedIndex = -1

        cmbSort.Items.Clear()
        cmbSort.Items.AddRange(New String() {"Newest First", "Oldest First"})
        cmbSort.SelectedIndex = -1

        dgvDeliveries.ReadOnly = True
        dgvDeliveries.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvDeliveries.MultiSelect = False
        dgvDeliveries.AllowUserToAddRows = False
        dgvDeliveries.CellBorderStyle = DataGridViewCellBorderStyle.None

        Try
            If WebViewMap IsNot Nothing Then
                WebViewMap.NavigateToString("<html><body style='margin:0;padding:10px;font-family:Segoe UI,Arial;background:#fff;color:#333'>Map will load here</body></html>")
            End If
        Catch
        End Try

        ' ensure placeholder is visible at startup
        Try
            If lblMapPlaceholder IsNot Nothing Then lblMapPlaceholder.Visible = True
        Catch
        End Try
    End Sub

    Private Async Function SafeEnsureWebView2Async() As Task
        Try
            If WebViewMap IsNot Nothing AndAlso WebViewMap.CoreWebView2 Is Nothing Then
                Await WebViewMap.EnsureCoreWebView2Async()
            End If
        Catch
        End Try
    End Function

    Private Sub ShowPlaceholder()
        Try
            If lblMapPlaceholder IsNot Nothing Then lblMapPlaceholder.Visible = True
        Catch
        End Try
    End Sub

    Private Sub HidePlaceholder()
        Try
            If lblMapPlaceholder IsNot Nothing Then lblMapPlaceholder.Visible = False
        Catch
        End Try
    End Sub

    Private Sub LoadDeliveries()
        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim query As String = "SELECT DeliveryID, CustomerName, Address, ContactNumber, PaymentMethod, DeliveryStatus, DeliveryDate FROM Deliveries"
                Using cmd As New SqlCommand(query, conn)
                    Dim da As New SqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    dgvDeliveries.DataSource = dt
                    For Each col As DataGridViewColumn In dgvDeliveries.Columns
                        col.ReadOnly = True
                    Next
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading deliveries: " & ex.Message)
        End Try
    End Sub

    ' Display a single address in Google Maps iframe inside WebView2
    Private Async Sub ShowAddressOnMap(address As String)
        Try
            If String.IsNullOrWhiteSpace(address) Then
                If WebViewMap IsNot Nothing Then WebViewMap.NavigateToString("<html><body style='padding:10px'>No address provided.</body></html>")
                ShowPlaceholder()
                Return
            End If

            Await SafeEnsureWebView2Async()

            Dim encodedAddress As String = Uri.EscapeDataString(address)
            Dim html As String = "<!doctype html><html><head><meta charset='utf-8'/><meta name='viewport' content='width=device-width,initial-scale=1'/>" &
                                 "<style>html,body{height:100%;margin:0;padding:0}iframe{width:100%;height:100%;border:0}</style></head><body>" &
                                 "<iframe src='https://www.google.com/maps?q=" & encodedAddress & "&output=embed'></iframe></body></html>"

            If WebViewMap IsNot Nothing Then
                WebViewMap.NavigateToString(html)
                HidePlaceholder()
            End If
        Catch ex As Exception
            Try
                If WebViewMap IsNot Nothing Then WebViewMap.NavigateToString("<html><body style='padding:10px;color:#900'>Error displaying map: " & ex.Message & "</body></html>")
            Catch
            End Try
            ShowPlaceholder()
        End Try
    End Sub

    Private Sub dgvDeliveries_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDeliveries.CellClick
        If e.RowIndex < 0 Then Return

        If newRowIndex >= 0 Then
            Dim r = dgvDeliveries.Rows(newRowIndex)
            Dim isEmpty = String.IsNullOrWhiteSpace(r.Cells("CustomerName").Value?.ToString()) AndAlso
                          String.IsNullOrWhiteSpace(r.Cells("Address").Value?.ToString()) AndAlso
                          String.IsNullOrWhiteSpace(r.Cells("ContactNumber").Value?.ToString())
            If isEmpty AndAlso TypeOf dgvDeliveries.DataSource Is DataTable Then
                CType(dgvDeliveries.DataSource, DataTable).Rows.RemoveAt(newRowIndex)
            End If
            newRowIndex = -1
        End If

        Dim row As DataGridViewRow = dgvDeliveries.Rows(e.RowIndex)
        txtCustomer.Text = row.Cells("CustomerName").Value?.ToString()
        txtContact.Text = row.Cells("ContactNumber").Value?.ToString()
        txtAddress.Text = row.Cells("Address").Value?.ToString()
        cmbPayment.Text = row.Cells("PaymentMethod").Value?.ToString()
        cmbStatus.Text = row.Cells("DeliveryStatus").Value?.ToString()

        ' Show only the delivery address on the map
        ShowAddressOnMap(txtAddress.Text)
        UpdateStatusIndicator(cmbStatus.Text)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrWhiteSpace(txtCustomer.Text) OrElse String.IsNullOrWhiteSpace(txtAddress.Text) Then
            ' Required fields missing — silently abort and focus the first empty input
            If String.IsNullOrWhiteSpace(txtCustomer.Text) Then
                txtCustomer.Focus()
            Else
                txtAddress.Focus()
            End If
            Exit Sub
        End If

        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim checkQuery As String = "SELECT COUNT(*) FROM Deliveries WHERE DeliveryID=@DeliveryID"
                Dim exists As Boolean
                Dim deliveryID As String = String.Empty
                If dgvDeliveries.SelectedRows.Count > 0 Then deliveryID = dgvDeliveries.SelectedRows(0).Cells("DeliveryID").Value?.ToString()

                Using chk As New SqlCommand(checkQuery, conn)
                    chk.Parameters.AddWithValue("@DeliveryID", deliveryID)
                    exists = Convert.ToInt32(chk.ExecuteScalar()) > 0
                End Using

                Dim query As String
                If exists Then
                    query = "UPDATE Deliveries SET CustomerName=@CustomerName, Address=@Address, ContactNumber=@ContactNumber, PaymentMethod=@PaymentMethod, DeliveryStatus=@DeliveryStatus WHERE DeliveryID=@DeliveryID"
                Else
                    query = "INSERT INTO Deliveries (CustomerName, Address, ContactNumber, PaymentMethod, DeliveryStatus, DeliveryDate) VALUES (@CustomerName, @Address, @ContactNumber, @PaymentMethod, @DeliveryStatus, @DeliveryDate)"
                End If

                Using cmd As New SqlCommand(query, conn)
                    If exists Then cmd.Parameters.AddWithValue("@DeliveryID", deliveryID)
                    cmd.Parameters.AddWithValue("@CustomerName", txtCustomer.Text)
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text)
                    cmd.Parameters.AddWithValue("@ContactNumber", If(String.IsNullOrWhiteSpace(txtContact.Text), DBNull.Value, CType(txtContact.Text, Object)))
                    cmd.Parameters.AddWithValue("@PaymentMethod", If(String.IsNullOrWhiteSpace(cmbPayment.Text), DBNull.Value, CType(cmbPayment.Text, Object)))
                    cmd.Parameters.AddWithValue("@DeliveryStatus", If(String.IsNullOrWhiteSpace(cmbStatus.Text), "Pending", cmbStatus.Text))
                    If Not exists Then cmd.Parameters.AddWithValue("@DeliveryDate", DateTime.Now)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            LoadDeliveries()
            UpdateStatusIndicator(cmbStatus.Text)
            MessageBox.Show("Saved successfully.")
        Catch ex As Exception
            MessageBox.Show("Error saving: " & ex.Message)
        End Try
    End Sub

    Private Sub UpdateDeliveryStatus(status As String)
        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim query As String = "UPDATE Deliveries SET DeliveryStatus=@Status WHERE DeliveryID=@DeliveryID"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Status", status)
                    Dim deliveryID As String = String.Empty
                    If dgvDeliveries.SelectedRows.Count > 0 Then deliveryID = dgvDeliveries.SelectedRows(0).Cells("DeliveryID").Value?.ToString()
                    cmd.Parameters.AddWithValue("@DeliveryID", deliveryID)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            LoadDeliveries()
            UpdateStatusIndicator(status)
        Catch ex As Exception
            MessageBox.Show("Error updating: " & ex.Message)
        End Try
    End Sub

    Private Sub UpdateStatusIndicator(status As String)
        Select Case status.ToLower()
            Case "delivered"
                pnlStatus.BackColor = Color.MediumSeaGreen
                lblStatusDisplay.Text = "Delivered"
            Case "failed"
                pnlStatus.BackColor = Color.IndianRed
                lblStatusDisplay.Text = "Failed"
            Case Else
                pnlStatus.BackColor = Color.LightGray
                lblStatusDisplay.Text = "Pending"
        End Select
    End Sub

    Private Sub btnCreateOrder_Click(sender As Object, e As EventArgs) Handles btnCreateOrder.Click
        Try
            Dim beforeShow As DateTime = DateTime.Now
            Dim menuForm As New MenuDashboardForm()
            menuForm.OrderType = "Takeout"
            menuForm.FormBorderStyle = FormBorderStyle.None
            menuForm.WindowState = FormWindowState.Maximized
            menuForm.StartPosition = FormStartPosition.CenterScreen
            menuForm.ShowDialog()

            For Each f As Form In Application.OpenForms.Cast(Of Form)().ToList()
                If f.GetType().Name = "DineInOrTakeout" Then
                    Try : f.Hide() : Catch : End Try
                End If
            Next

            Dim createdOrderId As Integer = 0
            Dim createdOrderNumber As String = String.Empty
            Try
                Using conn As New SqlConnection(connectionString)
                    conn.Open()
                    Dim q As String = "SELECT TOP 1 OrderID, OrderNumber, CreatedAt FROM Orders WHERE CreatedAt >= @start ORDER BY CreatedAt DESC"
                    Using cmd As New SqlCommand(q, conn)
                        cmd.Parameters.AddWithValue("@start", beforeShow)
                        Using rdr As SqlDataReader = cmd.ExecuteReader()
                            If rdr.Read() Then
                                createdOrderId = Convert.ToInt32(rdr("OrderID"))
                                createdOrderNumber = rdr("OrderNumber").ToString()
                            End If
                        End Using
                    End Using
                End Using
            Catch
            End Try


            ' Request customer and address (required)
            '            Dim cust As String = Microsoft.VisualBasic.Interaction.InputBox("Enter customer name (required):", "Customer")
            '            If String.IsNullOrWhiteSpace(cust) Then MessageBox.Show("Customer name is required. Delivery not created.") : Return
            '
            '            Dim addr As String = Microsoft.VisualBasic.Interaction.InputBox("Enter delivery address (required):", "Address")
            '            If String.IsNullOrWhiteSpace(addr) Then MessageBox.Show("Address is required. Delivery not created.") : Return
            '
            '            Dim contact As String = Microsoft.VisualBasic.Interaction.InputBox("Enter contact number (optional):", "Contact")
            '            Dim payment As String = Microsoft.VisualBasic.Interaction.InputBox("Payment method (Cash/Card/MobilePay):", "Payment", "Cash")
            Dim cust As String = txtCustomer.Text.Trim()
            If String.IsNullOrWhiteSpace(cust) Then txtCustomer.Focus() : Return

            Dim addr As String = txtAddress.Text.Trim()
            If String.IsNullOrWhiteSpace(addr) Then txtAddress.Focus() : Return

            Dim contact As String = txtContact.Text.Trim()
            Dim payment As String = If(String.IsNullOrWhiteSpace(cmbPayment.Text), "Cash", cmbPayment.Text)

            Try
                Using conn As New SqlConnection(connectionString)
                    conn.Open()
                    Dim insertQuery As String = "INSERT INTO Deliveries (OrderID, CustomerName, Address, ContactNumber, PaymentMethod, DeliveryStatus, DeliveryDate) VALUES (@OrderID, @CustomerName, @Address, @ContactNumber, @PaymentMethod, @DeliveryStatus, @DELIVERYDATE)"
                    Using cmd As New SqlCommand(insertQuery, conn)
                        cmd.Parameters.AddWithValue("@OrderID", createdOrderId)
                        cmd.Parameters.AddWithValue("@CustomerName", cust)
                        cmd.Parameters.AddWithValue("@Address", addr)
                        cmd.Parameters.AddWithValue("@ContactNumber", If(String.IsNullOrWhiteSpace(contact), DBNull.Value, CType(contact, Object)))
                        cmd.Parameters.AddWithValue("@PaymentMethod", If(String.IsNullOrWhiteSpace(payment), "Cash", CType(payment, Object)))
                        cmd.Parameters.AddWithValue("@DeliveryStatus", "Pending")
                        cmd.Parameters.AddWithValue("@DELIVERYDATE", DateTime.Now)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
            Catch ex As Exception
                ' Silent: Do not show any message box for create delivery errors
                ' (Previously showed MessageBox with DB foreign key errors)
                Return
            End Try

            LoadDeliveries()
            txtCustomer.Text = ""
            txtAddress.Text = ""
            txtContact.Text = ""
            cmbPayment.SelectedIndex = -1
            cmbStatus.SelectedIndex = 0
            UpdateStatusIndicator("Pending")

            MessageBox.Show("Delivery created for order " & createdOrderNumber)

            For Each f As Form In Application.OpenForms.Cast(Of Form)().ToList()
                If f.GetType().Name = "StaffMenuDashboard" Then
                    Try
                        Dim smd = DirectCast(f, Object)
                        smd.LoadDeliveryControl()
                    Catch : End Try
                End If
            Next

        Catch ex As Exception
            MessageBox.Show("Error opening Menu Dashboard: " & ex.Message)
        End Try
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Dim keyword As String = txtSearch.Text.Trim()
        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim query As String = "SELECT DeliveryID, CustomerName, Address, ContactNumber, PaymentMethod, DeliveryStatus, DeliveryDate FROM Deliveries WHERE DeliveryID LIKE @kw OR CustomerName LIKE @kw OR Address LIKE @kw OR ContactNumber LIKE @kw"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@kw", "%" & keyword & "%")
                    Dim da As New SqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    dgvDeliveries.DataSource = dt
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Search error: " & ex.Message)
        End Try
    End Sub

    Private Sub cmbFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFilter.SelectedIndexChanged
        Dim selectedCategory As String = cmbFilter.Text
        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim query As String
                If selectedCategory = "No Filters" Then
                    query = "SELECT DeliveryID, CustomerName, Address, ContactNumber, PaymentMethod, DeliveryStatus, DeliveryDate FROM Deliveries"
                Else
                    query = "SELECT DeliveryID, CustomerName, Address, ContactNumber, PaymentMethod, DeliveryStatus, DeliveryDate FROM Deliveries WHERE DeliveryStatus = @category OR PaymentMethod = @category"
                End If
                Using cmd As New SqlCommand(query, conn)
                    If selectedCategory <> "No Filters" Then cmd.Parameters.AddWithValue("@category", selectedCategory)
                    Dim da As New SqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    dgvDeliveries.DataSource = dt
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Filter error: " & ex.Message)
        End Try
    End Sub

    Private Sub cmbSort_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSort.SelectedIndexChanged
        Dim orderBy As String = If(cmbSort.Text = "Newest First", "DESC", "ASC")
        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim query As String = $"SELECT DeliveryID, CustomerName, Address, ContactNumber, PaymentMethod, DeliveryStatus, DeliveryDate FROM Deliveries ORDER BY DeliveryDate {orderBy}"
                Using cmd As New SqlCommand(query, conn)
                    Dim da As New SqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    dgvDeliveries.DataSource = dt
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Sort error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnNewEntry_Click(sender As Object, e As EventArgs) Handles btnNewEntry.Click
        If TypeOf dgvDeliveries.DataSource IsNot DataTable Then Return
        If newRowIndex >= 0 Then
            Dim dt As DataTable = CType(dgvDeliveries.DataSource, DataTable)
            Dim r = dgvDeliveries.Rows(newRowIndex)
            Dim isEmpty = String.IsNullOrWhiteSpace(r.Cells("CustomerName").Value?.ToString()) AndAlso String.IsNullOrWhiteSpace(r.Cells("Address").Value?.ToString())
            If isEmpty Then dt.Rows.RemoveAt(newRowIndex)
            newRowIndex = -1
        End If
        Dim dtNew As DataTable = CType(dgvDeliveries.DataSource, DataTable)
        Dim newRow As DataRow = dtNew.NewRow()
        dtNew.Rows.Add(newRow)
        newRowIndex = dgvDeliveries.Rows.Count - 1
        dgvDeliveries.ClearSelection()
        dgvDeliveries.CurrentCell = dgvDeliveries.Rows(newRowIndex).Cells(0)
        dgvDeliveries.Rows(newRowIndex).Selected = True
        txtCustomer.Text = ""
        txtContact.Text = ""
        txtAddress.Text = ""
        cmbPayment.SelectedIndex = -1
        cmbStatus.SelectedIndex = 0
        UpdateStatusIndicator("Pending")
        lblStatusDisplay.Text = "Creating new entry..."
        pnlStatus.BackColor = Color.LightBlue
    End Sub

    Private Sub dgvDeliveries_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvDeliveries.CellPainting
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then

            e.Paint(e.CellBounds, DataGridViewPaintParts.All And Not DataGridViewPaintParts.Border)

            Dim borderThickness As Integer = 1  ' Change this number to make it thicker/thinner
            Dim borderColor As Color = Color.Black

            Using p As New Pen(borderColor, borderThickness)

                Dim rect As Rectangle = e.CellBounds

                rect.X += 1
                rect.Y += 1
                rect.Width -= borderThickness
                rect.Height -= borderThickness

                e.Graphics.DrawRectangle(p, rect)
            End Using

            e.Handled = True
        End If
    End Sub

    ' Hover effects: subtle lighten on buttons and light background on inputs
    Private Sub OnButtonMouseEnter(sender As Object, e As EventArgs)
        Dim btn = TryCast(sender, Button)
        If btn Is Nothing Then Return

        Try
            If Not controlOriginalColors.ContainsKey(btn) Then controlOriginalColors(btn) = btn.BackColor
            If Not controlOriginalForeColors.ContainsKey(btn) Then controlOriginalForeColors(btn) = btn.ForeColor

            btn.BackColor = System.Windows.Forms.ControlPaint.Light(btn.BackColor)
            btn.ForeColor = Color.White

            If buttonIconMap.ContainsKey(btn) Then
                Dim lbl = buttonIconMap(btn)
                If Not controlOriginalForeColors.ContainsKey(lbl) Then controlOriginalForeColors(lbl) = lbl.ForeColor
                lbl.ForeColor = Color.White
            End If
        Catch
        End Try
    End Sub

    Private Sub OnButtonMouseLeave(sender As Object, e As EventArgs)
        Dim btn = TryCast(sender, Button)
        If btn Is Nothing Then Return

        Try
            If controlOriginalColors.ContainsKey(btn) Then
                btn.BackColor = controlOriginalColors(btn)
                controlOriginalColors.Remove(btn)
            End If
            If controlOriginalForeColors.ContainsKey(btn) Then
                btn.ForeColor = controlOriginalForeColors(btn)
                controlOriginalForeColors.Remove(btn)
            End If

            If buttonIconMap.ContainsKey(btn) Then
                Dim lbl = buttonIconMap(btn)
                If controlOriginalForeColors.ContainsKey(lbl) Then
                    lbl.ForeColor = controlOriginalForeColors(lbl)
                    controlOriginalForeColors.Remove(lbl)
                End If
            End If
        Catch
        End Try
    End Sub

    Private Sub OnInputMouseEnter(sender As Object, e As EventArgs)
        Dim c = TryCast(sender, Control)
        If c Is Nothing Then Return
        Try
            If Not controlOriginalColors.ContainsKey(c) Then controlOriginalColors(c) = c.BackColor
            c.BackColor = Color.FromArgb(250, 250, 250)
        Catch
        End Try
    End Sub

    Private Sub OnInputMouseLeave(sender As Object, e As EventArgs)
        Dim c = TryCast(sender, Control)
        If c Is Nothing Then Return
        Try
            If controlOriginalColors.ContainsKey(c) Then
                c.BackColor = controlOriginalColors(c)
                controlOriginalColors.Remove(c)
            End If
        Catch
        End Try
    End Sub


End Class
