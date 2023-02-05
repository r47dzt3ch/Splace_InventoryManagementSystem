Imports System.Windows.Forms

Public Class mdi_dashboard
    Dim mdiC_nR_ As New frm_newRecord
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        mdiC_nR_.MdiParent = Me
        mdiC_nR_.Show()

    End Sub
End Class
