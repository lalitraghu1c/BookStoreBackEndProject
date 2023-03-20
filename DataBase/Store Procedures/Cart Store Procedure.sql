USE [BookStore]
GO
/****** Object:  StoredProcedure [dbo].[Sp_AddtoCart]    Script Date: 20-03-2023 10:10:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[Sp_AddtoCart]
( 
  @Book_Quantity bigint,
  @Id bigint,
  @Book_Id bigint
)
as
INSERT into CartTable(Book_Quantity,Id,Book_Id) VALUES ( @Book_Quantity,@Id, @Book_Id);

----------Store Procedure for Delete Cart-----------

CREATE PROCEDURE Sp_DeleteCart
@CartId bigint
as
	DELETE from CartTable where CartId = @CartId;
go

----------Store Procedure for Update Cart-----------

CREATE PROCEDURE Sp_UpdateCart
(
	@CartId bigint,
	@Book_Quantity bigint 
)
as
UPDATE CartTable set Book_Quantity=@Book_Quantity where CartId=@CartId;
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