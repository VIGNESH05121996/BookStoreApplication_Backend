use BookStoreDataBase;
create table WishListTable(
    WishListId bigint Identity(1,1) Not Null Primary Key,
    BookId bigint,
	UserId bigint,

	FOREIGN KEY (BookId) REFERENCES BookTable (BookId)  ON DELETE Cascade,
	FOREIGN KEY (UserId) REFERENCES UserTable (UserId)   ON DELETE Cascade
);