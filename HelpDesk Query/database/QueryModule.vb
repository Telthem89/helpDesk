Imports System.Data.OleDb
Module sqlstatements
    Public Sub findthis(ByVal sql As String)
        Try
            con.Open()
            With cmd
                .Connection = con
                .CommandText = sql
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        Finally
            con.Close()
            da.Dispose()
        End Try
    End Sub

    Public Sub LoadSingleResult(ByVal param As String)
        Try
            con.Open()
            dReader = cmd.ExecuteReader()
            Select Case param

                Case "login"
                    Do While dReader.Read = True

                        ACCOUNT_NAME = dReader("name") & " " & dReader("surname")
                        ACCOUNT_USERNAME = dReader("username")
                        ACCOUNT_TYPE = dReader("userType")



                        If ACCOUNT_TYPE = "Administrator" Then
                            Dashboard.Show()
                            Dashboard.btnLogout.Text = ACCOUNT_NAME
                            Login.Hide()

                        ElseIf ACCOUNT_TYPE = "Student" Then
                            ' splash.Show()
                            ' POS.btnLogout.Text = ACCOUNT_NAME
                            'POS.lblUser.Text = ACCOUNT_TYPE
                            Login.Hide()

                        ElseIf ACCOUNT_TYPE = "Headmaster" Then
                            ' splash.Show()
                            ' POS.btnLogout.Text = ACCOUNT_NAME
                            'POS.lblUser.Text = ACCOUNT_TYPE
                            Login.Hide()

                        ElseIf ACCOUNT_TYPE = "Teacher" Then
                            ' splash.Show()
                            ' POS.btnLogout.Text = ACCOUNT_NAME
                            'POS.lblUser.Text = ACCOUNT_TYPE
                            Login.Hide()


                        ElseIf ACCOUNT_TYPE = "Accounts" Then
                            ' splash.Show()
                            ' POS.btnLogout.Text = ACCOUNT_NAME
                            'POS.lblUser.Text = ACCOUNT_TYPE
                            Login.Hide()

                        Else
                            MsgBox("Please contact the IT Department for Account Activation", MsgBoxStyle.Exclamation)
                        End If
                    Loop



            End Select

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        Finally
            con.Close()
            da.Dispose()
        End Try
    End Sub


End Module
