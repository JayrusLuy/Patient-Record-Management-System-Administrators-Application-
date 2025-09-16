Imports MySql.Data.MySqlClient

Public Class Form29
    ' Public property to store the PatientID received from Form24
    Public Property PatientID As String

    Private Sub Form29_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize checked list items for medical history, treatment, animal bite mode, and category
        InitializeCheckedListBoxes()

        ' Load the data for the specified PatientID after initializing items
        If Not String.IsNullOrEmpty(PatientID) Then
            LoadBiteTreatmentData()
        Else
            MessageBox.Show("No PatientID provided.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If

        ' Set the DateTimePicker format
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy-MM-dd"
        DateTimePicker1.MaxDate = Date.Today ' Limit to today or earlier

        ' Disable additional text boxes and labels initially
        EnableOrDisableTextBoxes()
    End Sub

    ' Method to initialize checked list boxes with predefined items
    Private Sub InitializeCheckedListBoxes()
        ' Initialize CheckedListBox1 for medical history
        CheckedListBox1.Items.Clear()
        CheckedListBox1.Items.Add("Asthma")
        CheckedListBox1.Items.Add("HPN")
        CheckedListBox1.Items.Add("DM")
        CheckedListBox1.Items.Add("PTB")
        CheckedListBox1.Items.Add("CA")
        CheckedListBox1.Items.Add("Allergies")
        CheckedListBox1.Items.Add("Previous Operation")

        ' Initialize CheckedListBox3 for treatment with predefined items
        CheckedListBox3.Items.Clear()
        CheckedListBox3.Items.Add("Anti Tetanus Shot")
        CheckedListBox3.Items.Add("1st Rabies Vaccine Shot")
        CheckedListBox3.Items.Add("2nd Rabies Vaccine Shot")
        CheckedListBox3.Items.Add("3rd Rabies Vaccine Shot")
        CheckedListBox3.Items.Add("4th Rabies Immunization Shot")

        ' Initialize CheckedListBox2 for animal bite mode with predefined items
        CheckedListBox2.Items.Clear()
        CheckedListBox2.Items.Add("Nibbling/Licking of intact skin")
        CheckedListBox2.Items.Add("Nibbling/Licking of wounded broken skin")
        CheckedListBox2.Items.Add("Scratch and abrasion w/ bleeding")
        CheckedListBox2.Items.Add("Handling or ingesting raw infected meat")
        CheckedListBox2.Items.Add("Minor superficial scratch and abrasion w/o or induce bleeding")
        CheckedListBox2.Items.Add("Transdermal bite or scratches w/ spontaneous bleeding")
        CheckedListBox2.Items.Add("Unprotected handling of infected carcass")
        CheckedListBox2.Items.Add("Exposure to bats")
        CheckedListBox2.Items.Add("Feeding and touching animals")
        CheckedListBox2.Items.Add("Exposure to patients with S/Sx of Rabies")

        ' Initialize CheckedListBox4 for category with predefined items
        CheckedListBox4.Items.Clear()
        CheckedListBox4.Items.Add("1")
        CheckedListBox4.Items.Add("2")
        CheckedListBox4.Items.Add("3")
    End Sub

    ' Method to load the bite treatment data from tbl_bite_treatment for the given PatientID
    Private Sub LoadBiteTreatmentData()
        Dim connectionString As String = "Server=localhost;Database=prms;Uid=root;Pwd=root;"
        Dim query As String = "SELECT date_exposure, bpm, cpm, blood_pressure, weight, temp, chief_complaints " &
                              "FROM tbl_bite_treatment WHERE patient_id = @patient_id"

        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@patient_id", PatientID)

                    Using reader As MySqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            ' Map the data to the respective controls
                            DateTimePicker1.Value = If(IsDBNull(reader("date_exposure")), DateTime.Today, Convert.ToDateTime(reader("date_exposure")))
                            TextBox1.Text = reader("bpm").ToString()
                            TextBox2.Text = reader("cpm").ToString()
                            TextBox3.Text = reader("blood_pressure").ToString()
                            TextBox4.Text = reader("weight").ToString()
                            TextBox5.Text = reader("temp").ToString()
                            TextBox9.Text = reader("chief_complaints").ToString()

                            ' Enable or disable labels and textboxes based on loaded data
                            EnableOrDisableTextBoxes()
                        Else
                            MessageBox.Show("No data found for this PatientID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End Using
                End Using
            Catch ex As MySqlException
                MessageBox.Show("An error occurred while loading data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    ' Method to enable or disable labels and text boxes based on checked items in CheckedListBox1
    Private Sub CheckedListBox1_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles CheckedListBox1.ItemCheck
        ' Determine the item being checked or unchecked
        Dim itemText As String = CheckedListBox1.Items(e.Index).ToString()

        ' Enable or disable associated text boxes based on the checked item
        Select Case itemText
            Case "Allergies"
                Label10.Enabled = (e.NewValue = CheckState.Checked)
                TextBox7.Enabled = (e.NewValue = CheckState.Checked)

            Case "CA"
                Label9.Enabled = (e.NewValue = CheckState.Checked)
                TextBox6.Enabled = (e.NewValue = CheckState.Checked)

            Case "Previous Operation"
                Label11.Enabled = (e.NewValue = CheckState.Checked)
                TextBox8.Enabled = (e.NewValue = CheckState.Checked)
        End Select
    End Sub

    ' Method to enable or disable labels and text boxes based on whether the text boxes contain data
    Private Sub EnableOrDisableTextBoxes()
        ' Ensure these controls are disabled initially
        Label9.Enabled = False
        TextBox6.Enabled = False
        Label10.Enabled = False
        TextBox7.Enabled = False
        Label11.Enabled = False
        TextBox8.Enabled = False
    End Sub

    ' Event handler to update the state of labels and text boxes when the text in TextBoxes changes
    Private Sub TextBox_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged, TextBox2.TextChanged, TextBox3.TextChanged
        EnableOrDisableTextBoxes()
    End Sub

    ' Button1 click handler to validate and save data
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Validate that the required CheckedListBoxes have selections
        If CheckedListBox2.CheckedItems.Count = 0 OrElse CheckedListBox3.CheckedItems.Count = 0 OrElse CheckedListBox4.CheckedItems.Count = 0 Then
            MessageBox.Show("Please make a selection in all required CheckedListBoxes.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Collect data from controls
        Dim dateExposure As String = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        Dim bpm As String = TextBox1.Text.Trim()
        Dim cpm As String = TextBox2.Text.Trim()
        Dim bloodPressure As String = TextBox3.Text.Trim()
        Dim weight As String = TextBox4.Text.Trim()
        Dim temp As String = TextBox5.Text.Trim()
        Dim chiefComplaints As String = TextBox9.Text.Trim()

        ' Collect formatted data from CheckedListBoxes
        Dim medicalHistory As String = FormatCheckedListBox(CheckedListBox1, TextBox6, TextBox7, TextBox8)
        Dim animalBiteMode As String = FormatCheckedListBox(CheckedListBox2)
        Dim treatment As String = FormatCheckedListBox(CheckedListBox3)
        Dim category As String = FormatCheckedListBox(CheckedListBox4)

        ' Update the database
        SaveBiteTreatment(dateExposure, bpm, cpm, bloodPressure, weight, temp, treatment, category, animalBiteMode, medicalHistory, chiefComplaints)
    End Sub

    ' Helper method to format CheckedListBox items with optional associated textboxes
    Private Function FormatCheckedListBox(clb As CheckedListBox, Optional caInfo As TextBox = Nothing, Optional allergiesInfo As TextBox = Nothing, Optional operationInfo As TextBox = Nothing) As String
        Dim formattedItems As New List(Of String)
        For Each item In clb.CheckedItems
            Dim itemText = item.ToString()
            If itemText = "CA" AndAlso caInfo IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(caInfo.Text) Then
                itemText &= $" ({caInfo.Text})"
            ElseIf itemText = "Allergies" AndAlso allergiesInfo IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(allergiesInfo.Text) Then
                itemText &= $" ({allergiesInfo.Text})"
            ElseIf itemText = "Previous Operation" AndAlso operationInfo IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(operationInfo.Text) Then
                itemText &= $" ({operationInfo.Text})"
            End If
            formattedItems.Add(itemText)
        Next
        Return String.Join(Environment.NewLine, formattedItems)
    End Function
    ' Method to save the collected data into tbl_bite_treatment
    Private Sub SaveBiteTreatment(dateExposure As String, bpm As String, cpm As String, bloodPressure As String, weight As String, temp As String, treatment As String, category As String, animalBiteMode As String, medicalHistory As String, chiefComplaints As String)
        Dim connectionString As String = "Server=localhost;Database=prms;Uid=root;Pwd=root;"
        Dim query As String = "UPDATE tbl_bite_treatment SET date_exposure = @date_exposure, bpm = @bpm, cpm = @cpm, " &
                              "blood_pressure = @blood_pressure, weight = @weight, temp = @temp, treatment = @treatment, " &
                              "category = @category, animal_bite_mode = @animal_bite_mode, medical_history = @medical_history, " &
                              "chief_complaints = @chief_complaints WHERE patient_id = @patient_id"

        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New MySqlCommand(query, connection)
                    ' Bind parameters
                    command.Parameters.AddWithValue("@date_exposure", dateExposure)
                    command.Parameters.AddWithValue("@bpm", bpm)
                    command.Parameters.AddWithValue("@cpm", cpm)
                    command.Parameters.AddWithValue("@blood_pressure", bloodPressure)
                    command.Parameters.AddWithValue("@weight", weight)
                    command.Parameters.AddWithValue("@temp", temp)
                    command.Parameters.AddWithValue("@treatment", treatment)
                    command.Parameters.AddWithValue("@category", category)
                    command.Parameters.AddWithValue("@animal_bite_mode", animalBiteMode)
                    command.Parameters.AddWithValue("@medical_history", medicalHistory)
                    command.Parameters.AddWithValue("@chief_complaints", chiefComplaints)
                    command.Parameters.AddWithValue("@patient_id", PatientID)
                    command.ExecuteNonQuery()

                    ' Inform the user and close Form29, then show Form7
                    MessageBox.Show("Bite treatment data successfully saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close() ' Close Form29
                    Form7.Show() ' Show Form7
                End Using
            Catch ex As MySqlException
                MessageBox.Show("Error saving data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        Form7.Show()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Clear all TextBoxes
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()

        ' Reset the DateTimePicker to today
        DateTimePicker1.Value = Date.Today

        ' Uncheck all items in each CheckedListBox
        For Each clb As CheckedListBox In New CheckedListBox() {CheckedListBox1, CheckedListBox2, CheckedListBox3, CheckedListBox4}
            For i As Integer = 0 To clb.Items.Count - 1
                clb.SetItemChecked(i, False)
            Next
        Next

        ' Disable additional text boxes and labels linked to CheckedListBox1 selections (Allergies, CA, Previous Operation)
        Label9.Enabled = False
        TextBox6.Enabled = False
        Label10.Enabled = False
        TextBox7.Enabled = False
        Label11.Enabled = False
        TextBox8.Enabled = False
    End Sub
End Class