USE [SportsBuddyDB]
GO

/****** Object:  Table [dbo].[Event]    Script Date: 9/1/2021 5:33:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Event](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AuthorId] [int] NOT NULL,
	[Title] [varchar](150) NOT NULL,
	[Description] [varchar](250) NULL,
	[Goal] [varchar](150) NOT NULL,
	[AddressID] [int] NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[Duration] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Event]  WITH CHECK ADD FOREIGN KEY([AddressID])
REFERENCES [dbo].[Addresses] ([Id])
GO

ALTER TABLE [dbo].[Event]  WITH CHECK ADD FOREIGN KEY([AuthorId])
REFERENCES [dbo].[User] ([Id])
GO


