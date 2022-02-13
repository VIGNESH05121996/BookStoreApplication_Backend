Create Procedure spDeleteBookWithBookId(  
    @BookId bigint,
	@UserId bigint  
)
As 
Begin
   Delete from BookTable where  BookId=@BookId and UserId=@UserId
End