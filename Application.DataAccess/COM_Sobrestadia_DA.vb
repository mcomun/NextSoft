Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Application.BusinessEntities

Public Class COM_Sobrestadia_DA
    Dim constr As String = ConfigurationSettings.AppSettings("dbNextSoft").ToString()
    Dim cnx As New SqlConnection(constr)
    Dim cmd As New SqlCommand

    Public Function Insert(ByVal BE As COM_Sobrestadia_BE) As Boolean

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DGP.COM_SOBRESTADIA_INSERT"

            With .Parameters
                .Clear()
                .Add("@SOES_CODIGO", SqlDbType.Int).Value = BE.SOES_Codigo
                .Add("@ENTC_CODIGO", SqlDbType.Int).Value = BE.ENTC_Codigo
                .Add("@CONT_CODIGO", SqlDbType.Int).Value = BE.CONT_Codigo
                .Add("@SOES_SERVICECONTRACT", SqlDbType.VarChar, 200).Value = BE.SOES_ServiceContract
                .Add("@SOES_FECINI", SqlDbType.DateTime).Value = BE.SOES_FecIni
                .Add("@SOES_FECFIN", SqlDbType.DateTime).Value = BE.SOES_FecFin
                .Add("@SOES_ACTIVO", SqlDbType.Bit).Value = BE.SOES_Activo
                .Add("@SOES_OBSERVACIONES", SqlDbType.VarChar, 100).Value = BE.SOES_Observaciones
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

    Public Function Update(ByVal BE As COM_Sobrestadia_BE) As Boolean

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DGP.COM_SOBRESTADIA_UPDATE"

            With .Parameters
                .Clear()
                .Add("@SOES_CODIGO", SqlDbType.Int).Value = BE.SOES_Codigo
                .Add("@ENTC_CODIGO", SqlDbType.Int).Value = BE.ENTC_Codigo
                .Add("@CONT_CODIGO", SqlDbType.Int).Value = BE.CONT_Codigo
                .Add("@SOES_SERVICECONTRACT", SqlDbType.VarChar, 200).Value = BE.SOES_ServiceContract
                .Add("@SOES_FECINI", SqlDbType.DateTime).Value = BE.SOES_FecIni
                .Add("@SOES_FECFIN", SqlDbType.DateTime).Value = BE.SOES_FecFin
                .Add("@SOES_ACTIVO", SqlDbType.Bit).Value = BE.SOES_Activo
                .Add("@SOES_OBSERVACIONES", SqlDbType.VarChar, 100).Value = BE.SOES_Observaciones
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

    Public Function Delete(ByVal BE As COM_Sobrestadia_BE) As Boolean

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DGP.COM_SOBRESTADIA_DELETE"

            With .Parameters
                .Clear()
                .Add("@SOES_Codigo", SqlDbType.Int).Value = BE.SOES_Codigo
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

    Public Function GetAll(ByVal BE As COM_Sobrestadia_BE) As COM_Sobrestadia_BE
        Dim dr As SqlDataReader
        Dim COM_Sobrestadia_BE As New COM_Sobrestadia_BE

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DGP.COM_SOBRESTADIA_SELECTALL"

            With .Parameters
                .Clear()
                .Add("@SOES_Codigo", SqlDbType.Int).Value = BE.SOES_Codigo
            End With
        End With

        Try
            cnx.Open()
            dr = cmd.ExecuteReader

            If dr.HasRows Then
                While dr.Read()
                    With COM_Sobrestadia_BE
                        If dr("SOES_Codigo") Is DBNull.Value Then
                            .SOES_Codigo = Nothing
                        Else
                            .SOES_Codigo = dr("SOES_Codigo")
                        End If

                        If dr("ENTC_Codigo") Is DBNull.Value Then
                            .ENTC_Codigo = Nothing
                        Else
                            .ENTC_Codigo = dr("ENTC_Codigo")
                        End If

                        If dr("CONT_Codigo") Is DBNull.Value Then
                            .CONT_Codigo = Nothing
                        Else
                            .CONT_Codigo = dr("CONT_Codigo")
                        End If

                        If dr("SOES_ServiceContract") Is DBNull.Value Then
                            .SOES_ServiceContract = Nothing
                        Else
                            .SOES_ServiceContract = dr("SOES_ServiceContract")
                        End If

                        If dr("SOES_FecIni") Is DBNull.Value Then
                            .SOES_FecIni = Nothing
                        Else
                            .SOES_FecIni = dr("SOES_FecIni")
                        End If

                        If dr("SOES_FecFin") Is DBNull.Value Then
                            .SOES_FecFin = Nothing
                        Else
                            .SOES_FecFin = dr("SOES_FecFin")
                        End If

                        If dr("SOES_Activo") Is DBNull.Value Then
                            .SOES_Activo = Nothing
                        Else
                            .SOES_Activo = dr("SOES_Activo")
                        End If

                        If dr("SOES_Observaciones") Is DBNull.Value Then
                            .SOES_Observaciones = Nothing
                        Else
                            .SOES_Observaciones = dr("SOES_Observaciones")
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
        Return COM_Sobrestadia_BE
    End Function

    Public Function GetDataTableByFilter(ByVal BE As COM_Sobrestadia_BE) As DataTable
        Dim dt As New DataTable

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DGP.COM_SOBRESTADIA_SELECTBYFILTER"
            With .Parameters
                .Clear()
                .Add("@SOES_Codigo", SqlDbType.Int).Value = BE.SOES_Codigo
                .Add("@ENTC_Codigo", SqlDbType.Int).Value = BE.ENTC_Codigo
                .Add("@SOES_FecIni", SqlDbType.Date).Value = BE.SOES_FecIni
                .Add("@SOES_FecFin", SqlDbType.Date).Value = BE.SOES_FecFin
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

End Class
