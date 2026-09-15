<html>
<body>
<h3>Constructing Option Box</h3>
<form action="PHP_Example_PDOSearch.php" method="post">
	<select size='1' name='SSN'>
<?php		
		$pdo = new PDO('mysql:dbname=a00leifo;host=127.0.0.1;port=3306', 'myusername', 'mypassword');

    // We use order by in order to sort the dropdown. A non-sorted dropdown is a bad user interface.		
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

