USE [test_shop]
GO
/****** Object:  StoredProcedure [dbo].[GetLotShortInfo]    Script Date: 03.03.2020 2:45:47 ******/
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
