USE [quanlichitieuphanhiep]
GO

--ALTER TABLE [dbo].[LOAN] DROP CONSTRAINT [FK__INCOME__USER_ID__48CFD27E]
--GO

/****** Object:  Table [dbo].[INCOME]    Script Date: 2022/05/06 10:53:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LOAN]') AND type in (N'U'))
DROP TABLE [dbo].[LOAN]
GO

/****** Object:  Table [dbo].[INCOME]    Script Date: 2022/05/06 10:53:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LOAN](
	[USER_ID] [int] NOT NULL,
	[LOAN_ID] [int] IDENTITY(1,1) NOT NULL,
	[SPENDING_ID] [int] NOT NULL,
	[DATE_LOAN] [datetime] NOT NULL,
	[HUMAN_LOAN] [nvarchar](50) NOT NULL,
	[VALUE_LOAN] [bigint] NOT NULL,
	[STATUS_LOAN] [nvarchar](1) NOT NULL,
	[NOTE_LOAN] [nvarchar](MAX) NULL,
	[PATH_IMG_LOAN] [nvarchar](200) NOT NULL,
	[DATE_LOAN_FINISH] [datetime] NULL,
	[NOTE_LOAN_FINISH] [nvarchar](MAX) NULL,
	[PATH_IMG_LOAN_FINISH] [nvarchar](200) NULL,
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[LOAN]  WITH CHECK ADD FOREIGN KEY([USER_ID])
REFERENCES [dbo].[USER_INFO] ([USER_ID])
GO


