CREATE DATABASE ObligatorioAppWeb
go
USE ObligatorioAppWeb
go

CREATE TABLE Usuarios (
    cedula INT    PRIMARY KEY,
    nombre VARCHAR(40) not null,
    nomUsuario VARCHAR(15) UNIQUE not null
);
go

CREATE TABLE Mensajes (
    numInt INT PRIMARY KEY IDENTITY(1,1),
    cedulaE INT not null,
    cedulaR INT not null,
    fechaHora DATETIME not null,
    asunto VARCHAR(50) not null,
    texto VARCHAR(200) not null,
    FOREIGN KEY (cedulaE) REFERENCES Usuarios(cedula),
    FOREIGN KEY (cedulaR) REFERENCES Usuarios(cedula)
);
go

CREATE TABLE Privado (
  numInt INT PRIMARY KEY,
  fechaCad DATE not null,
  FOREIGN KEY (numInt) REFERENCES Mensajes(numInt)
);
go

CREATE TABLE TipoMensaje (
  codigoInterno VARCHAR(3) PRIMARY KEY,
  nombreTipo VARCHAR(20) not null
);
go

CREATE TABLE Comun (
    numInt INT PRIMARY KEY,
    codigoInterno VARCHAR(3) not null,
    FOREIGN KEY (numInt) REFERENCES Mensajes(numInt),
    FOREIGN KEY (codigoInterno) REFERENCES TipoMensaje(codigoInterno)
);



---------------- Registros ----------------------

-- Usuarios
INSERT INTO Usuarios (cedula, nombre, nomUsuario)
VALUES (12345678, 'Ezequiel Silva', 'ezephh');
go

INSERT INTO Usuarios (cedula, nombre, nomUsuario)
VALUES (87654321, 'Julia Ábalo', 'juliabalo');
go

INSERT INTO Usuarios (cedula, nombre, nomUsuario)
VALUES (37429846, 'Juan Perez ', 'carlitos');
go

INSERT INTO Usuarios (cedula, nombre, nomUsuario)
VALUES (37295744, 'Ana Silva', 'ana123');
go

INSERT INTO Usuarios (cedula, nombre, nomUsuario)
VALUES (52637125, 'Julieta Martínez', 'luisa123');
go

INSERT INTO Usuarios (cedula, nombre, nomUsuario)
VALUES (60471772, 'Pedro Paez', 'pedropa');
go

INSERT INTO Usuarios (cedula, nombre, nomUsuario)
VALUES (99918347, 'Lucas Lopez', 'lucas123');
go

INSERT INTO Usuarios (cedula, nombre, nomUsuario)
VALUES (87584883, 'Jorge Martinez', 'jorge123');
go

INSERT INTO Usuarios (cedula, nombre, nomUsuario)
VALUES (95567377, 'Julio Sánchez', 'juliosa');
go

INSERT INTO Usuarios (cedula, nombre, nomUsuario)
VALUES (10992883, 'Daniel Perez', 'daniel123');
go



-- Mensajes	
INSERT INTO Mensajes (cedulaE, cedulaR, fechaHora, asunto, texto)
VALUES (12345678, 87654321, '2023-04-22 19:30:05', 'Consulta', 'Hola ¿Cómo estás?, ¿Estás libre mañana?');
go

INSERT INTO Mensajes (cedulaE, cedulaR, fechaHora, asunto, texto)
VALUES (87654321, 12345678, '2023-04-24 16:57:23', 'Invitación', '¿Vamos al cine este sábado?');
go

INSERT INTO Mensajes (cedulaE, cedulaR, fechaHora, asunto, texto)
VALUES (37429846, 37295744, '2023-04-25 06:47:20', 'Urgente', 'Necesito que vengas a mi casa en cuanto puedas');
go

INSERT INTO Mensajes (cedulaE, cedulaR, fechaHora, asunto, texto)
VALUES (37295744, 37429846, '2023-04-26 10:29:25', 'Evento', 'El domingo a las 15 horas hay encuentro en la plaza central!');
go

INSERT INTO Mensajes (cedulaE, cedulaR, fechaHora, asunto, texto)
VALUES (52637125, 60471772, '2023-04-27 11:30:17', 'Consulta', '¿Te gustan las carreras de autos?');
go

INSERT INTO Mensajes (cedulaE, cedulaR, fechaHora, asunto, texto)
VALUES (60471772, 52637125, '2023-04-28 19:13:12', 'Informativo', 'Anoche tuve un accidente en la ruta 3 pero no pasó nada, está todo bien');
go

INSERT INTO Mensajes (cedulaE, cedulaR, fechaHora, asunto, texto)
VALUES (99918347, 87584883, '2023-04-29 18:47:26', 'Invitación', '¿Hacemos de cenar juntos hoy?');
go

INSERT INTO Mensajes (cedulaE, cedulaR, fechaHora, asunto, texto)
VALUES (87584883, 99918347, '2023-05-03 17:16:29', 'Trabajo', 'Buenas tardes, nos gustaría invitarte a una entrevista el día lunes a las 10 horas.');
go

INSERT INTO Mensajes (cedulaE, cedulaR, fechaHora, asunto, texto)
VALUES (95567377, 10992883, '2023-05-07 14:37:46', 'Evento', 'Recuerda que el miércoles nos reunimos en la oficina que vamos a tener un almuerzo de despedida');
go

INSERT INTO Mensajes (cedulaE, cedulaR, fechaHora, asunto, texto)
VALUES (10992883, 95567377, '2023-05-10 11:33:42', 'Evento', 'Carrera de autos el sábado a las 15 horas en el kartodromo de San José');
go

INSERT INTO Mensajes (cedulaE, cedulaR, fechaHora, asunto, texto)
VALUES (95567377, 87584883, '2023-05-12 12:31:03', 'Consulta', 'Hola ¿Cómo estás?, ¿Conseguiste el trabajo al final?');
go

INSERT INTO Mensajes (cedulaE, cedulaR, fechaHora, asunto, texto)
VALUES (60471772, 37429846, '2023-05-15 13:03:24', 'Urgente', 'Ven al hospital que tuve un accidente!');
go

INSERT INTO Mensajes (cedulaE, cedulaR, fechaHora, asunto, texto)
VALUES (37429846, 87584883, '2023-05-19 14:57:31', 'Informativo', 'Ganó red bull en la competencia de ayer');
go

INSERT INTO Mensajes (cedulaE, cedulaR, fechaHora, asunto, texto)
VALUES (87654321, 37295744, '2023-05-22 15:34:34', 'Invitación', '¿Vamos al teatro este sábado?');
go

INSERT INTO Mensajes (cedulaE, cedulaR, fechaHora, asunto, texto)
VALUES (37295744, 99918347, '2023-05-24 16:55:09', 'Consulta', '¿Estás libre?');
go

INSERT INTO Mensajes (cedulaE, cedulaR, fechaHora, asunto, texto)
VALUES (87654321, 99918347, '2023-05-25 09:15:11', 'Evento', 'Hoy vamos a ir al evento de gastronomía en la plaza');
go

INSERT INTO Mensajes (cedulaE, cedulaR, fechaHora, asunto, texto)
VALUES (60471772, 37295744, '2023-05-27 08:34:44', 'Informativo', 'Están agotadas las entradas para el sábado');
go

INSERT INTO Mensajes (cedulaE, cedulaR, fechaHora, asunto, texto)
VALUES (60471772, 10992883, '2023-05-27 07:32:43', 'Trabajo', 'Gracias por haberme realizado el trabajo!!!');
go

INSERT INTO Mensajes (cedulaE, cedulaR, fechaHora, asunto, texto)
VALUES (10992883, 52637125, '2023-05-28 05:24:13', 'Trabajo', 'Hola, para mañana tendré tu trabajo listo');
go

INSERT INTO Mensajes (cedulaE, cedulaR, fechaHora, asunto, texto)
VALUES (52637125, 95567377, '2023-05-29 16:22:27', 'Evento', 'Vamos a ver la película el viernes!');
go


-- MensajePrivado
INSERT INTO Privado (numInt, fechaCad)
VALUES (1, '2023-06-30');
go

INSERT INTO Privado (numInt, fechaCad)
VALUES (2, '2023-07-01');
go

INSERT INTO Privado (numInt, fechaCad)
VALUES (3, '2023-07-03');
go

INSERT INTO Privado (numInt, fechaCad)
VALUES (4, '2023-07-07');
go

INSERT INTO Privado (numInt, fechaCad)
VALUES (9, '2023-07-10');
go

INSERT INTO Privado (numInt, fechaCad)
VALUES (10, '2023-07-12');
go

INSERT INTO Privado (numInt, fechaCad)
VALUES (11, '2023-07-15');
go

INSERT INTO Privado (numInt, fechaCad)
VALUES (12, '2023-07-17');
go

INSERT INTO Privado (numInt, fechaCad)
VALUES (17, '2023-07-18');
go

INSERT INTO Privado (numInt, fechaCad)
VALUES (18, '2023-07-22');
go



-- TipoMensaje
INSERT INTO TipoMensaje (codigoInterno, nombreTipo)
VALUES ('CTA', 'Consulta');
go

INSERT INTO TipoMensaje (codigoInterno, nombreTipo)
VALUES ('ITC', 'Invitación');
go

INSERT INTO TipoMensaje (codigoInterno, nombreTipo)
VALUES ('URG', 'Urgente');
go

INSERT INTO TipoMensaje (codigoInterno, nombreTipo)
VALUES ('TBO', 'Trabajo');
go

INSERT INTO TipoMensaje (codigoInterno, nombreTipo)
VALUES ('EVT', 'Evento');
go

INSERT INTO TipoMensaje (codigoInterno, nombreTipo)
VALUES ('INF', 'Informativo');
go



-- MensajeComun
INSERT INTO Comun (numInt, codigoInterno)
VALUES (5, 'CTA');
go

INSERT INTO Comun (numInt, codigoInterno)
VALUES (6, 'INF');
go

INSERT INTO Comun (numInt, codigoInterno)
VALUES (7, 'ITC');
go

INSERT INTO Comun (numInt, codigoInterno)
VALUES (8, 'TBO');
go

INSERT INTO Comun (numInt, codigoInterno)
VALUES (13, 'INF');
go

INSERT INTO Comun (numInt, codigoInterno)
VALUES (14, 'ITC');
go

INSERT INTO Comun (numInt, codigoInterno)
VALUES (15, 'CTA');
go

INSERT INTO Comun (numInt, codigoInterno)
VALUES (16, 'EVT');
go

INSERT INTO Comun (numInt, codigoInterno)
VALUES (19, 'TBO');
go

INSERT INTO Comun (numInt, codigoInterno)
VALUES (20, 'EVT');
go


--------------- Stored Procedures -----------------

-------------------------- Inicio Usuarios --------------------------

CREATE PROCEDURE BuscarUsuario @cedula INT AS
BEGIN
		SELECT * FROM Usuarios WHERE cedula = @cedula
END
GO

CREATE PROCEDURE AltaUsuario @cedula INT, @nombre VARCHAR(40), @nomUsuario VARCHAR(15) AS

BEGIN
	IF EXISTS (SELECT * FROM Usuarios WHERE cedula = @cedula)
	BEGIN
		RETURN -1; -- Existe el usuario
	END ELSE
BEGIN
		INSERT Usuarios (cedula, nombre, nomUsuario) VALUES (@cedula, @nombre, @nomUsuario);

		IF @@ERROR != 0
		BEGIN
			RETURN -2; -- No se dió de alta
		END
		RETURN 1; -- Se dió de alta
	END
END
GO



CREATE PROCEDURE EditarUsuario @cedula INT, @nombre VARCHAR(40), @nomUsuario VARCHAR(15) AS

BEGIN
    IF EXISTS (SELECT 1 FROM Usuarios WHERE cedula = @cedula)
	BEGIN	
			UPDATE Usuarios
		SET Nombre = @nombre,
			nomUsuario = @nomUsuario
		WHERE cedula = @cedula;

		RETURN 0; -- Editado
	END
		ELSE BEGIN 
			RETURN -1; -- No hay usuario
		END
END
GO


CREATE PROCEDURE EliminarUsuario @cedula INT AS

BEGIN
        IF(NOT EXISTS (SELECT * FROM Usuarios WHERE cedula = @cedula))
            RETURN -1 -- Busco al usuario

		IF EXISTS (SELECT * FROM Mensajes WHERE cedulaE = @cedula OR cedulaR = @cedula)
        RETURN -3; -- Indico que hay mensajes asociados
        
		DELETE FROM Usuarios WHERE cedula = @cedula;
        
		IF @@ERROR != 0
            
		BEGIN
			RETURN -2; -- No se eliminó
		END
        RETURN 1; -- Usuario eliminado
END 
go
-------------------------- Fin Mantenimiento Usuarios ---------------------------

------------------------- Inicio Mantenimiento TipoMensaje ----------------------

CREATE PROCEDURE BuscarTipoMensaje @codigoInterno VARCHAR(3) AS
BEGIN
		SELECT * FROM TipoMensaje WHERE codigoInterno = @codigoInterno
END
GO

CREATE PROCEDURE AltaTipoMensaje @codigoInterno VARCHAR(3), @nombreTipo VARCHAR(20) AS

BEGIN
    IF EXISTS (SELECT 1 FROM TipoMensaje WHERE codigoInterno = @codigoInterno)
    BEGIN
        RETURN -1; -- Ya existe
    END
    ELSE
    BEGIN
        INSERT TipoMensaje (codigoInterno, nombreTipo) VALUES (@codigoInterno, @nombreTipo);

        IF @@ERROR != 0
        BEGIN
            RETURN -2; -- No se dió de alta
        END

        RETURN 1; -- Se dió de alta
    END
END
GO

CREATE PROCEDURE EditarTipoMensaje @codigoInterno VARCHAR(3), @nombreTipo VARCHAR(20) AS

BEGIN
	IF EXISTS (SELECT 1 FROM TipoMensaje WHERE codigoInterno = @codigoInterno)
	BEGIN
		UPDATE TipoMensaje
		SET nombreTipo = @nombreTipo
		WHERE codigoInterno = @codigoInterno;

		RETURN 0; -- Editado
	END
	ELSE
	BEGIN
		RETURN -1; -- No existe TipoMensaje
	END
END
GO

CREATE PROCEDURE EliminarTipoMensaje @codigoInterno VARCHAR(3) AS

BEGIN
    IF NOT EXISTS (SELECT 1 FROM TipoMensaje WHERE codigoInterno = @codigoInterno)
        RETURN -1; -- No existe


    IF EXISTS (SELECT 1 FROM Comun WHERE codigoInterno = @codigoInterno)
        RETURN -3; -- Tiene mensajes asociados
    
    DELETE FROM TipoMensaje WHERE codigoInterno = @codigoInterno;
    
    IF @@ERROR != 0
    BEGIN
        RETURN -2; -- No se eliminó
    END

    RETURN 1; -- Usuario eliminado
END
GO



--------------------------- Fin Mantenimiento TipoMensaje -----------------------

------------------------------- Inicio Agregar Privado ---------------------------------

CREATE PROCEDURE AgregarPrivado
	@cedulaE INT,
	@cedulaR INT,
	@fechaHora DATETIME,
	@fechaCad DATETIME,
	@asunto VARCHAR(50),
	@texto VARCHAR(200)
AS
BEGIN
	IF NOT EXISTS (SELECT 1 FROM Usuarios WHERE cedula = @cedulaE)
	BEGIN
		RETURN -1; --No existe
	END

	IF NOT EXISTS (SELECT 1 FROM Usuarios WHERE cedula = @cedulaR)
	BEGIN
		RETURN -2; --No existe
	END

	IF @fechaCad <= GETDATE()
	BEGIN
		RETURN -3; -- La fecha tiene que ser posterior a hoy
	END

	DECLARE @numInt INT;
	BEGIN TRY
		BEGIN TRAN

		INSERT Mensajes (cedulaE, cedulaR, fechaHora, asunto, texto)
		VALUES (@cedulaE, @cedulaR, @fechaHora, @asunto, @texto)

		SET @numInt = IDENT_CURRENT('Mensajes');

		INSERT Privado (numInt, fechaCad)
		VALUES (@numInt, @fechaCad)

		COMMIT;

		RETURN @numInt;
	END TRY
	BEGIN CATCH
		ROLLBACK;

	RETURN -4;
	END CATCH
END
GO

------------------------------- Fin Agregar Privado ---------------------------------

------------------------------- Inicio Agregar Comun ---------------------------------

CREATE PROC AgregarComun 
	@cedulaE INT,
	@cedulaR INT,
	@fechaHora DATETIME,
    @asunto VARCHAR(50),
    @texto VARCHAR(200),
    @codigoInterno VARCHAR(3)
AS
BEGIN
	IF NOT EXISTS (SELECT 1 FROM Usuarios WHERE cedula = @cedulaE)
	BEGIN
		RETURN -1;
	END

	IF NOT EXISTS (SELECT 1 FROM Usuarios WHERE cedula = @cedulaR)
	BEGIN
		RETURN -2;
	END

	IF NOT EXISTS (SELECT 1 FROM TipoMensaje WHERE codigoInterno = @codigoInterno)
	BEGIN
		RETURN -3;
	END

	DECLARE @numInt INT;
	BEGIN TRY 
		BEGIN TRAN;

		INSERT Mensajes (cedulaE, cedulaR, fechaHora, asunto, texto)
		VALUES (@cedulaE, @cedulaR, @fechaHora, @asunto, @texto)

		SET @numInt = IDENT_CURRENT('Mensajes');

		INSERT Comun (numInt, codigoInterno)
		VALUES (@numInt, @codigoInterno);

		COMMIT;

		RETURN 1; -- Se envió
	END TRY
	BEGIN CATCH
		ROLLBACK;

		RETURN -4; -- Error
	END CATCH;
END
GO

------------------------------- Fin Agregar Comun ---------------------------------

------------------------------- Inicio ListarMensajeComunPorUsuario ---------------------------------

CREATE PROCEDURE ListarMensajesComunesDeUnUsuario
    @codigoInterno VARCHAR(3),
    @cedulaUsuario INT,
    @listado BIT
AS
BEGIN
    SELECT m.numInt, m.fechaHora, m.asunto, m.texto, c.codigoInterno, m.cedulaE, m.cedulaR
    FROM Mensajes m
    INNER JOIN Comun c ON m.numInt = c.numInt
    WHERE c.codigoInterno = @codigoInterno AND 
          ((@listado = 1 AND m.cedulaE = @cedulaUsuario) OR (@listado = 0 AND m.cedulaR = @cedulaUsuario));
END
GO

------------------------------- Fin ListarMensajeComunPorUsuario ---------------------------------

------------------------------- Inicio ListadoMensajesPrivadosEnviados ---------------------------------

CREATE PROCEDURE ListarMensajesPrivadosEnviados
    @cedula INT
AS
BEGIN
    SELECT m.numInt, m.fechaHora, m.asunto, m.texto, p.fechaCad, m.cedulaE, m.cedulaR
    FROM Mensajes m
    INNER JOIN Privado p ON m.numInt = p.numInt
    WHERE m.cedulaE = @cedula;
END
GO


------------------------------- Fin ListadoMensajesPrivadosEnviados ---------------------------------

------------------------------- Inicio ListadoMensajesPrivadosRecibidos ---------------------------------


CREATE PROCEDURE ListarMensajesPrivadosRecibidos
    @cedula INT
AS
BEGIN
    SELECT m.numInt, m.fechaHora, m.asunto, m.texto, p.fechaCad, m.cedulaE, m.cedulaR
    FROM Mensajes m
    INNER JOIN Privado p ON m.numInt = p.numInt
    WHERE m.cedulaR = @cedula AND p.fechaCad > GETDATE();
END
GO

------------------------------- Fin ListadoMensajesPrivadosRecibidos ---------------------------------

CREATE PROCEDURE ListarTipoMensaje
AS
BEGIN
    SELECT codigoInterno, nombreTipo
    FROM TipoMensaje;
END
go

CREATE PROCEDURE ListarUsuarios
AS
BEGIN
    SELECT cedula, nombre, nomUsuario
    FROM Usuarios;
END
