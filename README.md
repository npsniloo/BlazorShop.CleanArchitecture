# BlazorShop.CleanArchitecture
A production-ready E-commerce platform built with Blazor Server and .NET, implementing Clean Architecture, JWT Authentication, and a comprehensive Admin Dashboard.

# BlazorShop: Clean Architecture E-Commerce

[![.NET 8/9](https://img.shields.io/badge/.NET-8.0/9.0-512bd4)](https://dotnet.microsoft.com/)
[![Blazor](https://img.shields.io/badge/UI-Blazor%20Server-512bd4)](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor)
![Auth](https://img.shields.io/badge/Auth-Cookie%20Based-blue)
![Authorization](https://img.shields.io/badge/Auth-Claims%20%26%20Roles-success)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

A modern, full-stack E-commerce solution designed with **Clean Architecture** principles. This project serves as a showcase of enterprise-level development patterns using **Blazor Server** and **.NET**.

## 🚀 Key Features

### Customer Portal
- **Product Discovery:** Browse products with dynamic filtering.
- **Cart Management:** Full CRUD operations on basket items.
- **Checkout Flow:** Integrated checkout process with order persistence.
- **User Accounts:** Secure registration, login, and profile management.

### Admin Dashboard
- **Content Management:** Manage UI elements (Banners, Sliders, Menus).
- **Catalog Management:** Full control over Products, Categories, and Coupons.
- **Order Tracking:** Monitor and manage customer orders and statuses.
- **User & Feedback:** Manage users and moderate product comments.

### Technical Excellence
- **Architecture:** Clean Architecture (Domain, Application, Infrastructure, WebUI).
- **Security:** Cookie-based authentication with secure password recovery (Email-based codes).
- **Data:** SQL Server with EF Core (Code-First approach).
- **Patterns:** Repository Pattern, Dependency Injection, and DTO mapping.

## 🛠️ Tech Stack
- **Frontend:** Blazor Server
- **Backend:** .NET (9.0) / ASP.NET Core
- **Database:** SQL Server
- **ORM:** Entity Framework Core (9.0)
- **Authentication:** ASP.NET Core Cookie Authentication
- **Authorization:** Claims and Role-based Access Control
- **Password Recovery:** Email-based reset code

## 🏗️ Architecture Overview
The project is divided into four main layers to ensure maintainability and testability:
1.  **Domain:** Core entities and business logic.
2.  **Application:** Application logic, DTOs, and Interfaces.
3.  **Infrastructure:** Persistence (EF Core), SQL Server implementation, and external services (Email).
4.  **WebUI:** Blazor Server components and API endpoints.

## 🚧 Roadmap
- [ ] Structured Logging (Serilog/ELK)
- [ ] Redis Distributed Caching for Shopping Carts
- [ ] Dockerization & Container Orchestration
- [ ] Integration of Payment Gateways (Stripe/PayPal)
- [ ] Unit & Integration Testing (xUnit/FluentAssertions)

## 💻 Getting Started
1. Clone the repository: `git clone https://github.com/YourUsername/BlazorShop.CleanArchitecture.git`
2. Update the connection string in `appsettings.json`.
3. Run `Update-Database` via Package Manager Console to initialize SQL Server.
4. Press `F5` to run the application.

---
*Developed by Niloofar Pahlevan – Senior .NET Developer*

