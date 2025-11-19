Imports System.Data.SqlClient
Imports Microsoft.Web.WebView2.WinForms

Public Class UC_Delivery
    Private connectionString As String = "Data Source=PC\SQLEXPRESS;Initial Catalog=POS;Integrated Security=True"
    Private newRowIndex As Integer = -1
    Private Sub UC_Delivery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDeliveries()

        ' Setup Status ComboBox
        cmbStatus.Items.Clear()
        cmbStatus.Items.Add("Pending")
        cmbStatus.Items.Add("Delivered")
        cmbStatus.Items.Add("Failed")
        cmbStatus.SelectedIndex = 0

        ' Setup Filter ComboBox
        cmbFilter.Items.Clear()
        cmbFilter.Items.Add("No Filters")
        cmbFilter.Items.Add("Pending")
        cmbFilter.Items.Add("Delivered")
        cmbFilter.Items.Add("Failed")
        cmbFilter.SelectedIndex = -1

        ' Setup Sort ComboBox
        cmbSort.Items.Clear()
        cmbSort.Items.Add("Newest First")
        cmbSort.Items.Add("Oldest First")
        cmbSort.SelectedIndex = -1

        dgvDeliveries.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvDeliveries.MultiSelect = False
        dgvDeliveries.AllowUserToAddRows = False
        dgvDeliveries.CellBorderStyle = DataGridViewCellBorderStyle.None
    End Sub

    Private Sub LoadDeliveries()
        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim query As String =
                "SELECT DeliveryID, CustomerName, Address, ContactNumber, Items, PaymentMethod, DeliveryStatus, DeliveryDate 
                 FROM Deliveries"

                Using cmd As New SqlCommand(query, conn)
                    Dim da As New SqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    dgvDeliveries.DataSource = dt

                    If dgvDeliveries.Columns.Contains("DeliveryID") Then
                        dgvDeliveries.Columns("DeliveryID").ReadOnly = True
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading deliveries: " & ex.Message)
        End Try
    End Sub

    Private Async Sub ShowAddressOnMap(address As String)
        Try
            If String.IsNullOrWhiteSpace(address) Then Exit Sub

            If WebViewMap.CoreWebView2 Is Nothing Then
                Await WebViewMap.EnsureCoreWebView2Async()
            End If

            Dim encodedAddress As String = Uri.EscapeDataString(address)
            Dim html As String = $"
            <html>
                <head>
                    <style>
                        html, body {{ margin: 0; padding: 0; height: 100%; }}
                        iframe {{ width: 100%; height: 100%; border: none; }}
                    </style>
                </head>
                <body>
                    <iframe src='https://www.google.com/maps?q={encodedAddress}&output=embed'></iframe>
                </body>
            </html>"
            WebViewMap.NavigateToString(html)
        Catch ex As Exception
            MessageBox.Show("Error displaying map: " & ex.Message)
        End Try
    End Sub

    Private Sub dgvDeliveries_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDeliveries.CellClick

        If newRowIndex >= 0 Then
            Dim r = dgvDeliveries.Rows(newRowIndex)
            Dim isEmpty = String.IsNullOrWhiteSpace(r.Cells("CustomerName").Value?.ToString()) AndAlso
                  String.IsNullOrWhiteSpace(r.Cells("Address").Value?.ToString()) AndAlso
                  String.IsNullOrWhiteSpace(r.Cells("ContactNumber").Value?.ToString()) AndAlso
                  String.IsNullOrWhiteSpace(r.Cells("Items").Value?.ToString())

            If isEmpty Then
                CType(dgvDeliveries.DataSource, DataTable).Rows.RemoveAt(newRowIndex)
            End If

            newRowIndex = -1
        End If

        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvDeliveries.Rows(e.RowIndex)

            Dim deliveryID As String = row.Cells("DeliveryID").Value.ToString()

            txtCustomer.Text = row.Cells("CustomerName").Value.ToString()
            txtContact.Text = row.Cells("ContactNumber").Value.ToString()
            txtAddress.Text = row.Cells("Address").Value.ToString()
            txtItems.Text = row.Cells("Items").Value.ToString()
            cmbPayment.Text = row.Cells("PaymentMethod").Value.ToString()
            cmbStatus.Text = row.Cells("DeliveryStatus").Value.ToString()

            ShowAddressOnMap(txtAddress.Text)
            UpdateStatusIndicator(cmbStatus.Text)
        End If
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
                Dim deliveryID As String = ""

                If dgvDeliveries.SelectedRows.Count > 0 Then
                    deliveryID = dgvDeliveries.SelectedRows(0).Cells("DeliveryID").Value.ToString()
                End If

                Using chk As New SqlCommand(checkQuery, conn)
                    chk.Parameters.AddWithValue("@DeliveryID", deliveryID)
                    exists = Convert.ToInt32(chk.ExecuteScalar()) > 0
                End Using

                Dim query As String
                If exists Then
                    query = "UPDATE Deliveries 
                             SET CustomerName=@CustomerName, Address=@Address, ContactNumber=@ContactNumber,
                             Items=@Items, PaymentMethod=@PaymentMethod, DeliveryStatus=@DeliveryStatus 
                             WHERE DeliveryID=@DeliveryID"
                Else
                    query = "INSERT INTO Deliveries (CustomerName, Address, ContactNumber, Items, PaymentMethod, DeliveryStatus, DeliveryDate) 
                             VALUES (@CustomerName, @Address, @ContactNumber, @Items, @PaymentMethod, @DeliveryStatus, @DeliveryDate)"
                End If

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@DeliveryID", deliveryID)
                    cmd.Parameters.AddWithValue("@CustomerName", txtCustomer.Text)
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text)
                    cmd.Parameters.AddWithValue("@ContactNumber", txtContact.Text)
                    cmd.Parameters.AddWithValue("@Items", txtItems.Text)
                    cmd.Parameters.AddWithValue("@PaymentMethod", cmbPayment.Text)
                    cmd.Parameters.AddWithValue("@DeliveryStatus", cmbStatus.Text)

                    If Not exists Then
                        cmd.Parameters.AddWithValue("@DeliveryDate", DateTime.Now)
                    End If

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

    Private Sub btnDelivered_Click(sender As Object, e As EventArgs)
        UpdateDeliveryStatus("Delivered")
    End Sub

    Private Sub btnFailed_Click(sender As Object, e As EventArgs)
        UpdateDeliveryStatus("Failed")
    End Sub

    Private Sub UpdateDeliveryStatus(status As String)
        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim query As String = "UPDATE Deliveries SET DeliveryStatus=@Status WHERE DeliveryID=@DeliveryID"

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Status", status)
                    Dim deliveryID As String = ""
                    If dgvDeliveries.SelectedRows.Count > 0 Then
                        deliveryID = dgvDeliveries.SelectedRows(0).Cells("DeliveryID").Value.ToString()
                    End If
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

    '  Search Function
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Dim keyword As String = txtSearch.Text.Trim()

        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim query As String =
                    "SELECT DeliveryID, CustomerName, Address, ContactNumber, Items, PaymentMethod, DeliveryStatus, DeliveryDate 
                     FROM Deliveries 
                     WHERE DeliveryID LIKE @kw OR CustomerName LIKE @kw OR Address LIKE @kw OR ContactNumber LIKE @kw OR Items LIKE @kw"

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

    '  Filter Function
    Private Sub cmbFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFilter.SelectedIndexChanged
        Dim selectedCategory As String = cmbFilter.Text

        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()

                Dim query As String

                If selectedCategory = "No Filters" Then
                    query = "SELECT DeliveryID, CustomerName, Address, ContactNumber, Items, PaymentMethod, DeliveryStatus, DeliveryDate FROM Deliveries"
                Else
                    query = "SELECT DeliveryID, CustomerName, Address, ContactNumber, Items, PaymentMethod, DeliveryStatus, DeliveryDate 
                         FROM Deliveries 
                         WHERE DeliveryStatus = @category OR PaymentMethod = @category"
                End If

                Using cmd As New SqlCommand(query, conn)
                    If selectedCategory <> "No Filters" Then
                        cmd.Parameters.AddWithValue("@category", selectedCategory)
                    End If

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


    '  Sort Function
    Private Sub cmbSort_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSort.SelectedIndexChanged
        Dim orderBy As String = If(cmbSort.Text = "Newest First", "DESC", "ASC")

        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim query As String =
                    $"SELECT DeliveryID, CustomerName, Address, ContactNumber, Items, PaymentMethod, DeliveryStatus, DeliveryDate 
                      FROM Deliveries ORDER BY DeliveryDate {orderBy}"

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

    ' New Entry Button
    Private Sub btnNewEntry_Click(sender As Object, e As EventArgs) Handles btnNewEntry.Click
        ' Remove any previous blank row if still empty
        If newRowIndex >= 0 Then
            Dim dt As DataTable = CType(dgvDeliveries.DataSource, DataTable)
            Dim r = dgvDeliveries.Rows(newRowIndex)
            Dim isEmpty = String.IsNullOrWhiteSpace(r.Cells("CustomerName").Value?.ToString()) AndAlso
                          String.IsNullOrWhiteSpace(r.Cells("Address").Value?.ToString()) AndAlso
                          String.IsNullOrWhiteSpace(r.Cells("ContactNumber").Value?.ToString()) AndAlso
                          String.IsNullOrWhiteSpace(r.Cells("Items").Value?.ToString())
            If isEmpty Then
                dt.Rows.RemoveAt(newRowIndex)
            End If
            newRowIndex = -1
        End If

        ' Add new blank row to grid
        Dim dtNew As DataTable = CType(dgvDeliveries.DataSource, DataTable)
        Dim newRow As DataRow = dtNew.NewRow()
        dtNew.Rows.Add(newRow)

        ' Track the new row index
        newRowIndex = dgvDeliveries.Rows.Count - 1

        ' Select the new row
        dgvDeliveries.ClearSelection()
        dgvDeliveries.CurrentCell = dgvDeliveries.Rows(newRowIndex).Cells(0)
        dgvDeliveries.Rows(newRowIndex).Selected = True

        ' Clear form fields
        txtCustomer.Text = ""
        txtContact.Text = ""
        txtAddress.Text = ""
        txtItems.Text = ""
        cmbPayment.SelectedIndex = -1
        cmbStatus.SelectedIndex = 0 ' Default to Pending
        UpdateStatusIndicator("Pending")

        ' Visual indicator
        lblStatusDisplay.Text = "Creating new entry..."
        pnlStatus.BackColor = Color.LightBlue
    End Sub



End Class
