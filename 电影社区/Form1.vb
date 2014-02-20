Imports System.Data.SqlClient
Imports System.Text
Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim mycommand1 As New SqlCommand("select film.*,act.aaname from film,act where film.fname=act.afname and film.fbtime = act.afbtime and fname = '鸿门宴' and film.fbtime = 2011", myconnection)
        myconnection.Open()
        myreader = mycommand1.ExecuteReader()
        myreader.Read()
        Label1.Text = myreader.GetValue(0).ToString
        Label2.Text = "(" & myreader.GetValue(1).ToString & ")"
        Label3.Text = "导演：" & myreader.GetValue(7).ToString
        Label4.Text = "主演：" & myreader.GetValue(10).ToString
        Label5.Text = "制片地区/国家：" & myreader.GetValue(6).ToString
        Label6.Text = "片长：" & myreader.GetValue(4).ToString & "分钟"
        Label7.Text = "类型：" & myreader.GetValue(2).ToString
        Label8.Text = "上映时间：" & Mid(myreader.GetValue(5).ToString, 1, 10)
        myconnection.Close()

        Dim mycommand2 As New SqlCommand("select film.*,act.aaname from film,act where film.fname = act.afname and film.fbtime = act.afbtime and film.fname='泰坦尼克号' and fbtime=1997", myconnection)
        myconnection.Open()
        myreader = mycommand2.ExecuteReader()
        myreader.Read()
        Label16.Text = myreader.GetValue(0).ToString
        Label17.Text = "(" & myreader.GetValue(1).ToString & ")"
        Label18.Text = "导演：" & myreader.GetValue(7).ToString
        Label19.Text = "主演：" & myreader.GetValue(10).ToString
        Label20.Text = "制片地区/国家：" & myreader.GetValue(6).ToString
        Label21.Text = "片长：" & myreader.GetValue(4).ToString & "分钟"
        Label22.Text = "类型：" & myreader.GetValue(2).ToString
        Label23.Text = "上映时间：" & Mid(myreader.GetValue(5).ToString, 1, 10)
        myconnection.Close()

        Dim mycommand3 As New SqlCommand("hot_p", myconnection)
        mycommand3.CommandType = CommandType.StoredProcedure
        myconnection.Open()
        myreader = mycommand3.ExecuteReader()
        Do While myreader.Read()
            Dim a As String, b As String, c As String
            a = myreader.GetValue(0).ToString & "(" & myreader.GetValue(1).ToString & ")"
            a = a + Space(30 - Encoding.Default.GetByteCount(a))
            b = "类型：" & myreader.GetValue(2)
            b = b + Space(40 - Encoding.Default.GetByteCount(b))
            c = "导演：" & myreader.GetValue(7)
            ListBox1.Items.Add(a & b & c)
        Loop
        myconnection.Close()

        Dim mycommand4 As New SqlCommand("hh_p", myconnection)
        mycommand4.CommandType = CommandType.StoredProcedure
        myconnection.Open()
        myreader = mycommand4.ExecuteReader
        Do While myreader.Read()
            Dim a As String, b As String, c As String
            a = myreader.GetValue(0).ToString & "(" & myreader.GetValue(1).ToString & ")"
            a = a + Space(30 - Encoding.Default.GetByteCount(a))
            b = "类型：" & myreader.GetValue(2)
            b = b + Space(40 - Encoding.Default.GetByteCount(b))
            c = "导演：" & myreader.GetValue(7)
            ListBox5.Items.Add(a & b & c)
        Loop
        myconnection.Close()

        Dim mycommand5 As New SqlCommand("SELECT*FROM film where fn ='是'", myconnection)
        myconnection.Open()
        myreader = mycommand5.ExecuteReader()
        Do While myreader.Read()
            Dim a As String, b As String
            a = myreader.GetValue(0).ToString & "(" & myreader.GetValue(1).ToString & ")"
            a = a + Space(30 - Encoding.Default.GetByteCount(a))
            b = "导演：" & myreader.GetValue(7)
            b = b + Space(40 - Encoding.Default.GetByteCount(b))
            ListBox4.Items.Add(a & b)
        Loop
        myconnection.Close()

        Dim mycommand6 As New SqlCommand("SELECT * FROM film where fn is null", myconnection)
        myconnection.Open()
        myreader = mycommand6.ExecuteReader()
        Do While myreader.Read()
            Dim a As String, b As String
            a = myreader.GetValue(0).ToString & "(" & myreader.GetValue(1).ToString & ")"
            a = a + Space(30 - Encoding.Default.GetByteCount(a))
            b = "导演：" & myreader.GetValue(7)
            b = b + Space(40 - Encoding.Default.GetByteCount(b))
            ListBox2.Items.Add(a & b)
        Loop
        myconnection.Close()

        Dim mycommand7 As New SqlCommand("SELECT DISTINCT film.fname FROM film", myconnection)
        myconnection.Open()
        myreader = mycommand7.ExecuteReader()
        Do While myreader.Read()
            ComboBox7.Items.Add(myreader.GetValue(0).ToString())
        Loop
        myconnection.Close()

        Dim mycommand8 As New SqlCommand("SELECT * FROM comment", myconnection)
        TextBox4.Text = ""
        ListBox7.Items.Clear()
        myconnection.Open()
        myreader = mycommand8.ExecuteReader()
        Do While myreader.Read()
            Dim a As String = (myreader.GetValue(1).ToString) & "(" & (myreader.GetValue(2).ToString) & ")" & Space(6)
            Dim b As String = (myreader.GetValue(0).ToString) & ":" & Space(4)
            Dim c As String = (myreader.GetValue(3).ToString)
            TextBox4.Text &= a & b & c & vbCrLf & vbCrLf
            ListBox7.Items.Add(a & b & c)
        Loop
        myconnection.Close()


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim mycommand As New SqlCommand("p1", myconnection)
        mycommand.CommandType = CommandType.StoredProcedure
        Dim fname As SqlParameter = mycommand.Parameters.Add("@fname", SqlDbType.NVarChar, 40)
        myconnection.Open()
        fname.Value = Trim(TextBox1.Text)
        ListBox3.Items.Clear()
        Try
            myreader = mycommand.ExecuteReader()
            Do While myreader.Read()
                ListBox3.Items.Add(myreader.GetValue(0).ToString & "(" & myreader.GetValue(1).ToString & "    类型：" & myreader.GetValue(2) & "    导演：" _
                & myreader.GetValue(7) & "    制片地区/国家：" & myreader.GetValue(6))
            Loop
        Catch ex As Exception

        End Try
        myconnection.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim mycommand As New SqlCommand("p2", myconnection)
        mycommand.CommandType = CommandType.StoredProcedure
        Dim aname As SqlParameter = mycommand.Parameters.Add("@aname", SqlDbType.NVarChar, 40)
        myconnection.Open()
        aname.Value = Trim(TextBox2.Text)
        ListBox6.Items.Clear()
        Try
            myreader = mycommand.ExecuteReader()
            Do While myreader.Read()
                ListBox6.Items.Add(myreader.GetValue(0).ToString)
            Loop
        Catch ex As Exception

        End Try
        myconnection.Close()

        Dim mycommand1 As New SqlCommand("p3", myconnection)
        Dim dname As SqlParameter = mycommand1.Parameters.Add("@dname", SqlDbType.NVarChar, 40)
        myconnection.Open()
        dname.Value = Trim(TextBox2.Text)
        mycommand1.CommandType = CommandType.StoredProcedure
        Try
            myreader = mycommand1.ExecuteReader()
            Do While myreader.Read()
                ListBox6.Items.Add(myreader.GetValue(0).ToString)
            Loop
        Catch ex As Exception

        End Try
        myconnection.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If logged = 0 Then
            MsgBox("您还没有登录")
            Button10_Click(Button10, e)
            Exit Sub
        End If
        Dim fname As String, fbtime As Integer, uname As String
        fname = ComboBox7.SelectedItem
        fbtime = ComboBox8.SelectedItem
        uname = username
        'INSERT INTO comment VALUES ('A', 'B', 1998, 'abcd')
        Dim str As String = "INSERT INTO comment(cname, cfname, cfbtime, ccomment) VALUES ('" & uname & "', '" & fname & "', " & fbtime & ", '" & TextBox3.Text & "')"
        Dim mycommand As New SqlCommand(str, myconnection)
        myconnection.Open()
        mycommand.ExecuteNonQuery()
        myconnection.Close()

        TextBox4.Text = ""
        ListBox7.Items.Clear()
        mycommand.CommandText = "SELECT * FROM comment"
        myconnection.Open()
        myreader = mycommand.ExecuteReader()
        Do While myreader.Read()
            Dim a As String = (myreader.GetValue(1).ToString) & "(" & (myreader.GetValue(2).ToString) & ")" & Space(6)
            Dim b As String = (myreader.GetValue(0).ToString) & ":" & Space(4)
            Dim c As String = (myreader.GetValue(3).ToString)
            TextBox4.Text &= a & b & c & vbCrLf & vbCrLf
            ListBox7.Items.Add(a & b & c)
        Loop
        myconnection.Close()
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Dim mycommand As New SqlCommand("select film.*,act.aaname from film,act where film.fname=act.afname and film.fbtime = act.afbtime and fname = '鸿门宴'", myconnection)
        Dim fname As SqlParameter = mycommand.Parameters.Add("@fname", SqlDbType.NVarChar, 40)
        fname.Value = "鸿门宴"
        myconnection.Open()
        TabControl1.SelectTab(4)
        myreader = mycommand.ExecuteReader()
        myreader.Read()
        Label14.Text = myreader.GetValue(0).ToString
        Label15.Text = "(" & myreader.GetValue(1).ToString & ")"
        Label25.Text = "导演：" & myreader.GetValue(7).ToString
        Label26.Text = "主演：" & myreader.GetValue(10).ToString
        Label27.Text = "制片地区/国家：" & myreader.GetValue(6).ToString
        Label28.Text = "片长：" & myreader.GetValue(4).ToString & "分钟"
        Label29.Text = "类型：" & myreader.GetValue(2).ToString
        Label30.Text = "上映时间：" & myreader.GetValue(5).ToString
        TextBox31.Text = myreader.GetValue(3).ToString
        myconnection.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim mycommand As New SqlCommand("p_fname", myconnection)
        Dim fname As SqlParameter = mycommand.Parameters.Add("@fname", SqlDbType.NVarChar, 40)
        mycommand.CommandType = CommandType.StoredProcedure
        fname.Value = Mid(ListBox1.SelectedItem, 1, InStr(ListBox1.SelectedItem, "(") - 1)
        myconnection.Open()
        TextBox31.Location = New Point(TextBox31.Location.X, 265)
        TextBox31.Height = 243
        TabControl1.SelectTab(4)
        myreader = mycommand.ExecuteReader()
        myreader.Read()
        Label14.Text = myreader.GetValue(0).ToString
        Label15.Text = "(" & myreader.GetValue(1).ToString & ")"
        Label25.Text = "导演：" & myreader.GetValue(7).ToString
        Label26.Text = "主演：" & myreader.GetValue(10).ToString
        Label27.Text = "制片地区/国家：" & myreader.GetValue(6).ToString
        Label28.Text = "片长：" & myreader.GetValue(4).ToString & "分钟"
        Label29.Text = "类型：" & myreader.GetValue(2).ToString
        Label30.Text = "上映时间：" & myreader.GetValue(5).ToString
        TextBox31.Text = myreader.GetValue(3).ToString
        myconnection.Close()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim mycommand As New SqlCommand("p_fname", myconnection)
        Dim fname As SqlParameter = mycommand.Parameters.Add("@fname", SqlDbType.NVarChar, 40)
        mycommand.CommandType = CommandType.StoredProcedure
        fname.Value = Mid(ListBox5.SelectedItem, 1, InStr(ListBox5.SelectedItem, "(") - 1)
        myconnection.Open()
        TextBox31.Location = New Point(TextBox31.Location.X, 265)
        TextBox31.Height = 243
        TabControl1.SelectTab(4)
        myreader = mycommand.ExecuteReader()
        myreader.Read()
        Label14.Text = myreader.GetValue(0).ToString
        Label15.Text = "(" & myreader.GetValue(1).ToString & ")"
        Label25.Text = "导演：" & myreader.GetValue(7).ToString
        Label26.Text = "主演：" & myreader.GetValue(10).ToString
        Label27.Text = "制片地区/国家：" & myreader.GetValue(6).ToString
        Label28.Text = "片长：" & myreader.GetValue(4).ToString & "分钟"
        Label29.Text = "类型：" & myreader.GetValue(2).ToString
        Label30.Text = "上映时间：" & Mid(myreader.GetValue(5).ToString, 1, 10)
        TextBox31.Text = myreader.GetValue(3).ToString
        myconnection.Close()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim mycommand As New SqlCommand("p_fname", myconnection)
        Dim fname As SqlParameter = mycommand.Parameters.Add("@fname", SqlDbType.NVarChar, 40)
        mycommand.CommandType = CommandType.StoredProcedure
        fname.Value = Mid(ListBox4.SelectedItem, 1, InStr(ListBox4.SelectedItem, "(") - 1)
        myconnection.Open()
        TextBox31.Location = New Point(TextBox31.Location.X, 265)
        TextBox31.Height = 243
        TabControl1.SelectTab(4)
        myreader = mycommand.ExecuteReader()
        myreader.Read()
        Label14.Text = myreader.GetValue(0).ToString
        Label15.Text = "(" & myreader.GetValue(1).ToString & ")"
        Label25.Text = "导演：" & myreader.GetValue(7).ToString
        Label26.Text = "主演：" & myreader.GetValue(10).ToString
        Label27.Text = "制片地区/国家：" & myreader.GetValue(6).ToString
        Label28.Text = "片长：" & myreader.GetValue(4).ToString & "分钟"
        Label29.Text = "类型：" & myreader.GetValue(2).ToString
        Label30.Text = "上映时间：" & Mid(myreader.GetValue(5).ToString, 1, 10)
        TextBox31.Text = myreader.GetValue(3).ToString
        myconnection.Close()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim mycommand As New SqlCommand("p_fname", myconnection)
        Dim fname As SqlParameter = mycommand.Parameters.Add("@fname", SqlDbType.NVarChar, 40)
        mycommand.CommandType = CommandType.StoredProcedure
        fname.Value = Mid(ListBox2.SelectedItem, 1, InStr(ListBox2.SelectedItem, "(") - 1)
        myconnection.Open()
        TextBox31.Location = New Point(TextBox31.Location.X, 265)
        TextBox31.Height = 243
        TabControl1.SelectTab(4)
        myreader = mycommand.ExecuteReader()
        myreader.Read()
        Label14.Text = myreader.GetValue(0).ToString
        Label15.Text = "(" & myreader.GetValue(1).ToString & ")"
        Label25.Text = "导演：" & myreader.GetValue(7).ToString
        Label26.Text = "主演：" & myreader.GetValue(10).ToString
        Label27.Text = "制片地区/国家：" & myreader.GetValue(6).ToString
        Label28.Text = "片长：" & myreader.GetValue(4).ToString & "分钟"
        Label29.Text = "类型：" & myreader.GetValue(2).ToString
        Label30.Text = "上映时间：" & Mid(myreader.GetValue(5).ToString, 1, 10)
        TextBox31.Text = myreader.GetValue(3).ToString
        myconnection.Close()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim mycommand As New SqlCommand("p_fname", myconnection)
        Dim fname As SqlParameter = mycommand.Parameters.Add("@fname", SqlDbType.NVarChar, 40)
        mycommand.CommandType = CommandType.StoredProcedure
        fname.Value = Mid(ListBox3.SelectedItem, 1, InStr(ListBox3.SelectedItem, "(") - 1)
        myconnection.Open()
        TextBox31.Location = New Point(TextBox31.Location.X, 265)
        TextBox31.Height = 243
        TabControl1.SelectTab(4)
        myreader = mycommand.ExecuteReader()
        myreader.Read()
        Label14.Text = myreader.GetValue(0).ToString
        Label15.Text = "(" & myreader.GetValue(1).ToString & ")"
        Label25.Text = "导演：" & myreader.GetValue(7).ToString
        Label26.Text = "主演：" & myreader.GetValue(10).ToString
        Label27.Text = "制片地区/国家：" & myreader.GetValue(6).ToString
        Label28.Text = "片长：" & myreader.GetValue(4).ToString & "分钟"
        Label29.Text = "类型：" & myreader.GetValue(2).ToString
        Label30.Text = "上映时间：" & Mid(myreader.GetValue(5).ToString, 1, 10)
        TextBox31.Text = myreader.GetValue(3).ToString
        myconnection.Close()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim mycommand As New SqlCommand("p_aname", myconnection)
        Dim fname As SqlParameter = mycommand.Parameters.Add("@aname", SqlDbType.NVarChar, 40)
        mycommand.CommandType = CommandType.StoredProcedure
        fname.Value = Trim(ListBox6.SelectedItem)
        myconnection.Open()
        TextBox31.Location = New Point(TextBox31.Location.X, 77)
        TextBox31.Height = 431
        TabControl1.SelectTab(4)
        myreader = mycommand.ExecuteReader()
        If myreader.Read() = True Then
            Label14.Text = myreader.GetValue(0).ToString
            TextBox31.Text = "获奖情况：" & vbCrLf & myreader.GetValue(2).ToString & vbCrLf & vbCrLf
            TextBox31.Text &= "主要作品：" & vbCrLf & myreader.GetValue(3).ToString & vbCrLf & vbCrLf
            TextBox31.Text &= "人物介绍：" & vbCrLf & myreader.GetValue(1).ToString & vbCrLf & vbCrLf
        End If
        myconnection.Close()

        Dim mycommand1 As New SqlCommand("p_dname", myconnection)
        Dim fname1 As SqlParameter = mycommand1.Parameters.Add("@dname", SqlDbType.NVarChar, 40)
        mycommand1.CommandType = CommandType.StoredProcedure
        fname1.Value = Trim(ListBox6.SelectedItem)
        myconnection.Open()
        myreader = mycommand1.ExecuteReader()
        If myreader.Read() = True Then
            Label14.Text = myreader.GetValue(0).ToString
            TextBox31.Text = "获奖情况：" & vbCrLf & myreader.GetValue(2).ToString & vbCrLf & vbCrLf
            TextBox31.Text &= "主要作品：" & vbCrLf & myreader.GetValue(3).ToString & vbCrLf & vbCrLf
            TextBox31.Text &= "人物介绍：" & vbCrLf & myreader.GetValue(1).ToString & vbCrLf & vbCrLf
        End If
        myconnection.Close()
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Dim mycommand As New SqlCommand("select film.*,act.aaname from film,act where film.fname = act.afname and film.fbtime = act.afbtime and film.fname='泰坦尼克号' and fbtime=1997", myconnection)
        Dim fname As SqlParameter = mycommand.Parameters.Add("@fname", SqlDbType.NVarChar, 40)
        fname.Value = "泰坦尼克号"
        myconnection.Open()
        TabControl1.SelectTab(4)
        myreader = mycommand.ExecuteReader()
        myreader.Read()
        Label14.Text = myreader.GetValue(0).ToString
        Label15.Text = "(" & myreader.GetValue(1).ToString & ")"
        Label25.Text = "导演：" & myreader.GetValue(7).ToString
        Label26.Text = "主演：" & myreader.GetValue(10).ToString
        Label27.Text = "制片地区/国家：" & myreader.GetValue(6).ToString
        Label28.Text = "片长：" & myreader.GetValue(4).ToString & "分钟"
        Label29.Text = "类型：" & myreader.GetValue(2).ToString
        Label30.Text = "上映时间：" & Mid(myreader.GetValue(5).ToString, 1, 10)
        TextBox31.Text = myreader.GetValue(3).ToString
        myconnection.Close()
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        If logged = 0 Then
            LoginForm1.ShowDialog()
        Else
            logged = 0
            Button10.Text = "登录"
            Button11.Enabled = True
            GroupBox1.Visible = False
            username = ""
        End If
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        LoginForm2.ShowDialog()
    End Sub

    Private Sub ComboBox7_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox7.SelectedIndexChanged
        ComboBox8.Items.Clear()
        If ComboBox7.SelectedIndex = -1 Then
            ComboBox8.Enabled = False
        Else
            Dim fname As String = ComboBox7.SelectedItem
            Dim mycommand As New SqlCommand("SELECT film.fbtime FROM film WHERE film.fname = '" & fname & "'", myconnection)
            myconnection.Open()
            myreader = mycommand.ExecuteReader()
            Do While myreader.Read()
                ComboBox8.Items.Add(myreader.GetValue(0).ToString)
            Loop
            ComboBox8.Enabled = True
            myconnection.Close()
        End If
    End Sub

    Private Sub ComboBox8_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox8.SelectedIndexChanged
        If ComboBox8.SelectedIndex <> -1 Then
            TextBox3.Enabled = True
        Else
            TextBox3.Enabled = False
        End If
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        If Trim(TextBox3.Text) = "" Then
            Button3.Enabled = False
        Else
            Button3.Enabled = True
        End If
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Dim username As String = ComboBox1.SelectedItem
        If Module1.username = username Then
            MsgBox("不能删除自己")
            Exit Sub
        End If
        Dim mycommand As New SqlCommand("DELETE FROM users WHERE users.uname = '" & username & "'", myconnection)
        myconnection.Open()
        Try
            mycommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myconnection.Close()
        TextBox4.Text = ""
        ListBox7.Items.Clear()
        mycommand.CommandText = "SELECT * FROM comment"
        myconnection.Open()
        myreader = mycommand.ExecuteReader()
        Do While myreader.Read()
            Dim a As String = (myreader.GetValue(1).ToString) & "(" & (myreader.GetValue(2).ToString) & ")" & Space(6)
            Dim b As String = (myreader.GetValue(0).ToString) & ":" & Space(4)
            Dim c As String = (myreader.GetValue(3).ToString)
            TextBox4.Text &= a & b & c & vbCrLf & vbCrLf
            ListBox7.Items.Add(a & b & c)
        Loop
        myconnection.Close()
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        If ListBox7.SelectedIndex = -1 Then
            MsgBox("请选择一条评论")
            Exit Sub
        End If

        Dim s As String, user As String, fname As String, fbtime As Integer
        s = ListBox7.SelectedItem
        fname = Mid(s, 1, InStr(s, "(") - 1)
        fbtime = Val(Mid(s, InStr(s, "(") + 1, 4))
        user = Trim(Mid(s, InStr(s, ")") + 1, InStr(s, ":") - InStr(s, ")") - 1))
        Dim mycommand As New SqlCommand("DELETE FROM comment WHERE cname = '" & user & "' AND cfname = '" & fname & "' AND cfbtime = " & fbtime, myconnection)
        myconnection.Open()
        mycommand.ExecuteNonQuery()
        myconnection.Close()
        TextBox4.Text = ""
        ListBox7.Items.Clear()
        mycommand.CommandText = "SELECT * FROM comment"
        myconnection.Open()
        myreader = mycommand.ExecuteReader()
        Do While myreader.Read()
            Dim a As String = (myreader.GetValue(1).ToString) & "(" & (myreader.GetValue(2).ToString) & ")" & Space(6)
            Dim b As String = (myreader.GetValue(0).ToString) & ":" & Space(4)
            Dim c As String = (myreader.GetValue(3).ToString)
            TextBox4.Text &= a & b & c & vbCrLf & vbCrLf
            ListBox7.Items.Add(a & b & c)
        Loop
        myconnection.Close()
    End Sub
End Class
