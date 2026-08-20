### Overview
This example contains an example of the use of Constraints in create table statements. The constraints allow us to define which values we want to store in the database.

Primary Key, Candidate key and Mandatory value constraints
The simplest forms of constraints are keys and candidate keys. Primary key is used to denote the keys that identify the table.

UNIQUE is used to denote any candidate keys ===Example2_Constraints.sql,7,7,(row 7)===.

CHECK constraints enables the database designer to impose limits on what values that are applicable for a specific column. In this case we have one constraint that limits the cost of an invoice row to positive value and one constraint that limits the ssn to the XXXXXX-XXXX format (rows ===Example2_Constraints.sql,11,11,(row 11)=== and ===Example2_Constraints.sql,30,30,(row 30)===).

___Note:___ The currently installed 5.2 series version of MySQL does not enforce check constraints (it does however parse them to guarantee that they are correctly written). Writing the constraints like this is thus mainly for documentation and compatibility with other servers (most other servers support check constraints) since the constraints must be enforced by other means in MySQL

NOT NULL is used to denote mandatory values (this is natural for keys) but is also common for other types of columns.

In this case, NOT NULL is used for primary keys and candidate keys (===Example2_Constraints.sql,6,6,row 6=== and ===Example2_Constraints.sql,7,7,row 7=== among others).

Not null can also be used to guarantee that a relation is mandatory such as the relation between customer and invoice (row 16).

Not null can also be used to guarantee that a value is entered into other columns such as the cost for invoice rows (row 29). An invoice row does not make sense if it does not have a cost. 