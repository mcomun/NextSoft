Imports System.Windows
Imports ApplicationForm.OnLineService

Public Class CustomerRegisterRequestForm
    Dim oOnLineService As New OnLineService.OnLineServiceClient
    Dim oAppService As New AppService.DelfinServiceClient
    Public AppUser As String = "sistemas"
    Public drEntidadRegistro As DataRow

    Private Sub CustomerRegisterRequestForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadRequestList()
    End Sub

    Private Sub LoadRequestList()
        gcMainData.MainView.RestoreLayoutFromRegistry(IO.Directory.GetCurrentDirectory)
        Dim dtQuery As New DataTable
        Dim oCustomerRegister As New EntidadRegistro_BE
        oCustomerRegister.REGI_Estado = "P"
        dtQuery = oOnLineService.GetAllDataTableCustomerRegister(oCustomerRegister)
        dtQuery.Columns.Add("Checked", GetType(Boolean)).DefaultValue = False
        gcMainData.DataSource = dtQuery
    End Sub

    Private Sub SeleccionaFila()
        Dim i As Integer = 0
        Dim iPos As Integer = GridView1.FocusedRowHandle
        Do While i < GridView1.RowCount
            Dim row As DataRow = GridView1.GetDataRow(i)
            row("Checked") = False
            If i = iPos Then
                row("Checked") = True
            End If
            i += 1
        Loop
    End Sub

    Private Sub bbiClose_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiClose.ItemClick
        Close()
    End Sub

    Private Sub bbiImport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiImport.ItemClick
        For i = 0 To GridView1.RowCount - 1
            Dim row As DataRow = GridView1.GetDataRow(i)
            If row("Checked") = True Then
                drEntidadRegistro = row
                Exit For
            End If
        Next
        Close()
    End Sub

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        SeleccionaFila()
    End Sub

    Private Sub bbiReject_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiReject.ItemClick
        If DevExpress.XtraEditors.XtraMessageBox.Show("Si rechaza esta solicitud ya no estará disponible, desea continuar? ", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Forms.DialogResult.No Then
            Return
        End If
        Dim oCustomerRegister As New EntidadRegistro_BE
        oCustomerRegister.REGI_Codigo = GridView1.GetFocusedRowCellValue("REGI_Codigo")
        oCustomerRegister.REGI_Estado = "R"
        oCustomerRegister.AUDI_UsrMod = AppUser
        oCustomerRegister.AUDI_FecMod = Now
        Try
            oOnLineService.StatusUpdateCustomerRegister(oCustomerRegister)
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show("La actualización no se aplicó correctamente. " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        LoadRequestList()
    End Sub

    Private Sub CustomerRegisterRequestForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        gcMainData.MainView.SaveLayoutToRegistry(IO.Directory.GetCurrentDirectory)
    End Sub

    Private Sub bbiExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiExport.ItemClick
        ExportToExcel(gcMainData)
    End Sub

    Private Sub bbiRefresh_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiRefresh.ItemClick
        LoadRequestList()
    End Sub
End Class