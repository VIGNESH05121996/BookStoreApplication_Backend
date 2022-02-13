Create Procedure spGetAddressWithAddressId(  
    @AddressId bigint,
	@UserId bigint  
)
As 
Begin
   Select * from AddressTable where AddressId=@AddressId and UserId=@UserId
End