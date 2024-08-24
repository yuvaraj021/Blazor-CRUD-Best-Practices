# Blazor CRUD Application

This is a Blazor Server application that demonstrates CRUD operations with best practices. The application uses Entity Framework Core, AutoMapper, and a clean architecture approach.

## Features

- **CRUD Operations**: Create, Read, Update, and Delete operations for products.
- **Entity Framework Core**: Database access using EF Core with a repository pattern.
- **AutoMapper**: Simplified object mapping between DTOs and entities.
- **Bootstrap**: Responsive and modern UI with Bootstrap.
- **Blazor Server**: Interactive and real-time data updates using Blazor's server-side model.

## Project Structure

- **BlazorCRUD.Application**: Contains DTOs and application-specific logic.
- **BlazorCRUD.Domain**: Contains entities and interfaces for repositories.
- **BlazorCRUD.Infrastructure**: Contains implementations of repositories and services.
- **BlazorCRUD.Components**: Contains Razor components and Blazor pages.

## Getting Started

### Prerequisites

- .NET 8 SDK
- SQL Server

### Setup

1. Clone the repository:
   ```bash
   git clone https://github.com/yuvaraj021/BlazorCRUD.git
