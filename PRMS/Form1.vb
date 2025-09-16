Imports MySql.Data.MySqlClient

Public Class Form1
    Dim conn As MySqlConnection
    Dim COMMAND As MySqlCommand

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Credentials entered by the user
        Dim enteredUsername = TextBox1.Text.Trim()
        Dim enteredPassword = TextBox2.Text.Trim()

        ' Connection string to connect to the MySQL database
        Dim connectionString = "Server=localhost;Database=prms;Uid=root;Pwd=root;"

        ' SQL query to select data from the accounts table based on entered username and matching password
        Dim query = "SELECT username, password, usertype FROM accounts WHERE username = @username AND password = @password"

        ' Using statement ensures the connection is closed and disposed properly
        Using connection As New MySqlConnection(connectionString)
            Try
                ' Open the connection
                connection.Open()

                ' Create a MySqlCommand object with parameters
                Using command As New MySqlCommand(query, connection)
                    ' Add parameters to the command
                    command.Parameters.AddWithValue("@username", enteredUsername)
                    command.Parameters.AddWithValue("@password", enteredPassword)

                    ' Execute the command and retrieve data using MySqlDataReader
                    Using reader = command.ExecuteReader()
                        ' Check if there are any rows
                        If reader.Read() Then
                            ' Read usertype from the database
                            Dim userType = reader("usertype").ToString()

                            ' Check if the user is an admin
                            If userType.ToLower() = "admin" Then
                                ' Log the login details
                                LogLoginDetails(enteredUsername, userType, "logged in as admin", connectionString)

                                ' Retrieve the latest log entry and navigate to Form2
                                Dim latestLogUsername = GetLatestLogUsername(connectionString)

                                ' Successful login as admin: navigate to Form2
                                MessageBox.Show("Login successful as admin!")
                                Hide() ' Hide Form1
                                Dim form2 As New Form2
                                form2.LoggedInUsername = latestLogUsername
                                form2.UserType = userType ' Ensure you set the UserType
                                form2.Show()

                            Else
                                ' User is not an admin
                                MessageBox.Show("Only administrators can log in.")
                                ClearTextBoxes()
                            End If
                        Else
                            ' No matching username and password found
                            MessageBox.Show("Incorrect username or password.")
                            ClearTextBoxes()
                        End If
                    End Using
                End Using
            Catch ex As Exception
                ' Handle any errors that occur during connection or data retrieval
                MessageBox.Show($"An error occurred: {ex.Message}")
                ClearTextBoxes()
            End Try
        End Using
    End Sub

    ' Function to log login details to the logs table
    Private Sub LogLoginDetails(username As String, usertype As String, action As String, connectionString As String)
        ' Generate current date and time
        Dim currentDate As Date = Date.Now
        Dim currentTime As TimeSpan = currentDate.TimeOfDay

        ' SQL query to insert data into the logs table
        Dim logQuery = "INSERT INTO logs (username, usertype, action, date, time) VALUES (@username, @usertype, @action, @date, @time)"

        ' Using statement ensures the connection is closed and disposed properly
        Using connection As New MySqlConnection(connectionString)
            Try
                ' Open the connection
                connection.Open()

                ' Create a MySqlCommand object with parameters
                Using logCommand As New MySqlCommand(logQuery, connection)
                    ' Add parameters to the command
                    logCommand.Parameters.AddWithValue("@username", username)
                    logCommand.Parameters.AddWithValue("@usertype", usertype)
                    logCommand.Parameters.AddWithValue("@action", action)
                    logCommand.Parameters.AddWithValue("@date", currentDate.Date)
                    logCommand.Parameters.AddWithValue("@time", currentTime)

                    ' Execute the command
                    logCommand.ExecuteNonQuery()
                End Using
            Catch ex As Exception
                ' Handle any errors that occur during connection or data insertion
                MessageBox.Show($"An error occurred while logging the login details: {ex.Message}")
            End Try
        End Using
    End Sub

    ' Function to retrieve the latest log entry username from the logs table
    Private Function GetLatestLogUsername(connectionString As String) As String
        Dim latestUsername As String = ""

        ' SQL query to select the latest log entry
        Dim logQuery = "SELECT username FROM logs ORDER BY date DESC, time DESC LIMIT 1"

        ' Using statement ensures the connection is closed and disposed properly
        Using connection As New MySqlConnection(connectionString)
            Try
                ' Open the connection
                connection.Open()

                ' Create a MySqlCommand object
                Using command As New MySqlCommand(logQuery, connection)
                    ' Execute the command and retrieve data using MySqlDataReader
                    Using reader = command.ExecuteReader()
                        ' Check if there are any rows
                        If reader.Read() Then
                            latestUsername = reader("username").ToString()
                        End If
                    End Using
                End Using
            Catch ex As Exception
                ' Handle any errors that occur during connection or data retrieval
                MessageBox.Show($"An error occurred while retrieving the latest log entry: {ex.Message}")
            End Try
        End Using

        Return latestUsername
    End Function

    Private Sub ClearTextBoxes()
        TextBox1.Clear()
        TextBox2.Clear()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
