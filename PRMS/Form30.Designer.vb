<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form30
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form30))
        TextBox1 = New TextBox()
        Button2 = New Button()
        Button1 = New Button()
        DataGridView1 = New DataGridView()
        Label1 = New Label()
        PictureBox2 = New PictureBox()
        PictureBox1 = New PictureBox()
        Button3 = New Button()
        Button4 = New Button()
        Button5 = New Button()
        Button6 = New Button()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TextBox1
        ' 
        TextBox1.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox1.Location = New Point(644, 50)
        TextBox1.Multiline = True
        TextBox1.Name = "TextBox1"
        TextBox1.PlaceholderText = "Search"
        TextBox1.Size = New Size(202, 21)
        TextBox1.TabIndex = 33
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Century Gothic", 11.25F, FontStyle.Bold)
        Button2.Location = New Point(717, 159)
        Button2.Name = "Button2"
        Button2.Size = New Size(129, 32)
        Button2.TabIndex = 31
        Button2.Text = "Delete"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Century Gothic", 11.25F, FontStyle.Bold)
        Button1.Location = New Point(716, 83)
        Button1.Name = "Button1"
        Button1.Size = New Size(129, 32)
        Button1.TabIndex = 30
        Button1.Text = "Add"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(9, 82)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.Size = New Size(702, 387)
        DataGridView1.TabIndex = 29
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.DarkSeaGreen
        Label1.Font = New Font("Century Gothic", 24F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(76, 33)
        Label1.Name = "Label1"
        Label1.Size = New Size(249, 38)
        Label1.TabIndex = 28
        Label1.Text = "Set Up Controls"
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.DarkSeaGreen
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(9, 9)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(61, 62)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 27
        PictureBox2.TabStop = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.DarkSeaGreen
        PictureBox1.Location = New Point(-1, -1)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(869, 78)
        PictureBox1.TabIndex = 26
        PictureBox1.TabStop = False
        ' 
        ' Button3
        ' 
        Button3.Font = New Font("Century Gothic", 11.25F, FontStyle.Bold)
        Button3.Location = New Point(717, 318)
        Button3.Name = "Button3"
        Button3.Size = New Size(129, 46)
        Button3.TabIndex = 34
        Button3.Text = "Set Up List of Doctors"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button4
        ' 
        Button4.Font = New Font("Century Gothic", 11.25F, FontStyle.Bold)
        Button4.Location = New Point(717, 370)
        Button4.Name = "Button4"
        Button4.Size = New Size(129, 46)
        Button4.TabIndex = 35
        Button4.Text = "Set Up List of Illnesses"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Button5
        ' 
        Button5.Font = New Font("Century Gothic", 11.25F, FontStyle.Bold)
        Button5.Location = New Point(716, 422)
        Button5.Name = "Button5"
        Button5.Size = New Size(129, 46)
        Button5.TabIndex = 36
        Button5.Text = "Set Up List of Services"
        Button5.UseVisualStyleBackColor = True
        ' 
        ' Button6
        ' 
        Button6.Font = New Font("Century Gothic", 11.25F, FontStyle.Bold)
        Button6.Location = New Point(717, 121)
        Button6.Name = "Button6"
        Button6.Size = New Size(129, 32)
        Button6.TabIndex = 37
        Button6.Text = "Edit"
        Button6.UseVisualStyleBackColor = True
        ' 
        ' Form30
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FloralWhite
        ClientSize = New Size(852, 480)
        Controls.Add(Button6)
        Controls.Add(Button5)
        Controls.Add(Button4)
        Controls.Add(Button3)
        Controls.Add(TextBox1)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(DataGridView1)
        Controls.Add(Label1)
        Controls.Add(PictureBox2)
        Controls.Add(PictureBox1)
        Name = "Form30"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form30"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
End Class
