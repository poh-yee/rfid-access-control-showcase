# 🛡️ RFID Access Control

![.NET Build and Test](https://github.com/poh-yee/rfid-access-control-showcase/actions/workflows/build.yml/badge.svg)

An end-to-end RFID Access Control System featuring a C# ASP.NET Core Web API, a .NET MAUI desktop frontend, MySQL database integration, and automated CI/CD unit testing.

---

## 🚀 Key Features

* **⚡ ASP.NET Core Web API:** High-performance RESTful API that handles real-time RFID card validation, custom middleware, and access logging.
* **🔒 API Key Security:** Header-level token authentication (`X-API-KEY`) enforcing unauthorized access prevention.
* **🖥️ .NET MAUI Desktop App:** Cross-platform desktop interface simulating physical card scans with dynamic feedback and live history logs.
* **🗄️ MySQL Database:** Relational database setup (via XAMPP) storing user badges, access permissions, and timestamped logs.
* **🧪 Automated Unit Testing:** Comprehensive test coverage written with **xUnit** to verify security business logic.
* **🔄 CI/CD Pipeline:** GitHub Actions workflow executing automated build and test checks on every push.

---

## 🛠️ Tech Stack

* **Language:** C# (.NET 10)
* **Frontend:** .NET MAUI (Windows)
* **Backend:** ASP.NET Core Web API
* **Database:** MySQL / XAMPP
* **Testing:** xUnit
* **DevOps:** GitHub Actions CI/CD

---

## 🚦 Getting Started

### Prerequisites

* [.NET 10 SDK](https://dotnet.microsoft.com/)
* [XAMPP](https://www.apachefriends.org/) (for MySQL)
* Visual Studio 2022 / VS Code with .NET & MAUI workloads

---

### Setup & Run

1. **Database Setup:**
   * Start Apache and MySQL in XAMPP.
   * Import the database script to create the required tables (`rfid_db`).

2. **Run the API:**
   ```bash
   cd RfidAccessControl.Api
   dotnet run

3. **Run the Desktop:**
```bash
   cd RfidAccessControl.Desktop
   dotnet run -f net10.0-windows10.0.19041.0
   
 Optional (Unit Test):
   dotnet test RfidAccessControl.Tests