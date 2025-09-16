Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Diagnostics
' Button1 create a backup
Public Class Form26
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim databaseName As String = "prms"
        Dim userName As String = "root"
        Dim password As String = "root"

        ' Path to mysqldump
        Dim mysqldumpPath As String = "C:\Program Files\MySQL\MySQL Server 8.4\bin\mysqldump.exe"

        ' Check if mysqldump exists at the specified path
        If Not File.Exists(mysqldumpPath) Then
            MessageBox.Show("mysqldump.exe not found. Please check the path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Set up the SaveFileDialog to choose where to save the backup
        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "SQL File|*.sql"
        saveFileDialog.Title = "Save Backup File"
        saveFileDialog.FileName = "prms_backup_" & DateTime.Now.ToString("yyyy-MM-dd") & ".sql"

        ' Show the dialog and get the result
        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            ' Get the file path chosen by the user
            Dim backupFile As String = saveFileDialog.FileName

            ' Prepare the mysqldump command
            Dim backupCommand As String = $"""{mysqldumpPath}"" --user={userName} --password={password} {databaseName} -r ""{backupFile}"""

            Try
                Dim process As New Process()
                process.StartInfo.FileName = "cmd.exe"
                process.StartInfo.Arguments = $"/c ""{backupCommand}"""
                process.StartInfo.RedirectStandardOutput = True
                process.StartInfo.RedirectStandardError = True
                process.StartInfo.UseShellExecute = False
                process.StartInfo.CreateNoWindow = True

                ' Start the process
                process.Start()

                Dim outputMessage As String = process.StandardOutput.ReadToEnd()
                Dim errorMessage As String = process.StandardError.ReadToEnd()

                process.WaitForExit()

                ' Confirmation message if backup complete
                If process.ExitCode = 0 Then
                    MessageBox.Show($"Backup completed successfully! Backup saved at: {backupFile}", "Backup Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Backup failed: " & errorMessage, "Backup Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Catch ex As Exception
                MessageBox.Show("An error occurred during backup: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    ' Button 2 to select restore point
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim databaseName As String = "prms"
        Dim userName As String = "root"
        Dim password As String = "root"

        ' Path to mysql
        Dim mysqlPath As String = "C:\Program Files\MySQL\MySQL Server 8.4\bin\mysql.exe"

        ' Check if mysql exists at the specified path
        If Not File.Exists(mysqlPath) Then
            MessageBox.Show("mysql.exe not found. Please check the path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Open a file dialog to choose the backup file to restore
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "SQL File|*.sql"
        openFileDialog.Title = "Select Backup File to Restore"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            ' Get the selected file path
            Dim backupFile As String = openFileDialog.FileName

            Try
                ' Create a new process to run the mysql restore command
                Dim process As New Process()
                process.StartInfo.FileName = mysqlPath
                process.StartInfo.Arguments = $"--user={userName} --password={password} {databaseName}"
                process.StartInfo.RedirectStandardInput = True
                process.StartInfo.RedirectStandardOutput = True
                process.StartInfo.RedirectStandardError = True
                process.StartInfo.UseShellExecute = False
                process.StartInfo.CreateNoWindow = True

                ' Start the process
                process.Start()

                ' Open the backup file and feed it into the process StandardInput
                Using streamReader As New StreamReader(backupFile)
                    process.StandardInput.Write(streamReader.ReadToEnd())
                    process.StandardInput.Close()
                End Using

                process.WaitForExit()

                ' Read any errors
                Dim errorMessage As String = process.StandardError.ReadToEnd()

                ' Check if there were any errors
                If process.ExitCode = 0 Then
                    MessageBox.Show("Database restored successfully!", "Restore Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Restore failed: " & errorMessage, "Restore Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Catch ex As Exception
                MessageBox.Show("An error occurred during restore: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
    End Sub

    Private Sub Form26_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class