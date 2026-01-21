# 🛒 Mini Grocery Order System

A minimal, backend-focused grocery ordering system designed to demonstrate **clean architecture**, **transaction-safe order processing**, and **strict API discipline**.

---

## 🎯 Objective

This project was built as part of an evaluation task to assess:
- Backend architecture clarity
- Business logic isolation
- Transaction handling
- API discipline

UI and design were intentionally kept minimal.

---

## 🧰 Tech Stack

| Layer | Technology |
|------|-----------|
Backend | ASP.NET Core Web API |
Frontend | Angular (Standalone, Minimal UI) |
Database | SQL Server + Entity Framework Core |

---

## 📁 Project Structure
```
mini-grocery-order-system/
├── backend/
│ ├── Controllers/
│ ├── Services/
│ ├── Repositories/
│ ├── Models/
│ └── Data/
│
└── frontend/
└── Angular standalone app
```


### Responsibility Breakdown

| Layer | Responsibility |
|-----|----------------|
Controllers | Handle HTTP request & response only |
Services | All business logic & transaction handling |
Repositories | Database access |
Models | Database schema |

---

## 🔗 API Design (STRICT)

⚠️ **Only two APIs are implemented as per requirement**

### 🔹 GET `/products`
Fetches the list of available products.

### 🔹 POST `/orders`
Handles the **entire order lifecycle**:
- Product existence validation
- Stock availability check
- Stock deduction
- Order creation
- All operations executed in **one database transaction**

❌ No extra APIs were created for validation or stock checks.

---

## 🔐 Order Logic & Stock Handling

- Orders are rejected if stock is insufficient
- Stock is never allowed to go negative
- Concurrent requests are handled safely
- All operations are wrapped inside a single database transaction

### Edge Case Handling
If product stock = 5:
- Order quantity = 3 → ✅ Success
- Order quantity = 3 again → ❌ Fails

---

## 🖥️ Frontend (Minimal)

The frontend is intentionally minimal and focuses only on:
- Displaying product list
- Placing orders
- Showing success or failure popups

❌ No business logic  
❌ No stock calculations  
❌ No extra API calls  

All logic is handled by the backend.

---

## 🚫 Constraints Followed

- ❌ No extra APIs
- ❌ No business logic in controllers
- ❌ No business logic in frontend
- ❌ No database triggers or stored procedures
- ❌ No mixed responsibilities

---

## ✅ Summary

This project demonstrates:
- Clean layered architecture
- Transaction-safe order processing
- Strict API discipline
- Proper separation of concerns

It fully satisfies all requirements of **Demo Task 1**.

---

📌 **Note:**  
This project prioritizes backend correctness and architecture over UI design, as per task instructions.
