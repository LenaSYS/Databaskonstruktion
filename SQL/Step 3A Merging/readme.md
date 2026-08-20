### Overview
This example contains an example of the use of Denormalization. In this case we join invoice and invoice row, to create a table that is faster to search when it comes to matchin invoices with invoice rows. This reduces the need for costly join queries and allows us to speed things up by defining indexes.


### Table merging
Table merging exploits the fact that in many cases, searches progress from the 1:N side in one to many relationships by using a join query. 

By merging the two tables we can instead use simple queries to search the invoice rows, but we introduce redundancy. 

This only makes sense for 1:1 and 1:N relationships.

Technilcally this is very simple as the only thing we need to do is to take the columns from invoice and adding them to invoice row.

```sql
CREATE TABLE invoicerow(
  invoiceno INTEGER NOT NULL,
  rownumber INTEGER,
  custno CHAR(6) NOT NULL,
  invcomment VARCHAR(1024),
  datepaid DATETIME,
  productname VARCHAR(30),
  company VARCHAR(30),
  cost REAL NOT NULL,
  PRIMARY KEY (invoiceno,rownumber),
  CHECK (cost>0),
  FOREIGN KEY (custno) REFERENCES customer(custno)
) ENGINE=INNODB;
```
The invoice number column from the invoice table needs to be removed as it otherwise would appear twice in the invoicerow table. 

The foreign key statement that refers to invoice must also be removed as the invoice table no longer exists.
