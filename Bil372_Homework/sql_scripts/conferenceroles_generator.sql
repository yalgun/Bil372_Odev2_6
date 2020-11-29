create table ConferenceRoles(
ConferenceRole int not null,
AuthenticationID int foreign key references [User](AuthenticationID)
)
