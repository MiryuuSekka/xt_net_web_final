USE [test_shop]
GO
/****** Object:  StoredProcedure [dbo].[GetLotsId]    Script Date: 03.03.2020 2:45:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetLotsId]
AS
	Select LotTable.id_lot from LotTable;
GO
