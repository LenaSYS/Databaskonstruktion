### Overview
This example contains shows how to make a html form and read the form contents using PHP. The example also contains useful debug functionality that shows the data
returned from the form.


### Introduction

The html form is created using the <form> tag and uses a variety of <input> tags for entering information. For example, a "text" input (===PHP_Example1_Params.php,19,20,rows 19-20===) creates a text box in the form.


Each form has a method (in this case "post") and a link, called an action, in this case "PHP_Example1_Params.php". The action can refer to the same file
that contains the form (===PHP_Example1_Params.php,18,18,row 18===). If the form uses the "post" method, $_POST is used to retrieve the information from the form in the application, if "get" is
used the variable is called $_GET.


### This Example Database

The debug function (===PHP_Example1_Params.php,7,12,rows 7-12=== and used on ===PHP_Example1_Params.php,14,14,row 14===) shows exactly which information that is returned to the application. This is useful in order to understand 
exactly what the information that is returned means and how it is structured. When developing a new web application it is very common that such debug funcationality is
used during the early phases of development.


The application does nothing other than show the data that is entered into the form.