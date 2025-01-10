USE [GITStudent]
GO

/****** Object:  Table [dbo].[ActivityLog]    Script Date: 1/10/2025 11:20:10 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ActivityLog](
	[TableUID] [uniqueidentifier] NOT NULL,
	[TableId] [int] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[CreatedUID] [uniqueidentifier] NOT NULL,
	[Modified_Date] [datetime] NOT NULL,
	[ModifiedUID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[TableUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ActivityLog]  WITH CHECK ADD  CONSTRAINT [FK_Log_Users] FOREIGN KEY([CreatedUID])
REFERENCES [dbo].[Users] ([UID])
GO

ALTER TABLE [dbo].[ActivityLog] CHECK CONSTRAINT [FK_Log_Users]
GO

ALTER TABLE [dbo].[ActivityLog]  WITH CHECK ADD  CONSTRAINT [FK_Log_Users1] FOREIGN KEY([ModifiedUID])
REFERENCES [dbo].[Users] ([UID])
GO

ALTER TABLE [dbo].[ActivityLog] CHECK CONSTRAINT [FK_Log_Users1]
GO


