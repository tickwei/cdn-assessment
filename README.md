# CDN Freelancer Directory API

This project is a RESTful API built using ASP.NET Core and Entity Framework Core, designed to manage a directory of freelancers for the fictional company "Complete Developer Network" (CDN).  <br />
The API allows for creating, reading, updating, and deleting user records, including their skillsets and hobbies. The data is stored in a SQLite database.

## Table of Contents

- [Installation](#installation)
- [Database Setup](#database-setup)
- [Running the Application](#running-the-application)
- [API Endpoints](#api-endpoints)
- [Testing the API](#testing-the-api)
- [Project Structure](#project-structure)
- [Technologies Used](#technologies-used)

## Installation

1. **Clone the Repository:**
   bash
   git clone https://github.com/tickwei/cdn-assessment.git
   
   
2. **Navigate to the Project Directory:**
   bash
   cd cdn-assessment
   

3. **Install Dependencies:**
   - Open the project in Visual Studio.
   - Restore NuGet packages by building the solution (`Ctrl + Shift + B`) or by running:
     bash
     dotnet restore
     

4. **Ensure SQLite is set up correctly:**
   - The project is configured to use SQLite. The database file `CDNFreelancerDirectory.db` will be created automatically in the project directory when the application runs.


## Database Setup

The project uses Entity Framework Core with SQLite as the database provider. The database is automatically created when you run the application for the first time.

### Applying Migrations

If you need to apply migrations manually, follow these steps:

1. **Create the Initial Migration (if not already done):**
   bash
   dotnet ef migrations add InitialCreate -Context AppDbContext
   

2. **Update the Database:**
   bash
   dotnet ef database update -Context AppDbContext
   

The `CDNFreelancerDirectory.db` file will be created in the root directory of the project.


## Running the Application

To run the application locally:

1. **In Visual Studio:**
   - Press `F5` or click on the "Run" button.

2. **Using the .NET CLI:**
   bash
   dotnet run
   

The application will start, and the API will be accessible at `https://localhost:{port}/api/users` (replace `{port}` with the actual port number).


## API Endpoints

The following endpoints are available in the API:

### Get All Users
- **Endpoint:** `GET /api/users`
- **Description:** Retrieves a list of all users.
- **Response:** `200 OK` with a JSON array of user objects.

### Get a User by ID
- **Endpoint:** `GET /api/users/{id}`
- **Description:** Retrieves a single user by their ID.
- **Response:** `200 OK` with the user object or `404 Not Found` if the user does not exist.

### Create a New User
- **Endpoint:** `POST /api/users`
- **Description:** Creates a new user.
- **Request Body:** JSON object containing `Username`, `Email`, `PhoneNumber`, `Skillsets`, and `Hobbies`.
- **Response:** `201 Created` with the created user object.

### Update an Existing User
- **Endpoint:** `PUT /api/users/{id}`
- **Description:** Updates an existing user's details.
- **Request Body:** JSON object with updated `Username`, `Email`, `PhoneNumber`, `Skillsets`, and `Hobbies`.
- **Response:** `200 OK` with the updated user object or `404 Not Found` if the user does not exist.

### Delete a User
- **Endpoint:** `DELETE /api/users/{id}`
- **Description:** Deletes a user by their ID.
- **Response:** `204 No Content` or `404 Not Found` if the user does not exist.


## Testing the API

You can test the API using tools like Postman or cURL.

### Example with cURL:

- **Get All Users:**
  bash
  curl -X GET https://localhost:{port}/api/users
  

- **Create a New User:**
  bash
  curl -X POST https://localhost:{port}/api/users -H "Content-Type: application/json" -d "{\"Username\":\"JohnDoe\",\"Email\":\"john@example.com\",\"PhoneNumber\":\"1234567890\",\"Skillsets\":[\"C#\",\"SQL\"],\"Hobbies\":[\"Reading\",\"Gaming\"]}"
  

- **Update an Existing User:**
  bash
  curl -X PUT https://localhost:{port}/api/users/{id} -H "Content-Type: application/json" -d "{\"Username\":\"JaneDoe\",\"Email\":\"jane@example.com\",\"PhoneNumber\":\"0987654321\",\"Skillsets\":[\"Java\",\"Python\"],\"Hobbies\":[\"Traveling\",\"Cooking\"]}"
  

- **Delete a User:**
  bash
  curl -X DELETE https://localhost:{port}/api/users/{id}
  

Replace `{port}` with the port your application is running on and `{id}` with the user's ID.


## Project Structure

Here is an overview of the main folders and files in the project:


CDNFreelancerDirectory/ <br>
│<br>
├── Controllers/<br>
│   └── UsersController.cs         # Handles API requests<br>
│<br>
├── Data/<br>
│   └── AppDbContext.cs            # EF Core database context<br>
│<br>
├── Models/<br>
│   └── User.cs                    # User model<br>
│<br>
├── Services/<br>
│   ├── IUserService.cs            # User service interface<br>
│   └── UserService.cs             # User service implementation<br>
│<br>
├── Migrations/                    # EF Core migrations<br>
│<br>
├── appsettings.json               # Configuration settings<br>
│<br>
└── Program.cs                     # Program entry point and DI configuration<br>



## Technologies Used

- **ASP.NET Core**: Web framework for building the API.
- **Entity Framework Core**: ORM for database access.
- **SQLite**: Lightweight database engine.
- **C#**: Programming language used for development.
- **GitHub**: Version control and repository hosting.

