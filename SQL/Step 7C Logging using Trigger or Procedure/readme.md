### Overview
This example contains an example of the use of triggers. A trigger is a stored procedure that is fired automatically by some update
of the database. Triggers perform actions in the database without the need for intervention by the user.

### Introduction

One very common use for triggers is logging. The advantage is that the logging is transparent, happens
without any change of the application, and that it works regardless of which code that updated the information,
and that it is completely hidden from the user.

A log is a table that stores the history of some other table. Commonly changed values of the corresponding table are stored 
(often the whole table) together with user accounts, change dates and other relevant statistics.

Most commonly users do __not__ have access to log tables (as they could see the evidence of their own tampering).
Log tables make no sense at all if __anyone__ has delete or update privileges of the log.

### This Example Database

We can add code that saves some kind of a history including who made an update into a separate table. We must first create the log table. The log can contain a complete copy of the base table or some part of it. The log commonly contains the time of the update and the user name of the user that performed the update. 

In this example we store the ID of the update, the kind of update, the updated produch and the user and time of the update.

```sql
CREATE TABLE INVOICEROWLOG(
    ID           INTEGER NOT NULL AUTO_INCREMENT,
    OPERATION    CHAR(3),
    USERNAME     VARCHAR(32),
    PRODUCT      SMALLINT,
    OPTIME       DATETIME,
    PRIMARY KEY(ID)
);
```

We can then make code in a procedure that makes the logging operation before the operation that we want to keep a log of (in this case the sum of costs).

```sql
-- Update cost for certain invoice and row number. Makes sure Cost is positive

DELIMITER //
CREATE PROCEDURE GETCOSTPROD(prod VARCHAR(30))
BEGIN
  INSERT INTO INVOICEROWLOG(OPERATION,USERNAME,PRODUCT,OPTIME) VALUES ("SEL",USER(),prod,NOW());

  SELECT SUM(COST)
  FROM INVOICEROW
  WHERE PRODUCT=prod;
END;
//
```

The trigger is nearly identical to the procedure, programming wise. We first specify which event we connect the trigger to (in this case AFTER INSERT).
After that we have the code for the trigger which makes use of aa variable called NEW which contains all columns that were changed by the update, there is a corresponding variable OLD which is the information before the update. NEW.PRODUCTNAME means the name of the product that was updated.

```sql
-- Trigger for logging new invoices. Assumes same log table as in previous example

DELIMITER //
CREATE TRIGGER LOGGTRIGGER AFTER INSERT ON INVOICEROW 
FOR EACH ROW BEGIN 
   INSERT INTO INVOICEROWLOG(OPERATION,USERNAME,PRODUCT,OPTIME) 
      VALUES("INS",USER(),NEW.PRODUCTNAME,NOW());
END;
//
DELIMITER ;
```

In this case, the advantage of the trigger is that we are able to log updats even if the user has direct SQL access to that table, something that procedures will not allow.
