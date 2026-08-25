### Overview
This example contains an example of the use of triggers. A trigger is a stored procedure that is fired automatically by some update
of the database. Triggers perform actions in the database without the need for intervention by the user.


### Introduction

One very common use for triggers is rule checking. The advantage is that the checking is transparent, happens
without any change of the application, and that it works regardless of which code that updated the information.


### This Example Database

The trigger is nearly identical to the rule checking procedure, programming wise. We first specify which event we connect the trigger to (in this case BEFORE INSERT, ===Procedures_Example6_CheckRule.sql,6,6,row 6===).
After that we have the code for the trigger ===Procedures_Example6_CheckRule.sql,9,12,(rows 9-12)===. 


The only main difference compared to the procedure rule code is that we use update instead of select as the error generator and have access to a variable called 
NEW which contains all columns that were changed before the update, there is a corresponding variable OLD which is the
information after the update. NEW.PRODUCTNAME means the name of the product that was updated.


Since execution stops when an error occurs, the execution of the insert will stop if the result of the IF THEN statement on ===Procedures_Example6_CheckRule.sql,9,9,row 9=== evaluates to true,
and we will receive the error message. If the condition is false, nothing happens and the execution of the insert statement will be executed normally.


In this case, the advantage of the trigger is that we are able to log updats even if the user has direct SQL access
to that table, something that procedures will not allow.
