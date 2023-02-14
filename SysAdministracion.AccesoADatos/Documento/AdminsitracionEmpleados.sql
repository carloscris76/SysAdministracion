USE [master]
GO
CREATE DATABASE [Administraciondb]
GO
USE [Administraciondb]
GO

CREATE TABLE dbo.Empleados(
	Id int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Nombre varchar(60) NOT NULL,
	Apellido varchar(60) NOT NULL,
	DUI varchar(10) NOT NULL,
	Area tinyint NOT NULL,
	Carga tinyint NOT NULL,
);
