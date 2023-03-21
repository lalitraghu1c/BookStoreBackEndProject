-------------Database Created-------------

Create Database BookStore

---------Creating Table for User----------

Create Table BookStoreUser(
	Id bigint Identity (1,1) PRIMARY KEY,
	Full_Name varchar (50) NOT NULL,
	Email_Id varchar (50) NOT NULL,
	Password varchar (50) NOT NULL,
	Mobile_Number varchar (50) NOT NULL
)

Select * from BookStoreUser

--------Creating Tabel for Book----------

Create Table BookStoreDetail(
	Book_Id bigint Identity (1,1) PRIMARY KEY,
	Book_Name varchar (100),
	Book_Image varchar (300),
	Author_Name varchar (100),
	Original_Price bigint,
	Discount_Price bigint,
	Detail varchar (300),
	Rating bigint,
	Rating_Count bigint, 
	Book_Quantity bigint NOT NULL
)

Select * from BookStoreDetail
Drop Table BookStoreDetail
