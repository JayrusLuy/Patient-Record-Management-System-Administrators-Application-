<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form25
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form25))
        Label4 = New Label()
        DateTimePicker1 = New DateTimePicker()
        Button3 = New Button()
        Button2 = New Button()
        Button1 = New Button()
        Label3 = New Label()
        TextBox1 = New TextBox()
        Label2 = New Label()
        ComboBox1 = New ComboBox()
        Label1 = New Label()
        PictureBox2 = New PictureBox()
        PictureBox1 = New PictureBox()
        ComboBox2 = New ComboBox()
        Label5 = New Label()
        DataGridView1 = New DataGridView()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(186, 127)
        Label4.Name = "Label4"
        Label4.Size = New Size(171, 19)
        Label4.TabIndex = 74
        Label4.Text = "Edit Date of Diagnosis"
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.Location = New Point(186, 149)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(200, 23)
        DateTimePicker1.TabIndex = 73
        ' 
        ' Button3
        ' 
        Button3.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button3.Location = New Point(266, 585)
        Button3.Name = "Button3"
        Button3.Size = New Size(120, 37)
        Button3.TabIndex = 72
        Button3.Text = "Cancel"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button2.Location = New Point(140, 585)
        Button2.Name = "Button2"
        Button2.Size = New Size(120, 37)
        Button2.TabIndex = 71
        Button2.Text = "Clear"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button1.Location = New Point(14, 585)
        Button1.Name = "Button1"
        Button1.Size = New Size(120, 37)
        Button1.TabIndex = 70
        Button1.Text = "Save"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(14, 189)
        Label3.Name = "Label3"
        Label3.Size = New Size(228, 19)
        Label3.TabIndex = 69
        Label3.Text = "Select new diagnosed illness"
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(14, 211)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(372, 23)
        TextBox1.TabIndex = 68
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(12, 125)
        Label2.Name = "Label2"
        Label2.Size = New Size(90, 19)
        Label2.TabIndex = 67
        Label2.Text = "Edit Doctor"
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Items.AddRange(New Object() {"Dr. Salamida", "Dr. Brucela"})
        ComboBox1.Location = New Point(12, 149)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(122, 23)
        ComboBox1.TabIndex = 66
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.DarkSeaGreen
        Label1.Font = New Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(79, 40)
        Label1.Name = "Label1"
        Label1.Size = New Size(151, 25)
        Label1.TabIndex = 65
        Label1.Text = "Edit Diagnosis"
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.DarkSeaGreen
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(12, 3)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(61, 62)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 64
        PictureBox2.TabStop = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.DarkSeaGreen
        PictureBox1.Location = New Point(-2, -3)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(401, 78)
        PictureBox1.TabIndex = 63
        PictureBox1.TabStop = False
        ' 
        ' ComboBox2
        ' 
        ComboBox2.FormattingEnabled = True
        ComboBox2.Location = New Point(165, 81)
        ComboBox2.Name = "ComboBox2"
        ComboBox2.Size = New Size(221, 23)
        ComboBox2.TabIndex = 75
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(12, 85)
        Label5.Name = "Label5"
        Label5.Size = New Size(147, 19)
        Label5.TabIndex = 76
        Label5.Text = "Select a Diagnosis" & vbCrLf
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(12, 240)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.Size = New Size(374, 339)
        DataGridView1.TabIndex = 77
        ' 
        ' Form25
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FloralWhite
        ClientSize = New Size(399, 629)
        Controls.Add(DataGridView1)
        Controls.Add(Label5)
        Controls.Add(ComboBox2)
        Controls.Add(Label4)
        Controls.Add(DateTimePicker1)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(Label3)
        Controls.Add(TextBox1)
        Controls.Add(Label2)
        Controls.Add(ComboBox1)
        Controls.Add(Label1)
        Controls.Add(PictureBox2)
        Controls.Add(PictureBox1)
        Name = "Form25"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form25"
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label4 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents DataGridView1 As DataGridView
End Class
