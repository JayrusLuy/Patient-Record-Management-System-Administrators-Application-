Imports MySql.Data.MySqlClient

Public Class Form12
    ' Property to receive the patient_id from Form13
    Public Property PatientID As String

    Private Sub Form12_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize checked list items for medical history
        CheckedListBox1.Items.Add("Asthma")
        CheckedListBox1.Items.Add("HPN")
        CheckedListBox1.Items.Add("DM")
        CheckedListBox1.Items.Add("PTB")
        CheckedListBox1.Items.Add("CA")
        CheckedListBox1.Items.Add("Allergies")
        CheckedListBox1.Items.Add("Previous Operation")

        ' Set the DateTimePicker format
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy-MM-dd"
        DateTimePicker1.MaxDate = Date.Today ' Limit to today or earlier

        ' Disable additional text boxes and labels initially
        Label9.Enabled = False
        TextBox6.Enabled = False
        Label10.Enabled = False
        TextBox7.Enabled = False
        Label11.Enabled = False
        TextBox8.Enabled = False
    End Sub

    Private Sub CheckedListBox1_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles CheckedListBox1.ItemCheck
        ' Enable or disable additional textboxes based on selected medical history
        Dim item = CheckedListBox1.Items(e.Index).ToString()

        If item = "CA" Then
            Label9.Enabled = e.NewValue = CheckState.Checked
            TextBox6.Enabled = e.NewValue = CheckState.Checked
        ElseIf item = "Allergies" Then
            Label10.Enabled = e.NewValue = CheckState.Checked
            TextBox7.Enabled = e.NewValue = CheckState.Checked
        ElseIf item = "Previous Operation" Then
            Label11.Enabled = e.NewValue = CheckState.Checked
            TextBox8.Enabled = e.NewValue = CheckState.Checked
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Validate that all required fields have data
        If Not AreAllRequiredFieldsFilled() Then
            MessageBox.Show("All fields must be entered.")
            Return
        End If

        ' Collect data from the form controls
        Dim dateExposure As String = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        Dim bpm As String = TextBox1.Text.Trim()
        Dim cpm As String = TextBox2.Text.Trim()
        Dim bloodPressure As String = TextBox3.Text.Trim()
        Dim weight As String = TextBox4.Text.Trim()
        Dim temp As String = TextBox5.Text.Trim()
        Dim chiefComplaints As String = TextBox9.Text.Trim()
        Dim dateReturned As String = DateTime.Now.ToString("yyyy-MM-dd") ' Today's date for date_returned

        ' Collect data from CheckedListBox controls
        Dim medicalHistory As String = GetCheckedItems(CheckedListBox1, TextBox6, TextBox7, TextBox8)
        Dim animalBiteMode As String = GetCheckedItems(CheckedListBox2)
        Dim treatment As String = GetCheckedItems(CheckedListBox3)
        Dim category As String = GetCheckedItems(CheckedListBox4)

        ' Save data to tbl_bite_treatment, including date_returned
        SaveBiteTreatment(PatientID, dateExposure, bpm, cpm, bloodPressure, weight, temp, treatment, category, animalBiteMode, medicalHistory, chiefComplaints, dateReturned)
    End Sub

    ' Method to save the data to tbl_bite_treatment
    Private Sub SaveBiteTreatment(patientID As String, dateExposure As String, bpm As String, cpm As String, bloodPressure As String, weight As String, temp As String, treatment As String, category As String, animalBiteMode As String, medicalHistory As String, chiefComplaints As String, dateReturned As String)
        Dim connectionString As String = "Server=localhost;Database=prms;Uid=root;Pwd=root;"
        Dim insertQuery As String = "INSERT INTO tbl_bite_treatment (patient_id, date_exposure, bpm, cpm, blood_pressure, weight, temp, treatment, category, animal_bite_mode, medical_history, chief_complaints, date_returned) " &
                                "VALUES (@patient_id, @date_exposure, @bpm, @cpm, @blood_pressure, @weight, @temp, @treatment, @category, @animal_bite_mode, @medical_history, @chief_complaints, @date_returned)"

        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New MySqlCommand(insertQuery, connection)
                    ' Add parameters
                    command.Parameters.AddWithValue("@patient_id", patientID)
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
                    command.Parameters.AddWithValue("@date_returned", dateReturned)

                    ' Execute the insert command
                    command.ExecuteNonQuery()
                    MessageBox.Show("Bite treatment saved successfully!")
                    Me.Close()
                    Form7.Show()
                End Using
            Catch ex As MySqlException
                MessageBox.Show("An error occurred while saving the data: " & ex.Message)
            End Try
        End Using
    End Sub


    ' Function to check if all required fields are filled (excluding optional fields and buttons)
    Private Function AreAllRequiredFieldsFilled() As Boolean
        Return Not (String.IsNullOrWhiteSpace(DateTimePicker1.Text) OrElse
                    String.IsNullOrWhiteSpace(TextBox1.Text) OrElse
                    String.IsNullOrWhiteSpace(TextBox2.Text) OrElse
                    String.IsNullOrWhiteSpace(TextBox3.Text) OrElse
                    String.IsNullOrWhiteSpace(TextBox4.Text) OrElse
                    String.IsNullOrWhiteSpace(TextBox5.Text) OrElse
                    CheckedListBox1.CheckedItems.Count = 0 OrElse
                    CheckedListBox2.CheckedItems.Count = 0 OrElse
                    CheckedListBox3.CheckedItems.Count = 0 OrElse
                    CheckedListBox4.CheckedItems.Count = 0)
    End Function

    ' Method to get checked items from a CheckedListBox as separate lines
    Private Function GetCheckedItems(checkedListBox As CheckedListBox, Optional caInfo As TextBox = Nothing, Optional allergiesInfo As TextBox = Nothing, Optional operationInfo As TextBox = Nothing) As String
        Dim result As New List(Of String)

        For Each item In checkedListBox.CheckedItems
            Dim itemText As String = item.ToString()

            ' Append additional info if provided in the related textboxes
            If itemText = "CA" AndAlso caInfo IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(caInfo.Text) Then
                itemText &= $" ({caInfo.Text})"
            ElseIf itemText = "Allergies" AndAlso allergiesInfo IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(allergiesInfo.Text) Then
                itemText &= $" ({allergiesInfo.Text})"
            ElseIf itemText = "Previous Operation" AndAlso operationInfo IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(operationInfo.Text) Then
                itemText &= $" ({operationInfo.Text})"
            End If

            result.Add(itemText)
        Next

        ' Join each item with a new line
        Return String.Join(Environment.NewLine, result)
    End Function

    ' Method to save the data to tbl_bite_treatment
    Private Sub SaveBiteTreatment(patientID As String, dateExposure As String, bpm As String, cpm As String, bloodPressure As String, weight As String, temp As String, treatment As String, category As String, animalBiteMode As String, medicalHistory As String, chiefComplaints As String)
        Dim connectionString As String = "Server=localhost;Database=prms;Uid=root;Pwd=root;"
        Dim insertQuery As String = "INSERT INTO tbl_bite_treatment (patient_id, date_exposure, bpm, cpm, blood_pressure, weight, temp, treatment, category, animal_bite_mode, medical_history, chief_complaints) " &
                                    "VALUES (@patient_id, @date_exposure, @bpm, @cpm, @blood_pressure, @weight, @temp, @treatment, @category, @animal_bite_mode, @medical_history, @chief_complaints)"

        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New MySqlCommand(insertQuery, connection)
                    ' Add parameters
                    command.Parameters.AddWithValue("@patient_id", patientID)
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

                    ' Execute the insert command
                    command.ExecuteNonQuery()
                    MessageBox.Show("Bite treatment saved successfully!")
                    Me.Close()
                    Form7.Show()
                End Using
            Catch ex As MySqlException
                MessageBox.Show("An error occurred while saving the data: " & ex.Message)
            End Try
        End Using
    End Sub

    ' Button2: Clears all TextBoxes, CheckedListBoxes, and resets DateTimePicker
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

        ' Uncheck all items in CheckedListBoxes
        For Each item As CheckedListBox In New CheckedListBox() {CheckedListBox1, CheckedListBox2, CheckedListBox3, CheckedListBox4}
            For i As Integer = 0 To item.Items.Count - 1
                item.SetItemChecked(i, False)
            Next
        Next

        ' Reset DateTimePicker to today
        DateTimePicker1.Value = Date.Today
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        Form7.Show()
    End Sub
End Class