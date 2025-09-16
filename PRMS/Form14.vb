Imports MySql.Data.MySqlClient

Public Class Form14
    ' Property to receive the patient_id from Form13
    Public Property PatientID As String

    Private Sub Form14_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Populate CheckedListBox3 with treatment options
        CheckedListBox3.Items.Add("Anti Tetanus Shot")
        CheckedListBox3.Items.Add("1st Rabies Vaccine Shot")
        CheckedListBox3.Items.Add("2nd Rabies Vaccine Shot")
        CheckedListBox3.Items.Add("3rd Rabies Vaccine Shot")
        CheckedListBox3.Items.Add("4th Rabies Immunization Shot")
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Check if any item in CheckedListBox3 is selected
        If CheckedListBox3.CheckedItems.Count = 0 Then
            MessageBox.Show("Please select at least one treatment.")
            Return
        End If

        ' Collect selected treatments as separate lines
        Dim newTreatment As String = GetCheckedItems(CheckedListBox3)

        ' Save the new treatment data to tbl_bite_treatment, including today's date for date_returned
        Dim dateReturned As String = DateTime.Now.ToString("yyyy-MM-dd") ' Today's date for date_returned
        SaveTreatment(PatientID, newTreatment, dateReturned)
    End Sub

    ' Method to collect selected items from CheckedListBox3 as separate lines
    Private Function GetCheckedItems(checkedListBox As CheckedListBox) As String
        Dim result As New List(Of String)
        For Each item In checkedListBox.CheckedItems
            result.Add(item.ToString())
        Next
        Return String.Join(Environment.NewLine, result)
    End Function

    ' Method to save treatment data to tbl_bite_treatment, including date_returned
    Private Sub SaveTreatment(patientID As String, newTreatment As String, dateReturned As String)
        Dim connectionString As String = "Server=localhost;Database=prms;Uid=root;Pwd=root;"
        Dim updateTreatmentQuery As String = "UPDATE tbl_bite_treatment SET treatment = @treatment, date_returned = @date_returned WHERE patient_id = @patient_id"

        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()

                ' Update treatment and date_returned in tbl_bite_treatment
                Using updateCommand As New MySqlCommand(updateTreatmentQuery, connection)
                    updateCommand.Parameters.AddWithValue("@treatment", newTreatment)
                    updateCommand.Parameters.AddWithValue("@date_returned", dateReturned)
                    updateCommand.Parameters.AddWithValue("@patient_id", patientID)
                    updateCommand.ExecuteNonQuery()
                End Using

                MessageBox.Show("Treatment updated successfully.")
                Me.Close()
                Form7.Show()
            Catch ex As MySqlException
                MessageBox.Show("An error occurred while saving the data: " & ex.Message)
            End Try
        End Using
    End Sub
    ' Method to save treatment data to tbl_bite_treatment
    Private Sub SaveTreatment(patientID As String, newTreatment As String)
        Dim connectionString As String = "Server=localhost;Database=prms;Uid=root;Pwd=root;"
        Dim updateTreatmentQuery As String = "UPDATE tbl_bite_treatment SET treatment = @treatment WHERE patient_id = @patient_id"

        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()

                ' Update treatment in tbl_bite_treatment
                Using updateCommand As New MySqlCommand(updateTreatmentQuery, connection)
                    updateCommand.Parameters.AddWithValue("@treatment", newTreatment)
                    updateCommand.Parameters.AddWithValue("@patient_id", patientID)
                    updateCommand.ExecuteNonQuery()
                End Using

                MessageBox.Show("Treatment updated")
                Me.Close()
                Form7.Show()
            Catch ex As MySqlException
                MessageBox.Show("An error occurred while saving the data: " & ex.Message)
            End Try
        End Using
    End Sub

    ' Button2: Clear all selections in CheckedListBox3
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        For i As Integer = 0 To CheckedListBox3.Items.Count - 1
            CheckedListBox3.SetItemChecked(i, False)
        Next
    End Sub

    ' Button3: Close Form14 and open Form7
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        Form7.Show()
    End Sub
End Class
