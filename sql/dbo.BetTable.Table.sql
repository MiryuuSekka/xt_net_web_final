USE [test_shop]
GO
/****** Object:  Table [dbo].[BetTable]    Script Date: 09.03.2020 8:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BetTable](
	[id_bet] [int] IDENTITY(1,1) NOT NULL,
	[id_user] [int] NULL,
	[id_lot] [int] NULL,
	[bet_date] [date] NULL,
	[bet_price] [decimal](18, 0) NULL,
 CONSTRAINT [PK_bump] PRIMARY KEY CLUSTERED 
(
	[id_bet] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BetTable]  WITH CHECK ADD  CONSTRAINT [FK_bet_lots] FOREIGN KEY([id_lot])
REFERENCES [dbo].[LotTable] ([id_lot])
GO
ALTER TABLE [dbo].[BetTable] CHECK CONSTRAINT [FK_bet_lots]
GO
ALTER TABLE [dbo].[BetTable]  WITH CHECK ADD  CONSTRAINT [FK_bet_Users] FOREIGN KEY([id_user])
REFERENCES [dbo].[UserTable] ([id_user])
GO
ALTER TABLE [dbo].[BetTable] CHECK CONSTRAINT [FK_bet_Users]
GO
