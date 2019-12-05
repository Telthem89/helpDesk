Imports System.Data.OleDb
Module DatabaseConnection
    Dim MysqlConn As New OleDbConnection

    Public Function myconn() As OleDbConnection

        Return New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\query.mdb;")


    End Function
End Module
