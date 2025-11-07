Imports System.Data.SqlClient
Imports Microsoft.Web.WebView2.WinForms

Public Class UC_Delivery
    Private connectionString As String = "Data Source=DESKTOP-V1R80EP\SQLEXPRESS01;Initial Catalog=POS;Integrated Security=True"

    Private Sub UC_Delivery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDeliveries()
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
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvDeliveries.Rows(e.RowIndex)

            txtDeliveryID.Text = row.Cells("DeliveryID").Value.ToString()
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

                Using chk As New SqlCommand(checkQuery, conn)
                    chk.Parameters.AddWithValue("@DeliveryID", txtDeliveryID.Text)
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
                    cmd.Parameters.AddWithValue("@DeliveryID", txtDeliveryID.Text)
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

    Private Sub btnDelivered_Click(sender As Object, e As EventArgs) Handles btnDelivered.Click
        UpdateDeliveryStatus("Delivered")
    End Sub

    Private Sub btnFailed_Click(sender As Object, e As EventArgs) Handles btnFailed.Click
        UpdateDeliveryStatus("Failed")
    End Sub

    Private Sub UpdateDeliveryStatus(status As String)
        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim query As String = "UPDATE Deliveries SET DeliveryStatus=@Status WHERE DeliveryID=@DeliveryID"

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Status", status)
                    cmd.Parameters.AddWithValue("@DeliveryID", txtDeliveryID.Text)
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

End Class
