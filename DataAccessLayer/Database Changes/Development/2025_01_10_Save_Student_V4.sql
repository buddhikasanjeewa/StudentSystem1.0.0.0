USE [GITStudent]
GO
/****** Object:  StoredProcedure [dbo].[Save_Student]    Script Date: 1/10/2025 4:33:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:    Buddhika
-- Create date: 2024-11-26
-- Description:  SAVE Student Data
-- =============================================
--History
-- =============================================
-- Author:    Buddhika
-- Create date: 2024-12-30
-- Description:  Remove Student code from filtering
-- =============================================
--History
-- Author:    Buddhika
-- Create date: 2025-01-10
-- Description:  Add Transaction,Error Handeling,Add Acitivity log
-- =============================================
ALTER PROCEDURE [dbo].[Save_Student]
  -- Add the parameters for the stored procedure here
  @Id          UNIQUEIDENTIFIER,
  @StudentCode VARCHAR(50),
  @FirstName   VARCHAR(50),
  @LastName    VARCHAR(50),
  @Address     VARCHAR(250),
  @mobile      VARCHAR(20),
  @email       VARCHAR(50),
  @DOB         DATETIME,
  @NIC         VARCHAR(50),
  @TableUID    UNIQUEIDENTIFIER,
  @UserCUid    UNIQUEIDENTIFIER,
  @UserMUid    UNIQUEIDENTIFIER
AS
  BEGIN
      -- SET NOCOUNT ON added to prevent extra result sets from
      -- interfering with SELECT statements.
      SET nocount ON;
	  Declare @RTableUID uniqueidentifier

      BEGIN TRAN savestudentdetails

      BEGIN Try
	 SET @RTableUID = [dbo].[GetTableUIDs]('Student Personal')
          IF EXISTS(SELECT studentcode
                    FROM   student_personal
                    WHERE  uid = @Id)
            BEGIN
                UPDATE [dbo].[student_personal]
                SET    [firstname] = @FirstName,
                       [lastname] = @LastName,
                       [address] = @Address,
                       [mobile] = @mobile,
                       [email] = @email,
                       [dob] = @DOB,
                       [nic] = @NIC
                WHERE  uid = @Id

                UPDATE [dbo].[activitylog]
                SET    [modified_date] = Getdate(),
                       [modifieduid] = @UserMUid
                WHERE  UID = @TableUID
            END
          ELSE
            BEGIN
                INSERT INTO [dbo].[student_personal]
                            ([uid],
                             [studentcode],
                             [firstname],
                             [lastname],
                             [address],
                             [mobile],
                             [email],
                             [dob],
                             [nic])
                VALUES      (@Id,
                             @StudentCode,
                             @FirstName,
                             @LastName,
                             @Address,
                             @mobile,
                             @email,
                             @DOB,
                             @NIC)

                INSERT INTO [dbo].[activitylog]
                            (TableUID,
                             [created_date],
                             [createduid],
                             [modified_date],
                             [modifieduid])
                VALUES      ( @RTableUID,
                             Getdate(),
                             @UserCUid,
                             Getdate(),
                             @UserMUid)
            END

          COMMIT TRAN
      END try

      BEGIN catch
          ROLLBACK TRAN
      END catch
  END 