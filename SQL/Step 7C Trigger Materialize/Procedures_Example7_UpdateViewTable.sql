CREATE TABLE CATEGORYSUM(
    PRODUCTNAME VARCHAR(32),
    COST REAL
);

DELIMITER //

-- Materialized view update view

CREATE TRIGGER updatesum BEFORE INSERT ON invoicerow
FOR EACH ROW BEGIN
        DELETE FROM categorysum WHERE productname=(SELECT productname FROM PRODUCT WHERE productcode=new.product);
        INSERT INTO categorysum(productname,cost) SELECT productname,sum(cost) FROM INVOICEROW,PRODUCT where INVOICEROW.PRODUCT=New.PRODUCT and PRODUCT.PRODUCTCODE=New.PRODUCT;
END;

//

DELIMITER ;
 