<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form21
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form21))
        Button3 = New Button()
        Button2 = New Button()
        Button1 = New Button()
        Label2 = New Label()
        TextBox1 = New TextBox()
        PictureBox2 = New PictureBox()
        Label1 = New Label()
        PictureBox1 = New PictureBox()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Button3
        ' 
        Button3.Font = New Font("Century Gothic", 11.25F, FontStyle.Bold)
        Button3.Location = New Point(220, 108)
        Button3.Name = "Button3"
        Button3.Size = New Size(99, 32)
        Button3.TabIndex = 43
        Button3.Text = "Cancel"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Century Gothic", 11.25F, FontStyle.Bold)
        Button2.Location = New Point(115, 108)
        Button2.Name = "Button2"
        Button2.Size = New Size(99, 32)
        Button2.TabIndex = 42
        Button2.Text = "Clear"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Century Gothic", 11.25F, FontStyle.Bold)
        Button1.Location = New Point(10, 108)
        Button1.Name = "Button1"
        Button1.Size = New Size(99, 32)
        Button1.TabIndex = 41
        Button1.Text = "Save"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.FloralWhite
        Label2.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(31, 71)
        Label2.Name = "Label2"
        Label2.Size = New Size(95, 19)
        Label2.TabIndex = 40
        Label2.Text = "Edit Control"
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(132, 67)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(169, 23)
        TextBox1.TabIndex = 39
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.DarkSeaGreen
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(-3, 0)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(61, 62)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 38
        PictureBox2.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.DarkSeaGreen
        Label1.Font = New Font("Century Gothic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(64, 23)
        Label1.Name = "Label1"
        Label1.Size = New Size(161, 32)
        Label1.TabIndex = 37
        Label1.Text = "edit control"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.DarkSeaGreen
        PictureBox1.Location = New Point(-3, 0)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(337, 61)
        PictureBox1.TabIndex = 36
        PictureBox1.TabStop = False
        ' 
        ' Form21
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FloralWhite
        ClientSize = New Size(334, 151)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(Label2)
        Controls.Add(TextBox1)
        Controls.Add(PictureBox2)
        Controls.Add(Label1)
        Controls.Add(PictureBox1)
        Name = "Form21"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form21"
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
