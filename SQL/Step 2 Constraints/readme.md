### Overview
This example contains an example of the use of Constraints in create table statements. The constraints allow us to define which values we want to store in the database.

Primary Key, Candidate key and Mandatory value constraints
The simplest forms of constraints are keys and candidate keys. Primary key is used to denote the keys that identify the table.

```sql
PRIMARY KEY (custno),
```

UNIQUE is used to denote any candidate keys.

```sql
ssn CHAR(11) UNIQUE NOT NULL,
```

CHECK constraints enables the database designer to impose limits on what values that are applicable for a specific column. 

In this case we among other things have one constraint that limits the cost of an invoice row to positive value.

```sql
CHECK (cost>0),
```
And one constraint that limits the ssn to the XXXXXX-XXXX format.

```sql
CHECK (ssn REGEXP '[0-9][0-9][0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]'),	
```

NOT NULL is used to denote mandatory values (this is natural for keys) but is also common for other types of columns. In this case, NOT NULL is used for primary keys and candidate keys among others.

Not null can also be used to guarantee that a relation is mandatory such as the relation between customer and invoice.

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

Not null can also be used to guarantee that a value is entered into other columns such as the cost for invoice rows. An invoice row does not make sense if it does not have a cost. 

```sql
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
```