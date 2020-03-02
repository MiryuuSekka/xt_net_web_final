USE [test_shop]
GO
/****** Object:  StoredProcedure [dbo].[GetTagByLotId]    Script Date: 03.03.2020 2:45:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetTagByLotId]
	@id int
As
	Select TagTable.id_tag, TagTable.title_tag
	from TagTable
	join LotTags on LotTags.id_tag = TagTable.id_tag
	where LotTags.id_lot = @id;
GO
