# ECommerceMini
  ECommerceMini is a sample e-commerce application demonstrating a modern microservices architecture built with .NET 8. The application showcases the integration of Blazor Web App for the frontend and Web API for backend services, leveraging Kafka for asynchronous messaging between services.

## Features
1. Blazor Web App:

 - A modern and interactive frontend built using Blazor WebAssembly.
 - Provides a seamless and responsive user experience.
 
2. Web API Backend:

 - Microservices-based backend developed with .NET 8 Web API.
 - Implements RESTful APIs for efficient communication.

3. Database Integration:

 - Uses Entity Framework Core with a code-first approach.
 - SQL Server is utilized as the database for reliable and scalable data storage.

4. Asynchronous Messaging:
   
 - Two services communicate using Apache Kafka as the message broker.
 - Enables reliable and efficient asynchronous communication between services.

## Architecture
The application is divided into the following components:
- Frontend:

  - Built with Blazor WebAssembly.
  - Communicates with backend APIs for fetching and displaying data.

- Backend:

  - Developed using .NET 8 Web API.
  - Contains microservices for handling specific tasks like product management, order processing, and messaging.
   
- Database:

  - Managed using Entity Framework Core (EF Core).
  - Code-first migrations for schema management.

- Messaging:
  - Apache Kafka is used for inter-service communication.
  - Ensures high throughput and fault-tolerant message delivery.

## Getting Started
1. Clone the Repository

``` bash
git clone https://github.com//pongsapak-suwa/ECommerceMini.git  
cd ECommerceMini  
```

2. Run Kafka Docker compose 

``` bash
docker compose up --build
```

3. Run the backend:

``` bash
dotnet run
```

## Usage
> Access the application at https://localhost:17221/ after running
