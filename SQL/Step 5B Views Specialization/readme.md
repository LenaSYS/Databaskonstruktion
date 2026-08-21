### Overview

This example contains an example of the use of Views to simplify search queries. By using views we can make querying simpler or nearer to the usage scenario of the application, whith privileges that match that scenario.

### Introduction

A VIEW is a virtual table that does not exist in the database, but appears to exist from the viewpoint of the server. For the server there is no difference between a view and a base table. Views can be queried like any other table.

### This Example Database

There are different uses for views. The second such usage scenario is for specialization. Different applications or different parts of an application may not need identical information. A VIEW allow us to make a set of tables that is specific for each application/usage scenario.

In this example scenario there is an economics department that needs statistics on the average cost for each product. 

This is a simple grouping query that makes use of the AVG function. By making a view, we can make sure that the application receives information that is tailored for the needs of that application. This type of specialization is very closely related to the following section on privileges and views. 

We can make the specialization effort even more powerful by tuning the privileges so that the economics application does not have acces to the base table but only the view. 

```sql
CREATE VIEW PRODUCTSTATISTICS AS
SELECT PRODUCTNAME,AVG(COST) AS AVGCOST
FROM INVOICEROW,PRODUCT
WHERE INVOICEROW.PRODUCT=PRODUCT.PRODUCTCODE
GROUP BY PRODUCT;
```

Another use case is to create a view for showing some kind of information for example we might want to se all comments in the database connected to companies.

```sql
CREATE VIEW COMPANYCOMMENTS AS                                                                                                                        
SELECT COMPANYNAME,COMMENT FROM COMPANY,INVOICEROW,INVOICEROWCOMMENT                                                                                  
WHERE COMPANY.COMPANYCODE=INVOICEROW.COMPANY AND INVOICEROWCOMMENT.INVOICENO=INVOICEROW.INVOICENO AND INVOICEROWCOMMENT.NUMBER=INVOICEROW.NUMBER;     
```

As previously stated this specialization can also be viewed as a simplification as we are simplifiying the join condition. But normally simplification views are commonly have even more complex conditions or other operators.