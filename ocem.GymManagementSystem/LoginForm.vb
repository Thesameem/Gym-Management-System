Imports System.Data.SqlClient
Imports System.Data
Imports System.Text.RegularExpressions
Imports System.IO
Public Class LoginForm
    Dim rdr As SqlDataReader = Nothing
    Dim dtable As DataTable
    Dim con As SqlConnection = Nothing
    Dim adp As SqlDataAdapter
    Dim ds As DataSet
    Dim cmd As SqlCommand = Nothing
    Dim dt As New DataTable
    Dim mRegxExpression As Regex
    Private Sub LoginForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Application.Exit()
    End Sub

    Private Sub btnlogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click
        If Len(Trim(txtUserName.Text)) = 0 Then
            MessageBox.Show("Please enter user name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtUserName.Focus()
            Exit Sub
        End If
        If Len(Trim(txtPassword.Text)) = 0 Then
            MessageBox.Show("Please enter password", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPassword.Focus()
            Exit Sub
        End If
        Try
            Dim myConnection As SqlConnection
            myConnection = New SqlConnection(cs)
            Dim myCommand As SqlCommand
            myCommand = New SqlCommand("SELECT Username,Password FROM UserTable WHERE Username = @username AND Password = @UserPassword", myConnection)
            Dim uName As New SqlParameter("@username", SqlDbType.NChar)
            Dim uPassword As New SqlParameter("@UserPassword", SqlDbType.NChar)
            uName.Value = txtUserName.Text
            uPassword.Value = txtPassword.Text
            myCommand.Parameters.Add(uName)
            myCommand.Parameters.Add(uPassword)
            myCommand.Connection.Open()
            Dim myReader As SqlDataReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
            Dim Login As Object = 0
            If myReader.HasRows Then
                myReader.Read()
                Login = myReader(Login)
            End If
            If Login = Nothing Then
                MsgBox("Login is Failed...Try again !", MsgBoxStyle.Critical, "Login Denied")
                txtUserName.Clear()
                txtPassword.Clear()
                txtUserName.Focus()
            Else
                HomeForm.Show()
                txtPassword.Text = ""
                Me.Hide()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            txtPassword.UseSystemPasswordChar = False
        Else
            txtPassword.UseSystemPasswordChar = True
        End If
    End Sub
End Class