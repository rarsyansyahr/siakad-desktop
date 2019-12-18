create database db_siakad;

use db_siakad;

create table mahasiswa(
	id smallint NOT NULL PRIMARY KEY IDENTITY(1,1),
	nim char(10) NOT NULL UNIQUE,
	nama varchar(30) NOT NULL,
	alamat varchar(50) NOT NULL
);

create table matakuliah(
	id tinyint NOT NULL PRIMARY KEY IDENTITY(1,1),
	kode varchar(5) NOT NULL UNIQUE,
	nama varchar(30) NOT NULL,
	sks tinyint NOT NULL
);

create table dosen(
	id tinyint NOT NULL PRIMARY KEY IDENTITY(1,1),
	nidn char(10) NOT NULL UNIQUE,
	nama varchar(30) NOT NULL,
	alamat varchar(50) NOT NULL
);

create table kelas(
	id tinyint NOT NULL PRIMARY KEY IDENTITY(1,1),
	nama char(5) NOT NULL UNIQUE
);

create table detailmahasiswa(
	id smallint NOT NULL PRIMARY KEY IDENTITY(1,1),
	idmahasiswa smallint NOT NULL foreign key references mahasiswa(id)
		on update cascade on delete cascade,
	idmatakuliah tinyint NOT NULL foreign key references matakuliah(id)
		on update cascade on delete cascade
);

create table detaildosen(
	id smallint NOT NULL PRIMARY KEY IDENTITY(1,1),
	iddosen tinyint NOT NULL foreign key references dosen(id)
		on update cascade on delete cascade,
	idmatakuliah tinyint NOT NULL foreign key references matakuliah(id)
		on update cascade on delete cascade
);

create table pengguna(
	id tinyint NOT NULL PRIMARY KEY IDENTITY(1,1),
	nama varchar(30) NOT NULL,
	username varchar(10),
	password varchar(50)
);