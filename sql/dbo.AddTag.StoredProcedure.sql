USE [test_shop]
GO
/****** Object:  StoredProcedure [dbo].[AddTag]    Script Date: 01.03.2020 19:07:07 ******/
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
