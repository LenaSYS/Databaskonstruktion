### Overview

This example shows how to show data in a form using a select query and a foreach statement. We add data into the form using the select tag.


### Introduction

We execute a SELECT query, and iterate over the results from that query using foreach.
We start by making a form with a <select> tag. Each select tag will represent one combo box (also known as an option box or a dropdown). 

For each of the rows returned from the query we add one option tag using the echo statement. We use $row['NAME'] to read from the NAME column in the query result.
__Note:__ A very important feature is that we can show the __name__ in the dropdown but send __ssn__ to the response page.

Sorting of paramount importance for dropdowns since unsorted dropdowns get confusing with even small amounts of data.

```php
    // We use order by in order to sort the dropdown. A non-sorted dropdown is a bad user interface.		
		foreach($pdo->query( 'SELECT * FROM CUSTOMER ORDER BY NAME;' ) as $row){
			echo '<option value="'.$row['SSN'].'">';
			echo $row['NAME'];			
			echo '</option>';
		}		
```

The option tag makes life easier for the user than the text box, we can show the user something that is easy to read such as a product name but the application will work with some other value, such as a product code. 

In the response page given by the form tag, we use a prepared statement which is filled by the SSN value from the post. The main difference between this example and the previous ones, is that
this examples makes use of prepared statements that contain one or more placeholders. In a prepare statement the query has parameters (e.g. :SSN), that we fill out using the bindParam statement.

The main advantage is that the code that uses prepared statements is much __more secure__, and the input does not need to be sanitized. The parameter is filled with the text and even if we add potentially harmful characters such as quotes, the binding ensures that the contents of the variable is inserted verbatim.

```php
$querystring='SELECT * FROM CUSTOMER WHERE SSN=:SSN';

$stmt = $pdo->prepare($querystring);
$stmt->bindParam(':SSN', $_POST['SSN']);
$stmt->execute();
```
The if isset is especially important in self referencing applications but is also necessary in multiple page applications.

```php
if(isset($_POST['SSN'])){
```

We then generate the table using a foreach with one <tr> generated for each row in the result of the search query.

```php
foreach($stmt as $key => $row){
  echo "<tr>";
  echo "<td>".$row['CUSTNO']."</td>";      
  echo "<td>".$row['NAME']."</td>";      
  echo "<td>".$row['REGDATE']."</td>";
  echo "</tr>";
}
```