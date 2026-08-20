/*-----------------------------------------------------------
Denormalization Step 1: Merging
 ------------------------------------------------------------
När vi normaliserar så slår vi isär datan för att tabort redundans - alltså
frågor blir långsammare pga joins
denormaliserar vi - inför redundans - och slår ihop tabeller
                                          -redundansen högre
                                          -tar mer plats
                                          +går snabbare att få svar och ställa frågor mot
                
Table Merging (Joining tables to avoid costly joins)
+  Large to Medium performance gain(beroende på hur många joins man får bort desto bättre, sedan kan man få med data i tabellen som man kan få arbeta för att få bort)
‐ Easy to implement hard to use    (bara lägga ihop tabeller)
‐ Error prone                      (risk för att det blir felaktigheter när vi lägger in data exv två olika invoices med olika datepaid eller olika invcomment)

invoice and invoicerow can be merged to make
searching for invoice rows much faster

New invoicerow table contains first all key columns from both tables then columns from invoice and then any additional non-key columns from invoicerow

*/

CREATE TABLE customer(
	custno CHAR(6) NOT NULL,
	ssn CHAR(11) UNIQUE NOT NULL,
	customername VARCHAR(10) NOT NULL,
	regdate DATETIME,
	PRIMARY KEY (custno),
	CHECK ((regdate>”2009-01-01”)AND(regdate<”2010-01-01”)),
	CHECK (ssn REGEXP '[0-9][0-9][0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]'),	
) ENGINE=INNODB;

CREATE TABLE invoicerow(
	invoiceno INTEGER NOT NULL,
	rownumber INTEGER,
	custno CHAR(6) NOT NULL,
	invcomment VARCHAR(1024),
	datepaid DATETIME,
	productname VARCHAR(30),
	company VARCHAR(30),
	cost REAL,
	PRIMARY KEY (invoiceno,rownumber),
	FOREIGN KEY (custno) REFERENCES customer(custno)
) ENGINE=INNODB;