create database kaasland;
go
use kaasland;
go
create table Kazen (
	id int identity primary key,
	naam nvarchar(50) not null,
	soort nvarchar(50) not null,
	smaak nvarchar(50) not null
);
insert into Kazen(naam, soort, smaak) values
('Oud-Brugge', 'hard', 'pittig'),
('Wattou', 'halfhard', 'zacht'),
('Wynendaele','zacht','pittig'),
('La Prihel', 'vers', 'pittig'),
('GrevenBroucker','blauwgeaderd','romig');