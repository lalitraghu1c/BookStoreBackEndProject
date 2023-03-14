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
	Book_Name varchar (50) NOT NULL,
	Book_Image varchar (max) NOT NULL,
	Author_Name varchar (50) NOT NULL,
	Price bigint NOT NULL,
	Discount_Price bigint,
	Detail varchar (150) NOT NULL,
	Rating varchar (50) NOT NULL,
	Rating_Count bigint, 
	Book_Quantity bigint
)

Select * from BookStoreDetail