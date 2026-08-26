<!DOCTYPE html>
<html>
<body>
<h3>Testing Form</h3>
 
<?php
    // Function to debug parameters
    echo "<pre>";
    print_r($_POST);
    echo "</pre>";
?>
 
<form action="PHPFormSelfreference.php" method="POST">
  Field1: <input type="text" name="field1" /><br>
  Field2: <input type="text" name="field2" /><br>
  Checkbox1: <input type="checkbox" name="checkbox0" /><br>
  <input type="submit" />
</form> 
 
</body>
</html>