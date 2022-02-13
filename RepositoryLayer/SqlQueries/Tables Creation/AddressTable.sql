Use BookStoreDataBase;
Create Table AddressTable(
   AddressId bigInt Not Null Identity(1,1) Primary Key,
   TypeId bigint,
   FullName varchar(150),
   FullAddress varchar(max),
   City varchar(255),
   State varchar(255),
   UserId bigint,
   Foreign Key (UserId) References UserTable(UserId) On Delete No Action,
   Foreign Key (TypeId) References TypeTable(TypeId)
)
