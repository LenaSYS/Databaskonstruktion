### Overview

This example shows how to show data in a form using a select query and a foreach statement. We add data into the form using the select tag.


### Introduction

We execute a SELECT query, and iterate over the results from that query using foreach.
We start by making a table with a <table> tag. Each row in the response to the query will be a row in the on-screen table.

For each of the rows returned from the query we add one tr tag using the echo statement. We use $row['NAME'] to read from the NAME column in the query result and $row['NAME'] for the link url.
__Note:__ A very important feature is that we can show the __name__ in the link anchor but send __ssn__ to the response page.

```php
		foreach($pdo->query( 'SELECT * FROM CUSTOMER;' ) as $row){
			echo "<tr><td>";
			echo "<a href='PHP_Example8_PDOSearch.php?SSN=".urlencode($row['SSN'])."'>Customer: ".$row['NAME']."</a>";
			echo "</td></tr>";	
		}
```
The only difference between the link response and the dropdown response is that we use $_GET instead of $_POST.

In the response page given by the form tag, we use a prepared statement which is filled by the SSN value from the post. The main difference between this example and the previous ones, is that
this examples makes use of prepared statements that contain one or more placeholders. In a prepare statement the query has parameters (e.g. :SSN), that we fill out using the bindParam statement.

The main advantage is that the code that uses prepared statements is much __more secure__, and the input does not need to be sanitized. The parameter is filled with the text and even if we add potentially harmful characters such as quotes, the binding ensures that the contents of the variable is inserted verbatim.

```php
$querystring='SELECT * FROM CUSTOMER WHERE SSN=:SSN';

$stmt = $pdo->prepare($querystring);
$stmt->bindParam(':SSN', $_GET['SSN']);
$stmt->execute();
```
The if isset is especially important in self referencing applications but is also necessary in multiple page applications.

```php
if(isset($_GET['SSN'])){
```

We then generate the table using a foreach with one <tr> generated for each row in the result of the search query. This response is exactly the same as for the dropdown.

```php
foreach($stmt as $key => $row){
  echo "<tr>";
  echo "<td>".$row['CUSTNO']."</td>";      
  echo "<td>".$row['NAME']."</td>";      
  echo "<td>".$row['REGDATE']."</td>";
  echo "</tr>";
}
```