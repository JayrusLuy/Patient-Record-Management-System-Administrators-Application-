Imports MySql.Data.MySqlClient

Public Class Form7
    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Prevent the DataGridView from showing an empty row for new entry
        DataGridView1.AllowUserToAddRows = False
        SetupDataGridViewColumns()
        LoadDataIntoDataGridView() ' Initial load of all data
    End Sub

    ' Method to setup DataGridView columns
    Private Sub SetupDataGridViewColumns()
        ' Clear any existing columns
        DataGridView1.Columns.Clear()

        ' Define columns with headers matching the database columns
        DataGridView1.Columns.Add("patient_id", "Patient ID")
        DataGridView1.Columns.Add("name", "Name")
        DataGridView1.Columns.Add("address", "Address")
        DataGridView1.Columns.Add("family_head", "Family Head")
        DataGridView1.Columns.Add("family_no", "Mobile No")
        DataGridView1.Columns.Add("age", "Age")
        DataGridView1.Columns.Add("sex", "Sex")
        DataGridView1.Columns.Add("birthdate", "Birthdate")
        DataGridView1.Columns.Add("religion", "Religion")
        DataGridView1.Columns.Add("civil_status", "Civil Status")
        DataGridView1.Columns.Add("date_added", "Date Added")

        ' Make sure the column headers are always visible
        DataGridView1.ColumnHeadersVisible = True
    End Sub

    ' Method to load data from the database into DataGridView1
    Private Sub LoadDataIntoDataGridView(Optional searchKeyword As String = "")
        ' Connection string
        Dim connectionString As String = "Server=localhost;Database=prms;Uid=root;Pwd=root;"

        ' Base SQL query
        Dim query As String = "SELECT patient_id, name, address, family_head, family_no, age, sex, " &
                              "birthdate, religion, civil_status, date_added " &
                              "FROM out_patient_info"

        ' Modify query if searchKeyword is provided
        If Not String.IsNullOrWhiteSpace(searchKeyword) Then
            query &= " WHERE " &
                     "(patient_id LIKE @keyword OR " &
                     "name LIKE @keyword OR " &
                     "address LIKE @keyword OR " &
                     "family_head LIKE @keyword OR " &
                     "family_no LIKE @keyword OR " &
                     "age LIKE @keyword OR " &
                     "sex LIKE @keyword OR " &
                     "birthdate LIKE @keyword OR " &
                     "religion LIKE @keyword OR " &
                     "civil_status LIKE @keyword OR " &
                     "date_added LIKE @keyword)"
        End If

        ' Clear existing rows
        DataGridView1.Rows.Clear()

        ' Using statement to ensure the connection is disposed properly after use
        Using connection As New MySqlConnection(connectionString)
            Try
                ' Open the connection
                connection.Open()

                ' Create a MySqlCommand with the query and connection
                Using command As New MySqlCommand(query, connection)
                    ' Add the search keyword parameter if searching
                    If Not String.IsNullOrWhiteSpace(searchKeyword) Then
                        command.Parameters.AddWithValue("@keyword", $"%{searchKeyword}%")
                    End If

                    ' Execute the command and read data using MySqlDataReader
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        ' Check if there is any data
                        If reader.HasRows Then
                            ' Loop through each record and add it to the DataGridView
                            While reader.Read()
                                DataGridView1.Rows.Add(
                                    reader("patient_id").ToString(),
                                    reader("name").ToString(),
                                    reader("address").ToString(),
                                    reader("family_head").ToString(),
                                    reader("family_no").ToString(),
                                    reader("age").ToString(),
                                    reader("sex").ToString(),
                                    reader("birthdate").ToString(),
                                    reader("religion").ToString(),
                                    reader("civil_status").ToString(),
                                    reader("date_added").ToString()
                                )
                            End While
                        End If
                    End Using
                End Using
            Catch ex As MySqlException
                ' Show error message if an exception occurs
                MessageBox.Show($"An error occurred: {ex.Message}")
            End Try
        End Using
    End Sub

    ' Event handler for TextBox1 text changed - triggers search
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        LoadDataIntoDataGridView(TextBox1.Text.Trim()) ' Pass the search keyword to the LoadData method
    End Sub

    ' Button1 opens Form8 for adding a new record
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form8.Show()
        Close()
    End Sub

    ' Button2 opens Form9 and sends selected record data to it
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Check if a row is selected in DataGridView1
        If DataGridView1.SelectedRows.Count > 0 Then
            ' Get the selected row
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)

            ' Retrieve data from the selected row's cells
            Dim patientID As String = selectedRow.Cells("patient_id").Value.ToString()
            Dim name As String = selectedRow.Cells("name").Value.ToString()
            Dim address As String = selectedRow.Cells("address").Value.ToString()
            Dim familyHead As String = selectedRow.Cells("family_head").Value.ToString()
            Dim familyNo As String = selectedRow.Cells("family_no").Value.ToString()
            Dim birthdate As Date = Date.Parse(selectedRow.Cells("birthdate").Value.ToString())
            Dim age As String = selectedRow.Cells("age").Value.ToString()
            Dim sex As String = selectedRow.Cells("sex").Value.ToString()
            Dim religion As String = selectedRow.Cells("religion").Value.ToString()
            Dim civilStatus As String = selectedRow.Cells("civil_status").Value.ToString()
            Dim dateAdded As String = selectedRow.Cells("date_added").Value.ToString()

            ' Pass data to Form9 using LoadSelectedRecord method
            Form9.LoadSelectedRecord(name, address, familyHead, familyNo, birthdate, age, sex, religion, civilStatus, patientID, dateAdded)

            ' Show Form9
            Form9.Show()
        Else
            ' Show message if no row is selected
            MessageBox.Show("Please select a record to view details.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Close()
    End Sub

    ' Button3 opens Form13 and passes the selected patient ID
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)
            Dim patientID As String = selectedRow.Cells("patient_id").Value.ToString()
            Dim form13 As New Form13()
            form13.PatientID = patientID
            form13.Show()
        Else
            MessageBox.Show("Please select a record to view details.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        ' Check if a row is selected in DataGridView1
        If DataGridView1.SelectedRows.Count > 0 Then
            ' Confirm the recycling action with the user
            Dim confirmResult As DialogResult = MessageBox.Show("Are you sure you want to recycle the selected record?", "Confirm Recycle", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If confirmResult = DialogResult.No Then
                Return ' Exit if the user chooses "No"
            End If

            ' Get the selected row
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)

            ' Retrieve the patient_id from the selected row
            Dim originalPatientID As String = selectedRow.Cells("patient_id").Value.ToString()

            ' Connection string
            Dim connectionString As String = "Server=localhost;Database=prms;Uid=root;Pwd=root;"

            Using connection As New MySqlConnection(connectionString)
                Try
                    connection.Open()

                    ' Generate a unique patient_id for the deleted_out_patient_info table
                    Dim newPatientID As String = GenerateUniquePatientID(connection, originalPatientID)

                    ' Transfer the record to deleted_out_patient_info with the new patient_id
                    Dim dateDeleted As String = DateTime.Now.ToString("yyyy-MM-dd")
                    Dim insertQuery As String = "INSERT INTO deleted_out_patient_info (patient_id, name, address, family_head, family_no, age, sex, birthdate, religion, civil_status, date_added, date_deleted) " &
                                            "SELECT @new_patient_id, name, address, family_head, family_no, age, sex, birthdate, religion, civil_status, date_added, @date_deleted " &
                                            "FROM out_patient_info WHERE patient_id = @original_patient_id"
                    Dim deleteQuery As String = "DELETE FROM out_patient_info WHERE patient_id = @original_patient_id"

                    ' Insert into deleted_out_patient_info
                    Using insertCommand As New MySqlCommand(insertQuery, connection)
                        insertCommand.Parameters.AddWithValue("@new_patient_id", newPatientID)
                        insertCommand.Parameters.AddWithValue("@original_patient_id", originalPatientID)
                        insertCommand.Parameters.AddWithValue("@date_deleted", dateDeleted)
                        insertCommand.ExecuteNonQuery()
                    End Using

                    ' Delete the record from out_patient_info
                    Using deleteCommand As New MySqlCommand(deleteQuery, connection)
                        deleteCommand.Parameters.AddWithValue("@original_patient_id", originalPatientID)
                        deleteCommand.ExecuteNonQuery()
                    End Using

                    ' Notify the user about the successful operation
                    MessageBox.Show($"Record has been recycled successfully with new Patient ID: {newPatientID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Refresh the DataGridView to reflect the deletion
                    LoadDataIntoDataGridView()

                Catch ex As MySqlException
                    ' Handle any MySQL errors that occur during the operation
                    MessageBox.Show("An error occurred while recycling the data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        Else
            ' Show message if no row is selected
            MessageBox.Show("Please select a record to recycle.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Function GenerateUniquePatientID(connection As MySqlConnection, originalPatientID As String) As String
        Dim basePrefix As String = "OPD-"
        Dim newPatientID As String = originalPatientID
        Dim numericValue As Integer = 1

        ' Query to fetch the highest patient_id with the OPD- prefix in deleted_out_patient_info
        Dim query As String = "SELECT patient_id FROM deleted_out_patient_info WHERE patient_id LIKE 'OPD-%' ORDER BY patient_id DESC LIMIT 1"

        Using command As New MySqlCommand(query, connection)
            Dim result As Object = command.ExecuteScalar()
            If result IsNot Nothing Then
                ' Extract numeric part of the highest patient_id
                Dim highestPatientID As String = result.ToString()
                Dim numericPartMatch = System.Text.RegularExpressions.Regex.Match(highestPatientID, "\d+$")
                If numericPartMatch.Success Then
                    numericValue = Convert.ToInt32(numericPartMatch.Value) + 1
                End If
            End If
        End Using

        ' Generate the new patient_id
        newPatientID = $"{basePrefix}{numericValue:D4}" ' Format as OPD-0002, OPD-0010, etc.
        Return newPatientID
    End Function

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ' Check if a row is selected in DataGridView1
        If DataGridView1.SelectedRows.Count > 0 Then
            ' Get the selected row
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)

            ' Retrieve the patient_id from the selected row
            Dim patientID As String = selectedRow.Cells("patient_id").Value.ToString()

            ' Open Form15 and pass the patient_id to it
            Dim form15 As New Form15()
            form15.PatientID = patientID ' Assuming PatientID property is implemented in Form15
            form15.Show()
        Else
            ' Show message if no row is selected
            MessageBox.Show("Please select a record to proceed.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ' Check if a row is selected in DataGridView1
        If DataGridView1.SelectedRows.Count > 0 Then
            ' Get the selected row
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)

            ' Retrieve the patient_id from the selected row
            Dim patientID As String = selectedRow.Cells("patient_id").Value.ToString()

            ' Open Form19 and pass the patient_id to it
            Dim form19 As New Form19()
            form19.PatientID = patientID ' Assuming PatientID property is implemented in Form19
            form19.Show()
        Else
            ' Show message if no row is selected
            MessageBox.Show("Please select a record to proceed.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' Check if a row is selected in DataGridView1
        If DataGridView1.SelectedRows.Count > 0 Then
            ' Get the selected row
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)

            ' Retrieve the patient_id from the selected row
            Dim patientID As String = selectedRow.Cells("patient_id").Value.ToString()

            ' Open Form24 and pass the patient_id to it
            Dim form24 As New Form24()
            form24.PatientID = patientID ' Assuming PatientID property is implemented in Form24
            form24.Show()
        Else
            ' Show message if no row is selected
            MessageBox.Show("Please select a record to proceed.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
End Class
