### Overview
This example makes use vertical denormalization by splitting the table vertically into two parts, of which one part receives much more queries than the other.


### Vertical Denormalization
Vertical denormalization is possible if there is some value that affects the usage frequency of the table. 


In the case of many types of invoice databases, the payment date of the invoice is such a value. 


The unpiad invoices are used much more frequently than a paid invoice. 


If the table is thus split into two tables, one for paid invoices (which will be smaller and therefore faster) and one for the unpaid invoices, the performance will increase as we need to work with less information most of the time.


Technically this is done by duplicating the invoice table into two tables, paid and unpaid invoices. 


The only difference is the name of the table ===Example5_Vertical.sql,43,57,(rows 43-57)===.
