Imports DevExpress.XtraEditors.DXErrorProvider
Imports DevExpress.XtraSplashScreen
Imports Microsoft.Office.Interop
Imports DevExpress.XtraWaitForm
Imports System.Runtime.InteropServices

Public Class DemurrageForm
    Dim oNextSoftService As New NextSoftService.NextSoftServiceClient
    Public AppUser As String = "sistemas"

    Private Sub lueShipline_Properties_EditValueChanged(sender As Object, e As EventArgs) Handles lueShipline.Properties.EditValueChanged

    End Sub

    Private Sub DemurrageForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gcMainData.MainView.RestoreLayoutFromRegistry(IO.Directory.GetCurrentDirectory)
        Me.WindowState = FormWindowState.Maximized
        deDateFrom.EditValue = DateAdd(DateInterval.Day, -30, Today)
        deDateTo.EditValue = Today
        LoadShipline()
    End Sub

    Private Sub LoadShipline()
        lueShipline.Properties.DataSource = GetShipline(Nothing)
        lueShipline.Properties.DisplayMember = "DescripcionTransportista"
        lueShipline.Properties.ValueMember = "CodigoTransportista"
    End Sub

    Private Sub bbiClose_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiClose.ItemClick
        End
    End Sub

    Private Sub bbiSearch_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiSearch.ItemClick
        Dim dtDemurrage As New DataTable
        Dim oSobrestadiaBE As New NextSoftService.COM_Sobrestadia_BE
        oSobrestadiaBE.SOES_Codigo = IIf(teInternalCode.Text <> Nothing, teInternalCode.Text, Nothing)
        oSobrestadiaBE.ENTC_Codigo = IIf(lueShipline.EditValue <> Nothing, lueShipline.EditValue, Nothing)
        oSobrestadiaBE.SOES_FecIni = deDateFrom.EditValue
        oSobrestadiaBE.SOES_FecFin = deDateTo.EditValue
        dtDemurrage = oNextSoftService.GetSobrestadiaByFilter(oSobrestadiaBE)
        gcMainData.DataSource = dtDemurrage
    End Sub

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        If GridView1.RowCount = 0 Then
            Return
        End If
        Dim dtDemurrageDetail As New DataTable
        Dim oDetSobrestadiaBE As New NextSoftService.COM_DetSobrestadia_BE
        oDetSobrestadiaBE.SOES_Codigo = GridView1.GetFocusedRowCellValue("SOES_Codigo")
        dtDemurrageDetail = oNextSoftService.GetDetSobrestadiaByFilter(oDetSobrestadiaBE)
        gcDetail.DataSource = dtDemurrageDetail
    End Sub

    Private Sub DemurrageForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        gcMainData.MainView.SaveLayoutToRegistry(IO.Directory.GetCurrentDirectory)
    End Sub
End Class