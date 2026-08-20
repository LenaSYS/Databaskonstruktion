### Overview

This example contains an example of the use of Views to control database privileges. By using views we can make sure that the user does not have access to any information that the user is not supposed to have access to. Even if the user can exploit a loophole in the software, if the database has not been compromized, the privileges will make sure that the information is secure.


### Introduction

A VIEW is a virtual table, a table that does not exist in the database, but appears to exist from the viewpoint of the server or the user that is making queries.


### This Example Database

By making users, we can control the privileges. If we want to control the privileges of each user individually, we can create accounts for each user, but if it is enough to control the privileges of each application, we can make an account for each application. 


In this case, we create an account using CREATE USER for the economics system ===Example11_Rights.sql,3,3,(row 3)===.


There are separate privileges for each of the main commands of SQL and each table or view can have a distinct set of privileges. If we want the application to have access to all of the information in a table we can give privileges directly to a base table. In this example we want the user to be able to read (we GRANT SELECT privileges) all the information about the companies ===Example11_Rights.sql,6,6,(row 6)===.


However, when it comes to the customer table, we want the economics application to be able to read all information about the customers except for the password for that user. Therefore we create a view called ECONOMYCUSTOMERS ===Example11_Rights.sql,9,9,(row 9)=== that excludes the password column from the result.


We then give the user select privileges to the ECONOMYCUSTOMERS view ===Example11_Rights.sql,12,12,(row 12)=== but not to the base table. The economy application is thus not able to read the user passwords even if a user finds an exploit that allows the execution of arbitrary queries. 


As can be seen below, the economy system can retrieve the ECONOMYCUSTOMERS view but not the base table that it is based on.

~~~
mysql> select * from CUSTOMERS;

ERROR 1142 (42000): SELECT command denied to user 'economysystem'
~~~