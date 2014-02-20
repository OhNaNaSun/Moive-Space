Imports System.Data.SqlClient

Public Class LoginForm2

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim username As SqlParameter, password As SqlParameter, rtn As SqlParameter
        Dim mycommand As New SqlCommand("register", myconnection)
        mycommand.CommandType = CommandType.StoredProcedure
        username = mycommand.Parameters.Add("@username", SqlDbType.NVarChar, 100)
        password = mycommand.Parameters.Add("@password", SqlDbType.NVarChar, 20)
        rtn = mycommand.Parameters.Add("", SqlDbType.Int)
        username.Value = Trim(UsernameTextBox.Text)
        password.Value = Trim(PasswordTextBox.Text)
        rtn.Direction = ParameterDirection.ReturnValue
        Try
            myconnection.Open()
            mycommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If rtn.Value = 1 Then
                logged = 1
                Form1.Button10.Text = "注销"
                Form1.Button11.Enabled = False
                Module1.username = username.Value
                MsgBox("注册成功，已经自动登录")
                Me.Close()
            End If
            myconnection.Close()
        End Try
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

End Class
