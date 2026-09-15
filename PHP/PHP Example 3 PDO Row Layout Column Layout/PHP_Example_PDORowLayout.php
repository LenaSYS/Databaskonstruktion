<html>
<body>
<table border=1>

<?php
		$pdo = new PDO('mysql:dbname=a00leifo;host=127.0.0.1;port=3306', 'root', 'kingfisher');
		$pdo->setAttribute( PDO::ATTR_ERRMODE, PDO::ERRMODE_WARNING );
		
		// Read all customers to a table
    $previnvoice="NONE";
		foreach($pdo->query( '(SELECT * FROM INVOICEROW,PRODUCT WHERE PRODUCT.PRODUCTCODE=INVOICEROW.PRODUCT) UNION (SELECT * FROM PAIDINVOICEROW,PRODUCT WHERE PRODUCT.PRODUCTCODE=PAIDINVOICEROW.PRODUCT) ORDER BY INVOICENO ASC;' ) as $row){
      // If we are in a new invoice make a new row
      if($previnvoice!=$row['INVOICENO']){
            // If not first invoice we close previous row!
            if($previnvoice!="NONE"){
                echo "</table></td></tr>";
            }

            echo "<tr>";
      			echo "<td>".$row['CUSTNO']."</td>";
			      echo "<td>".$row['INVOICENO']."</td>";
			      echo "<td>".$row['DATEPAID']."</td>";
            echo "<td><table border=1>";
      }

      echo "<tr>";
			echo "<td>".$row['NUMBER']."</td>";
			echo "<td>".$row['PRODUCTNAME']."</td>";
			echo "<td>".$row['COMPANY']."</td>";
			echo "<td>".$row['COST']."</td>";
			echo "</tr>";	

      $previnvoice=$row['INVOICENO'];
		}
?>
</table>
</body>
</html>

