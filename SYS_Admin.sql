-- Create regular user
CREATE USER supplier_mgr IDENTIFIED BY supplier123;
GRANT CONNECT, RESOURCE, CREATE TRIGGER, CREATE PROCEDURE TO supplier_mgr;
GRANT UNLIMITED TABLESPACE TO supplier_mgr;
GRANT CREATE SESSION TO supplier_mgr;

ALTER USER supplier_mgr ACCOUNT UNLOCK;

-- Verify
SELECT USERNAME, ACCOUNT_STATUS FROM DBA_USERS WHERE USERNAME = 'SUPPLIER_MGR';

GRANT ALL ON USERS TO supplier_mgr;
GRANT ALL ON SUPPLIERS TO supplier_mgr;
GRANT ALL ON PRODUCTS TO supplier_mgr;
GRANT ALL ON SUPPLIER_PRODUCTS TO supplier_mgr;
GRANT ALL ON PURCHASE_ORDERS TO supplier_mgr;
GRANT ALL ON PO_ITEMS TO supplier_mgr;
GRANT ALL ON DELIVERIES TO supplier_mgr;
GRANT ALL ON SUPPLIER_INVOICES TO supplier_mgr;
GRANT ALL ON PAYMENTS TO supplier_mgr;
GRANT ALL ON SUPPLIER_AUDIT_LOG TO supplier_mgr;


-- GRANT EXECUTE ON PROCEDURES

GRANT EXECUTE ON RECORD_PAYMENT TO supplier_mgr;
GRANT EXECUTE ON GET_SUPPLIER_OUTSTANDING TO supplier_mgr;


-- GRANT ACCESS TO VIEWS/SEQUENCES (if any)

-- Grant access to identity sequences (automatically needed for inserts)
GRANT SELECT ON USERS_SEQ TO supplier_mgr;  -- If sequences exist
-- For identity columns, Oracle handles automatically


-- VERIFY GRANTS

-- Check what privileges were granted
SELECT TABLE_NAME, PRIVILEGE 
FROM DBA_TAB_PRIVS 
WHERE GRANTEE = 'SUPPLIER_MGR'
ORDER BY TABLE_NAME;