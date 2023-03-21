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

-----------Creating Address table--------------


create table Addresses(
    AddressId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Address varchar(300) not null,
	City varchar(100),
	State varchar(100),
	TypeId int FOREIGN KEY (TypeId) REFERENCES AddressType(TypeId),
	Id bigint NOT NULL FOREIGN KEY (Id) REFERENCES BookStoreUser(Id),
)

select * from Addresses

-----------Creating Order table--------------


create table OrderTable(
	OrdersId int identity(1,1) not null primary key,
	Id bigint FOREIGN KEY (Id) REFERENCES BookStoreUser(Id),
	Book_Id bigint FOREIGN KEY (Book_Id) REFERENCES BookStoreDetail(Book_Id),
	AddressId int FOREIGN KEY (AddressId) REFERENCES Addresses(AddressId),
	TotalPrice int,
	BookQuantity int,
	OrderDate Date
)

select * from OrderTable

