Create Procedure spGetBookWithBookId(  
    @BookId bigint,
	@UserId bigint  
)
As 
Begin
   select * from BookTable where BookId=@BookId and UserId=@UserId
End