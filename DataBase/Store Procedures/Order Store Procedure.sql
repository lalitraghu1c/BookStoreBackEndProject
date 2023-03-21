---------------Store procedure for Add order------------------


CREATE OR ALTER PROCEDURE SP_AddOrder
	@Id bigint,
	@AddressId int,
	@Book_Id bigint ,
	@TotalQuantity int
AS
	Declare @TotPrice int
BEGIN
Select @TotPrice=DiscountPrice from BookTable where Book_Id = @Book_Id;
	IF (EXISTS(SELECT * FROM BookTable WHERE Book_Id = @Book_Id))
	begin
		IF (EXISTS(SELECT * FROM BookStoreUser WHERE Id = @Id))
		Begin
		Begin try
			Begin transaction			
				INSERT INTO OrderTable(Id,AddressId,Book_Id,Totalprice,TotalQuantity,OrderDate)
				VALUES (@Id,@AddressId,@Book_Id,@TotPrice*@TotalQuantity,@TotalQuantity,GETDATE())
				Update BookTable set BookCount=BookCount-@TotalQuantity
				Delete from CartTable where Book_Id = @Book_Id and Id = @Id
				select * from OrderTable
			commit Transaction
		End try
		Begin catch
			Rollback transaction
		End catch
		end
		Else
		begin
			Select 1
		end
	end 
	Else
	begin
			Select 2
	end	
END

EXEC SP_AddOrder 1,1,3,10

--------------Store Procedure for Get all Order----------
CREATE PROCEDURE SP_GetOrder

AS
BEGIN
SELECT * FROM OrderTable 
END

------------------Store procedure for Cancel Orders----------------------

CREATE or ALTER PROCEDURE SPCancelOrder
		@OrdersId INT
AS
	BEGIN
	DECLARE @OrderQuantity INT = (SELECT TotalQuantity FROM OrderTable WHERE OrdersId = @OrdersId)
	DECLARE @Book_Id INT = (SELECT Book_Id FROM OrderTable WHERE OrdersId = @OrdersId)
		BEGIN
			UPDATE CartTable
			SET BookCount = BookCount + @OrderQuantity
			WHERE Book_Id = @Book_Id
		END
		BEGIN
			DELETE FROM OrderTable
			WHERE OrdersId = @OrdersId
		END
	END
