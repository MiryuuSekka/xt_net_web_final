USE [test_shop]
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 09.03.2020 8:17:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[AddUser]
    @id_role int,
    @name varchar(50),
    @pass varchar(50)
AS
	INSERT INTO UserTable(id_role, name, password)
    values (@id_role, @name, @pass)

	SELECT SCOPE_IDENTITY()
GO
