USE [test_shop]
GO
/****** Object:  StoredProcedure [dbo].[AddTagToLot]    Script Date: 03.03.2020 2:45:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[AddTagToLot]
    @id_lot int,
    @id_tag int
AS
	INSERT INTO LotTags(id_lot, id_tag)
    values (@id_lot, @id_tag)

	SELECT SCOPE_IDENTITY()
GO
