### Overview
This example contains an example of the use of triggers. A trigger is a stored procedure that is fired automatically by some update
of the database. Triggers perform actions in the database without the need for intervention by the user.


### Introduction

One use for triggers has to do with optimization of views. A view that does some complicated computation such as a sum of all purchases per category (requires GROUP BY).
Such a view can simplify or specialize the code, but, execution of that view may be very slow.

~~~
SELECT PRODUCTNAME,SUM(COST)
FROM INVOICEROW,PRODUCT
WHERE INVOICEROW.PRODUCT=PRODUCT.PRODUCTCODE
GROUP BY PRODUCTNAME;
~~~


One solution to this is to create a table that contains that sum, and each time the base table is updated, we compute a new sum for that 
category alone. Reading the information is extremely fast, since we can read the sum from that table directly.


### This Example

First we create the table that we want to store the sums in ===Procedures_Example7_UpdateViewTable.sql,1,4,(rows 1-4)===. 


The trigger that executes BEFORE INSERT first deletes the corresponding row in the sums table ===Procedures_Example7_UpdateViewTable.sql,12,12,(row 12)=== and stores a new updated sum ===Procedures_Example7_UpdateViewTable.sql,13,13,(row 13)===.


In this case the trigger helps us to compute a very complicated computation piece by piece whenever the data is updated
rather than computing the sum every time we want to know the information.
