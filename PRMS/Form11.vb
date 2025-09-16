Imports MySql.Data.MySqlClient

Public Class Form11
    ' Property to receive the patient_id from Form7
    Public Property PatientID As String

    Private Sub Form11_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Display the patient_id in a label
        Label1.Text = "Patient ID: " & PatientID

        ' Load the list of doctors into ComboBox1
        LoadDoctors()

        ' Set the DateTimePicker format and restrict future dates
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy-MM-dd"
        DateTimePicker1.MaxDate = DateTime.Today ' Prevent future dates

        ' Load tbl_service_list into DataGridView1
        LoadServices()
    End Sub

    ' Method to load the list of doctors into ComboBox1
    Private Sub LoadDoctors()
        Dim connectionString As String = "Server=localhost;Database=prms;Uid=root;Pwd=root;"
        Dim query As String = "SELECT doc_id, doctor FROM tbl_doctor"

        ComboBox1.Items.Clear()
        ComboBox1.Items.Add(New KeyValuePair(Of String, String)("0", "Select Doctor")) ' Placeholder
        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New MySqlCommand(query, connection)
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            ' Store doc_id as the key and doctor name as the value
                            ComboBox1.Items.Add(New KeyValuePair(Of String, String)(reader("doc_id").ToString(), reader("doctor").ToString()))
                        End While
                    End Using
                End Using
                ComboBox1.SelectedIndex = 0 ' Default to "Select Doctor"
            Catch ex As MySqlException
                MessageBox.Show($"Error loading doctors: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using

        ' Ensure the ComboBox displays the doctor's name but uses doc_id as the value
        ComboBox1.DisplayMember = "Value"
        ComboBox1.ValueMember = "Key"
    End Sub

    ' Method to load tbl_service_list into DataGridView1
    Private Sub LoadServices(Optional searchKeyword As String = "")
        Dim connectionString As String = "Server=localhost;Database=prms;Uid=root;Pwd=root;"
        Dim query As String = "SELECT service_id, service FROM tbl_service_list"

        ' Add search filter if a search keyword is provided
        If Not String.IsNullOrWhiteSpace(searchKeyword) Then
            query &= " WHERE service LIKE @searchKeyword"
        End If

        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()

        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New MySqlCommand(query, connection)
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


                If DataGridView1.Columns.Contains("service") Then
                    DataGridView1.Columns("service").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End If

                DataGridView1.ReadOnly = True
                DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            Catch ex As MySqlException
                MessageBox.Show($"Error loading services: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    ' Event handler for TextBox1 text change (search functionality)
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        LoadServices(TextBox1.Text.Trim()) ' Refresh services based on the search term
    End Sub

    ' Event handler for Button1 to add a row in tbl_service
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Validate inputs
        If ComboBox1.SelectedIndex <= 0 Then
            MessageBox.Show("Please select a doctor.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a service from the list.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Collect inputs
        Dim selectedDoctorID As String = CType(ComboBox1.SelectedItem, KeyValuePair(Of String, String)).Key
        Dim selectedServiceID As String = DataGridView1.SelectedRows(0).Cells("service_id").Value.ToString()
        Dim selectedDate As String = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        Dim currentDate As String = DateTime.Now.ToString("yyyy-MM-dd") ' Today's date for date_returned

        ' Generate the next service_no
        Dim newServiceNo As String = GenerateNextServiceNo()

        ' Insert the new service into tbl_service
        Dim connectionString As String = "Server=localhost;Database=prms;Uid=root;Pwd=root;"
        Dim insertQuery As String = "INSERT INTO tbl_service (service_no, patient_id, doctor, service, date, date_returned) " &
                                    "VALUES (@service_no, @patient_id, @doctor, @service, @date, @date_returned)"

        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New MySqlCommand(insertQuery, connection)
                    command.Parameters.AddWithValue("@service_no", newServiceNo)
                    command.Parameters.AddWithValue("@patient_id", PatientID)
                    command.Parameters.AddWithValue("@doctor", selectedDoctorID) ' Save the doctor as doc_id
                    command.Parameters.AddWithValue("@service", selectedServiceID) ' Save the selected service id
                    command.Parameters.AddWithValue("@date", selectedDate)
                    command.Parameters.AddWithValue("@date_returned", currentDate) ' Save today's date as date_returned
                    command.ExecuteNonQuery()
                End Using
                MessageBox.Show("Service added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
                Form7.Show()
            Catch ex As MySqlException
                MessageBox.Show($"Error saving service: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    ' Method to generate the next service_no in the format service-****
    Private Function GenerateNextServiceNo() As String
        Dim connectionString As String = "Server=localhost;Database=prms;Uid=root;Pwd=root;"
        Dim query As String = "SELECT service_no FROM tbl_service ORDER BY service_no DESC LIMIT 1"

        Dim nextID As Integer = 1
        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New MySqlCommand(query, connection)
                    Dim result As Object = command.ExecuteScalar()
                    If result IsNot Nothing Then
                        Dim lastID As String = result.ToString().Replace("service-", "")
                        nextID = Convert.ToInt32(lastID) + 1
                    End If
                End Using
            Catch ex As MySqlException
                MessageBox.Show($"Error generating service number: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
        Return $"service-{nextID:D4}"
    End Function
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Clear the search TextBox
        TextBox1.Clear()

        ' Reset ComboBox1 to the first item
        If ComboBox1.Items.Count > 0 Then
            ComboBox1.SelectedIndex = 0
        End If

        ' Reset DateTimePicker1 to today's date
        DateTimePicker1.Value = DateTime.Today
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        Form7.Show()
    End Sub
End Class
