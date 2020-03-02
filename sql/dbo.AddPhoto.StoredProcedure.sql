USE [test_shop]
GO
/****** Object:  StoredProcedure [dbo].[AddPhoto]    Script Date: 03.03.2020 2:45:47 ******/
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
