USE [test_shop]
GO
/****** Object:  StoredProcedure [dbo].[GetUsers]    Script Date: 03.03.2020 2:45:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetUsers]
AS
	Select UserTable.id_user, UserTable.name, UserTable.password, RolesTable.title_role
	from UserTable
	join RolesTable on RolesTable.id_role = UserTable.id_role;
GO
