--DROP TABLES
DROP TABLE Product CASCADE CONSTRAINTS;
DROP TABLE Gerecht CASCADE CONSTRAINTS;
DROP TABLE Boodschappenlijst CASCADE CONSTRAINTS;
DROP TABLE  Winkel CASCADE CONSTRAINTS;
DROP TABLE Winkel_product CASCADE CONSTRAINTS;
DROP TABLE Gerecht_product CASCADE CONSTRAINTS;
DROP TABLE Boodschappenlijst_product CASCADE CONSTRAINTS;
DROP TABLE Categorie CASCADE CONSTRAINTS;

-- CREATE TABLES


CREATE TABLE Categorie
(
	naam varchar2(100) PRIMARY KEY,
	naamHoofdCategorie varchar2(100) REFERENCES Categorie(naam)
);

CREATE TABLE Product 
(
	id number PRIMARY KEY,
	naam varchar2(100),
	houdbaarheid date,
	hoeveelheid varchar2(100),
	categorieNaam varchar2(100) REFERENCES Categorie(naam)
);

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

CREATE TABLE Boodschappenlijst
(
	id number PRIMARY KEY
);

CREATE TABLE Boodschappenlijst_product
(
	productId number REFERENCES Product(id),
	boodschappenlijstId number REFERENCES Boodschappenlijst(id),
	aantal number,
	CONSTRAINT boodschappenlijst_product_pk PRIMARY KEY (productId, boodschappenlijstId)
);

-- INSERT TESTDATA
-- Product
INSERT INTO Product(id, naam, hoeveelheid) VALUES (0, 'Creme Fresh', '125 ml');
INSERT INTO Product(id, naam, hoeveelheid) VALUES (1, 'Eieren', '6st');
INSERT INTO Product(id, naam, hoeveelheid) VALUES (2, 'Gehakt', '400 gram');
INSERT INTO Product(id, naam, hoeveelheid) VALUES (3, 'Geraspte Kaas' , '100 gram');
INSERT INTO Product(id, naam, hoeveelheid) VALUES (4, 'Kip', '400 gram');
INSERT INTO Product(id, naam, hoeveelheid) VALUES (5, 'Meel', '1 kg');
INSERT INTO Product(id, naam, hoeveelheid) VALUES (6, 'Melk', '1 L');
INSERT INTO Product(id, naam, hoeveelheid) VALUES (7, 'Noodles', '6 porties');
INSERT INTO Product(id, naam, hoeveelheid) VALUES (8, 'Pak Macaroni', '1 kg');
INSERT INTO Product(id, naam, hoeveelheid) VALUES (9, 'Paprika', 'Zak 3 stuks');
INSERT INTO Product(id, naam, hoeveelheid) VALUES (10, 'Spekreepjes', '100 gram');
INSERT INTO Product(id, naam, hoeveelheid) VALUES (11, 'Spinazie', 'Zak 300 gram');
INSERT INTO Product(id, naam, hoeveelheid) VALUES (12, 'Stamp Aardappels', '500 gram');
INSERT INTO Product(id, naam, hoeveelheid) VALUES (13, 'Wokgroente', 'Zak 210 gram');
INSERT INTO Product(id, naam, hoeveelheid) VALUES (14, 'Wrap saus', '1 cl');
INSERT INTO Product(id, naam, hoeveelheid) VALUES (15, 'Wraps', '6 st');
INSERT INTO Product(id, naam, hoeveelheid) VALUES (16, 'Zak Andijviesla', '250 gram');

--Gerecht
INSERT INTO Gerecht VALUES (0, 'Macaroni');
INSERT INTO Gerecht VALUES (1, 'Tortilla wraps');
INSERT INTO Gerecht VALUES (2, 'Andijvi stamp');
INSERT INTO Gerecht VALUES (3, 'Noodles');
INSERT INTO Gerecht VALUES (4, 'Kipspinazie pasta');
INSERT INTO Gerecht VALUES (5, 'Spinazie met gehakt');
INSERT INTO Gerecht VALUES (6, 'Pannenkoeken');

--Gerecht product
INSERT INTO Gerecht_product VALUES(2, 0, 50);
INSERT INTO Gerecht_product VALUES(3, 0, 30);
INSERT INTO Gerecht_product VALUES(8, 0, 25);
INSERT INTO Gerecht_product VALUES(9, 0, 33);

INSERT INTO Gerecht_product VALUES(2,1,50);
INSERT INTO Gerecht_product VALUES(3,1,50);
INSERT INTO Gerecht_product VALUES(9,1,33);
INSERT INTO Gerecht_product VALUES(14,1,100);
INSERT INTO Gerecht_product VALUES(15,1,100);
INSERT INTO Gerecht_product VALUES(16,1,10);

INSERT INTO Gerecht_product VALUES(9,2,33);
INSERT INTO Gerecht_product VALUES(10, 2, 100);
INSERT INTO Gerecht_product VALUES(12, 2, 50);
INSERT INTO Gerecht_product VALUES(16,2,80);

INSERT INTO Gerecht_product VALUES(4,3,50);
INSERT INTO Gerecht_product VALUES(7, 3, 17);
INSERT INTO Gerecht_product VALUES(13, 3, 80);

INSERT INTO Gerecht_product VALUES(0, 4, 100);
INSERT INTO Gerecht_product VALUES(4,4,50);
INSERT INTO Gerecht_product VALUES(8,4, 25);
INSERT INTO Gerecht_product VALUES(11,4,33);

INSERT INTO Gerecht_product VALUES(2,5,50);
INSERT INTO Gerecht_product VALUES(11,5,50);
INSERT INTO Gerecht_product VALUES(12,5,33);

INSERT INTO Gerecht_product VALUES(1, 6, 50);
INSERT INTO Gerecht_product VALUES(5, 6, 50);
INSERT INTO Gerecht_product VALUES(6,6,100);

--Winkel
INSERT INTO Winkel VALUES (0, 'Albert Heijn');
INSERT INTO Winkel VALUES (1, 'Jumbo');

-- Winkel product
INSERT INTO Winkel_product VALUES (0, 0 , 0);
INSERT INTO Winkel_product VALUES (1, 0, 1);
INSERT INTO Winkel_product VALUES (2, 0, 2);
INSERT INTO Winkel_product VALUES (3, 0, 3);
INSERT INTO Winkel_product VALUES (4, 0, 4);
INSERT INTO Winkel_product VALUES (5, 0,5);
INSERT INTO Winkel_product VALUES (6, 0,6);
INSERT INTO Winkel_product VALUES (7, 0,7);
INSERT INTO Winkel_product VALUES (8, 0, 8);
INSERT INTO Winkel_product VALUES (9, 0, 9);
INSERT INTO Winkel_product VALUES (10, 0, 10);
INSERT INTO Winkel_product VALUES (11, 0,11);
INSERT INTO Winkel_product VALUES (12, 0,12);
INSERT INTO Winkel_product VALUES (13, 0, 13);
INSERT INTO Winkel_product VALUES (14, 0, 14);
INSERT INTO Winkel_product VALUES (15, 0, 15);
INSERT INTO Winkel_product VALUES (16, 0, 16);

INSERT INTO Winkel_product VALUES (0, 1, 16);
INSERT INTO Winkel_product VALUES (1, 1, 15);
INSERT INTO Winkel_product VALUES (2, 1, 14);
INSERT INTO Winkel_product VALUES (3, 1, 13);
INSERT INTO Winkel_product VALUES (4, 1, 12);
INSERT INTO Winkel_product VALUES (5, 1, 11);
INSERT INTO Winkel_product VALUES (6, 1, 10);
INSERT INTO Winkel_product VALUES (7, 1, 9);
INSERT INTO Winkel_product VALUES (8, 1, 8);
INSERT INTO Winkel_product VALUES (9, 1, 7);
INSERT INTO Winkel_product VALUES (10, 1, 6);
INSERT INTO Winkel_product VALUES (11, 1, 5);
INSERT INTO Winkel_product VALUES (12, 1, 4);
INSERT INTO Winkel_product VALUES (13, 1, 3);
INSERT INTO Winkel_product VALUES (14, 1, 2);
INSERT INTO Winkel_product VALUES (15, 1, 1);
INSERT INTO Winkel_product VALUES (16, 1, 0);

commit;