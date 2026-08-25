### Overview
This example contains an example of the use of stored procedures and triggers for implementing constraints. 

A stored procedure is the same thing as a function or method in an ordinary programming language, but it is stored in the database itself. By using stored procedures we gain a slight bit of performance but also gain control over exactly which code that is run in the database. If we use stored procedures it is more difficult to compromise the security of the database.

This example also contains an example of the use of triggers. A trigger is a stored procedure that is fired automatically by some update
of the database. Triggers perform actions in the database without the need for intervention by the user.

### Introduction

One very common use for procedures / triggers is rule checking. The advantage is that the checking is transparent, happens
without any change of the application, and that it works regardless of which code that updated the information.

We can also check rules that are much more complex than the rules available using check constraints.

### This Example Database

This example is the same as the previous example that updates an invoice row but in addition to that code has an IF ELSE statement that has the same condition as the check constraint that we want to implement.

```sql
CREATE PROCEDURE SETCOSTPRODRULE(InInvoice integer,InRowno integer, InCost real)
BEGIN
    IF (InCost<=0) THEN
				SIGNAL SQLSTATE ‘45000’ set message_text =‘The cost cant be less than zero.’
    ELSE 
        UPDATE INVOICEROW SET COST=InCost WHERE INVOICENO=InInvoice and NUMBER=InRowno;
    END IF;
END;
```

In a procedure we use signal statement that aborts execution and displays an error message. (on older versions of mysql the signal statement does not exist)
In order to generate an error message in older versions of MySQL which do not support the signal statement which is intended for the purpose of generating error messages. If you are running MySQL 5.2 or later you can substitute that select statement for a SIGNAL statement [Mysql Documentation](https://dev.mysql.com/doc/refman/5.5/en/signal.html,see MySQL documentation).

If the condition is false we update the data just like an ordinary procedure. The advantage of using the procedure is that we can guarantee that the code that is run is exactly the code in the procedure, which may be an advantage from a security standpoint, given that the user does not have access to the base table directly. The procedure also allows us to group a set of operations into the same procedure. 

The trigger is nearly identical to the rule checking procedure, programming wise. We first specify which event we connect the trigger to (in this case BEFORE INSERT). After that we have the code for the trigger.

```sql
CREATE TRIGGER INSERTCHECK BEFORE INSERT ON INVOICEROW
FOR EACH ROW BEGIN
	IF(NEW.COST<0) THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Negative Cost Not Allowed';
	END IF;
END;
```

The only main difference compared to the procedure rule code is that we use update instead of select as the error generator and have access to a variable called 
NEW which contains all columns that were changed before the update, there is a corresponding variable OLD which is the
information after the update. NEW.PRODUCTNAME means the name of the product that was updated.

Since execution stops when an error occurs, the execution of the insert will stop if the result of the IF THEN statement evaluates to true,
and we will receive the error message. If the condition is false, nothing happens and the execution of the insert statement will be executed normally.

In this case, the advantage of the trigger is that we are able to log updats even if the user has direct SQL access
to that table, something that procedures will not allow.
