<html>
<body>
<h3>Calling Procedure</h3>
<pre>
<?php
		// Connect to database and iterate over each row of the result of a procedure call
		$pdo = new PDO('mysql:dbname=a00leifo;host=127.0.0.1;port=3306', 'myusername', 'mypassword');
		$pdo->setAttribute( PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION );

    foreach($pdo->query( 'CALL GETAVGCOST();' ) as $row){
        print_r($row);
    }
?>
</pre>
</body>
</html>

