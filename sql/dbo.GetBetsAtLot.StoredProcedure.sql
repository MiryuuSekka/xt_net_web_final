USE [test_shop]
GO
/****** Object:  StoredProcedure [dbo].[GetBetsAtLot]    Script Date: 09.03.2020 8:17:35 ******/
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
