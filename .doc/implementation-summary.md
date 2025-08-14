[Back to README](../README.md)

# Developer Evaluation – Backend API

## Overview

This project implements a **complete CRUD API** for **Users, Products, and Sales** using **DDD principles**.  
It includes validation rules, JWT authentication, Redis caching, and RabbitMQ event publishing (simulated via logs).

---

## 2. Tech Stack

- **Backend:** .NET 8 / C#  
- **Database:** PostgreSQL  
- **Cache:** Redis  
- **Messaging:** RabbitMQ  
- **Authentication:** JWT  
- **ORM:** Entity Framework Core  
- **Other:** AutoMapper, MediatR, FluentValidation, Serilog  

---


## 3. Setup

### 3.1 Clone repository

```bash
git clone <your-repo-url>
cd developer-evaluation
```

### 3.2 Docker Compose

```bash
docker-compose up -d
```

### 3.3 Configure Environment

-- Set environment variables (or edit appsettings.Development.json)

```bash
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=devstore;Username=postgres;Password=postgres"
  },
  "RabbitMq": {
    "RabbitMqConnection": "localhost:5672",
    "RabbitMqUser": "developer",
    "RabbitMqPass": "eveluAt10n"
  },
  "Redis": {
    "RedisConnection": "localhost:6379",
    "RedisPass": "ev@luAt10n"
  },
  "Jwt": {
    "Secret": "your-jwt-secret-key",
    "Issuer": "developer-evaluation",
    "Audience": "developer-evaluation"
  }
}
```

### 3.4 Run Migrations

```bash
dotnet ef database update --project Ambev.DeveloperEvaluation.ORM
```

### 3.4 Run Migrations

```bash
dotnet ef database update --project Ambev.DeveloperEvaluation.ORM
```

### 3.5 Run API

```bash
dotnet run --project Ambev.DeveloperEvaluation.WebApi
```

-- API will be available at: https://localhost:8081
-- Swagger UI: https://localhost:8081/swagger

### 4. Authentication (JWT)

-- 1. Use /api/auth/login endpoint to generate a token.
-- 2. Copy the token and click Authorize in Swagger.
-- 3. All endpoints require authentication

### 5. Endpoints

| Method | Endpoint        | Description    |
| ------ | --------------- | -------------- |
| POST   | /api/users      | Create user    |
| GET    | /api/users      | List users     |
| GET    | /api/users/{id} | Get user by ID |
| PUT    | /api/users/{id} | Update user    |
| DELETE | /api/users/{id} | Delete user    |


| Method | Endpoint           | Description       |
| ------ | ------------------ | ----------------- |
| POST   | /api/products      | Create product    |
| GET    | /api/products      | List products     |
| GET    | /api/products/{id} | Get product by ID |
| PUT    | /api/products/{id} | Update product    |
| DELETE | /api/products/{id} | Delete product    |


| Method | Endpoint        | Description                                |
| ------ | --------------- | ------------------------------------------ |
| POST   | /api/sales      | Create sale (items, quantities, discounts) |
| GET    | /api/sales      | List sales                                 |
| GET    | /api/sales/{id} | Get sale by ID                             |
| PUT    | /api/sales/{id} | Update sale (update/cancel/add items)      |
| DELETE | /api/sales/{id} | Cancel sale                                |


## 6. Event Publishing

The system can log events for sales operations. No external broker is required, but RabbitMQ is configured.

### Sale Events

| Event Name        | Triggered When                                    |
|------------------|--------------------------------------------------|
| SaleCreated       | When a new sale is created                       |
| SaleModified      | When an existing sale is updated                 |
| SaleCancelled     | When a sale is cancelled                         |
| ItemCancelled     | When an individual item in a sale is cancelled  |


## 7. Caching with Redis

Redis is used for caching frequently accessed data.

** Redis Configuration

| Method      | Description           |
| ----------- | --------------------- |
| SetCache    | Save a key-value pair |
| GetCache    | Retrieve value by key |
| KeyExists   | Check if key exists   |
| RemoveCache | Delete a key          |

** Example Usage

```bash
var redisService = new RedisService(configuration);

// Set
redisService.SetCache("sale_123", "cached_sale_data");

// Get
var saleData = redisService.GetCache("sale_123");

// Check existence
bool exists = redisService.KeyExists("sale_123");

// Remove
redisService.RemoveCache("sale_123");
```

