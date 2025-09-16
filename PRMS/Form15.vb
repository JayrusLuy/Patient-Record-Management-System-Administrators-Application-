Public Class Form15
    ' Property to receive patient_id from Form7
    Public Property PatientID As String

    Private Sub Form15_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Display the patient_id in Label1
        Label1.Text = "View the clinical care of " & PatientID
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Open Form16 and pass the patient_id to it
        Dim form16 As New Form16()
        form16.PatientID = PatientID ' Assuming Form16 has a PatientID property
        form16.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Open Form17 and pass the patient_id to it
        Dim form17 As New Form17()
        form17.PatientID = PatientID ' Assuming Form17 has a PatientID property
        form17.Show()
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Open Form18 and pass the patient_id to it
        Dim form18 As New Form18()
        form18.PatientID = PatientID ' Assuming Form18 has a PatientID property
        form18.Show()
        Me.Close()
    End Sub
End Class
