Public Class SplashScreenForm

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Timer1.[Stop]()
            LoginForm.Show()
            Me.Hide()
        Catch generaedExceptionName As Exception
            Return
        End Try
    End Sub


End Class
