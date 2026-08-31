<html>
<body>
<h3>Table With Hidden Inputs and Hidden form</h3>
	
<?php

		$pdo = new PDO('mysql:dbname=a00leifo;host=127.0.0.1;port=3306', 'myusername', 'mypassword');

		if(isset($_POST['ModCustno'])){
				$querystring='UPDATE CUSTOMER SET NAME=:NAME WHERE CUSTNO=:MODCUSTNO;';
				$stmt = $pdo->prepare($querystring);
				$stmt->bindParam(':NAME', $_POST['Custname']);
				$stmt->bindParam(':MODCUSTNO', $_POST['ModCustno']);			
				$stmt->execute();				
		}

    // Forms are not allowed inside TBODY / TABLE / TR but are allowed inside TD or TH so we generate forms first and connect using form attribute
		foreach($pdo->query("SELECT * FROM CUSTOMER") as $row){
			echo "<form action='PHP_Example_HiddenForm.php' method='post' id='form".$row['CUSTNO']."'></form>";
		}

    echo "<pre>";
    print_r($_POST);
    echo "</pre>";

    echo "<table>";
		foreach($pdo->query("SELECT * FROM CUSTOMER") as $row){
        // Make table row including one row with input
        echo "<tr>";
        echo "<td>".$row['CUSTNO']."</td>";
        echo "<td>".$row['SSN']."</td>";
        // Connect input to correct form through ID
				echo "<td>";
        echo "<input type='text'   form='form".$row['CUSTNO']."' name='Custname' value='".$row['NAME']."'>";
				echo "<input type='hidden' form='form".$row['CUSTNO']."' name='ModCustno' value='".$row['CUSTNO']."'>";
				echo "<input type='submit' form='form".$row['CUSTNO']."' value='Save'>";
        echo "</td>";
        echo "</tr>";
    }
    echo "</table>"

    /*

<form method="GET" id="my_form"></form>

<table>
    <tr>
        <td>
            <input type="text" name="company" form="my_form" />
            <button type="button" form="my_form">ok</button>
        </td>
    </tr>
</table>

    */
		
?>

</body>
</html>