USE [quanlichitieuphanhiep]
GO

ALTER TABLE [dbo].[SPENDING] DROP CONSTRAINT [fk_id_user]
GO

/****** Object:  Table [dbo].[SPENDING]    Script Date: 2022/05/06 11:24:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SPENDING]') AND type in (N'U'))
DROP TABLE [dbo].[SPENDING]
GO

/****** Object:  Table [dbo].[SPENDING]    Script Date: 2022/05/06 11:24:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SPENDING](
	[USER_ID] [int] NOT NULL,
	[SPENDING_ID] [int] IDENTITY(1,1) NOT NULL,
	[VALUE_SPENDING] [bigint] NOT NULL,
	[TYPE_SPENDING] [nvarchar](1) NOT NULL,
	[DATE_SPENDING] [datetime] NOT NULL,
	[NOTE_SPENDING] [nvarchar](200) NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SPENDING]  WITH CHECK ADD  CONSTRAINT [fk_id_user] FOREIGN KEY([USER_ID])
REFERENCES [dbo].[USER_INFO] ([USER_ID])
GO

ALTER TABLE [dbo].[SPENDING] CHECK CONSTRAINT [fk_id_user]
GO


