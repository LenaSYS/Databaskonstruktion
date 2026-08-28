### Overview
This example shows how to use the error handling of PDO to present an error message for duplicate primary key error message.


The try catch construct (===PHP_Example10_PDOError.php,25,33,rows 25-33===) allows us to react to errors that happen in the try block. Since the execute statement is the only statement in the try block we can be sure that the error is an SQL error.
