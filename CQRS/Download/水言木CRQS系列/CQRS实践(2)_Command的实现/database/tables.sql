create database [CQRS.Sample]
go

use [CQRS.Sample]
go


create table [User]
(
	Id varchar(36) not null,
	Email nvarchar(50) not null,
	NickName nvarchar(50) not null,
	[Password] varchar(20) not null,

	constraint PK_User primary key (Id)
)
go

create unique index UQ_User_Email on [User](Email)