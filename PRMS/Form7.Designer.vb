<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form7
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form7))
        PictureBox1 = New PictureBox()
        PictureBox2 = New PictureBox()
        Label1 = New Label()
        DataGridView1 = New DataGridView()
        Button1 = New Button()
        Button2 = New Button()
        TextBox1 = New TextBox()
        Button3 = New Button()
        Button4 = New Button()
        Button5 = New Button()
        Button6 = New Button()
        Button9 = New Button()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.DarkSeaGreen
        PictureBox1.Location = New Point(0, 0)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(869, 78)
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.DarkSeaGreen
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(10, 10)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(61, 62)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 9
        PictureBox2.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.DarkSeaGreen
        Label1.Font = New Font("Century Gothic", 24F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(76, 39)
        Label1.Name = "Label1"
        Label1.Size = New Size(484, 38)
        Label1.TabIndex = 10
        Label1.Text = "Out Patient's Basic Information"
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(10, 83)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.Size = New Size(702, 387)
        DataGridView1.TabIndex = 11
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Century Gothic", 11.25F, FontStyle.Bold)
        Button1.Location = New Point(717, 84)
        Button1.Name = "Button1"
        Button1.Size = New Size(129, 32)
        Button1.TabIndex = 12
        Button1.Text = "Add Record"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Century Gothic", 11.25F, FontStyle.Bold)
        Button2.Location = New Point(717, 122)
        Button2.Name = "Button2"
        Button2.Size = New Size(129, 32)
        Button2.TabIndex = 13
        Button2.Text = "Edit Record"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' TextBox1
        ' 
        TextBox1.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox1.Location = New Point(645, 51)
        TextBox1.Multiline = True
        TextBox1.Name = "TextBox1"
        TextBox1.PlaceholderText = "Search for a Record"
        TextBox1.Size = New Size(202, 21)
        TextBox1.TabIndex = 21
        ' 
        ' Button3
        ' 
        Button3.Font = New Font("Century Gothic", 11.25F, FontStyle.Bold)
        Button3.Location = New Point(718, 263)
        Button3.Name = "Button3"
        Button3.Size = New Size(129, 46)
        Button3.TabIndex = 22
        Button3.Text = "Add Clinical Care"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button4
        ' 
        Button4.Font = New Font("Century Gothic", 11.25F, FontStyle.Bold)
        Button4.Location = New Point(718, 315)
        Button4.Name = "Button4"
        Button4.Size = New Size(129, 46)
        Button4.TabIndex = 23
        Button4.Text = "Edit Clinical Care"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Button5
        ' 
        Button5.Font = New Font("Century Gothic", 11.25F, FontStyle.Bold)
        Button5.Location = New Point(717, 367)
        Button5.Name = "Button5"
        Button5.Size = New Size(129, 46)
        Button5.TabIndex = 24
        Button5.Text = "View Clinical Care"
        Button5.UseVisualStyleBackColor = True
        ' 
        ' Button6
        ' 
        Button6.Font = New Font("Century Gothic", 11.25F, FontStyle.Bold)
        Button6.Location = New Point(717, 419)
        Button6.Name = "Button6"
        Button6.Size = New Size(129, 46)
        Button6.TabIndex = 25
        Button6.Text = "Recycle Clinical Care"
        Button6.UseVisualStyleBackColor = True
        ' 
        ' Button9
        ' 
        Button9.Font = New Font("Century Gothic", 11.25F, FontStyle.Bold)
        Button9.Location = New Point(718, 160)
        Button9.Name = "Button9"
        Button9.Size = New Size(129, 32)
        Button9.TabIndex = 20
        Button9.Text = "Recycle Record"
        Button9.UseVisualStyleBackColor = True
        ' 
        ' Form7
        ' 
        AutoScaleDimensions = New SizeF(6F, 13F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FloralWhite
        ClientSize = New Size(858, 480)
        Controls.Add(Button6)
        Controls.Add(Button5)
        Controls.Add(Button4)
        Controls.Add(Button3)
        Controls.Add(TextBox1)
        Controls.Add(Button9)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(DataGridView1)
        Controls.Add(Label1)
        Controls.Add(PictureBox2)
        Controls.Add(PictureBox1)
        Font = New Font("Microsoft Sans Serif", 8.25F)
        Name = "Form7"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form7"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button9 As Button
End Class
