Imports DevExpress.XtraEditors.DXErrorProvider
Imports DevExpress.XtraSplashScreen
Imports Microsoft.Office.Interop
Imports DevExpress.XtraWaitForm
Imports System.Runtime.InteropServices
Imports System.Windows

Public Class CargoAddressingForm

    Dim oAppService As New AppService.DelfinServiceClient
    Public AppUser As String = "sistemas"

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        'DevExpress.UserSkins.BonusSkins.Register()
        'DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Blue")

    End Sub

    Private Sub CargoAddressingForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gcMainData.MainView.RestoreLayoutFromRegistry(IO.Directory.GetCurrentDirectory)
        Me.WindowState = FormWindowState.Maximized
        SplitContainerControl2.SplitterPosition = SplitContainerControl2.Height * 0.6
        SplitContainerControl3.SplitterPosition = Me.Width * 0.7
        VGridControl1.OptionsView.MinRowAutoHeight = 40
        LoadShipline()
        LoadVoyage()
        LoadDepot()
        ButtonEnabled()
    End Sub

    Private Sub LoadShipline()
        lueShipline.Properties.DataSource = GetShipline(Nothing)
        lueShipline.Properties.DisplayMember = "DescripcionTransportista"
        lueShipline.Properties.ValueMember = "CodigoTransportista"
    End Sub

    Private Sub LoadVoyage()
        lueVoyage.Properties.DataSource = GetVoyage(Nothing, lueShipline.EditValue)
        lueVoyage.Properties.DisplayMember = "NombreNave"
        lueVoyage.Properties.ValueMember = "CodigoViaje"
    End Sub

    Private Sub LoadDepot()
        RepositoryItemLookUpEdit1.DataSource = GetDepot(Nothing)
        RepositoryItemLookUpEdit1.DisplayMember = "DescripcionDepositoTemporal"
        RepositoryItemLookUpEdit1.ValueMember = "CodigoDepositoTemporal"
    End Sub

    Private Sub bbiClose_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiClose.ItemClick
        Me.Close()
    End Sub

    Private Sub lueShipline_Properties_EditValueChanged(sender As Object, e As EventArgs) Handles lueShipline.Properties.EditValueChanged
        LoadVoyage()
    End Sub

    Private Sub lueVoyage_EditValueChanged(sender As Object, e As EventArgs) Handles lueVoyage.EditValueChanged
        teVoyage.Text = lueVoyage.GetColumnValue("Viaje_Vuelo")
    End Sub

    Private Sub bbiSearch_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiSearch.ItemClick
        LoadInputValidations()
        If Not vpInputs.Validate Then
            Return
        End If
        ButtonEnabled()
        gcMainData.DataSource = Nothing
        gcContainer.DataSource = Nothing
        SplashScreenManager.ShowForm(Me, GetType(WaitForm), True, True, False)
        SplashScreenManager.Default.SetWaitFormDescription("Consultando datos")
        Try
            Dim dtQuery As New DataTable
            Dim sQuery As String = ""
            sQuery += "EXEC NextSoft.dgp.paConsultaDireccionamientoCarga "
            If Not lueShipline.EditValue Is Nothing Then
                sQuery += lueShipline.EditValue.ToString
            Else
                sQuery += "NULL"
            End If
            sQuery += "," & lueVoyage.EditValue.ToString
            sQuery += "," & IIf(teHBL.Text.Trim = "", "NULL", "'" & teHBL.Text.Trim & "'")
            dtQuery = oAppService.ExecuteSQL(sQuery).Tables(0)
            GridView1.BestFitMaxRowCount = 1
            GridView1.BestFitColumns()
            gcMainData.DataSource = dtQuery
            VGridControl1.DataSource = dtQuery
            ButtonEnabled()
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
        End Try
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub LoadInputValidations()
        Validate()
        Dim containsValidationRule As New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        containsValidationRule.ConditionOperator = ConditionOperator.IsNotBlank
        containsValidationRule.ErrorText = "Asigne un valor."
        containsValidationRule.ErrorType = ErrorType.Critical
        Dim customValidationRule As New CustomValidationRule()
        customValidationRule.ErrorText = "Valor obligatorio."
        customValidationRule.ErrorType = ErrorType.Critical
        vpInputs.SetValidationRule(Me.lueVoyage, customValidationRule)
    End Sub

    Private Sub bbiExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiExport.ItemClick
        ExportToExcel(gcMainData)
    End Sub

    Private Sub bbiSendMessage_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiSendMessage.ItemClick
        If DevExpress.XtraEditors.XtraMessageBox.Show("El envío de esta notificación creará el evento de direccionamiento, desea continuar? ", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Forms.DialogResult.No Then
            Return
        End If
        If UpdateAddressingDate(GridView1.GetFocusedRowCellValue("CodigoViaje")) Then
            CreateSendItem()
        End If
    End Sub

    Function UpdateAddressingDate(iNVIA_Codigo As Integer) As Boolean
        Dim bResult As Boolean = True
        Try
            oAppService.ExecuteSQLNonQuery("EXEC NextSoft.dgp.paAsignaFechaRegistroDireccionamiento " & iNVIA_Codigo.ToString)
        Catch ex As Exception
            bResult = False
            DevExpress.XtraEditors.XtraMessageBox.Show("No se actualizó la fecha de registro de direccionamiento. " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return bResult
    End Function

    'Function EventRegister(iCCOT_Numero As Integer) As Boolean
    '    Dim bResult As Boolean = True
    '    Dim sQuery As String = ""
    '    sQuery += "EXEC NextSoft.dbo.COM_EVENSI_UnReg "
    '    sQuery += iCCOT_Numero.ToString & ", "
    '    sQuery += "2" & ", "
    '    sQuery += "NULL" & ", "
    '    sQuery += "'" & Format(Now, "dd/MM/yyyy HH:mm:ss") & "', "
    '    sQuery += "1" & ", "
    '    sQuery += "'" & AppUser & "', "
    '    sQuery += "'Se ha asignado el depósito en la orden de venta desde Direccionamiento de Carga'" & ", "
    '    sQuery += "'" & "EVE" & "', "
    '    sQuery += "'" & "039" & "', "
    '    sQuery += "'" & "MOD" & "', "
    '    sQuery += "'" & "001" & "', "
    '    sQuery += "0" & ", "
    '    sQuery += "'" & AppUser & "'"
    '    Try
    '        oAppService.ExecuteSQLNonQuery(sQuery)
    '    Catch ex As Exception
    '        SplashScreenManager.CloseForm(False)
    '        bResult = False
    '        DevExpress.XtraEditors.XtraMessageBox.Show("No se generó el evento de direccionamiento. " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Finally
    '        SplashScreenManager.CloseForm(False)
    '    End Try
    '    Return bResult
    'End Function

    Friend Sub CreateSendItem()
        Dim Application As New Outlook.Application
        Dim mail As Outlook.MailItem = Nothing
        Dim mailRecipients As Outlook.Recipients = Nothing
        Dim mailRecipient As Outlook.Recipient = Nothing
        Try
            mail = Application.CreateItem(Outlook.OlItemType.olMailItem)
            mail.Subject = "NAVE CON DIRECCIONAMIENTO " & GridView1.GetFocusedRowCellValue("NombreNave").ToString & Space(1) & GridView1.GetFocusedRowCellValue("Viaje_Vuelo").ToString
            mail.HTMLBody = "Estimados," & "<br><br>" & "Se confirma el direccionamiento para la nave de la referencia con la línea naviera " & GridView1.GetFocusedRowCellValue("Transportista").ToString
            If GridView1.GetFocusedRowCellValue("ETA_ETD").ToString <> "" Then
                mail.HTMLBody += " con ETA " & GridView1.GetFocusedRowCellValue("Puerto").ToString & Space(1) & Format(GridView1.GetFocusedRowCellValue("ETA_ETD"), "dd/MM/yyyy")
            End If
            mail.To = "operations@delfingroupco.com.pe; logistica@delfingroupco.com.pe"
            mail.CC = "admin@delfingroupco.com.pe; controller@delfingroupco.com.pe"
            Dim sFileName = GetTmpFileName("xlsx")
            GridView1.ExportToXlsx(sFileName)
            If IO.File.Exists(sFileName) Then
                mail.Attachments.Add(sFileName)
            End If
            SplashScreenManager.ShowForm(Me, GetType(WaitForm), True, True, False)
            SplashScreenManager.Default.SetWaitFormDescription("Creando nuevo mensaje")
            mail.Display()
            SplashScreenManager.CloseForm(False)
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            System.Windows.Forms.MessageBox.Show(ex.Message,
                "An exception is occured in the code of add-in.")
        Finally
            If Not IsNothing(mailRecipient) Then Marshal.ReleaseComObject(mailRecipient)
            If Not IsNothing(mailRecipients) Then Marshal.ReleaseComObject(mailRecipients)
            If Not IsNothing(mail) Then Marshal.ReleaseComObject(mail)
        End Try

    End Sub

    Private Sub bbiDepotAssign_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiDepotAssign.ItemClick
        Validate()
        If DevExpress.XtraEditors.XtraMessageBox.Show("Está seguro de aplicar la actualización de datos?  ", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Return
        End If
        SplashScreenManager.ShowForm(Me, GetType(WaitForm), True, True, False)
        SplashScreenManager.Default.SetWaitFormDescription("Asignando depósitos")
        Try
            For r = 0 To GridView1.RowCount - 1
                Dim oRow As DataRow = GridView1.GetDataRow(r)
                If GridView1.GetDataRow(r).RowState = DataRowState.Modified Then
                    oAppService.ExecuteSQLNonQuery("EXEC NextSoft.dgp.paAsignaDireccionamientoCarga " & oRow("CCOT_Numero").ToString & ", " & oRow("CodigoDepositoTemporal").ToString & ",'" & AppUser & "'")
                End If
            Next
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
        End Try
        SplashScreenManager.CloseForm(False)
        bbiSearch.PerformClick()
    End Sub

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs)
        Validate()
        ButtonEnabled()
    End Sub

    Private Sub ButtonEnabled()
        If GridView1.RowCount = 0 Then
            bbiSendMessage.Enabled = False
            bbiExport.Enabled = False
            bbiDepotAssign.Enabled = False
            Return
        End If
        bbiSendMessage.Enabled = True
        bbiExport.Enabled = True
        bbiDepotAssign.Enabled = EtaValidate()
        bbiSendMessage.Enabled = True
        For r = 0 To GridView1.RowCount - 1
            Dim oRow As DataRow = GridView1.GetDataRow(r)
            If oRow("DepositoTemporal") = "" Then
                'bbiSendMessage.Enabled = False
            End If
        Next
    End Sub

    Function EtaValidate() As Boolean
        Dim bResult As Boolean = True
        If Not IsDBNull(GridView1.GetFocusedRowCellValue("ETA_ETD")) Then
            bResult = False
        End If
        Return bResult
    End Function

    Private Sub GridView1_FocusedRowChanged_1(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        Validate()
        If e.FocusedRowHandle < 0 Then
            Return
        End If
        Dim dtContainers As New DataTable
        dtContainers = oAppService.ExecuteSQL("EXEC NextSoft.dgp.paObtieneContenedoresPorOrdenVenta '" & GridView1.GetFocusedRowCellValue("CCOT_Numero").ToString & "'").Tables(0)
        gcContainer.DataSource = dtContainers
        GridView3.BestFitColumns()
    End Sub

    Private Sub CargoAddressingForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        gcMainData.MainView.SaveLayoutToRegistry(IO.Directory.GetCurrentDirectory)
    End Sub
End Class