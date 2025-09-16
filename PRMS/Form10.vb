Imports MySql.Data.MySqlClient

Public Class Form10
    ' Property to receive the patient_id from Form7
    Public Property PatientID As String

    Private Sub Form10_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Display the patient_id in a label
        Label1.Text = "Patient ID: " & PatientID

        ' Load the list of doctors into ComboBox1
        LoadDoctors()

        ' Set the DateTimePicker format and restrict future dates
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy-MM-dd"
        DateTimePicker1.MaxDate = DateTime.Today ' Prevent future dates

        ' Load tbl_illness into DataGridView1
        LoadIllnesses()
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

    ' Method to load tbl_illness into DataGridView1
    Private Sub LoadIllnesses(Optional searchKeyword As String = "")
        Dim connectionString As String = "Server=localhost;Database=prms;Uid=root;Pwd=root;"
        Dim query As String = "SELECT ill_id, illness FROM tbl_illness"

        ' Add search filter if a search keyword is provided
        If Not String.IsNullOrWhiteSpace(searchKeyword) Then
            query &= " WHERE illness LIKE @searchKeyword"
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
                        DataGridView1.Columns.Add("ill_id", "Illness ID")
                        DataGridView1.Columns.Add("illness", "Illness")

                        ' Populate rows
                        While reader.Read()
                            DataGridView1.Rows.Add(reader("ill_id"), reader("illness"))
                        End While
                    End Using
                End Using

                ' Set column autosize for the illness column
                If DataGridView1.Columns.Contains("illness") Then
                    DataGridView1.Columns("illness").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End If

                ' Configure DataGridView settings
                DataGridView1.ReadOnly = True
                DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            Catch ex As MySqlException
                MessageBox.Show($"Error loading illnesses: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    ' Event handler for TextBox1 text change (search functionality)
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        LoadIllnesses(TextBox1.Text.Trim()) ' Refresh illnesses based on the search term
    End Sub
    ' Event handler for Button1 to add a row in tbl_diagnosis
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Validate inputs
        If ComboBox1.SelectedIndex <= 0 Then
            MessageBox.Show("Please select a doctor.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a diagnosis from the list.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Collect inputs
        Dim selectedDoctorID As String = CType(ComboBox1.SelectedItem, KeyValuePair(Of String, String)).Key
        Dim selectedDiagnosisID As String = DataGridView1.SelectedRows(0).Cells("ill_id").Value.ToString()
        Dim selectedDate As String = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        Dim currentDate As String = DateTime.Now.ToString("yyyy-MM-dd") ' Today's date for date_returned

        ' Generate the next diagnosis_no
        Dim newDiagnosisNo As String = GenerateNextDiagnosisNo()

        ' Insert the new diagnosis into tbl_diagnosis
        Dim connectionString As String = "Server=localhost;Database=prms;Uid=root;Pwd=root;"
        Dim insertQuery As String = "INSERT INTO tbl_diagnosis (diagnosis_no, patient_id, doctor, diagnosis, date, date_returned) " &
                                "VALUES (@diagnosis_no, @patient_id, @doctor, @diagnosis, @date, @date_returned)"

        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New MySqlCommand(insertQuery, connection)
                    command.Parameters.AddWithValue("@diagnosis_no", newDiagnosisNo)
                    command.Parameters.AddWithValue("@patient_id", PatientID)
                    command.Parameters.AddWithValue("@doctor", selectedDoctorID) ' Save the doctor as doc_id
                    command.Parameters.AddWithValue("@diagnosis", selectedDiagnosisID) ' Save the selected illness id
                    command.Parameters.AddWithValue("@date", selectedDate)
                    command.Parameters.AddWithValue("@date_returned", currentDate) ' Save today's date as date_returned
                    command.ExecuteNonQuery()
                End Using
                MessageBox.Show("Diagnosis added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
                Form7.Show()
            Catch ex As MySqlException
                MessageBox.Show($"Error saving diagnosis: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    ' Method to generate the next diagnosis_no in the format diag-****
    Private Function GenerateNextDiagnosisNo() As String
        Dim connectionString As String = "Server=localhost;Database=prms;Uid=root;Pwd=root;"
        Dim query As String = "SELECT diagnosis_no FROM tbl_diagnosis ORDER BY diagnosis_no DESC LIMIT 1"

        Dim nextID As Integer = 1
        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New MySqlCommand(query, connection)
                    Dim result As Object = command.ExecuteScalar()
                    If result IsNot Nothing Then
                        Dim lastID As String = result.ToString().Replace("diag-", "")
                        nextID = Convert.ToInt32(lastID) + 1
                    End If
                End Using
            Catch ex As MySqlException
                MessageBox.Show($"Error generating diagnosis number: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
        Return $"diag-{nextID:D4}"
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
