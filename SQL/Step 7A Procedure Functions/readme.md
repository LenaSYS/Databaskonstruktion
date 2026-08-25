### Overview
This example contains an example of the use of stored procedures. A stored procedure is the same thing as a function or method in an ordinary programming language, but it is stored in the database itself. By using stored procedures we gain a slight bit of performance but also gain control over exactly which code that is run in the database. If we use stored procedures it is more difficult to compromise the security of the database.

### Introduction

Stored procedures have parameters like functions in any programming language.

There are few books that in any length discuss stored procedures in MySQL, one well known book is MySQL stored procedure programming from Oriley. There are two types of tools for working with procedures and triggers. If you use tools that use the MySQL formatting rules, delimiters are required to tell the interpreter when the statement ends. Most examples of MySQL code found on the internet uses these delimiters.

### This Example

Most procedures are commonly either select procedures that read information or computes values using select commans. The other type of procedure updates the database using insert or update commands.

This exmple shows the scaffolding for a stored PROCEDURE that returns the average cost of all of the unpaid invoice rows.

The advantage of encapsulating a single select statement is small, in some other servers there is a small performance gain to be made, but in MySQL the performance gains are insignificant.

The only advantage of using the procedure is that we can guarantee that the code that is run is exactly the code in the procedure, which may be an advantage from a security standpoint, if the user does not have access to the base table directly.

```sql
-- Get average cost procedure
DELIMITER //
CREATE PROCEDURE GETAVGCOST()
BEGIN
    SELECT AVG(COST) FROM INVOICEROW;
END;
//
DELIMITER ;
```

The stored procedure is executed by a CALL statement (row 14) or by an application (such as a php application running on a web server). 

```sql
-- Execute procedure
CALL GETAVGCOST();
```

The second exmple shows a very simple stored procedure that updates the cost of an invoice using the update statement. The procedure has two parameters, the invoice row number and the cost (this code updates all invoices with that row number, so it is not very realistic).

```sql
-- Update cost for certain invoice row number
DELIMITER //
CREATE PROCEDURE SETCOSTPROD(InRowno INTEGER, InCost REAL)
BEGIN
  UPDATE INVOICEROW SET COST=InCost WHERE NUMBER=InRowno;
END;
//
```

The main advantage of using the procedure is that we can guarantee that the code that is run is __exactly__ the code in the procedure, which may be an advantage from a security standpoint, given that the user does not have access to the base table directly. Even if an attacker gains control over the application only the SQL code in the procedures can be executed given that we have privileges that limit access to the base tables.

