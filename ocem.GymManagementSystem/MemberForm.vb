Imports System.Data.SqlClient
Imports System.Data
Imports System.Text.RegularExpressions

Public Class MemberForm
    Inherits UserControl
    Dim rdr As SqlDataReader = Nothing
    Dim dtable As DataTable
    Dim con As SqlConnection = Nothing
    Dim adp As SqlDataAdapter
    Dim ds As DataSet
    Dim cmd As SqlCommand = Nothing
    Dim dt As New DataTable
    Dim mRegxExpression As Regex

    Private Shared _instance As MemberForm
    Public Shared ReadOnly Property Instance() As MemberForm
        Get
            If _instance Is Nothing Then
                _instance = New MemberForm()
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
        fillPlantype()
        Me.Hide()
    End Sub

    Sub fillPlantype()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(PlanType) FROM PlanTypeTable", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            CmbPlanType.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                CmbPlanType.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub MemberForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = GetData()
        btnDelete.Visible = False
        btnUpdate.Visible = False
        btnSave.Visible = True
        Clear()
        fillPlantype()
    End Sub

    Private Sub CmbPlanType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbPlanType.SelectedIndexChanged
        Try
            CmbPlanType.Text = CmbPlanType.Text.TrimEnd()
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT Amount FROM PlanTypeTable WHERE PlanType ='" & CmbPlanType.Text & "'"
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtAmount.Text = (rdr.GetValue(0).ToString())
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Sub Clear()
        lblID.Text = ""
        txtAddress.Text = ""
        txtAmount.Text = ""
        txtContactNo.Text = ""
        txtFirstName.Text = ""
        txtLastName.Text = ""
        CmbPlanType.Text = ""
    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Len(Trim(txtFirstName.Text)) = 0 Then
            MessageBox.Show("Please Enter First Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtFirstName.Focus()
            Exit Sub
        End If
        If Len(Trim(txtLastName.Text)) = 0 Then
            MessageBox.Show("Please Enter Last Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtLastName.Focus()
            Exit Sub
        End If
        If Len(Trim(txtContactNo.Text)) = 0 Then
            MessageBox.Show("Please Enter Contact No", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtContactNo.Focus()
            Exit Sub
        End If
        If Len(Trim(CmbPlanType.Text)) = 0 Then
            MessageBox.Show("Please Enter Plan Type", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            CmbPlanType.Focus()
            Exit Sub
        End If
        If Len(Trim(txtAmount.Text)) = 0 Then
            MessageBox.Show("Please Enter Ammount", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtAmount.Focus()
            Exit Sub
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "SELECT ContactNo FROM MemberTable WHERE ContactNo=@Find"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@Find", System.Data.SqlDbType.NVarChar, 12, "ContactNo"))
            cmd.Parameters("@Find").Value = txtContactNo.Text
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Member Already Exists", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtContactNo.Text = ""
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
            Else
                con = New SqlConnection(cs)
                con.Open()
                Dim cb As String = "INSERT INTO MemberTable VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7)"
                cmd = New SqlCommand(cb)
                cmd.Connection = con
                cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.NVarChar, 50, "FirstName"))
                cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NVarChar, 50, "LastName"))
                cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.NVarChar, 10, "ContactNo"))
                cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.NVarChar, 500, "PlanType"))
                cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.NVarChar, 50, "DateOfJoining"))
                cmd.Parameters.Add(New SqlParameter("@d6", System.Data.SqlDbType.NVarChar, 10, "Amount"))
                cmd.Parameters.Add(New SqlParameter("@d7", System.Data.SqlDbType.NVarChar, 500, "Address"))

                cmd.Parameters("@d1").Value = Trim(txtFirstName.Text)
                cmd.Parameters("@d2").Value = Trim(txtLastName.Text)
                cmd.Parameters("@d3").Value = Trim(txtContactNo.Text)
                cmd.Parameters("@d4").Value = Trim(CmbPlanType.Text)
                cmd.Parameters("@d5").Value = Trim(dtpDOJ.Text)
                cmd.Parameters("@d6").Value = Trim(txtAmount.Text)
                cmd.Parameters("@d7").Value = Trim(txtAddress.Text)

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

    Private ReadOnly Property Connection() As SqlConnection
        Get
            Dim ConnectionToFetch As New SqlConnection(cs)
            ConnectionToFetch.Open()
            Return ConnectionToFetch
        End Get
    End Property

    Public Function GetData() As DataView
        Dim SelectQry = "SELECT * FROM MemberTable ORDER BY Id"

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
            lblID.Text = dr.Cells(0).Value.ToString()
            txtFirstName.Text = dr.Cells(1).Value.ToString()
            txtLastName.Text = dr.Cells(2).Value.ToString()
            txtContactNo.Text = dr.Cells(3).Value.ToString()
            CmbPlanType.Text = dr.Cells(4).Value.ToString()
            dtpDOJ.Text = dr.Cells(5).Value.ToString()
            txtAmount.Text = dr.Cells(6).Value.ToString()
            txtAddress.Text = dr.Cells(7).Value.ToString()
            btnUpdate.Visible = True
            btnDelete.Visible = True
            btnSave.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If Len(Trim(txtFirstName.Text)) = 0 Then
            MessageBox.Show("Please Enter First Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtFirstName.Focus()
            Exit Sub
        End If
        If Len(Trim(txtLastName.Text)) = 0 Then
            MessageBox.Show("Please Enter Last Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtLastName.Focus()
            Exit Sub
        End If
        If Len(Trim(txtContactNo.Text)) = 0 Then
            MessageBox.Show("Please Enter Contact No", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtContactNo.Focus()
            Exit Sub
        End If
        If Len(Trim(CmbPlanType.Text)) = 0 Then
            MessageBox.Show("Please Enter Plan Type", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            CmbPlanType.Focus()
            Exit Sub
        End If
        If Len(Trim(txtAmount.Text)) = 0 Then
            MessageBox.Show("Please Enter Ammount", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtAmount.Focus()
            Exit Sub
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "UPDATE MemberTable SET FirstName=@d2,LastName=@d3,ContactNo=@d4,PlanType=@d5,DateOfJoining=@d6,Amount=@d7,Address=@d8 Where Id=@d1"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.NVarChar, 50, "Id"))
            cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NVarChar, 50, "FirstName"))
            cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.NVarChar, 50, "LastName"))
            cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.NVarChar, 10, "ContactNo"))
            cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.NVarChar, 500, "PlanType"))
            cmd.Parameters.Add(New SqlParameter("@d6", System.Data.SqlDbType.NVarChar, 50, "DateOfJoining"))
            cmd.Parameters.Add(New SqlParameter("@d7", System.Data.SqlDbType.NVarChar, 10, "Amount"))
            cmd.Parameters.Add(New SqlParameter("@d8", System.Data.SqlDbType.NVarChar, 500, "Address"))

            cmd.Parameters("@d1").Value = Trim(lblID.Text)
            cmd.Parameters("@d2").Value = Trim(txtFirstName.Text)
            cmd.Parameters("@d3").Value = Trim(txtLastName.Text)
            cmd.Parameters("@d4").Value = Trim(txtContactNo.Text)
            cmd.Parameters("@d5").Value = Trim(CmbPlanType.Text)
            cmd.Parameters("@d6").Value = Trim(dtpDOJ.Text)
            cmd.Parameters("@d7").Value = Trim(txtAmount.Text)
            cmd.Parameters("@d8").Value = Trim(txtAddress.Text)
            cmd.ExecuteReader()
            MessageBox.Show("Successfully Updated.", "Member Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            If lblID.Text = "" Then
                MessageBox.Show("Please select Member", "Member Details", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
            Dim cq As String = "DELETE FROM MemberTable WHERE Id=@DELETE1;"
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 30, "Id"))
            cmd.Parameters("@DELETE1").Value = Trim(lblID.Text)
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                MessageBox.Show("Successfully deleted", "Member Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MsgBox("Sorry No Member Details Deleted")
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
End Class
