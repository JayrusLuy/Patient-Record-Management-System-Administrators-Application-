<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form6
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form6))
        PictureBox2 = New PictureBox()
        Label5 = New Label()
        PictureBox1 = New PictureBox()
        Button3 = New Button()
        Button2 = New Button()
        Button1 = New Button()
        ComboBox2 = New ComboBox()
        ComboBox1 = New ComboBox()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        TextBox2 = New TextBox()
        TextBox1 = New TextBox()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.DarkSeaGreen
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(11, 12)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(62, 60)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 31
        PictureBox2.TabStop = False
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.DarkSeaGreen
        Label5.Font = New Font("Century Gothic", 24F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(79, 25)
        Label5.Name = "Label5"
        Label5.Size = New Size(260, 38)
        Label5.TabIndex = 30
        Label5.Text = "Edit an account"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.DarkSeaGreen
        PictureBox1.Location = New Point(-1, 0)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(437, 86)
        PictureBox1.TabIndex = 29
        PictureBox1.TabStop = False
        ' 
        ' Button3
        ' 
        Button3.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button3.Location = New Point(149, 353)
        Button3.Name = "Button3"
        Button3.Size = New Size(139, 41)
        Button3.TabIndex = 28
        Button3.Text = "Cancel"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button2.Location = New Point(240, 306)
        Button2.Name = "Button2"
        Button2.Size = New Size(139, 41)
        Button2.TabIndex = 27
        Button2.Text = "Clear"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button1.Location = New Point(56, 306)
        Button1.Name = "Button1"
        Button1.Size = New Size(139, 41)
        Button1.TabIndex = 26
        Button1.Text = "Confirm"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' ComboBox2
        ' 
        ComboBox2.FormattingEnabled = True
        ComboBox2.Items.AddRange(New Object() {"Bacnor East", "Bacnor West", "Caliguian", "Catabban", "Cullalabo del Norte", "Cullalabo del Sur", "Dalig", "Malasin", "Masigun East", "Raniag", "San Antonino (Poblacion)", "San Bonifacio", "San Miguel", "San Roque"})
        ComboBox2.Location = New Point(149, 240)
        ComboBox2.Name = "ComboBox2"
        ComboBox2.Size = New Size(230, 23)
        ComboBox2.TabIndex = 25
        ComboBox2.Visible = False
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Items.AddRange(New Object() {"Admin", "Standard"})
        ComboBox1.Location = New Point(149, 198)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(230, 23)
        ComboBox1.TabIndex = 24
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(56, 244)
        Label4.Name = "Label4"
        Label4.Size = New Size(75, 19)
        Label4.TabIndex = 23
        Label4.Text = "Location"
        Label4.Visible = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(56, 198)
        Label3.Name = "Label3"
        Label3.Size = New Size(74, 19)
        Label3.TabIndex = 22
        Label3.Text = "Usertype"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(56, 159)
        Label2.Name = "Label2"
        Label2.Size = New Size(80, 19)
        Label2.TabIndex = 21
        Label2.Text = "Password"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(56, 120)
        Label1.Name = "Label1"
        Label1.Size = New Size(87, 19)
        Label1.TabIndex = 20
        Label1.Text = "Username"
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(149, 145)
        TextBox2.Multiline = True
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(230, 33)
        TextBox2.TabIndex = 19
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(149, 106)
        TextBox1.Multiline = True
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(230, 33)
        TextBox1.TabIndex = 18
        ' 
        ' Form6
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FloralWhite
        ClientSize = New Size(436, 426)
        Controls.Add(PictureBox2)
        Controls.Add(Label5)
        Controls.Add(PictureBox1)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(ComboBox2)
        Controls.Add(ComboBox1)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(TextBox2)
        Controls.Add(TextBox1)
        Name = "Form6"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Edit an Account"
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label5 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
End Class
