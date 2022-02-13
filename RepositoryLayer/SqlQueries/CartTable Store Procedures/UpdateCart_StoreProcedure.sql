Create Procedure spUpdateCart(  
    @CartId bigint,
    @UserId bigint,
	@Quantity bigint
)
As 
Begin
   UPDATE CartTable set Quantity=@Quantity where CartId=@CartId and UserId=@UserId
End