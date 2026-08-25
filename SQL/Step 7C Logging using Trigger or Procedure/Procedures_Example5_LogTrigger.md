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

The trigger is nearly identical to the procedure, programming wise. We first specify which event we connect the trigger to (in this case AFTER INSERT, ===Procedures_Example5_LogTrigger.sql,6,6,row 6===).
After that we have the code for the trigger ===Procedures_Example5_LogTrigger.sql,8,9,(rows 8-9)===. 

The only main difference is that we have a variable called NEW which contains all columns that were changed before the update, there is a corresponding variable OLD which is the
information after the update. NEW.PRODUCTNAME means the name of the product that was updated.


In this case, the advantage of the trigger is that we are able to log updats even if the user has direct SQL access
to that table, something that procedures will not allow.
