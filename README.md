# 🏫 School Management System

A basic school management web application built with a clean architecture using:
- ASP.NET Core (.NET 6+) for the backend API
- PostgreSQL as the database
- React for the frontend UI
- JWT Authentication for security
- xUnit for unit testing

---

## 📁 Project Structure
SchoolSolution/
│
├── School.Api # .NET Web API project
│ ├── Controllers # API endpoints
│ ├── DAL # Data access layer (DbContext)
│ ├── BLL # Business logic layer (services)
│ ├── Repositories # Database logic
│ ├── DTOs # Data transfer objects
│ └── Interfaces # Service/repo contracts
│
├── School.Tests # xUnit test project
│
└── school-ui # React frontend project

---

## 🚀 Features

- User Registration & Login
- JWT Token-based Authentication
- Role-based Authorization (`admin`, `user`)
- Protected API endpoints
- React-based Login UI
- Clean N-tier Architecture
- PostgreSQL Integration
- xUnit Test Cases

---

## 🔐 Authentication Flow

- JWT Token is generated after successful login.
- Token is stored in localStorage (frontend).
- Protected routes check for token and role before allowing access.

---

## 🛠️ Technologies Used

- ASP.NET Core Web API
- PostgreSQL
- Entity Framework Core
- React (Vite + React Router + Axios)
- Bootstrap (for styling)
- JWT Bearer Authentication
- xUnit for testing

---

## 🧪 Running the Project

### Backend (.NET)
