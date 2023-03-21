------------Create feedback table---------------

create table FeedbackTable(
	FeedbackId int identity(1,1) not null primary key,
	Id bigint not null foreign key (Id) References BookStoreUser(Id),
	Book_Id bigint not null foreign key (Book_Id) References BookTable(Book_Id),
	Comment varchar(500),
	Ratings varchar(300)
)

select * from FeedbackTable;
