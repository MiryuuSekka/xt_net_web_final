USE [test_shop]
GO
/****** Object:  StoredProcedure [dbo].[GetBetsAtLot]    Script Date: 03.03.2020 2:45:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetBetsAtLot]
	@id int
As
	Select BetTable.id_bet, BetTable.id_user, BetTable.bet_price, BetTable.bet_date
	from BetTable
	where BetTable.id_lot = @id;
GO
