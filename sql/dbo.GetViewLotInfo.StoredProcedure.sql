USE [test_shop]
GO
/****** Object:  StoredProcedure [dbo].[GetViewLotInfo]    Script Date: 09.03.2020 8:17:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetViewLotInfo]
	@id int
As
	Select LotTable.id_seller, LotTable.lot_price, LotTable.date_start, LotTable.date_end, 
	ProductTable.title_product, ProductTable.company, ProductTable.id_product, StatusTable.title_status
	from LotTable
	left join ProductTable on ProductTable.id_product = LotTable.id_product
	left join StatusTable on StatusTable.id_status = ProductTable.id_status
	where LotTable.id_lot = @id;
GO
