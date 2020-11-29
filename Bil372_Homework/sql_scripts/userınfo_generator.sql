create table UserInfo(
Title varchar(30),
Name varchar(30),
Affilation varchar(50),
primaryEmail varchar(50),
secondaryEmail varchar(50),
password varchar(50),
Phone varchar(50),
fax varchar(50),
URL varchar(100),
Address varchar(100),
City varchar(15),
Country varchar(30),
Record varchar(50),
CreationDate Datetime,
AuthenticationID int foreign key references [User](AuthenticationID)
)
