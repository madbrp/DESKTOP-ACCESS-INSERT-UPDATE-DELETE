Imports System.Data.OleDb
Imports System.Drawing.Text
Imports System.Runtime.CompilerServices.RuntimeHelpers
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Public Class Form2
    Dim conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\book.mdb")
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Bi_Data()
    End Sub
    Private Sub Bi_Data()
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\book.mdb")
        Dim cmd2 As New OleDbCommand("SELECT * from ddate ", conn)

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

        str = "insert into ddate(sdate) values(@sdate)"

        Dim cmd1 As New OleDbCommand(str, conn)
        cmd1.Parameters.AddWithValue("@sdate", TextBox1.Text)
        conn.Open()

        cmd1.ExecuteNonQuery()
        conn.Close()
        MsgBox("Inserted")

        Bi_Data()

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        TextBox1.Text = DateTimePicker1.Value
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Form1.Show()

    End Sub
End Class