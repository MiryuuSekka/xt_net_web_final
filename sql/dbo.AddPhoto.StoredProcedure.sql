USE [test_shop]
GO
/****** Object:  StoredProcedure [dbo].[AddPhoto]    Script Date: 01.03.2020 19:07:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[AddPhoto]
    @url varchar(max),
    @comment varchar(50)
AS
	INSERT INTO PhotoTable(url, comment)
    values (@url, @comment)

	SELECT SCOPE_IDENTITY()
GO
