<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HomeForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HomeForm))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnMini = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnTrainer = New System.Windows.Forms.Button()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.btnUser = New System.Windows.Forms.Button()
        Me.btnReports = New System.Windows.Forms.Button()
        Me.btnTransaction = New System.Windows.Forms.Button()
        Me.btnEquipment = New System.Windows.Forms.Button()
        Me.btnInstructor = New System.Windows.Forms.Button()
        Me.btnPlanCourse = New System.Windows.Forms.Button()
        Me.btnMember = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Orange
        Me.Panel1.Controls.Add(Me.btnMini)
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1303, 53)
        Me.Panel1.TabIndex = 0
        '
        'btnMini
        '
        Me.btnMini.BackgroundImage = CType(resources.GetObject("btnMini.BackgroundImage"), System.Drawing.Image)
        Me.btnMini.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnMini.FlatAppearance.BorderSize = 0
        Me.btnMini.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMini.Location = New System.Drawing.Point(1197, 4)
        Me.btnMini.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnMini.Name = "btnMini"
        Me.btnMini.Size = New System.Drawing.Size(45, 44)
        Me.btnMini.TabIndex = 4
        Me.btnMini.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = CType(resources.GetObject("btnClose.BackgroundImage"), System.Drawing.Image)
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Location = New System.Drawing.Point(1251, 4)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(45, 44)
        Me.btnClose.TabIndex = 3
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(92, 10)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(360, 39)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Management System"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(8, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 39)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "GYM"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnTrainer)
        Me.Panel2.Controls.Add(Me.btnLogout)
        Me.Panel2.Controls.Add(Me.btnUser)
        Me.Panel2.Controls.Add(Me.btnReports)
        Me.Panel2.Controls.Add(Me.btnTransaction)
        Me.Panel2.Controls.Add(Me.btnEquipment)
        Me.Panel2.Controls.Add(Me.btnInstructor)
        Me.Panel2.Controls.Add(Me.btnPlanCourse)
        Me.Panel2.Controls.Add(Me.btnMember)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 53)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(316, 778)
        Me.Panel2.TabIndex = 1
        '
        'btnTrainer
        '
        Me.btnTrainer.BackColor = System.Drawing.Color.Orange
        Me.btnTrainer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTrainer.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTrainer.ForeColor = System.Drawing.Color.White
        Me.btnTrainer.Image = CType(resources.GetObject("btnTrainer.Image"), System.Drawing.Image)
        Me.btnTrainer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTrainer.Location = New System.Drawing.Point(-1, 546)
        Me.btnTrainer.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnTrainer.Name = "btnTrainer"
        Me.btnTrainer.Size = New System.Drawing.Size(315, 46)
        Me.btnTrainer.TabIndex = 10
        Me.btnTrainer.Text = "Trainer"
        Me.btnTrainer.UseVisualStyleBackColor = False
        '
        'btnLogout
        '
        Me.btnLogout.BackColor = System.Drawing.Color.Orange
        Me.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogout.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogout.ForeColor = System.Drawing.Color.White
        Me.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLogout.Location = New System.Drawing.Point(3, 594)
        Me.btnLogout.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(315, 46)
        Me.btnLogout.TabIndex = 9
        Me.btnLogout.Text = "Logout"
        Me.btnLogout.UseVisualStyleBackColor = False
        '
        'btnUser
        '
        Me.btnUser.BackColor = System.Drawing.Color.Orange
        Me.btnUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUser.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUser.ForeColor = System.Drawing.Color.White
        Me.btnUser.Image = CType(resources.GetObject("btnUser.Image"), System.Drawing.Image)
        Me.btnUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUser.Location = New System.Drawing.Point(1, 498)
        Me.btnUser.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnUser.Name = "btnUser"
        Me.btnUser.Size = New System.Drawing.Size(315, 46)
        Me.btnUser.TabIndex = 8
        Me.btnUser.Text = "User"
        Me.btnUser.UseVisualStyleBackColor = False
        '
        'btnReports
        '
        Me.btnReports.BackColor = System.Drawing.Color.Orange
        Me.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReports.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReports.ForeColor = System.Drawing.Color.White
        Me.btnReports.Image = CType(resources.GetObject("btnReports.Image"), System.Drawing.Image)
        Me.btnReports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReports.Location = New System.Drawing.Point(0, 449)
        Me.btnReports.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnReports.Name = "btnReports"
        Me.btnReports.Size = New System.Drawing.Size(315, 46)
        Me.btnReports.TabIndex = 6
        Me.btnReports.Text = "Reports"
        Me.btnReports.UseVisualStyleBackColor = False
        '
        'btnTransaction
        '
        Me.btnTransaction.BackColor = System.Drawing.Color.Orange
        Me.btnTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTransaction.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTransaction.ForeColor = System.Drawing.Color.White
        Me.btnTransaction.Image = CType(resources.GetObject("btnTransaction.Image"), System.Drawing.Image)
        Me.btnTransaction.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTransaction.Location = New System.Drawing.Point(0, 399)
        Me.btnTransaction.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnTransaction.Name = "btnTransaction"
        Me.btnTransaction.Size = New System.Drawing.Size(315, 46)
        Me.btnTransaction.TabIndex = 5
        Me.btnTransaction.Text = "Transaction"
        Me.btnTransaction.UseVisualStyleBackColor = False
        '
        'btnEquipment
        '
        Me.btnEquipment.BackColor = System.Drawing.Color.Orange
        Me.btnEquipment.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEquipment.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEquipment.ForeColor = System.Drawing.Color.White
        Me.btnEquipment.Image = CType(resources.GetObject("btnEquipment.Image"), System.Drawing.Image)
        Me.btnEquipment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEquipment.Location = New System.Drawing.Point(0, 348)
        Me.btnEquipment.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnEquipment.Name = "btnEquipment"
        Me.btnEquipment.Size = New System.Drawing.Size(315, 46)
        Me.btnEquipment.TabIndex = 4
        Me.btnEquipment.Text = "Equipment"
        Me.btnEquipment.UseVisualStyleBackColor = False
        '
        'btnInstructor
        '
        Me.btnInstructor.BackColor = System.Drawing.Color.Orange
        Me.btnInstructor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnInstructor.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInstructor.ForeColor = System.Drawing.Color.White
        Me.btnInstructor.Image = CType(resources.GetObject("btnInstructor.Image"), System.Drawing.Image)
        Me.btnInstructor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnInstructor.Location = New System.Drawing.Point(0, 298)
        Me.btnInstructor.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnInstructor.Name = "btnInstructor"
        Me.btnInstructor.Size = New System.Drawing.Size(315, 46)
        Me.btnInstructor.TabIndex = 3
        Me.btnInstructor.Text = "Instructor"
        Me.btnInstructor.UseVisualStyleBackColor = False
        '
        'btnPlanCourse
        '
        Me.btnPlanCourse.BackColor = System.Drawing.Color.Orange
        Me.btnPlanCourse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPlanCourse.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPlanCourse.ForeColor = System.Drawing.Color.White
        Me.btnPlanCourse.Image = CType(resources.GetObject("btnPlanCourse.Image"), System.Drawing.Image)
        Me.btnPlanCourse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPlanCourse.Location = New System.Drawing.Point(0, 247)
        Me.btnPlanCourse.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnPlanCourse.Name = "btnPlanCourse"
        Me.btnPlanCourse.Size = New System.Drawing.Size(315, 46)
        Me.btnPlanCourse.TabIndex = 2
        Me.btnPlanCourse.Text = "Plan / Course"
        Me.btnPlanCourse.UseVisualStyleBackColor = False
        '
        'btnMember
        '
        Me.btnMember.BackColor = System.Drawing.Color.Orange
        Me.btnMember.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMember.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMember.ForeColor = System.Drawing.Color.White
        Me.btnMember.Image = CType(resources.GetObject("btnMember.Image"), System.Drawing.Image)
        Me.btnMember.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMember.Location = New System.Drawing.Point(1, 200)
        Me.btnMember.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnMember.Name = "btnMember"
        Me.btnMember.Size = New System.Drawing.Size(315, 46)
        Me.btnMember.TabIndex = 1
        Me.btnMember.Text = "MemberShip"
        Me.btnMember.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Orange
        Me.Panel3.Controls.Add(Me.lblUserName)
        Me.Panel3.Controls.Add(Me.PictureBox1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.ForeColor = System.Drawing.Color.White
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(316, 192)
        Me.Panel3.TabIndex = 0
        '
        'lblUserName
        '
        Me.lblUserName.AutoSize = True
        Me.lblUserName.Font = New System.Drawing.Font("Arial Rounded MT Bold", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserName.ForeColor = System.Drawing.Color.White
        Me.lblUserName.Location = New System.Drawing.Point(55, 145)
        Me.lblUserName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(192, 39)
        Me.lblUserName.TabIndex = 5
        Me.lblUserName.Text = "UserName"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(69, 4)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(175, 138)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'Panel4
        '
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(316, 53)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(987, 778)
        Me.Panel4.TabIndex = 2
        '
        'HomeForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1303, 831)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "HomeForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HomeForm"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnMini As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnLogout As System.Windows.Forms.Button
    Friend WithEvents btnUser As System.Windows.Forms.Button
    Friend WithEvents btnReports As System.Windows.Forms.Button
    Friend WithEvents btnTransaction As System.Windows.Forms.Button
    Friend WithEvents btnEquipment As System.Windows.Forms.Button
    Friend WithEvents btnInstructor As System.Windows.Forms.Button
    Friend WithEvents btnPlanCourse As System.Windows.Forms.Button
    Friend WithEvents btnMember As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents btnTrainer As System.Windows.Forms.Button
End Class
