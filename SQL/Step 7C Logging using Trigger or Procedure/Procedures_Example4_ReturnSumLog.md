### Overview

This example contains an example of the use of stored procedures. A stored procedure is the same thing as a function or method in an ordinary programming language,
but it is stored in the database itself. By using stored procedures we gain a slight bit of performance but also gain control over exactly which code that is run in
the database. If we use stored procedures it is more difficult to compromise the security of the database.


### Introduction

Stored procedures are some times used for logging. Logging is more commonly done with triggers, since the logging
will be more hidden that way. However most servers do not allow logging of select statements, therefore using a procedures
for this purpose is the only available solution that will guarantee that the transaction is logged.


A log is a table that stores the history of some other table. Commonly changed values of the corresponding table are stored 
(often the whole table) together with user accounts, change dates and other relevant statistics.


Most commonly users do ___not___ have access to log tables (as they could see the evidence of their own tampering).
Log tables make no sense at all if ___anyone___ has delete or update privileges of the log.


### This Example Database

First we must create the logging table ===Procedures_Example4_ReturnSumLog.sql,2,9,(rows 2-9)===. If we want to completely recreate the information, at the time of trigger execution,
we must stor ALL information in the corresponding table row or rows. If less information is necessary we create a smaller logging table.


In this case we store only the operation, the name of the product that was searched for and statistics on date, time and user account.
The atuo_increment key is useful since the same invoice may be searched many times. That way we do not need to worry about the
uniqueness of the log entries, as this is handled automatically.


Note that in this case, user account will probably be an application (i.e. economysystem) rather than a user account,
if we want to log exactly which user that performed the search, we must pass this information from the applicartion
to the procedure using parameters.


In this example the logging is done first ===Procedures_Example4_ReturnSumLog.sql,18,18,(row 18)=== since execution may terminate if there is something wrong with the select statement.


In this case, the advantage of the procedure is that we are able to log select statements, something that is not possible
using other means.
