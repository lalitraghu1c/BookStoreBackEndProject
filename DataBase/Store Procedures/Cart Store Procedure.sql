USE [BookStore]
GO
/****** Object:  StoredProcedure [dbo].[Sp_AddtoCart]    Script Date: 20-03-2023 10:10:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[Sp_AddtoCart]
( 
  @Book_Quantity bigint,
  @Id bigint,
  @Book_Id bigint
)
as
INSERT into CartTable(Book_Quantity,Id,Book_Id) VALUES ( @Book_Quantity,@Id, @Book_Id);

----------Store Procedure for Delete Cart-----------

CREATE PROCEDURE Sp_DeleteCart
@CartId bigint
as
	DELETE from CartTable where CartId = @CartId;
go

----------Store Procedure for Update Cart-----------

CREATE PROCEDURE Sp_UpdateCart
(
	@CartId bigint,
	@Book_Quantity bigint 
)
as
UPDATE CartTable set Book_Quantity=@Book_Quantity where CartId=@CartId;
go