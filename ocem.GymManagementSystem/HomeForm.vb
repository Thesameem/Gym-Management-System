Public Class HomeForm

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Application.Exit()
    End Sub

    Private Sub btnMini_Click(sender As Object, e As EventArgs) Handles btnMini.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Me.Hide()
        LoginForm.show()
    End Sub

    Private Sub btnMember_Click(sender As Object, e As EventArgs) Handles btnMember.Click
        If Not Panel4.Controls.Contains(MemberForm.Instance) Then
            Panel4.Controls.Add(MemberForm.Instance)
            MemberForm.Instance.Dock = DockStyle.Fill
            MemberForm.Instance.BringToFront()
            MemberForm.Instance.Visible = True
        End If
        MemberForm.Instance.BringToFront()
        MemberForm.Instance.Visible = True
    End Sub

    Private Sub btnPlanCourse_Click(sender As Object, e As EventArgs) Handles btnPlanCourse.Click
        If Not Panel4.Controls.Contains(PlanCourseForm.Instance) Then
            Panel4.Controls.Add(PlanCourseForm.Instance)
            PlanCourseForm.Instance.Dock = DockStyle.Fill
            PlanCourseForm.Instance.BringToFront()
            PlanCourseForm.Instance.Visible = True
        End If
        PlanCourseForm.Instance.BringToFront()
        PlanCourseForm.Instance.Visible = True
    End Sub

    Private Sub btnInstructor_Click(sender As Object, e As EventArgs) Handles btnInstructor.Click
        If Not Panel4.Controls.Contains(InstructorForm.Instance) Then
            Panel4.Controls.Add(InstructorForm.Instance)
            InstructorForm.Instance.Dock = DockStyle.Fill
            InstructorForm.Instance.BringToFront()
            InstructorForm.Instance.Visible = True
        End If
        InstructorForm.Instance.BringToFront()
        InstructorForm.Instance.Visible = True
    End Sub

    Private Sub btnEquipment_Click(sender As Object, e As EventArgs) Handles btnEquipment.Click
        If Not Panel4.Controls.Contains(EquipmentForm.Instance) Then
            Panel4.Controls.Add(EquipmentForm.Instance)
            EquipmentForm.Instance.Dock = DockStyle.Fill
            EquipmentForm.Instance.BringToFront()
            EquipmentForm.Instance.Visible = True
        End If
        EquipmentForm.Instance.BringToFront()
        EquipmentForm.Instance.Visible = True
    End Sub

    Private Sub btnTransaction_Click(sender As Object, e As EventArgs) Handles btnTransaction.Click
        If Not Panel4.Controls.Contains(TransactionForm.Instance) Then
            Panel4.Controls.Add(TransactionForm.Instance)
            TransactionForm.Instance.Dock = DockStyle.Fill
            TransactionForm.Instance.BringToFront()
            TransactionForm.Instance.Visible = True
        End If
        TransactionForm.Instance.BringToFront()
        TransactionForm.Instance.Visible = True
    End Sub

    Private Sub btnReports_Click(sender As Object, e As EventArgs) Handles btnReports.Click
        If Not Panel4.Controls.Contains(ReportForm.Instance) Then
            Panel4.Controls.Add(ReportForm.Instance)
            ReportForm.Instance.Dock = DockStyle.Fill
            ReportForm.Instance.BringToFront()
            ReportForm.Instance.Visible = True
        End If
        ReportForm.Instance.BringToFront()
        ReportForm.Instance.Visible = True
    End Sub

    Private Sub btnTrainer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrainer.Click
        If Not Panel4.Controls.Contains(TrainerForm.Instance) Then
            Panel4.Controls.Add(TrainerForm.Instance)
            TrainerForm.Instance.Dock = DockStyle.Fill
            TrainerForm.Instance.BringToFront()
            TrainerForm.Instance.Visible = True
        End If
        TrainerForm.Instance.BringToFront()
        TrainerForm.Instance.Visible = True
    End Sub

    Private Sub btnUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUser.Click
        If Not Panel4.Controls.Contains(UserForm.Instance) Then
            Panel4.Controls.Add(UserForm.Instance)
            UserForm.Instance.Dock = DockStyle.Fill
            UserForm.Instance.BringToFront()
            UserForm.Instance.Visible = True
        End If
        UserForm.Instance.BringToFront()
        UserForm.Instance.Visible = True
    End Sub

    Private Sub HomeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblUserName.Text = LoginForm.txtUserName.Text
    End Sub
End Class