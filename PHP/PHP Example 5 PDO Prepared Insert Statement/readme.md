### Overview
This example shows how to query the database using prepared statements.


### Introduction

This example does a simple insert statement. The main difference between this example and the previous ones, is that
this examples makes use of prepared statements that contain one or more placeholders. In a prepare statement the query has parameters (e.g. :CUSTNO), that we fill out using the bindParam statement.

We use the isset to make sure that there is data to insert. This is especiall important for self referencing pages but also important for form response pages.

```php
		// Only make insert if there is a form post to process
		if(isset($_POST['Custno'])){
				$querystring='INSERT INTO CUSTOMER (CUSTNO,SSN,NAME,REGDATE) VALUES(:CUSTNO,:SSN,:NAME,:REGDATE);';
				$stmt = $pdo->prepare($querystring);
				$stmt->bindParam(':CUSTNO', $_POST['Custno']);
				$stmt->bindParam(':SSN', $_POST['SSN']);
				$stmt->bindParam(':NAME', $_POST['Name']);
				$stmt->bindParam(':REGDATE', $_POST['Regdate']);
				$stmt->execute();
		}
```


The main advantage is that the code that uses prepared statements is much more secure, and the input does not need to be sanitized. The parameter is filled with the text and even if we add potentially harmful characters such as quotes, the binding ensures that the contents of the variable is inserted verbatim.


We then use an ordinary select query to show a table containing the newly inserted element (===PHP_Example6_PDOPrepStatement.php,28,36,rows 28-36===)

