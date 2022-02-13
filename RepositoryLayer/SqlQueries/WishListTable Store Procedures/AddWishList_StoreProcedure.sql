Create Procedure spAddWishList(
	@BookId bigint,
	@UserId bigint 
)
As 
Begin
   Insert into WishListTable Values (@BookId,@UserId)
End