Imports MySql.Data.MySqlClient

Public Class Form25
    ' Public property to store the PatientID for use as a foreign key
    Public Property PatientID As String

    ' Dictionary to map diagnosis_no to details for ComboBox2 selection
    Private DiagnosisInfoMap As New Dictionary(Of String, Tuple(Of String, String, String))

    Private Sub Form25_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Display PatientID on Label1
        Label1.Text = $"Editing diagnosis for: {PatientID}"

        ' Set DateTimePicker1 to restrict selection to past or current dates only
        DateTimePicker1.MaxDate = Date.Today
        DateTimePicker1.CustomFormat = "yyyy-MM-dd"
        DateTimePicker1.Format = DateTimePickerFormat.Custom

        ' Load available diagnoses for this PatientID into ComboBox2
        LoadDiagnoses()

        ' Load tbl_illness into DataGridView1
        LoadIllnesses()

        ' Disable controls until a diagnosis is selected
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

    ' Method to load diagnoses into ComboBox2 for the specified PatientID
    Private Sub LoadDiagnoses()
        Dim connectionString As String = "Server=localhost;Database=prms;Uid=root;Pwd=root;"
        Dim query As String =
            "SELECT d.diagnosis_no, d.date, doc.doctor, ill.illness " &
            "FROM tbl_diagnosis d " &
            "INNER JOIN tbl_doctor doc ON d.doctor = doc.doc_id " &
            "INNER JOIN tbl_illness ill ON d.diagnosis = ill.ill_id " &
            "WHERE d.patient_id = @patient_id"

        ComboBox2.Items.Clear()
        DiagnosisInfoMap.Clear()

        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@patient_id", PatientID)

                    Using reader As MySqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim diagnosisNo As String = reader("diagnosis_no").ToString()
                            Dim dateValue As String = reader("date").ToString()
                            Dim doctor As String = reader("doctor").ToString()
                            Dim illness As String = reader("illness").ToString()

                            ' Add to ComboBox2 and map details to DiagnosisInfoMap
                            ComboBox2.Items.Add(illness)
                            DiagnosisInfoMap(illness) = Tuple.Create(diagnosisNo, dateValue, doctor)
                        End While
                    End Using
                End Using
            Catch ex As MySqlException
                MessageBox.Show($"Error loading diagnoses: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    ' Method to load tbl_illness into DataGridView1 with optional search keyword
    Private Sub LoadIllnesses(Optional searchKeyword As String = "")
        Dim connectionString As String = "Server=localhost;Database=prms;Uid=root;Pwd=root;"
        Dim query As String = "SELECT ill_id, illness FROM tbl_illness"

        ' Modify query for search functionality
        If Not String.IsNullOrWhiteSpace(searchKeyword) Then
            query &= " WHERE illness LIKE @searchKeyword"
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

    ' Event handler for ComboBox2 selection change
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        ' Ensure an item is selected
        If ComboBox2.SelectedIndex = -1 Then
            DisableControls()
            Return
        End If

        ' Get selected illness
        Dim selectedIllness As String = ComboBox2.SelectedItem.ToString()
        If DiagnosisInfoMap.ContainsKey(selectedIllness) Then
            Dim diagnosisInfo = DiagnosisInfoMap(selectedIllness)

            ' Populate fields
            ComboBox1.Text = diagnosisInfo.Item3 ' Doctor name
            DateTimePicker1.Value = Date.Parse(diagnosisInfo.Item2) ' Diagnosis date

            ' Enable controls
            EnableControls()
        End If
    End Sub

    ' Event handler for Button1 to update the selected diagnosis
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Validate input
        If ComboBox2.SelectedIndex = -1 OrElse ComboBox1.SelectedIndex = -1 OrElse DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a diagnosis, a doctor, and an illness from the list.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Collect updated values
        Dim selectedIllness As String = ComboBox2.SelectedItem.ToString()
        Dim updatedDoctorID As String = GetDoctorID(ComboBox1.Text)
        Dim updatedDate As String = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        Dim selectedIllnessID As String = DataGridView1.SelectedRows(0).Cells("ill_id").Value.ToString()

        If DiagnosisInfoMap.ContainsKey(selectedIllness) Then
            Dim diagnosisNo As String = DiagnosisInfoMap(selectedIllness).Item1

            ' Update the row in tbl_diagnosis
            Dim connectionString As String = "Server=localhost;Database=prms;Uid=root;Pwd=root;"
            Dim updateQuery As String =
                "UPDATE tbl_diagnosis " &
                "SET doctor = @doctor, date = @date, diagnosis = @diagnosis " &
                "WHERE diagnosis_no = @diagnosis_no"

            Using connection As New MySqlConnection(connectionString)
                Try
                    connection.Open()
                    Using command As New MySqlCommand(updateQuery, connection)
                        command.Parameters.AddWithValue("@doctor", updatedDoctorID) ' Update doctor (doc_id)
                        command.Parameters.AddWithValue("@date", updatedDate) ' Update date
                        command.Parameters.AddWithValue("@diagnosis", selectedIllnessID) ' Update diagnosis (ill_id)
                        command.Parameters.AddWithValue("@diagnosis_no", diagnosisNo) ' Identify row using diagnosis_no
                        command.ExecuteNonQuery()
                    End Using

                    MessageBox.Show("Diagnosis updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                    Form7.Show()
                Catch ex As MySqlException
                    MessageBox.Show($"Error updating diagnosis: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    ' Real-time search for illnesses in DataGridView1
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        LoadIllnesses(TextBox1.Text.Trim())
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Clear all controls
        ComboBox1.SelectedIndex = -1 ' Deselect ComboBox1
        ComboBox1.Text = String.Empty ' Clear ComboBox1 text
        ComboBox2.SelectedIndex = -1 ' Deselect ComboBox2
        ComboBox2.Text = String.Empty ' Clear ComboBox2 text
        DateTimePicker1.Value = Date.Today ' Reset DateTimePicker to today's date
        DateTimePicker1.CustomFormat = "yyyy-MM-dd" ' Reset format
        DateTimePicker1.Format = DateTimePickerFormat.Custom

        ' Clear DataGridView1
        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()

        ' Disable controls
        DisableControls()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Close the form and return to Form7
        Me.Close()
        Form7.Show()
    End Sub
End Class
