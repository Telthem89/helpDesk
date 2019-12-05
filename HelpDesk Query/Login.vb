Public Class Login
    Dim newpoints As System.Drawing.Point
    Dim x, y As Integer
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ActiveControl = GroupBox1
    End Sub

    Private Sub txtUser_Click(sender As Object, e As EventArgs) Handles txtUser.Click
        If txtUser.Text = "Enter Username" Then
            txtUser.Text = ""
            txtUser.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtUser_Leave(sender As Object, e As EventArgs) Handles txtUser.Leave
        If txtUser.Text = "" Then
            txtUser.Text = "Enter Username"
            txtUser.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub TxtPass_Click(sender As Object, e As EventArgs) Handles txtPass.Click
        If txtPass.Text = "Enter Password" Then
            txtPass.Text = ""
            'txtPass.PasswordChar = "*"
            txtPass.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtPass_Leave(sender As Object, e As EventArgs) Handles txtPass.Leave
        If txtPass.Text = "" Then
            txtPass.Text = "Enter Password"
            txtPass.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Application.Exit()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Register.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtUser.Text = "" Then
            MsgBox("Username is required", MsgBoxStyle.Critical)

        ElseIf txtPass.Text = "" Then
            MsgBox("Password is required", MsgBoxStyle.Critical)

        Else
            sql = "SELECT * FROM `account` WHERE `username`='" & txtUser.Text & "' AND `password`='" & txtPass.Text & "' "
            findthis(sql)

            If GetNumRows() = 1 Then
                ' MsgBox("Logged in Successfully", MsgBoxStyle.Information)
                LoadSingleResult("login")

                txtPass.Text = ""
                txtUser.Text = ""

            Else
                MsgBox("Username or Passwrord is not correct, Please try again!!")
                txtPass.Text = ""
                txtUser.Text = ""

            End If
        End If
    End Sub

    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            newpoints = Control.MousePosition
            newpoints.X -= (x)
            newpoints.Y -= (y)

            Me.Location = newpoints
        End If
    End Sub
End Class
