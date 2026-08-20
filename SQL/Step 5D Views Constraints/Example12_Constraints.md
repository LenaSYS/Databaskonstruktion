### Overview
This example contains an example of the use of Views to execute check constraints. There are various ways to enforce constraints in an SQL database. 

One way to do this is by using a view. The application inserts information into the view in the same way as it would into a base table. The difference is that the database will only allow inserts that would be visible in the view. This is done using the with check option keyword.


### Introduction

A VIEW is a virtual table, a table that does not exist in the database, but appears to exist from the viewpoint of the server or the user that is making queries.


### This database

We create a VIEW that is __identical__ to the base table, and we add the constraint to the where clause of the view ===Example12_Constraints.sql,1,1,(row 1)===. 


The only thing that we need to do to enforce the check constraint is to use the view instead of the base table. If we combine this with the use of privileges (like in the previous example) we can make sure that it is impossible for the application to insert information into the base table by not giving GRANT INSERT on the base table but only to the view ===Example12_Constraints.sql,3,3,(row 3)===.


In the example input below it is possible to see that it is possible to insert erroneous information into the base table but not into the view.  If we do not give insert privileges on the base table we thereby make sure that the SSN must be correctly formed.
