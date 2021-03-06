USE [test_shop]
GO
/****** Object:  Table [dbo].[UserTable]    Script Date: 09.03.2020 8:17:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTable](
	[id_user] [int] IDENTITY(1,1) NOT NULL,
	[id_role] [int] NOT NULL,
	[name] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[id_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[UserTable]  WITH CHECK ADD  CONSTRAINT [FK_Users_roles] FOREIGN KEY([id_role])
REFERENCES [dbo].[RolesTable] ([id_role])
GO
ALTER TABLE [dbo].[UserTable] CHECK CONSTRAINT [FK_Users_roles]
GO
