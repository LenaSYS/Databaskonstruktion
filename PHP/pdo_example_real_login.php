<html>
<body>
<pre>
<?php
	
print_r($_POST);
 
if(isset($_POST['login'])&&isset($_POST['password'])){
		try{
				$conn = new PDO("mysql:host=localhost;dbname=a00leifo", $_POST['login'], $_POST['password']);

				// set the PDO error mode to exception
				$conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
				
				echo "\n\nConnected successfully";
		}catch(PDOException $e){
				echo "Connection failed: " . $e->getMessage();
				echo "<script>setTimeout(function(){ location.href='pdo_example_real_login_form.html' }, 2000);</script>";
		}
}else{
		echo "\n\nYou must provide login name and password";
		echo "<script>setTimeout(function(){ location.href='pdo_example_real_login_form.html' }, 2000);</script>";	
}

?>
</pre>
</body>
</html>