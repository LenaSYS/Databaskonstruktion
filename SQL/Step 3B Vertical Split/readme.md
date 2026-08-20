### Overview
This example makes use vertical denormalization by splitting the table vertically into two parts, of which one part receives much more queries than the other.


### Vertical Denormalization
Vertical denormalization is possible if there is some value that affects the usage frequency of the table. 

In the case of many types of invoice databases, the payment date of the invoice is such a value. 

The unpiad invoices are used much more frequently than a paid invoice. 

If the table is thus split into two tables, one for paid invoices (which will be smaller and therefore faster) and one for the unpaid invoices, the performance will increase as we need to work with less information most of the time.

Technically this is done by duplicating the invoice table into two tables, paid and unpaid invoices. 

The only difference is the name of the table. Since we already merged the same table invoicerow, we get two tables again, but one table is used much more frequently than the other, and also contains much fewer rows.

If the column that makes this decision is binary (if it was called paidinvoice and was either true or false) we can remove this column completely since the table that the row is part of decides this. But in this case we (which is more useful) store the date that the invoice was paid.

```sql
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

```
