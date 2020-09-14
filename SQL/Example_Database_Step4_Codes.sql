/*-----------------------------------------------------------
Denormalization Step 2: codes
 ------------------------------------------------------------

• Long Column Codes                   (långa namn och så i tabellen)
+ Very small performance gain         (inte så jättehög effektivitetsvinning på det)
+ Queries are only slightly more complex (lite mer komplexa frågor)
+ Very easy to implement                  (lätt att implementera)

– Product name / company name are good candidates  (namn som upprepas)
– customer name is not since most customer names are unique i.e. we do not benefit from making codes 

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
	invcomment VARCHAR(1024),
	datepaid DATETIME,
	productname INTEGER,
	company INTEGER,
	cost REAL,
	PRIMARY KEY (invoiceno,rownumber),
	FOREIGN KEY (custno) REFERENCES customer(custno)
  FOREIGN KEY (company) REFERENCES company(compnumber),
	FOREIGN KEY (productname) REFERENCES product(prodnumber)
) ENGINE=INNODB;

CREATE TABLE invoicerowinvcomment(
	invoiceno INTEGER NOT NULL,
	productname INTEGER,
	invcomment VARCHAR(1024),
	PRIMARY KEY (invoiceno,rownumber),
	FOREIGN KEY (invoiceno,rownumber) REFERENCES invoicerow(invoiceno,rownumber)
) ENGINE=INNODB;

CREATE TABLE PAIDinvoicerowinvcomment(
	invoiceno INTEGER NOT NULL,
	productname INTEGER,
	invcomment VARCHAR(1024),
	PRIMARY KEY (invoiceno,rownumber),
	FOREIGN KEY (invoiceno,rownumber) REFERENCES PAIDinvoicerow(invoiceno,rownumber)
) ENGINE=INNODB;

