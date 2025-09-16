Imports MySql.Data.MySqlClient

Public Class Form16
    ' Property to receive patient_id from Form15
    Public Property PatientID As String

    Private Sub Form16_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Display the patient_id in Label1
        If Not String.IsNullOrEmpty(PatientID) Then
            Label1.Text = $"Viewing the Diagnosis of {PatientID}"
            LoadDiagnosisData(PatientID)
        End If

        ' Ensure TextBox1 is visually enabled and properly formatted
        TextBox1.ReadOnly = True
        TextBox1.BackColor = Color.White
        TextBox1.ForeColor = Color.Black
    End Sub

    ' Method to load diagnosis data for the specific patient_id
    Private Sub LoadDiagnosisData(patientID As String)
        Dim connectionString As String = "Server=localhost;Database=prms;Uid=root;Pwd=root;"
        Dim query As String =
            "SELECT d.date, doc.doctor AS Doctor, ill.illness AS Diagnosis " &
            "FROM tbl_diagnosis d " &
            "INNER JOIN tbl_doctor doc ON d.doctor = doc.doc_id " &
            "INNER JOIN tbl_illness ill ON d.diagnosis = ill.ill_id " &
            "WHERE d.patient_id = @patient_id"

        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@patient_id", patientID)

                    Using reader As MySqlDataReader = command.ExecuteReader()
                        If reader.HasRows Then
                            Dim formattedText As New System.Text.StringBuilder()

                            ' Loop through each row and format it
                            While reader.Read()
                                Dim diagnosisDate As String = reader("date").ToString()
                                Dim doctor As String = reader("Doctor").ToString()
                                Dim diagnosis As String = reader("Diagnosis").ToString()

                                formattedText.AppendLine($"Date: {diagnosisDate}")
                                formattedText.AppendLine($"Doctor: {doctor}")
                                formattedText.AppendLine($"Diagnosis: {diagnosis}")
                                formattedText.AppendLine() ' Add a blank line between entries
                            End While

                            ' Set the formatted text in the TextBox
                            TextBox1.Text = formattedText.ToString()
                        Else
                            TextBox1.Text = "No diagnosis data found for this patient."
                        End If
                    End Using
                End Using
            Catch ex As MySqlException
                MessageBox.Show("An error occurred while loading diagnosis data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub
End Class
