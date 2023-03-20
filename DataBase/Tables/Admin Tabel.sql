CREATE TABLE ADMINTABLE(
	Admin_Id INT IDENTITY (1,1) PRIMARY KEY,
	Admin_Name VARCHAR(50),
	Email_Id VARCHAR(50),
	Password VARCHAR(50),
	Mobile_Number BIGINT
)

Insert into ADMINTABLE (Admin_Name,Email_Id,Password,Mobile_Number) values 
('Lalit', 'lalitraghu@gmail.com', 'lalit123@', 8358814392)

Insert into ADMINTABLE (Admin_Name,Email_Id,Password,Mobile_Number) values 
('Dahrmesh Raghuwanshi', 'dharmeshraghu@gmail.com', 'dharmesh123@', 7974166398)

SELECT * FROM ADMINTABLE