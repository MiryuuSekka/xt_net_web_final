USE [test_shop]
GO
/****** Object:  StoredProcedure [dbo].[GetUserBets]    Script Date: 09.03.2020 8:17:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetUserBets]
	@id int
As
	Select BetTable.id_bet, BetTable.id_lot, BetTable.bet_price, BetTable.bet_date
	from BetTable
	where BetTable.id_user = @id;
GO
