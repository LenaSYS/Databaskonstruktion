<html>
<body>
<h3>Query Parameter</h3>

<form action="PHP_Example9_PDOFetch.php" method="post">
	 DATEPAID:<input type="text" name="datepaid">
   <input type="submit" value="Send">
   <input type="reset">
</form>

<?php
		
		$pdo = new PDO('mysql:dbname=a00leifo;host=localhost', 'myusername', 'mypassword');
		$pdo->setAttribute( PDO::ATTR_ERRMODE, PDO::ERRMODE_WARNING );
		
		if(isset($_POST['datepaid'])){
				$datepaid=$_POST['datepaid'];
				$sql = 'SELECT * FROM COMPANY,INVOICEROW,PRODUCT WHERE COMPANY.COMPANYCODE=INVOICEROW.COMPANY AND PRODUCTCODE=INVOICEROW.PRODUCT AND DATEPAID<:DATEPAID;';
				
				$stmt = $pdo->prepare($sql, array(PDO::ATTR_CURSOR => PDO::CURSOR_SCROLL));
				$stmt->bindParam(':DATEPAID', $datepaid);
				$stmt->execute();
				
				foreach($stmt as $key => $row){
						echo "<div>";
						echo $row['COMPANYNAME']." ".$row['PRODUCTNAME']." ".$row['COST'];
						echo "</div>";
				}
		}

?>


</body>
</html>