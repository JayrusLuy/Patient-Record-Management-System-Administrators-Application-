Imports MySql.Data.MySqlClient
Public Class Form3
    Public Property LoggedInUsername As String
    Public Property UserType As String

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadLogsData()
    End Sub
    Private Sub LoadLogsData()
        ' Connection string to connect to the MySQL database
        Dim connectionString = "Server=localhost;Database=prms;Uid=root;Pwd=root;"
        Dim query = "SELECT * FROM logs ORDER BY date DESC, time DESC"

        ' Create a DataTable to hold the data
        Dim logsTable As New DataTable()

        ' Using statement ensures the connection is closed and disposed properly
        Using connection As New MySqlConnection(connectionString)
            Try
                ' Open the connection
                connection.Open()

                ' Create a MySqlDataAdapter to fill the DataTable
                Using adapter As New MySqlDataAdapter(query, connection)
                    ' Fill the DataTable with data from the logs table
                    adapter.Fill(logsTable)
                End Using
            Catch ex As Exception
                ' Handle any errors that occur during connection or data retrieval
                MessageBox.Show($"An error occurred while loading the logs data: {ex.Message}")
            End Try
        End Using

        ' Bind the DataTable to the DataGridView
        DataGridView1.DataSource = logsTable

        ' Set the AutoSizeColumnsMode to Fill to make columns fill the entire DataGridView
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        ' Reload the DataGridView data when Label1 is clicked
        LoadLogsData()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
    End Sub

End Class
