Create Procedure spAddUser(
    @FullName varchar(50),          
    @EmailId varchar(30), 
	@Password varchar(30),   
    @MobileNumber varchar(20) 
)
As 
Begin
   Insert into UserTable (FullName,EmailId,Password,MobileNumber)
   Values (@FullName,@EmailId,@Password,@MobileNumber)
End