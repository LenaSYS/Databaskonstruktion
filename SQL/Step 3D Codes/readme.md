### Overview
This example makes use of codes, to reduce the number of long text columns with repeating values.
		
### Codes
When we have text values that appear many times, we gain performance by changing that text value to a code i.e. a number that represents that text string. 

The more a certain text is repeated, the more we gain. In the case of the invoice, the company name and the product names are long strings that are repeated over and over again.

Technilcally this is quite straightforward. We create a tables with the code, and the corresponding text.

```sql
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
```

In the original table use a foreign key to refer to the code table and finally we change the datatypes from varchar(30) to integer.

```sql
CREATE TABLE invoicerow(
  invoiceno INTEGER NOT NULL,
  rownumber INTEGER,
  custno CHAR(6) NOT NULL,
  invcomment VARCHAR(1024),
  datepaid DATETIME,
  productname INTEGER,
  company INTEGER,
  cost REAL NOT NULL,
  PRIMARY KEY (invoiceno,rownumber),
  CHECK (cost>0),
  FOREIGN KEY (custno) REFERENCES customer(custno)
  FOREIGN KEY (company) REFERENCES company(compnumber),
  FOREIGN KEY (productname) REFERENCES product(prodnumber)
) ENGINE=INNODB;
```

By doing this we reduce the (at most) 30 character columns to only two bytes, meaning that in the extreme we have gone from 60 bytes to only four. As the value is a varchar, on average the numbers are less impressive, but the gain can be substantial. 