USE [test_shop]
GO
/****** Object:  StoredProcedure [dbo].[GetLotsId]    Script Date: 05.03.2020 2:53:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetLotsId]
AS
	Select LotTable.id_lot from LotTable;
GO
