-----------Creating Address table--------------

CREATE TABLE ADDRESSTYPE
( 
	TypeId INT PRIMARY KEY IDENTITY NOT NULL, 
	Type VARCHAR(200)
)
INSERT INTO ADDRESSTYPE VALUES ('WORK'),('Home'),('Others');
SELECT * FROM ADDRESSTYPE

create table Addresses(
    AddressId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Address varchar(300) not null,
	City varchar(100),
	State varchar(100),
	TypeId int FOREIGN KEY (TypeId) REFERENCES AddressType(TypeId),
	Id bigint NOT NULL FOREIGN KEY (Id) REFERENCES BookStoreUser(Id),
)

select * from Addresses