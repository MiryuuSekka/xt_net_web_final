USE [test_shop]
GO
/****** Object:  Table [dbo].[ProductPhoto]    Script Date: 09.03.2020 8:17:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductPhoto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_photo] [int] NOT NULL,
	[id_product] [int] NOT NULL,
 CONSTRAINT [PK_LotPhoto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ProductPhoto]  WITH CHECK ADD  CONSTRAINT [FK_LotPhoto_Photo] FOREIGN KEY([id_photo])
REFERENCES [dbo].[PhotoTable] ([id_photo])
GO
ALTER TABLE [dbo].[ProductPhoto] CHECK CONSTRAINT [FK_LotPhoto_Photo]
GO
ALTER TABLE [dbo].[ProductPhoto]  WITH CHECK ADD  CONSTRAINT [FK_ProductPhoto_product] FOREIGN KEY([id_product])
REFERENCES [dbo].[ProductTable] ([id_product])
GO
ALTER TABLE [dbo].[ProductPhoto] CHECK CONSTRAINT [FK_ProductPhoto_product]
GO
