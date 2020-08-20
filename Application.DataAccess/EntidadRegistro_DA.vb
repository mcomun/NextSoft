Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Application.BusinessEntities

Public Class EntidadRegistro_DA
    Dim constr As String = ConfigurationSettings.AppSettings("dbSolution").ToString()
    Dim cnx As New SqlConnection(constr)
    Dim cmd As New SqlCommand

    Public Function Insert(ByVal BE As EntidadRegistro_BE) As Boolean

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "web.upCustomerRegisterRequest"

            With .Parameters
                .Clear()
                .Add("@TIPO_CodTDI", SqlDbType.Char, 3).Value = BE.TIPO_CodTDI
                .Add("@ENTC_DocIden", SqlDbType.VarChar, 25).Value = BE.ENTC_DocIden
                .Add("@ENTC_RazonSocial", SqlDbType.NVarChar, 100).Value = BE.ENTC_RazonSocial
                .Add("@ENTC_EMail", SqlDbType.VarChar).Value = BE.ENTC_EMail
                .Add("@ENTC_EmailReceptorFE", SqlDbType.VarChar).Value = BE.ENTC_EmailReceptorFE
                .Add("@ENTC_Telef1", SqlDbType.VarChar, 25).Value = BE.ENTC_Telef1
                .Add("@ENTC_Origen", SqlDbType.Char, 3).Value = BE.ENTC_Origen
                .Add("@REGI_Estado", SqlDbType.Char, 1).Value = BE.REGI_Estado
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

    'Public Function Update(ByVal BE As EntidadRegistro_BE) As Boolean

    '    With cmd
    '        .Connection = cnx
    '        .CommandType = CommandType.StoredProcedure
    '        .CommandText = "dgp.upCustomerRegisterStatus"

    '        With .Parameters
    '            .Clear()
    '            .Add("@REGI_Codigo", SqlDbType.Int).Value = BE.REGI_Codigo
    '            .Add("@ENTC_CODIGO", SqlDbType.Int).Value = BE.ENTC_Codigo
    '            .Add("@TIPO_CodTDI", SqlDbType.Char, 3).Value = BE.TIPO_CodTDI
    '            .Add("@ENTC_DocIden", SqlDbType.VarChar, 25).Value = BE.ENTC_DocIden
    '            .Add("@ENTC_RazonSocial", SqlDbType.NVarChar, 100).Value = BE.ENTC_RazonSocial
    '            .Add("@ENTC_EMail", SqlDbType.VarChar).Value = BE.ENTC_EMail
    '            .Add("@ENTC_EmailReceptorFE", SqlDbType.VarChar).Value = BE.ENTC_EmailReceptorFE
    '            .Add("@ENTC_Telef1", SqlDbType.VarChar, 25).Value = BE.ENTC_Telef1
    '            .Add("@ENTC_Origen", SqlDbType.Char, 3).Value = BE.ENTC_Origen
    '            .Add("@REGI_Estado", SqlDbType.Char, 1).Value = BE.REGI_Estado
    '            .Add("@AUDI_USRMOD", SqlDbType.VarChar, 20).Value = BE.AUDI_UsrMod
    '            .Add("@AUDI_FECMOD", SqlDbType.DateTime).Value = BE.AUDI_FecMod
    '        End With
    '    End With

    '    Try
    '        cnx.Open()
    '        If cmd.ExecuteNonQuery() > 0 Then
    '            Return True
    '        Else
    '            Return False
    '        End If
    '    Catch ex As Exception
    '        Throw
    '    Finally
    '        cnx.Close()
    '    End Try
    'End Function

    Public Function StatusUpdate(ByVal BE As EntidadRegistro_BE) As Boolean

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "dgp.upCustomerRegisterStatus"

            With .Parameters
                .Clear()
                .Add("@REGI_Codigo", SqlDbType.Int).Value = BE.REGI_Codigo
                .Add("@ENTC_CODIGO", SqlDbType.Int).Value = BE.ENTC_Codigo
                .Add("@REGI_Estado", SqlDbType.Char, 1).Value = BE.REGI_Estado
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

    Public Function GetAllDataTable(ByVal BE As EntidadRegistro_BE) As DataTable
        Dim dt As New DataTable

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "web.upCustomerRegisterQuery"

            With .Parameters
                .Clear()
                .Add("@ENTC_DocIden", SqlDbType.VarChar, 25).Value = BE.ENTC_DocIden
                .Add("@REGI_Estado", SqlDbType.Char, 1).Value = BE.REGI_Estado
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
