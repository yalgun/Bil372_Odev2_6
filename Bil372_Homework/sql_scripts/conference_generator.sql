create table Conference(
ConfID  Varchar(20) primary key,
CreationDateTime  Datetime,
NAME varchar(100),
ShortName varchar(19),
Year Integer,
StartDate Date,
EndDate Date,
SubmissionDeadline Date, 
WebSite Varchar(100),
CreatorUser int constraint createruser foreign key references [User](AuthenticationID)
)
