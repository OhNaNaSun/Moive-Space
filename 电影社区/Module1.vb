Imports System.Data.SqlClient

Module Module1
    Public Const connectionstring = "Data Source=(local);Initial Catalog=电影社区;Integrated Security=True"
    Public myconnection As New SqlConnection(connectionstring) '控制连接的变量
    Public myreader As SqlDataReader '取回结果的变量
    Public logged As Integer, username As String
End Module
