Create Procedure spAddCart(
	@BookId bigint,
	@UserId bigint 
)
As 
Begin
   Insert into CartTable (BookId,UserId) Values (@BookId,@UserId)
End