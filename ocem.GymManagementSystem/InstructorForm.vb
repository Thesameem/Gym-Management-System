Imports System.Data.SqlClient
Imports System.Data
Imports System.Text.RegularExpressions

Public Class InstructorForm
    Inherits UserControl
    Dim rdr As SqlDataReader = Nothing
    Dim dtable As DataTable
    Dim con As SqlConnection = Nothing
    Dim adp As SqlDataAdapter
    Dim ds As DataSet
    Dim cmd As SqlCommand = Nothing
    Dim dt As New DataTable
    Dim mRegxExpression As Regex

    Private Shared _instance As InstructorForm
    Public Shared ReadOnly Property Instance() As InstructorForm
        Get
            If _instance Is Nothing Then
                _instance = New InstructorForm()
            End If
            Return _instance
        End Get
    End Property
    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClose.Click
        DataGridView1.DataSource = GetData()
        btnDelete.Visible = False
        btnUpdate.Visible = False
        btnSave.Visible = True
        Clear()
        Me.Hide()
    End Sub

    Private Sub AutocompleteSuggest()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("SELECT TrainerId FROM TrainerTable", con)
            Dim ds As DataSet = New DataSet()
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            da.Fill(ds, "TrainerId")
            Dim col As AutoCompleteStringCollection = New AutoCompleteStringCollection()
            Dim i As Integer = 0
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("TrainerId").ToString())
            Next
            txtTrainerId.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtTrainerId.AutoCompleteCustomSource = col
            txtTrainerId.AutoCompleteMode = AutoCompleteMode.Suggest
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub InstructorForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = GetData()
        btnDelete.Visible = False
        btnUpdate.Visible = False
        btnSave.Visible = True
        AutocompleteSuggest()
        Clear()
    End Sub

    Sub Clear()
        lblID.Text = ""
        txtTrainerId.Text = ""
        txtTrainerName.Text = ""
        txtSalary.Text = ""
        CmbSchedule.Items.Clear()
        AutocompleteSuggest()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Len(Trim(txtTrainerId.Text)) = 0 Then
            MessageBox.Show("Please Enter Trainer ID", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTrainerId.Focus()
            Exit Sub
        End If
        If Len(Trim(txtTrainerName.Text)) = 0 Then
            MessageBox.Show("Please Enter TrainerName", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTrainerName.Focus()
            Exit Sub
        End If
        If Len(Trim(txtSalary.Text)) = 0 Then
            MessageBox.Show("Please Enter Salary", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtSalary.Focus()
            Exit Sub
        End If
        If Len(Trim(CmbSchedule.Text)) = 0 Then
            MessageBox.Show("Please Select Schedule", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            CmbSchedule.Focus()
            Exit Sub
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "SELECT TrainerId FROM InstructorTable WHERE TrainerId=@Find"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@Find", System.Data.SqlDbType.NVarChar, 12, "TrainerId"))
            cmd.Parameters("@Find").Value = txtTrainerId.Text
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Trainer Id Already Exists", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtTrainerId.Text = ""
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
            Else
                con = New SqlConnection(cs)
                con.Open()
                Dim cb As String = "INSERT INTO InstructorTable VALUES (@d1,@d2,@d3,@d4)"
                cmd = New SqlCommand(cb)
                cmd.Connection = con
                cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.NVarChar, 50, "TrainerId"))
                cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NVarChar, 50, "TrainerName"))
                cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.NVarChar, 50, "Schedule"))
                cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.NVarChar, 50, "Salary"))

                cmd.Parameters("@d1").Value = Trim(txtTrainerId.Text)
                cmd.Parameters("@d2").Value = Trim(txtTrainerName.Text)
                cmd.Parameters("@d3").Value = Trim(CmbSchedule.Text)
                cmd.Parameters("@d4").Value = Trim(txtSalary.Text)

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

    Private Sub txtTrainerId_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTrainerId.TextChanged
        Try
            txtTrainerId.Text = txtTrainerId.Text.TrimEnd()
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()

            cmd.CommandText = "SELECT TrainerName FROM TrainerTable WHERE TrainerId ='" & txtTrainerId.Text & "'"
            rdr = cmd.ExecuteReader()

            If rdr.Read() Then
                txtTrainerName.Text = (rdr.GetString(0).Trim())
            End If

            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If

            If con.State = ConnectionState.Open Then
                con.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private ReadOnly Property Connection() As SqlConnection
        Get
            Dim ConnectionToFetch As New SqlConnection(cs)
            ConnectionToFetch.Open()
            Return ConnectionToFetch
        End Get
    End Property

    Public Function GetData() As DataView
        Dim SelectQry = "SELECT * FROM InstructorTable ORDER BY Id"

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

    Private Sub DataGridView1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick
        Try
            Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
            txtTrainerId.Text = dr.Cells(1).Value.ToString()
            txtTrainerName.Text = dr.Cells(2).Value.ToString()
            CmbSchedule.Text = dr.Cells(3).Value.ToString()
            txtSalary.Text = dr.Cells(4).Value.ToString()
            btnUpdate.Visible = True
            btnDelete.Visible = True
            btnSave.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If Len(Trim(txtTrainerId.Text)) = 0 Then
            MessageBox.Show("Please Enter Trainer ID", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTrainerId.Focus()
            Exit Sub
        End If
        If Len(Trim(txtTrainerName.Text)) = 0 Then
            MessageBox.Show("Please Enter TrainerName", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTrainerName.Focus()
            Exit Sub
        End If
        If Len(Trim(txtSalary.Text)) = 0 Then
            MessageBox.Show("Please Enter Salary", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtSalary.Focus()
            Exit Sub
        End If
        If Len(Trim(CmbSchedule.Text)) = 0 Then
            MessageBox.Show("Please Select Schedule", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            CmbSchedule.Focus()
            Exit Sub
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "UPDATE InstructorTable SET TrainerName=@d2,Schedule=@d3,Salary=@d4 Where TrainerId=@d1"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.NVarChar, 50, "TrainerId"))
            cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NVarChar, 50, "TrainerName"))
            cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.NVarChar, 50, "Schedule"))
            cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.NVarChar, 50, "Salary"))

            cmd.Parameters("@d1").Value = Trim(txtTrainerId.Text)
            cmd.Parameters("@d2").Value = Trim(txtTrainerName.Text)
            cmd.Parameters("@d3").Value = Trim(CmbSchedule.Text)
            cmd.Parameters("@d4").Value = Trim(txtSalary.Text)
            cmd.ExecuteReader()
            MessageBox.Show("Successfully Updated.", "Instructor Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
                MessageBox.Show("Please select Trainer Id", "Instructor Details", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
            Dim cq As String = "DELETE FROM InstructorTable WHERE TrainerId=@DELETE1;"
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 30, "TrainerId"))
            cmd.Parameters("@DELETE1").Value = Trim(txtTrainerId.Text)
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                MessageBox.Show("Successfully deleted", "Instructor Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MsgBox("Sorry No Instructor Details Deleted")
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

    Private Sub CmbSchedule_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbSchedule.SelectedIndexChanged

    End Sub
End Class
