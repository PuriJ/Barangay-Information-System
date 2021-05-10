Imports MySql.Data.MySqlClient

Public Class Login
    Dim ctr = 0
    Dim strsql As String
    Dim cmd As New MySqlCommand
    Dim adapt As New MySqlDataAdapter
    Dim acc As New Maintenance
    Dim f As New Form

    Private Sub Login()
        'Login
        If txtUser.Text = "" Or txtPass.Text = "" Then
            txtUser.ResetText()
            txtPass.ResetText()
            txtUser.Focus()
            MessageBox.Show("Fill the Username or Password before you login.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Else
            Dim obj As New MySqlDataAdapter("SELECT * FROM tbl_account WHERE Username = '" & txtUser.Text & "' AND Password = '" & txtPass.Text & "'", connect)
            bdt.Clear()
            obj.Fill(bdt)

            If bdt.Rows.Count = Nothing Then
                ctr = ctr + 1

                'TIMER TICK IF ATTEMPT IS 3 AND LOCK IF IT REACH 3 ATTEMPTS
                If ctr = 3 Then
                    ctr = 0
                    txtUser.Enabled = False
                    txtPass.Enabled = False
                    btnLogin.Enabled = False
                    btnExit.Enabled = False
                    txtUser.Text = ""
                    txtPass.Text = ""
                    txtUser.Focus()
                    MessageBox.Show("You've reached the maximum attempt, 3 out of 3. Please wait for 30 seconds and try again.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Timer1.Enabled = True

                Else
                    txtUser.ResetText()
                    txtPass.ResetText()
                    txtUser.Focus()
                    MessageBox.Show("Invalid Username or Password, please try again. (Attempt " & ctr.ToString & " out of 3.)", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End If

            Else
                If bdt.Rows.Count > 0 Then
                    Dim userType, name As String
                    userType = bdt.Rows(0).Item(3)
                    name = bdt.Rows(0).Item(4)

                    If userType = "Admin" Then
                        txtUser.Clear()
                        txtPass.Clear()
                        MessageBox.Show("Welcome " & name & ". You logged in as Administrator.", "Brgy. Unang Sigaw", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Admin.Show()

                        'LOG ACTIVITY
                        connect.Open()
                        cmd = connect.CreateCommand
                        cmd.CommandText = "INSERT INTO tbl_logs(User_No, Last_Name, First_Name, User_Type, Time_In, Date, Activity) VALUES (@UserNo, @Last, @First, @Utype, @TimeIn, @Date, @Act)"

                        cmd.Parameters.AddWithValue("@UserNo", bdt.Rows(0).Item(0))
                        cmd.Parameters.AddWithValue("@Last", bdt.Rows(0).Item(4))
                        cmd.Parameters.AddWithValue("@First", bdt.Rows(0).Item(5))
                        cmd.Parameters.AddWithValue("Utype", bdt.Rows(0).Item(3))
                        cmd.Parameters.AddWithValue("@TimeIn", DateTime.Now.ToLongTimeString)
                        cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToShortDateString)
                        cmd.Parameters.AddWithValue("@Act", "Admin Logged In")
                        cmd.ExecuteNonQuery()
                        connect.Close()

                        Me.Hide()
                        ctr = 0

                    ElseIf userType = "Employee" Then
                        txtUser.Clear()
                        txtPass.Clear()
                        MessageBox.Show("Welcome " & name & ". You logged in as Employee.", "Brgy. Unang Sigaw", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Employee.Show()

                        'LOG ACTIVITY
                        connect.Open()
                        cmd = connect.CreateCommand
                        cmd.CommandText = "INSERT INTO tbl_logs(User_No, Last_Name, First_Name, User_Type, Time_In, Date, Activity) VALUES (@UserNo, @Last, @First, @Utype, @TimeIn, @Date, @Act)"

                        cmd.Parameters.AddWithValue("@UserNo", bdt.Rows(0).Item(0))
                        cmd.Parameters.AddWithValue("@Last", bdt.Rows(0).Item(4))
                        cmd.Parameters.AddWithValue("@First", bdt.Rows(0).Item(5))
                        cmd.Parameters.AddWithValue("Utype", bdt.Rows(0).Item(3))
                        cmd.Parameters.AddWithValue("@TimeIn", DateTime.Now.ToLongTimeString)
                        cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToShortDateString)
                        cmd.Parameters.AddWithValue("@Act", "Employee Logged In")
                        cmd.ExecuteNonQuery()
                        connect.Close()

                        connect.Open()
                        Dim cmd1 As New MySqlCommand
                        Dim b

                        Me.Hide()
                        ctr = 0

                    End If
                End If
            End If
        End If
        adapt.Dispose()
        connect.Close()
        cmd.Dispose()
    End Sub

    Private Sub chkShowPass_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPass.CheckedChanged
        If txtPass.UseSystemPasswordChar = True Then

            'Show Password
            txtPass.UseSystemPasswordChar = False

        Else

            'Hide Password
            txtPass.UseSystemPasswordChar = True

        End If
    End Sub

    Private Sub btnLogin_Click_1(sender As Object, e As EventArgs) Handles btnLogin.Click
        Login()

    End Sub

    Private Sub btnExit_Click_1(sender As Object, e As EventArgs) Handles btnExit.Click
        'Exit form
        If MessageBox.Show("Do you want to logout?", "Login", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = vbYes Then
            Me.Close()

        End If

    End Sub

    Private Sub txtUser_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUser.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLogin_Click_1(Nothing, Nothing)
        Else
            Exit Sub
        End If
        e.Handled = True
    End Sub

    Private Sub txtPass_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPass.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLogin_Click_1(Nothing, Nothing)
        Else
            Exit Sub
        End If
        e.Handled = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        txtUser.Enabled = True
        txtPass.Enabled = True
        btnLogin.Enabled = True
        btnExit.Enabled = True
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TIMER TICKS AND GOES BACK AFTER 30 SECS
        Timer1.Interval = 30000
        Timer1.Enabled = True
    End Sub

End Class
