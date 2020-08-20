Imports Application.BusinessEntities
Imports Application.DataAccess

Public Class COM_DetSobrestadia_BL
    Dim COM_DetSobrestadia_DA As New COM_DetSobrestadia_DA

    Public Function Insert(ByVal BE As COM_DetSobrestadia_BE) As Boolean
        Return COM_DetSobrestadia_DA.Insert(BE)
    End Function
    Public Function Update(ByVal BE As COM_DetSobrestadia_BE) As Boolean
        Return COM_DetSobrestadia_DA.Update(BE)
    End Function
    Public Function Delete(ByVal BE As COM_DetSobrestadia_BE) As Boolean
        Return COM_DetSobrestadia_DA.Delete(BE)
    End Function
    Public Function GetAll(ByVal BE As COM_DetSobrestadia_BE) As COM_DetSobrestadia_BE
        Return COM_DetSobrestadia_DA.GetAll(BE)
    End Function
    Public Function GetDataTableByFilter(ByVal BE As COM_DetSobrestadia_BE) As DataTable
        Return COM_DetSobrestadia_DA.GetDataTableByFilter(BE)
    End Function
End Class
