Imports MySql.Data.MySqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form4
    Public Property LoggedInUsername As String
    Public Property UserType As String
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAccountsData()
    End Sub

    Public Sub LoadAccountsData(Optional searchQuery As String = "")
        ' Connection string to connect to the MySQL database
        Dim connectionString = "Server=localhost;Database=prms;Uid=root;Pwd=root;"

        ' SQL query to select all data or filter based on the search query
        Dim query As String
        If String.IsNullOrWhiteSpace(searchQuery) Then
            query = "SELECT * FROM accounts"
        Else
            query = "SELECT * FROM accounts WHERE username LIKE @searchQuery OR password LIKE @searchQuery OR usertype LIKE @searchQuery OR location LIKE @searchQuery"
        End If

        ' Create a DataTable to hold the data
        Dim accountsTable As New DataTable()

        ' Using statement ensures the connection is closed and disposed properly
        Using connection As New MySqlConnection(connectionString)
            Try
                ' Open the connection
                connection.Open()

                ' Create a MySqlDataAdapter to fill the DataTable
                Using adapter As New MySqlDataAdapter(query, connection)
                    If Not String.IsNullOrWhiteSpace(searchQuery) Then
                        adapter.SelectCommand.Parameters.AddWithValue("@searchQuery", "%" & searchQuery & "%")
                    End If
                    ' Fill the DataTable with data from the accounts table
                    adapter.Fill(accountsTable)
                End Using
            Catch ex As Exception
                ' Handle any errors that occur during connection or data retrieval
                MessageBox.Show($"An error occurred while loading the accounts data: {ex.Message}")
            End Try
        End Using

        ' Bind the DataTable to the DataGridView
        DataGridView1.DataSource = accountsTable

        ' Set the AutoSizeColumnsMode to Fill to make columns fill the entire DataGridView
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Create an instance of Add_Account (Form5)
        Dim addAccountForm As New Add_Account

        ' Subscribe to the AccountAdded event
        AddHandler addAccountForm.AccountAdded, AddressOf Me.ReloadDataGrid

        ' Show the Add_Account form
        addAccountForm.Show()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        ' Reload the table data when Label1 is clicked
        LoadAccountsData()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Check if a row is selected
        If DataGridView1.SelectedRows.Count > 0 Then
            ' Get the data from the selected row
            Dim selectedUsername As String = DataGridView1.SelectedRows(0).Cells("username").Value.ToString()
            Dim selectedPassword As String = DataGridView1.SelectedRows(0).Cells("password").Value.ToString()
            Dim selectedUsertype As String = DataGridView1.SelectedRows(0).Cells("usertype").Value.ToString()
            Dim selectedLocation As String = If(DataGridView1.SelectedRows(0).Cells("location").Value Is DBNull.Value, Nothing, DataGridView1.SelectedRows(0).Cells("location").Value.ToString())

            ' Create an instance of Form6
            Dim form6 As New Form6

            ' Pass the data to Form6
            form6.TextBox1.Text = selectedUsername
            form6.TextBox2.Text = selectedPassword
            form6.ComboBox1.SelectedItem = selectedUsertype

            If selectedUsertype.ToLower() = "admin" Then
                form6.ComboBox2.Visible = False
                form6.Label4.Visible = False
            Else
                form6.ComboBox2.Visible = True
                form6.Label4.Visible = True
                form6.ComboBox2.SelectedItem = selectedLocation
            End If

            ' Show Form6
            form6.Show()

        Else
            MessageBox.Show("Please select a row to edit.", "No selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Check if a row is selected
        If DataGridView1.SelectedRows.Count > 0 Then
            ' Get the username of the selected row
            Dim selectedUsername As String = DataGridView1.SelectedRows(0).Cells("username").Value.ToString()

            ' Ask for confirmation
            Dim result As DialogResult = MessageBox.Show("Do you want to delete the selected account?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                Dim connectionString As String = "Server=localhost;Database=prms;Uid=root;Pwd=root;"

                ' Create SQL query to delete data
                Dim query As String = "DELETE FROM accounts WHERE username = @username"

                ' Use MySqlConnection and MySqlCommand to execute the query
                Using connection As New MySqlConnection(connectionString)
                    Using command As New MySqlCommand(query, connection)
                        ' Add parameter to the command
                        command.Parameters.AddWithValue("@username", selectedUsername)

                        ' Open the connection, execute the query, and close the connection
                        Try
                            connection.Open()
                            command.ExecuteNonQuery()
                            MessageBox.Show("Account successfully deleted from the database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Catch ex As Exception
                            MessageBox.Show("An error occurred while deleting the account: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Finally
                            connection.Close()
                        End Try
                    End Using
                End Using

                ' Reload the data in the DataGridView
                LoadAccountsData()
            End If
        Else
            MessageBox.Show("Please select a row to delete.", "No selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    ' Method to reload the DataGridView
    Private Sub ReloadDataGrid()
        LoadAccountsData()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        ' Call LoadAccountsData with the search query from TextBox1
        LoadAccountsData(TextBox1.Text)
    End Sub
End Class
