Imports Application.BusinessEntities
Imports Application.DataAccess

Public Class EntidadVinculada_BL
    Dim EntidadVinculada_DA As New EntidadVinculada_DA

    Public Function Insert(ByVal BE As EntidadVinculada_BE) As Boolean
        Return EntidadVinculada_DA.Insert(BE)
    End Function
    Public Function Update(ByVal BE As EntidadVinculada_BE) As Boolean
        Return EntidadVinculada_DA.Update(BE)
    End Function
    Public Function StatusUpdate(ByVal BE As EntidadVinculada_BE) As Boolean
        Return EntidadVinculada_DA.StatusUpdate(BE)
    End Function
    Public Function Delete(ByVal BE As EntidadVinculada_BE) As Boolean
        Return EntidadVinculada_DA.Delete(BE)
    End Function
    Public Function GetAll(ByVal BE As EntidadVinculada_BE) As EntidadVinculada_BE
        Return EntidadVinculada_DA.GetAll(BE)
    End Function
    Public Function GetAllDataTable(ByVal BE As EntidadVinculada_BE) As DataTable
        Return EntidadVinculada_DA.GetAllDataTable(BE)
    End Function

End Class
