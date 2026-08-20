/*-----------------------------------------------------------
Constraints - restriktioner/begränsningar
 ------------------------------------------------------------
 Primary keys and Candidate Keys (unique)
	Primary key automatically unique
	We specify Unique for candidate key (ssn)
• Not Null - måste fyllas i
• Check constraints

Check constraints are not possible in older MySQL (before 2019, MySQL 8.0.16) therefore a workaround may be needed for very old systems
	• Views Simple, but works only in some cases
	• Triggers More difficult but works for any case
	• Procedures Same as triggers but more restricted
	
Conditions to check value e.g. regdate>xxx or using regular expressions for string matching

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
	CHECK (ssn REGEXP '[0-9][0-9][0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]'),	
) ENGINE=INNODB;

CREATE TABLE invoice(
	invoiceno INTEGER NOT NULL,
	custno CHAR(6) NOT NULL,
	invcomment VARCHAR(1024),
	datepaid DATETIME,
	PRIMARY KEY (invoiceno),
	FOREIGN KEY (custno) REFERENCES customer(custno)
) ENGINE=INNODB;

CREATE TABLE invoicerow(
	invoiceno INTEGER NOT NULL,
	rownumber INTEGER,
	productname VARCHAR(30),
	company VARCHAR(30),
	cost REAL NOT NULL,
	PRIMARY KEY (invoiceno,rownumber),
  CHECK (cost>0),
	FOREIGN KEY (invoiceno) REFERENCES invoice(invoiceno)
) ENGINE=INNODB;
