CREATE PROCEDURE spGetAllOrders(
	@UserId bigint
)
AS 
BEGIN
	SELECT 
		o.OrderId,
		o.BookId,
		o.AddressId,
		o.UserId,
		o.Price,
		o.Quantity,
		b.BookName,
		b.BookAuthor,
		b.OriginalPrice,
		b.DiscountPrice,
		b.BookImage,
		b.BookDetails,
		a.TypeId,
		a.FullName,
		a.FullAddress,
		a.City,
		a.State
	FROM [OrderTable] AS o
	Left JOIN [BookTable] AS b On o.BookId=b.BookId
	Right Join [AddressTable] As a On o.AddressId=a.AddressId
	WHERE o.UserId=@UserId
END