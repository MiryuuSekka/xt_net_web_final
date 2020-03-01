USE [test_shop]
GO
/****** Object:  StoredProcedure [dbo].[GetUserById]    Script Date: 01.03.2020 19:07:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetUserById]
    @id int
AS
	Select UserTable.name, UserTable.password, RolesTable.title_role
	from UserTable
	join RolesTable on RolesTable.id_role = UserTable.id_role
	where UserTable.id_user = @id;
GO
