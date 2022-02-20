Create Procedure spUpdateAddress(  
    @AddressId bigint,
	@FullName varchar(150),
	@FullAddress varchar(max),
	@City varchar(225),
	@State varchar(255),
    @UserId bigint
)
As 
Begin
   UPDATE AddressTable set FullName=@FullName,FullAddress=@FullAddress,
   City=@City,State=@State where AddressId=@AddressId and UserId=@UserId
End