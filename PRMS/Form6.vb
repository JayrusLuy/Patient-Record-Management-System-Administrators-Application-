Imports MySql.Data.MySqlClient

Public Class Form6
    ' Variable to store the original username (before edits)
    Private originalUsername As String

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Store the original username (assuming it's loaded when the form loads)
        originalUsername = TextBox1.Text

        ' Check if ComboBox1 is set to "standard"
        If ComboBox1.SelectedItem IsNot Nothing AndAlso ComboBox1.SelectedItem.ToString().ToLower() = "standard" Then
            Label4.Visible = True
            ComboBox2.Visible = True
        Else
            Label4.Visible = False
            ComboBox2.Visible = False
        End If
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
        ' Ensure TextBox1 and TextBox2 are not Nothing before calling Clear
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
        ' Check if required fields are empty
        If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(TextBox2.Text) OrElse ComboBox1.SelectedItem Is Nothing Then
            MessageBox.Show("Please ensure all fields are filled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Show a message box with Yes and No options to confirm editing the account
        Dim result As DialogResult = MessageBox.Show("Do you want to edit the account?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        ' Check the result of the message box
        If result = DialogResult.Yes Then
            ' Get the updated data from the textboxes and comboboxes
            Dim newUsername As String = TextBox1.Text
            Dim password As String = TextBox2.Text
            Dim usertype As String = ComboBox1.SelectedItem.ToString()
            Dim location As String

            ' Check if usertype is admin
            If usertype.ToLower() = "admin" Then
                location = Nothing
            Else
                location = ComboBox2.SelectedItem?.ToString()
            End If

            ' SQL query
            Dim connectionString As String = "Server=localhost;Database=prms;Uid=root;Pwd=root;"
            Dim query As String = "UPDATE accounts SET username = @newUsername, password = @password, usertype = @usertype, location = @location WHERE username = @originalUsername"

            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(query, connection)
                    ' Add parameters to the command
                    command.Parameters.AddWithValue("@newUsername", newUsername)
                    command.Parameters.AddWithValue("@password", password)
                    command.Parameters.AddWithValue("@usertype", usertype)
                    command.Parameters.AddWithValue("@originalUsername", originalUsername) ' Use original username for WHERE clause

                    ' Add location parameter, handle null case
                    If location Is Nothing Then
                        command.Parameters.AddWithValue("@location", DBNull.Value)
                    Else
                        command.Parameters.AddWithValue("@location", location)
                    End If

                    ' Execute the update query
                    Try
                        connection.Open()
                        Dim rowsAffected As Integer = command.ExecuteNonQuery()

                        ' Check if any rows were updated
                        If rowsAffected > 0 Then
                            MessageBox.Show("Account successfully updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            originalUsername = newUsername ' Update originalUsername to the new one

                            ' Refresh accounts data in Form4
                            For Each form As Form In Application.OpenForms
                                If TypeOf form Is Form4 Then
                                    CType(form, Form4).LoadAccountsData()
                                    Exit For
                                End If
                            Next

                            ' Close the form after a successful update
                            Me.Close()
                        Else
                            MessageBox.Show("No account was updated. Please check the username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Catch ex As Exception
                        MessageBox.Show("An error occurred while updating the account: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Finally
                        connection.Close()
                    End Try
                End Using
            End Using
        End If
    End Sub
End Class