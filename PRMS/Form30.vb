Imports MySql.Data.MySqlClient

Public Class Form30
    ' Store the current table name being shown on DataGridView1
    Private CurrentTableName As String = String.Empty

    Private Sub Form30_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Clear the DataGridView and disable Button1 and Button2
        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()
        Button1.Enabled = False
        Button2.Enabled = False
        Button6.Enabled = False
    End Sub

    ' Method to load data into DataGridView from a specified table
    Private Sub LoadTableData(tableName As String, Optional searchKeyword As String = "")
        ' Connection string
        Dim connectionString As String = "Server=localhost;Database=prms;Uid=root;Pwd=root;"
        Dim query As String = $"SELECT * FROM {tableName}"

        ' Add search filter if a search keyword is provided
        If Not String.IsNullOrWhiteSpace(searchKeyword) Then
            query &= " WHERE " & String.Join(" OR ", GetSearchableColumns(tableName).Select(Function(col) $"{col} LIKE @searchKeyword"))
        End If

        ' Clear the DataGridView
        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()

        ' Fetch data from the specified table
        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()

                ' Execute the query
                Using command As New MySqlCommand(query, connection)
                    ' Add the search keyword parameter if applicable
                    If Not String.IsNullOrWhiteSpace(searchKeyword) Then
                        command.Parameters.AddWithValue("@searchKeyword", $"%{searchKeyword}%")
                    End If

                    Using reader As MySqlDataReader = command.ExecuteReader()
                        ' Dynamically add columns based on the table structure
                        For i As Integer = 0 To reader.FieldCount - 1
                            DataGridView1.Columns.Add(reader.GetName(i), reader.GetName(i))
                        Next

                        ' Populate rows with data from the table
                        While reader.Read()
                            Dim row As New List(Of Object)
                            For i As Integer = 0 To reader.FieldCount - 1
                                row.Add(reader(i))
                            Next
                            DataGridView1.Rows.Add(row.ToArray())
                        End While
                    End Using
                End Using

                ' Customize headers and column settings for the specific table
                CustomizeHeadersAndColumns(tableName)

                ' Enable user interactions
                DataGridView1.ReadOnly = False
                DataGridView1.AllowUserToAddRows = False
                DataGridView1.AllowUserToDeleteRows = False
                DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

                ' Enable Button1 and Button2
                Button1.Enabled = True
                Button2.Enabled = True
                Button6.Enabled = True

                ' Store the current table name
                CurrentTableName = tableName

            Catch ex As MySqlException
                MessageBox.Show($"An error occurred while fetching data: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    ' Method to customize column headers and adjust column widths
    Private Sub CustomizeHeadersAndColumns(tableName As String)
        Select Case tableName
            Case "tbl_doctor"
                If DataGridView1.Columns.Contains("doc_id") Then
                    DataGridView1.Columns("doc_id").HeaderText = "Doctor ID"
                End If
                If DataGridView1.Columns.Contains("doctor") Then
                    DataGridView1.Columns("doctor").HeaderText = "Doctor"
                    DataGridView1.Columns("doctor").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End If

            Case "tbl_illness"
                If DataGridView1.Columns.Contains("ill_id") Then
                    DataGridView1.Columns("ill_id").HeaderText = "Illness ID"
                End If
                If DataGridView1.Columns.Contains("illness") Then
                    DataGridView1.Columns("illness").HeaderText = "Illness"
                    DataGridView1.Columns("illness").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End If

            Case "tbl_service_list"
                If DataGridView1.Columns.Contains("service_id") Then
                    DataGridView1.Columns("service_id").HeaderText = "Service ID"
                End If
                If DataGridView1.Columns.Contains("service") Then
                    DataGridView1.Columns("service").HeaderText = "Services"
                    DataGridView1.Columns("service").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End If
        End Select
    End Sub

    ' Event handler for Button3: Load tbl_doctor into DataGridView
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        LoadTableData("tbl_doctor")
    End Sub

    ' Event handler for Button4: Load tbl_illness into DataGridView
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        LoadTableData("tbl_illness")
    End Sub

    ' Event handler for Button5: Load tbl_service_list into DataGridView
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        LoadTableData("tbl_service_list")
    End Sub

    ' Event handler for Button1: Open Form31 and pass the current table name
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Ensure a table is loaded
        If Not String.IsNullOrEmpty(CurrentTableName) Then
            ' Open Form31 and pass the current table name
            Dim form31 As New Form31()
            form31.CurrentTableName = CurrentTableName ' Assuming Form31 has a property CurrentTableName
            form31.Show()
            Me.Close()
        Else
            MessageBox.Show("No table is currently loaded. Please select a table first.", "No Table Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    ' Event handler for Button2: Delete the selected row
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Ensure a table is loaded and a row is selected
        If String.IsNullOrEmpty(CurrentTableName) Then
            MessageBox.Show("No table is currently loaded. Please select a table first.", "No Table Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a row to delete.", "No Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Get the ID of the selected row
        Dim selectedRow = DataGridView1.SelectedRows(0)
        Dim idColumn = GetPrimaryKeyColumn(CurrentTableName)
        Dim idValue = selectedRow.Cells(idColumn).Value.ToString

        ' Confirmation prompt
        Dim result = MessageBox.Show($"Are you sure you want to delete this record ({idValue})?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then Return

        ' Connection string
        Dim connectionString = "Server=localhost;Database=prms;Uid=root;Pwd=root;"
        Dim deleteQuery = $"DELETE FROM {CurrentTableName} WHERE {idColumn} = @id"

        ' Delete the record
        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()

                Using command As New MySqlCommand(deleteQuery, connection)
                    command.Parameters.AddWithValue("@id", idValue)
                    command.ExecuteNonQuery()
                End Using
                MessageBox.Show("Record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadTableData(CurrentTableName) ' Refresh the table
            Catch ex As MySqlException
                MessageBox.Show($"An error occurred while deleting the record: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    ' Method to get the primary key column for a table
    Private Function GetPrimaryKeyColumn(tableName As String) As String
        Select Case tableName
            Case "tbl_doctor"
                Return "doc_id"
            Case "tbl_illness"
                Return "ill_id"
            Case "tbl_service_list"
                Return "service_id"
            Case Else
                Return String.Empty ' Default if table is unknown
        End Select
    End Function

    ' Event handler for TextBox1 text changed - triggers search
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If Not String.IsNullOrEmpty(CurrentTableName) Then
            ' Reload the table data with the search keyword
            LoadTableData(CurrentTableName, TextBox1.Text.Trim())
        End If
    End Sub

    ' Method to get the list of searchable columns for a table
    Private Function GetSearchableColumns(tableName As String) As List(Of String)
        Select Case tableName
            Case "tbl_doctor"
                Return New List(Of String) From {"doc_id", "doctor"}
            Case "tbl_illness"
                Return New List(Of String) From {"ill_id", "illness"}
            Case "tbl_service_list"
                Return New List(Of String) From {"service_id", "service"}
            Case Else
                Return New List(Of String)() ' Return an empty list for unknown tables
        End Select
    End Function
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ' Ensure a table is loaded and a row is selected
        If String.IsNullOrEmpty(CurrentTableName) Then
            MessageBox.Show("No table is currently loaded. Please select a table first.", "No Table Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a record to view.", "No Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Get the selected row
        Dim selectedRow = DataGridView1.SelectedRows(0)

        ' Get the primary key column for the current table
        Dim idColumn = GetPrimaryKeyColumn(CurrentTableName)

        ' Ensure the primary key column exists
        If String.IsNullOrEmpty(idColumn) OrElse Not DataGridView1.Columns.Contains(idColumn) Then
            MessageBox.Show("Invalid selection. The selected row does not have the necessary identifier.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Get the primary key value of the selected record
        Dim selectedId = selectedRow.Cells(idColumn).Value.ToString()

        ' Open Form21
        Dim form21 As New Form21()

        ' Pass the selected record and the current table name to Form21
        form21.SelectedId = selectedId ' Assuming Form21 has a property 'SelectedId'
        form21.CurrentTableName = CurrentTableName ' Assuming Form21 has a property 'CurrentTableName'

        ' Show Form21
        form21.Show()
        Me.Close()
    End Sub
End Class
