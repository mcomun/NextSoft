Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Application.BusinessEntities

Public Class COM_DetSobrestadia_DA
    Dim constr As String = ConfigurationSettings.AppSettings("dbNextSoft").ToString()
    Dim cnx As New SqlConnection(constr)
    Dim cmd As New SqlCommand

    Public Function Insert(ByVal BE As COM_DetSobrestadia_BE) As Boolean

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DGP.COM_DETSOBRESTADIA_INSERT"

            With .Parameters
                .Clear()
                .Add("@SOES_CODIGO", SqlDbType.int).Value = BE.SOES_Codigo
                .Add("@SOES_ITEM", SqlDbType.int).Value = BE.SOES_Item
                .Add("@PACK_CODIGO", SqlDbType.int).Value = BE.PACK_Codigo
                .Add("@PUER_CODDESTINO", SqlDbType.int).Value = BE.PUER_CodDestino
                .Add("@SOES_DIASSOBRESTADIALINEA", SqlDbType.SmallInt).Value = BE.SOES_DiasSobrestadiaLinea
                .Add("@SOES_DIASSOBRESTADIACLIENTE", SqlDbType.SmallInt).Value = BE.SOES_DiasSobrestadiaCliente
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

    Public Function Update(ByVal BE As COM_DetSobrestadia_BE) As Boolean

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DGP.COM_DETSOBRESTADIA_UPDATE"

            With .Parameters
                .Clear()
                .Add("@SOES_CODIGO", SqlDbType.int).Value = BE.SOES_Codigo
                .Add("@SOES_ITEM", SqlDbType.int).Value = BE.SOES_Item
                .Add("@PACK_CODIGO", SqlDbType.int).Value = BE.PACK_Codigo
                .Add("@PUER_CODDESTINO", SqlDbType.int).Value = BE.PUER_CodDestino
                .Add("@SOES_DIASSOBRESTADIALINEA", SqlDbType.SmallInt).Value = BE.SOES_DiasSobrestadiaLinea
                .Add("@SOES_DIASSOBRESTADIACLIENTE", SqlDbType.SmallInt).Value = BE.SOES_DiasSobrestadiaCliente
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

    Public Function Delete(ByVal BE As COM_DetSobrestadia_BE) As Boolean

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DGP.COM_DETSOBRESTADIA_DELETE"

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

    Public Function GetAll(ByVal BE As COM_DetSobrestadia_BE) As COM_DetSobrestadia_BE
        Dim dr As SqlDataReader
        Dim COM_DetSobrestadia_BE As New COM_DetSobrestadia_BE

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DGP.COM_DETSOBRESTADIA_SELECTALL"

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
                    With COM_DetSobrestadia_BE
                        If dr("SOES_Codigo") Is DBNull.Value Then
                            .SOES_Codigo = Nothing
                        Else
                            .SOES_Codigo = dr("SOES_Codigo")
                        End If

                        If dr("SOES_Item") Is DBNull.Value Then
                            .SOES_Item = Nothing
                        Else
                            .SOES_Item = dr("SOES_Item")
                        End If

                        If dr("PACK_Codigo") Is DBNull.Value Then
                            .PACK_Codigo = Nothing
                        Else
                            .PACK_Codigo = dr("PACK_Codigo")
                        End If

                        If dr("PUER_CodDestino") Is DBNull.Value Then
                            .PUER_CodDestino = Nothing
                        Else
                            .PUER_CodDestino = dr("PUER_CodDestino")
                        End If

                        If dr("SOES_DiasSobrestadiaLinea") Is DBNull.Value Then
                            .SOES_DiasSobrestadiaLinea = Nothing
                        Else
                            .SOES_DiasSobrestadiaLinea = dr("SOES_DiasSobrestadiaLinea")
                        End If

                        If dr("SOES_DiasSobrestadiaCliente") Is DBNull.Value Then
                            .SOES_DiasSobrestadiaCliente = Nothing
                        Else
                            .SOES_DiasSobrestadiaCliente = dr("SOES_DiasSobrestadiaCliente")
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
        Return COM_DetSobrestadia_BE
    End Function

    Public Function GetDataTableByFilter(ByVal BE As COM_DetSobrestadia_BE) As DataTable
        Dim dt As New DataTable

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DGP.COM_DETSOBRESTADIA_SELECTBYFILTER"
            With .Parameters
                .Clear()
                .Add("@SOES_Codigo", SqlDbType.Int).Value = BE.SOES_Codigo
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
