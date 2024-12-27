USE [GITStudent]
GO

/****** Object:  Table [dbo].[Course_Type]    Script Date: 12/27/2024 8:47:39 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Course_Type](
	[UId] [uniqueidentifier] NOT NULL,
	[Course_Type_Id] [int] NOT NULL,
	[Course_Type_Description] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Course_Type] PRIMARY KEY CLUSTERED 
(
	[UId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


