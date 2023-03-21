--------Add to wishlist----------

CREATE or ALTER PROCEDURE spAddToWishList
(
	@Id bigint,
	@Book_Id bigint)
As
BEGIN TRY
 INSERT INTO WishListTable (Id, Book_Id)VALUES (@Id,@Book_Id);
 END TRY 
 BEGIN CATCH
 SELECT ERROR_MESSAGE() AS ERROR
 END CATCH

 ----------Delete Wishlist------------

CREATE PROCEDURE spDeleteWishList
(
	@WishListId INT, 
	@Id bigint
)
AS
BEGIN TRY
DELETE FROM WishListTable WHERE WishListId = @WishListId and Id=@Id;
END TRY
BEGIN CATCH
SELECT ERROR_MESSAGE() AS ERROR
END CATCH


--------Get wishlist----------

CREATE PROCEDURE spGetWishList
	@Id INT
AS
BEGIN TRY
SELECT WishListId,Id,b.Book_Id,b.BookName,b.AuthorName,b.OriginalPrice, b.DiscountPrice, b.BookImage from WishListTable 
c join BookTable b on c.Book_Id=b.Book_Id 
WHERE Id=@Id;
END TRY
BEGIN CATCH
SELECT ERROR_MESSAGE() AS ERROR
END CATCH