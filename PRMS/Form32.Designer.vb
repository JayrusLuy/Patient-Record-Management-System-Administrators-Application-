<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form32
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form32))
        PictureBox2 = New PictureBox()
        Label1 = New Label()
        PictureBox1 = New PictureBox()
        Button2 = New Button()
        Button1 = New Button()
        ComboBox1 = New ComboBox()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.DarkSeaGreen
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(-1, 0)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(62, 60)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 89
        PictureBox2.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.DarkSeaGreen
        Label1.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(67, 35)
        Label1.Name = "Label1"
        Label1.Size = New Size(193, 19)
        Label1.TabIndex = 88
        Label1.Text = "Select which * to recyce"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.DarkSeaGreen
        PictureBox1.Location = New Point(-1, 0)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(397, 60)
        PictureBox1.TabIndex = 87
        PictureBox1.TabStop = False
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Century Gothic", 11.25F, FontStyle.Bold)
        Button2.Location = New Point(137, 95)
        Button2.Name = "Button2"
        Button2.Size = New Size(120, 37)
        Button2.TabIndex = 85
        Button2.Text = "Cancel"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Century Gothic", 11.25F, FontStyle.Bold)
        Button1.Location = New Point(11, 95)
        Button1.Name = "Button1"
        Button1.Size = New Size(120, 37)
        Button1.TabIndex = 84
        Button1.Text = "Confirm"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(11, 66)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(370, 23)
        ComboBox1.TabIndex = 90
        ' 
        ' Form32
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FloralWhite
        ClientSize = New Size(393, 141)
        Controls.Add(ComboBox1)
        Controls.Add(PictureBox2)
        Controls.Add(Label1)
        Controls.Add(PictureBox1)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Name = "Form32"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form32"
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents ComboBox1 As ComboBox
End Class
