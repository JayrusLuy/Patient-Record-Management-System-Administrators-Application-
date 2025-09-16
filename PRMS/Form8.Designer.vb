<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form8
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form8))
        PictureBox1 = New PictureBox()
        PictureBox2 = New PictureBox()
        Label1 = New Label()
        Label2 = New Label()
        TextBox1 = New TextBox()
        Label3 = New Label()
        DateTimePicker1 = New DateTimePicker()
        TextBox2 = New TextBox()
        Label4 = New Label()
        TextBox3 = New TextBox()
        Label5 = New Label()
        ComboBox1 = New ComboBox()
        ComboBox2 = New ComboBox()
        Label8 = New Label()
        TextBox5 = New TextBox()
        Label9 = New Label()
        ComboBox3 = New ComboBox()
        Label10 = New Label()
        Button1 = New Button()
        Button2 = New Button()
        Button3 = New Button()
        TextBox4 = New TextBox()
        Label7 = New Label()
        Label6 = New Label()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.DarkSeaGreen
        PictureBox1.Location = New Point(0, 0)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(450, 81)
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.DarkSeaGreen
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(0, 10)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(71, 71)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 10
        PictureBox2.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.DarkSeaGreen
        Label1.Font = New Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(77, 47)
        Label1.Name = "Label1"
        Label1.Size = New Size(312, 25)
        Label1.TabIndex = 11
        Label1.Text = "Add Patients Baic Information"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.FloralWhite
        Label2.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(72, 104)
        Label2.Name = "Label2"
        Label2.Size = New Size(58, 19)
        Label2.TabIndex = 12
        Label2.Text = "Name"
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(136, 100)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(301, 23)
        TextBox1.TabIndex = 13
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.FloralWhite
        Label3.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(60, 131)
        Label3.Name = "Label3"
        Label3.Size = New Size(70, 19)
        Label3.TabIndex = 14
        Label3.Text = "Address"
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.Location = New Point(136, 216)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(301, 23)
        DateTimePicker1.TabIndex = 15
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(136, 158)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(301, 23)
        TextBox2.TabIndex = 16
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.FloralWhite
        Label4.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(22, 162)
        Label4.Name = "Label4"
        Label4.Size = New Size(108, 19)
        Label4.TabIndex = 17
        Label4.Text = "Family Head"
        ' 
        ' TextBox3
        ' 
        TextBox3.Location = New Point(136, 187)
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(301, 23)
        TextBox3.TabIndex = 18
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.FloralWhite
        Label5.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(0, 191)
        Label5.Name = "Label5"
        Label5.Size = New Size(130, 19)
        Label5.TabIndex = 19
        Label5.Text = "Mobile Number"
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Items.AddRange(New Object() {"Bacnor East", "Bacnor West", "Caliguian", "Catabban", "Cullalabo del Norte", "Cullalabo del Sur", "Dalig", "Malasin", "Masigun East", "Raniag", "San Antonino (Poblacion)", "San Bonifacio", "San Miguel"})
        ComboBox1.Location = New Point(136, 129)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(301, 23)
        ComboBox1.TabIndex = 24
        ' 
        ' ComboBox2
        ' 
        ComboBox2.FormattingEnabled = True
        ComboBox2.Items.AddRange(New Object() {"Male", "Female"})
        ComboBox2.Location = New Point(136, 274)
        ComboBox2.Name = "ComboBox2"
        ComboBox2.Size = New Size(301, 23)
        ComboBox2.TabIndex = 25
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.BackColor = Color.FloralWhite
        Label8.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label8.Location = New Point(53, 218)
        Label8.Name = "Label8"
        Label8.Size = New Size(77, 19)
        Label8.TabIndex = 26
        Label8.Text = "Birthdate"
        ' 
        ' TextBox5
        ' 
        TextBox5.Location = New Point(136, 303)
        TextBox5.Name = "TextBox5"
        TextBox5.Size = New Size(301, 23)
        TextBox5.TabIndex = 27
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.BackColor = Color.FloralWhite
        Label9.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.Location = New Point(59, 307)
        Label9.Name = "Label9"
        Label9.Size = New Size(71, 19)
        Label9.TabIndex = 28
        Label9.Text = "Religion"
        ' 
        ' ComboBox3
        ' 
        ComboBox3.FormattingEnabled = True
        ComboBox3.Items.AddRange(New Object() {"Single", "Married", "Widowed"})
        ComboBox3.Location = New Point(136, 332)
        ComboBox3.Name = "ComboBox3"
        ComboBox3.Size = New Size(301, 23)
        ComboBox3.TabIndex = 29
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.BackColor = Color.FloralWhite
        Label10.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label10.Location = New Point(41, 336)
        Label10.Name = "Label10"
        Label10.Size = New Size(89, 19)
        Label10.TabIndex = 30
        Label10.Text = "Civil Status"
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button1.Location = New Point(41, 378)
        Button1.Name = "Button1"
        Button1.Size = New Size(120, 37)
        Button1.TabIndex = 31
        Button1.Text = "Save"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button2.Location = New Point(167, 378)
        Button2.Name = "Button2"
        Button2.Size = New Size(120, 37)
        Button2.TabIndex = 32
        Button2.Text = "Clear"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button3.Location = New Point(293, 378)
        Button3.Name = "Button3"
        Button3.Size = New Size(120, 37)
        Button3.TabIndex = 33
        Button3.Text = "Cancel"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' TextBox4
        ' 
        TextBox4.Enabled = False
        TextBox4.Location = New Point(136, 245)
        TextBox4.Name = "TextBox4"
        TextBox4.Size = New Size(301, 23)
        TextBox4.TabIndex = 34
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.BackColor = Color.FloralWhite
        Label7.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(94, 278)
        Label7.Name = "Label7"
        Label7.Size = New Size(36, 19)
        Label7.TabIndex = 23
        Label7.Text = "Sex"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.BackColor = Color.FloralWhite
        Label6.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(88, 249)
        Label6.Name = "Label6"
        Label6.Size = New Size(42, 19)
        Label6.TabIndex = 35
        Label6.Text = "Age"
        ' 
        ' Form8
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FloralWhite
        ClientSize = New Size(449, 436)
        Controls.Add(Label6)
        Controls.Add(TextBox4)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(Label10)
        Controls.Add(ComboBox3)
        Controls.Add(Label9)
        Controls.Add(TextBox5)
        Controls.Add(Label8)
        Controls.Add(ComboBox2)
        Controls.Add(ComboBox1)
        Controls.Add(Label7)
        Controls.Add(Label5)
        Controls.Add(TextBox3)
        Controls.Add(Label4)
        Controls.Add(TextBox2)
        Controls.Add(DateTimePicker1)
        Controls.Add(Label3)
        Controls.Add(TextBox1)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(PictureBox2)
        Controls.Add(PictureBox1)
        Name = "Form8"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Add Patient Basic Info"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents ComboBox3 As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
End Class
