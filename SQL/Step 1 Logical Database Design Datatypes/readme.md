### Overview
This example contains an example of the use of Datatypes in create table statements. It is important to think about the datatypes since the choice of datatypes affect the performance of the database and any other design decisions made down the line.

### Initiation
The first part of the code. Makes sure that we can just re-run the script to change the database. This way we do not need to drop the database explicity, every time that we run the script. The first time that the script is run, we need to remove the drop database statement either by -- commenting or by deleting the first row from the file.

```sql
DROP DATABASE a00leifo;
CREATE DATABASE a00leifo;
USE a00leifo;
```
### This database
In this specific database, we make use of DATETIME for regdate and datepaid since both date and time is included. TIMESTAMP can also be used but has timezone conversion which may or may not be useful in each case. In the same manner, the use of INTEGER for customer number and invoice number may not be appropriate since smaller numbers may work equally well (2.000.000 rows in an invoice may be excessive). The use of real for representing money may not be the best choice when compared to the use of the decimal type.

```sql
CREATE TABLE invoice(
	invoiceno INTEGER NOT NULL,
	custno CHAR(6) NOT NULL,
	invcomment VARCHAR(1024),
	datepaid DATETIME,
	PRIMARY KEY (invoiceno),
	FOREIGN KEY (custno) REFERENCES customer(custno)
) ENGINE=INNODB;
```
Suggestions for datatyping in MySQL are available below and on the [MySQL homepage](http://dev.mysql.com/doc/refman/5.7/en/data-types.html)

### Datatypes in MySQL
The simplest and most common datatype is CHAR or VARCHAR. If the size is very short (less than about 4 characters) or if the length is fixed, we use char. The difference is that char always stores the maximum number of characters (i.e. 10 characters if we use CHAR(10)). If we use varchar the length is a maximum value, but to know where the end of the string is, one or more bytes is added to mark the end of the string.

Another very important datatype is the DATE or DATETIME datatype. The difference is that the date type does not store the time of day, just the calendar date, whereas the datetime type stores the date and time (including fractions of seconds). The size gain is neglible, but there is a semantic difference that is as important.

Numbers are also important INTEGER or SMALLINT or TINYINT or BIGINT datatypes. The integer types range from TINYINT (1 byte ±127), SMALLINT (2 bytes ±32768) INT/INTEGER (4 bytes ±2147483648) and BIGINT (8 bytes ±9223372036854775808). As integer types are used often in important places such as identifiers, it is important to choose a correct integer type, that is neither too large nor too small.

Decimal numbers DECIMAL or FLOAT/REAL/DOUBLE can either be stored as fixed point numbers (with a fixed number of decimal points) or as floating point numbes (with a known number of decimal points). The floating point variables either use four bytes, for float/real and eight bytes for double precision values. The decimal type specifies the number of positions and the number of decimals (e.g. DECIMAL(5,2) can store at most ±999.99). The advantage of fixed point is that fractions are truncated or rounded off, which may be good for storing pricing information which does not use the decimal points, but if we use it to compute for example taxes, this datatype may not be precise enough or able to store high enough values. If we want to store very large numbers with many decimals, float may not be sufficiently accurate, and we must in those cases turn to double precision.