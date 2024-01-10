USE [AdventureWorks2019]
GO

/****** Object:  StoredProcedure [dbo].[PersonDetails]    Script Date: 1/9/2024 10:51:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PersonDetails]
@SelectedID int

AS
SELECT BusinessEntityID, FirstName, MiddleName, LastName, Title,
Suffix, PersonType, EmailPromotion, AdditionalContactInfo
FROM [Person].[Person]
WHERE BusinessEntityID = @SelectedID
GO


