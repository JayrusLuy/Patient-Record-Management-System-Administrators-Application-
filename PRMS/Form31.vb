Imports MySql.Data.MySqlClient

Public Class Form31
    ' Property to receive the table name from Form30
    Public Property CurrentTableName As String

    Private Sub Form31_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Check if the table name is provided
        If String.IsNullOrEmpty(CurrentTableName) Then
            MessageBox.Show("No table information received.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close() ' Close the form if no table name is provided
            Return
        End If

        ' Determine the table function based on the table name and update the labels
        Dim tableFunction As String = GetTableFunction(CurrentTableName)

        ' Update the labels
        Label1.Text = $"Add {tableFunction}"
        Label2.Text = $"Insert {tableFunction}"
    End Sub

    ' Method to map table names to their corresponding table functions
    Private Function GetTableFunction(tableName As String) As String
        Select Case tableName
            Case "tbl_doctor"
                Return "Doctor"
            Case "tbl_illness"
                Return "Illness"
            Case "tbl_service_list"
                Return "Service"
            Case Else
                Return "Unknown Table" ' Fallback for unknown tables
        End Select
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Validate TextBox1 input
        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            MessageBox.Show("Please enter a value before saving.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Determine the column and ID format based on the current table
        Dim idColumn As String = ""
        Dim valueColumn As String = ""
        Dim idFormat As String = ""
        Select Case CurrentTableName
            Case "tbl_doctor"
                idColumn = "doc_id"
                valueColumn = "doctor"
                idFormat = "doc-"
            Case "tbl_illness"
                idColumn = "ill_id"
                valueColumn = "illness"
                idFormat = "illness-"
            Case "tbl_service_list"
                idColumn = "service_id"
                valueColumn = "service"
                idFormat = "service-"
            Case Else
                MessageBox.Show("Invalid table selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
        End Select

        ' Insert the new record into the specified table
        SaveData(CurrentTableName, idColumn, valueColumn, idFormat, TextBox1.Text.Trim())
    End Sub

    ' Method to generate a new ID and save the record into the database
    Private Sub SaveData(tableName As String, idColumn As String, valueColumn As String, idFormat As String, value As String)
        Dim connectionString As String = "Server=localhost;Database=prms;Uid=root;Pwd=root;"
        Dim newID As String = ""

        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()

                ' Query to get the highest current ID
                Dim selectQuery As String = $"SELECT {idColumn} FROM {tableName} WHERE {idColumn} LIKE @idFormat ORDER BY {idColumn} DESC LIMIT 1"
                Using selectCommand As New MySqlCommand(selectQuery, connection)
                    selectCommand.Parameters.AddWithValue("@idFormat", idFormat & "%")
                    Dim result As Object = selectCommand.ExecuteScalar()

                    ' Generate the new ID based on the result
                    If result IsNot Nothing Then
                        Dim lastID As String = result.ToString().Replace(idFormat, "")
                        Dim nextID As Integer = Convert.ToInt32(lastID) + 1
                        newID = $"{idFormat}{nextID:D4}"
                    Else
                        ' If no existing ID is found, start with the first ID
                        newID = $"{idFormat}0001"
                    End If
                End Using

                ' Query to insert the new record
                Dim insertQuery As String = $"INSERT INTO {tableName} ({idColumn}, {valueColumn}) VALUES (@id, @value)"
                Using insertCommand As New MySqlCommand(insertQuery, connection)
                    insertCommand.Parameters.AddWithValue("@id", newID)
                    insertCommand.Parameters.AddWithValue("@value", value)
                    insertCommand.ExecuteNonQuery()
                End Using

                MessageBox.Show($"{valueColumn} added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Clear TextBox1 after saving
                TextBox1.Clear()
                Me.Close()
                Form30.Show()
            Catch ex As MySqlException
                MessageBox.Show($"An error occurred while saving the data: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        Form30.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Clear()
    End Sub
End Class
