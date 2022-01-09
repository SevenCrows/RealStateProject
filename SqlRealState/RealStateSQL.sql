--Crear base de datos realstate
IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'realstate')
  BEGIN
    CREATE DATABASE realstate
END
GO
    USE realstate
GO


--Crear tabla PropertyImage
IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES
                 WHERE TABLE_SCHEMA = 'dbo'
                 AND  TABLE_NAME = 'PropertyImage'))
BEGIN
    CREATE TABLE PropertyImage (
        IdPropertyImage UNIQUEIDENTIFIER PRIMARY KEY,
        IdProperty UNIQUEIDENTIFIER NOT NULL,
        "File" VARBINARY(MAX) NOT NULL,
        Enabled BIT DEFAULT 1
    )
END


--CREATE TABLE Property
IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES
                 WHERE TABLE_SCHEMA = 'dbo'
                 AND  TABLE_NAME = 'Property'))
BEGIN
    CREATE TABLE Property (
        IdProperty UNIQUEIDENTIFIER PRIMARY KEY,
        Name VARCHAR(250) NOT NULL,
        Address VARCHAR(300) NOT NULL,
        Price DECIMAL(19,4) NOT NULL,
        CodeInternal VARCHAR(25) NOT NULL,
        Year DATE NOT NULL,
        IdOwner UNIQUEIDENTIFIER NOT NULL
    )
END


--CREATE TABLE Owner
IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES
                 WHERE TABLE_SCHEMA = 'dbo'
                 AND  TABLE_NAME = 'Owner'))
BEGIN
    CREATE TABLE Owner (
        IdOwner UNIQUEIDENTIFIER PRIMARY KEY,
        Name VARCHAR(200) NOT NULL,
        FirstSurname VARCHAR(80) NOT NULL,
        SecondSurname VARCHAR(80) NOT NULL,
        Address VARCHAR(300) NOT NULL,
        Photo VARBINARY(MAX) NOT NULL,
        Birthday DATE NOT NULL
    )
END


--CREATE TABLE PropertyTrace
IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES
                 WHERE TABLE_SCHEMA = 'dbo'
                 AND  TABLE_NAME = 'PropertyTrace'))
BEGIN
    CREATE TABLE PropertyTrace (
        IdPropertyTrace UNIQUEIDENTIFIER PRIMARY KEY,
        DateSale DATETIME NOT NULL,
        Name VARCHAR(250) NOT NULL,
        Value VARCHAR(250) NOT NULL,
        Tax DECIMAL(19,4) NOT NULL,
        IdProperty UNIQUEIDENTIFIER NOT NULL
    )
END


--Crear relaciones tablas
ALTER TABLE PropertyTrace
  ADD CONSTRAINT FK_PropertyTrace_Property FOREIGN KEY (IdProperty)
    REFERENCES Property (IdProperty);

ALTER TABLE PropertyImage
  ADD CONSTRAINT FK_PropertyImage_Property FOREIGN KEY (IdProperty)
    REFERENCES Property (IdProperty);

ALTER TABLE Property
  ADD CONSTRAINT FK_Property_Owner FOREIGN KEY (IdOwner)
    REFERENCES Owner (IdOwner);