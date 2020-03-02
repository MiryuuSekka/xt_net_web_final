USE [test_shop]
GO
/****** Object:  StoredProcedure [dbo].[GetProductPhotos]    Script Date: 03.03.2020 2:45:47 ******/
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
