USE [test_shop]
GO
/****** Object:  StoredProcedure [dbo].[GetTags]    Script Date: 09.03.2020 8:17:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetTags]
As
	Select TagTable.id_tag, TagTable.title_tag
	from TagTable
GO
