Use BookStoreDataBase;
Create Table OrderTable(
   OrderId bigInt Not Null Identity(1,1) Primary Key,
   BookId bigInt,
   UserId bigint,
   AddressId bigInt,
   Price bigint,
   Quantity bigint,
   Foreign Key (BookId) References BookTable(BookId) On Delete No Action,
   Foreign Key (UserId) References UserTable(UserId) On Delete No Action,
   Foreign Key (AddressId) References AddressTable(AddressId) On Delete Cascade
)