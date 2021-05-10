Imports MySql.Data.MySqlClient
Public Class Maintenance
    Dim strsql As String
    Dim ds As New DataSet
    Dim cmd As New MySqlCommand
    Dim dr As MySqlDataReader

    Public Sub List()
        'SHOW ITS DATA
        strsql = "SELECT * FROM tbl_account"
        adapter = New MySqlDataAdapter(strsql, connect)
        ds = New DataSet()
        connect.Close()
        adapter.Fill(ds, "Emp")
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.ReadOnly = True
    End Sub

    Private Sub txtClear()
        'CLEARING CONTENTS ON ITS TEXTBOXES
        txtUser.Text = ""
        txtPass.Text = ""
        cbUsertype.SelectedItem = ""
        txtLast.Text = ""
        txtFirst.Text = ""
        txtMid.Text = ""
        txtAge.Text = ""
        cbGen.SelectedItem = ""
    End Sub

    Private Sub Autogen()
        'AUTO INCREMENT NUMBER FOR ACCOUNTS
        connect.Open()

        Dim num As Integer
        strsql = "SELECT MAX(User_No) FROM tbl_account"
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

    Private Sub Add()
        'INSERT ACCOUNT FOR USERS

        If txtUser.Text = "" Or txtUser.Text = "" Or txtPass.Text = "" Or cbUsertype.SelectedItem = "" Or txtLast.Text = "" Or txtFirst.Text = "" Or txtMid.Text = "" Or txtAge.Text = "" Or cbGen.SelectedItem = "" Then
            MessageBox.Show("Fill the forms before you insert", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        ElseIf MessageBox.Show("Add this Account?", "Add Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            strsql = "INSERT INTO tbl_account(User_No, Username, Password, User_Type, Last_Name, First_Name, Middle_Initial, Age, Gender, Birth_Date) VALUES ('" & lblCount.Text & "','" & txtUser.Text & "','" & txtPass.Text & "','" & cbUsertype.SelectedItem & "','" & txtLast.Text & "','" & txtFirst.Text & "','" & txtMid.Text & "','" & txtAge.Text & "','" & cbGen.SelectedItem & "','" & dtpBdate.Value & "')"
            cmd = New MySqlCommand(strsql, connect)
            Try
                connect.Open()

                If cmd.ExecuteNonQuery() > 0 Then
                    txtClear()
                    List()
                    MessageBox.Show("Account Added!", "Add Account", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                connect.Close()

                connect.Open()
                cmd = connect.CreateCommand
                cmd.CommandText = "INSERT INTO tbl_logs(User_No, Last_Name, First_Name, User_Type, Time, Date, Activity) VALUES (@UserNo, @Last, @First, @Utype, @Time, @Date, @Act)"

                cmd.Parameters.AddWithValue("@UserNo", bdt.Rows(0).Item(0))
                cmd.Parameters.AddWithValue("@Last", bdt.Rows(0).Item(4))
                cmd.Parameters.AddWithValue("@First", bdt.Rows(0).Item(5))
                cmd.Parameters.AddWithValue("Utype", bdt.Rows(0).Item(3))
                cmd.Parameters.AddWithValue("@Time", DateTime.Now.ToLongTimeString)
                cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToShortDateString)
                cmd.Parameters.AddWithValue("@Act", "Added Account")
                cmd.ExecuteNonQuery()
                connect.Close()

            Catch ex As Exception
                MsgBox("Duplicate entry. Please try again!", MessageBoxIcon.Error)
                connect.Close()
                txtClear()
            End Try
            Autogen()
        End If
    End Sub

    Private Sub UpdateInfo()
        'UPDATE ACCOUNT

        If DataGridView1.SelectedCells.Count = 0 Then
            MessageBox.Show("Select an account first and click edit.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        ElseIf MessageBox.Show("Update this Account?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            strsql = "UPDATE tbl_account SET Username = '" & txtUser.Text & "', Password = '" & txtPass.Text & "', User_Type = '" & cbUsertype.SelectedItem & "', Last_Name = '" & txtLast.Text & "', First_Name = '" & txtFirst.Text & "', Middle_Initial = '" & txtMid.Text & "', Age = '" & txtAge.Text & "', Gender = '" & cbGen.SelectedItem & "', Birth_Date = '" & dtpBdate.Value & "' WHERE User_No = '" & lblCount.Text & "'"
            cmd = New MySqlCommand(strsql, connect)

            Try
                connect.Open()
                adapter.UpdateCommand = connect.CreateCommand()
                adapter.UpdateCommand.CommandText = strsql

                If adapter.UpdateCommand.ExecuteNonQuery() > 0 Then
                    txtClear()
                    List()
                    MessageBox.Show("Account Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    connect.Open()
                    cmd = connect.CreateCommand
                    cmd.CommandText = "INSERT INTO tbl_logs(User_No, Last_Name, First_Name, User_Type, Time, Date, Activity) VALUES (@UserNo, @Last, @First, @Utype, @Time, @Date, @Act)"

                    cmd.Parameters.AddWithValue("@UserNo", bdt.Rows(0).Item(0))
                    cmd.Parameters.AddWithValue("@Last", bdt.Rows(0).Item(4))
                    cmd.Parameters.AddWithValue("@First", bdt.Rows(0).Item(5))
                    cmd.Parameters.AddWithValue("Utype", bdt.Rows(0).Item(3))
                    cmd.Parameters.AddWithValue("@Time", DateTime.Now.ToLongTimeString)
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToShortDateString)
                    cmd.Parameters.AddWithValue("@Act", "Updated Account")
                    cmd.ExecuteNonQuery()
                    connect.Close()

                Else
                    txtClear()
                    MessageBox.Show("Account did not update", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

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
        'EDIT ACCOUNT

        Dim row As DataGridViewRow = DataGridView1.CurrentRow

        If DataGridView1.SelectedCells.Count = 0 Then
            MessageBox.Show("Select an account first!", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        ElseIf DataGridView1.SelectedCells.Count > 0 Then
            Dim ID As String = row.Cells(0).Value.ToString
            Dim User As String = row.Cells(1).Value.ToString
            Dim Pass As String = row.Cells(2).Value.ToString
            Dim Usertype As String = row.Cells(3).Value.ToString
            Dim Last As String = row.Cells(4).Value.ToString
            Dim First As String = row.Cells(5).Value.ToString
            Dim Mid As String = row.Cells(6).Value.ToString
            Dim Age As String = row.Cells(7).Value.ToString
            Dim Gender As String = row.Cells(8).Value.ToString
            Dim Birth As String = row.Cells(9).Value.ToString

            lblCount.Text = ID
            txtUser.Text = User
            txtPass.Text = Pass
            cbUsertype.SelectedItem = Usertype
            txtLast.Text = Last
            txtFirst.Text = First
            txtMid.Text = Mid
            txtAge.Text = Age
            cbGen.SelectedItem = Gender
            dtpBdate.Value = Birth
        End If
    End Sub

    Private Sub Delete()
        'DELETING ACCOUNT

        If DataGridView1.SelectedCells.Count = 0 Then

            MessageBox.Show("Please choose an item to delete!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        ElseIf MessageBox.Show("Delete this Account?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            strsql = "DELETE FROM tbl_account WHERE User_No = '" & DataGridView1.CurrentRow.Cells(0).Value.ToString & "'"
            Dim ada As New MySqlDataAdapter(strsql, connect)
            ada.Fill(ds)
            txtClear()
            List()
            MessageBox.Show("Account Deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            connect.Open()
            cmd = connect.CreateCommand
            cmd.CommandText = "INSERT INTO tbl_logs(User_No, Last_Name, First_Name, User_Type, Time, Date, Activity) VALUES (@UserNo, @Last, @First, @Utype, @Time, @Date, @Act)"

            cmd.Parameters.AddWithValue("@UserNo", bdt.Rows(0).Item(0))
            cmd.Parameters.AddWithValue("@Last", bdt.Rows(0).Item(4))
            cmd.Parameters.AddWithValue("@First", bdt.Rows(0).Item(5))
            cmd.Parameters.AddWithValue("Utype", bdt.Rows(0).Item(3))
            cmd.Parameters.AddWithValue("@Time", DateTime.Now.ToLongTimeString)
            cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToShortDateString)
            cmd.Parameters.AddWithValue("@Act", "Deleted Account")
            cmd.ExecuteNonQuery()
            connect.Close()

        End If
        Autogen()
    End Sub

    'SEARCHING THE INFO USING THE LAST NAME
    Private Sub Search()
        Dim ds As New DataSet
        Dim ada As MySqlDataAdapter
        Try
            connect.Open()
            ada = New MySqlDataAdapter("SELECT * FROM tbl_account WHERE Last_Name LIKE '%" & txtSearch.Text & "%'", connect)
            ada.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
            connect.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Maintenance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'SHOW THE LIST DATA
        List()
        Autogen()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Search()
    End Sub

    Private Sub txtAge_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAge.KeyPress
        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Then
            e.Handled = False

        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtLast_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLast.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            If Not ((Asc(e.KeyChar) >= 97 And Asc(e.KeyChar) <= 122) Or (Asc(e.KeyChar) >= 65 And Asc(e.KeyChar) <= 90) Or (Asc(e.KeyChar) = Keys.Space)) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtFirst_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFirst.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            If Not ((Asc(e.KeyChar) >= 97 And Asc(e.KeyChar) <= 122) Or (Asc(e.KeyChar) >= 65 And Asc(e.KeyChar) <= 90) Or (Asc(e.KeyChar) = Keys.Space)) Then
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

    Private Sub dtpBdate_ValueChanged(sender As Object, e As EventArgs) Handles dtpBdate.ValueChanged
        'AUTO GENERATED AGE FOR THE BIRTHDATE IF YOU CHOOSE FROM THE DATE
        With dtpBdate.Value
            Dim bdate As DateTime = New DateTime(Now.Year, .Month, .Day)
            Dim age As Integer = Now.Year - .Year
            If bdate > Now Then age -= 1
            txtAge.Text = CStr(age)
        End With
    End Sub

    Private Sub DataGridView1_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles DataGridView1.DataBindingComplete
        'NOT AUTO SELECTED SO YOU GONNA CLICK FROM DATA ROW FIRST
        DataGridView1.ClearSelection()
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        'UNABLE BUTTONS IF THE DATA IS NOT SELECTED
        If DataGridView1.SelectedRows.Count = True Then
            btnAdd.Enabled = (DataGridView1.SelectedRows.Count > 0)
        Else
            btnAdd.Enabled = (DataGridView1.SelectedRows.Count = 0)
            btnEdit.Enabled = (DataGridView1.SelectedRows.Count > 0)
            btnUpdate.Enabled = (DataGridView1.SelectedRows.Count > 0)
            btnDelete.Enabled = (DataGridView1.SelectedRows.Count > 0)
        End If

    End Sub

    'FILTERING THE DATA BASED ON THE USER ACCESS
    Private Sub cmbFilt_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFilt.SelectedIndexChanged
        connect.Open()
        strsql = "SELECT * FROM tbl_account WHERE User_Type = '" & cmbFilt.SelectedItem & "'"
        adapter = New MySqlDataAdapter(strsql, connect)

        If cmbFilt.SelectedItem = "Admin" Then
            Dim ds1 As New DataSet
            adapter.Fill(ds1, "Empty")
            DataGridView1.DataSource = ds1.Tables(0)

        ElseIf cmbFilt.SelectedItem = "Employee" Then
            Dim ds2 As New DataSet
            adapter.Fill(ds2, "Empty")
            DataGridView1.DataSource = ds2.Tables(0)

        ElseIf cmbFilt.SelectedItem = "All" Then
            adapter.Fill(ds, "Empty")
            DataGridView1.DataSource = ds.Tables(0)
        End If
        connect.Close()
    End Sub
End Class