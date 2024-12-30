Create Table Vehicle (
id bigint Identity(1,1) not null,
brand varchar(30) not null,
model varchar (50) not null,
license_plate varchar(20) unique not null,
yearOfFabrication smallint not null,
fuelType varchar(30) not null,
Primary key(id)
)

Create Table Client (
id bigint Identity(1,1) not null,
fullname varchar(max) not null,
email varchar (50) unique not null,
phone int not null,
license varchar(50) not null,
Primary key(id)
)

Create Table Renting (
id bigint Identity(1,1) not null,
ClientId bigint not null,
VehicleId bigint not null,
initialDate date not null,
endDate date not null,
initialKms int not null,
Primary key(id),
Foreign Key (ClientId) references Client(Id),
Foreign key (VehicleId) references Vehicle(Id)
)