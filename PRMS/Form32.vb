Imports MySql.Data.MySqlClient

Public Class Form32
    ' Properties to receive data from the previous form
    Public Property PatientID As String
    Public Property DataSourceTable As String
    Public Property ColumnToDisplay As String

    Private Sub Form32_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Display the label text and load data into ComboBox1
        Label1.Text = Label1.Text ' Label already updated by Form19
        LoadData()
    End Sub
    ' Method to load data into ComboBox1 based on the specified table and column
    Private Sub LoadData()
        Dim connectionString As String = "Server=localhost;Database=prms;Uid=root;Pwd=root;"
        Dim query As String = ""

        ' Determine the query based on the DataSourceTable
        If DataSourceTable = "tbl_diagnosis" Then
            query = "SELECT d.diagnosis_no, i.illness " &
                "FROM tbl_diagnosis d " &
                "INNER JOIN tbl_illness i ON d.diagnosis = i.ill_id " &
                "WHERE d.patient_id = @patient_id"
        ElseIf DataSourceTable = "tbl_service" Then
            query = "SELECT s.service_no, sl.service " &
                "FROM tbl_service s " &
                "INNER JOIN tbl_service_list sl ON s.service = sl.service_id " &
                "WHERE s.patient_id = @patient_id"
        Else
            MessageBox.Show("Invalid data source table specified.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ComboBox1.Items.Clear()

        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@patient_id", PatientID)
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            ' Dynamically add the correct column to the ComboBox
                            If DataSourceTable = "tbl_diagnosis" Then
                                ComboBox1.Items.Add(reader("illness").ToString())
                            ElseIf DataSourceTable = "tbl_service" Then
                                ComboBox1.Items.Add(reader("service").ToString())
                            End If
                        End While
                    End Using
                End Using
                If ComboBox1.Items.Count = 0 Then
                    MessageBox.Show("No records found for the selected patient.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As MySqlException
                MessageBox.Show($"An error occurred while loading data: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Ensure a selection has been made
        If ComboBox1.SelectedIndex = -1 Then
            MessageBox.Show("Please select a record to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Get the selected value from ComboBox1
        Dim selectedValue As String = ComboBox1.SelectedItem.ToString()
        Dim connectionString As String = "Server=localhost;Database=prms;Uid=root;Pwd=root;"
        Dim deleteQuery As String

        ' Define the delete query based on the table being used
        If DataSourceTable = "tbl_diagnosis" Then
            deleteQuery = "DELETE d FROM tbl_diagnosis d " &
                      "INNER JOIN tbl_illness i ON d.diagnosis = i.ill_id " &
                      "WHERE d.patient_id = @patient_id AND i.illness = @selected_value"
        ElseIf DataSourceTable = "tbl_service" Then
            deleteQuery = "DELETE s FROM tbl_service s " &
                      "INNER JOIN tbl_service_list sl ON s.service = sl.service_id " &
                      "WHERE s.patient_id = @patient_id AND sl.service = @selected_value"
        Else
            MessageBox.Show("Invalid data source table specified.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Perform the deletion operation
        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()

                ' Execute the delete command
                Using deleteCommand As New MySqlCommand(deleteQuery, connection)
                    deleteCommand.Parameters.AddWithValue("@patient_id", PatientID)
                    deleteCommand.Parameters.AddWithValue("@selected_value", selectedValue)
                    Dim rowsAffected As Integer = deleteCommand.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MessageBox.Show("Record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("No records were deleted. Please ensure your selection is valid.", "No Changes", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End Using

                ' Close the form after successful deletion
                Me.Close()
            Catch ex As MySqlException
                MessageBox.Show($"An error occurred during the deletion process: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub
End Class