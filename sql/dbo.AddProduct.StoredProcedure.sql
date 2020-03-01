USE [test_shop]
GO
/****** Object:  StoredProcedure [dbo].[AddProduct]    Script Date: 01.03.2020 19:07:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[AddProduct]
    @id_status int,
    @title varchar(50),
    @company varchar(50)
AS
	INSERT INTO ProductTable(id_status, title_product, company)
    values (@id_status, @title, @company)

	SELECT SCOPE_IDENTITY()
GO
