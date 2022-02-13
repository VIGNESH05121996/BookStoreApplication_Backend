Create Procedure spGetAllOrders(  
	@UserId bigint  
)
As 
Begin
   select * from OrderTable where UserId=@UserId
End