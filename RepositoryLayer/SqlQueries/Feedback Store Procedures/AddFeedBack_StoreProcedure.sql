Create Procedure spAddFeedBack(
	@BookId bigint,
	@Feedback varchar(max),
	@Ratings bigint,
	@UserId bigint 
)
As 
Begin
   Insert into FeedBackTable (BookId,FeedBack,Ratings,UserId) Values (@BookId,@Feedback,@Ratings,@UserId)
End