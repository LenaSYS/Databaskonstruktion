### Overview
This example contains an example of the use of Indexing to optimize search queries. 
By using indexing, we can make certain search queries many times faster.

### Introduction
An index is created for each primary key or unique column (candidate key) in the database. This makes join queries faster than they would otherwise be. 


For any other columns or combinations of columns that we want to optimize searching for, we need to explicitly define the indices that we want. 


An index that is not used affects performance negatively and it is therefore very important that we only create indices that are useful.


### Indexing for the Example Database

In this database it there are a few options for indexing. One query that is very likely to be used often is the query on ===Example7_Indexing.sql,1,3,(rows 1-3)=== which returns all the invoices for a certain customer.

~~~
SELECT * FROM INVOICEROW WHERE custno="XXX"
~~~

Since customer is not the primary key, this makes that query a very good candidate for indexing. 


We can specify a search order for the index, and we can specify if we want the index to use a binary tree or a hash for retrieving the information. A hash may be faster, but does work best with unique information.


---

One important category of indexing optimization that is often forgotten is one that gives great improvements of performance, the ordered query ===Example7_Indexing.sql,5,7,(rows 5-7)===. 

~~~
SELECT * FROM CUSTOMER ORDER BY NAME;
~~~

Just by adding order by to a sql statement, we may often reduce the performance of that query by a large amount. Such ordering is very common since it makes the data much easier to read for the user. By adding the corresponding index, we gain a lot of performance.


In order to help remembering which query it is that we have optimized the database for, it is a good idea to add that query as a comment.
