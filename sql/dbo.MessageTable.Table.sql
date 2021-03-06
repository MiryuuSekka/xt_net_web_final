USE [test_shop]
GO
/****** Object:  Table [dbo].[MessageTable]    Script Date: 09.03.2020 8:17:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MessageTable](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_lot] [int] NOT NULL,
	[id_theme] [int] NOT NULL,
	[message] [varchar](max) NOT NULL,
	[id_bet] [int] NOT NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[MessageTable]  WITH CHECK ADD  CONSTRAINT [FK_Message_BetTable] FOREIGN KEY([id_bet])
REFERENCES [dbo].[BetTable] ([id_bet])
GO
ALTER TABLE [dbo].[MessageTable] CHECK CONSTRAINT [FK_Message_BetTable]
GO
ALTER TABLE [dbo].[MessageTable]  WITH CHECK ADD  CONSTRAINT [FK_Message_LotTable] FOREIGN KEY([id_lot])
REFERENCES [dbo].[LotTable] ([id_lot])
GO
ALTER TABLE [dbo].[MessageTable] CHECK CONSTRAINT [FK_Message_LotTable]
GO
ALTER TABLE [dbo].[MessageTable]  WITH CHECK ADD  CONSTRAINT [FK_Message_themes] FOREIGN KEY([id_theme])
REFERENCES [dbo].[themes] ([id])
GO
ALTER TABLE [dbo].[MessageTable] CHECK CONSTRAINT [FK_Message_themes]
GO
