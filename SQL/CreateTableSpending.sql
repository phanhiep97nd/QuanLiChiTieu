USE [phanhiep]
GO

ALTER TABLE [dbo].[SPENDING] DROP CONSTRAINT [fk_id_user]
GO

/****** Object:  Table [dbo].[SPENDING]    Script Date: 5/7/2022 11:39:55 PM ******/
DROP TABLE [dbo].[SPENDING]
GO

/****** Object:  Table [dbo].[SPENDING]    Script Date: 5/7/2022 11:39:55 PM ******/
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
	[NOTE_SPENDING] [nvarchar](MAX) NOT NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[SPENDING]  WITH CHECK ADD  CONSTRAINT [fk_id_user] FOREIGN KEY([USER_ID])
REFERENCES [dbo].[USER_INFO] ([USER_ID])
GO

ALTER TABLE [dbo].[SPENDING] CHECK CONSTRAINT [fk_id_user]
GO


