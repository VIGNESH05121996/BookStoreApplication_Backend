Create Procedure spAddCart(
	@BookId bigint,
	@Quantity bigint,
	@UserId bigint 
)
As 
Begin
   Insert into CartTable (BookId,Quantity,UserId) Values (@BookId,@Quantity,@UserId)
End