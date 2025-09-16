<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form12
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form12))
        PictureBox1 = New PictureBox()
        PictureBox2 = New PictureBox()
        Label1 = New Label()
        CheckedListBox1 = New CheckedListBox()
        CheckedListBox2 = New CheckedListBox()
        Label21 = New Label()
        Label25 = New Label()
        CheckedListBox3 = New CheckedListBox()
        Label30 = New Label()
        Label2 = New Label()
        TextBox1 = New TextBox()
        Label3 = New Label()
        Label4 = New Label()
        TextBox2 = New TextBox()
        TextBox3 = New TextBox()
        Label5 = New Label()
        TextBox4 = New TextBox()
        Label6 = New Label()
        TextBox5 = New TextBox()
        Label7 = New Label()
        CheckedListBox4 = New CheckedListBox()
        Label8 = New Label()
        TextBox6 = New TextBox()
        Label9 = New Label()
        Label10 = New Label()
        TextBox7 = New TextBox()
        TextBox8 = New TextBox()
        Label11 = New Label()
        Label12 = New Label()
        DateTimePicker1 = New DateTimePicker()
        TextBox9 = New TextBox()
        Label13 = New Label()
        Button3 = New Button()
        Button2 = New Button()
        Button1 = New Button()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.DarkSeaGreen
        PictureBox1.Location = New Point(-2, 0)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(1042, 78)
        PictureBox1.TabIndex = 1
        PictureBox1.TabStop = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.DarkSeaGreen
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(12, 12)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(61, 62)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 10
        PictureBox2.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.DarkSeaGreen
        Label1.Font = New Font("Century Gothic", 24F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(79, 36)
        Label1.Name = "Label1"
        Label1.Size = New Size(311, 38)
        Label1.TabIndex = 66
        Label1.Text = "Add Bite Treatment"
        ' 
        ' CheckedListBox1
        ' 
        CheckedListBox1.FormattingEnabled = True
        CheckedListBox1.Location = New Point(12, 347)
        CheckedListBox1.Name = "CheckedListBox1"
        CheckedListBox1.Size = New Size(186, 130)
        CheckedListBox1.TabIndex = 67
        ' 
        ' CheckedListBox2
        ' 
        CheckedListBox2.FormattingEnabled = True
        CheckedListBox2.Items.AddRange(New Object() {"Nibbling/Licking of intact skin", "NIbbling/Licking of wounded broken skin", "Scratch and abrassion w/ bleeding", "Handling or ingesting raw infected meat", "Minor superficial scratch and abrassion w.o or induce bleeding", "Transdermal bite or scratches w/ spontaneous bleeding", "Unprotected Handling of infected carcass", "Exposure to bats", "Feeding and touching animals", "Exposure to patients with S/Sx of Rabies"})
        CheckedListBox2.Location = New Point(432, 116)
        CheckedListBox2.Name = "CheckedListBox2"
        CheckedListBox2.Size = New Size(378, 184)
        CheckedListBox2.TabIndex = 68
        ' 
        ' Label21
        ' 
        Label21.AutoSize = True
        Label21.BackColor = Color.FloralWhite
        Label21.Font = New Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label21.Location = New Point(12, 321)
        Label21.Name = "Label21"
        Label21.Size = New Size(196, 23)
        Label21.TabIndex = 69
        Label21.Text = "Past Medical History"
        ' 
        ' Label25
        ' 
        Label25.AutoSize = True
        Label25.BackColor = Color.FloralWhite
        Label25.Font = New Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label25.Location = New Point(432, 90)
        Label25.Name = "Label25"
        Label25.Size = New Size(245, 23)
        Label25.TabIndex = 73
        Label25.Text = "Mode of Animal Exposure"
        ' 
        ' CheckedListBox3
        ' 
        CheckedListBox3.FormattingEnabled = True
        CheckedListBox3.Items.AddRange(New Object() {"Anti Tetanus Shot", "1st Rabies Vaccine Shot", "2nd Rabies Vaccine Shot", "3rd Rabies Vaccine Shot", "4th Rabies Immunization Shot"})
        CheckedListBox3.Location = New Point(624, 347)
        CheckedListBox3.Name = "CheckedListBox3"
        CheckedListBox3.Size = New Size(186, 130)
        CheckedListBox3.TabIndex = 74
        ' 
        ' Label30
        ' 
        Label30.AutoSize = True
        Label30.BackColor = Color.FloralWhite
        Label30.Font = New Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label30.Location = New Point(624, 321)
        Label30.Name = "Label30"
        Label30.Size = New Size(102, 23)
        Label30.TabIndex = 87
        Label30.Text = "Treatment"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.FloralWhite
        Label2.Font = New Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(79, 136)
        Label2.Name = "Label2"
        Label2.Size = New Size(104, 23)
        Label2.TabIndex = 88
        Label2.Text = "Vital Signs"
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(156, 162)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(100, 23)
        TextBox1.TabIndex = 89
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.FloralWhite
        Label3.Font = New Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(12, 162)
        Label3.Name = "Label3"
        Label3.Size = New Size(107, 23)
        Label3.TabIndex = 90
        Label3.Text = "Heart Rate"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.FloralWhite
        Label4.Font = New Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(12, 191)
        Label4.Name = "Label4"
        Label4.Size = New Size(53, 23)
        Label4.TabIndex = 92
        Label4.Text = "CPM"
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(156, 191)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(100, 23)
        TextBox2.TabIndex = 91
        ' 
        ' TextBox3
        ' 
        TextBox3.Location = New Point(156, 220)
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(100, 23)
        TextBox3.TabIndex = 93
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.FloralWhite
        Label5.Font = New Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(12, 220)
        Label5.Name = "Label5"
        Label5.Size = New Size(142, 23)
        Label5.TabIndex = 94
        Label5.Text = "Blood Pressure"
        ' 
        ' TextBox4
        ' 
        TextBox4.Location = New Point(156, 249)
        TextBox4.Name = "TextBox4"
        TextBox4.Size = New Size(100, 23)
        TextBox4.TabIndex = 95
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.BackColor = Color.FloralWhite
        Label6.Font = New Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(12, 249)
        Label6.Name = "Label6"
        Label6.Size = New Size(118, 23)
        Label6.TabIndex = 96
        Label6.Text = "Weight (Kg)"
        ' 
        ' TextBox5
        ' 
        TextBox5.Location = New Point(156, 278)
        TextBox5.Name = "TextBox5"
        TextBox5.Size = New Size(100, 23)
        TextBox5.TabIndex = 97
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.BackColor = Color.FloralWhite
        Label7.Font = New Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(12, 278)
        Label7.Name = "Label7"
        Label7.Size = New Size(127, 23)
        Label7.TabIndex = 98
        Label7.Text = "Temperature"
        ' 
        ' CheckedListBox4
        ' 
        CheckedListBox4.FormattingEnabled = True
        CheckedListBox4.Items.AddRange(New Object() {"1", "2", "3"})
        CheckedListBox4.Location = New Point(432, 347)
        CheckedListBox4.Name = "CheckedListBox4"
        CheckedListBox4.Size = New Size(186, 130)
        CheckedListBox4.TabIndex = 99
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.BackColor = Color.FloralWhite
        Label8.Font = New Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label8.Location = New Point(432, 321)
        Label8.Name = "Label8"
        Label8.Size = New Size(98, 23)
        Label8.TabIndex = 100
        Label8.Text = "Category"
        ' 
        ' TextBox6
        ' 
        TextBox6.Location = New Point(316, 347)
        TextBox6.Name = "TextBox6"
        TextBox6.Size = New Size(100, 23)
        TextBox6.TabIndex = 101
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.BackColor = Color.FloralWhite
        Label9.Font = New Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.Location = New Point(268, 347)
        Label9.Name = "Label9"
        Label9.Size = New Size(39, 23)
        Label9.TabIndex = 102
        Label9.Text = "CA"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.BackColor = Color.FloralWhite
        Label10.Font = New Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label10.Location = New Point(217, 376)
        Label10.Name = "Label10"
        Label10.Size = New Size(90, 23)
        Label10.TabIndex = 104
        Label10.Text = "Allergies"
        ' 
        ' TextBox7
        ' 
        TextBox7.Location = New Point(316, 376)
        TextBox7.Name = "TextBox7"
        TextBox7.Size = New Size(100, 23)
        TextBox7.TabIndex = 103
        ' 
        ' TextBox8
        ' 
        TextBox8.Location = New Point(316, 405)
        TextBox8.Name = "TextBox8"
        TextBox8.Size = New Size(100, 23)
        TextBox8.TabIndex = 105
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.BackColor = Color.FloralWhite
        Label11.Font = New Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.Location = New Point(206, 405)
        Label11.Name = "Label11"
        Label11.Size = New Size(104, 23)
        Label11.TabIndex = 106
        Label11.Text = "Operation"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.BackColor = Color.FloralWhite
        Label12.Font = New Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label12.Location = New Point(12, 90)
        Label12.Name = "Label12"
        Label12.Size = New Size(164, 23)
        Label12.TabIndex = 107
        Label12.Text = "Date of Exposure"
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.Location = New Point(182, 90)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(161, 23)
        DateTimePicker1.TabIndex = 108
        ' 
        ' TextBox9
        ' 
        TextBox9.Location = New Point(826, 116)
        TextBox9.Multiline = True
        TextBox9.Name = "TextBox9"
        TextBox9.Size = New Size(200, 361)
        TextBox9.TabIndex = 109
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.BackColor = Color.FloralWhite
        Label13.Font = New Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label13.Location = New Point(826, 89)
        Label13.Name = "Label13"
        Label13.Size = New Size(169, 23)
        Label13.TabIndex = 110
        Label13.Text = "Chief Complaints"
        ' 
        ' Button3
        ' 
        Button3.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button3.Location = New Point(913, 36)
        Button3.Name = "Button3"
        Button3.Size = New Size(120, 37)
        Button3.TabIndex = 113
        Button3.Text = "Cancel"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button2.Location = New Point(787, 36)
        Button2.Name = "Button2"
        Button2.Size = New Size(120, 37)
        Button2.TabIndex = 112
        Button2.Text = "Clear"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button1.Location = New Point(661, 36)
        Button1.Name = "Button1"
        Button1.Size = New Size(120, 37)
        Button1.TabIndex = 111
        Button1.Text = "Save"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Form12
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FloralWhite
        ClientSize = New Size(1038, 502)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(Label13)
        Controls.Add(TextBox9)
        Controls.Add(DateTimePicker1)
        Controls.Add(Label12)
        Controls.Add(Label11)
        Controls.Add(TextBox8)
        Controls.Add(Label10)
        Controls.Add(TextBox7)
        Controls.Add(Label9)
        Controls.Add(TextBox6)
        Controls.Add(Label8)
        Controls.Add(CheckedListBox4)
        Controls.Add(Label7)
        Controls.Add(TextBox5)
        Controls.Add(Label6)
        Controls.Add(TextBox4)
        Controls.Add(Label5)
        Controls.Add(TextBox3)
        Controls.Add(Label4)
        Controls.Add(TextBox2)
        Controls.Add(Label3)
        Controls.Add(TextBox1)
        Controls.Add(Label2)
        Controls.Add(Label30)
        Controls.Add(CheckedListBox3)
        Controls.Add(Label25)
        Controls.Add(Label21)
        Controls.Add(CheckedListBox2)
        Controls.Add(CheckedListBox1)
        Controls.Add(Label1)
        Controls.Add(PictureBox2)
        Controls.Add(PictureBox1)
        Name = "Form12"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form12"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents CheckedListBox1 As CheckedListBox
    Friend WithEvents CheckedListBox2 As CheckedListBox
    Friend WithEvents Label21 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents CheckedListBox3 As CheckedListBox
    Friend WithEvents Label30 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents CheckedListBox4 As CheckedListBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents TextBox8 As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents TextBox9 As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
End Class
