
-------------------------------------------------------------------------
-- CREACION DE LA BASE DE DATOS
-------------------------------------------------------------------------

USE [master]
GO

CREATE DATABASE [CasoEstudioKN]
GO

USE [CasoEstudioKN]
GO

-------------------------------------------------------------------------
-- CREACION DE LA TABLA
-------------------------------------------------------------------------

CREATE TABLE CasasSistema
(
	IdCasa				BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	DescripcionCasa		VARCHAR(30) NOT NULL,
	PrecioCasa			DECIMAL(10,2) NOT NULL,
	UsuarioAlquiler		VARCHAR(30) NULL,
	FechaAlquiler		DATETIME NULL
);


-------------------------------------------------------------------------
-- INSERTAR DATOS EN LA TABLA
-------------------------------------------------------------------------

INSERT INTO [dbo].[CasasSistema] ([DescripcionCasa],[PrecioCasa],[UsuarioAlquiler],[FechaAlquiler])
VALUES ('Casa en San José',190000,null,null)
INSERT INTO [dbo].[CasasSistema] ([DescripcionCasa],[PrecioCasa],[UsuarioAlquiler],[FechaAlquiler])
VALUES ('Casa en Alajuela',145000,null,null)
INSERT INTO [dbo].[CasasSistema] ([DescripcionCasa],[PrecioCasa],[UsuarioAlquiler],[FechaAlquiler])
VALUES ('Casa en Cartago',115000,null,null)
INSERT INTO [dbo].[CasasSistema] ([DescripcionCasa],[PrecioCasa],[UsuarioAlquiler],[FechaAlquiler])
VALUES ('Casa en Heredia',122000,null,null)
INSERT INTO [dbo].[CasasSistema] ([DescripcionCasa],[PrecioCasa],[UsuarioAlquiler],[FechaAlquiler])
VALUES ('Casa en Guanacaste',105000,null,null)
GO

-------------------------------------------------------------------------
-- PROCEDIMIENTOS ALMACENADOS	
-------------------------------------------------------------------------


-- Procedimiento almacenado para consultar casas
CREATE PROCEDURE ConsultarCasas
AS
BEGIN
	SELECT IdCasa, DescripcionCasa, PrecioCasa, UsuarioAlquiler, Estado, FechaAlquiler
	FROM (
		SELECT	IdCasa, 
			DescripcionCasa, 
			PrecioCasa,
			ISNULL(UsuarioAlquiler, 'Sin cliente') 'UsuarioAlquiler',
			CASE 
				WHEN UsuarioAlquiler IS NOT NULL
				THEN 'Reservada'
				ELSE 'Disponible'
			END AS 'Estado',
			CAST(ISNULL(FORMAT(FechaAlquiler, 'dd/MM/yyyy'), 'Sin fecha') AS VARCHAR) AS 'FechaAlquiler'
	FROM CasasSistema
	WHERE PrecioCasa <= 180000.00
	AND	  PrecioCasa >= 115000.00
	)X
	ORDER BY Estado ASC	
END
GO

CREATE PROCEDURE ListaCasas
AS
BEGIN
		SELECT	IdCasa, 
				DescripcionCasa
		FROM CasasSistema
		WHERE UsuarioAlquiler IS NULL
END
GO

CREATE PROCEDURE ConsultarCasa
@IdCasa				BIGINT
AS
BEGIN	
	SELECT	IdCasa, 
		DescripcionCasa, 
		PrecioCasa
	FROM CasasSistema
	WHERE IdCasa = @IdCasa
END
GO

CREATE PROCEDURE AlquilarCasa
@IdCasa				BIGINT,
@UsuarioAlquiler	VARCHAR(30)
AS
BEGIN
	UPDATE CasasSistema
	SET	   UsuarioAlquiler = @UsuarioAlquiler,
		   FechaAlquiler = GETDATE()
	WHERE IdCasa = @IdCasa
END
GO




		