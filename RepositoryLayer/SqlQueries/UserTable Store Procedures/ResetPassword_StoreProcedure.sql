Create Procedure spResetPassword(          
    @EmailId varchar(30),
	@NewPassword varchar(30)
)
As 
Begin
   UPDATE UserTable set Password=@NewPassword where EmailId=@EmailId
End