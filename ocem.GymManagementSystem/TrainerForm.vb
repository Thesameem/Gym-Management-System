Imports System.Data.SqlClient
Imports System.Data
Imports System.Text.RegularExpressions

Public Class TrainerForm

    Inherits UserControl
    Dim rdr As SqlDataReader = Nothing
    Dim dtable As DataTable
    Dim con As SqlConnection = Nothing
    Dim adp As SqlDataAdapter
    Dim ds As DataSet
    Dim cmd As SqlCommand = Nothing
    Dim dt As New DataTable
    Dim mRegxExpression As Regex

    Private Shared _instance As TrainerForm
    Public Shared ReadOnly Property Instance() As TrainerForm
        Get
            If _instance Is Nothing Then
                _instance = New TrainerForm()
            End If
            Return _instance
        End Get
    End Property

    Private Sub AutoIdGeneration()
        Dim Num As Integer = 0
        con = New SqlConnection(cs)
        con.Open()
        Dim sql As String = "SELECT Max(Id+1) FROM TrainerTable"
        cmd = New SqlCommand(sql)
        cmd.Connection = con
        If Convert.IsDBNull(cmd.ExecuteScalar()) Then
            Num = 1
            lblTrainerId.Text = Convert.ToString(Num)
            txtTrainerId.Text = Convert.ToString("T-" & Num)
        Else
            Num = CInt((cmd.ExecuteScalar()))
            lblTrainerId.Text = Convert.ToString(Num)
            txtTrainerId.Text = Convert.ToString("T-" & Num)
        End If
        cmd.Dispose()
        con.Close()
        con.Dispose()
    End Sub

    Sub Clear()
        txtAddress.Text = ""
        txtMobileNo.Text = ""
        txtTrainerName.Text = ""
        txtTrainerId.Text = ""
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Len(Trim(txtTrainerName.Text)) = 0 Then
            MessageBox.Show("Please Enter Trainer Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTrainerName.Focus()
            Exit Sub
        End If
        If Len(Trim(txtAddress.Text)) = 0 Then
            MessageBox.Show("Please Enter Address", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtAddress.Focus()
            Exit Sub
        End If
        If Len(Trim(txtMobileNo.Text)) = 0 Then
            MessageBox.Show("Please Enter Mobile Number", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtMobileNo.Focus()
            Exit Sub
        End If
        If txtMobileNo.Text.Length > 10 Then
            MessageBox.Show("Please Enter Valid Mobile Number!!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtMobileNo.Focus()
            Exit Sub
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "SELECT MobileNo FROM TrainerTable WHERE MobileNo=@Find"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@Find", System.Data.SqlDbType.NVarChar, 12, "MobileNo"))
            cmd.Parameters("@Find").Value = txtMobileNo.Text
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Mobile Nubmer Already Exists", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtMobileNo.Text = ""
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
            Else
                AutoIdGeneration()
                con = New SqlConnection(cs)
                con.Open()
                Dim cb As String = "INSERT INTO TrainerTable VALUES (@d1,@d2,@d3,@d4)"
                cmd = New SqlCommand(cb)
                cmd.Connection = con
                cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.NVarChar, 50, "TrainerId"))
                cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NVarChar, 50, "TrainerName"))
                cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.NVarChar, 10, "MobileNo"))
                cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.NVarChar, 500, "Address"))
               
                cmd.Parameters("@d1").Value = Trim(txtTrainerId.Text)
                cmd.Parameters("@d2").Value = Trim(txtTrainerName.Text)
                cmd.Parameters("@d3").Value = Trim(txtMobileNo.Text)
                cmd.Parameters("@d4").Value = Trim(txtAddress.Text)

                cmd.ExecuteReader()
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con = New SqlConnection(cs)
                con.Open()
                Clear()
                btnDelete.Visible = True
                btnUpdate.Visible = True
                DataGridView1.DataSource = GetData()
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtMobileNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMobileNo.KeyPress
        If Not (Char.IsDigit(e.KeyChar) OrElse (e.KeyChar = CChar(ChrW(Keys.Back)))) Then e.Handled = True
    End Sub

    Private ReadOnly Property Connection() As SqlConnection
        Get
            Dim ConnectionToFetch As New SqlConnection(cs)
            ConnectionToFetch.Open()
            Return ConnectionToFetch
        End Get
    End Property

    Public Function GetData() As DataView
        Dim SelectQry = "SELECT * FROM TrainerTable ORDER BY TrainerId"

        Dim SampleSource As New DataSet
        Dim TableView As DataView
        Try
            Dim SampleCommand As New SqlCommand()
            Dim SampleDataAdapter = New SqlDataAdapter()
            SampleCommand.CommandText = SelectQry
            SampleCommand.Connection = Connection
            SampleDataAdapter.SelectCommand = SampleCommand
            SampleDataAdapter.Fill(SampleSource)
            TableView = SampleSource.Tables(0).DefaultView
        Catch ex As Exception
            Throw ex
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return TableView
    End Function

    Private Sub TrainerForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = GetData()
        btnDelete.Visible = False
        btnUpdate.Visible = False
        btnSave.Visible = True
        Clear()
        AutoIdGeneration()
    End Sub

    Private Sub DataGridView1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick
        Try
            Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
            txtTrainerId.Text = dr.Cells(1).Value.ToString()
            txtTrainerName.Text = dr.Cells(2).Value.ToString()
            txtMobileNo.Text = dr.Cells(3).Value.ToString()
            txtAddress.Text = dr.Cells(4).Value.ToString()
            btnUpdate.Visible = True
            btnDelete.Visible = True
            btnSave.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If Len(Trim(txtTrainerName.Text)) = 0 Then
            MessageBox.Show("Please Enter Trainer Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTrainerName.Focus()
            Exit Sub
        End If
        If Len(Trim(txtAddress.Text)) = 0 Then
            MessageBox.Show("Please Enter Address", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtAddress.Focus()
            Exit Sub
        End If
        If Len(Trim(txtMobileNo.Text)) = 0 Then
            MessageBox.Show("Please Enter Mobile Number", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtMobileNo.Focus()
            Exit Sub
        End If
        If txtMobileNo.Text.Length > 10 Then
            MessageBox.Show("Please Enter Valid Mobile Number!!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtMobileNo.Focus()
            Exit Sub
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "UPDATE TrainerTable SET TrainerName=@d2,MobileNo=@d3,Address=@d4 Where TrainerId=@d1"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.NVarChar, 50, "TrainerId"))
            cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NVarChar, 50, "TrainerName"))
            cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.NVarChar, 10, "MobileNo"))
            cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.NVarChar, 500, "Address"))

            cmd.Parameters("@d1").Value = Trim(txtTrainerId.Text)
            cmd.Parameters("@d2").Value = Trim(txtTrainerName.Text)
            cmd.Parameters("@d3").Value = Trim(txtMobileNo.Text)
            cmd.Parameters("@d4").Value = Trim(txtAddress.Text)
            cmd.ExecuteReader()
            MessageBox.Show("Successfully Updated.", "Trainer Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Close()
            Clear()
            btnDelete.Visible = False
            btnUpdate.Visible = False
            btnSave.Visible = True
            DataGridView1.DataSource = GetData()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If txtTrainerId.Text = "" Then
                MessageBox.Show("Please select Trainer Id", "Trainer Details", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If MsgBox("Do you really want to delete this details?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                DeleteData()
                btnUpdate.Visible = False
                btnDelete.Visible = False
                btnSave.Enabled = True
                Clear()
                DataGridView1.DataSource = GetData()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DeleteData()
        Try
            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "DELETE FROM TrainerTable WHERE TrainerId=@DELETE1;"
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 30, "TrainerIds"))
            cmd.Parameters("@DELETE1").Value = Trim(txtTrainerId.Text)
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                MessageBox.Show("Successfully deleted", "Trainer Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MsgBox("Sorry No Trainer Details Deleted")
                Clear()
                cmd.ExecuteReader()
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Close()
            End If
            Clear()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        DataGridView1.DataSource = GetData()
        btnDelete.Visible = False
        btnUpdate.Visible = False
        btnSave.Visible = True
        Clear()
        AutoIdGeneration()
        Me.Hide()
    End Sub
End Class
