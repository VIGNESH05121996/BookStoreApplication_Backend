CREATE PROCEDURE spGetCartWithCartId(
	@CartId bigint,
	@UserId bigint
)
AS 
BEGIN
	SELECT 
		c.CartId,
		c.BookId,
		c.Quantity,
		c.UserId,
		b.BookName,
		b.BookAuthor,
		b.TotalRating,
		b.NoOfPeopleRated,
		b.OriginalPrice,
		b.DiscountPrice,
		b.BookImage,
		b.BookQuantity,
		b.BookDetails
	FROM [CartTable] AS c
	LEFT JOIN [BookTable] AS b ON c.BookId=b.BookId
	WHERE c.UserId=@UserId and c.CartId=@CartId
END