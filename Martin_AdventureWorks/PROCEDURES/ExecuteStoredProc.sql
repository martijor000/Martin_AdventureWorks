USE [AdventureWorks2019]
GO

DECLARE @RC int

-- TODO: Set parameter values here.

EXECUTE @RC = [dbo].[MasterListOfNames] 
GO

USE [AdventureWorks2019]
GO

DECLARE @RC int
DECLARE @SelectedID int

-- TODO: Set parameter values here.

EXECUTE @RC = [dbo].[PersonDetails] 
   @SelectedID
GO



