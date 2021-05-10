Imports MySql.Data.MySqlClient
Module Module1
    Public connString As String = "server = localhost; port = 3306; username = root; password =; database = brgy_db"
    Public connect As New MySqlConnection(connString)
    Public cmd As New MySqlCommand
    Public adapter As New MySqlDataAdapter
    Public bdt As New DataTable
    Public bdt1 As New DataTable
    Public bSource As New BindingSource
    Public ds As New DataSet
End Module
