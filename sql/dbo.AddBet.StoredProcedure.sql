USE [test_shop]
GO
/****** Object:  StoredProcedure [dbo].[AddBet]    Script Date: 03.03.2020 2:45:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[AddBet]
    @id_User int,
    @id_Lot int,
    @price decimal,
    @date date
AS
	INSERT INTO BetTable(id_user, id_lot, bet_price, bet_date)
    values (@id_User, @id_Lot, @price, @date)

	SELECT SCOPE_IDENTITY()
GO
