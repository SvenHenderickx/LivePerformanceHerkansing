--DROP TABLES
DROP TABLE Product CASCADE CONSTRAINTS;
DROP TABLE Gerecht CASCADE CONSTRAINTS;
DROP TABLE Boodschappenlijst CASCADE CONSTRAINTS;
DROP TABLE  Winkel CASCADE CONSTRAINTS;
DROP TABLE Winkel_product CASCADE CONSTRAINTS;
DROP TABLE Gerecht_product CASCADE CONSTRAINTS;
DROP TABLE Boodschappenlijst_product CASCADE CONSTRAINTS;

-- CREATE TABLES

CREATE TABLE Product 
(
	id number PRIMARY KEY,
	naam varchar2(100),
	houdbaarheid date,
	hoeveelheid varchar2(100),
	vaderCategorie varchar2(100),
	categorieNaam varchar2(100)
);

ALTER TABLE Product
ADD FOREIGN KEY (vaderCategorie)
REFERENCES Product(categorieNaam)

CREATE TABLE Gerecht
(
	id number PRIMARY KEY,
	naam varchar2(100)
);

CREATE TABLE Gerecht_product
(
	productId number REFERENCES Product(id),
	gerechtId number REFERENCES Gerecht(id),
	verpakkingsProcent number,
	CONSTRAINT gerecht_product_pk PRIMARY KEY (productId, gerechtId)
);

CREATE TABLE Winkel
(
	id number PRIMARY KEY,
	naam varchar2(100)
);

CREATE TABLE Winkel_product
(
	productId number REFERENCES Product(id),
	winkelId number REFERENCES Winkel(id),
	loopRoute number,
	CONSTRAINT winkel_product_pk PRIMARY KEY (productId, winkelId)
);

