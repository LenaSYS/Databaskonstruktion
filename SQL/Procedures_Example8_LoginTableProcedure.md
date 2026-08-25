### Overview
This example contains an example of the use of procedures for password handling. It is possible to use procedures to check passwords, which may be safer if the base tables are protected using privileges so that only the procedure can read or write the passwords.


### Introduction

We add a password column (called PASSW) to the customer table. This is used to authenticate each user.


### This Example

The password is created using the PASSWORD function (===Procedures_Example8_LoginTableProcedure.sql,8,9,rows 8-9=== and ===Procedures_Example8_LoginTableProcedure.sql,21,22,rows 21-22===). We then either insert that value to the table (first procedure) or compare it to the stored value (second procedure) using an IF THEN statement.


Since we can make sure that the password can not be read fom the database even if the application has been breeched, this can in some cases be a good solution. But the PASSWORD function in MySQL may over time not be cryptographically secure enough.