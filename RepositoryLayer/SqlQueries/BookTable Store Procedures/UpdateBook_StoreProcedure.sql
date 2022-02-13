Create Procedure spUpdateBook(  
    @BookId bigint,        
    @BookName varchar(30),
    @BookAuthor varchar(30),
    @OriginalPrice bigint,
	@DiscountPrice bigint,
	@BookQuantity bigint,
    @BookDetails varchar(100),
    @UserId bigint
)
As 
Begin
   UPDATE BookTable set BookName=@BookName,BookAuthor=@BookAuthor,OriginalPrice=@OriginalPrice,
   DiscountPrice=@DiscountPrice,BookQuantity=@BookQuantity,BookDetails=@BookDetails 
   where BookId=@BookId and UserId=@UserId
End

