
create table Submissions(
SubmissionID int primary key,
prevSubmissionID int,
AuthenticationID int foreign key references [User](AuthenticationID),
ConfID Varchar(20) foreign key references Conference(ConfID)
)
