Imports MySql.Data.MySqlClient
Public Class bPermits
    Dim strsql As String
    Dim cmd As New MySqlCommand
    Dim adapt As New MySqlDataAdapter

    Private Sub List()
        'SHOW ITS DATA
        strsql = "SELECT Resident_No, Last_Name, First_Name, MI, Block_No, Address, DOB, POB, Sex, Age, Civil_Status, Occupation, Household, Status, Registered_Voters, Business_Name, Budget_Price, Contact_No, Remarks FROM tbl_residents"
        adapter = New MySqlDataAdapter(strsql, connect)
        ds = New DataSet()
        connect.Close()
        adapter.Fill(ds, "Emp")
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.ReadOnly = True
    End Sub

    Private Sub txtClear()
        'CLEARING CONTENTS ON ITS TEXTBOXES
        txtLast.Text = ""
        txtFirst.Text = ""
        txtMid.Text = ""
        txtBusiness.Text = ""
        txtContact.Text = ""
        txtPrice.Text = ""
    End Sub

    Private Sub Report()
        'PREVIEW THE PRINTING CERTIFICATE FORM
        Dim row As DataGridViewRow = DataGridView1.CurrentRow
        strsql = "SELECT * FROM tbl_residents WHERE Last_Name = '" & txtLast.Text & "'"
        Try
            If DataGridView1.SelectedRows.Count = False Then
                txtClear()
                MessageBox.Show("Click a Data First", "", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ElseIf row.Cells(18).Value.ToString = "Theft" Or row.Cells(18).Value.ToString = "Snatching" Or row.Cells(18).Value.ToString = "Hold Up" Or row.Cells(18).Value.ToString = "Drug User" Or row.Cells(18).Value.ToString = "Drug Pusher" Or row.Cells(18).Value.ToString = "Attempt Murder" Or row.Cells(18).Value.ToString = "Murder" Or row.Cells(18).Value.ToString = "Carnapping" Then
                txtClear()
                MessageBox.Show("This record has a remark and not qualified to get a certificate.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Else
                connect.Open()
                cmd = New MySqlCommand(strsql, connect)
                adapt.SelectCommand = cmd
                adapt.Fill(ds, "tbl_residents")
                Dim rep As New brgyPermit
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
                cmd.Parameters.AddWithValue("@Act", "Printed Permit")
                cmd.ExecuteNonQuery()
                connect.Close()

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub UpdateReq()
        'ADD REQUIREMENTS LIKE PERMIT 
        If DataGridView1.SelectedCells.Count = 0 Then
            MessageBox.Show("Select an record first.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        ElseIf MessageBox.Show("Update this Requirement?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            strsql = "UPDATE tbl_residents SET Business_Name = '" & txtBusiness.Text & "', Budget_Price = '" & txtPrice.Text & "', Contact_No = '" & txtContact.Text & "', Designation = '" & txtDesign.Text & "' WHERE Last_Name = '" & txtLast.Text & "'"
            cmd = New MySqlCommand(strsql, connect)

            Try
                connect.Open()
                adapter.UpdateCommand = connect.CreateCommand()
                adapter.UpdateCommand.CommandText = strsql

                If adapter.UpdateCommand.ExecuteNonQuery() > 0 Then
                    txtClear()
                    List()
                    MessageBox.Show("Business Permit Requirement Updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    'ACTIVITY LOG FOR UPDATING REQUIREMENT
                    connect.Open()
                    cmd = connect.CreateCommand
                    cmd.CommandText = "INSERT INTO tbl_logs(User_No, Last_Name, First_Name, User_Type, Time, Date, Activity) VALUES (@UserNo, @Last, @First, @Utype, @Time, @Date, @Act)"

                    cmd.Parameters.AddWithValue("@UserNo", bdt.Rows(0).Item(0))
                    cmd.Parameters.AddWithValue("@Last", bdt.Rows(0).Item(4))
                    cmd.Parameters.AddWithValue("@First", bdt.Rows(0).Item(5))
                    cmd.Parameters.AddWithValue("Utype", bdt.Rows(0).Item(3))
                    cmd.Parameters.AddWithValue("@Time", DateTime.Now.ToLongTimeString)
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToShortDateString)
                    cmd.Parameters.AddWithValue("@Act", "Updated Permit")
                    cmd.ExecuteNonQuery()
                    connect.Close()

                Else
                    txtClear()
                    List()
                    MessageBox.Show("Record did not update", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                connect.Close()


            Catch ex As Exception

            End Try

        End If
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

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'SELECTING DATA FROM DATAGRIDVIEW AND GOES THE TEXT DATA IN THE TEXTBOX
        Dim row As DataGridViewRow = DataGridView1.CurrentRow
        Try
            Dim Last As String = row.Cells(1).Value.ToString
            Dim First As String = row.Cells(2).Value.ToString
            Dim MI As String = row.Cells(3).Value.ToString
            Dim bName As String = row.Cells(15).Value.ToString
            Dim bPrice As String = row.Cells(16).Value.ToString
            Dim Contact As String = row.Cells(17).Value.ToString

            txtLast.Text = Last
            txtFirst.Text = First
            txtMid.Text = MI
            txtBusiness.Text = bName
            txtPrice.Text = bPrice
            txtContact.Text = Contact

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridView1_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles DataGridView1.DataBindingComplete
        'NOT AUTO SELECT SO YOU GONNA CLICK FROM DATA ROW FIRST
        DataGridView1.ClearSelection()
    End Sub

    Private Sub bPermit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        List()
    End Sub

    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        Report()
        List()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Search()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        UpdateReq()
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        'UNABLE TO CLICK BUTTONS IF THE DATA IS NOT SELECTED
        If DataGridView1.SelectedRows.Count = True Then
            btnUpdate.Enabled = (DataGridView1.SelectedRows.Count > 0)
        Else
            btnUpdate.Enabled = (DataGridView1.SelectedRows.Count > 0)
        End If
    End Sub

    Private Sub txtBusiness_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBusiness.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            If Not ((Asc(e.KeyChar) >= 97 And Asc(e.KeyChar) <= 122) Or (Asc(e.KeyChar) >= 65 And Asc(e.KeyChar) <= 90) Or (Asc(e.KeyChar) = Keys.Space)) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtDesign_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDesign.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            If Not ((Asc(e.KeyChar) >= 97 And Asc(e.KeyChar) <= 122) Or (Asc(e.KeyChar) >= 65 And Asc(e.KeyChar) <= 90) Or (Asc(e.KeyChar) = Keys.Space)) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtContact_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContact.KeyPress
        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Then
            e.Handled = False

        Else
            e.Handled = True
            MessageBox.Show("Numbers keyword only.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub txtPrice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrice.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            If Not ((Asc(e.KeyChar) >= 97 And Asc(e.KeyChar) <= 122) Or (Asc(e.KeyChar) >= 65 And Asc(e.KeyChar) <= 90) Or (Asc(e.KeyChar) = Keys.Space)) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
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