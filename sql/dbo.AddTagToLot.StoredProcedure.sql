USE [test_shop]
GO
/****** Object:  StoredProcedure [dbo].[AddTagToLot]    Script Date: 01.03.2020 19:07:07 ******/
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
