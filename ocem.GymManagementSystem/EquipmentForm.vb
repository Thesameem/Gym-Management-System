Imports System.Data.SqlClient
Imports System.Data
Imports System.Text.RegularExpressions

Public Class EquipmentForm
    Inherits UserControl
    Dim rdr As SqlDataReader = Nothing
    Dim dtable As DataTable
    Dim con As SqlConnection = Nothing
    Dim adp As SqlDataAdapter
    Dim ds As DataSet
    Dim cmd As SqlCommand = Nothing
    Dim dt As New DataTable
    Dim mRegxExpression As Regex

    Private Shared _instance As EquipmentForm
    Public Shared ReadOnly Property Instance() As EquipmentForm
        Get
            If _instance Is Nothing Then
                _instance = New EquipmentForm()
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

    Private Sub EquipmentForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = GetData()
        btnDelete.Visible = False
        btnUpdate.Visible = False
        btnSave.Visible = True
        Clear()
    End Sub

    Sub Clear()
        lblID.Text = ""
        txtCompany.Text = ""
        txtInstrument.Text = ""
        txtPrice.Text = ""
        txtTotalQuantity.Text = ""
        txtTotalPrice.Text = ""
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Len(Trim(txtInstrument.Text)) = 0 Then
            MessageBox.Show("Please Enter Instrument", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtInstrument.Focus()
            Exit Sub
        End If
        If Len(Trim(txtCompany.Text)) = 0 Then
            MessageBox.Show("Please Enter Company", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCompany.Focus()
            Exit Sub
        End If
        If Len(Trim(txtTotalQuantity.Text)) = 0 Then
            MessageBox.Show("Please Enter Total Quantity", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTotalQuantity.Focus()
            Exit Sub
        End If
        If Len(Trim(txtPrice.Text)) = 0 Then
            MessageBox.Show("Please Enter Price", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPrice.Focus()
            Exit Sub
        End If
        If Len(Trim(txtTotalPrice.Text)) = 0 Then
            MessageBox.Show("Please Enter Total Price", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTotalPrice.Focus()
            Exit Sub
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "SELECT Instrument FROM InstrumentTable WHERE Instrument=@Find"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@Find", System.Data.SqlDbType.NVarChar, 12, "Instrument"))
            cmd.Parameters("@Find").Value = txtInstrument.Text
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Instrument Already Exists", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtInstrument.Text = ""
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
            Else
                con = New SqlConnection(cs)
                con.Open()
                Dim cb As String = "INSERT INTO InstrumentTable VALUES (@d1,@d2,@d3,@d4,@d5,@d6)"
                cmd = New SqlCommand(cb)
                cmd.Connection = con
                cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.NVarChar, 50, "Instrument"))
                cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NVarChar, 50, "Company"))
                cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.NVarChar, 10, "TotalQuantity"))
                cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.NVarChar, 50, "Price"))
                cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.NVarChar, 50, "TotalPrice"))
                cmd.Parameters.Add(New SqlParameter("@d6", System.Data.SqlDbType.NVarChar, 50, "EnterDate"))

                cmd.Parameters("@d1").Value = Trim(txtInstrument.Text)
                cmd.Parameters("@d2").Value = Trim(txtCompany.Text)
                cmd.Parameters("@d3").Value = Trim(txtTotalQuantity.Text)
                cmd.Parameters("@d4").Value = Trim(txtPrice.Text)
                cmd.Parameters("@d5").Value = Trim(txtTotalPrice.Text)
                cmd.Parameters("@d6").Value = Trim(dtpDate.Text)

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
        Dim SelectQry = "SELECT * FROM InstrumentTable ORDER BY Id"

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
            txtInstrument.Text = dr.Cells(1).Value.ToString()
            txtCompany.Text = dr.Cells(2).Value.ToString()
            txtTotalQuantity.Text = dr.Cells(3).Value.ToString()
            txtPrice.Text = dr.Cells(4).Value.ToString()
            txtTotalPrice.Text = dr.Cells(5).Value.ToString()
            dtpDate.Text = dr.Cells(6).Value.ToString()
            btnUpdate.Visible = True
            btnDelete.Visible = True
            btnSave.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If Len(Trim(txtInstrument.Text)) = 0 Then
            MessageBox.Show("Please Enter Instrument", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtInstrument.Focus()
            Exit Sub
        End If
        If Len(Trim(txtCompany.Text)) = 0 Then
            MessageBox.Show("Please Enter Company", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCompany.Focus()
            Exit Sub
        End If
        If Len(Trim(txtTotalQuantity.Text)) = 0 Then
            MessageBox.Show("Please Enter Total Quantity", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTotalQuantity.Focus()
            Exit Sub
        End If
        If Len(Trim(txtPrice.Text)) = 0 Then
            MessageBox.Show("Please Enter Price", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPrice.Focus()
            Exit Sub
        End If
        If Len(Trim(txtTotalPrice.Text)) = 0 Then
            MessageBox.Show("Please Enter Total Price", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTotalPrice.Focus()
            Exit Sub
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "UPDATE InstrumentTable SET Instrument=@d2,Company=@d3,TotalQuantity=@d4,Price=@d5,TotalPrice=@d6,EnterDate=@d7 Where Id=@d1"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.NVarChar, 50, "Id"))
            cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.NVarChar, 50, "Instrument"))
            cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.NVarChar, 50, "Company"))
            cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.NVarChar, 10, "TotalQuantity"))
            cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.NVarChar, 50, "Price"))
            cmd.Parameters.Add(New SqlParameter("@d6", System.Data.SqlDbType.NVarChar, 50, "TotalPrice"))
            cmd.Parameters.Add(New SqlParameter("@d7", System.Data.SqlDbType.NVarChar, 50, "EnterDate"))

            cmd.Parameters("@d1").Value = Trim(lblID.Text)
            cmd.Parameters("@d2").Value = Trim(txtInstrument.Text)
            cmd.Parameters("@d3").Value = Trim(txtCompany.Text)
            cmd.Parameters("@d4").Value = Trim(txtTotalQuantity.Text)
            cmd.Parameters("@d5").Value = Trim(txtPrice.Text)
            cmd.Parameters("@d6").Value = Trim(txtTotalPrice.Text)
            cmd.Parameters("@d7").Value = Trim(dtpDate.Text)
            cmd.ExecuteReader()
            MessageBox.Show("Successfully Updated.", "Instrument Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
                MessageBox.Show("Please select Instrument", "Instrument Details", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
            Dim cq As String = "DELETE FROM InstrumentTable WHERE Id=@DELETE1;"
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 30, "Id"))
            cmd.Parameters("@DELETE1").Value = Trim(lblID.Text)
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                MessageBox.Show("Successfully deleted", "Instrument Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MsgBox("Sorry No Instrument Details Deleted")
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

    Private Sub txtPrice_TextChanged(sender As Object, e As EventArgs) Handles txtPrice.TextChanged
        txtTotalPrice.Text = CInt(Val(txtPrice.Text) * Val(txtTotalQuantity.Text))
    End Sub
End Class
