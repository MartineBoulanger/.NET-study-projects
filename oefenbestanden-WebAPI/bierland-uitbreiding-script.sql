use bierland;
create table Woonplaatsen (
	id int identity primary key,
	postcode int not null,
	naam nvarchar(50) not null
);
create table Filialen (
	id int identity primary key,
	naam nvarchar(50) not null,
	huurprijs int not null,
	woonplaatsId int not null,
	constraint FilialenWoonplaatsen foreign key (woonplaatsid) references
	Woonplaatsen(id)
);
insert into Woonplaatsen(postcode, naam) values
(8000, 'Brugge'),
(8500, 'Kortrijk');
insert into Filialen(naam, huurprijs, woonplaatsId) values
('Andros', 1000, 1),
('Delos', 2000, 1),
('Milos', 3000, 2);