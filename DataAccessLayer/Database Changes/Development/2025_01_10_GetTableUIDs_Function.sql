
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Buddhika
-- Create date: 2025-01-10
-- Description:	Return Table Identifier
-- =============================================
ALTER FUNCTION GetTableUIDs(
	-- Add the parameters for the function here
	@SearhText VARCHAR(50)
)
RETURNS uniqueIdentifier
AS
BEGIN
Declare @UID uniqueidentifier
Select @UID=UID FROM Tables Where Table_Name =@SearhText
RETURN @UID

END
GO

