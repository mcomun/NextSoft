Imports Application.BusinessEntities
Imports Application.DataAccess

Public Class COM_Sobrestadia_BL
    Dim COM_SobrestadiaDA As New COM_Sobrestadia_DA

    Public Function Insert(ByVal BE As COM_Sobrestadia_BE) As Boolean
        Return COM_SobrestadiaDA.Insert(BE)
    End Function
    Public Function Update(ByVal BE As COM_Sobrestadia_BE) As Boolean
        Return COM_SobrestadiaDA.Update(BE)
    End Function
    Public Function Delete(ByVal BE As COM_Sobrestadia_BE) As Boolean
        Return COM_SobrestadiaDA.Delete(BE)
    End Function
    Public Function GetAll(ByVal BE As COM_Sobrestadia_BE) As COM_Sobrestadia_BE
        Return COM_SobrestadiaDA.GetAll(BE)
    End Function
    Public Function GetDataTableByFilter(ByVal BE As COM_Sobrestadia_BE) As DataTable
        Return COM_SobrestadiaDA.GetDataTableByFilter(BE)
    End Function
End Class
