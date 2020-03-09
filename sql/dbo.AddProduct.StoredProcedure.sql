USE [test_shop]
GO
/****** Object:  StoredProcedure [dbo].[AddProduct]    Script Date: 09.03.2020 8:17:35 ******/
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
