Imports MySql.Data.MySqlClient
Public Class Residents
    Dim strsql As String
    Dim ds As New DataSet
    Dim cmd As New MySqlCommand
    Dim dr As MySqlDataReader

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

    Private Sub txtClear()
        'CLEARING CONTENTS ON ITS TEXTBOXES
        txtLast.Text = ""
        txtFirst.Text = ""
        txtMid.Text = ""
        txtBlock.Text = ""
        cbAddress.SelectedItem = Nothing
        txtPOB.Text = ""
        txtAge.Text = ""
        cbCivil.SelectedItem = Nothing
        txtOccupation.Text = ""
        txtHousehold.Text = ""
        dtpDOB.Value = "01/01/2000"
        cbSex.SelectedItem = Nothing
        cbStatus.SelectedItem = Nothing
        cbVoter.SelectedItem = Nothing

    End Sub

    Private Sub Autogen()
        'AUTO INCREMENT NUMBER FOR ACCOUNTS
        connect.Open()

        Dim num As Integer
        strsql = "SELECT MAX(Resident_No) FROM tbl_residents"
        cmd = New MySqlCommand(strsql, connect)

        If IsDBNull(cmd.ExecuteScalar) Then
            num = 1001
            lblPopulation.Text = num
        Else
            num = cmd.ExecuteScalar + 1
            lblPopulation.Text = num
        End If
        connect.Close()

    End Sub

    Private Sub Popo()
        'COUNTING THE NUMBER OF POPULATION
        connect.Open()

        Dim num1 As Integer
        strsql = "SELECT COUNT(Resident_No) FROM tbl_residents"
        cmd = New MySqlCommand(strsql, connect)

        If IsDBNull(cmd.ExecuteScalar) Then
            num1 = 0
            lblPop.Text = num1

        Else
            num1 = cmd.ExecuteScalar
            lblPop.Text = num1
        End If
        connect.Close()
    End Sub

    Private Sub Voters()
        'COUNTING THE NUMBER OF REGISTERED VOTERS
        connect.Open()

        Dim num2 As Integer
        strsql = "SELECT COUNT(Registered_Voters) FROM tbl_residents WHERE Registered_Voters = 'Yes'"
        cmd = New MySqlCommand(strsql, connect)

        If IsDBNull(cmd.ExecuteScalar) Then
            num2 = 0
            lblVoters.Text = num2

        Else
            num2 = cmd.ExecuteScalar
            lblVoters.Text = num2
        End If
        connect.Close()
    End Sub

    Private Sub Students()
        'COUNTING THE NUMBER OF STUDENTS
        connect.Open()

        Dim num3 As Integer
        strsql = "SELECT COUNT(Status) FROM tbl_residents WHERE Status = 'Student'"
        cmd = New MySqlCommand(strsql, connect)

        If IsDBNull(cmd.ExecuteScalar) Then
            num3 = 0
            lblStudents.Text = num3

        Else
            num3 = cmd.ExecuteScalar
            lblStudents.Text = num3
        End If
        connect.Close()
    End Sub

    Private Sub Senior()
        'COUNTING THE NUMBER OF SENIOR CITIZEN
        connect.Open()

        Dim num4 As Integer
        strsql = "SELECT COUNT(Status) FROM tbl_residents WHERE Status = 'Senior Citizen'"
        cmd = New MySqlCommand(strsql, connect)

        If IsDBNull(cmd.ExecuteScalar) Then
            num4 = 0
            lblSenior.Text = num4

        Else
            num4 = cmd.ExecuteScalar
            lblSenior.Text = num4
        End If
        connect.Close()
    End Sub

    Private Sub PWD()
        'COUNTING THE NUMBER OF SENIOR CITIZEN
        connect.Open()

        Dim num5 As Integer
        strsql = "SELECT COUNT(Status) FROM tbl_residents WHERE Status = 'PWD'"
        cmd = New MySqlCommand(strsql, connect)

        If IsDBNull(cmd.ExecuteScalar) Then
            num5 = 0
            lblPWD.Text = num5

        Else
            num5 = cmd.ExecuteScalar
            lblPWD.Text = num5
        End If
        connect.Close()
    End Sub

    Private Sub Add()
        'INSERT DATA FOR RESIDENTS

        If txtLast.Text = "" Or txtFirst.Text = "" Or txtMid.Text = "" Or txtBlock.Text = "" Or cbAddress.SelectedItem = Nothing Or txtPOB.Text = "" Or cbSex.SelectedItem = "" Or txtAge.Text = "" Or cbCivil.SelectedItem = "" Or txtOccupation.Text = "" Or txtHousehold.Text = "" Or cbVoter.SelectedItem = "" Then
            MessageBox.Show("Fill the forms before you add", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        ElseIf MessageBox.Show("Add this resident?", "Add Resident", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            strsql = "INSERT INTO tbl_residents(Resident_No, Last_Name, First_Name, MI, Block_No, Address, DOB, POB, Sex, Age, Civil_Status, Occupation, Household, Status, Registered_Voters) VALUES ('" & lblPopulation.Text & "', '" & txtLast.Text & "', '" & txtFirst.Text & "', '" & txtMid.Text & "', '" & txtBlock.Text & "', '" & cbAddress.SelectedItem & "', '" & dtpDOB.Value & "', '" & txtPOB.Text & "', '" & cbSex.SelectedItem & "', '" & txtAge.Text & "', '" & cbCivil.SelectedItem & "', '" & txtOccupation.Text & "', '" & txtHousehold.Text & "', '" & cbStatus.SelectedItem & "', '" & cbVoter.SelectedItem & "')"
            cmd = New MySqlCommand(strsql, connect)
            Try
                connect.Open()

                If cmd.ExecuteNonQuery() > 0 Then
                    txtClear()
                    List()
                    Autogen()
                    Popo()
                    Voters()
                    Students()
                    Senior()
                    PWD()
                    MessageBox.Show("Resident Added!", "Add Account", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                connect.Close()

                'ACTIVITY LOG FOR ADDING RESIDENTS RECORD
                connect.Open()
                cmd = connect.CreateCommand
                cmd.CommandText = "INSERT INTO tbl_logs(User_No, Last_Name, First_Name, User_Type, Time, Date, Activity) VALUES (@UserNo, @Last, @First, @Utype, @Time, @Date, @Act)"

                cmd.Parameters.AddWithValue("@UserNo", bdt.Rows(0).Item(0))
                cmd.Parameters.AddWithValue("@Last", bdt.Rows(0).Item(4))
                cmd.Parameters.AddWithValue("@First", bdt.Rows(0).Item(5))
                cmd.Parameters.AddWithValue("Utype", bdt.Rows(0).Item(3))
                cmd.Parameters.AddWithValue("@Time", DateTime.Now.ToLongTimeString)
                cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToShortDateString)
                cmd.Parameters.AddWithValue("@Act", "Added Resident")
                cmd.ExecuteNonQuery()
                connect.Close()

            Catch ex As Exception
                MsgBox(ex.Message)
                connect.Close()
                txtClear()
            End Try
        End If
    End Sub

    Private Sub UpdateInfo()
        'UPDATE RESIDENT

        If DataGridView1.SelectedCells.Count = 0 Then
            MessageBox.Show("Select an resident record first and click edit.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        ElseIf MessageBox.Show("Update this Resident?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            strsql = "UPDATE tbl_residents SET Last_Name = '" & txtLast.Text & "', First_Name = '" & txtFirst.Text & "', MI = '" & txtMid.Text & "', Block_No = '" & txtBlock.Text & "', Address = '" & cbAddress.SelectedItem & "', DOB = '" & dtpDOB.Value & "', POB = '" & txtPOB.Text & "', Sex = '" & cbSex.SelectedItem & "', Age = '" & txtAge.Text & "', Civil_Status = '" & cbCivil.SelectedItem & "', Occupation = '" & txtOccupation.Text & "', Household = '" & txtHousehold.Text & "', Status = '" & cbStatus.Text & "', Registered_Voters = '" & cbVoter.SelectedItem & "' WHERE Resident_No = '" & lblPopulation.Text & "'"
            cmd = New MySqlCommand(strsql, connect)

            Try
                connect.Open()
                adapter.UpdateCommand = connect.CreateCommand()
                adapter.UpdateCommand.CommandText = strsql

                If adapter.UpdateCommand.ExecuteNonQuery() > 0 Then
                    txtClear()
                    List()
                    Autogen()
                    Popo()
                    Voters()
                    Students()
                    Senior()
                    PWD()
                    MessageBox.Show("Resident Record Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    'ACTIVITY LOG FOR UPDATING RESIDENT RECORD
                    connect.Open()
                    cmd = connect.CreateCommand
                    cmd.CommandText = "INSERT INTO tbl_logs(User_No, Last_Name, First_Name, User_Type, Time, Date, Activity) VALUES (@UserNo, @Last, @First, @Utype, @Time, @Date, @Act)"

                    cmd.Parameters.AddWithValue("@UserNo", bdt.Rows(0).Item(0))
                    cmd.Parameters.AddWithValue("@Last", bdt.Rows(0).Item(4))
                    cmd.Parameters.AddWithValue("@First", bdt.Rows(0).Item(5))
                    cmd.Parameters.AddWithValue("Utype", bdt.Rows(0).Item(3))
                    cmd.Parameters.AddWithValue("@Time", DateTime.Now.ToLongTimeString)
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToShortDateString)
                    cmd.Parameters.AddWithValue("@Act", "Updated Resident")
                    cmd.ExecuteNonQuery()
                    connect.Close()

                Else
                    txtClear()
                    MessageBox.Show("Resident Record did not update", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If
                connect.Close()
            Catch ex As Exception
                MsgBox(ex.Message, MessageBoxIcon.Error)
                connect.Close()
            End Try
        End If

    End Sub

    Private Sub Edit()
        'EDIT RECORD FOR RESIDENT

        Dim row As DataGridViewRow = DataGridView1.CurrentRow

        Try

            If DataGridView1.SelectedCells.Count = 0 Then
                MessageBox.Show("Select an resident record first!", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf DataGridView1.SelectedCells.Count > 0 Then
                Dim ResNo As String = row.Cells(0).Value.ToString
                Dim Last As String = row.Cells(1).Value.ToString
                Dim First As String = row.Cells(2).Value.ToString
                Dim MI As String = row.Cells(3).Value.ToString
                Dim Block As String = row.Cells(4).Value.ToString
                Dim Address As String = row.Cells(5).Value.ToString
                Dim DOB As String = row.Cells(6).Value.ToString
                Dim POB As String = row.Cells(7).Value.ToString
                Dim Sex As String = row.Cells(8).Value.ToString
                Dim Age As String = row.Cells(9).Value.ToString
                Dim Civil As String = row.Cells(10).Value.ToString
                Dim Occupation As String = row.Cells(11).Value.ToString
                Dim House As String = row.Cells(12).Value.ToString
                Dim Status As String = row.Cells(13).Value.ToString
                Dim Voters As String = row.Cells(14).Value.ToString

                lblPopulation.Text = ResNo
                txtLast.Text = Last
                txtFirst.Text = First
                txtMid.Text = MI
                txtBlock.Text = Block
                cbAddress.SelectedItem = Address
                dtpDOB.Value = DOB
                txtPOB.Text = POB
                cbSex.SelectedItem = Sex
                txtAge.Text = Age
                cbCivil.SelectedItem = Civil
                txtOccupation.Text = Occupation
                txtHousehold.Text = House
                cbStatus.SelectedItem = Status
                cbVoter.SelectedItem = Voters
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            txtClear()
        End Try

    End Sub

    Private Sub Delete()
        'DELETING RESIDENT RECORD

        If DataGridView1.SelectedCells.Count = 0 Then
            MessageBox.Show("Please choose an record to delete!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        ElseIf MessageBox.Show("Delete this Account?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            strsql = "DELETE FROM tbl_residents WHERE Resident_No = '" & DataGridView1.CurrentRow.Cells(0).Value.ToString & "'"
            Dim ada As New MySqlDataAdapter(strsql, connect)
            ada.Fill(ds)
            txtClear()
            List()
            Autogen()
            Popo()
            Voters()
            Students()
            Senior()
            PWD()
            MessageBox.Show("Record Deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            'ACTIVITY LOG FOR DELETING RESIDENT RECORD
            connect.Open()
            cmd = connect.CreateCommand
            cmd.CommandText = "INSERT INTO tbl_logs(User_No, Last_Name, First_Name, User_Type, Time, Date, Activity) VALUES (@UserNo, @Last, @First, @Utype, @Time, @Date, @Act)"

            cmd.Parameters.AddWithValue("@UserNo", bdt.Rows(0).Item(0))
            cmd.Parameters.AddWithValue("@Last", bdt.Rows(0).Item(4))
            cmd.Parameters.AddWithValue("@First", bdt.Rows(0).Item(5))
            cmd.Parameters.AddWithValue("Utype", bdt.Rows(0).Item(3))
            cmd.Parameters.AddWithValue("@Time", DateTime.Now.ToLongTimeString)
            cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToShortDateString)
            cmd.Parameters.AddWithValue("@Act", "Deleted Resident")
            cmd.ExecuteNonQuery()
            connect.Close()

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

    Private Sub Filter()
        'Filtering the table
        connect.Open()
        strsql = "SELECT * FROM tbl_residents WHERE Civil_Status = '" & cbSort.SelectedItem & "' Or Status = '" & cbSort.SelectedItem & "'"
        adapter = New MySqlDataAdapter(strsql, connect)

        If cbSort.SelectedItem = "Single" Then
            Dim dsS As New DataSet
            adapter.Fill(dsS, "Empty")
            DataGridView1.DataSource = dsS.Tables(0)

        ElseIf cbSort.SelectedItem = "Married" Then
            Dim dsM As New DataSet
            adapter.Fill(dsM, "Empty")
            DataGridView1.DataSource = dsM.Tables(0)

        ElseIf cbSort.SelectedItem = "Widowed" Then
            Dim dsW As New DataSet
            adapter.Fill(dsW, "Empty")
            DataGridView1.DataSource = dsW.Tables(0)

        ElseIf cbSort.SelectedItem = "Separated" Then
            Dim dsSe As New DataSet
            adapter.Fill(dsSe, "Empty")
            DataGridView1.DataSource = dsSe.Tables(0)

        ElseIf cbSort.SelectedItem = "Student" Then
            Dim dsSt As New DataSet
            adapter.Fill(dsSt, "Empty")
            DataGridView1.DataSource = dsSt.Tables(0)

        ElseIf cbSort.SelectedItem = "Senior Citizen" Then
            Dim dsSen As New DataSet
            adapter.Fill(dsSen, "Empty")
            DataGridView1.DataSource = dsSen.Tables(0)

        ElseIf cbSort.SelectedItem = "PWD" Then
            Dim dsP As New DataSet
            adapter.Fill(dsP, "Empty")
            DataGridView1.DataSource = dsP.Tables(0)

        ElseIf cbSort.SelectedItem = "All" Then
            adapter.Fill(ds, "Empty")
            DataGridView1.DataSource = ds.Tables(0)
        End If
        connect.Close()
    End Sub

    Private Sub Residents_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        List()
        Autogen()
        Popo()
        Voters()
        Students()
        Senior()
        PWD()

    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Search()
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

    Private Sub txtAge_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAge.KeyPress
        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Then
            e.Handled = False

        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtHousehold_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtHousehold.KeyPress
        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Then
            e.Handled = False

        Else
            e.Handled = True
            MessageBox.Show("Numbers keyword only.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            If Not ((Asc(e.KeyChar) >= 97 And Asc(e.KeyChar) <= 122) Or (Asc(e.KeyChar) >= 65 And Asc(e.KeyChar) <= 90) Or (Asc(e.KeyChar) = Keys.Space)) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtPOB_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPOB.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            If Not ((Asc(e.KeyChar) >= 97 And Asc(e.KeyChar) <= 122) Or (Asc(e.KeyChar) >= 65 And Asc(e.KeyChar) <= 90) Or (Asc(e.KeyChar) = Keys.Space)) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtOccupation_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOccupation.KeyPress
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

    Private Sub dtpDOB_ValueChanged(sender As Object, e As EventArgs) Handles dtpDOB.ValueChanged
        'AUTO GENERATED AGE FOR THE BIRTHDATE IF YOU SET IT FROM THE DATE
        With dtpDOB.Value
            Dim bdate As DateTime = New DateTime(Now.Year, .Month, .Day)
            Dim age As Integer = Now.Year - .Year
            If bdate > Now Then age -= 1
            txtAge.Text = CStr(age)
        End With
    End Sub

    Private Sub DataGridView1_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles DataGridView1.DataBindingComplete
        'NOT AUTO SELECT SO YOU GONNA CLICK FROM DATA ROW FIRST
        DataGridView1.ClearSelection()
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        'UNABLE TO CLICK BUTTONS IF THE DATA IS NOT SELECTED
        If DataGridView1.SelectedRows.Count = True Then
            btnAdd.Enabled = (DataGridView1.SelectedRows.Count > 0)
        Else
            btnAdd.Enabled = (DataGridView1.SelectedRows.Count = 0)
            btnEdit.Enabled = (DataGridView1.SelectedRows.Count > 0)
            btnUpdate.Enabled = (DataGridView1.SelectedRows.Count > 0)
            btnDelete.Enabled = (DataGridView1.SelectedRows.Count > 0)
        End If
    End Sub

    Private Sub cbSort_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSort.SelectedIndexChanged
        Filter()
    End Sub

    Private Sub txtBlock_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBlock.KeyPress
        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Then
            e.Handled = False

        Else
            e.Handled = True
            MessageBox.Show("Numbers keyword only.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

End Class