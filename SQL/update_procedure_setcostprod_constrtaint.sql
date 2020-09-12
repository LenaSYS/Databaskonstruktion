USE a00leifo;

-- Update cost for certain invoice and row number. Makes sure Cost is positive

DELIMITER //

CREATE PROCEDURE SETCOSTPRODRULE(InInvoice integer,InRowno integer, InCost real)
BEGIN
    IF (InCost<=0) THEN
		    SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Negative Cost Not Allowed';
    ELSE 
        UPDATE INVOICEROW SET COST=InCost WHERE INVOICENO=InInvoice and NUMBER=InRowno;
    END IF;
END;
//

DELIMITER ;

-- Execute procedure
CALL SETCOSTPRODRULE('1','2','300');
