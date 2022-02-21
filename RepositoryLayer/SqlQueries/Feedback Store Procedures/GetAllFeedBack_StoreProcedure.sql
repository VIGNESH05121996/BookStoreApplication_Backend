Create Procedure spGetAllFeedBack(  
    @BookId bigint,
	@UserId bigint  
)
As 
Begin
   SELECT 
		f.FeedBackId,
		f.BookId,
		f.UserId,
		f.FeedBack,
		f.Ratings,
		u.FullName
	FROM [FeedBackTable] AS f
	Left JOIN [UserTable] AS u On f.UserId=u.UserId
	WHERE u.UserId=@UserId and f.BookId=@BookId
End