Imports System.Data.SqlClient

Public Class LoginForm1
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim username As SqlParameter, password As SqlParameter, rtn As SqlParameter
        Dim mycommand As New SqlCommand("logging", myconnection)
        mycommand.CommandType = CommandType.StoredProcedure
        username = mycommand.Parameters.Add("@username", SqlDbType.NVarChar, 100)
        password = mycommand.Parameters.Add("@password", SqlDbType.NVarChar, 20)
        rtn = mycommand.Parameters.Add("", SqlDbType.Int)
        username.Value = UsernameTextBox.Text
        password.Value = PasswordTextBox.Text
        rtn.Direction = ParameterDirection.ReturnValue
        Try
            myconnection.Open()
            mycommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            myconnection.Close()
            Select Case rtn.Value
                Case 2
                    logged = 2
                    Form1.Button10.Text = "注销"
                    Form1.Button11.Enabled = False
                    Module1.username = username.Value
                    MsgBox("登录成功")
                    Form1.GroupBox1.Visible = True
                    AddUsers()
                    Me.Close()
                Case 1
                    logged = 1
                    Form1.Button10.Text = "注销"
                    Form1.Button11.Enabled = False
                    Module1.username = username.Value
                    MsgBox("登录成功")
                    Me.Close()
                Case Else
                    logged = 0
            End Select
        End Try
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub AddUsers()
        Dim mycommand As New SqlCommand("SELECT users.uname FROM users", myconnection)
        Form1.ComboBox1.Items.Clear()
        myconnection.Open()
        myreader = mycommand.ExecuteReader()
        Do While myreader.Read()
            Form1.ComboBox1.Items.Add(myreader.GetValue(0).ToString())
        Loop
        myconnection.Close()
    End Sub
End Class
