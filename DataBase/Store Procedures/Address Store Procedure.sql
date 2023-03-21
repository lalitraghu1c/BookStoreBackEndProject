-----------Store procedure for Add Address-------------

CREATE PROCEDURE SPAddAddress
(
	@Address VARCHAR(300),
	@City VARCHAR(100),
	@State VARCHAR(100),
	@TypeId INT,
	@Id INT
)
AS 
BEGIN TRY

INSERT INTO Addresses(Address,City,State,TypeId,Id) values(@Address,@City,@State,@TypeId,@Id)

END TRY

BEGIN CATCH 
SELECT ERROR_MESSAGE() AS ERROR
END CATCH


----------Store procedure for Delete Address------------

CREATE PROCEDURE SPDeleteAddress
(
	@AddressId INT
)
AS BEGIN
	BEGIN TRY
		IF EXISTS(SELECT * FROM Addresses WHERE(AddressId= @AddressId))
		BEGIN
			DELETE Addresses WHERE(AddressId= @AddressId)
		END
	END TRY
	BEGIN CATCH
		SELECT ERROR_MESSAGE() AS ERROR
	END CATCH
END

----------Store procedure for Retrieving all Address------------

CREATE PROCEDURE SPGetAllAddress

AS
BEGIN
SELECT * FROM Addresses 
END

----------Store procedure for Retrieving all Address------------

Create or Alter PROCEDURE SPUpdateAddress
(
	@Id INT,
	@AddressId INT,
	@Address VARCHAR(300),
	@City VARCHAR(100),
	@State VARCHAR(100),
	@TypeId INT
)
AS 
BEGIN TRY

UPDATE Addresses SET Address = @Address, City=@City, State=@State, TypeId=@TypeId WHERE
(Id = @Id AND AddressId = @AddressId)

END TRY

BEGIN CATCH 
SELECT ERROR_MESSAGE() AS ERROR
END CATCH

