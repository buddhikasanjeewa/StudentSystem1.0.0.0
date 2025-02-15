USE [GITStudent]
GO
/****** Object:  StoredProcedure [dbo].[Save_Course]    Script Date: 12/30/2024 11:08:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Buddhika
-- Create date: 2024-12-30
-- Description:	Save Course Data
-- =============================================
ALTER PROCEDURE [dbo].[Save_Course]
	-- Add the parameters for the stored procedure here
	@UID   uniqueidentifier,
	@Course_Code  varchar(50),
    @Course_Type_UID uniqueidentifier,
	@Course_Description varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	IF EXISTS(SELECT Course_Code FROM Courses  WHERE UID=@UID)
	BEGIN
UPDATE [dbo].[Courses]
SET 
      [Course_Code] = @Course_Code
      ,[Course_Type_UID] = @Course_Type_UID
      ,[Course_Description] = @Course_Description
 WHERE UID=@UID
	END
	ELSE
	BEGIN
INSERT INTO [dbo].[Courses]
           ([UID]
           ,[Course_Code]
           ,[Course_Type_UID]
           ,[Course_Description])
     VALUES
           (@UID
           ,@Course_Code
           ,@Course_Type_UID
           ,@Course_Description)
   END
END
