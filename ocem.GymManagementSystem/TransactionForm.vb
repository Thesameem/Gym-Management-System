Imports System.Data.SqlClient
Imports System.Data
Imports System.Text.RegularExpressions

Public Class TransactionForm
    Inherits UserControl
    Dim rdr As SqlDataReader = Nothing
    Dim dtable As DataTable
    Dim con As SqlConnection = Nothing
    Dim adp As SqlDataAdapter
    Dim ds As DataSet
    Dim cmd As SqlCommand = Nothing
    Dim dt As New DataTable
    Dim mRegxExpression As Regex

    Private Shared _instance As TransactionForm
    Public Shared ReadOnly Property Instance() As TransactionForm
        Get
            If _instance Is Nothing Then
                _instance = New TransactionForm()
            End If
            Return _instance
        End Get
    End Property
    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClose.Click
        DataGridView1.DataSource = GetData()
        Clear()
        Me.Hide()
    End Sub

    Private Sub AutocompleteSuggest()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("SELECT Id FROM MemberTable", con)
            Dim ds As DataSet = New DataSet()
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            da.Fill(ds, "Id")
            Dim col As AutoCompleteStringCollection = New AutoCompleteStringCollection()
            Dim i As Integer = 0
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("Id").ToString())
            Next
            txtMemberID.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtMemberID.AutoCompleteCustomSource = col
            txtMemberID.AutoCompleteMode = AutoCompleteMode.Suggest
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub TransactionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = GetData()
        AutocompleteSuggest()
        Clear()
    End Sub

    Sub Clear()
        txtMemberID.Text = ""
        txtAmount.Text = ""
        txtName.Text = ""
        txtPayAmount.Text = ""
        txtPlanType.Text = ""
        dtpDOJ.Text = Today.Date.ToString()
        AutocompleteSuggest()
    End Sub

    Private Sub btnPay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPay.Click
        If Len(Trim(txtMemberID.Text)) = 0 Then
            MessageBox.Show("Please Enter Member ID", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtMemberID.Focus()
            Exit Sub
        End If
        If Len(Trim(txtAmount.Text)) = 0 Then
            MessageBox.Show("Please Enter Amount", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtAmount.Focus()
            Exit Sub
        End If
        If Len(Trim(txtName.Text)) = 0 Then
            MessageBox.Show("Please Enter Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtName.Focus()
            Exit Sub
        End If
        If Len(Trim(txtPayAmount.Text)) = 0 Then
            MessageBox.Show("Please Select PayAmount", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPayAmount.Focus()
            Exit Sub
        End If
        If Len(Trim(txtPlanType.Text)) = 0 Then
            MessageBox.Show("Please Select PlanType", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPlanType.Focus()
            Exit Sub
        End If
        Try
                con = New SqlConnection(cs)
                con.Open()
            Dim cb As String = "INSERT INTO TransactionTable VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7)"
                cmd = New SqlCommand(cb)
                cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.NVarChar, 50, "MemberId"))
            cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NVarChar, 50, "Name"))
            cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.NVarChar, 50, "PlanType"))
            cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.NVarChar, 50, "DateOfJoining"))
            cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.NVarChar, 50, "Amount"))
            cmd.Parameters.Add(New SqlParameter("@d6", System.Data.SqlDbType.NVarChar, 50, "PayAmount"))
            cmd.Parameters.Add(New SqlParameter("@d7", System.Data.SqlDbType.NVarChar, 50, "Date"))
            cmd.Parameters("@d1").Value = Trim(txtMemberID.Text)
            cmd.Parameters("@d2").Value = Trim(txtName.Text)
            cmd.Parameters("@d3").Value = Trim(txtPlanType.Text)
            cmd.Parameters("@d4").Value = Trim(dtpDOJ.Text)
            cmd.Parameters("@d5").Value = Trim(txtAmount.Text)
            cmd.Parameters("@d6").Value = Trim(txtPayAmount.Text)
            cmd.Parameters("@d7").Value = Trim(dtpdate.Text)

                cmd.ExecuteReader()
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con = New SqlConnection(cs)
                con.Open()
                Clear()
                DataGridView1.DataSource = GetData()
                con.Close()
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
        Dim SelectQry = "SELECT * FROM TransactionTable ORDER BY Id"

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

    Private Sub txtMemberID_TextChanged(sender As Object, e As EventArgs) Handles txtMemberID.TextChanged
        Try
            txtMemberID.Text = txtMemberID.Text.TrimEnd()
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()

            cmd.CommandText = "SELECT FirstName,PlanType,DateOfJoining,Amount FROM MemberTable WHERE Id ='" & txtMemberID.Text & "'"
            rdr = cmd.ExecuteReader()

            If rdr.Read() Then
                txtName.Text = (rdr.GetString(0).Trim())
                txtPlanType.Text = (rdr.GetString(1).Trim())
                dtpDOJ.Text = (rdr.GetValue(2).ToString())
                txtAmount.Text = (rdr.GetString(3).Trim())
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
End Class
