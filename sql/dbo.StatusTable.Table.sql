USE [test_shop]
GO
/****** Object:  Table [dbo].[StatusTable]    Script Date: 01.03.2020 19:07:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusTable](
	[id_status] [int] IDENTITY(1,1) NOT NULL,
	[title_status] [varchar](50) NOT NULL,
 CONSTRAINT [PK_statuses] PRIMARY KEY CLUSTERED 
(
	[id_status] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
