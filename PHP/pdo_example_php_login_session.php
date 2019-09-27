<?php
session_start();
?>
<html>
<body>
<pre>
<?php

print_r($_POST);
print_r($_SESSION);
	
if((isset($_POST['login'])&&isset($_POST['password']))||(isset($_SESSION['login'])&&isset($_SESSION['password']))){
		// We prioritize reading from post rather than session
		if((isset($_POST['login'])&&isset($_POST['password']))){
				$login=$_POST['login'];
				$password=$_POST['password'];
		}else{
				$login=$_SESSION['login'];
				$password=$_SESSION['password'];
		}
		
		try{
				$conn = new PDO("mysql:host=localhost;dbname=a00leifo", 'myusername', 'mypassword');
				$conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
				
				// Now we check if we have correct login and password according to customer table
				$sql = 'SELECT * FROM CUSTOMER WHERE PASSW=:PASSW;';
				
				$stmt = $conn->prepare($sql, array(PDO::ATTR_CURSOR => PDO::CURSOR_SCROLL));
				$stmt->bindParam(':PASSW', $password);
				$stmt->execute();
				
				if($stmt->rowCount()>0){
						echo "\n\nCustomer login successful";

						// If successful, save to session variable
						$_SESSION['login']=$login;	
						$_SESSION['password']=$password;					
				}else{
						echo "Customer login failed.";
						echo "<script>setTimeout(function(){ location.href='pdo_example_php_login_session_form.html' }, 2000);</script>";	
				}			
				
		}catch(PDOException $e){
				echo "Connection failed: " . $e->getMessage();
				echo "<script>setTimeout(function(){ location.href='pdo_example_php_login_session_form.html' }, 2000);</script>";	
		}
}else{
		echo "\n\nYou must provide login name and password";
		echo "<script>setTimeout(function(){ location.href='pdo_example_php_login_session_form.html' }, 2000);</script>";	
}
			
?>
</pre>
</body>
</html>

