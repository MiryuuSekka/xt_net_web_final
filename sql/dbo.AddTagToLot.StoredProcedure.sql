USE [test_shop]
GO
/****** Object:  StoredProcedure [dbo].[AddTagToLot]    Script Date: 09.03.2020 8:17:35 ******/
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
