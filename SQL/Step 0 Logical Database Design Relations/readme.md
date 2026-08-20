### Overview
This example contains an example of the use of the github [markdown](https://docs.github.com/en/get-started/writing-on-github/getting-started-with-writing-and-formatting-on-github/basic-writing-and-formatting-syntax) as a standard for documenting relational tables and documenting requirements. This serves as a living documentation document preserved in the github repository.

We use the following markdown code to represent the name of the relation
```
**RelationName** 
```

We use the following markdown code to represent the key of the relation
```
<ins>KeyColumn</ins>
```
We use the following markdown code to represent a compound key of a relation
```
<ins>KeyColumn, KeyColumnB</ins>
```
We use the following markdown code to represent a foreign key of a relation
```
~ForeignKeyColumn~
```

We use the following markdown code to represent a compound key of a relation that is also a foreign key
```
<ins>~KeyColumn, KeyColumnB~</ins>
```

A complete Example from the repository


```**InvoiceRow**(<ins>RowNumber,~InvoiceNumber~</ins> , Cost, ProductName, Company)```

Which renders as

**InvoiceRow**(<ins>RowNumber,~InvoiceNumber~</ins> , Cost, ProductName, Company)


We represent the requirements as a heading and the requirements that cover each relation as a subheading

```
# Requirements

A few lines containing general description of requirements

## Customer

* First customer requirement
* Second customer requirement
* Third customer requirement
```

Which renders as

# Requirements

A few lines containing general description of requirements

## Customer

* First customer requirement
* Second customer requirement
* Third customer requirement

