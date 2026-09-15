### Overview

This example shows how to show data in a form using a select query and a foreach statement. We add data into the form using the select tag.

### Introduction

We execute a SELECT query, and iterate over the results from that query using foreach.
We start by making a form with a select tag. Each select tag will represent one combo box (also known as an option box or a dropdown). 

Thw difference is that we use a like query insstead of a straight match using the = operator.

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