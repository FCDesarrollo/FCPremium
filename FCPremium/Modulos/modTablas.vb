Imports System.Data.SqlClient

Module modTablas
    Public Sub CreaTablas_contpaq(ByVal cSQLCont As String)
        Dim cpCom As SqlCommand
        Dim cQue As String
        If FC_ConexionSQL(cSQLCont) <> 0 Then Exit Sub

        cQue = "IF OBJECT_ID('dbo.XMLDigConceptos') IS NULL " &
                    "Begin CREATE TABLE [dbo].[XMLDigConceptos](
	                    [IDDocmodelo] [int] NULL,
	                    [sucursal] [nvarchar](100) NULL,
	                    [codconcepto] [nvarchar](100) NULL,
	                    [nomconcepto] [nvarchar](250) NULL
                    ) ON [PRIMARY] END"
        cpCom = New SqlCommand(cQue, FC_SQL)
        cpCom.ExecuteNonQuery()
        cpCom.Dispose()

        cQue = "IF OBJECT_ID('dbo.XMLDigAsoc') IS NULL " &
                    "Begin CREATE TABLE [dbo].[XMLDigAsoc](
	                    [id] [int] IDENTITY(1,1) NOT NULL,
	                    [idusuariocrm] [int] NULL,
	                    [fecha] [date] NULL,
	                    [nombreusercrm] [nvarchar](250) NULL,
	                    [sucursal] [nvarchar](150) NULL,
	                    [iddocADW] [int] NULL,
	                    [iddocdig] [int] NULL,
	                    [nombrearchivo] [nvarchar](250) NULL,
	                    [idsubmenu] [int] NULL,
	                    [esOtro] [int] NULL
                    ) ON [PRIMARY] END"
        cpCom = New SqlCommand(cQue, FC_SQL)
        cpCom.ExecuteNonQuery()
        cpCom.Dispose()

        FC_SQL.Close()
    End Sub
End Module
