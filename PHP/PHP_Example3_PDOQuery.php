<html>
<body>
<h3>Get Customers</h3>
<pre>
<?php
		
		$pdo = new PDO('mysql:dbname=a00leifo;host=localhost', 'myusername', 'mypassword');
		$pdo->setAttribute( PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION );
		
		foreach($pdo->query( 'SELECT * FROM CUSTOMER;' ) as $row){
			print_r($row);			
		}
		
?>
</pre>
</body>
</html>

