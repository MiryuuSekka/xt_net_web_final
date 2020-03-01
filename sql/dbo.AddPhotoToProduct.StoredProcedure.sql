USE [test_shop]
GO
/****** Object:  StoredProcedure [dbo].[AddPhotoToProduct]    Script Date: 01.03.2020 19:07:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[AddPhotoToProduct]
    @id_photo int,
    @id_product int
AS
	INSERT INTO ProductPhoto(id_photo, id_product)
    values (@id_photo, @id_product)

	SELECT SCOPE_IDENTITY()
GO
