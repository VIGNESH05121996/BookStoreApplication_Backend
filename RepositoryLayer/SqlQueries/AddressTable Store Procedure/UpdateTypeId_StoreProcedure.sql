Create Procedure spUpdateTypeId(  
    @AddressId bigint,
	@TypeId bigint,
    @UserId bigint
)
As 
Begin
   UPDATE AddressTable set TypeId=@TypeId where AddressId=@AddressId and UserId=@UserId
End