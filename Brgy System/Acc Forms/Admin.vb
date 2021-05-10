Public Class Admin
    Dim f As New Form

    'BUTTON FOR USER ACCOUNT
    Private Sub btnAccount_Click(sender As Object, e As EventArgs) Handles btnAccount.Click
        Try
            f.Dispose()
            f = Maintenance
            f.TopLevel = False
            Panel2.Controls.Add(f)
            f.Location = New Point((Me.Width - f.Width) \ 948, (Me.Height - f.Height) \ 565) ''width moves left and right - Height moves up and down
            f.Show()
        Catch ex As Exception

        End Try

    End Sub

    'BUTTON FOR LOGOUT
    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        If MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            Login.Show()
            connect.Open()
            cmd = connect.CreateCommand
            cmd.CommandText = "INSERT INTO tbl_logs(User_No, Last_Name, First_Name, User_Type, Time_Out, Date, Activity) VALUES (@UserNo, @Last, @First, @Utype, @TimeOut, @Date, @Act)"

            cmd.Parameters.AddWithValue("@UserNo", bdt.Rows(0).Item(0))
            cmd.Parameters.AddWithValue("@Last", bdt.Rows(0).Item(4))
            cmd.Parameters.AddWithValue("@First", bdt.Rows(0).Item(5))
            cmd.Parameters.AddWithValue("Utype", bdt.Rows(0).Item(3))
            cmd.Parameters.AddWithValue("@TimeOut", DateTime.Now.ToLongTimeString)
            cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToShortDateString)
            cmd.Parameters.AddWithValue("@Act", "Admin Logged Out")
            cmd.ExecuteNonQuery()
            connect.Close()
            Me.Close()
        End If

    End Sub

    'BUTTON FOR RESIDENTS
    Private Sub btnResidents_Click(sender As Object, e As EventArgs) Handles btnResidents.Click
        Try
            f.Dispose()
            f = Residents
            f.TopLevel = False
            Panel2.Controls.Add(f)
            f.Location = New Point((Me.Width - f.Width) \ 948, (Me.Height - f.Height) \ 565) ''width moves left and right - Height moves up and down
            f.Show()
        Catch ex As Exception

        End Try
    End Sub

    'BUTTON FOR BARANGAY CLEARANCE
    Private Sub btnClearance_Click(sender As Object, e As EventArgs) Handles btnClearance.Click
        Try
            f.Dispose()
            f = bClearance
            f.TopLevel = False
            Panel2.Controls.Add(f)
            f.Location = New Point((Me.Width - f.Width) \ 948, (Me.Height - f.Height) \ 565) ''width moves left and right - Height moves up and down
            f.Show()
        Catch ex As Exception

        End Try
    End Sub

    'BUTTON FOR INDIGENCY
    Private Sub btnIndigency_Click(sender As Object, e As EventArgs) Handles btnIndigency.Click
        Try
            f.Dispose()
            f = bIndigency
            f.TopLevel = False
            Panel2.Controls.Add(f)
            f.Location = New Point((Me.Width - f.Width) \ 948, (Me.Height - f.Height) \ 565) ''width moves left and right - Height moves up and down
            f.Show()
        Catch ex As Exception

        End Try
    End Sub

    'BUTTON FOR ACTIVITY LOG (TRAIL AND AUDIT)
    Private Sub btnLogs_Click(sender As Object, e As EventArgs) Handles btnLogs.Click
        Try
            f.Dispose()
            f = Log
            f.TopLevel = False
            Panel2.Controls.Add(f)
            f.Location = New Point((Me.Width - f.Width) \ 948, (Me.Height - f.Height) \ 565) ''width moves left and right - Height moves up and down
            f.Show()
        Catch ex As Exception

        End Try
    End Sub

    'BUTTON FOR DEROGATORY
    Private Sub btnDerogatory_Click(sender As Object, e As EventArgs) Handles btnDerogatory.Click
        Try
            f.Dispose()
            f = Derog
            f.TopLevel = False
            Panel2.Controls.Add(f)
            f.Location = New Point((Me.Width - f.Width) \ 948, (Me.Height - f.Height) \ 565) ''width moves left and right - Height moves up and down
            f.Show()
        Catch ex As Exception

        End Try
    End Sub

    'BUTTON FOR RESIDENCY
    Private Sub btnResidency_Click(sender As Object, e As EventArgs) Handles btnResidency.Click
        Try
            f.Dispose()
            f = Residency
            f.TopLevel = False
            Panel2.Controls.Add(f)
            f.Location = New Point((Me.Width - f.Width) \ 948, (Me.Height - f.Height) \ 565) ''width moves left and right - Height moves up and down
            f.Show()
        Catch ex As Exception

        End Try
    End Sub

    'BUTTON FOR BUSINESS PERMIT
    Private Sub btnPermit_Click(sender As Object, e As EventArgs) Handles btnPermit.Click
        Try
            f.Dispose()
            f = bPermits
            f.TopLevel = False
            Panel2.Controls.Add(f)
            f.Location = New Point((Me.Width - f.Width) \ 948, (Me.Height - f.Height) \ 565) ''width moves left and right - Height moves up and down
            f.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        Try
            f.Dispose()
            f = Reports
            f.TopLevel = False
            Panel2.Controls.Add(f)
            f.Location = New Point((Me.Width - f.Width) \ 948, (Me.Height - f.Height) \ 565) ''width moves left and right - Height moves up and down
            f.Show()
        Catch ex As Exception

        End Try
    End Sub
End Class