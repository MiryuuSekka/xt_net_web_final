USE [test_shop]
GO
/****** Object:  StoredProcedure [dbo].[AddTag]    Script Date: 03.03.2020 2:45:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[AddTag]
    @title varchar(50)
AS
	INSERT INTO TagTable(title_tag)
    values (@title)

	SELECT SCOPE_IDENTITY()
GO
