Imports MySql.Data.MySqlClient

Public Class Form2
    Public Property LoggedInUsername As String
    Public Property UserType As String
    Private isLogoutConfirmed As Boolean = False ' Flag to track if logout was confirmed

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set the StartPosition to Manual
        Me.StartPosition = FormStartPosition.Manual

        ' Calculate the position for the middle-left of the screen
        Dim screenHeight As Integer = Screen.PrimaryScreen.WorkingArea.Height
        Dim formHeight As Integer = Me.Height
        Dim xPosition As Integer = 0  ' Left edge of the screen
        Dim yPosition As Integer = (screenHeight - formHeight) \ 2

        ' Set the location to middle-left
        Me.Location = New Point(xPosition, yPosition)

        ' Display the logged-in username on Label3
        Label3.Text = $"User: {LoggedInUsername}"
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        ' Prompt user with a confirmation message box
        Dim result As DialogResult = MessageBox.Show("Do you want to confirm logging out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            ' Open Form1 (Login form) first, so it remains open
            Dim form1 As New Form1
            form1.Show()

            ' Close all other forms except Form1 and Form2 (the current form)
            For Each form As Form In Application.OpenForms.Cast(Of Form).ToList()
                If form IsNot Me AndAlso Not TypeOf form Is Form1 Then
                    form.Close()
                End If
            Next

            ' Connection string to connect to the MySQL database
            Dim connectionString = "Server=localhost;Database=prms;Uid=root;Pwd=root;"

            ' Log the logout details
            LogLogoutDetails(LoggedInUsername, UserType, "logged out as admin", connectionString)

            ' Set the flag to true, allowing the form to close
            isLogoutConfirmed = True

            ' Close this form (Form2)
            Me.Close()
        End If
    End Sub

    ' Function to log logout details to the logs table
    Private Sub LogLogoutDetails(username As String, usertype As String, action As String, connectionString As String)
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
                MessageBox.Show($"An error occurred while logging the logout details: {ex.Message}")
            End Try
        End Using
    End Sub

    ' Prevent the form from closing unless Button7 is clicked
    Private Sub Form2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not isLogoutConfirmed Then
            ' If logout is not confirmed, prevent the form from closing
            MessageBox.Show("You cannot close this form directly. Please use the Logout button.", "Logout Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            e.Cancel = True
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form3.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Form4.Show()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Form26.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form27.Show
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form7.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form20.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form30.Show()
    End Sub
End Class
