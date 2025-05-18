Imports System.Data.SqlClient
Imports System.Data
Imports System.Text.RegularExpressions
Imports System.Security.Cryptography

Public Class ReportForm

    Dim rdr As SqlDataReader = Nothing
    Dim adapter As SqlDataAdapter = Nothing
    Dim dtable As DataTable
    Dim con As SqlConnection = Nothing
    Dim adp As SqlDataAdapter
    Dim ds As DataSet
    Dim cmd As SqlCommand = Nothing
    Dim cmd1 As SqlCommand = Nothing
    Dim dt As New DataTable
    Dim mRegxExpression As Regex

    Private Shared _instance As ReportForm
    Public Shared ReadOnly Property Instance() As ReportForm
        Get
            If _instance Is Nothing Then
                _instance = New ReportForm()
            End If
            Return _instance
        End Get
    End Property
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Hide()
    End Sub

    Private Sub btnMFind_Click(sender As Object, e As EventArgs) Handles btnMFind.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT * From MemberTable WHERE DateOfJoining between @date1 and @date2 order by DateOfJoining", con)
            cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "DateOfJoining").Value = dtpMFrom.Value.Date
            cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "DateOfJoining").Value = dtpMTo.Value.Date
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "MemberTable")
            DataGridView1.DataSource = myDataSet.Tables("MemberTable").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnTFind_Click(sender As Object, e As EventArgs) Handles btnTFind.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT * From TransactionTable WHERE Date between @date1 and @date2 order by Date", con)
            cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = dtpTFrom.Value.Date
            cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = dtpTTo.Value.Date
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "TransactionTable")
            DataGridView1.DataSource = myDataSet.Tables("TransactionTable").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
