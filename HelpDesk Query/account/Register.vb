Public Class Register
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Login.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Login.Show()
        Me.Hide()
    End Sub

    Private Sub Register_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'GetRegisterID()
        GenerateNumber()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnReg.Click
        If (DOBPick.Text >= DateTime.Now.ToShortDateString) Then
            MsgBox("We don't enroll future students here! Please provide correct date of birth")
        Else
            If btnReg.Text = "Create Account" Then
                CreateAccount()

            End If
        End If
    End Sub
End Class