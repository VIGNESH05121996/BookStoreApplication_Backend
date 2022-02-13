Use BookStoreDataBase;
Create Table TypeTable(
  TypeId bigint Identity(1,1) Not Null Primary Key ,
  AddressType varchar(255)
)
Insert into TypeTable (AddressType) Values ('Home');
Insert into TypeTable (AddressType) Values ('Work');
Insert into TypeTable (AddressType) Values ('Others');