CREATE PROCEDURE SPAdminLogin(
@Email VARCHAR(50),
@Password VARCHAR(50)
)
as
Begin
	SELECT * FROM ADMINTABLE WHERE Email_Id=@Email  and Password=@Password
End