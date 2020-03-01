USE [test_shop]
GO
/****** Object:  StoredProcedure [dbo].[AddLot]    Script Date: 01.03.2020 19:07:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[AddLot]
    @id_Seller int,
    @id_Product int,
    @price decimal,
    @dateStart date,
    @dateEnd date
AS
	INSERT INTO LotTable(id_seller, id_product, lot_price, date_start, date_end)
    values (@id_Seller, @id_Product, @price, @dateStart, @dateEnd)

	SELECT SCOPE_IDENTITY()
GO
