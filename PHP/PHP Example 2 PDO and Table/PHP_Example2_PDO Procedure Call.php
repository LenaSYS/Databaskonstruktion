<html>
<body>
<h3>Calling Procedure</h3>
<pre>
<?php
		// Connect to database and iterate over each row of the result of a procedure call
		$pdo = new PDO('mysql:host=mysql;port=3306;dbname=a00leifo', 'username', 'hemligtlösen');
		$pdo->setAttribute( PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION );

    foreach($pdo->query( 'CALL GETAVGCOST();' ) as $row){
        print_r($row);
    }
?>
</pre>
</body>
</html>

