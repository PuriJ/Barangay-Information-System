Imports MySql.Data.MySqlClient
Public Class account
    Public strsql As String
    Public ds As New DataSet
    Public cmd As New MySqlCommand
    Public dr As MySqlDataReader
    Dim a, b, c, d

    Public Sub list()
        strsql = "select * from accounts"
        connect.Open()
        cmd = New MySqlCommand(strsql, connect)
        dr = cmd.ExecuteReader()
        ListView1.Items.Clear()

        Do While dr.Read()

            a = (dr.Item("username").ToString())
            b = (dr.Item("password").ToString())
            c = (dr.Item("name").ToString())
            d = (dr.Item("usertype").ToString())

            Dim lv As ListViewItem = ListView1.Items.Add(a)
            lv.SubItems.Add(b)
            lv.SubItems.Add(c)
            lv.SubItems.Add(d)

        Loop
        dr.Close()
        cmd.Dispose()
        connect.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim save As String

        save = MessageBox.Show("Are you sure you want to Save", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If save = vbYes Then

            strsql = "Insert accounts set username = '" & txtuser.Text & "', password = '" & txtpass.Text & "', name = '" & txtn.Text & "',usertype ='" & cmbusertype.Text & "'"
            Dim da As New MySqlDataAdapter(strsql, connect)
            da.Fill(ds)

            txtuser.Text = ""
            txtpass.Text = ""
            txtn.Text = ""
            cmbusertype.Text = ""
            list()
        End If
    End Sub

    Private Sub account_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        list()
    End Sub
End Class