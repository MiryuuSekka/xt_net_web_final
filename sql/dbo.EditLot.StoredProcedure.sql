USE [test_shop]
GO
/****** Object:  StoredProcedure [dbo].[EditLot]    Script Date: 09.03.2020 8:17:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[EditLot]
	@id int,
	@price decimal(18, 0),
	@start date,
	@end date
As
	Update LotTable
	Set LotTable.date_start = @start, LotTable.date_end = @end, LotTable.lot_price = @price
	where LotTable.id_lot = @id;
GO
