Imports DevExpress.XtraSplashScreen
Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Public Class CreateMailItem
    Dim Application As New Outlook.Application
    Dim mail As Outlook.MailItem = Nothing
    Dim mailRecipients As Outlook.Recipients = Nothing
    Dim mailRecipient As Outlook.Recipient = Nothing

    Friend htmlBody As New RichTextBox
    Friend subject, mailTo, mailCc, mailBcc As String
    Friend aAttachment As ArrayList

    Friend Function CreateCustomMessage()

        Dim bResult As Boolean = True
        Try
            mail = Application.CreateItem(Outlook.OlItemType.olMailItem)
            mail.Subject = subject
            mail.HTMLBody = htmlBody.Text
            If Not mailTo Is Nothing Then
                mail.To = mailTo
            End If
            If Not mailCc Is Nothing Then
                mail.CC = mailCc
            End If
            If Not mailBcc Is Nothing Then
                mail.BCC = mailBcc
            End If
            If Not aAttachment Is Nothing Then
                For a = 0 To aAttachment.Count - 1
                    If IO.File.Exists(aAttachment(a)) Then
                        mail.Attachments.Add(aAttachment(a))
                    End If
                Next
            End If
            SplashScreenManager.ShowForm(Form.ActiveForm, GetType(WaitForm), True, True, False)
            SplashScreenManager.Default.SetWaitFormDescription("Creando nuevo mensaje")
            mail.Display()
            SplashScreenManager.CloseForm(False)
        Catch ex As Exception
            bResult = False
            SplashScreenManager.CloseForm(False)
            System.Windows.Forms.MessageBox.Show(ex.Message,
                "An exception is occured in the code of add-in.")
        Finally
            If Not IsNothing(mailRecipient) Then Marshal.ReleaseComObject(mailRecipient)
            If Not IsNothing(mailRecipients) Then Marshal.ReleaseComObject(mailRecipients)
            If Not IsNothing(mail) Then Marshal.ReleaseComObject(mail)
        End Try
        Return bResult
    End Function

    Friend Function SendCustomMessage()
        Dim bResult As Boolean = True

        Return bResult
    End Function

End Class
