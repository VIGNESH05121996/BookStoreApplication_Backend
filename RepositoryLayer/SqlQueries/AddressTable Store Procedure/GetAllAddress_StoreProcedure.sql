Create Procedure spGetAllAddress(  
	@UserId bigint  
)
As 
Begin
   select * from AddressTable where UserId=@UserId
End