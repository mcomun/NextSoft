Imports System.IO
Imports Microsoft.Office.Interop
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraVerticalGrid

Module SharedModule
    Dim oAppService As New AppService.DelfinServiceClient

    Friend Function GetShipline(ShiplineCode As String) As DataTable
        Dim dtQuery As New DataTable
        Dim sShiplineCode As String = IIf(ShiplineCode Is Nothing, "NULL", ShiplineCode)
        dtQuery = oAppService.ExecuteSQL("EXEC NextSoft.dgp.paListaTransportista " & sShiplineCode).Tables(0)
        Return dtQuery
    End Function

    Friend Function GetCustomer(CustomerCode As String) As DataTable
        Dim dtQuery As New DataTable
        Dim sCustomerCode As String = IIf(CustomerCode Is Nothing, "NULL", CustomerCode)
        dtQuery = oAppService.ExecuteSQL("EXEC NextSoft.dgp.paListaCliente " & sCustomerCode).Tables(0)
        Return dtQuery
    End Function

    Friend Function GetVoyage(VoyageCode As String, ShiplineCode As String) As DataTable
        Dim dtQuery As New DataTable
        Dim sVoyageCode As String = IIf(VoyageCode Is Nothing, "NULL", VoyageCode)
        Dim sShiplineCode As String = IIf(ShiplineCode Is Nothing, "NULL", ShiplineCode)
        dtQuery = oAppService.ExecuteSQL("EXEC NextSoft.dgp.paListaNaveViaje " & sVoyageCode & "," & sShiplineCode).Tables(0)
        Return dtQuery
    End Function

    Friend Function GetDepot(DepotCode As String) As DataTable
        Dim dtQuery As New DataTable
        Dim sDepotCode As String = IIf(DepotCode Is Nothing, "NULL", DepotCode)
        dtQuery = oAppService.ExecuteSQL("EXEC NextSoft.dgp.paListaDeposito " & sDepotCode).Tables(0)
        Return dtQuery
    End Function

    Friend Sub ExportToExcel(sender As System.Object)
        Dim sFileName As String = GetTmpFileName("xlsx")
        If sender.ProductName = "DevExpress.XtraVerticalGrid" Then
            Dim oVGridControl As New VGridControl
            oVGridControl = sender
            oVGridControl.ExportToXlsx(sFileName)
        Else
            Dim oGridView As New GridView
            oGridView = sender.FocusedView
            oGridView.OptionsPrint.AutoWidth = False
            oGridView.BestFitColumns()
            oGridView.BestFitMaxRowCount = oGridView.RowCount
            oGridView.ExportToXlsx(sFileName)
        End If
        If IO.File.Exists(sFileName) Then
            Dim oXls As New Excel.Application 'Crea el objeto excel 
            oXls.Workbooks.Open(sFileName, , False) 'El true es para abrir el archivo en modo Solo lectura (False si lo quieres de otro modo)
            oXls.Visible = True
            oXls.WindowState = Excel.XlWindowState.xlMaximized 'Para que la ventana aparezca maximizada.
        End If
    End Sub

    Friend Function GetTmpFileName(sExtFile As String) As String
        Dim sResult As String = ""
        Dim sPath As String = Path.GetTempPath
        sResult = (FileIO.FileSystem.GetTempFileName).Replace(".tmp", ".xlsx")
        Return sResult
    End Function

End Module
