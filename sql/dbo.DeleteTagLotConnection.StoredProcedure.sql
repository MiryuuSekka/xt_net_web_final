USE [test_shop]
GO
/****** Object:  StoredProcedure [dbo].[DeleteTagLotConnection]    Script Date: 09.03.2020 8:17:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DeleteTagLotConnection]
	@id_lot int,
	@id_tag int
As
	Delete from LotTags
	where LotTags.id_lot = @id_lot AND LotTags.id_tag = @id_tag;
GO
