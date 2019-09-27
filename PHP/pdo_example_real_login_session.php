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
				$conn = new PDO("mysql:host=localhost;dbname=a00leifo", $login, $password);

				// set the PDO error mode to exception
				$conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
				
				echo "\n\nConnected successfully";

				// If successful, save to session variable
				$_SESSION['login']=$login;	
				$_SESSION['password']=$password;

		}catch(PDOException $e){
				echo "\n\nConnection failed: " . $e->getMessage();
				echo "<script>setTimeout(function(){ location.href='pdo_example_real_login_session_form.html' }, 2000);</script>";
		}
}else{
		echo "You must provide login name and password";
		echo "<script>setTimeout(function(){ location.href='pdo_example_real_login_session_form.html' }, 2000);</script>";	
}

?>
</pre>
</body>
</html>

