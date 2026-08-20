### Overview
This example makes use of codes, to reduce the number of long text columns with repeating values.
		
### Codes
When we have text values that appear many times, we gain performance by changing that text value to a code i.e. a number that represents that text string. 

The more a certain text is repeated, the more we gain. In the case of the invoice, the company name and the product names are long strings that are repeated over and over again.

Technilcally this is quite straightforward. We create a tabls with the code, and the corresponding text value ===Example4_Codes.sql,15,25,(rows 15-25)=== and we use a foreign key to refer to the code table ===Example4_Codes.sql,39,40,(rows 39-40)=== and finally we change the datatypes from varchar(30) to smallint ===Example4_Codes.sql,33,34,(rows 33-34)===.

By doing this we reduce the (at most) 30 character columns to only two bytes, meaning that in the extreme we have gone from 60 bytes to only four. As the value is a varchar, on average the numbers are less impressive, but the gain can be substantial. 