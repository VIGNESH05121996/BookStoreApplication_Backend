Create Procedure spDeleteWishListWithWishListtId(  
    @WishListId bigint,
	@UserId bigint  
)
As 
Begin
   Delete from WishListTable where WishListId=@WishListId  and UserId=@UserId
End