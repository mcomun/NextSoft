Imports ApplicationForm.OnLineService
Imports DevExpress.XtraEditors.DXErrorProvider
Imports WebTesting.OnlineService

Public Class RelatedCompanyRequestForm
    Private oAppService As New OnLineService.OnLineServiceClient
    'Dim oMasterDataList As New MasterDataList
    Dim oRelatedCompanyBE As New EntidadVinculada_BE
    Public AppUser As String = "sistemas"

    Private Sub RelatedCompanyRequestForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetRelatedCompany()
    End Sub

    Private Sub GetRelatedCompany()
        Dim dtSource As New DataTable
        dtSource = oAppService.ExecuteSQL("EXEC NextSoft.web.upRelatedCompanyQueryToApprove").Tables(0)
        gcMainData.DataSource = dtSource
    End Sub

    Private Sub bbiClose_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiClose.ItemClick
        Close()
    End Sub

    'Private Sub RelatedCompanyUpdate(drSource As DataRow)
    '    If drSource("Estado") = "A" Then
    '        DevExpress.XtraEditors.XtraMessageBox.Show("No se puede actualizar una vinculación aprobada. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Return
    '    End If
    '    If DevExpress.XtraEditors.XtraMessageBox.Show("La solicitud para una empresa existente actualizará los datos y quedará en estado PENDIENTE, desea continuar? ", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.No Then
    '        Return
    '    End If
    '    oRelatedCompanyBE.ENTC_Codigo = GridView1.GetFocusedRowCellValue("ENTC_Codigo")
    '    oRelatedCompanyBE.ENTC_CodigoVinculada = GetCustomerCode(teDocumentNumber.EditValue)
    '    oRelatedCompanyBE.NombreContacto = teContactName.Text
    '    oRelatedCompanyBE.CorreoContacto = teMail.Text
    '    oRelatedCompanyBE.CodigoTipoVinculacion = lueRelationType.EditValue
    '    oRelatedCompanyBE.CodigoTipoVigencia = lueValidityType.EditValue
    '    If lueValidityType.GetColumnValue("ValidaFechas") = True Then
    '        oRelatedCompanyBE.VigenciaDesde = deDateFrom.EditValue
    '        oRelatedCompanyBE.VigenciaHasta = deDateTo.EditValue
    '    End If
    '    oRelatedCompanyBE.Estado = "P"
    '    oRelatedCompanyBE.AUDI_UsrMod = AppUser
    '    oRelatedCompanyBE.AUDI_FecMod = Now
    '    Try
    '        oAppService.UpdateRelatedCompany(oRelatedCompanyBE)
    '    Catch ex As Exception
    '        DevExpress.XtraEditors.XtraMessageBox.Show("Se generó un error al actualizar la solicitud. " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Return
    '    Finally
    '        DevExpress.XtraEditors.XtraMessageBox.Show("La solicituda ha sido actualizada satisfactoriamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    End Try
    'End Sub

    Private Sub bbiApprove_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiApprove.ItemClick
        If DevExpress.XtraEditors.XtraMessageBox.Show("Esta seguro que desea aprobar la vinculación seleccionada? ", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.No Then
            Return
        End If
        oRelatedCompanyBE.ENTC_Codigo = GridView1.GetFocusedRowCellValue("ENTC_Codigo")
        oRelatedCompanyBE.ENTC_DocIdenVinculada = GridView1.GetFocusedRowCellValue("ENTC_DocIden")
        oRelatedCompanyBE.Estado = "A"
        oRelatedCompanyBE.AUDI_UsrMod = AppUser
        oRelatedCompanyBE.AUDI_FecMod = Now
        oAppService.StatusUpdateRelatedCompany(oRelatedCompanyBE)
        GetRelatedCompany()
    End Sub

    Private Sub bbiReject_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiReject.ItemClick
        If DevExpress.XtraEditors.XtraMessageBox.Show("Esta seguro que desea rechazar la vinculación seleccionada? ", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.No Then
            Return
        End If
        oRelatedCompanyBE.ENTC_Codigo = GridView1.GetFocusedRowCellValue("ENTC_Codigo")
        oRelatedCompanyBE.ENTC_DocIdenVinculada = GridView1.GetFocusedRowCellValue("ENTC_DocIden")
        oRelatedCompanyBE.Estado = "R"
        oRelatedCompanyBE.AUDI_UsrMod = AppUser
        oRelatedCompanyBE.AUDI_FecMod = Now
        oAppService.StatusUpdateRelatedCompany(oRelatedCompanyBE)
        GetRelatedCompany()
    End Sub

    Private Sub RepositoryItemHyperLinkEdit1_Click(sender As Object, e As EventArgs) Handles RepositoryItemHyperLinkEdit1.Click
        If DevExpress.XtraEditors.XtraMessageBox.Show("Esta seguro que desea desvincular la empresa seleccionada? ", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.No Then
            Return
        End If
        oRelatedCompanyBE.ENTC_Codigo = GridView1.GetFocusedRowCellValue("ENTC_Codigo")
        oRelatedCompanyBE.ENTC_DocIdenVinculada = GridView1.GetFocusedRowCellValue("ENTC_DocIden")
        oRelatedCompanyBE.Estado = "D"
        oRelatedCompanyBE.AUDI_UsrMod = AppUser
        oRelatedCompanyBE.AUDI_FecMod = Now
        oAppService.StatusUpdateRelatedCompany(oRelatedCompanyBE)
        GetRelatedCompany()
    End Sub

End Class