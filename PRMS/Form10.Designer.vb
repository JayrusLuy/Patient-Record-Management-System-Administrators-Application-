<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form10
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form10))
        PictureBox1 = New PictureBox()
        PictureBox2 = New PictureBox()
        Label1 = New Label()
        ComboBox1 = New ComboBox()
        Label2 = New Label()
        TextBox1 = New TextBox()
        Label3 = New Label()
        Button3 = New Button()
        Button2 = New Button()
        Button1 = New Button()
        DateTimePicker1 = New DateTimePicker()
        Label4 = New Label()
        DataGridView1 = New DataGridView()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.DarkSeaGreen
        PictureBox1.Location = New Point(-2, -3)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(401, 78)
        PictureBox1.TabIndex = 1
        PictureBox1.TabStop = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.DarkSeaGreen
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(12, 3)
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
        Label1.Font = New Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(79, 40)
        Label1.Name = "Label1"
        Label1.Size = New Size(159, 25)
        Label1.TabIndex = 11
        Label1.Text = "Add Diagnosis"
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(12, 102)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(122, 23)
        ComboBox1.TabIndex = 12
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(12, 78)
        Label2.Name = "Label2"
        Label2.Size = New Size(59, 19)
        Label2.TabIndex = 13
        Label2.Text = "Doctor"
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(14, 164)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(372, 23)
        TextBox1.TabIndex = 14
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(14, 142)
        Label3.Name = "Label3"
        Label3.Size = New Size(222, 19)
        Label3.TabIndex = 15
        Label3.Text = "Search for diagnosed illness"
        ' 
        ' Button3
        ' 
        Button3.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button3.Location = New Point(266, 538)
        Button3.Name = "Button3"
        Button3.Size = New Size(120, 37)
        Button3.TabIndex = 60
        Button3.Text = "Cancel"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button2.Location = New Point(140, 538)
        Button2.Name = "Button2"
        Button2.Size = New Size(120, 37)
        Button2.TabIndex = 59
        Button2.Text = "Clear"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button1.Location = New Point(14, 538)
        Button1.Name = "Button1"
        Button1.Size = New Size(120, 37)
        Button1.TabIndex = 58
        Button1.Text = "Save"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.Location = New Point(186, 102)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(200, 23)
        DateTimePicker1.TabIndex = 61
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(186, 80)
        Label4.Name = "Label4"
        Label4.Size = New Size(140, 19)
        Label4.TabIndex = 62
        Label4.Text = "Date of Diagnosis"
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(14, 193)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.Size = New Size(372, 339)
        DataGridView1.TabIndex = 63
        ' 
        ' Form10
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FloralWhite
        ClientSize = New Size(399, 583)
        Controls.Add(DataGridView1)
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
        Name = "Form10"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form10"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents DataGridView1 As DataGridView
End Class
