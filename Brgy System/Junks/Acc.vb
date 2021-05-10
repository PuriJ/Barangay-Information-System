Imports MySql.Data.MySqlClient
Public Class Acc
    Dim strsql As String
    Dim ds As New DataSet
    Dim cmd As New MySqlCommand
    Dim dr As MySqlDataReader
    Dim a, b, c, d, e


    Private Sub Acc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Set Listview Properties

        List()
        autogen()

    End Sub


    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        Add()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        UpdateInf()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Edit()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Del()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Search()
    End Sub

    Private Sub txtID_KeyPress(sender As Object, e As KeyPressEventArgs)
        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Then
            e.Handled = False
        Else

            e.Handled = True
        End If
    End Sub

    Public Sub List()
        strsql = "SELECT * FROM tbl_accounts"
        adapter = New MySqlDataAdapter(strsql, connect)
        ds = New DataSet()
        connect.Close()
        adapter.Fill(ds, "Emp")
        DataGridView1.DataSource = ds.Tables(0)

    End Sub


    Private Sub txtClear()
        txtUser.Text = ""
        txtPass.Text = ""
        txtName.Text = ""
        combUtype.SelectedValue = ""
    End Sub


    Private Sub Add()
        'CREATING AN ACCOUNT FOR EMPLOYEES AND/OR ADMIN

        If txtUser.Text = "" Or txtPass.Text = "" Or txtName.Text = "" Or combUtype.SelectedItem = "" Then
            MessageBox.Show("Fill the forms before you insert", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        ElseIf MessageBox.Show("Insert this Account?", "Insert Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            strsql = "INSERT INTO tbl_accounts(id, username, password, name, usertype) VALUES ('" & lblCount.Text & "', '" & txtUser.Text & "','" & txtPass.Text & "','" & txtName.Text & "','" & combUtype.SelectedItem & "')"
            cmd = New MySqlCommand(strsql, connect)
            Try
                connect.Open()

                If cmd.ExecuteNonQuery() > 0 Then
                    txtClear()
                    MessageBox.Show("Account Added!", "Insert Account", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

                connect.Close()
            Catch ex As Exception
                MsgBox("Duplicate entry. Please try again!", MessageBoxIcon.Error)
                connect.Close()
            End Try
            List()
            autogen()
        End If


    End Sub

    Private Sub UpdateInf()
        'UPDATE ACCOUNT
        If DataGridView1.SelectedCells.Count = 0 Then
            MessageBox.Show("Select an account first and click edit.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        ElseIf MessageBox.Show("Update this Account?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then

            strsql = "UPDATE `tbl_accounts` SET `username`= '" & txtUser.Text & "', `password`= '" & txtPass.Text & "', `name`= '" & txtName.Text & "', `usertype`= '" & combUtype.SelectedItem & "' WHERE `id`= '" & lblCount.Text & "'"
            cmd = New MySqlCommand(strsql, connect)

            Try
                connect.Open()

                adapter.UpdateCommand = connect.CreateCommand()
                adapter.UpdateCommand.CommandText = strsql

                If adapter.UpdateCommand.ExecuteNonQuery() > 0 Then

                    txtClear()

                    MessageBox.Show("Account Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Else

                    txtClear()
                    MessageBox.Show("Account did not update", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

                connect.Close()

            Catch ex As Exception
                MsgBox(ex.Message, MessageBoxIcon.Error)
                connect.Close()
            End Try
            List()
            autogen()
        End If

    End Sub

    Private Sub Edit()
        'Editing the account
        Dim row As DataGridViewRow = DataGridView1.CurrentRow

        If DataGridView1.SelectedCells.Count = 0 Then
            MessageBox.Show("Select an account first!", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        ElseIf DataGridView1.SelectedCells.Count > 0 Then
            Dim ID As String = row.Cells(0).Value.ToString
            Dim User As String = row.Cells(1).Value.ToString
            Dim Pass As String = row.Cells(2).Value.ToString
            Dim Name As String = row.Cells(3).Value.ToString
            Dim Utype As String = row.Cells(4).Value.ToString


            lblCount.Text = ID
            txtUser.Text = User
            txtPass.Text = Pass
            txtName.Text = Name
            combUtype.SelectedItem = Utype
        End If
    End Sub



    Private Sub Del()
        'DELETING ACCOUNT

        If DataGridView1.SelectedCells.Count = 0 Then

            MessageBox.Show("Please choose an item to delete!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)


        ElseIf MessageBox.Show("Delete this Account?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then

            strsql = "DELETE FROM `tbl_accounts` WHERE `id` = '" & DataGridView1.CurrentRow.Cells(0).Value.ToString & "'"
            Dim ada As New MySqlDataAdapter(strsql, connect)
            ada.Fill(ds)
            txtClear()
            List()
            MessageBox.Show("Account Deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
        autogen()
    End Sub

    Private Sub Search()
        Dim ds As New DataSet()
        Dim adapter As MySqlDataAdapter
        Try
            connect.Open()
            adapter = New MySqlDataAdapter("select * from tbl_accounts where name like '%" & txtSearch.Text & "%'", connect)
            adapter.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
            connect.Close()
        Catch ex As Exception

        End Try
    End Sub



    Private Sub autogen()
        'Auto increment number for accounts
        connect.Open()

        Dim num As Integer
        strsql = "SELECT MAX(id) FROM tbl_accounts"
        cmd = New MySqlCommand(strsql, connect)

        If IsDBNull(cmd.ExecuteScalar) Then
            num = 1001
            lblCount.Text = num
        Else
            num = cmd.ExecuteScalar + 1
            lblCount.Text = num
        End If
        connect.Close()

    End Sub

End Class