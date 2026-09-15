<html>
<body>
<h3>Response Page</h3>
<table border='1'>
 
<?php
		$pdo = new PDO('mysql:dbname=a00leifo;host=127.0.0.1;port=3306', 'myusername', 'mypassword');
 
    if(isset($_POST['SSN'])){
        $querystring='SELECT * FROM CUSTOMER WHERE SSN LIKE :SSN';
        
        $searchstr="%".$_POST['SSN']."%";
        $stmt = $pdo->prepare($querystring);
        $stmt->bindParam(':SSN', $searchstr);
        $stmt->execute();
                     
        foreach($stmt as $key => $row){
          echo "<tr>";
          echo "<td>".$row['SSN']."</td>";
          echo "<td>".$row['CUSTNO']."</td>";      
          echo "<td>".$row['NAME']."</td>";      
          echo "<td>".$row['REGDATE']."</td>";
          echo "</tr>";
        }
    }
?>
 
</table>
</body>
</html>