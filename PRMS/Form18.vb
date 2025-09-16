Imports MySql.Data.MySqlClient

Public Class Form18
    ' Property to receive patient_id from Form15
    Public Property PatientID As String

    Private Sub Form18_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set up the label to display the patient ID in the specified format
        Label1.Text = $"Viewing the bite treatment of {PatientID}"

        ' Set all textboxes to be disabled, with white background and black text
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is TextBox Then
                Dim txtBox As TextBox = DirectCast(ctrl, TextBox)
                txtBox.Enabled = False
                txtBox.BackColor = Color.White
                txtBox.ForeColor = Color.Black
            End If
        Next

        ' Load data from tbl_bite_treatment for the given patient_id
        If Not String.IsNullOrEmpty(PatientID) Then
            LoadBiteTreatmentData(PatientID)
        End If
    End Sub

    ' Method to load bite treatment data based on patient_id
    Private Sub LoadBiteTreatmentData(patientID As String)
        Dim connectionString As String = "Server=localhost;Database=prms;Uid=root;Pwd=root;"
        Dim query As String = "SELECT bpm, cpm, blood_pressure, weight, temp, date_exposure, medical_history, " &
                              "animal_bite_mode, chief_complaints, treatment, category FROM tbl_bite_treatment WHERE patient_id = @patient_id"

        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@patient_id", patientID)
                    Dim reader As MySqlDataReader = command.ExecuteReader()

                    If reader.Read() Then
                        ' Populate textboxes with data from the reader
                        TextBox1.Text = reader("bpm").ToString()
                        TextBox2.Text = reader("cpm").ToString()
                        TextBox3.Text = reader("blood_pressure").ToString()
                        TextBox4.Text = reader("weight").ToString()
                        TextBox5.Text = reader("temp").ToString()
                        TextBox7.Text = reader("date_exposure").ToString()
                        TextBox6.Text = reader("medical_history").ToString()
                        TextBox8.Text = reader("animal_bite_mode").ToString()
                        TextBox10.Text = reader("chief_complaints").ToString()
                        TextBox11.Text = reader("treatment").ToString()
                        TextBox9.Text = reader("category").ToString()
                    Else
                        ' If no data is found, set default text for all textboxes
                        For Each ctrl As Control In Me.Controls
                            If TypeOf ctrl Is TextBox Then
                                Dim txtBox As TextBox = DirectCast(ctrl, TextBox)
                                txtBox.Text = "No bite treatment info found"
                            End If
                        Next
                    End If
                End Using
            Catch ex As MySqlException
                MessageBox.Show("An error occurred while loading bite treatment data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub
End Class