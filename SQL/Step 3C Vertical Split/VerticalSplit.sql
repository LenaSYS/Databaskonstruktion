/*-----------------------------------------------------------
Denormalization Step 4: Vertical Denormalization
 ------------------------------------------------------------
Vertical Denormalization (vertical split)
+ Major performance gain
‐ Queries are more complex
‐ Difficult to implement


Vertical Denormalization
– A good category of vertical split is paid/unpaid
invoices. Unpaid invoices are used much more than
paid invoices.

1. Copy table and change customername for
copied table
2. For each table that is dependent of
the key of denormalized table, also
copy that table

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
