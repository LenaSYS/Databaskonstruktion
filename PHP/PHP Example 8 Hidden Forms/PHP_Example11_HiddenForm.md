### Overview
This example shows how to use hidden elements to add interactivity in forms.


### Introduction

This example makes a table using div elements (===PHP_Example11_HiddenForm.php,17,27,rows 17-27===). 

The reason for using div and flex instead of using table tags is that we are not allowed to make form tags inside tr/td/table tags which would result in broken markup if html tables were used. One workaround is to use div tags instead.

Each table row contains a form that contains a hidden customer number element and a customer name input element (===PHP_Example11_HiddenForm.php,21,22,rows 21-22===).

If a ModCustno inout has been sent we then execute the query using a prepared statement (===PHP_Example11_HiddenForm.php,9,15,rows 9-15===). 

We then make use of a prepared statement that contains one or more placeholders. In this case, the parameters concist of the customer number and the new updated customer name.


