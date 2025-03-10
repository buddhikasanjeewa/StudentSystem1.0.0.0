USE [GITStudent]
GO
/****** Object:  StoredProcedure [dbo].[Get_StudentData]    Script Date: 12/30/2024 4:09:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Buddhika
-- Create date: 2024-11-26
-- Description:	Get Student Data
-- =============================================
ALTER PROCEDURE [dbo].[Get_StudentData]

	@SeachCriteria nvarchar(50),
	@type int 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if(@type=1)  --All
	BEGIN
	SELECT * from Student_Personal
	END
	
	ELSE IF(@type=2)
	BEGIN
	SELECT * from Student_Personal WHERE (Mobile=@SeachCriteria OR Email =@SeachCriteria  OR NIC=@SeachCriteria or FirstName like '%' + @SeachCriteria +'%'  or LastName LIKE '%' + @SeachCriteria +'%')

	END
END	
