Module RegisterReg_h
    Dim todayday As DateTime = Format("yyyy-mmm-dd", Today)
    Dim stnamests As String = "Student"
    'Generate RegisterID
    Public Sub GetRegisterID()
        Try
            Dim strLetter As String = DateTime.Now.ToString("yyyy")  '"C"    '+ 
            Dim transnum As String
            Dim count As Integer = 0
            findthis("SELECT Max(stid) From `studentAccount` where stid like '" & strLetter & "%'") ' top 1 stid
            con.Open()
            dReader = cmd.ExecuteReader()
            dReader.Read()
            If dReader.HasRows Then
                transnum = dReader(0).ToString
                count = Integer.Parse(transnum.Substring(4, 4))
                Register.txtReg.Text = strLetter & (count + count + 1)

            Else
                transnum = strLetter + "1011"  '1440405
                Register.txtReg.Text = transnum
            End If
            dReader.Close()
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        con.Close()
    End Sub


    Public Sub GenerateNumber()
        Try
            findthis("SELECT Max(stid) From `studentAccount`")
            con.Open()
            Dim num As Integer = cmd.ExecuteScalar
            Register.txtReg.Text = num + 1
            If Register.txtReg.Text = "" Then
                Register.txtReg.Text = ""
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        con.Close()
    End Sub

    Public Sub CreateAccount()
        If Register.txtName.Text = "" Then
            MsgBox("Name is Required!")
        ElseIf Register.txtSurn.Text = "" Then
            MsgBox("Surname is Required!")
        ElseIf Register.txtAddress.Text = "" Then
            MsgBox("Address is Required!")
        ElseIf Register.txtNationality.Text = "" Then
            MsgBox("Nationality is Required!")
        ElseIf Register.txtGuid.Text = "" Then
            MsgBox("Guidance's name is Required!")
        ElseIf Register.txtPhone.Text = "" Then
            MsgBox("Phone Number is Required!")
        ElseIf Register.cboClass.Text = "" Then
            MsgBox("Please select class!")
        ElseIf Register.cboGender.Text = "" Then
            MsgBox("Please select gender!")
        Else
            cmd.Parameters.AddWithValue("@stid", Register.txtReg.Text)
            cmd.Parameters.AddWithValue("@name", Register.txtName.Text)
            cmd.Parameters.AddWithValue("@surname", Register.txtSurn.Text)
            cmd.Parameters.AddWithValue("@dateOfBirth", Register.DOBPick.Text)
            cmd.Parameters.AddWithValue("@gender", Register.cboGender.Text)
            cmd.Parameters.AddWithValue("@nationality", Register.txtNationality.Text)
            cmd.Parameters.AddWithValue("@class", Register.cboClass.Text)
            cmd.Parameters.AddWithValue("@address", Register.txtAddress.Text)
            cmd.Parameters.AddWithValue("@guidanceName", Register.txtGuid.Text)
            cmd.Parameters.AddWithValue("@phone", Register.txtPhone.Text)
            cmd.Parameters.AddWithValue("@date_registered", todayday)

                issucess = insert("INSERT INTO `studentAccount` (`stid`,`name`,`surname`,`dateOfBirth`,`gender`, `nationality`, `class`, `address`, `guidanceName`, `phone`,`date_registered`)  VALUES (@stid, @name, @surname,@dateOfBirth,@gender, @nationality, @class,@address, @guidanceName, @phone,@date_registered);")

            
                If issucess = True Then
                    MsgBox("You successfully created An Account!", MsgBoxStyle.Information)
                insert("INSERT INTO account (`name`,`surname`,`username`,`userType`,`gender`) VALUES('" & Register.txtName.Text & "','" & Register.txtSurn.Text & "','" & Register.txtReg.Text & "','" & stnamests & "','" & Register.cboGender.Text & "')")
                   
                    Login.Show()
                    Register.Hide()
                    Register.txtReg.Text = ""
                    Register.txtName.Text = ""
                    Register.txtAddress.Text = ""
                    Register.txtSurn.Text = ""
                    Register.txtGuid.Text = " "
                    Register.txtNationality.Text = ""
                    Register.txtPhone.Text = ""
                Else
                    MsgBox("Error occured while trying to process your detail, try again!", MsgBoxStyle.Critical)
                End If
            End If

    End Sub



    '================================User Login========================
    
End Module
