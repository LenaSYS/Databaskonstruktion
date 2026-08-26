<html>
<body>
<h3>Response Page</h3>

<table border='1'>

<?php
		
		$pdo = new PDO('mysql:dbname=a00leifo;host=localhost', 'myusername', 'mypassword');

		foreach($pdo->query("SELECT * FROM CUSTOMER") as $row){
			echo "<tr>";
			echo "<td>".$row['CUSTNO']."</td>";			
			echo "<td>".$row['NAME']."</td>";			
			echo "<td>".$row['REGDATE']."</td>";
			echo "</tr>";
		}		
?>

</table>
</body>
</html>

