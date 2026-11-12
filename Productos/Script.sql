CREATE DATABASE db_papeleria;
GO 
USE db_papeleria;
GO 

CREATE TABLE [Productos] (
    [id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [codigo] NVARCHAR(20) NOT NULL,
    [nombre] NVARCHAR(50) NOT NULL,
    [precio] DECIMAL(18, 2) NOT NULL,
    [descripcion] NVARCHAR(50) NOT NULL,
);
