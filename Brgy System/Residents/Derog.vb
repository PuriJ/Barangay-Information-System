Imports MySql.Data.MySqlClient
Public Class Derog
    Dim strsql As String
    Dim ds As New DataSet
    Dim cmd As New MySqlCommand
    Dim dr As MySqlDataReader

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

    Private Sub txtClear()
        'CLEARING TEXT CONTENTS ON ITS TEXTBOXES
        txtLast.Text = ""
        txtFirst.Text = ""
        txtMid.Text = ""
        txtBlock.Text = ""
        cbAddress.SelectedItem = Nothing
        dtpDOB.Value = "01/01/2000"
        cbCivil.SelectedItem = Nothing
        cbRemarks.SelectedItem = Nothing

    End Sub

    Private Sub UpdateInf()
        'UPDATE THE RECORD
        Dim row As DataGridViewRow = DataGridView1.CurrentRow

        If DataGridView1.SelectedCells.Count = 0 Then
            MessageBox.Show("Select an derogatory record first and click edit.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        ElseIf MessageBox.Show("Update this Derogatory Record?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            strsql = "UPDATE tbl_residents SET Remarks = '" & cbRemarks.Text & "' WHERE Last_Name = '" & txtLast.Text & "'"
            cmd = New MySqlCommand(strsql, connect)

            Try
                connect.Open()
                adapter.UpdateCommand = connect.CreateCommand()
                adapter.UpdateCommand.CommandText = strsql

                If adapter.UpdateCommand.ExecuteNonQuery() > 0 Then
                    txtClear()
                    List()
                    MessageBox.Show("Derogatory Record Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    'ACTIVITY LOG FOR UPDATING DEROGATORY
                    connect.Open()
                    cmd = connect.CreateCommand
                    cmd.CommandText = "INSERT INTO tbl_logs(User_No, Last_Name, First_Name, User_Type, Time, Date, Activity) VALUES (@UserNo, @Last, @First, @Utype, @Time, @Date, @Act)"

                    cmd.Parameters.AddWithValue("@UserNo", bdt.Rows(0).Item(0))
                    cmd.Parameters.AddWithValue("@Last", bdt.Rows(0).Item(4))
                    cmd.Parameters.AddWithValue("@First", bdt.Rows(0).Item(5))
                    cmd.Parameters.AddWithValue("Utype", bdt.Rows(0).Item(3))
                    cmd.Parameters.AddWithValue("@Time", DateTime.Now.ToLongTimeString)
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToShortDateString)
                    cmd.Parameters.AddWithValue("@Act", "Updated Derogatory")
                    cmd.ExecuteNonQuery()
                    connect.Close()

                Else
                    txtClear()
                    MessageBox.Show("Derogatory Record did not update", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                connect.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
                connect.Close()
            End Try
        End If

    End Sub

    Private Sub Edit()
        'EDIT RECORD
        Dim row As DataGridViewRow = DataGridView1.CurrentRow

        Try
            If DataGridView1.SelectedCells.Count = 0 Then
                MessageBox.Show("Select an derogatory record first!", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf DataGridView1.SelectedCells.Count > 0 Then
                Dim Last As String = row.Cells(1).Value.ToString
                Dim First As String = row.Cells(2).Value.ToString
                Dim MI As String = row.Cells(3).Value.ToString
                Dim Block As String = row.Cells(4).Value.ToString
                Dim Address As String = row.Cells(5).Value.ToString
                Dim DOB As String = row.Cells(6).Value.ToString
                Dim CStatus As String = row.Cells(10).Value.ToString
                Dim Remarks As String = row.Cells(15).Value.ToString

                txtLast.Text = Last
                txtFirst.Text = First
                txtMid.Text = MI
                txtBlock.Text = Block
                cbAddress.SelectedItem = Address
                dtpDOB.Value = DOB
                cbCivil.SelectedItem = CStatus
                cbRemarks.SelectedItem = Remarks

            End If
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

    Private Sub Derog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        List()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        UpdateInf()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Edit
    End Sub

    Private Sub DataGridView1_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles DataGridView1.DataBindingComplete
        'NOT AUTO SELECT SO YOU GONNA CLICK FROM DATA ROW FIRST
        DataGridView1.ClearSelection()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Search()
    End Sub

    Private Sub txtSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearch.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            If Not ((Asc(e.KeyChar) >= 97 And Asc(e.KeyChar) <= 122) Or (Asc(e.KeyChar) >= 65 And Asc(e.KeyChar) <= 90) Or (Asc(e.KeyChar) = Keys.Space)) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        'UNABLE TO CLICK BUTTONS IF THE DATA IS NOT SELECTED
        If DataGridView1.SelectedRows.Count = True Then
            btnEdit.Enabled = (DataGridView1.SelectedRows.Count > 0)
            cbRemarks.Enabled = (DataGridView1.SelectedRows.Count > 0)
        Else
            btnEdit.Enabled = (DataGridView1.SelectedRows.Count > 0)
            cbRemarks.Enabled = (DataGridView1.SelectedRows.Count > 0)
        End If
    End Sub

    Private Sub txtBlock_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBlock.KeyPress
        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Then
            e.Handled = False

        Else
            e.Handled = True
        End If
    End Sub
End Class