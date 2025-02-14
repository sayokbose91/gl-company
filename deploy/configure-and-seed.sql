IF DB_ID('gldb') IS NULL
    BEGIN
        CREATE DATABASE gldb;
    END
GO

USE gldb;
GO

IF OBJECT_ID('dbo.Companies', 'U') IS NULL
    BEGIN
        CREATE TABLE dbo.Companies
        (
            Id INT IDENTITY(1,1) PRIMARY KEY,
            Name NVARCHAR(255) NOT NULL,
            Exchange NVARCHAR(100) NOT NULL,
            Ticker NVARCHAR(50) NOT NULL,
            Isin CHAR(12) NOT NULL,
            Website NVARCHAR(255) NULL,
            CONSTRAINT UQ_Companies_Isin UNIQUE (Isin),
            CONSTRAINT CK_Companies_Isin_Format CHECK (
                Isin LIKE '[A-Za-z][A-Za-z]%')
        );
    END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Companies)
    BEGIN
        INSERT INTO dbo.Companies (Name, Exchange, Ticker, Isin, Website)
        VALUES
            ('Apple Inc.', 'NASDAQ', 'AAPL', 'US0378331005', 'http://www.apple.com'),
            ('British Airways Plc', 'Pink Sheets', 'BAIRY', 'US1104193065', NULL),
            ('Heineken NV', 'Euronext Amsterdam', 'HEIA', 'NL0000009165', NULL),
            ('Panasonic Corp', 'Tokyo Stock Exchange', '6752', 'JP3866800000', 'http://www.panasonic.co.jp'),
            ('Porsche Automobil', 'Deutsche Börse', 'PAH3', 'DE000PAH0038', 'https://www.porsche.com/');
    END
GO
