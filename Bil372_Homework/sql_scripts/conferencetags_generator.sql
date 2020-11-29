create table ConferenceTags(
Tag varchar(5) primary key,
ConfID Varchar(20) foreign key references Conference(ConfID)
)