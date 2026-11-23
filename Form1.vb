Imports System.Data.OleDb
Imports System.Drawing.Text
Imports System.Runtime.CompilerServices.RuntimeHelpers
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Public Class Form1
    Dim conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\book.mdb")
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Bi_Data()
    End Sub
    Private Sub Bi_Data()
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\book.mdb")
        Dim cmd2 As New OleDbCommand("SELECT * from emp order by phoneno", conn)

        Dim da As New OleDbDataAdapter
        da.SelectCommand = cmd2
        Dim ta As New DataTable
        ta.Clear()

        Dim v = da.Fill(ta)
        DataGridView1.DataSource = ta
        DataGridView1.Visible = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim str As String

        str = "insert into emp(phoneno,fname,lname,job,mgr,hiredate,sal,comm,deptno) values(@phoneno,@fname,@lname,@job,@mgr,@hiredate,@sal,@comm,@deptno)"

        Dim cmd1 As New OleDbCommand(str, conn)
        cmd1.Parameters.AddWithValue("@phoneno", TextBox1.Text)
        cmd1.Parameters.AddWithValue("@fname", TextBox2.Text)
        cmd1.Parameters.AddWithValue("@lname", TextBox3.Text)
        cmd1.Parameters.AddWithValue("@job", TextBox4.Text)
        cmd1.Parameters.AddWithValue("@mgr", TextBox5.Text)
        cmd1.Parameters.AddWithValue("@hiredate", TextBox6.Text)
        cmd1.Parameters.AddWithValue("@sal", TextBox7.Text)
        cmd1.Parameters.AddWithValue("@comm", TextBox8.Text)
        cmd1.Parameters.AddWithValue("@deptno", TextBox9.Text)



        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If



        cmd1.ExecuteNonQuery()


        conn.Close()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Focus()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Focus()
        TextBox9.Focus()

        Bi_Data()
    End Sub



    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) Then
            e.Handled = True
            MsgBox("only number")
        End If
    End Sub



    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        TextBox7.Text = DateTimePicker1.Value
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Hide()
        Form2.Show()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()

    End Sub

    'Private Sub TextBox7_Leave(sender As Object, e As EventArgs) Handles TextBox7.Leave
    'If String.IsNullOrEmpty(TextBox7.Text) Then Exit Sub
    'If Not IsDate(TextBox7) Then
    ' MsgBox("Please enter a valid date.", vbCritical)
    'TextBox7.SelectionStart = 0
    'TextBox7.SelectionLength = Len(TextBox7)
    'TextBox7.Focus()
    'End If
    'End Sub
End Class
