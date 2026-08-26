### Overview
This example shows how to query the database using prepared statements.


### Introduction

This example makes does a simple query link. The main difference between this example and the previous ones, is that
this examples makes use of query links. Instead of generating a table or a form we generate a link (===PHP_Example7_PDOPrepStatement.php,11,11,row 11===).


The code generates the query using the questionmark and an equals sign. Additional parameters can be added using an ampersand. In this case we only send the SSN of the customer.
A function called urlencode must be used since it guarantees that all special characters that are not legal in an url are changed. In the result application (the next example) we use urldecode to retrieve the string.
