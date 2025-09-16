<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form28
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form28))
        Label5 = New Label()
        ComboBox2 = New ComboBox()
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
        DataGridView1 = New DataGridView()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(14, 86)
        Label5.Name = "Label5"
        Label5.Size = New Size(130, 19)
        Label5.TabIndex = 90
        Label5.Text = "Select a Service"
        ' 
        ' ComboBox2
        ' 
        ComboBox2.FormattingEnabled = True
        ComboBox2.Location = New Point(167, 82)
        ComboBox2.Name = "ComboBox2"
        ComboBox2.Size = New Size(221, 23)
        ComboBox2.TabIndex = 89
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(188, 128)
        Label4.Name = "Label4"
        Label4.Size = New Size(154, 19)
        Label4.TabIndex = 88
        Label4.Text = "Edit Date of Service"
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.Location = New Point(188, 150)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(200, 23)
        DateTimePicker1.TabIndex = 87
        ' 
        ' Button3
        ' 
        Button3.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button3.Location = New Point(268, 586)
        Button3.Name = "Button3"
        Button3.Size = New Size(120, 37)
        Button3.TabIndex = 86
        Button3.Text = "Cancel"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button2.Location = New Point(142, 586)
        Button2.Name = "Button2"
        Button2.Size = New Size(120, 37)
        Button2.TabIndex = 85
        Button2.Text = "Clear"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button1.Location = New Point(16, 586)
        Button1.Name = "Button1"
        Button1.Size = New Size(120, 37)
        Button1.TabIndex = 84
        Button1.Text = "Save"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(16, 190)
        Label3.Name = "Label3"
        Label3.Size = New Size(302, 19)
        Label3.TabIndex = 83
        Label3.Text = "Select new service given to the patient"
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(16, 212)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(372, 23)
        TextBox1.TabIndex = 82
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(14, 126)
        Label2.Name = "Label2"
        Label2.Size = New Size(90, 19)
        Label2.TabIndex = 81
        Label2.Text = "Edit Doctor"
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Items.AddRange(New Object() {"Dr. Salamida", "Dr. Brucela"})
        ComboBox1.Location = New Point(14, 150)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(122, 23)
        ComboBox1.TabIndex = 80
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.DarkSeaGreen
        Label1.Font = New Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(81, 41)
        Label1.Name = "Label1"
        Label1.Size = New Size(128, 25)
        Label1.TabIndex = 79
        Label1.Text = "Edit Service"
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.DarkSeaGreen
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(14, 4)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(61, 62)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 78
        PictureBox2.TabStop = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.DarkSeaGreen
        PictureBox1.Location = New Point(0, -2)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(401, 78)
        PictureBox1.TabIndex = 77
        PictureBox1.TabStop = False
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(16, 241)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.Size = New Size(371, 339)
        DataGridView1.TabIndex = 91
        ' 
        ' Form28
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
        Name = "Form28"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form28"
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label5 As Label
    Friend WithEvents ComboBox2 As ComboBox
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
    Friend WithEvents DataGridView1 As DataGridView
End Class
