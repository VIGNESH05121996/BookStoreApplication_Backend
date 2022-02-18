Use BookStoreDataBase;
Create Table OrderTable(
   OrderId bigInt Not Null Identity(1,1) Primary Key,
   BookId bigInt,
   UserId bigint,
   AddressId bigInt,
   Price bigint,
   Quantity bigint,
   Foreign Key (BookId) References BookTable(BookId)  ON DELETE SET NULL,
   Foreign Key (UserId) References UserTable(UserId)  ON DELETE SET NULL,
   Foreign Key (AddressId) References AddressTable(AddressId)  ON DELETE SET NULL
)