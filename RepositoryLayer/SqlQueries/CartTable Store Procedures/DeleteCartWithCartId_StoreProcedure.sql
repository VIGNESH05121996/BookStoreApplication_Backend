Create Procedure spDeleteCartWithCartId(  
    @CartId bigint,
	@UserId bigint  
)
As 
Begin
   Delete from CartTable where  CartId=@CartId and UserId=@UserId
End