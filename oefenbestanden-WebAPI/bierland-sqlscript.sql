create database bierland;
go
go
use bierland;
create table Brouwers (
	id int identity primary key,
	naam nvarchar(50) not null,
	postcode int not null,
	gemeente nvarchar(50) not null
);
insert into Brouwers(naam, postcode, gemeente) values
('Achouffe',6666,'Achouffe'),
('Alken',3570,'Alken'),
('Bavik',8531,'Bavikhove');