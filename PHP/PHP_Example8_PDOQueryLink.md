### Overview

This example shows how to return a result from a query using a html query link.


### Introduction

This example makes  a reply from a query sent using a html query link. The main difference between this example and the previous ones, is that
this examples makes use of query links. Instead of using POST ($_POST) to get the result from a form, we use GET ($_GET) to get the result from the link (===PHP_Example8_PDOQueryLink.php,9,9,row 9=== ===PHP_Example8_PDOQueryLink.php,14,14,row 14===).


First we must check if the variable has been set by using the isset function. The only change necessary for retrieving information from a html link is thus to change to $_GET. The query (===PHP_Example8_PDOQueryLink.php,11,23,rows 11-23===) then uses bindParam to connect the GET variable from the link to the SELECT Query.


The preview for example 8 is what happens when one navigates the link in example 7.