Imports MySql.Data.MySqlClient

Public Class Form8
    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set default values for ComboBoxes and DateTimePicker
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("Select Address") ' Placeholder
        ComboBox1.Items.AddRange(New String() {
            "Bacnor East", "Bacnor West", "Caliguian", "Catabban", "Cullalabo del Norte",
            "Cullalabo del Sur", "Dalig", "Malasin", "Masigun East", "Raniag",
            "San Antonino (Poblacion)", "San Bonifacio", "San Miguel"
        })
        ComboBox1.SelectedIndex = 0 ' Set default to "Select Address"

        ComboBox2.Items.Clear()
        ComboBox2.Items.Add("Select Sex") ' Placeholder
        ComboBox2.Items.AddRange(New String() {"Male", "Female"})
        ComboBox2.SelectedIndex = 0 ' Set default to "Select Sex"

        ComboBox3.Items.Clear()
        ComboBox3.Items.Add("Select Civil Status") ' Placeholder
        ComboBox3.Items.AddRange(New String() {"Single", "Married", "Widowed"})
        ComboBox3.SelectedIndex = 0 ' Set default to "Select Civil Status"

        ' Set DateTimePicker format to custom and prevent future dates
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "0000-00-00" ' Placeholder format
        DateTimePicker1.MaxDate = Date.Today ' Prevent selecting future dates

        AddHandler DateTimePicker1.ValueChanged, AddressOf DateTimePicker1_ValueChanged
    End Sub

    ' Method to calculate age and display it in TextBox4 whenever DateTimePicker1 changes
    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs)
        DateTimePicker1.CustomFormat = "yyyy-MM-dd" ' Set format to date only after a selection is made
        TextBox4.Text = CalculateAge(DateTimePicker1.Value).ToString()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Validate all input fields
        If Not AreAllFieldsFilled() Then
            MessageBox.Show("Ensure that all fields are entered.")
            Return
        End If

        ' Collect data from the controls
        Dim name As String = TextBox1.Text.Trim()
        Dim address As String = ComboBox1.Text.Trim()
        Dim familyHead As String = TextBox2.Text.Trim()
        Dim familyNo As String = TextBox3.Text.Trim()
        Dim birthdate As String = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        Dim age As Integer = CalculateAge(DateTimePicker1.Value)
        Dim sex As String = ComboBox2.Text.Trim()
        Dim religion As String = TextBox5.Text.Trim()
        Dim civilStatus As String = ComboBox3.Text.Trim()

        ' Check if a record with the same details already exists
        If RecordExists(name, address, familyHead, familyNo, birthdate, age, sex, religion, civilStatus) Then
            MessageBox.Show("Record already exists.", "Duplicate Detected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Close()
            Form7.Show()
            Return
        End If

        ' Generate a unique patient ID in the format "OPD-XXXX"
        Dim patientID As String = GenerateNextPatientID()

        ' Insert data into the database
        If SaveData(patientID, name, address, familyHead, familyNo, birthdate, age, sex, religion, civilStatus) Then
            MessageBox.Show("Record saved successfully!")
            Me.Close()
            Form7.Show()
        End If
    End Sub

    ' Method to check for duplicate records
    Private Function RecordExists(name As String, address As String, familyHead As String, familyNo As String, birthdate As String, age As Integer, sex As String, religion As String, civilStatus As String) As Boolean
        Dim connectionString As String = "Server=localhost;Database=prms;Uid=root;Pwd=root;"
        Dim query As String = "SELECT COUNT(*) FROM out_patient_info WHERE name = @name AND address = @address AND family_head = @family_head " &
                              "AND family_no = @family_no AND birthdate = @birthdate AND age = @age AND sex = @sex AND religion = @religion AND civil_status = @civil_status"
        Dim recordCount As Integer = 0

        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New MySqlCommand(query, connection)
                    ' Add parameters
                    command.Parameters.AddWithValue("@name", name)
                    command.Parameters.AddWithValue("@address", address)
                    command.Parameters.AddWithValue("@family_head", familyHead)
                    command.Parameters.AddWithValue("@family_no", familyNo)
                    command.Parameters.AddWithValue("@birthdate", birthdate)
                    command.Parameters.AddWithValue("@age", age)
                    command.Parameters.AddWithValue("@sex", sex)
                    command.Parameters.AddWithValue("@religion", religion)
                    command.Parameters.AddWithValue("@civil_status", civilStatus)

                    ' Execute the command
                    recordCount = Convert.ToInt32(command.ExecuteScalar())
                End Using
            Catch ex As MySqlException
                MessageBox.Show("An error occurred while checking for duplicates: " & ex.Message)
            End Try
        End Using

        Return recordCount > 0 ' Returns true if a matching record is found
    End Function

    ' Function to check if all fields are filled
    Private Function AreAllFieldsFilled() As Boolean
        Dim isDateSelected As Boolean = DateTimePicker1.CustomFormat <> "0000-00-00"
        Return Not (String.IsNullOrWhiteSpace(TextBox1.Text) OrElse
                    ComboBox1.SelectedIndex = 0 OrElse
                    String.IsNullOrWhiteSpace(TextBox2.Text) OrElse
                    String.IsNullOrWhiteSpace(TextBox3.Text) OrElse
                    ComboBox2.SelectedIndex = 0 OrElse
                    String.IsNullOrWhiteSpace(TextBox5.Text) OrElse
                    ComboBox3.SelectedIndex = 0 OrElse
                    Not isDateSelected)
    End Function

    ' Function to calculate age based on birthdate
    Private Function CalculateAge(birthDate As Date) As Integer
        Dim today As Date = Date.Today
        Dim age As Integer = today.Year - birthDate.Year
        If birthDate > today.AddYears(-age) Then age -= 1
        Return age
    End Function

    ' Function to generate the next sequential patient ID in the format "OPD-XXXX"
    Private Function GenerateNextPatientID() As String
        Dim connectionString As String = "Server=localhost;Database=prms;Uid=root;Pwd=root;"
        Dim nextID As Integer = 1
        Dim newPatientID As String

        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()
                Dim query As String = "SELECT patient_id FROM out_patient_info WHERE patient_id LIKE 'OPD-%' ORDER BY patient_id DESC LIMIT 1"
                Using command As New MySqlCommand(query, connection)
                    Dim result As Object = command.ExecuteScalar()
                    If result IsNot Nothing Then
                        Dim lastID As String = result.ToString().Replace("OPD-", "")
                        nextID = Convert.ToInt32(lastID) + 1
                    End If
                End Using
            Catch ex As MySqlException
                MessageBox.Show("Error retrieving next patient ID: " & ex.Message)
            End Try
        End Using

        newPatientID = $"OPD-{nextID:D4}"
        Return newPatientID
    End Function

    ' Function to save data to the database
    Private Function SaveData(patientID As String, name As String, address As String, familyHead As String, familyNo As String, birthdate As String, age As Integer, sex As String, religion As String, civilStatus As String) As Boolean
        Dim connectionString As String = "Server=localhost;Database=prms;Uid=root;Pwd=root;"
        Dim query As String = "INSERT INTO out_patient_info (patient_id, name, address, family_head, family_no, birthdate, age, sex, religion, civil_status, date_added) " &
                              "VALUES (@patient_id, @name, @address, @family_head, @family_no, @birthdate, @age, @sex, @religion, @civil_status, @date_added)"
        Dim dateAdded As String = DateTime.Now.ToString("yyyy-MM-dd")

        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New MySqlCommand(query, connection)
                    ' Add parameters
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
                    command.Parameters.AddWithValue("@date_added", dateAdded)

                    ' Execute the insert command
                    command.ExecuteNonQuery()
                    Return True
                End Using
            Catch ex As MySqlException
                MessageBox.Show("An error occurred while saving the data: " & ex.Message)
                Return False
            End Try
        End Using
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Clear all TextBox controls and reset ComboBoxes
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
        ComboBox3.SelectedIndex = 0
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "0000-00-00"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        Form7.Show()
    End Sub
End Class