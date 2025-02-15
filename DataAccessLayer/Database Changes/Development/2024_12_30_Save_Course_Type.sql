USE [GITStudent]
GO
/****** Object:  StoredProcedure [dbo].[Save_Course_Type]    Script Date: 12/30/2024 11:34:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Buddhika
-- Create date: 2024-12-30
-- Description:	Save Course Type
-- =============================================
ALTER PROCEDURE [dbo].[Save_Course_Type]
	-- Add the parameters for the stored procedure here
	@UID   uniqueidentifier,
    @Course_Type_ID  varchar(10),
	@Course_Type_Description varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	IF EXISTS(SELECT  Course_Type_Id FROM Course_Type  WHERE UID=@UID)
	BEGIN

UPDATE [dbo].[Course_Type]
   SET
      [Course_Type_Id] = @Course_Type_ID
      ,[Course_Type_Description] = @Course_Type_Description
WHERE UID=@UID

	END
	ELSE
	BEGIN
	INSERT INTO [dbo].[Course_Type]
           ([UId]
           ,[Course_Type_Id]
           ,[Course_Type_Description])
     VALUES
           (@UID 
           , @Course_Type_ID
           ,@Course_Type_Description)
   END
END
