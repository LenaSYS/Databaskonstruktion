### Overview
This example contains an example of the use of views to simplify search queries. 


By using a view we can make querying simpler or nearer to the usage scenario of the application, whith privileges that match that scenario.


### Introduction

A VIEW is a virtual table, a table that does not exist in the database, but appears to exist from the viewpoint of the server or the user that is making queries.


For the server there is no difference between a view and a base table. Views can be queried like any other table.


### This Example Database

There are different usage scenarios for views. The first such usage scenario is for simplification. Some queries are very complex, and therefore more error prone than others. Views can be used to create simpler queries that do not require as complex queries.


In this example database it is likely that there will be some query that will want to see all of the invoices (both paid and unpaid) for a customer. This requires a UNION statement that makes a new table by combining rows from one or more tables.


In that case, the corresponding query will be quite complex, even for this very simple database. We therefore construct a view that will hide this complexity from the user. 


If the user wants to retrieve the information about a certain customer and all his invoices, this is now possible using this much simpler view. 

~~~
SELECT * FROM CUSTOMERINVOICE
~~~

