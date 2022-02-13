CREATE PROCEDURE spGetAllCart(
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
		b.OriginalPrice,
		b.DiscountPrice,
		b.BookImage,
		b.BookDetails
	FROM [CartTable] AS c
	Left JOIN [BookTable] AS b On c.BookId=b.BookId
	WHERE c.UserId=@UserId
END