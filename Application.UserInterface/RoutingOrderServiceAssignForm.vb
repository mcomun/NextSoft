Public Class RoutingOrderServiceAssignForm
    Dim oAppService As New AppService.DelfinServiceClient
    Public AppUser As String = "sistemas"

    Private Sub lueService_Properties_EditValueChanged(sender As Object, e As EventArgs) Handles lueService.Properties.EditValueChanged

    End Sub

    Private Sub RoutingOrderServiceAssignForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gcMainData.MainView.RestoreLayoutFromRegistry(IO.Directory.GetCurrentDirectory)
        deDateFrom.EditValue = DateAdd(DateInterval.Day, -30, Now)
        deDateTo.EditValue = Now
        LoadServices()
    End Sub

    Private Sub LoadServices()
        Dim dtQuery As New DataTable
        dtQuery = oAppService.ExecuteSQL("EXEC NextSoft.dgp.paListaServiciosMasivos").Tables(0)
        lueService.Properties.DataSource = dtQuery
        lueService.Properties.DisplayMember = "DescripcionServicioMasivo"
        lueService.Properties.ValueMember = "CodigoServicioMasivo"
    End Sub

    Private Sub bbiSearch_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiSearch.ItemClick
        If Not vpInputs.Validate Then
            Return
        End If
        Dim dtSource As New DataTable
        dtSource = oAppService.ExecuteSQL("EXEC NextSoft.dgp.paObtieneOperacionesComisionables 1, 1, '" & Format(deDateFrom.EditValue, "yyyyMMdd") & "','" & Format(deDateTo.EditValue, "yyyyMMdd") & "'," & lueService.EditValue.ToString).Tables(0)
        dtSource.Columns.Add("Checked", GetType(Boolean))
        gcMainData.DataSource = dtSource
        GridView1.BestFitColumns()
    End Sub

    Private Sub bbiAssign_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiAssign.ItemClick

    End Sub

    Private Sub bbiExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiExport.ItemClick
        ExportToExcel(gcMainData)
    End Sub

    Private Sub bbiClose_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiClose.ItemClick
        Close()
    End Sub

    Private Sub RoutingOrderServiceAssignForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        gcMainData.MainView.SaveLayoutToRegistry(IO.Directory.GetCurrentDirectory)
    End Sub
End Class