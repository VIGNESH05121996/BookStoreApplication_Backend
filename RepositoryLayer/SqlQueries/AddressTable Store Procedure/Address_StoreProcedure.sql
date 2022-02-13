Create Procedure spAddAddress(
    @TypeId bigint,
	@FullName varchar(150),
	@FullAddress varchar(max),
	@City varchar(225),
	@State varchar(255),
	@UserId bigint
)
As 
Begin
   Insert into AddressTable (TypeId,FullName,FullAddress,City,State,UserId)
   Values (@TypeId,@FullName,@FullAddress,@City,@State,@UserId)
End