<html>
<body>
<table>

<?php
		$pdo = new PDO('mysql:dbname=a00leifo;host=127.0.0.1;port=3306', 'myusername', 'mypassword');
		$pdo->setAttribute( PDO::ATTR_ERRMODE, PDO::ERRMODE_WARNING );
		
		// Read all customers to a table
		foreach($pdo->query( 'SELECT * FROM CUSTOMER;' ) as $row){
			echo "<tr>";
			echo "<td>".$row['CUSTNO']."</td>";
			echo "<td>".$row['SSN']."</td>";
			echo "<td>".$row['NAME']."</td>";
			echo "<td>".$row['REGDATE']."</td>";
			echo "</tr>";	
		}
?>
</table>
</body>
</html>

