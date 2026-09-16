<html>
<body>
<table>

<?php
		$pdo = new PDO('mysql:host=mysql;port=3306;dbname=a00leifo', 'username', 'hemligtlösen');
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

