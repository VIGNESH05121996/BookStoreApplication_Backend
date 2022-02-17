Create Procedure spCreateBooks(
    @BookName varchar(30),
    @BookAuthor varchar(30),
    @OriginalPrice bigint,
	@DiscountPrice bigint,
	@BookQuantity bigint,
    @BookDetails varchar(max),
    @UserId bigint
)
As 
Begin
   Insert into BookTable (BookName,BookAuthor,OriginalPrice,DiscountPrice,BookQuantity,BookDetails,UserId)
   Values (@BookName,@BookAuthor,@OriginalPrice,@DiscountPrice,@BookQuantity,@BookDetails,@UserId)
End