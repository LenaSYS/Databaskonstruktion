
-- Update cost for certain invoice row number

DELIMITER //

CREATE PROCEDURE SETCOSTPROD(InRowno INTEGER, InCost REAL)
BEGIN
  UPDATE INVOICEROW SET COST=InCost WHERE NUMBER=InRowno;
END;
//

DELIMITER ;

-- Execute procedure
CALL SETCOSTPROD('2','800');
