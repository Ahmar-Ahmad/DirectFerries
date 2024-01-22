
Partial Class _Default
    Inherits System.Web.UI.Page
    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        lblMessage.Text = ""
        If txtFullName.Text = "" Or txtDOB.Text = "" Then
            lblMessage.Text = "Please enter fullname and dob"
            Exit Sub

        ElseIf InStr(txtFullName.Text, " ") < 1 Then
            lblMessage.Text = "Please enter fullname"
            Exit Sub
        ElseIf txtDOB.Text <> "" Then

            Try
                Dim actualdate As Date = CDate(txtDOB.Text)
            Catch ex As Exception
                lblMessage.Text = "Please enter date of birth"
                Exit Sub
            End Try

        End If
        'valid enties for both fields, pass to process page
        Response.Redirect("process.aspx?fullname=" & txtFullName.Text & "&dob=" & txtDOB.Text)

    End Sub
End Class
