<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form26
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form26))
        Button1 = New Button()
        Button2 = New Button()
        PictureBox1 = New PictureBox()
        PictureBox2 = New PictureBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button1.Location = New Point(12, 128)
        Button1.Name = "Button1"
        Button1.Size = New Size(108, 34)
        Button1.TabIndex = 0
        Button1.Text = "Backup"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button2.Location = New Point(134, 128)
        Button2.Name = "Button2"
        Button2.Size = New Size(108, 34)
        Button2.TabIndex = 1
        Button2.Text = "Restore"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.DarkSeaGreen
        PictureBox1.Location = New Point(0, 0)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(261, 60)
        PictureBox1.TabIndex = 2
        PictureBox1.TabStop = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.DarkSeaGreen
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(0, 0)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(62, 60)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 15
        PictureBox2.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.DarkSeaGreen
        Label1.Font = New Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(66, 37)
        Label1.Name = "Label1"
        Label1.Size = New Size(195, 23)
        Label1.TabIndex = 16
        Label1.Text = "Backup and Restore"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.FloralWhite
        Label2.Font = New Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = SystemColors.ActiveCaptionText
        Label2.Location = New Point(12, 63)
        Label2.Name = "Label2"
        Label2.Size = New Size(237, 23)
        Label2.TabIndex = 17
        Label2.Text = "Backups  are located at "
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.FloralWhite
        Label3.Font = New Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = SystemColors.ActiveCaptionText
        Label3.Location = New Point(12, 86)
        Label3.Name = "Label3"
        Label3.Size = New Size(233, 23)
        Label3.TabIndex = 18
        Label3.Text = """C:\database backups"""
        ' 
        ' Form26
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FloralWhite
        ClientSize = New Size(261, 177)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(PictureBox2)
        Controls.Add(PictureBox1)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Name = "Form26"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Backup & Restore Page"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
