use BookStoreDataBase;
create table UserTable(
    UserId bigint IDENTITY(1,1) primary key NOT NULL,          
    FullName varchar(50) NOT NULL,          
    EmailId varchar(30) NOT NULL, 
	Password varchar(30) NOT NULL,   
    MobileNumber varchar(20) NOT NULL,  
)