### Overview

This example contains code for the specification of access privileges.

### Introduction

We use the create user command to create users in the database and then we use grant / revoke to give or remove privileges from users.

### This Example Database

By making users, we can control the privileges. If we want to control the privileges of each user individually, we can create accounts for each user, but if it is enough to control the privileges of each application, we can make an account for each application.

In this case, we create an account using CREATE USER for the economics system (row 3).

There are separate privileges for each of the main commands of SQL and each table or view can have a distinct set of privileges. If we want the application to have access to all of the information in a table we can give privileges directly to a base table. In this example we want the user to be able to read (we GRANT SELECT privileges) all the information about the companies (row 6).

```sql
-- Create a user for the economy system application
CREATE USER 'economysystem'@'localhost' IDENTIFIED BY 'mypass';
```
We can then specify privileges.

```sql
-- Gives select access to COMPANY table to the economysystem
GRANT SELECT ON a00leifo.COMPANY TO economysystem;
```
