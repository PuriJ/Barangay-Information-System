Imports MySql.Data.MySqlClient
Public Class brgyClearance
    Dim strsql As String
    Dim ds As New DataSet
    Dim cmd As New MySqlCommand
    Dim dr As MySqlDataReader

    Private Sub List()
        'SHOW ITS DATA
        strsql = "SELECT * FROM tbl_residents"
        adapter = New MySqlDataAdapter(strsql, connect)
        ds = New DataSet()
        connect.Close()
        adapter.Fill(ds, "Emp")
        DataGridView1.DataSource = ds.Tables(0)
    End Sub

    Private Sub txtClear()
        'CLEARING CONTENTS ON ITS TEXTBOXES
        txtLast.Text = ""
        txtFirst.Text = ""
        txtMid.Text = ""
        txtAddress.Text = ""
        txtPOB.Text = ""
        txtPurp.Text = ""
    End Sub

    Private Sub Autogen()
        'AUTO INCREMENT NUMBER FOR RESIDENTS
        connect.Open()

        Dim num As Integer
        strsql = "SELECT MAX(clearance_no) FROM tbl_clearance"
        cmd = New MySqlCommand(strsql, connect)

        If IsDBNull(cmd.ExecuteScalar) Then
            num = 1
            lblClr.Text = num
        Else
            num = cmd.ExecuteScalar + 1
            lblClr.Text = num
        End If
        connect.Close()

    End Sub

    Private Sub Add()
        'INSERT ACCOUNT FOR RESIDENTS

        If txtLast.Text = "" Or txtFirst.Text = "" Or txtMid.Text = "" Or txtAddress.Text = "" Or txtPOB.Text = "" Or txtPurp.Text = "" Or cmbRem.SelectedItem = "" Then
            MessageBox.Show("Fill the forms before you add", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        ElseIf MessageBox.Show("Add this clearance record?", "Add Resident", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            strsql = "INSERT INTO tbl_clearance(clearance_no, Last_Name, First_Name, MI, Address, DOB, POB, Purpose, Remarks, DOI) VALUES ('" & lblClr.Text & "', '" & txtLast.Text & "', '" & txtFirst.Text & "', '" & txtMid.Text & "', '" & txtAddress.Text & "', '" & dtpDOB.Value & "', '" & txtPOB.Text & "', '" & txtPurp.Text & "', '" & cmbRem.SelectedItem & "', '" & dtpDOI.Value & "')"
            cmd = New MySqlCommand(strsql, connect)
            Try
                connect.Open()

                If cmd.ExecuteNonQuery() > 0 Then
                    txtClear()
                    List()
                    MessageBox.Show("Clearance Added!", "Add Clearance", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                connect.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
                connect.Close()
                txtClear()
            End Try
            Autogen()
        End If
    End Sub

    Private Sub UpdateInfo()
        'UPDATE RESIDENTS

        If DataGridView1.SelectedCells.Count = 0 Then
            MessageBox.Show("Select an resident record first and click edit.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        ElseIf MessageBox.Show("Update this Resident?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            strsql = "UPDATE tbl_clearance SET Last_Name = '" & txtLast.Text & "', First_Name = '" & txtFirst.Text & "', MI = '" & txtMid.Text & "', Address = '" & txtAddress.Text & "', DOB = '" & dtpDOB.Value & "', POB = '" & txtPOB.Text & "', Purpose = '" & txtPurp.Text & "', Remarks = '" & cmbRem.SelectedItem & "', DOI = '" & dtpDOI.Value & "' WHERE clearance_no = '" & lblClr.Text & "'"
            cmd = New MySqlCommand(strsql, connect)

            Try
                connect.Open()
                adapter.UpdateCommand = connect.CreateCommand()
                adapter.UpdateCommand.CommandText = strsql

                If adapter.UpdateCommand.ExecuteNonQuery() > 0 Then
                    txtClear()
                    List()
                    MessageBox.Show("Clearance Record Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Else
                    txtClear()
                    MessageBox.Show("Clearance Record did not update", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If
                connect.Close()
            Catch ex As Exception
                MsgBox(ex.Message, MessageBoxIcon.Error)
                connect.Close()
            End Try
            Autogen()
        End If
    End Sub

    Private Sub Edit()
        'EDIT CLEARANCE

        Dim row As DataGridViewRow = DataGridView1.CurrentRow

        Try
            If DataGridView1.SelectedCells.Count = 0 Then
                MessageBox.Show("Select an clearance record first!", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf DataGridView1.SelectedCells.Count > 0 Then
                Dim clrNo As String = row.Cells(0).Value.ToString
                Dim LastN As String = row.Cells(1).Value.ToString
                Dim FirstN As String = row.Cells(2).Value.ToString
                Dim MI As String = row.Cells(3).Value.ToString
                Dim Address As String = row.Cells(4).Value.ToString
                Dim DOB As String = row.Cells(5).Value.ToString
                Dim POB As String = row.Cells(6).Value.ToString
                Dim Purpose As String = row.Cells(7).Value.ToString
                Dim Remarks As String = row.Cells(8).Value.ToString
                Dim DOI As String = row.Cells(9).Value.ToString

                lblClr.Text = clrNo
                txtLast.Text = LastN
                txtFirst.Text = FirstN
                txtMid.Text = MI
                txtAddress.Text = Address
                dtpDOB.Value = DOB
                txtPOB.Text = POB
                txtPurp.Text = Purpose
                cmbRem.SelectedItem = Remarks
                dtpDOI.Value = DOI
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            txtClear()
        End Try
    End Sub

    Private Sub Delete()
        'DELETING RESIDENT RECORD

        If DataGridView1.SelectedCells.Count = 0 Then
            MessageBox.Show("Please choose a record To delete!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        ElseIf MessageBox.Show("Delete this Clearance?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            strsql = "DELETE FROM tbl_clearance WHERE clearance_no = '" & DataGridView1.CurrentRow.Cells(0).Value.ToString & "'"
            Dim ada As New MySqlDataAdapter(strsql, connect)
            ada.Fill(ds)
            txtClear()
            List()
            MessageBox.Show("Record Deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Autogen()
    End Sub

    Private Sub Search()
        Dim ds As New DataSet
        Dim ada As MySqlDataAdapter

        Try
            connect.Open()
            ada = New MySqlDataAdapter("SELECT * FROM tbl_clearance WHERE Last_Name LIKE '%" & txtSearch.Text & "%'", connect)
            ada.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
            connect.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub brgyClearance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        List()
        Autogen()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Add()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Edit()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        UpdateInfo()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Delete()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Search()
    End Sub

    Private Sub txtLast_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLast.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            If Not ((Asc(e.KeyChar) >= 97 And Asc(e.KeyChar) <= 122) Or (Asc(e.KeyChar) >= 65 And Asc(e.KeyChar) <= 90)) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtFirst_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFirst.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            If Not ((Asc(e.KeyChar) >= 97 And Asc(e.KeyChar) <= 122) Or (Asc(e.KeyChar) >= 65 And Asc(e.KeyChar) <= 90)) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtMid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMid.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            If Not ((Asc(e.KeyChar) >= 97 And Asc(e.KeyChar) <= 122) Or (Asc(e.KeyChar) >= 65 And Asc(e.KeyChar) <= 90)) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtPOB_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPOB.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            If Not ((Asc(e.KeyChar) >= 97 And Asc(e.KeyChar) <= 122) Or (Asc(e.KeyChar) >= 65 And Asc(e.KeyChar) <= 90)) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtPurp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPurp.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            If Not ((Asc(e.KeyChar) >= 97 And Asc(e.KeyChar) <= 122) Or (Asc(e.KeyChar) >= 65 And Asc(e.KeyChar) <= 90)) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub lblClr_Click(sender As Object, e As EventArgs) Handles lblClr.Click

    End Sub
End Class