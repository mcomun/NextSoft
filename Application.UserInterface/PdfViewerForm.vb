Imports System.IO

Public Class PdfViewerForm
    Friend pathpdf As String = ""

    Private Sub IncoiceViewerForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If System.IO.File.Exists(pathpdf) Then
            Try
                pdfViewerDocs.LoadDocument(pathpdf)
                pdfViewerDocs.ZoomMode = DevExpress.XtraPdfViewer.PdfZoomMode.FitToVisible
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub pdfFileSaveBarItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles pdfFileSaveBarItem1.ItemClick
        saveFileDialog1.Filter = "PDF file (*.pdf)|*.pdf"
        saveFileDialog1.FileName = Path.GetFileName(pathpdf)
        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim newFile As String = saveFileDialog1.FileName
            File.Copy(pathpdf, newFile)
        End If
    End Sub
End Class