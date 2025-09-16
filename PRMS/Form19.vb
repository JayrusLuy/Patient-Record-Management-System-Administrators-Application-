Imports MySql.Data.MySqlClient

Public Class Form19
    ' Property to receive patient_id from Form7
    Public Property PatientID As String

    Private Sub Form19_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = $"Recycle clinical record of: {PatientID}"
    End Sub

    ' Button1: Open Form32 for diagnosis recycling
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim form32 As New Form32()
        form32.PatientID = Me.PatientID ' Pass PatientID to Form32
        form32.DataSourceTable = "tbl_diagnosis" ' Specify table
        form32.Label1.Text = "Please select a diagnosis to recycle" ' Update label
        form32.ColumnToDisplay = "diagnosis" ' Set column to display
        form32.Show() ' Open Form32
        Me.Close() ' Optionally close Form19
    End Sub

    ' Button2: Open Form32 for service recycling
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim form32 As New Form32()
        form32.PatientID = Me.PatientID ' Pass PatientID to Form32
        form32.DataSourceTable = "tbl_service" ' Specify table
        form32.Label1.Text = "Please select a service to recycle" ' Update label
        form32.ColumnToDisplay = "service" ' Set column to display
        form32.Show() ' Open Form32
        Me.Close() ' Optionally close Form19
    End Sub

    ' Button3: Recycle bite treatment record from tbl_bite_treatment to tbl_bite_treatment_delete
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If CheckForDuplicates("tbl_bite_treatment_delete") Then
            MessageBox.Show("Please delete the duplicate bite treatment of this record first.", "Duplicate Detected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim result As DialogResult = MessageBox.Show("Do you want to recycle the bite treatment of this record?", "Recycle Bite Treatment", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            TransferAndDeleteBiteTreatment()
        End If
    End Sub

    ' Method to check for duplicate patient records in a specified delete table
    Private Function CheckForDuplicates(tableName As String) As Boolean
        Dim connectionString As String = "Server=localhost;Database=prms;Uid=root;Pwd=root;"
        Dim query As String = $"SELECT COUNT(*) FROM {tableName} WHERE patient_id = @patient_id"
        Dim duplicateCount As Integer = 0

        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@patient_id", PatientID)
                    duplicateCount = Convert.ToInt32(command.ExecuteScalar())
                End Using
            Catch ex As MySqlException
                MessageBox.Show("An error occurred while checking for duplicates: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using

        Return duplicateCount > 0 ' Returns true if any duplicate record is found
    End Function

    ' Method to transfer bite treatment data to tbl_bite_treatment_delete and delete from tbl_bite_treatment
    Private Sub TransferAndDeleteBiteTreatment()
        Dim connectionString As String = "Server=localhost;Database=prms;Uid=root;Pwd=root;"
        Dim selectQuery As String = "SELECT patient_id, date_exposure, bpm, cpm, blood_pressure, weight, temp, treatment, " &
                                    "category, animal_bite_mode, medical_history, chief_complaints FROM tbl_bite_treatment WHERE patient_id = @patient_id"
        Dim insertQuery As String = "INSERT INTO tbl_bite_treatment_delete (patient_id, date_exposure, bpm, cpm, blood_pressure, weight, temp, treatment, " &
                                    "category, animal_bite_mode, medical_history, chief_complaints, date_deleted) VALUES (@patient_id, @date_exposure, @bpm, @cpm, " &
                                    "@blood_pressure, @weight, @temp, @treatment, @category, @animal_bite_mode, @medical_history, @chief_complaints, @date_deleted)"
        Dim deleteQuery As String = "DELETE FROM tbl_bite_treatment WHERE patient_id = @patient_id"

        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()

                ' Retrieve data from tbl_bite_treatment
                Dim dateExposure As String = ""
                Dim bpm As String = ""
                Dim cpm As String = ""
                Dim bloodPressure As String = ""
                Dim weight As String = ""
                Dim temp As String = ""
                Dim treatment As String = ""
                Dim category As String = ""
                Dim animalBiteMode As String = ""
                Dim medicalHistory As String = ""
                Dim chiefComplaints As String = ""

                Using selectCommand As New MySqlCommand(selectQuery, connection)
                    selectCommand.Parameters.AddWithValue("@patient_id", PatientID)
                    Using reader As MySqlDataReader = selectCommand.ExecuteReader()
                        If reader.Read() Then
                            dateExposure = reader("date_exposure").ToString()
                            bpm = reader("bpm").ToString()
                            cpm = reader("cpm").ToString()
                            bloodPressure = reader("blood_pressure").ToString()
                            weight = reader("weight").ToString()
                            temp = reader("temp").ToString()
                            treatment = reader("treatment").ToString()
                            category = reader("category").ToString()
                            animalBiteMode = reader("animal_bite_mode").ToString()
                            medicalHistory = reader("medical_history").ToString()
                            chiefComplaints = reader("chief_complaints").ToString()
                        Else
                            MessageBox.Show("No bite treatment data found for this patient.", "Data Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Return
                        End If
                    End Using
                End Using

                ' Insert data into tbl_bite_treatment_delete with today's date
                Dim dateDeleted As String = DateTime.Now.ToString("yyyy-MM-dd")
                Using insertCommand As New MySqlCommand(insertQuery, connection)
                    insertCommand.Parameters.AddWithValue("@patient_id", PatientID)
                    insertCommand.Parameters.AddWithValue("@date_exposure", dateExposure)
                    insertCommand.Parameters.AddWithValue("@bpm", bpm)
                    insertCommand.Parameters.AddWithValue("@cpm", cpm)
                    insertCommand.Parameters.AddWithValue("@blood_pressure", bloodPressure)
                    insertCommand.Parameters.AddWithValue("@weight", weight)
                    insertCommand.Parameters.AddWithValue("@temp", temp)
                    insertCommand.Parameters.AddWithValue("@treatment", treatment)
                    insertCommand.Parameters.AddWithValue("@category", category)
                    insertCommand.Parameters.AddWithValue("@animal_bite_mode", animalBiteMode)
                    insertCommand.Parameters.AddWithValue("@medical_history", medicalHistory)
                    insertCommand.Parameters.AddWithValue("@chief_complaints", chiefComplaints)
                    insertCommand.Parameters.AddWithValue("@date_deleted", dateDeleted)
                    insertCommand.ExecuteNonQuery()
                End Using

                ' Delete record from tbl_bite_treatment
                Using deleteCommand As New MySqlCommand(deleteQuery, connection)
                    deleteCommand.Parameters.AddWithValue("@patient_id", PatientID)
                    deleteCommand.ExecuteNonQuery()
                End Using

                MessageBox.Show("Bite treatment successfully recycled.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()

            Catch ex As MySqlException
                MessageBox.Show("An error occurred during the recycling process: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub
End Class
