### Overview
This example shows how to query the database using prepared statements.


### Introduction

This example does a simple insert statement (===PHP_Example6_PDOPrepStatement.php,17,26,rows 17-26===). The main difference between this example and the previous ones, is that
this examples makes use of prepared statements that contain one or more placeholders. In a prepare statement the query has parameters (e.g. :CUSTNO), that we fill out using the bindParam statement.


The main advantage is that the code that uses prepared statements is much more secure, and the input does not need to be sanitized. The parameter is filled with the text and even if we add potentially harmful characters such as quotes, the binding ensures that the contents of the variable is inserted verbatim.


We then use an ordinary select query to show a table containing the newly inserted element (===PHP_Example6_PDOPrepStatement.php,28,36,rows 28-36===)

