-- Create a user for the economy system application
CREATE USER 'economysystem'@'localhost' IDENTIFIED BY 'mypass';
 
-- Gives select access to COMPANY table to the economysystem
GRANT SELECT ON a00leifo.COMPANY TO economysystem;
