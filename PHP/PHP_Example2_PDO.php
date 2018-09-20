<html>
<body>
<h3>Calling Procedure</h3>
<?php
		
    // Function to debug 
    function debug($o){
      echo '<pre>';
      print_r($o);
      echo '</pre>';
    }

		$pdo = new PDO('mysql:dbname=a00leifo;host=localhost', 'myusername', 'mypassword');
				
		foreach($pdo->query( 'CALL GETAVGCOST();' ) as $row){
			debug($row);
		}
		
?>
</body>
</html>

