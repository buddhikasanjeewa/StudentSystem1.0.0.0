USE [GITStudent]
GO
/****** Object:  StoredProcedure [dbo].[Get_CourseTypeData]    Script Date: 12/30/2024 11:35:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Buddhika
-- Create date: 2024-12-30
-- Description:	Get Course Data
-- =============================================
ALTER PROCEDURE [dbo].[Get_CourseTypeData]

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
	SELECT * from Course_Type
	END

	ELSE IF(@type=2)
	BEGIN
	SELECT * from Course_Type Where Course_Type_Description LIKE '%' + @SeachCriteria +'%'

	END
END	
