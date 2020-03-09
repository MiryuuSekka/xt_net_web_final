USE [test_shop]
GO
/****** Object:  StoredProcedure [dbo].[EditUser]    Script Date: 09.03.2020 8:17:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[EditUser]
	@id int,
	@role int,
	@pass nvarchar(50),
	@name nvarchar(50)
As
	UPDATE UserTable
	SET UserTable.id_role = @role, UserTable.name = @name, UserTable.password = @pass
	WHERE UserTable.id_user = @id;
GO
