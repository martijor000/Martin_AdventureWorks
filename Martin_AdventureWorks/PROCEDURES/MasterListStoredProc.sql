USE [AdventureWorks2019]
GO

/****** Object:  StoredProcedure [dbo].[MasterListOfNames]    Script Date: 1/9/2024 10:50:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[MasterListOfNames]
AS
SELECT BusinessEntityID, FirstName, LastName FROM [Person].[Person]
ORDER BY FirstName ASC, LastName ASC
GO


