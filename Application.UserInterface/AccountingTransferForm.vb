Public Class AccountingTransferForm
    Dim oAppService As New AppService.DelfinServiceClient
    Public AppUser As String = "sistemas"

    Private Sub AccountingTransferForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gcMainData.MainView.RestoreLayoutFromRegistry(IO.Directory.GetCurrentDirectory)
        deDateFrom.EditValue = DateAdd(DateInterval.Day, -90, Now)
        deDateTo.EditValue = Now
        'LoadBusinessUnit()
    End Sub

    'Private Sub LoadBusinessUnit()
    '    Dim dtQuery As New DataTable
    '    dtQuery = oAppService.ExecuteSQL("EXEC NextSoft.dgp.paListaLineaNegocio").Tables(0)
    '    lueBusinessUnit.Properties.DataSource = dtQuery
    '    lueBusinessUnit.Properties.DisplayMember = "DescripcionLineaNegocio"
    '    lueBusinessUnit.Properties.ValueMember = "CodigoLineaNegocio"
    'End Sub

    Private Sub bbiSearch_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiSearch.ItemClick
        Dim dtSource As New DataTable
        dtSource = oAppService.ExecuteSQL("EXEC NextSoft.dgp.paObtieneStatementsPorNaveViaje '" & Format(deDateFrom.EditValue, "yyyyMMdd") & "','" & Format(deDateTo.EditValue, "yyyyMMdd") & "'").Tables(0)
        dtSource.Columns.Add("Checked", GetType(Boolean))
        gcMainData.DataSource = dtSource
        GridView1.BestFitColumns()
    End Sub

    Private Sub bbiTransfer_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiTransfer.ItemClick

    End Sub

    Private Sub bbiExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiExport.ItemClick

    End Sub

    Private Sub bbiClose_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiClose.ItemClick
        Close()
    End Sub

    Private Sub AccountingTransferForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        gcMainData.MainView.SaveLayoutToRegistry(IO.Directory.GetCurrentDirectory)
    End Sub
End Class