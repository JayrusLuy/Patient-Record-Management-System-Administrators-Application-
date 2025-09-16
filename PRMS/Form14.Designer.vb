<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form14
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form14))
        Label30 = New Label()
        CheckedListBox3 = New CheckedListBox()
        Button3 = New Button()
        Button2 = New Button()
        Button1 = New Button()
        PictureBox1 = New PictureBox()
        PictureBox2 = New PictureBox()
        Label1 = New Label()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label30
        ' 
        Label30.AutoSize = True
        Label30.BackColor = Color.FloralWhite
        Label30.Font = New Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label30.Location = New Point(12, 86)
        Label30.Name = "Label30"
        Label30.Size = New Size(102, 23)
        Label30.TabIndex = 89
        Label30.Text = "Treatment"
        ' 
        ' CheckedListBox3
        ' 
        CheckedListBox3.FormattingEnabled = True
        CheckedListBox3.Location = New Point(12, 112)
        CheckedListBox3.Name = "CheckedListBox3"
        CheckedListBox3.Size = New Size(186, 130)
        CheckedListBox3.TabIndex = 88
        ' 
        ' Button3
        ' 
        Button3.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button3.Location = New Point(204, 198)
        Button3.Name = "Button3"
        Button3.Size = New Size(120, 37)
        Button3.TabIndex = 92
        Button3.Text = "Cancel"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button2.Location = New Point(204, 155)
        Button2.Name = "Button2"
        Button2.Size = New Size(120, 37)
        Button2.TabIndex = 91
        Button2.Text = "Clear"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button1.Location = New Point(204, 112)
        Button1.Name = "Button1"
        Button1.Size = New Size(120, 37)
        Button1.TabIndex = 90
        Button1.Text = "Save"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.DarkSeaGreen
        PictureBox1.Location = New Point(-2, -4)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(339, 78)
        PictureBox1.TabIndex = 93
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
        PictureBox2.TabIndex = 94
        PictureBox2.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.DarkSeaGreen
        Label1.Font = New Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(79, 49)
        Label1.Name = "Label1"
        Label1.Size = New Size(194, 25)
        Label1.TabIndex = 95
        Label1.Text = "Update Treatment"
        ' 
        ' Form14
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FloralWhite
        ClientSize = New Size(336, 254)
        Controls.Add(Label1)
        Controls.Add(PictureBox2)
        Controls.Add(PictureBox1)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(Label30)
        Controls.Add(CheckedListBox3)
        Name = "Form14"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form14"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label30 As Label
    Friend WithEvents CheckedListBox3 As CheckedListBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label1 As Label
End Class
