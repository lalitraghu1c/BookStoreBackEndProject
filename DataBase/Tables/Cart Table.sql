Create Table CartTable
(
CartId bigint identity(1,1) primary key,
Book_Quantity bigint default 1,
Id bigint foreign key (Id) references BookStoreUser(Id),
Book_Id bigint Foreign key (Book_Id) references BookTable(Book_Id)
);

Select * from CartTable