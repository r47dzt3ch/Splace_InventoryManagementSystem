Public Class frm_login
    Dim login_queery As String
    Private Sub btn_login_Click(sender As Object, e As EventArgs) Handles btn_login.Click
        login_queery = "Select admin_uname,admin_password from tbl_administrator where admin_uname='" + txtb_uname.Text.ToString() + "' and admin_password='" + txtb_pass.Text.ToString + "'"
        _dbConnection("db_splaceims")

        Try
            _retrieveData(login_queery)
            If result = 1 Then
                MessageBox.Show("Login Succesfully")
                Me.Hide()
                mdi_dashboard.Show()
            Else
                MessageBox.Show("Wrong Password Please Try Again!")
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
