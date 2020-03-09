USE [test_shop]
GO
/****** Object:  StoredProcedure [dbo].[EditProduct]    Script Date: 09.03.2020 8:17:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[EditProduct]
	@id int,
	@company varchar(50),
	@title varchar(50),
	@status int
As
	Update ProductTable
	Set ProductTable.company = @company, ProductTable.title_product = @title, ProductTable.id_status = @status
	where ProductTable.id_product = @id;
GO
