USE [GITStudent]
GO
/****** Object:  StoredProcedure [dbo].[Delete_Students]    Script Date: 12/30/2024 11:26:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:    Buddhika Walpita
-- Create date: 2024-12-13
-- Description:  Delete_Data
-- =============================================
ALTER PROCEDURE [dbo].[Delete_Students]
  -- Add the parameters for the stored procedure here
  @Id      UNIQUEIDENTIFIER

AS
  BEGIN
      -- SET NOCOUNT ON added to prevent extra result sets from
      -- interfering with SELECT statements.
      SET nocount ON;

      -- Insert statements for procedure here
      DELETE FROM student_personal
      WHERE  UID = @Id
             
  END

