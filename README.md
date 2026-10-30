<p align="center"><img src="assets/logo.png" alt="Masaka-Agri Supplies logo" width="180"></p>

# Supplier Management System

An Oracle database for **Masaka Agri-Supplies Ltd**, a case-study agricultural input business in Masaka, Uganda that buys seeds, fertilizers, pesticides and farm tools from more than 30 suppliers and handles about 50 purchase orders a month.

Coursework project for Database Programming (Year 2), Muteesa I Royal University. Designed and developed by **Muloki Elizephen Derick**.

## The problem

The business tracked suppliers in notebooks and Excel files. That led to duplicated data, delayed orders, payment confusion, arithmetic errors and no audit trail. This project moves everything into one database that enforces the business rules itself.

## What is in the database

| Area | Details |
|---|---|
| Tables (10) | USERS, SUPPLIERS, PRODUCTS, SUPPLIER_PRODUCTS, PURCHASE_ORDERS, PO_ITEMS, DELIVERIES, SUPPLIER_INVOICES, PAYMENTS, SUPPLIER_AUDIT_LOG |
| Integrity | Primary and foreign keys, unique and check constraints, indexes on the main join columns |
| Stored procedures | `RECORD_PAYMENT`, `GET_SUPPLIER_OUTSTANDING` (invoiced, paid and balance per supplier) |
| Triggers | `CHECK_PAYMENT_AMOUNT` blocks overpayments, `UPDATE_INVOICE_STATUS_AFTER_PAYMENT` keeps invoice status correct, `LOG_SUPPLIER_CHANGES` writes an audit trail |
| Users and roles | A USERS table with ADMIN, MANAGER and CLERK roles, plus an Oracle schema user with explicit grants |

## Repository layout

```
database/
  oracle/01_sys_admin.sql      create the schema user and grants (run as a DBA)
  oracle/02_supplier_mgr.sql   tables, procedures, triggers and sample data
  mysql/supplier_management_system.sql   MySQL / MariaDB version of the schema and sample data
docs/supplier_management_system_ERD.mwb   entity relationship diagram (MySQL Workbench)
assets/logo.png
```

## How to run (Oracle)

1. Connect as a DBA, edit the password in `01_sys_admin.sql`, and run it to create the `supplier_mgr` user.
2. Connect as `supplier_mgr` and run `02_supplier_mgr.sql`.
3. Try it: `EXEC GET_SUPPLIER_OUTSTANDING(NULL);` after `SET SERVEROUTPUT ON`.

The sample accounts in the data (`admin`, `manager`, `clerk`) are demo logins only. Change them before any real use.

## Author

Muloki Elizephen Derick, [GitHub](https://github.com/Muloki-256)
