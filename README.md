

# Manga Store

Manga Store is a comprehensive online platform built with ASP.NET Core 8, following the MVC pattern. The application provides a seamless user experience for browsing, purchasing, and managing manga collections. With robust authentication and admin capabilities, it’s designed to offer both regular users and administrators an intuitive and efficient interface.

## Features

- **User Interface**: Simple, elegant, and responsive design using Bootstrap, with features like advanced search and smooth navigation.
- **Authentication & Authorization**: Secure user login, registration, and role-based access powered by ASP.NET Core Identity.
- **Admin Panel**: Manage categories, products (manga), and orders with ease through a feature-rich admin dashboard.
- **Order Management**: Track order statuses from processing to shipping, with options to manage carriers and tracking numbers.
- **Manga Details**: Comprehensive manga detail pages with category listings and user reviews.

## Technologies

- **Front-End**:  
  - HTML, CSS, JavaScript
  - Bootstrap for responsive design
- **Back-End**:  
  - C#
  - ASP.NET Core 7 (MVC)
  - Entity Framework Core for database access
- **Database**:  
  - Microsoft SQL Server

## Design Patterns

- Repository Pattern
- Unit of Work Pattern
- Dependency Injection for efficient and maintainable code.

## Architecture

The project is structured with an **N-Tier Architecture**, separating concerns into:
- **Data Access Layer**: Manages database interaction using Entity Framework.
- **Business Logic Layer**: Handles business operations, validations, and logic.
- **Presentation Layer**: Manages user interaction via the MVC pattern.

## Getting Started with Docker

You can quickly run the application using Docker and Docker Compose.

### Prerequisites

- [Docker](https://www.docker.com/products/docker-desktop)
- [Docker Compose](https://docs.docker.com/compose/)

### Running the Application

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/Mo7ammedd/BookStore.git
   cd BookStore
   ```

2. **Build and Start Containers**:
   ```bash
   docker-compose up --build
   ```

   This command will:
   - Build the ASP.NET Core application.
   - Spin up a SQL Server database container.
   - Expose the application on port `5000`.

3. **Access the Application**:
   Open your browser and navigate to `http://localhost:5000`.

### Environment Variables

You can customize the environment variables in `docker-compose.yml`:

```yaml
environment:
  - ConnectionStrings__DefaultConnection=Server=sqlserver;Database=MangaStoreDB;User=sa;Password=Your_password123;
```

#
## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.

