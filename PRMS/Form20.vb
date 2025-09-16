Imports MySql.Data.MySqlClient

Public Class Form20
    Private Sub Form20_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.AllowUserToAddRows = False ' Disable the extra empty row
        SetupDataGridViewColumns() ' Setup columns in DataGridView
        LoadDataIntoDataGridView() ' Initial load of all data
        CheckAndDeleteOldRecords() ' Check for records older than 30 days
    End Sub

    ' Method to setup DataGridView columns
    Private Sub SetupDataGridViewColumns()
        ' Clear existing columns to avoid duplicate headers
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
        DataGridView1.Columns.Add("date_deleted", "Date Deleted")

        ' Set column headers to always be visible
        DataGridView1.ColumnHeadersVisible = True
    End Sub

    ' Method to load data from deleted_out_patient_info into DataGridView1
    Private Sub LoadDataIntoDataGridView(Optional searchKeyword As String = "")
        Dim connectionString As String = "Server=localhost;Database=prms;Uid=root;Pwd=root;"
        Dim query As String = "SELECT patient_id, name, address, family_head, family_no, age, sex, birthdate, religion, " &
                              "civil_status, date_added, date_deleted " &
                              "FROM deleted_out_patient_info"

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
                     "date_added LIKE @keyword OR " &
                     "date_deleted LIKE @keyword)"
        End If

        ' Clear existing rows only, not columns
        DataGridView1.Rows.Clear()

        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New MySqlCommand(query, connection)
                    ' Add the search keyword parameter if searching
                    If Not String.IsNullOrWhiteSpace(searchKeyword) Then
                        command.Parameters.AddWithValue("@keyword", "%" & searchKeyword & "%")
                    End If

                    ' Execute the command and read data using MySqlDataReader
                    Using reader As MySqlDataReader = command.ExecuteReader()
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
                                reader("date_added").ToString(),
                                reader("date_deleted").ToString()
                            )
                        End While
                    End Using
                End Using
            Catch ex As MySqlException
                MessageBox.Show($"An error occurred: {ex.Message}")
            End Try
        End Using
    End Sub

    ' Event handler for TextBox1 text changed - triggers search
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        ' Pass the search keyword to LoadDataIntoDataGridView to filter results
        LoadDataIntoDataGridView(TextBox1.Text.Trim())
    End Sub

    ' Method to check for records older than 30 days and delete them
    Private Sub CheckAndDeleteOldRecords()
        Dim connectionString As String = "Server=localhost;Database=prms;Uid=root;Pwd=root;"
        Dim selectQuery As String = "SELECT patient_id, date_deleted FROM deleted_out_patient_info"
        Dim deleteQuery As String = "DELETE FROM deleted_out_patient_info WHERE patient_id = @patient_id"
        Dim recordsToDelete As New List(Of String)()
        Dim deleteCount As Integer = 0 ' Counter for deleted records

        ' First, collect patient IDs to delete
        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New MySqlCommand(selectQuery, connection)
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim patientID As String = reader("patient_id").ToString()
                            Dim dateDeleted As Date = Date.Parse(reader("date_deleted").ToString())
                            Dim daysSinceDeleted As Integer = (Date.Today - dateDeleted).Days

                            ' Check if record is older than 30 days
                            If daysSinceDeleted >= 30 Then
                                recordsToDelete.Add(patientID) ' Store for deletion
                            End If
                        End While
                    End Using
                End Using

                ' Now delete each collected record
                For Each patientID In recordsToDelete
                    Using deleteCommand As New MySqlCommand(deleteQuery, connection)
                        deleteCommand.Parameters.AddWithValue("@patient_id", patientID)
                        deleteCommand.ExecuteNonQuery()
                        deleteCount += 1 ' Increment the counter for each deleted record
                    End Using
                Next

                ' Refresh DataGridView to reflect deletions
                LoadDataIntoDataGridView()

                ' Show message box if records were deleted
                If deleteCount > 0 Then
                    MessageBox.Show($"{deleteCount} record(s) have been deleted automatically.", "Auto-Deletion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Catch ex As MySqlException
                MessageBox.Show($"An error occurred during the deletion process: {ex.Message}")
            End Try
        End Using
    End Sub

    ' Button1 click event handler for deleting selected record
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Check if a row is selected in DataGridView1
        If DataGridView1.SelectedRows.Count > 0 Then
            ' Get the selected row
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)

            ' Retrieve the patient_id from the selected row
            Dim patientID As String = selectedRow.Cells("patient_id").Value.ToString()

            ' Confirm deletion
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to permanently delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                ' Perform deletion
                Dim connectionString As String = "Server=localhost;Database=prms;Uid=root;Pwd=root;"
                Dim deleteQuery As String = "DELETE FROM deleted_out_patient_info WHERE patient_id = @patient_id"

                Using connection As New MySqlConnection(connectionString)
                    Try
                        connection.Open()
                        Using deleteCommand As New MySqlCommand(deleteQuery, connection)
                            deleteCommand.Parameters.AddWithValue("@patient_id", patientID)
                            deleteCommand.ExecuteNonQuery()
                        End Using

                        MessageBox.Show("Record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' Refresh DataGridView to reflect the deleted record
                        LoadDataIntoDataGridView()

                    Catch ex As MySqlException
                        MessageBox.Show($"An error occurred while deleting the record: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            End If
        Else
            MessageBox.Show("Please select a record to delete.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Check if a row is selected in DataGridView1
        If DataGridView1.SelectedRows.Count > 0 Then
            ' Get the selected row
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)

            ' Retrieve the patient_id from the selected row
            Dim originalPatientID As String = selectedRow.Cells("patient_id").Value.ToString()

            ' Confirm restoration
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to restore this record?", "Confirm Restore", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Dim connectionString As String = "Server=localhost;Database=prms;Uid=root;Pwd=root;"

                Using connection As New MySqlConnection(connectionString)
                    Try
                        connection.Open()

                        ' Generate a unique patient_id in the format OPD-****
                        Dim newPatientID As String = GenerateUniquePatientID(connection)

                        ' Restore the record with the updated patient_id
                        Dim insertQuery As String = "INSERT INTO out_patient_info (patient_id, name, address, family_head, family_no, age, sex, birthdate, religion, " &
                                                "civil_status, date_added) " &
                                                "SELECT @new_patient_id, name, address, family_head, family_no, age, sex, birthdate, religion, civil_status, date_added " &
                                                "FROM deleted_out_patient_info WHERE patient_id = @original_patient_id"
                        Dim deleteQuery As String = "DELETE FROM deleted_out_patient_info WHERE patient_id = @original_patient_id"

                        ' Insert into out_patient_info
                        Using insertCommand As New MySqlCommand(insertQuery, connection)
                            insertCommand.Parameters.AddWithValue("@new_patient_id", newPatientID)
                            insertCommand.Parameters.AddWithValue("@original_patient_id", originalPatientID)
                            insertCommand.ExecuteNonQuery()
                        End Using

                        ' Delete from deleted_out_patient_info
                        Using deleteCommand As New MySqlCommand(deleteQuery, connection)
                            deleteCommand.Parameters.AddWithValue("@original_patient_id", originalPatientID)
                            deleteCommand.ExecuteNonQuery()
                        End Using

                        MessageBox.Show($"Record restored successfully with Patient ID: {newPatientID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' Refresh DataGridView to reflect the restored record
                        LoadDataIntoDataGridView()

                    Catch ex As MySqlException
                        MessageBox.Show($"An error occurred while restoring the record: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            End If
        Else
            MessageBox.Show("Please select a record to restore.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Function GenerateUniquePatientID(connection As MySqlConnection) As String
        Dim basePrefix As String = "OPD-"
        Dim newPatientID As String = ""
        Dim numericValue As Integer = 1

        ' Query to fetch the highest patient_id with the OPD- prefix
        Dim query As String = "SELECT patient_id FROM out_patient_info WHERE patient_id LIKE 'OPD-%' ORDER BY patient_id DESC LIMIT 1"

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
        newPatientID = $"{basePrefix}{numericValue:D4}" ' Format as OPD-****
        Return newPatientID
    End Function
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
    End Sub
End Class