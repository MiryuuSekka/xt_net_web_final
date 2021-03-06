USE [test_shop]
GO
/****** Object:  Table [dbo].[LotTags]    Script Date: 09.03.2020 8:17:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LotTags](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_lot] [int] NOT NULL,
	[id_tag] [int] NOT NULL,
 CONSTRAINT [PK_LotTags] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[LotTags]  WITH CHECK ADD  CONSTRAINT [FK_LotTags_lots] FOREIGN KEY([id_lot])
REFERENCES [dbo].[LotTable] ([id_lot])
GO
ALTER TABLE [dbo].[LotTags] CHECK CONSTRAINT [FK_LotTags_lots]
GO
ALTER TABLE [dbo].[LotTags]  WITH CHECK ADD  CONSTRAINT [FK_LotTags_tags] FOREIGN KEY([id_tag])
REFERENCES [dbo].[TagTable] ([id_tag])
GO
ALTER TABLE [dbo].[LotTags] CHECK CONSTRAINT [FK_LotTags_tags]
GO
