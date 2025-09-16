<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        PictureBox1 = New PictureBox()
        Button1 = New Button()
        Button3 = New Button()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        PictureBox2 = New PictureBox()
        Button4 = New Button()
        Button5 = New Button()
        Button6 = New Button()
        Button7 = New Button()
        Button8 = New Button()
        Button2 = New Button()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.DarkSeaGreen
        PictureBox1.Location = New Point(272, 0)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(240, 541)
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button1.ForeColor = SystemColors.ControlText
        Button1.Location = New Point(316, 140)
        Button1.Name = "Button1"
        Button1.Size = New Size(153, 44)
        Button1.TabIndex = 1
        Button1.Text = "View Out Patient Information"
        Button1.UseMnemonic = False
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Font = New Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button3.ForeColor = SystemColors.ControlText
        Button3.Location = New Point(316, 390)
        Button3.Name = "Button3"
        Button3.Size = New Size(153, 44)
        Button3.TabIndex = 3
        Button3.Text = "About Us"
        Button3.UseMnemonic = False
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.DarkSeaGreen
        Label1.Font = New Font("Century Gothic", 12.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(290, 59)
        Label1.Name = "Label1"
        Label1.Size = New Size(200, 19)
        Label1.TabIndex = 4
        Label1.Text = "Please select an option"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Century Gothic", 12.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(7, 279)
        Label2.Name = "Label2"
        Label2.Size = New Size(241, 19)
        Label2.TabIndex = 5
        Label2.Text = "Welcome to the main menu," & vbCrLf
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Century Gothic", 12.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(7, 302)
        Label3.Name = "Label3"
        Label3.Size = New Size(91, 19)
        Label3.TabIndex = 6
        Label3.Text = "Username" & vbCrLf
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Century Gothic", 12.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(12, 9)
        Label4.Name = "Label4"
        Label4.Size = New Size(247, 38)
        Label4.TabIndex = 7
        Label4.Text = "Patient Record Management " & vbCrLf & "System"
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(32, 59)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(191, 198)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 8
        PictureBox2.TabStop = False
        ' 
        ' Button4
        ' 
        Button4.Font = New Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button4.ForeColor = SystemColors.ControlText
        Button4.Location = New Point(316, 290)
        Button4.Name = "Button4"
        Button4.Size = New Size(153, 44)
        Button4.TabIndex = 9
        Button4.Text = "View Logs"
        Button4.UseMnemonic = False
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Button5
        ' 
        Button5.Font = New Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button5.ForeColor = SystemColors.ControlText
        Button5.Location = New Point(316, 190)
        Button5.Name = "Button5"
        Button5.Size = New Size(153, 44)
        Button5.TabIndex = 10
        Button5.Text = "View Recycle Bin"
        Button5.UseMnemonic = False
        Button5.UseVisualStyleBackColor = True
        ' 
        ' Button6
        ' 
        Button6.Font = New Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button6.ForeColor = SystemColors.ControlText
        Button6.Location = New Point(316, 240)
        Button6.Name = "Button6"
        Button6.Size = New Size(153, 44)
        Button6.TabIndex = 11
        Button6.Text = "View Account Manager"
        Button6.UseMnemonic = False
        Button6.UseVisualStyleBackColor = True
        ' 
        ' Button7
        ' 
        Button7.Font = New Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button7.ForeColor = SystemColors.ControlText
        Button7.Location = New Point(316, 485)
        Button7.Name = "Button7"
        Button7.Size = New Size(153, 44)
        Button7.TabIndex = 12
        Button7.Text = "Log Out"
        Button7.UseMnemonic = False
        Button7.UseVisualStyleBackColor = True
        ' 
        ' Button8
        ' 
        Button8.Font = New Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button8.ForeColor = SystemColors.ControlText
        Button8.Location = New Point(316, 340)
        Button8.Name = "Button8"
        Button8.Size = New Size(153, 44)
        Button8.TabIndex = 13
        Button8.Text = "Backup & Restore"
        Button8.UseMnemonic = False
        Button8.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button2.ForeColor = SystemColors.ControlText
        Button2.Location = New Point(316, 90)
        Button2.Name = "Button2"
        Button2.Size = New Size(153, 44)
        Button2.TabIndex = 14
        Button2.Text = "Set up Controls"
        Button2.UseMnemonic = False
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Form2
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FloralWhite
        ClientSize = New Size(513, 541)
        Controls.Add(Button2)
        Controls.Add(Button8)
        Controls.Add(Button7)
        Controls.Add(Button6)
        Controls.Add(Button5)
        Controls.Add(Button4)
        Controls.Add(PictureBox2)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(Button3)
        Controls.Add(Button1)
        Controls.Add(PictureBox1)
        Name = "Form2"
        StartPosition = FormStartPosition.Manual
        Text = "Main Menu Form"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Button2 As Button
End Class
