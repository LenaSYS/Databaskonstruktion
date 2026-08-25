
-- Create a user for the economy system application
CREATE USER 'economysystem'@'localhost' IDENTIFIED BY 'mypass';

-- Gives select access to COMPANY table to the economysystem
GRANT SELECT ON a00leifo.COMPANY TO economysystem;

-- Create a view that excludes the password from the result
CREATE VIEW ECONOMYCUSTOMERS AS SELECT CUSTNO,SSN,NAME,REGDATE FROM CUSTOMER;

-- Gives select on all parts of customer except for password to economysystem
GRANT SELECT ON a00leifo.ECONOMYCUSTOMERS to economysystem;

