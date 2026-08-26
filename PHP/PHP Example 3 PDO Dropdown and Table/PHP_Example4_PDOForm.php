<html>
<body>
<h3>Constructing Option Box</h3>
<form action="PHP_Example4_PDOForm.php" method="post">
	<select size='1' name='SSN'>
<?php		
		echo "<div>";
		print_r($_POST);
		echo "</div>";

		$pdo = new PDO('mysql:dbname=a00leifo;host=localhost', 'myusername', 'mypassword');
				
		foreach($pdo->query( 'SELECT * FROM CUSTOMER ORDER BY NAME;' ) as $row){
			echo '<option value="'.$row['SSN'].'">';
			echo $row['NAME'];			
			echo '</option>';
		}		
?>
   </select>
   <input type="submit" value="Send">
   <input type="reset">
</form>
</body>
</html>

