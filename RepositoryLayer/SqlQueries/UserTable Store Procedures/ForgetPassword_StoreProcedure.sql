Create Procedure spForgetPassword(          
    @EmailId varchar(30)
)
As 
Begin
   select UserId,EmailId from UserTable where EmailId=@EmailId
End