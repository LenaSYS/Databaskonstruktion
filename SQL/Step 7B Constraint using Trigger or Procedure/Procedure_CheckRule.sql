
-- Update cost for certain invoice and row number. Makes sure Cost is positive

DELIMITER //

CREATE TRIGGER INSERTCHECK BEFORE INSERT ON INVOICEROW
FOR EACH ROW BEGIN

	IF(NEW.COST<0) THEN
		SIGNAL SQLSTATE ‘45000’ set message_text =‘The cost cant be less than zero.’
	END IF;

END;

//
DELIMITER ;