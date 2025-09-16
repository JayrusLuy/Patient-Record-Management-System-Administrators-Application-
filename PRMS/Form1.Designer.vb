<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        TextBox1 = New TextBox()
        TextBox2 = New TextBox()
        Button1 = New Button()
        PictureBox1 = New PictureBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        PictureBox2 = New PictureBox()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(415, 161)
        TextBox1.Multiline = True
        TextBox1.Name = "TextBox1"
        TextBox1.PlaceholderText = "Type username here"
        TextBox1.Size = New Size(266, 28)
        TextBox1.TabIndex = 0
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(415, 247)
        TextBox2.Multiline = True
        TextBox2.Name = "TextBox2"
        TextBox2.PasswordChar = "*"c
        TextBox2.PlaceholderText = "Type password here"
        TextBox2.Size = New Size(266, 28)
        TextBox2.TabIndex = 1
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button1.ForeColor = SystemColors.ControlText
        Button1.Location = New Point(415, 326)
        Button1.Name = "Button1"
        Button1.Size = New Size(129, 46)
        Button1.TabIndex = 2
        Button1.Text = "Login"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.DarkSeaGreen
        PictureBox1.Location = New Point(0, 0)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(285, 545)
        PictureBox1.TabIndex = 3
        PictureBox1.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(307, 170)
        Label1.Name = "Label1"
        Label1.Size = New Size(91, 19)
        Label1.TabIndex = 4
        Label1.Text = "Username:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(314, 256)
        Label2.Name = "Label2"
        Label2.Size = New Size(84, 19)
        Label2.TabIndex = 5
        Label2.Text = "Password:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(334, 63)
        Label3.Name = "Label3"
        Label3.Size = New Size(320, 28)
        Label3.TabIndex = 6
        Label3.Text = "Administrators Application"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.DarkSeaGreen
        Label4.Font = New Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(12, 35)
        Label4.Name = "Label4"
        Label4.Size = New Size(259, 56)
        Label4.TabIndex = 7
        Label4.Text = "Patients Record " & vbCrLf & "Management System"
        Label4.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.DarkSeaGreen
        Label5.Font = New Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(12, 517)
        Label5.Name = "Label5"
        Label5.Size = New Size(166, 16)
        Label5.TabIndex = 8
        Label5.Text = "Programmed By: Jayrus Luy"
        Label5.TextAlign = ContentAlignment.TopCenter
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.DarkSeaGreen
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(22, 94)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(232, 232)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 9
        PictureBox2.TabStop = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FloralWhite
        ClientSize = New Size(704, 542)
        Controls.Add(PictureBox2)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(PictureBox1)
        Controls.Add(Button1)
        Controls.Add(TextBox2)
        Controls.Add(TextBox1)
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Login Page"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents PictureBox2 As PictureBox

End Class
