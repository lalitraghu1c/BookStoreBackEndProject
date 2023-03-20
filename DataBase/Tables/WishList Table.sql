CREATE TABLE WishListTable
(
	WishListId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Id bigint FOREIGN KEY references BookStoreUser(Id),
	Book_Id bigint FOREIGN KEY references BookTable(Book_Id)
)

SELECT * FROM BookStoreUser
SELECT * FROM BookTable