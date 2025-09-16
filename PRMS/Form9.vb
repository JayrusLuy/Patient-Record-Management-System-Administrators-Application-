Imports MySql.Data.MySqlClient

Public Class Form9
    Private selectedPatientID As String
    Private dateAdded As String

    ' Load selected record with the proper date format and restrict future dates
    Public Sub LoadSelectedRecord(name As String, address As String, familyHead As String, familyNo As String, birthdate As Date, age As String, sex As String, religion As String, civilStatus As String, patientID As String, originalDateAdded As String)
        selectedPatientID = patientID
        dateAdded = originalDateAdded

        TextBox1.Text = name
        ComboBox1.Text = address
        TextBox2.Text = familyHead
        TextBox3.Text = familyNo
        DateTimePicker1.Value = birthdate
        TextBox4.Text = age
        ComboBox2.Text = sex
        TextBox5.Text = religion
        ComboBox3.Text = civilStatus

        ' Set ComboBox items
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add(address)
        ComboBox1.Items.AddRange(New String() {"Bacnor East", "Bacnor West", "Caliguian", "Catabban", "Cullalabo del Norte", "Cullalabo del Sur", "Dalig", "Malasin", "Masigun East", "Raniag", "San Antonino (Poblacion)", "San Bonifacio", "San Miguel"})
        ComboBox1.SelectedItem = address

        ComboBox2.Items.Clear()
        ComboBox2.Items.Add(sex)
        ComboBox2.Items.AddRange(New String() {"Male", "Female"})
        ComboBox2.SelectedItem = sex

        ComboBox3.Items.Clear()
        ComboBox3.Items.Add(civilStatus)
        ComboBox3.Items.AddRange(New String() {"Single", "Married", "Widowed"})
        ComboBox3.SelectedItem = civilStatus

        ' Set the DateTimePicker to only show yyyy-MM-dd and prevent selecting future dates
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy-MM-dd"
        DateTimePicker1.MaxDate = Date.Today
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not AreAllFieldsFilled() Then
            MessageBox.Show("Please ensure all fields are filled.")
            Return
        End If

        Dim name As String = TextBox1.Text.Trim()
        Dim address As String = ComboBox1.Text.Trim()
        Dim familyHead As String = TextBox2.Text.Trim()
        Dim familyNo As String = TextBox3.Text.Trim()
        Dim birthdate As String = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        Dim age As String = TextBox4.Text.Trim()
        Dim sex As String = ComboBox2.Text.Trim()
        Dim religion As String = TextBox5.Text.Trim()
        Dim civilStatus As String = ComboBox3.Text.Trim()

        ' Update the record in the database
        If UpdateData(selectedPatientID, name, address, familyHead, familyNo, birthdate, age, sex, religion, civilStatus) Then
            MessageBox.Show("Record updated successfully!")
            Me.Close()
            Form7.Show()
        End If
    End Sub

    Private Function AreAllFieldsFilled() As Boolean
        Return Not (String.IsNullOrWhiteSpace(TextBox1.Text) OrElse
                    String.IsNullOrWhiteSpace(ComboBox1.Text) OrElse
                    String.IsNullOrWhiteSpace(TextBox2.Text) OrElse
                    String.IsNullOrWhiteSpace(TextBox3.Text) OrElse
                    String.IsNullOrWhiteSpace(TextBox4.Text) OrElse
                    String.IsNullOrWhiteSpace(ComboBox2.Text) OrElse
                    String.IsNullOrWhiteSpace(TextBox5.Text) OrElse
                    String.IsNullOrWhiteSpace(ComboBox3.Text))
    End Function

    Private Function UpdateData(patientID As String, name As String, address As String, familyHead As String, familyNo As String, birthdate As String, age As String, sex As String, religion As String, civilStatus As String) As Boolean
        Dim connectionString As String = "Server=localhost;Database=prms;Uid=root;Pwd=root;"
        Dim query As String = "UPDATE out_patient_info SET name = @name, address = @address, family_head = @family_head, family_no = @family_no, " &
                              "birthdate = @birthdate, age = @age, sex = @sex, religion = @religion, civil_status = @civil_status " &
                              "WHERE patient_id = @patient_id"

        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@patient_id", patientID)
                    command.Parameters.AddWithValue("@name", name)
                    command.Parameters.AddWithValue("@address", address)
                    command.Parameters.AddWithValue("@family_head", familyHead)
                    command.Parameters.AddWithValue("@family_no", familyNo)
                    command.Parameters.AddWithValue("@birthdate", birthdate)
                    command.Parameters.AddWithValue("@age", age)
                    command.Parameters.AddWithValue("@sex", sex)
                    command.Parameters.AddWithValue("@religion", religion)
                    command.Parameters.AddWithValue("@civil_status", civilStatus)

                    Dim rowsAffected As Integer = command.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        Return True
                    Else
                        MessageBox.Show("No records were updated. Check if the patient_id exists.")
                        Return False
                    End If
                End Using
            Catch ex As MySqlException
                MessageBox.Show("An error occurred while updating the data: " & ex.Message)
                Return False
            End Try
        End Using
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set DateTimePicker to prevent future dates
        DateTimePicker1.MaxDate = Date.Today
    End Sub
End Class
