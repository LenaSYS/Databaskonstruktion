<html>
<body>
<h3>Table With Hidden Input Detail Form</h3>
	
<?php

		$pdo = new PDO('mysql:dbname=a00leifo;host=localhost', 'myusername', 'mypassword');
	
		if(isset($_POST['ModCustno'])){
				$querystring='UPDATE CUSTOMER SET CUSTNO=:CUSTNO, SSN=:SSN, NAME=:NAME, REGDATE=:REGDATE WHERE CUSTNO=:MODCUSTNO;';
				$stmt = $pdo->prepare($querystring);
				$stmt->bindParam(':CUSTNO', $_POST['CUSTNO']);
				$stmt->bindParam(':SSN', $_POST['SSN']);
				$stmt->bindParam(':NAME', $_POST['NAME']);
				$stmt->bindParam(':REGDATE', $_POST['REGDATE']);
				$stmt->bindParam(':MODCUSTNO', $_POST['ModCustno']);			
				$stmt->execute();				
		}else if(isset($_POST['EdCustno'])){
				echo "<div style='border:1px solid outset #888;border-radius:4px;background-color:#eee;'>";
				echo "<form action='PHP_Example12_HiddenFormShow.php' method='post' >";
						echo "<input type='hidden' name='ModCustno' value='".$_POST['EdCustno']."'>";
						echo "Custno:<input type='text' name='CUSTNO' value='".$_POST['EdCustno']."'><br>";
						echo "SSN:<input type='text' name='SSN' value='".$_POST['SSN']."'><br>";
						echo "Name:<input type='text' name='NAME' value='".$_POST['NAME']."'><br>";
						echo "Regdate:<input type='text' name='REGDATE' value='".$_POST['REGDATE']."'><br>";
						echo "<input type='submit' value='Save' >";			
				echo "</form>";
				echo "</div>";
		}
	
		echo "<table style='border-collapse:collapse;'>";
		foreach($pdo->query("SELECT * FROM CUSTOMER") as $row){
			if(isset($_POST['EdCustno'])){
					if($_POST['EdCustno']==$row['CUSTNO']){
								echo "<tr style='border:4px solid lightgreen;background-color:#448;color:#fff;box-shadow:2px 2px 2px #000;'>";
					}else{
								echo "<tr>";
					}
			}
			
			echo "<td>".$row['CUSTNO']."</td>";					
			echo "<td>".$row['SSN']."</td>";
			echo "<td>".$row['NAME']."</td>";			
			echo "<td>".$row['REGDATE']."</td>";
			echo "<td>";
				echo "<form action='PHP_Example12_HiddenFormShow.php' method='post' >";
					echo "<input type='hidden' name='EdCustno' value='".$row['CUSTNO']."'>";
					echo "<input type='hidden' name='SSN' value='".$row['SSN']."'>";			
					echo "<input type='hidden' name='NAME' value='".$row['NAME']."'>";			
					echo "<input type='hidden' name='REGDATE' value='".$row['REGDATE']."'>";			
					echo "<input type='submit' value='Edit' >";			
				echo "</form>";
			echo "</td>";
			echo "</tr>";
		}
		echo "</table>"; 
		
?>

</body>
</html>