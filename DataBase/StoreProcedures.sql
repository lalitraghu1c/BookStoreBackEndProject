---------------Store Procedure for User Registration-----------------

Create Procedure SPBookStoreUser (
	@Full_Name varchar(50), 
	@Email_Id varchar(50), 
	@Password varchar(50),
	@Mobile_Number varchar(50)
)
as
Begin
	Insert into BookStoreUser (Full_Name,Email_Id,Password, Mobile_Number)         
    Values (@Full_Name,@Email_Id,@Password, @Mobile_Number) 
End

Exec SPBookStoreUser @Full_Name='Lalit Raghuwanshi',@Email_Id='lalitraghu@gmail.com',@Password='lalit123@',@Mobile_Number='8358814392'
Exec SPBookStoreUser @Full_Name='Aditya Raghuwanshi',@Email_Id='adityaraghu@gmail.com',@Password='aditya123@',@Mobile_Number='9039204506'

---------------Store Procedure for User Login-----------------

Create Procedure SPUserLogin(
	@Email_Id varchar(50),
	@Password varchar(100)
)
as
Begin 
Select * From BookStoreUser where Email_Id=@Email_Id and Password=@Password
END

---------------Store Procedure for Forgot Password-----------------

Create Procedure SPUserForgotPassword(
	@Email_Id varchar(50)
)
as
Begin 
Select * From BookStoreUser where Email_Id=@Email_Id
END

---------------Store Procedure for Reset Password-----------------

Create Procedure SPUserResetPassword(
	@Email_Id varchar(50),
	@Password varchar(200)
)
as
Begin 
Select * From BookStoreUser where Email_Id=@Email_Id
END