USE [test_shop]
GO
/****** Object:  StoredProcedure [dbo].[GetLotShortInfo]    Script Date: 01.03.2020 19:07:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetLotShortInfo]
    @id int
AS
	Select LotTable.id_lot, LotTable.date_start, LotTable.date_end, LotTable.lot_price, LotTable.id_seller, 
	PhotoTable.url, PhotoTable.comment
	from LotTable
	join ProductPhoto on LotTable.id_product = ProductPhoto.id_product
	join PhotoTable on PhotoTable.id_photo = ProductPhoto.id_photo
	where LotTable.id_lot = @id;
GO
