Public Class Form24
    ' Public property to receive the patient_id from Form7
    Public Property PatientID As String

    Private Sub Form24_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Display the PatientID on Label1
        Label1.Text = $"Edit clinical record of: {PatientID}"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Create an instance of Form25
        Dim form25 As New Form25()

        ' Pass the PatientID to Form25
        form25.PatientID = Me.PatientID

        ' Close Form24 and open Form25
        Me.Close()
        form25.Show()
        Form7.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Create an instance of Form28
        Dim form28 As New Form28()

        ' Pass the PatientID to Form28
        form28.PatientID = Me.PatientID

        ' Close Form24 and open Form28
        Me.Close()
        form28.Show()
        Form7.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Display a message before opening Form29 to remind the user to check old checked options
        Dim message As String = "Please review and check previously saved options in the checklists."
        MessageBox.Show(message, "Reminder", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' Open Form29 and pass the PatientID
        Dim form29 As New Form29()
        form29.PatientID = Me.PatientID
        form29.Show()
        Me.Close()
        Form7.Close()
    End Sub
End Class
