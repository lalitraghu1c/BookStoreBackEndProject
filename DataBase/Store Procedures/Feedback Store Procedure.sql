---------Store Procedure for Add Feedback-----------

USE [BookStore]
GO
/****** Object:  StoredProcedure [dbo].[spAddFeedback]    Script Date: 20-Mar-23 4:18:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[SPAddFeedback]
( 
  @Ratings VARCHAR (300), @Comment VARCHAR(500), @Id INT, @Book_Id INT
)
AS
BEGIN TRY
	INSERT INTO FeedbackTable(Ratings, Comment, Id, Book_Id) VALUES ( @Ratings,@Comment, @Id, @Book_Id);
	END TRY
	BEGIN CATCH
	SELECT ERROR_MESSAGE() AS ERROR
END CATCH


-------------Get all Feedbacks-------------

Create PROCEDURE SPGetFeedback
	@Book_Id INT
AS
BEGIN
	SELECT 
		FeedbackTable.FeedbackId,FeedbackTable.Id,FeedbackTable.Book_Id,FeedbackTable.Comment,FeedbackTable.Ratings,
		BookStoreUser.Full_Name FROM BookStoreUser
		INNER JOIN FeedbackTable
		ON FeedbackTable.Id=BookStoreUser.Id
		WHERE Book_Id=@Book_Id
END
