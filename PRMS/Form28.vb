Imports MySql.Data.MySqlClient

Public Class Form28
    ' Public property to store the PatientID for use as a foreign key
    Public Property PatientID As String

    ' Dictionary to map service_no to details for ComboBox2 selection
    Private ServiceInfoMap As New Dictionary(Of String, Tuple(Of String, String, String))

    Private Sub Form28_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Display PatientID on Label1
        Label1.Text = $"Editing service for: {PatientID}"

        ' Set DateTimePicker1 to restrict selection to past or current dates only
        DateTimePicker1.MaxDate = Date.Today
        DateTimePicker1.CustomFormat = "yyyy-MM-dd"
        DateTimePicker1.Format = DateTimePickerFormat.Custom

        ' Load available services for this PatientID into ComboBox2
        LoadServices()

        ' Load tbl_service_list into DataGridView1
        LoadServiceList()

        ' Disable controls initially
        DisableControls()
    End Sub

    ' Method to disable all controls except ComboBox2
    Private Sub DisableControls()
        ComboBox1.Enabled = False
        DateTimePicker1.Enabled = False
        DataGridView1.Enabled = False
        Button1.Enabled = False
    End Sub

    ' Method to enable all controls
    Private Sub EnableControls()
        ComboBox1.Enabled = True
        DateTimePicker1.Enabled = True
        DataGridView1.Enabled = True
        Button1.Enabled = True
    End Sub

    ' Method to load services into ComboBox2 for the specified PatientID
    Private Sub LoadServices()
        Dim connectionString As String = "Server=localhost;Database=prms;Uid=root;Pwd=root;"
        Dim query As String =
            "SELECT s.service_no, s.date, d.doctor, sl.service " &
            "FROM tbl_service s " &
            "INNER JOIN tbl_doctor d ON s.doctor = d.doc_id " &
            "INNER JOIN tbl_service_list sl ON s.service = sl.service_id " &
            "WHERE s.patient_id = @patient_id"

        ComboBox2.Items.Clear()
        ServiceInfoMap.Clear()

        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@patient_id", PatientID)

                    Using reader As MySqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim serviceNo As String = reader("service_no").ToString()
                            Dim dateValue As String = reader("date").ToString()
                            Dim doctor As String = reader("doctor").ToString()
                            Dim service As String = reader("service").ToString()

                            ' Add to ComboBox2 and map details to ServiceInfoMap
                            ComboBox2.Items.Add(service)
                            ServiceInfoMap(service) = Tuple.Create(serviceNo, dateValue, doctor)
                        End While
                    End Using
                End Using
            Catch ex As MySqlException
                MessageBox.Show($"Error loading services: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    ' Method to load tbl_service_list into DataGridView1 with optional search keyword
    Private Sub LoadServiceList(Optional searchKeyword As String = "")
        Dim connectionString As String = "Server=localhost;Database=prms;Uid=root;Pwd=root;"
        Dim query As String = "SELECT service_id, service FROM tbl_service_list"

        ' Modify query for search functionality
        If Not String.IsNullOrWhiteSpace(searchKeyword) Then
            query &= " WHERE service LIKE @searchKeyword"
        End If

        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()

        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New MySqlCommand(query, connection)
                    ' Add parameter for search keyword if provided
                    If Not String.IsNullOrWhiteSpace(searchKeyword) Then
                        command.Parameters.AddWithValue("@searchKeyword", $"%{searchKeyword}%")
                    End If

                    Using reader As MySqlDataReader = command.ExecuteReader()
                        ' Add columns dynamically
                        DataGridView1.Columns.Add("service_id", "Service ID")
                        DataGridView1.Columns.Add("service", "Service")

                        ' Populate rows
                        While reader.Read()
                            DataGridView1.Rows.Add(reader("service_id"), reader("service"))
                        End While
                    End Using
                End Using

                ' Set column autosize for the service column
                If DataGridView1.Columns.Contains("service") Then
                    DataGridView1.Columns("service").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End If

                ' Configure DataGridView settings
                DataGridView1.ReadOnly = True
                DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            Catch ex As MySqlException
                MessageBox.Show($"Error loading service list: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    ' Event handler for ComboBox2 selection change
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        ' Ensure an item is selected
        If ComboBox2.SelectedIndex = -1 Then
            DisableControls()
            Return
        End If

        ' Get selected service
        Dim selectedService As String = ComboBox2.SelectedItem.ToString()
        If ServiceInfoMap.ContainsKey(selectedService) Then
            Dim serviceInfo = ServiceInfoMap(selectedService)

            ' Populate fields
            ComboBox1.Text = serviceInfo.Item3 ' Doctor name
            DateTimePicker1.Value = Date.Parse(serviceInfo.Item2) ' Service date

            ' Enable controls
            EnableControls()
        End If
    End Sub

    ' Event handler for Button1 to update the selected service
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Validate input
        If ComboBox2.SelectedIndex = -1 OrElse ComboBox1.SelectedIndex = -1 OrElse DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a service, a doctor, and a service from the list.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Collect updated values
        Dim selectedService As String = ComboBox2.SelectedItem.ToString()
        Dim updatedDoctorID As String = GetDoctorID(ComboBox1.Text)
        Dim updatedDate As String = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        Dim selectedServiceID As String = DataGridView1.SelectedRows(0).Cells("service_id").Value.ToString()

        If ServiceInfoMap.ContainsKey(selectedService) Then
            Dim serviceNo As String = ServiceInfoMap(selectedService).Item1

            ' Update the row in tbl_service
            Dim connectionString As String = "Server=localhost;Database=prms;Uid=root;Pwd=root;"
            Dim updateQuery As String =
                "UPDATE tbl_service " &
                "SET doctor = @doctor, date = @date, service = @service " &
                "WHERE service_no = @service_no"

            Using connection As New MySqlConnection(connectionString)
                Try
                    connection.Open()
                    Using command As New MySqlCommand(updateQuery, connection)
                        command.Parameters.AddWithValue("@doctor", updatedDoctorID) ' Update doctor (doc_id)
                        command.Parameters.AddWithValue("@date", updatedDate) ' Update date
                        command.Parameters.AddWithValue("@service", selectedServiceID) ' Update service (service_id)
                        command.Parameters.AddWithValue("@service_no", serviceNo) ' Identify row using service_no
                        command.ExecuteNonQuery()
                    End Using

                    MessageBox.Show("Service updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                Catch ex As MySqlException
                    MessageBox.Show($"Error updating service: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End If
    End Sub

    ' Helper method to get doc_id for a given doctor name
    Private Function GetDoctorID(doctorName As String) As String
        Dim connectionString As String = "Server=localhost;Database=prms;Uid=root;Pwd=root;"
        Dim query As String = "SELECT doc_id FROM tbl_doctor WHERE doctor = @doctor"

        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@doctor", doctorName)
                    Dim result As Object = command.ExecuteScalar()
                    If result IsNot Nothing Then
                        Return result.ToString()
                    End If
                End Using
            Catch ex As MySqlException
                MessageBox.Show($"Error fetching doctor ID: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
        Return String.Empty
    End Function

    ' Event handler for TextBox1.TextChanged to filter DataGridView1 in real time
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        LoadServiceList(TextBox1.Text.Trim()) ' Reload DataGridView with search filter
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Clear all fields and disable controls except ComboBox2
        ComboBox1.SelectedIndex = -1
        ComboBox1.Text = String.Empty
        ComboBox2.SelectedIndex = -1
        ComboBox2.Text = String.Empty
        DateTimePicker1.Value = DateTime.Now
        DataGridView1.ClearSelection()

        ' Disable controls
        DisableControls()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        Form7.Show()
    End Sub
End Class
