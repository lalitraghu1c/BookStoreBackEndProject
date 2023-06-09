USE [BookStore]
GO
/****** Object:  StoredProcedure [dbo].[Sp_AddtoCart]    Script Date: 20-03-2023 10:10:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[Sp_AddtoCart]
( 
  @BookCount bigint,
  @Id bigint,
  @Book_Id bigint
)
as
INSERT into CartTable(BookCount,Id,Book_Id) VALUES ( @BookCount,@Id, @Book_Id);

----------Store Procedure for Delete Cart-----------

CREATE PROCEDURE Sp_DeleteCart
@CartId bigint
as
	DELETE from CartTable where CartId = @CartId;
go

----------Store Procedure for Update Cart-----------

CREATE or alter PROCEDURE Sp_UpdateCart
(
	@CartId bigint,
	@BookCount bigint 
)
as
UPDATE CartTable set BookCount=@BookCount where CartId=@CartId;
go


-----------Store Procedure for Get all cart by User Id-----------

CREATE PROCEDURE spGetCartByUserId(	
		@Id bigint
)
AS 
BEGIN
BEGIN TRY
		IF EXISTS(SELECT * FROM dbo.CartTable WHERE Id = @Id )
		BEGIN
			SELECT * FROM CartTable WHERE (Id = @Id) 
		END
		ELSE
			THROW 51002, 'Not a Valid User Id', 1
	END TRY
	BEGIN CATCH
		SELECT ERROR_MESSAGE() AS ERROR
	END CATCH
END



EXEC spGetCartByUserId 2


-----------Store Procedure for Get all cart by Cart Id-----------

CREATE PROCEDURE SP_GetCartByCartId(	
		@Id bigint,
		@CartId bigint
)
AS 
BEGIN
BEGIN TRY
		IF EXISTS(SELECT * FROM CartTable WHERE Id = @Id )
		BEGIN
			SELECT * FROM CartTable WHERE (CartId = @CartId) 
		END
		ELSE
			THROW 51002, 'Not a Valid User Id', 1
	END TRY
	BEGIN CATCH
		SELECT ERROR_MESSAGE() AS ERROR
	END CATCH
END