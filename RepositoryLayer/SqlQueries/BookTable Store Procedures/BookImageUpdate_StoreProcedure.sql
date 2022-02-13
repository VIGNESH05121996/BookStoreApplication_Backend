Create Procedure spBookImageUpdate(  
    @BookId bigint,        
    @BookImage varchar(max),
    @UserId bigint
)
As 
Begin
   UPDATE BookTable set BookImage=@BookImage where BookId=@BookId and UserId=@UserId
End