### Overview
This example contains an example of the use of forms in PHP code. 

We can either make self referencing applications that consist of one single php file or form response pages that contain more than one php file.

## Self Referencing Application

In this case in the file PHPFormSelfreference.php we refer to that same file in the action part of the form and the code that shows the output of the form is in the same php file as the form.

```php
<form action="PHPFormSelfreference.php" method="POST">
  Field1: <input type="text" name="field1" /><br>
  Field2: <input type="text" name="field2" /><br>
  Checkbox1: <input type="checkbox" name="checkbox0" /><br>
  <input type="submit" />
</form> 
```
## Form Response Application

In this case in the file PHPFormForm.php we refer to another file PHPFormResponse.php in the action part of the form and the form debugging code is in the response page.

```php
<form action="PHPFormResponse.php" method="POST">
  Field1: <input type="text" name="field1" /><br>
  Field2: <input type="text" name="field2" /><br>
  Checkbox1: <input type="checkbox" name="checkbox0" /><br>
  <input type="submit" />
</form> 
```

## Debugging form

We debug the form by making a print_r inside a pre tag which formats the output in a structured manner. If we do not include the pre tag the output will be harder to read.

```php
<?php
    // Function to debug parameters
    echo "<pre>";
    print_r($_POST);
    echo "</pre>";
?>
```


