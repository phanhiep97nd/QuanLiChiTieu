USE [phanhiep]
GO

--ALTER TABLE [dbo].[DEBT] DROP CONSTRAINT [FK__INCOME__USER_ID__48CFD27E]
--GO

/****** Object:  Table [dbo].[INCOME]    Script Date: 2022/05/06 10:53:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DEBT]') AND type in (N'U'))
DROP TABLE [dbo].[DEBT]
GO

/****** Object:  Table [dbo].[INCOME]    Script Date: 2022/05/06 10:53:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DEBT](
	[USER_ID] [int] NOT NULL,
	[DEBT_ID] [int] IDENTITY(1,1) NOT NULL,
	[INCOME_ID] [int] NOT NULL,
	[DATE_DEBT] [datetime] NOT NULL,
	[HUMAN_DEBT] [nvarchar](50) NOT NULL,
	[VALUE_DEBT] [bigint] NOT NULL,
	[STATUS_DEBT] [nvarchar](1) NOT NULL,
	[NOTE_DEBT] [nvarchar](MAX) NULL,
	[PATH_IMG_DEBT] [nvarchar](200) NOT NULL,
	[DATE_DEBT_FINISH] [datetime] NULL,
	[NOTE_DEBT_FINISH] [nvarchar](MAX) NULL,
	[PATH_IMG_DEBT_FINISH] [nvarchar](200) NULL,
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[DEBT]  WITH CHECK ADD FOREIGN KEY([USER_ID])
REFERENCES [dbo].[USER_INFO] ([USER_ID])
GO


