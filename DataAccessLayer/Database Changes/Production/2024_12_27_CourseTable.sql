USE [GITStudent]
GO

/****** Object:  Table [dbo].[Courses]    Script Date: 12/27/2024 8:49:12 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Courses](
	[UID] [uniqueidentifier] NOT NULL,
	[Course_Code] [varchar](10) NOT NULL,
	[Course_Type_UID] [uniqueidentifier] NOT NULL,
	[Course_Description] [varchar](250) NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Course_Type] FOREIGN KEY([Course_Type_UID])
REFERENCES [dbo].[Course_Type] ([UId])
GO

ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_Course_Type]
GO


