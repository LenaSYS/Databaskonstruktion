### Overview
This example contains an example of the use of Views to simplify search queries. By using views we can make querying simpler or nearer to the usage scenario of the application, whith privileges that match that scenario.


### Introduction
A VIEW is a virtual table, a table that does not exist in the database, but appears to exist from the viewpoint of the server or the user that is making queries.


### This database
There are different uses for views. The second such usage scenario is for specialization. The applications may not need the same exact information. Views allow us to make a set of tables that is specific for each application/usage scenario.


In this example database there is an economics department that needs to see the comments for each of the companies but not any other information. By making this view we can give a user in the economics department the information about the companies that is relevant to that user and no other information.


This type of specialization is very closely related to the following section on __privileges and views__. We can help the specialization effort by tuning the privileges so that the economics application does not have acces to the base table but only the view.


This type of specialization is also similar to simplification since we often make the queries simpler by specializing the query for that specific scenario. 


~~~
SELECT COMMENT FROM COMPANYCOMMENTS
WHERE COMPANYNAME="PolyzPy Oy"
~~~