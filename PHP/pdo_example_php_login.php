<html>
<body>
<pre>
<?php
	
print_r($_POST);
 
if(isset($_POST['login'])&&isset($_POST['password'])){
		try{
				$conn = new PDO("mysql:host=localhost;dbname=a00leifo", 'myusername', 'mypassword');

				// set the PDO error mode to exception
				$conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
				
				// Now we check if we have correct login and password according to customer table
				$sql = 'SELECT * FROM CUSTOMER WHERE PASSW=:PASSW;';
				
				$stmt = $conn->prepare($sql, array(PDO::ATTR_CURSOR => PDO::CURSOR_SCROLL));
				$stmt->bindParam(':PASSW', $_POST['password']);
				$stmt->execute();
				
				if($stmt->rowCount()>0){
						echo "\n\nCustomer login successful";
				}else{
						echo "Customer login failed.";
						echo "<script>setTimeout(function(){ location.href='pdo_example_php_login_form.html' }, 2000);</script>";
				
				}			
				
		}catch(PDOException $e){
				echo "Connection failed: " . $e->getMessage();
				echo "<script>setTimeout(function(){ location.href='pdo_example_php_login_form.html' }, 2000);</script>";
		}
}else{
		echo "\n\nYou must provide login name and password";
		echo "<script>setTimeout(function(){ location.href='pdo_example_php_login_form.html' }, 2000);</script>";	
}

?>
</pre>
</body>
</html>