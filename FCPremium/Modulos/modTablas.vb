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

        cQue = "IF OBJECT_ID('dbo.zCEXTiposDocto') IS NULL " &
                    "Begin CREATE TABLE [dbo].[zCEXTiposDocto](
	                [id] [int] IDENTITY(1,1) NOT NULL,
	                [tipo_docto] [nvarchar](150) NULL,
	                [id_modulo] [int] NULL,
	                [id_serviciocrm] [int] NULL,
	                [clave] [nvarchar](50) NULL
                ) ON [PRIMARY] END"
        cpCom = New SqlCommand(cQue, FC_SQL)
        cpCom.ExecuteNonQuery()
        cpCom.Dispose()

        'Tabla unificada de los modulos de escritorio para expedientes
        cQue = "IF OBJECT_ID('dbo.zClipExped') IS NULL " &
                    "Begin CREATE TABLE [dbo].[zClipExped](
	                [id] [int] IDENTITY(1,1) NOT NULL,
	                [idusuario] [int] NULL,
	                [idmodulo] [int] NULL,
	                [idcuenta] [int] NULL,
	                [periodo] [int] NULL,
	                [ejercicio] [int] NULL,
	                [tipo] [varchar](150) NULL,
	                [fecha] [varchar](50) NULL,
	                [fecha_reg] [date] NULL,
	                [descripcion] [text] NULL,
	                [version] [varchar](50) NULL,
	                [iddigital] [int] NULL,
	                [ruta] [varchar](250) NULL,
	                [ruta_original] [varchar](250) NULL,
	                [numero1] [float] NULL,
	                [numero2] [float] NULL,
	                [numero3] [float] NULL,
	                [texto1] [varchar](max) NULL,
	                [texto2] [varchar](max) NULL,
	                [texto3] [varchar](max) NULL,
	                [procesado] [bit] NULL
                ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY] END"
        cpCom = New SqlCommand(cQue, FC_SQL)
        cpCom.ExecuteNonQuery()
        cpCom.Dispose()

        FC_SQL.Close()
    End Sub
End Module
