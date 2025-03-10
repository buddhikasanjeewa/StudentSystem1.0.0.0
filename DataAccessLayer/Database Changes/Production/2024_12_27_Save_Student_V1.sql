USE [GITStudent]
GO
/****** Object:  StoredProcedure [dbo].[Save_Student]    Script Date: 12/27/2024 2:35:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Buddhika
-- Create date: 2024-11-26
-- Description:	SAVE Student Data
-- =============================================
ALTER PROCEDURE [dbo].[Save_Student]
	-- Add the parameters for the stored procedure here
	@Id   uniqueidentifier,
	@StudentCode  varchar(50),
	@FirstName varchar(50),
	@LastName varchar(50),
	@Address varchar(250),
	@mobile varchar(20),
	@email varchar(50),
   @DOB datetime,
	@NIC VARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	IF EXISTS(SELECT  StudentCode FROM Student_Personal  WHERE UID=@Id  AND StudentCode=@StudentCode)
	BEGIN
	UPDATE [dbo].[Student_Personal]
   SET 
     
      [FirstName] = @FirstName
      ,[LastName] = @LastName
      ,[Address] = @Address
      ,[Mobile] =@mobile
      ,[Email] = @email
      ,[DOB] =@DOB
      ,[NIC] =@NIC
 WHERE UID=@Id  AND StudentCode=@StudentCode
	END
	ELSE
	BEGIN
   INSERT INTO [dbo].[Student_Personal]
           ([UID]
           ,[StudentCode]
           ,[FirstName]
           ,[LastName]
           ,[Address]
           ,[Mobile]
           ,[Email]
           ,[DOB]
           ,[NIC])
     VALUES
           (@Id 
           ,@StudentCode 
           ,@FirstName
           ,@LastName
           ,@Address
           ,@mobile
           ,@email 
         ,@DOB
           ,@NIC)
   END
END
