CREATE TABLE zene(
	id integer not null primary key autoincrement,
	cim text not null,
	eloado text not null,
	kiadas integer not null,
	hossz integer not null,
	prioritas integer not null,
	unique(cim)
);