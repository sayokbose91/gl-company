# Company Application

Company Application is a Single Page Application built with Angular (frontend) and ASP.NET Core (backend). It allows users to view, create, and manage company records.

## Table of Contents

- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Running the Application](#running-the-application)
- [Docker Setup](#docker-setup)
- [Database Setup](#database-setup)
- [Authentication and API Access](#authentication-and-api-access)
- [Testing](#testing)


## Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download)
- [Node.js](https://nodejs.org/) (v16 LTS recommended)
- [Angular CLI](https://angular.io/cli) (`npm install -g @angular/cli`)
- [Docker](https://www.docker.com/)

## Installation

### Backend (Company API)

1. **Clone the Repository:**
   ```bash
   git clone https://github.com/sayokbose91/Company.git
   cd gl-company/CompanyApi
   ```
2. **Restore and Build the API:**
   ```bash
   dotnet restore
   dotnet build
   ```

### Frontend (Company SPA)

1. **Navigate to the `company-spa` Folder:**
   ```bash
   cd ../company-spa
   ```
2. **Install Dependencies:**
   ```bash
   npm install --force
   ```

## Running the Application

### Locally

#### Backend (Company API)

From the `CompanyApi` folder:

```bash
   dotnet run
```

The API will typically be available at [http://localhost:8080](http://localhost:8080).

#### Frontend (Company SPA)

From the `company-spa` folder:

```bash
   ng serve
```

The SPA will be available at [http://localhost:4200](http://localhost:4200).

### Docker

The repository includes Dockerfiles for both the API and SPA along with a `docker-compose.yml` file.

1. **Build and Start the Containers:**
   ```bash
   cd gl-company/deploy
   docker-compose up --build
   docker compose up --build //if using latest docker compose
   ```
2. **Access the Application:**
   - **API:** [http://localhost:8080](http://localhost:8080) (and/or port 8081)
   - **SPA:** [http://localhost:4200](http://localhost:4200)
   - Db takes roughly 3-4 mins to start. (As it configues and seeds data) wait till you dont see "Database configuration and seeding completed." in db container log.


## Database Setup

The database is set up as a container and includes seeding of initial data. The `docker-compose.yml` file for this setup is located in the `deploy` folder under the project root.

### Steps to Set Up the Database:

1. **Ensure Docker is Running**
2. **Navigate to the `deploy` folder:**
   ```bash
   cd deploy
   ```
3. **Run the database container:**
   ```bash
   docker-compose up
   ```
4. **Check Container Logs for Confirmation:**
   Run the following command to ensure database configuration and seeding have been completed successfully:
   ```bash
   docker logs <container_id>
   ```
   You should see the message:
   ```
   Database configuration and seeding completed.
   ```

### Running with LocalDB

If running locally without Docker, update the `appsettings.json` connection string to use LocalDB:

```json
"ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=gldb;User Id=gldbuser;Password=password;Encrypt=false;"
}
```

1. **Open LocalDB in SQL Server Management Studio (SSMS).**
2. **Execute the `local-db-script.sql`** located in the `deploy` folder. This script:
   - Creates necessary tables.
   - Seeds initial data.
   - Creates a user `gldbuser` for the connection.

## Authentication and API Access

The API has a Swagger endpoint to view available API endpoints and test them.

- **Swagger UI:** Access it at:
  ```
  http://localhost:8080/swagger
  ```
- **JWT Authentication:** API endpoints are secured with JWT authentication.
- **Generating a JWT Token:** Use the `TokenGenerator` console application to generate a valid JWT token (valid for 1 hour). The token will be printed in the console output.

## Testing

### Backend Tests

From the solution root or within the `CompanyApi` folder:

```bash
   dotnet test
```

