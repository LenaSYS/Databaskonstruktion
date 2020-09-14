/*-----------------------------------------------------------
Data Types
 ------------------------------------------------------------
 
• CHAR / VARCHAR
	– Char for fixed length columns i.e. ssn - vet man hur mycket plats något ska ta -allokera den platsen (data consistency, and performance.)
      CHAR takes up 1 byte per character. CHAR(100) field (or variable) takes up 100 bytes on disk, regardless of the string it holds.
      VARCHAR takes up 1 byte per character, + 2 bytes to hold length information, VARCHAR(100) data type = ‘Jen’, then it would take up 3 bytes (for J, E, and N) plus 2 bytes, or 5 bytes in al
      When should I use CHAR instead of VARCHAR? The short answer is: Almost never.
	– Varchar for varying size columns - ( Variable Character Field) 
    
	– Compression?
    kan spara data med compression, tar extra resurser för att lagra och ta fram datan, för stora textmängder man sällan efterfrågar
• DECIMAL
	– Four bytes per 9,9 decimal digits i.e. 8 bytes, four for
	decimal decimal part and four for integer integer part
    signed integers it's 2,147,483,647.
• TINYINT / SMALLINT / MEDIUMINT / INT / BIGINT
	– 1,2,3,4,8 Bytes integer
       ( 1-byte unsigned integer has a range of 0 to 255 (256tecken) -  1-byte signed integer range of -128 to 127 (samma värde unsigned är bara posetiva))
       256*256 = 65 536 =2 byte
• BIT
	– Can be used to save bytes for flags in very small tables
    0/1
• FLOAT / DOUBLE / REAL
	– Floating point invnumbers either four or eight bytes
	   (REAL is a synonym for DOUBLE PRECISION (a nonstandard variation) unless the REAL_AS_FLOAT SQL mode is enabled.)
       double = float med dubbel precition
*/

DROP DATABASE a00leifo;
CREATE DATABASE a00leifo;
USE a00leifo;

CREATE TABLE customer(
	custno CHAR(6),
	ssn CHAR(11),
	customername VARCHAR(10) NOT NULL,
	regdate DATETIME,
	PRIMARY KEY (custno)
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
	custno CHAR(6) NOT NULL,
	productname VARCHAR(30),
	company VARCHAR(30),
	cost REAL,
	PRIMARY KEY (invoiceno,rownumber),
	FOREIGN KEY (invoiceno) REFERENCES invoice(invoiceno)
) ENGINE=INNODB;