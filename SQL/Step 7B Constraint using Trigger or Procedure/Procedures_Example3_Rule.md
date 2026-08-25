### Overview
This example contains an example of the use of stored procedures. A stored procedure is the same thing as a function or method in an ordinary programming language, but it is stored in the database itself. By using stored procedures we gain a slight bit of performance but also gain control over exactly which code that is run in the database. If we use stored procedures it is more difficult to compromise the security of the database.


### Introduction
Stored procedures are often used to check rules. This is an alternative to using a view or a trigger for checking a rule. The advantage of using a procedure is more granular control of what actually happens and more advanced programming options.


### This Example
This example has an IF ELSE statement ===Procedures_Example3_Rule.sql,8,13,(rows 8-13)=== (that has the same condition as the check constraint that we want to implement).


On row 9 we use a SELECT that makes use of a column that does not exist.


~~~
SELECT COST_MUST_BE_ABOVE_ZERO FROM INVOICEROW;
~~~


In order to generate an error message since most older versions of MySQL does not support the signal statement which is intended for the purpose of generating error messages. If you are running MySQL 5.2 or later you can substitute that select statement for a SIGNAL statement (!!!https://dev.mysql.com/doc/refman/5.5/en/signal.html,see MySQL documentation!!!).


If the condition is false ===Procedures_Example3_Rule.sql,12,12,(row 12)=== we update the data just like an ordinary procedure (like in trigger example 2), The advantage of using the procedure is that we can guarantee that the code that is run is exactly the code in the procedure, which may be an advantage from a security standpoint, given that the user does not have access to the base table directly. The procedure also allows us to group a set of operations into the same procedure. 