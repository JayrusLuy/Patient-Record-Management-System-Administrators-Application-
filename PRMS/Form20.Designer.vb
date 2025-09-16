<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form20
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form20))
        TextBox1 = New TextBox()
        Button2 = New Button()
        Button1 = New Button()
        DataGridView1 = New DataGridView()
        Label1 = New Label()
        PictureBox2 = New PictureBox()
        PictureBox1 = New PictureBox()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TextBox1
        ' 
        TextBox1.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox1.Location = New Point(642, 51)
        TextBox1.Multiline = True
        TextBox1.Name = "TextBox1"
        TextBox1.PlaceholderText = "Search for a Record"
        TextBox1.Size = New Size(202, 21)
        TextBox1.TabIndex = 33
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Century Gothic", 11.25F, FontStyle.Bold)
        Button2.Location = New Point(714, 122)
        Button2.Name = "Button2"
        Button2.Size = New Size(129, 32)
        Button2.TabIndex = 31
        Button2.Text = "Restore"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Century Gothic", 11.25F, FontStyle.Bold)
        Button1.Location = New Point(714, 84)
        Button1.Name = "Button1"
        Button1.Size = New Size(129, 32)
        Button1.TabIndex = 30
        Button1.Text = "Delete"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(7, 83)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.Size = New Size(702, 387)
        DataGridView1.TabIndex = 29
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.DarkSeaGreen
        Label1.Font = New Font("Century Gothic", 24F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(74, 34)
        Label1.Name = "Label1"
        Label1.Size = New Size(452, 38)
        Label1.TabIndex = 28
        Label1.Text = "Out Patient Info Reycling Bin"
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.DarkSeaGreen
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(7, 10)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(61, 62)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 27
        PictureBox2.TabStop = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.DarkSeaGreen
        PictureBox1.Location = New Point(-3, 0)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(869, 78)
        PictureBox1.TabIndex = 26
        PictureBox1.TabStop = False
        ' 
        ' Form20
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FloralWhite
        ClientSize = New Size(858, 480)
        Controls.Add(TextBox1)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(DataGridView1)
        Controls.Add(Label1)
        Controls.Add(PictureBox2)
        Controls.Add(PictureBox1)
        Name = "Form20"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form20"
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
End Class
