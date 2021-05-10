Imports MySql.Data.MySqlClient
Public Class Residency
    Dim strsql As String
    Dim cmd As New MySqlCommand
    Dim cmd2 As New MySqlCommand
    Dim adapt As New MySqlDataAdapter

    Private Sub txtClear()
        txtLast.Text = ""
        txtFirst.Text = ""
        txtMid.Text = ""
    End Sub

    Private Sub List()
        'SHOW ITS DATA
        strsql = "SELECT Resident_No, Last_Name, First_Name, MI, Block_No, Address, DOB, POB, Sex, Age, Civil_Status, Occupation, Household, Status, Registered_Voters, Remarks FROM tbl_residents"
        adapter = New MySqlDataAdapter(strsql, connect)
        ds = New DataSet()
        connect.Close()
        adapter.Fill(ds, "Emp")
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.ReadOnly = True

    End Sub

    Private Sub Report()
        'PREVIEW THE PRINTING CERTIFICATE FORM
        Dim row As DataGridViewRow = DataGridView1.CurrentRow
        strsql = "SELECT * FROM tbl_residents WHERE Last_Name = '" & txtLast.Text & "'"
        Try
            If DataGridView1.SelectedRows.Count = False Then
                txtClear()
                MessageBox.Show("Click a Data First", "", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ElseIf row.Cells(15).Value.ToString = "Theft" Or row.Cells(15).Value.ToString = "Snatching" Or row.Cells(15).Value.ToString = "Hold Up" Or row.Cells(15).Value.ToString = "Drug User" Or row.Cells(15).Value.ToString = "Drug Pusher" Or row.Cells(15).Value.ToString = "Attempt Murder" Or row.Cells(15).Value.ToString = "Murder" Or row.Cells(15).Value.ToString = "Carnapping" Then
                txtClear()
                MessageBox.Show("This record has a remark and not qualified to get a certificate.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Else
                connect.Open()
                cmd = New MySqlCommand(strsql, connect)
                adapt.SelectCommand = cmd
                adapt.Fill(ds, "tbl_residents")
                Dim rep As New bResidency
                rep.SetDataSource(ds)
                CrystalReportViewer1.ReportSource = rep
                CrystalReportViewer1.Refresh()
                CrystalReportViewer1.RefreshReport()
                cmd.Dispose()
                adapt.Dispose()
                ds.Dispose()
                connect.Close()


                'ACTIVITY LOG FOR PRINTING INDIGENCY
                connect.Open()
                cmd = connect.CreateCommand
                cmd.CommandText = "INSERT INTO tbl_logs(User_No, Last_Name, First_Name, User_Type, Time, Date, Activity) VALUES (@UserNo, @Last, @First, @Utype, @Time, @Date, @Act)"

                cmd.Parameters.AddWithValue("@UserNo", bdt.Rows(0).Item(0))
                cmd.Parameters.AddWithValue("@Last", bdt.Rows(0).Item(4))
                cmd.Parameters.AddWithValue("@First", bdt.Rows(0).Item(5))
                cmd.Parameters.AddWithValue("Utype", bdt.Rows(0).Item(3))
                cmd.Parameters.AddWithValue("@Time", DateTime.Now.ToLongTimeString)
                cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToShortDateString)
                cmd.Parameters.AddWithValue("@Act", "Printed Residency")
                cmd.ExecuteNonQuery()
                connect.Close()

            End If


        Catch ex As Exception

        End Try


    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'SELECTING DATA FROM DATAGRIDVIEW AND GOES THE TEXT DATA IN THE TEXTBOX
        Dim row As DataGridViewRow = DataGridView1.CurrentRow

        Try
            Dim Last As String = row.Cells(1).Value.ToString
            Dim First As String = row.Cells(2).Value.ToString
            Dim MI As String = row.Cells(3).Value.ToString

            txtLast.Text = Last
            txtFirst.Text = First
            txtMid.Text = MI
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Search()
        'SEARCH BY LAST NAME ONLY
        Dim ds As New DataSet
        Dim ada As MySqlDataAdapter

        Try
            connect.Open()
            ada = New MySqlDataAdapter("SELECT * FROM tbl_residents WHERE Last_Name LIKE '%" & txtSearch.Text & "%'", connect)
            ada.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
            connect.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        Report()
        List()
    End Sub

    Private Sub Residency_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        List()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Search()
    End Sub

    Private Sub DataGridView1_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles DataGridView1.DataBindingComplete
        'NOT AUTO SELECT SO YOU GONNA CLICK FROM DATA ROW FIRST
        DataGridView1.ClearSelection()
    End Sub

    Private Sub txtSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearch.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            If Not ((Asc(e.KeyChar) >= 97 And Asc(e.KeyChar) <= 122) Or (Asc(e.KeyChar) >= 65 And Asc(e.KeyChar) <= 90) Or (Asc(e.KeyChar) = Keys.Space)) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub
End Class