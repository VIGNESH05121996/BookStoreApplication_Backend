Create Procedure spGetOrderWithBookId(  
    @BookId bigint,
	@UserId bigint  
)
As 
Begin
   select * from OrderTable where BookId=@BookId and UserId=@UserId
End