-------Store Procedure for Add New Book-------

Create PROCEDURE SPAddNewBook(
 @BookName VARCHAR (500),
 @AuthorName VARCHAR(20),
 @Rating VARCHAR(300),
 @TotalCountRating INT,
 @DiscountPrice INT,
 @OriginalPrice INT,
 @Detail VARCHAR (500),
 @BookImage VARCHAR (max),
 @BookCount INT
)
as Begin
Insert into BookTable values (@BookName,@AuthorName,@Rating,@TotalCountRating,@DiscountPrice,@OriginalPrice,@Detail,@BookImage,@Bookcount)
End

EXEC SPAddNewBook "Book","LALIT","4.1",20,150,200,"NOTING","ABCD",200

SELECT * FROM BookTable

	-------Store Procedure for Delete Book-------

	CREATE PROCEDURE SPDeleteBook(
		@Book_Id BIGINT
	)
	as
	Delete from BookTable Where Book_Id=@Book_Id
	go

	-------Store Procedure for Update Book-------

	CREATE PROCEDURE SPUpdateBook(
		@Book_Id BIGINT,
		@BookName VARCHAR (500),
		@AuthorName VARCHAR(20),
		@Rating VARCHAR(300),
		@TotalCountRating INT,
		@DiscountPrice INT,
		@OriginalPrice INT,
		@Detail VARCHAR (500),
		@BookImage VARCHAR (max),
		@BookCount INT)
	as
	Update BookTable set
		BookName=@BookName,
		AuthorName=@AuthorName,
		Rating=@Rating,
		@TotalCountRating=@TotalCountRating,
		DiscountPrice=@DiscountPrice,
		OriginalPrice=@OriginalPrice,
		@Detail=@Detail,
		BookImage=@BookImage,
		BookCount=@Bookcount
	Where Book_Id=@Book_Id
	go

	-------Store Procedure for Get all Books-------

	CREATE PROCEDURE SPGetAllBooks
	as
	SELECT *FROM BookTable
	go

	-------Store Procedure for Get Book by Book_Id-------

	CREATE Procedure SPGetBookByBook_Id
		@Book_Id BIGINT
	as
	SELECT * FROM BookTable where Book_Id=@Book_Id
	go

	-------Store Procedure for Uploading Image-------

	CREATE Procedure SPBookImageUpload
		@Book_Id BIGINT,
		@BookImage VARCHAR (max)
	as
	SELECT * FROM BookTable where Book_Id=@Book_Id
	go