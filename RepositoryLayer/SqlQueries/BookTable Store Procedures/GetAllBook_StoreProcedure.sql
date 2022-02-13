Create Procedure spGetAllBooks(  
	@UserId bigint  
)
As 
Begin
   select * from BookTable where UserId=@UserId
End