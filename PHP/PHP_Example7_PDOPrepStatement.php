<html>
<body>
<table>

<?php	
		$pdo = new PDO('mysql:dbname=a00leifo;host=localhost', 'myusername', 'mypassword');
		$pdo->setAttribute( PDO::ATTR_ERRMODE, PDO::ERRMODE_WARNING );

		foreach($pdo->query( 'SELECT * FROM CUSTOMER;' ) as $row){
			echo "<tr><td>";
			echo "<a href='PHP_Example8_PDOQueryLink.php?SSN=".urlencode($row['SSN'])."'>Customer: ".$row['SSN']."</a>";
			echo "</td></tr>";	
		}
?>

</table>
</body>
</html>

