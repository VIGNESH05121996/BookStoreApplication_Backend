Create Procedure spGetAllFeedBack(  
    @BookId bigint,
	@UserId bigint  
)
As 
Begin
   select * from FeedBackTable where UserId=@UserId and BookId=@BookId
End