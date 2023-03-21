-----------Creating Order table--------------


create table OrderTable(
	OrdersId int identity(1,1) not null primary key,
	Id bigint FOREIGN KEY (Id) REFERENCES BookStoreUser(Id),
	Book_Id bigint FOREIGN KEY (Book_Id) REFERENCES BookTable(Book_Id),
	AddressId int FOREIGN KEY (AddressId) REFERENCES Addresses(AddressId),
	TotalPrice int,
	TotalQuantity int,
	OrderDate Date
)
select * from OrderTable
drop table OrderTable
