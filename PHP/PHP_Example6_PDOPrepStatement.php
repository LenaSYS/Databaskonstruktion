<html>
<body>

<form action="PHP_Example6_PDOPrepStatement.php" method="post">
	Custno: <input type="text" name="Custno" /><br>
	Name: <input type="text" name="Name" /><br>
	SSN: <input type="text" name="SSN" /><br>
	Regdate: <input type="text" name="Regdate" /><br>
	<input type="submit" />
</form> 
<table>

<?php
		$pdo = new PDO('mysql:dbname=a00leifo;host=localhost', 'myusername', 'mypassword');
		$pdo->setAttribute( PDO::ATTR_ERRMODE, PDO::ERRMODE_WARNING );

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
		
		// Read all customers
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

