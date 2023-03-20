Create Table BookTable(
	Book_Id BIGINT IDENTITY(1,1) PRIMARY KEY,
	BookName VARCHAR (500),
	AuthorName VARCHAR(20),
	Rating VARCHAR(300),
	TotalCountRating INT,
	DiscountPrice INT,
	OriginalPrice INT,
	Deetail VARCHAR (500),
	BookImage VARCHAR (max),
	BookCount INT NOT NULL
)

Select * from BookTable
Drop table BookTable
