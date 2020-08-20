Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Application.BusinessEntities

Public Class EntidadVinculada_DA
    Dim constr As String = ConfigurationSettings.AppSettings("dbSolution").ToString()
    Dim cnx As New SqlConnection(constr)
    Dim cmd As New SqlCommand

    Public Function Insert(ByVal BE As EntidadVinculada_BE) As Boolean

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "web.upRelatedCompanyInsert"

            With .Parameters
                .Clear()
                .Add("@ENTC_CODIGO", SqlDbType.Int).Value = BE.ENTC_Codigo
                .Add("@ENTC_CODIGOVINCULADA", SqlDbType.Int).Value = BE.ENTC_CodigoVinculada
                .Add("@NOMBRECONTACTO", SqlDbType.VarChar, 150).Value = BE.NombreContacto
                .Add("@CORREOCONTACTO", SqlDbType.NVarChar, 200).Value = BE.CorreoContacto
                .Add("@CODIGOTIPOVINCULACION", SqlDbType.Char, 3).Value = BE.CodigoTipoVinculacion
                .Add("@CODIGOTIPOVIGENCIA", SqlDbType.Char, 3).Value = BE.CodigoTipoVigencia
                .Add("@VIGENCIADESDE", SqlDbType.DateTime).Value = BE.VigenciaDesde
                .Add("@VIGENCIAHASTA", SqlDbType.DateTime).Value = BE.VigenciaHasta
                .Add("@ESTADO", SqlDbType.Char, 1).Value = BE.Estado
                .Add("@AUDI_USRCREA", SqlDbType.VarChar, 20).Value = BE.AUDI_UsrCrea
                .Add("@AUDI_FECCREA", SqlDbType.DateTime).Value = BE.AUDI_FecCrea
            End With
        End With

        Try
            cnx.Open()
            If cmd.ExecuteNonQuery() > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw
        Finally
            cnx.Close()
        End Try
    End Function

    Public Function Update(ByVal BE As EntidadVinculada_BE) As Boolean

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "web.upRelatedCompanyUpdate"

            With .Parameters
                .Clear()
                .Add("@ENTC_CODIGO", SqlDbType.Int).Value = BE.ENTC_Codigo
                .Add("@ENTC_CODIGOVINCULADA", SqlDbType.Int).Value = BE.ENTC_CodigoVinculada
                .Add("@NOMBRECONTACTO", SqlDbType.VarChar, 150).Value = BE.NombreContacto
                .Add("@CORREOCONTACTO", SqlDbType.NVarChar, 200).Value = BE.CorreoContacto
                .Add("@CODIGOTIPOVINCULACION", SqlDbType.Char, 3).Value = BE.CodigoTipoVinculacion
                .Add("@CODIGOTIPOVIGENCIA", SqlDbType.Char, 3).Value = BE.CodigoTipoVigencia
                .Add("@VIGENCIADESDE", SqlDbType.DateTime).Value = BE.VigenciaDesde
                .Add("@VIGENCIAHASTA", SqlDbType.DateTime).Value = BE.VigenciaHasta
                .Add("@ESTADO", SqlDbType.Char, 1).Value = BE.Estado
                .Add("@AUDI_USRMOD", SqlDbType.VarChar, 20).Value = BE.AUDI_UsrMod
                .Add("@AUDI_FECMOD", SqlDbType.DateTime).Value = BE.AUDI_FecMod
            End With
        End With

        Try
            cnx.Open()
            If cmd.ExecuteNonQuery() > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw
        Finally
            cnx.Close()
        End Try
    End Function

    Public Function Delete(ByVal BE As EntidadVinculada_BE) As Boolean

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "web.upRelatedCompanyDelete"

            With .Parameters
                .Clear()
                .Add("@ENTC_Codigo", SqlDbType.Int).Value = BE.ENTC_Codigo
                .Add("@ENTC_CodigoVinculada", SqlDbType.Int).Value = BE.ENTC_CodigoVinculada
            End With
        End With

        Try
            cnx.Open()
            If cmd.ExecuteNonQuery() > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw
        Finally
            cnx.Close()
        End Try
    End Function

    Public Function GetAll(ByVal BE As EntidadVinculada_BE) As EntidadVinculada_BE
        Dim dr As SqlDataReader
        Dim EntidadVinculadaBE As New EntidadVinculada_BE

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "web.upRelatedCompanySelectAll"

            With .Parameters
                .Clear()
                .Add("@ENTC_Codigo", SqlDbType.Int).Value = BE.ENTC_Codigo
            End With
        End With

        Try
            cnx.Open()
            dr = cmd.ExecuteReader

            If dr.HasRows Then
                While dr.Read()
                    With EntidadVinculadaBE
                        If dr("ENTC_Codigo") Is DBNull.Value Then
                            .ENTC_Codigo = Nothing
                        Else
                            .ENTC_Codigo = dr("ENTC_Codigo")
                        End If

                        If dr("ENTC_CodigoVinculada") Is DBNull.Value Then
                            .ENTC_CodigoVinculada = Nothing
                        Else
                            .ENTC_CodigoVinculada = dr("ENTC_CodigoVinculada")
                        End If

                        If dr("NombreContacto") Is DBNull.Value Then
                            .NombreContacto = Nothing
                        Else
                            .NombreContacto = dr("NombreContacto")
                        End If

                        If dr("CorreoContacto") Is DBNull.Value Then
                            .CorreoContacto = Nothing
                        Else
                            .CorreoContacto = dr("CorreoContacto")
                        End If

                        If dr("CodigoTipoVinculacion") Is DBNull.Value Then
                            .CodigoTipoVinculacion = Nothing
                        Else
                            .CodigoTipoVinculacion = dr("CodigoTipoVinculacion")
                        End If

                        If dr("CodigoTipoVigencia") Is DBNull.Value Then
                            .CodigoTipoVigencia = Nothing
                        Else
                            .CodigoTipoVigencia = dr("CodigoTipoVigencia")
                        End If

                        If dr("VigenciaDesde") Is DBNull.Value Then
                            .VigenciaDesde = Nothing
                        Else
                            .VigenciaDesde = dr("VigenciaDesde")
                        End If

                        If dr("VigenciaHasta") Is DBNull.Value Then
                            .VigenciaHasta = Nothing
                        Else
                            .VigenciaHasta = dr("VigenciaHasta")
                        End If

                        If dr("Estado") Is DBNull.Value Then
                            .Estado = Nothing
                        Else
                            .Estado = dr("Estado")
                        End If

                        If dr("AUDI_UsrCrea") Is DBNull.Value Then
                            .AUDI_UsrCrea = Nothing
                        Else
                            .AUDI_UsrCrea = dr("AUDI_UsrCrea")
                        End If

                        If dr("AUDI_FecCrea") Is DBNull.Value Then
                            .AUDI_FecCrea = Nothing
                        Else
                            .AUDI_FecCrea = dr("AUDI_FecCrea")
                        End If

                        If dr("AUDI_UsrMod") Is DBNull.Value Then
                            .AUDI_UsrMod = Nothing
                        Else
                            .AUDI_UsrMod = dr("AUDI_UsrMod")
                        End If

                        If dr("AUDI_FecMod") Is DBNull.Value Then
                            .AUDI_FecMod = Nothing
                        Else
                            .AUDI_FecMod = dr("AUDI_FecMod")
                        End If

                    End With

                End While
                dr.Close()
            End If
        Catch ex As Exception
            Throw
        Finally
            cnx.Close()
        End Try
        Return EntidadVinculadaBE
    End Function

    Public Function GetAllDataTable(ByVal BE As EntidadVinculada_BE) As DataTable
        Dim dt As New DataTable

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "web.upRelatedCompanyQuery"

            With .Parameters
                .Clear()
                .Add("@pintENTC_Codigo", SqlDbType.Int).Value = BE.ENTC_Codigo
            End With
        End With

        Try
            cnx.Open()
            dt.Load(cmd.ExecuteReader)
            dt.TableName = "Result"
            Return dt
        Catch ex As Exception
            Throw
        Finally
            cnx.Close()
        End Try
    End Function

    Public Function StatusUpdate(ByVal BE As EntidadVinculada_BE) As Boolean

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "web.upRelatedCompanyStatusUpdate"

            With .Parameters
                .Clear()
                .Add("@ENTC_CODIGO", SqlDbType.Int).Value = BE.ENTC_Codigo
                .Add("@ENTC_DocIdenVinculada", SqlDbType.VarChar, 20).Value = BE.ENTC_DocIdenVinculada
                .Add("@ESTADO", SqlDbType.Char, 1).Value = BE.Estado
                .Add("@AUDI_USRMOD", SqlDbType.VarChar, 20).Value = BE.AUDI_UsrMod
                .Add("@AUDI_FECMOD", SqlDbType.DateTime).Value = BE.AUDI_FecMod
            End With
        End With

        Try
            cnx.Open()
            If cmd.ExecuteNonQuery() > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw
        Finally
            cnx.Close()
        End Try
    End Function

End Class
