Create Procedure spAddFeedBack(
	@BookId bigint,
	@Feedback varchar(max),
	@Ratings bigint,
	@UserId bigint 
)
As 
Begin
   Insert into FeedBackTable (BookId,FeedBack,Ratings,UserId) Values (@BookId,@Feedback,@Ratings,@UserId)
   Begin
   Declare @rowCounts int;
   select @rowCounts=count(*) from FeedBackTable where BookId=@BookId;
   Declare @averageOfRatings bigint;
   select @averageOfRatings=avg(Ratings) from FeedBackTable where BookId=@BookId;
       if exists(select * from [FeedBackTable] where @rowCounts=1)
	   Begin
		 update [BookTable] set TotalRating=@Ratings where BookId=@BookId
		 update [BookTable] set NoOfPeopleRated=@rowCounts where BookId=@BookId
	   End
	   else if exists(select * from [FeedBackTable] where @rowCounts>1)
	   Begin
	     update [BookTable] set TotalRating=@averageOfRatings where BookId=@BookId
		 update [BookTable] set NoOfPeopleRated=@rowCounts where BookId=@BookId
		End
   End
End