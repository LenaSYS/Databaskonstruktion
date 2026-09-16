<html>
<body>
<table>

<?php	
		$pdo = new PDO('mysql:host=mysql;port=3306;dbname=a00leifo', 'username', 'hemligtlösen');
		$pdo->setAttribute( PDO::ATTR_ERRMODE, PDO::ERRMODE_WARNING );

		foreach($pdo->query( 'SELECT * FROM CUSTOMER;' ) as $row){
			echo "<tr><td>";
			echo "<a href='PHP_Example_PDOSearch.php?SSN=".urlencode($row['SSN'])."'>Customer: ".$row['NAME']."</a>";
			echo "</td></tr>";	
		}
?>

</table>
</body>
</html>

