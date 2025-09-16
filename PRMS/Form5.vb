Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient

Public Class Add_Account
    ' Declare an event to notify the parent form (Form4) to reload data
    Public Event AccountAdded As EventHandler

    ' Form Load event handler
    Private Sub Add_Account(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Populate ComboBox1 with usertype
        ComboBox1.Items.Add("Admin")
        ComboBox1.Items.Add("Standard")

        ' Set Label4 and ComboBox2 to be not visible initially
        Label4.Visible = False
        ComboBox2.Visible = False

        ' Populate ComboBox2 with list of location
        ComboBox2.Items.Add("Bacnor East")
        ComboBox2.Items.Add("Bacnor West")
        ComboBox2.Items.Add("Caliguian")
        ComboBox2.Items.Add("Catabban")
        ComboBox2.Items.Add("Cullalabo del Norte")
        ComboBox2.Items.Add("Cullalabo del Sur")
        ComboBox2.Items.Add("Dalig")
        ComboBox2.Items.Add("Malasin")
        ComboBox2.Items.Add("Masigun East")
        ComboBox2.Items.Add("Raniag")
        ComboBox2.Items.Add("San Antonino (Poblacion)")
        ComboBox2.Items.Add("San Bonifacio")
        ComboBox2.Items.Add("San Miguel")
        ComboBox2.Items.Add("San Roque")
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ' Check if the selected item is "standard"
        If ComboBox1.SelectedItem.ToString().ToLower() = "standard" Then
            ' Show Label4 and ComboBox2
            Label4.Visible = True
            ComboBox2.Visible = True
        Else
            ' Hide Label4 and ComboBox2
            Label4.Visible = False
            ComboBox2.Visible = False
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1 IsNot Nothing Then
            TextBox1.Clear()
        End If

        If TextBox2 IsNot Nothing Then
            TextBox2.Clear()
        End If

        ' Set ComboBox1 text to "admin"
        If ComboBox1 IsNot Nothing Then
            ComboBox1.Text = "admin"
        End If

        ' Hide Label4 and ComboBox2
        If Label4 IsNot Nothing Then
            Label4.Visible = False
        End If

        If ComboBox2 IsNot Nothing Then
            ComboBox2.Visible = False
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Show a message box with Yes and No options
        Dim result As DialogResult = MessageBox.Show("Do you want to create the account?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        ' Check the result of the message box
        If result = DialogResult.Yes Then
            ' Get the data from the textboxes and comboboxes
            Dim username As String = TextBox1.Text
            Dim password As String = TextBox2.Text
            Dim usertype As String = ComboBox1.SelectedItem?.ToString()
            Dim location As String

            ' Check if the usertype is "admin" and set location to Nothing if true
            If usertype IsNot Nothing AndAlso usertype.ToLower() = "admin" Then
                location = Nothing
            Else
                location = ComboBox2.SelectedItem?.ToString()
            End If

            Dim connectionString As String = "Server=localhost;Database=prms;Uid=root;Pwd=root;"

            ' Create SQL query to insert data
            Dim query As String = "INSERT INTO accounts (username, password, usertype, location) VALUES (@username, @password, @usertype, @location)"

            ' Use MySqlConnection and MySqlCommand to execute the query
            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(query, connection)
                    ' Add parameters to the command
                    command.Parameters.AddWithValue("@username", username)
                    command.Parameters.AddWithValue("@password", password)
                    command.Parameters.AddWithValue("@usertype", usertype)

                    ' set location to null if usertype admin
                    If location Is Nothing Then
                        command.Parameters.AddWithValue("@location", DBNull.Value)
                    Else
                        command.Parameters.AddWithValue("@location", location)
                    End If

                    ' Open the connection, execute the query, and close the connection
                    Try
                        connection.Open()
                        command.ExecuteNonQuery()
                        MessageBox.Show("Account successfully added to the database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ' Trigger the AccountAdded event
                        RaiseEvent AccountAdded(Me, EventArgs.Empty)
                    Catch ex As Exception
                        MessageBox.Show("An error occurred while adding the account: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Finally
                        connection.Close()
                    End Try
                End Using
            End Using
        End If
        Me.Close()
    End Sub
End Class
