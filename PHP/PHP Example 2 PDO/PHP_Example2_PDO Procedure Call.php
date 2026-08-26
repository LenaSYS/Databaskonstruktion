<html>
<body>
<h3>Calling Procedure</h3>
<?php
		// Connect to database and iterate over each row of the result of a procedure call
		$pdo = new PDO('mysql:dbname=a00leifo;host=localhost', 'myusername', 'mypassword');
    
    echo '<pre>';
    foreach($pdo->query( 'CALL GETAVGCOST();' ) as $row){
        print_r($row);
    }
    echo '</pre>';
?>
</body>
</html>

