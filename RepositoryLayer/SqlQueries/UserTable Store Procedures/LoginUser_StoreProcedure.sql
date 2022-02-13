Create Procedure spLoginUser(          
    @EmailId varchar(30), 
	@Password varchar(30)
)
As 
Begin
   select UserId,EmailId,Password from UserTable where EmailId=@EmailId and Password=@Password
End