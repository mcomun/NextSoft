Imports Application.BusinessEntities
Imports Application.DataAccess

Public Class EntidadRegistro_BL
    Dim EntidadRegistro_DA As New EntidadRegistro_DA

    Public Function Insert(ByVal BE As EntidadRegistro_BE) As Boolean
        Return EntidadRegistro_DA.Insert(BE)
    End Function
    Public Function StatusUpdate(ByVal BE As EntidadRegistro_BE) As Boolean
        Return EntidadRegistro_DA.StatusUpdate(BE)
    End Function
    Public Function GetAllDataTable(ByVal BE As EntidadRegistro_BE) As DataTable
        Return EntidadRegistro_DA.GetAllDataTable(BE)
    End Function

End Class
