'ACTIVITY LOG FOR ADMIN

Imports MySql.Data.MySqlClient
Public Class Log
    Dim strsql As String
    Dim ds As New DataSet
    Dim cmd As New MySqlCommand
    Dim dr As MySqlDataReader

    Private Sub AI()
        'AUTO INCREMENT
        connect.Open()

            Dim num As Integer
            strsql = "SELECT MAX(Log_No) FROM tbl_logs"
            cmd = New MySqlCommand(strsql, connect)

            If IsDBNull(cmd.ExecuteScalar) Then
                num = 1
            Else
                num = cmd.ExecuteScalar + 1
            End If
        connect.Close()


    End Sub

    Private Sub Logs()
        strsql = "SELECT * FROM tbl_logs"
        adapter = New MySqlDataAdapter(strsql, connect)
        ds = New DataSet()
        connect.Close()
        adapter.Fill(ds, "Emp")
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.ReadOnly = True
    End Sub

    Private Sub Delete()
        If DataGridView1.SelectedCells.Count = 0 Then

            MessageBox.Show("Please select log to delete!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        ElseIf MessageBox.Show("Delete this Log?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            strsql = "DELETE FROM tbl_logs WHERE Log_No = '" & DataGridView1.CurrentRow.Cells(0).Value.ToString & "'"
            Dim ada As New MySqlDataAdapter(strsql, connect)
            ada.Fill(ds)
            Logs()
            MessageBox.Show("Log Deleted.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
    End Sub

    Private Sub Search()
        'SEARCH BY LAST NAME ONLY
        Dim ds As New DataSet
        Dim ada As MySqlDataAdapter

        Try
            connect.Open()
            ada = New MySqlDataAdapter("SELECT * FROM tbl_logs WHERE Last_Name LIKE '%" & txtSearch.Text & "%'", connect)
            ada.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
            connect.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Filter()
        'Filtering the table
        connect.Open()
        strsql = "SELECT * FROM tbl_logs WHERE User_Type = '" & cmbFilt.SelectedItem & "' OR Activity = '" & cmbFilt.SelectedItem & "'"
        adapter = New MySqlDataAdapter(strsql, connect)

        If cmbFilt.SelectedItem = "Admin" Then
            Dim dsA As New DataSet
            adapter.Fill(dsA, "Empty")
            DataGridView1.DataSource = dsA.Tables(0)

        ElseIf cmbFilt.SelectedItem = "Employee" Then
            Dim dsE As New DataSet
            adapter.Fill(dsE, "Empty")
            DataGridView1.DataSource = dsE.Tables(0)

        ElseIf cmbFilt.SelectedItem = "Admin Logged In" Then
            Dim dsALI As New DataSet
            adapter.Fill(dsALI, "Empty")
            DataGridView1.DataSource = dsALI.Tables(0)

        ElseIf cmbFilt.SelectedItem = "Admin Logged Out" Then
            Dim dsALO As New DataSet
            adapter.Fill(dsALO, "Empty")
            DataGridView1.DataSource = dsALO.Tables(0)

        ElseIf cmbFilt.SelectedItem = "Employee Logged In" Then
            Dim dsELI As New DataSet
            adapter.Fill(dsELI, "Empty")
            DataGridView1.DataSource = dsELI.Tables(0)

        ElseIf cmbFilt.SelectedItem = "Employee Logged Out" Then
            Dim dsELO As New DataSet
            adapter.Fill(dsELO, "Empty")
            DataGridView1.DataSource = dsELO.Tables(0)

        ElseIf cmbFilt.SelectedItem = "Added Resident" Then
            Dim dsAR As New DataSet
            adapter.Fill(dsAR, "Empty")
            DataGridView1.DataSource = dsAR.Tables(0)

        ElseIf cmbFilt.SelectedItem = "Updated Resident" Then
            Dim dsUR As New DataSet
            adapter.Fill(dsUR, "Empty")
            DataGridView1.DataSource = dsUR.Tables(0)

        ElseIf cmbFilt.SelectedItem = "Deleted Resident" Then
            Dim dsDR As New DataSet
            adapter.Fill(dsDR, "Empty")
            DataGridView1.DataSource = dsDR.Tables(0)

        ElseIf cmbFilt.SelectedItem = "Added Account" Then
            Dim dsAA As New DataSet
            adapter.Fill(dsAA, "Empty")
            DataGridView1.DataSource = dsAA.Tables(0)

        ElseIf cmbFilt.SelectedItem = "Updated Account" Then
            Dim dsUA As New DataSet
            adapter.Fill(dsUA, "Empty")
            DataGridView1.DataSource = dsUA.Tables(0)

        ElseIf cmbFilt.SelectedItem = "Deleted Account" Then
            Dim dsDA As New DataSet
            adapter.Fill(dsDA, "Empty")
            DataGridView1.DataSource = dsDA.Tables(0)

        ElseIf cmbFilt.SelectedItem = "All" Then
            adapter.Fill(ds, "Empty")
            DataGridView1.DataSource = ds.Tables(0)
        End If
        connect.Close()
    End Sub

    Private Sub Log_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AI()
        Logs()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Delete()
    End Sub

    Private Sub DataGridView1_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles DataGridView1.DataBindingComplete
        'NOT AUTO SELECTED SO YOU GONNA CLICK FROM DATA ROW FIRST
        DataGridView1.ClearSelection()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Search()
    End Sub

    Private Sub cmbFilt_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFilt.SelectedIndexChanged
        Filter()
    End Sub
End Class