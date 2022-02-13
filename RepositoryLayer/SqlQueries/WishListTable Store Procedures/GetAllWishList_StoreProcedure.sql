CREATE PROCEDURE spGetAllWishList(
	@UserId bigint
)
AS 
BEGIN
	SELECT 
		c.WishListId,
		c.BookId,
		c.UserId,
		b.BookName,
		b.BookAuthor,
		b.OriginalPrice,
		b.DiscountPrice,
		b.BookImage,
		b.BookDetails
	FROM [WishListTable] AS c
	Left JOIN [BookTable] AS b On c.BookId=b.BookId
	WHERE c.UserId=@UserId
END