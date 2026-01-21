\# Mini Grocery Order System



\## Overview

A minimal grocery ordering system built to demonstrate clean backend architecture,

transaction-safe order handling, and strict API discipline.



Tech Stack:

\- Backend: ASP.NET Core Web API

\- Frontend: Angular (standalone, minimal UI)

\- Database: SQL Server (EF Core)



---



\## Project Structure



backend/

\- Controllers/

\- Services/

\- Repositories/

\- Models/

\- Data/



frontend/

\- Angular standalone app

\- Minimal UI



---



\## APIs (STRICT)

Only the following APIs are implemented:



\### GET /products

Fetches the list of available products.



\### POST /orders

Places an order and handles all order logic:

\- Product existence check

\- Stock availability check

\- Stock deduction

\- Order creation

\- All operations executed in a single database transaction



---



\## Business Logic Location

\- Controllers: Handle HTTP request/response only

\- Services: Contain all business logic

\- Repositories: Handle database access

\- Models: Define database schema



No business logic exists in controllers or frontend.



---



\## Order Logic (Transaction-Safe)

\- Rejects order if stock is insufficient

\- Prevents negative stock

\- Handles concurrent requests safely using database transactions



---



\## Frontend

\- Lists products

\- Allows placing orders

\- Displays success/failure messages via popup

\- No UI/UX focus, logic handled only by backend



---



\## Notes

\- No extra APIs were created

\- No database triggers or stored procedures used

\- Frontend does not handle business logic



