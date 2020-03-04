USE [test_shop]
GO
/****** Object:  StoredProcedure [dbo].[GetProductPhotos]    Script Date: 05.03.2020 2:53:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetProductPhotos]
	@id int
As
	Select PhotoTable.id_photo, PhotoTable.comment, PhotoTable.url
	from PhotoTable
	left join ProductPhoto on ProductPhoto.id_photo = PhotoTable.id_photo
	where ProductPhoto.id_product = @id;
GO
