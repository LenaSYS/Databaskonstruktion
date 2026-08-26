### Overview

This example shows how to show data in a form using a select query and a foreach statement. We add data into the form using the select tag.


### Introduction

We execute a SELECT query, and iterate over the results from that query using foreach (===PHP_Example4_PDOForm.php,13,17,rows 13-17===).
We start by making a form with a <select> tag (===PHP_Example4_PDOForm.php,5,5,row 5=== and ===PHP_Example4_PDOForm.php,19,19,row 19===). Each select tag will represent one combo box (also known as an option box). 
For each of the rows returned from the query we add one option tag using the echo statement. We use $row['NAME'] to read from the NAME (===PHP_Example4_PDOForm.php,15,15,row 15===) column in the query result.


The option tag makes life easier for the user than the text box, we can show the user something that is easy to read such as a product name but the application will work with some other value, such as a product code. If the select query uses the ORDER BY statement, the options in the list can be sorted.

