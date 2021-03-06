USE [test_shop]
GO
/****** Object:  Table [dbo].[ProductTable]    Script Date: 09.03.2020 8:17:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductTable](
	[id_product] [int] IDENTITY(1,1) NOT NULL,
	[company] [varchar](50) NULL,
	[title_product] [varchar](50) NULL,
	[id_status] [int] NULL,
 CONSTRAINT [PK_description] PRIMARY KEY CLUSTERED 
(
	[id_product] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ProductTable]  WITH CHECK ADD  CONSTRAINT [FK_product_statuses] FOREIGN KEY([id_status])
REFERENCES [dbo].[StatusTable] ([id_status])
GO
ALTER TABLE [dbo].[ProductTable] CHECK CONSTRAINT [FK_product_statuses]
GO
