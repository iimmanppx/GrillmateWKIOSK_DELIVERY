Imports System.Data.SqlClient
Imports Microsoft.Web.WebView2.WinForms
Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports System.Threading.Tasks

Public Class UC_Delivery
    Private connectionString As String = "Data Source=PC\SQLEXPRESS;Initial Catalog=POS;Integrated Security=True"
    Private newRowIndex As Integer = -1

    Private Sub UC_Delivery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If LicenseManager.UsageMode = LicenseUsageMode.Designtime Then Return

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
    End Sub

    Private Async Function SafeEnsureWebView2Async() As Task
        Try
            If WebViewMap IsNot Nothing AndAlso WebViewMap.CoreWebView2 Is Nothing Then
                Await WebViewMap.EnsureCoreWebView2Async()
            End If
        Catch
        End Try
    End Function

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
                Return
            End If

            Await SafeEnsureWebView2Async()

            Dim encodedAddress As String = Uri.EscapeDataString(address)
            Dim html As String = "<!doctype html><html><head><meta charset='utf-8'/><meta name='viewport' content='width=device-width,initial-scale=1'/>" &
                                 "<style>html,body{height:100%;margin:0;padding:0}iframe{width:100%;height:100%;border:0}</style></head><body>" &
                                 "<iframe src='https://www.google.com/maps?q=" & encodedAddress & "&output=embed'></iframe></body></html>"

            If WebViewMap IsNot Nothing Then
                WebViewMap.NavigateToString(html)
            End If
        Catch ex As Exception
            Try
                If WebViewMap IsNot Nothing Then WebViewMap.NavigateToString("<html><body style='padding:10px;color:#900'>Error displaying map: " & ex.Message & "</body></html>")
            Catch
            End Try
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
            MessageBox.Show("Fill in all required fields.")
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


            Dim cust As String = Microsoft.VisualBasic.Interaction.InputBox("Enter customer name (required):", "Customer")
            If String.IsNullOrWhiteSpace(cust) Then MessageBox.Show("Customer name is required. Delivery not created.") : Return

            Dim addr As String = Microsoft.VisualBasic.Interaction.InputBox("Enter delivery address (required):", "Address")
            If String.IsNullOrWhiteSpace(addr) Then MessageBox.Show("Address is required. Delivery not created.") : Return

            Dim contact As String = Microsoft.VisualBasic.Interaction.InputBox("Enter contact number (optional):", "Contact")
            Dim payment As String = Microsoft.VisualBasic.Interaction.InputBox("Payment method (Cash/Card/MobilePay):", "Payment", "Cash")

            Try
                Using conn As New SqlConnection(connectionString)
                    conn.Open()
                    Dim insertQuery As String = "INSERT INTO Deliveries (OrderID, CustomerName, Address, ContactNumber, PaymentMethod, DeliveryStatus, DeliveryDate) VALUES (@OrderID, @CustomerName, @Address, @ContactNumber, @PaymentMethod, @DeliveryStatus, @DeliveryDate)"
                    Using cmd As New SqlCommand(insertQuery, conn)
                        cmd.Parameters.AddWithValue("@OrderID", createdOrderId)
                        cmd.Parameters.AddWithValue("@CustomerName", cust)
                        cmd.Parameters.AddWithValue("@Address", addr)
                        cmd.Parameters.AddWithValue("@ContactNumber", If(String.IsNullOrWhiteSpace(contact), DBNull.Value, CType(contact, Object)))
                        cmd.Parameters.AddWithValue("@PaymentMethod", If(String.IsNullOrWhiteSpace(payment), "Cash", CType(payment, Object)))
                        cmd.Parameters.AddWithValue("@DeliveryStatus", "Pending")
                        cmd.Parameters.AddWithValue("@DeliveryDate", DateTime.Now)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error creating delivery: " & ex.Message)
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
End Class
