/*-----------------------------------------------------------
Denormalization Step 3: Horizontal Denormalization
 ------------------------------------------------------------

Horizontal Denormalization (horizontal split)
+ Relatively Small performance gain
‐ Queries are more complex but less complex than vertical split
‐ Easy to implement

– invcomments are not given for all invoices which makes it a good candidate for denormalization and each field is potentially very long

lyfta ut stora textmängder (som helst förekommer sällan) så de inte behöver läsas in varje gång
lätt att göra, inte så stor förbättring av  prestandan
ställa frågor lite mer komplext pga joins

*/

DROP DATABASE a00leifo;
CREATE DATABASE a00leifo;
USE a00leifo;

CREATE TABLE customer(
	custno CHAR(6) NOT NULL,
	ssn CHAR(11) UNIQUE NOT NULL,
	customername VARCHAR(10) NOT NULL,
	regdate DATETIME,
	PRIMARY KEY (custno),
	CHECK ((regdate>”2009-01-01”)AND(regdate<”2010-01-01”)),
	CHECK (ssn REGEXP '[0-9][0-9][0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]'),	
) ENGINE=INNODB;

CREATE TABLE company(
	compnumber INTEGER,
	companyname VARCHAR(30),
	PRIMARY KEY (compnumber)
) ENGINE=INNODB;

CREATE TABLE product(
	prodnumber INTEGER,
	productname VARCHAR(30),
	PRIMARY KEY (prodnumber)
) ENGINE=INNODB;

CREATE TABLE invoicerow(
	invoiceno INTEGER NOT NULL,
	rownumber INTEGER,
	custno CHAR(6) NOT NULL,
	datepaid DATETIME,
	productname INTEGER,
	company INTEGER,
	cost REAL,
	PRIMARY KEY (invoiceno,rownumber),
	FOREIGN KEY (company) REFERENCES company(compnumber),
	FOREIGN KEY (productname) REFERENCES product(prodnumber)
) ENGINE=INNODB;

CREATE TABLE PAIDinvoicerow(
	invoiceno INTEGER NOT NULL,
	rownumber INTEGER,
	custno CHAR(6) NOT NULL,
	datepaid DATETIME,
	productname INTEGER,
	company INTEGER,
	cost REAL,
	PRIMARY KEY (invoiceno,rownumber),
	FOREIGN KEY (company) REFERENCES company(compnumber),
	FOREIGN KEY (productname) REFERENCES product(prodnumber)
) ENGINE=INNODB;

CREATE TABLE invoicerowinvcomment(
	invoiceno INTEGER NOT NULL,
	rownumber INTEGER,
	invcomment VARCHAR(1024),
	PRIMARY KEY (invoiceno,rownumber),
	FOREIGN KEY (invoiceno,rownumber) REFERENCES invoicerow(invoiceno,rownumber)
) ENGINE=INNODB;

CREATE TABLE PAIDinvoicerowinvcomment(
	invoiceno INTEGER NOT NULL,
	rownumber INTEGER,
	invcomment VARCHAR(1024),
	PRIMARY KEY (invoiceno,rownumber),
	FOREIGN KEY (invoiceno,rownumber) REFERENCES PAIDinvoicerow(invoiceno,rownumber)
) ENGINE=INNODB;
