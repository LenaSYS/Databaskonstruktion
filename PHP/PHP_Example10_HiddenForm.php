<html>
<body>
<h3>Table With Hidden Form</h3>
	
<?php

		echo "<pre>";
		print_r($_POST);
		echo "</pre>";
	
		$pdo = new PDO('mysql:dbname=a00leifo;host=localhost', 'myusername', 'mypassword');
	
		foreach($pdo->query("SELECT * FROM CUSTOMER") as $row){
			echo "<form style='margin:0;display: flex;' action='PHP_Example10_HiddenForm.php' method='post' >";
			echo "<span style='flex: 4;border: 1px solid red;'>".$row['CUSTNO']."</span>";			
			echo "<span style='flex: 4;border: 1px solid red;'>";
				echo "<input type='text' name='Custname' value='".$row['NAME']."'>";
				echo "<input type='hidden' name='Custno' value='".$row['CUSTNO']."'>";
			echo "</span>";			
			echo "<span style='flex: 4;border: 1px solid red;'>".$row['REGDATE']."</span>";
			echo "<span style='flex: 4;border: 1px solid red;'><input type='submit' value='Save!' /></span>";			
			echo "</form>";
		}
		
?>

</body>
</html>