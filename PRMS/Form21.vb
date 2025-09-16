Imports MySql.Data.MySqlClient

Public Class Form21
    ' Properties to receive data from the previous form
    Public Property SelectedId As String
    Public Property CurrentTableName As String

    Private Sub Form21_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set labels dynamically based on the table name
        Select Case CurrentTableName
            Case "tbl_illness"
                Label1.Text = "Edit Illness"
                Label2.Text = "Insert Illness"
            Case "tbl_service_list"
                Label1.Text = "Edit Service"
                Label2.Text = "Insert Service"
            Case "tbl_doctor"
                Label1.Text = "Edit Doctor"
                Label2.Text = "Insert Doctor"
            Case Else
                Label1.Text = "Edit Record"
                Label2.Text = "Insert Record"
        End Select

        ' Load the selected record into TextBox1
        LoadSelectedRecord()
    End Sub

    Private Sub LoadSelectedRecord()
        ' Connection string
        Dim connectionString As String = "Server=localhost;Database=prms;Uid=root;Pwd=root;"
        Dim query As String = $"SELECT * FROM {CurrentTableName} WHERE {GetPrimaryKeyColumn(CurrentTableName)} = @id"

        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()

                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@id", SelectedId)
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            ' Display the value of the second column in TextBox1
                            TextBox1.Text = reader(1).ToString()
                        End If
                    End Using
                End Using
            Catch ex As MySqlException
                MessageBox.Show($"Error loading record: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Update the selected record in the database
        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            MessageBox.Show("The text field cannot be empty. Please provide a value.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Connection string
        Dim connectionString As String = "Server=localhost;Database=prms;Uid=root;Pwd=root;"
        Dim query As String = $"UPDATE {CurrentTableName} SET {GetSecondColumn(CurrentTableName)} = @value WHERE {GetPrimaryKeyColumn(CurrentTableName)} = @id"

        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()

                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@value", TextBox1.Text.Trim())
                    command.Parameters.AddWithValue("@id", SelectedId)
                    command.ExecuteNonQuery()
                End Using

                MessageBox.Show("Record updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
                Form30.Show()
            Catch ex As MySqlException
                MessageBox.Show($"Error updating record: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Clear the TextBox1
        TextBox1.Clear()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Close the form
        Me.Close()
    End Sub

    ' Method to get the primary key column for the table
    Private Function GetPrimaryKeyColumn(tableName As String) As String
        Select Case tableName
            Case "tbl_illness"
                Return "ill_id"
            Case "tbl_service_list"
                Return "service_id"
            Case "tbl_doctor"
                Return "doc_id"
            Case Else
                Return String.Empty
        End Select
    End Function

    ' Method to get the second column name for the table
    Private Function GetSecondColumn(tableName As String) As String
        Select Case tableName
            Case "tbl_illness"
                Return "illness"
            Case "tbl_service_list"
                Return "service"
            Case "tbl_doctor"
                Return "doctor"
            Case Else
                Return String.Empty
        End Select
    End Function
End Class
