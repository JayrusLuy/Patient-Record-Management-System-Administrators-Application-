Imports MySql.Data.MySqlClient

Public Class Form17
    ' Property to receive patient_id from Form15
    Public Property PatientID As String

    Private Sub Form17_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Ensure TextBox1 is read-only and visually enabled
        TextBox1.ReadOnly = True
        TextBox1.BackColor = Color.White
        TextBox1.ForeColor = Color.Black

        ' Display patient_id info on a label
        Label1.Text = $"Viewing the Service History of {PatientID}"

        ' Ensure PatientID is not empty before loading data
        If Not String.IsNullOrEmpty(PatientID) Then
            LoadServiceData(PatientID)
        End If
    End Sub

    ' Method to load service data for the specific patient_id
    Private Sub LoadServiceData(patientID As String)
        Dim connectionString As String = "Server=localhost;Database=prms;Uid=root;Pwd=root;"
        Dim query As String =
            "SELECT s.date AS ServiceDate, doc.doctor AS Doctor, sl.service AS Service " &
            "FROM tbl_service s " &
            "INNER JOIN tbl_doctor doc ON s.doctor = doc.doc_id " &
            "INNER JOIN tbl_service_list sl ON s.service = sl.service_id " &
            "WHERE s.patient_id = @patient_id"

        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@patient_id", patientID)

                    Using reader As MySqlDataReader = command.ExecuteReader()
                        If reader.HasRows Then
                            Dim formattedText As New System.Text.StringBuilder()

                            ' Loop through each record and format the data
                            While reader.Read()
                                Dim serviceDate As String = reader("ServiceDate").ToString()
                                Dim doctor As String = reader("Doctor").ToString()
                                Dim service As String = reader("Service").ToString()

                                formattedText.AppendLine($"Date: {serviceDate}")
                                formattedText.AppendLine($"Doctor: {doctor}")
                                formattedText.AppendLine($"Service: {service}")
                                formattedText.AppendLine() ' Add a blank line between entries
                            End While

                            ' Display the formatted data in TextBox1
                            TextBox1.Text = formattedText.ToString()
                        Else
                            TextBox1.Text = "No service data found for this patient."
                        End If
                    End Using
                End Using
            Catch ex As MySqlException
                MessageBox.Show("An error occurred while loading service data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub
End Class
