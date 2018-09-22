<html>
<body>
<h3>Constructing Option Box</h3>
 
<form action="dbktest9code.php" method="post">
   COMPANYCODE:<input type="text" name="companycode">
   COMPANYNAME:<input type="text" name="companyname">
   <input type="submit" value="Send">
   <input type="reset">
</form>
 
<?php
    
    $pdo = new PDO('mysql:dbname=a00leifo;host=localhost', 'a00leifo', 'thisisthepassword');
    $pdo->setAttribute( PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION );
 
    if(isset($_POST['companycode'])){
        $companycode=$_POST['companycode'];
        $companyname=$_POST['companyname'];
        $sql = 'INSERT INTO COMPANY(COMPANYCODE,COMPANYNAME) VALUES(:COMPANYCODE,:COMPANYNAME);';
        $stmt = $pdo->prepare($sql);
        $stmt->bindParam(':COMPANYCODE', $companycode);
        $stmt->bindParam(':COMPANYNAME', $companyname);
 
         try{ 
            $stmt->execute();                  
        }catch (PDOException $e){
            if($e->getCode()="23000"){
                echo "Duplicate company code!";
            }else{
                echo $e->getMessage();
            }
        }
        
    }
    
?>
 
 
</body>
</html>