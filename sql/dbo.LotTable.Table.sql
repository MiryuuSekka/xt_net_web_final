USE [test_shop]
GO
/****** Object:  Table [dbo].[LotTable]    Script Date: 09.03.2020 8:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LotTable](
	[id_lot] [int] IDENTITY(1,1) NOT NULL,
	[id_seller] [int] NOT NULL,
	[id_product] [int] NOT NULL,
	[lot_price] [decimal](18, 0) NOT NULL,
	[date_start] [date] NOT NULL,
	[date_end] [date] NOT NULL,
 CONSTRAINT [PK_lots] PRIMARY KEY CLUSTERED 
(
	[id_lot] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[LotTable]  WITH CHECK ADD  CONSTRAINT [FK_lots_product] FOREIGN KEY([id_product])
REFERENCES [dbo].[ProductTable] ([id_product])
GO
ALTER TABLE [dbo].[LotTable] CHECK CONSTRAINT [FK_lots_product]
GO
ALTER TABLE [dbo].[LotTable]  WITH CHECK ADD  CONSTRAINT [FK_lots_Users] FOREIGN KEY([id_seller])
REFERENCES [dbo].[UserTable] ([id_user])
GO
ALTER TABLE [dbo].[LotTable] CHECK CONSTRAINT [FK_lots_Users]
GO
