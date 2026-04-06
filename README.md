# Booking Care Service

**Booking Service** API built with **.NET Core** for managing reservations, users, and services. This service provides endpoints for creating, updating, and retrieving bookings in a secure and scalable manner.

## Table of Contents

- [Features](#features)  
- [Tech Stack](#tech-stack)  
- [Getting Started](#getting-started)  
- [API Endpoints](#api-endpoints)  
- [Database Schema](#database-schema)  
- [Authentication](#authentication)  
- [Testing](#testing)  
- [Future Improvements](#future-improvements)  
- [License](#license)  

---

## Features

- Create, update, cancel, and retrieve bookings  
- Search bookings by date, service type, or user  
- Role-based access control (Admin/User)  
- RESTful API design for scalability  
- Input validation and error handling  

---

## Tech Stack

- **Backend:** .NET Core, C#  
- **Database:** SQL Server / PostgreSQL  

---

## Getting Started

### Prerequisites

- [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)  
- Node.js 18+ (for frontend)  
- SQL Server / PostgreSQL  

### Bookings Endpoints

| Method | Endpoint             | Description               |
|--------|--------------------|---------------------------|
| POST   | /api/Booking       | Create a new booking      |
| POST    | /api/Booking/{id}/reschedule  | Reschedule an existing booking|
| POST | /api/Booking/{id}/cancel  | Cancel a booking          |
| GET | /api/Booking/{id} | Retrieve a booking by GUID
---