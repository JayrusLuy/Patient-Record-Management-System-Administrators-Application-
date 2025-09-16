Imports MySql.Data.MySqlClient

Public Class Form13
    ' Property to receive the patient_id from Form7
    Public Property PatientID As String

    ' Shared instance of Form13 to ensure only one instance is open
    Private Shared instance As Form13 = Nothing

    ' Method to get or show the single instance of Form13
    Public Shared Sub ShowForm(patientID As String)
        ' Check if the instance already exists
        If instance Is Nothing OrElse instance.IsDisposed Then
            ' Create a new instance if none exists or it was disposed
            instance = New Form13()
            instance.PatientID = patientID
        End If
        ' Show the form (activate if it is already open)
        instance.Show()
        instance.BringToFront()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Open Form10 and pass the patient_id for diagnosis entry
        Dim form10 As New Form10()
        form10.PatientID = PatientID ' Assuming Form10 has a PatientID property
        form10.Show()

        ' Close Form13 after opening Form10
        Me.Close()
        Form7.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Open Form10 and pass the patient_id for diagnosis entry
        Dim form10 As New Form10()
        Form11.PatientID = PatientID ' Assuming Form10 has a PatientID property
        Form11.Show()

        ' Close Form13 after opening Form10
        Me.Close()
        Form7.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim connectionString As String = "Server=localhost;Database=prms;Uid=root;Pwd=root;"
        Dim checkQuery As String = "SELECT COUNT(*) FROM tbl_bite_treatment WHERE patient_id = @patient_id"

        Using connection As New MySqlConnection(connectionString)
            connection.Open()
            Using command As New MySqlCommand(checkQuery, connection)
                command.Parameters.AddWithValue("@patient_id", PatientID)

                ' Execute the query to check if a row exists in tbl_bite_treatment with the given patient_id
                Dim recordExists As Integer = Convert.ToInt32(command.ExecuteScalar())

                If recordExists > 0 Then
                    ' If a record exists, open Form14 to update treatment
                    Dim form14 As New Form14()
                    form14.PatientID = PatientID ' Assuming Form14 has a PatientID property
                    form14.Show()
                Else
                    ' If no record exists, open Form12 to add a new treatment entry
                    Dim form12 As New Form12()
                    form12.PatientID = PatientID
                    form12.Show()
                End If
            End Using
        End Using

        ' Close Form13 after opening the appropriate form
        Me.Close()
        Form7.Close()
    End Sub


    ' Optional: Handle Form13 closure to release the instance reference
    Protected Overrides Sub OnFormClosed(e As FormClosedEventArgs)
        MyBase.OnFormClosed(e)
        instance = Nothing ' Release the instance reference when the form closes
    End Sub

    Private Sub Form13_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = $"Add clinical care to record: {PatientID}"
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class