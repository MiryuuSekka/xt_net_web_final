USE [test_shop]
GO
/****** Object:  StoredProcedure [dbo].[GetLotShortInfo]    Script Date: 09.03.2020 8:17:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetLotShortInfo]
	@id int
As
	Select LotTable.id_lot, LotTable.date_start, LotTable.date_end, LotTable.lot_price, LotTable.id_seller,
	PhotoTable.url, PhotoTable.comment, LotTable.id_product 
	from LotTable
	join ProductPhoto on LotTable.id_product = ProductPhoto.id_product
	join PhotoTable on PhotoTable.id_photo = ProductPhoto.id_photo
	where LotTable.id_lot = @id;
GO
