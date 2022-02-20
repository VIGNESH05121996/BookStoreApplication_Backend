Create Procedure spGetAddressWithTypeId(  
    @TypeId bigint,
	@UserId bigint  
)
As 
Begin
   Select * from AddressTable where TypeId=@TypeId and UserId=@UserId
End