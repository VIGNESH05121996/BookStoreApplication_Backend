use BookStoreDataBase;
CREATE TABLE BookTable(
BookId bigint Identity(1,1) Not Null,
BookName varchar(30),
BookAuthor varchar(30),
TotalRating bigint,
NoOfPeopleRated bigint,
OriginalPrice bigint,
DiscountPrice bigint,
BookImage varchar(30),
BookQuantity bigint,
BookDetails varchar(100),
UserId bigint Not Null,
PRIMARY KEY (BookId),
FOREIGN KEY (UserId) REFERENCES UserTable(UserId) 
);