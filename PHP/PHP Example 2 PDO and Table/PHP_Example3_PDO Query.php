<html>
<body>
<h3>Get All Customers using Query</h3>
<pre>
<?php

		// Connect to database and iterate over each row of the result of a procedure call
		$pdo = new PDO('mysql:dbname=a00leifo;host=localhost', 'myusername', 'mypassword');
		$pdo->setAttribute( PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION );
		
		foreach($pdo->query( 'SELECT * FROM CUSTOMER;' ) as $row){
			print_r($row);			
		}
		
?>
</pre>
</body>
</html>

