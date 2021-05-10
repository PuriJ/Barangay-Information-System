Imports MySql.Data.MySqlClient
Public Class Reports
    Dim strsql As String
    Dim ds As New DataSet
    Dim cmd As New MySqlCommand
    Dim dr As MySqlDataReader
    Dim adapt As New MySqlDataAdapter

    Private Sub List()
        'SHOW ITS DATA
        strsql = "SELECT Resident_No, Last_Name, First_Name, MI, Block_No, Address, DOB, POB, Sex, Age, Civil_Status, Occupation, Household, Status, Registered_Voters FROM tbl_residents"
        adapter = New MySqlDataAdapter(strsql, connect)
        ds = New DataSet()
        connect.Close()
        adapter.Fill(ds, "Emp")
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.ReadOnly = True
    End Sub


    Private Sub Report()
        connect.Open()
        cmd = New MySqlCommand(strsql, connect)
        adapt.SelectCommand = cmd
        adapt.Fill(ds, "tbl_residents")
        Dim rep As New brgResi
        rep.SetDataSource(ds)
        CrystalReportViewer1.ReportSource = rep
        CrystalReportViewer1.Refresh()
        CrystalReportViewer1.RefreshReport()
        cmd.Dispose()
        adapt.Dispose()
        ds.Dispose()
        connect.Close()

        'ACTIVITY LOG FOR PRINTING CLEARANCE
        connect.Open()
        cmd = connect.CreateCommand
        cmd.CommandText = "INSERT INTO tbl_logs(User_No, Last_Name, First_Name, User_Type, Time, Date, Activity) VALUES (@UserNo, @Last, @First, @Utype, @Time, @Date, @Act)"

        cmd.Parameters.AddWithValue("@UserNo", bdt.Rows(0).Item(0))
        cmd.Parameters.AddWithValue("@Last", bdt.Rows(0).Item(4))
        cmd.Parameters.AddWithValue("@First", bdt.Rows(0).Item(5))
        cmd.Parameters.AddWithValue("Utype", bdt.Rows(0).Item(3))
        cmd.Parameters.AddWithValue("@Time", DateTime.Now.ToLongTimeString)
        cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToShortDateString)
        cmd.Parameters.AddWithValue("@Act", "Printed Residents Report")
        cmd.ExecuteNonQuery()
        connect.Close()
    End Sub

    Private Sub DataGridView1_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles DataGridView1.DataBindingComplete
        'NOT AUTO SELECT SO YOU GONNA CLICK FROM DATA ROW FIRST
        DataGridView1.ClearSelection()
    End Sub

    Private Sub Reports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        List()
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        Report()
    End Sub
End Class