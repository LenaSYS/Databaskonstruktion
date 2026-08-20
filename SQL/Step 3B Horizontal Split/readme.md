### Overview
This example makes use horizontal denormalization by splitting the table horizontally into two parts, of which one part is substantially larger than the other.


### Horizontal Denormalization
It is common that tables have columns that are of different sizes. It is often true that there are very large columns mixed in with smaller columns. 


The gains from vertical denormalization can be great, since we are reducing the size of the tables many times over. 


The gains from splitting the tables vertically are smaller but if there are some columns with very large amounts of information, this can be worthwhile nonetheless.


Technically this is done by creating a table containing the larger columns ===Example6_Horizontal.sql,57,62,(rows 57-62)===, keeping as many as possible of the smaller columns in the other table. 


This is similar to the use of codes, but we can potentially move more than one column to a separate table, and we use the same key as in the base table.


If we previously have denormalized the tables vertically, we must perform the horizontal denormalization on both tables. We can however store both of the long values in the same table, thereby reducing the number of tables by one. 


### Keys

It is important to note is that if we reuse the denormalized table we cannot use foreign keys, since it is impossible to make a foreign key that refers to two distinct tables. 


If this is not the case we must add a foreign key definition as this guarantees that the connection between the two normalized tables remains intact when data is added or removed.
