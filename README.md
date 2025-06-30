#  Freelancer Manager API – ETIQA Backend Assessment (June 2025)
 
This is a backend developer assessment project for ETIQA IT.  
It allows managing freelancer data using a RESTful Web API built with ASP.NET Core, and a clean, neat HTML interface for interaction.
 
---
 
##  Technologies Used
 
- ASP.NET Core Web API (.NET 8)
- Entity Framework Core
- Clean Architecture Design
- SQL Server (via EF Core Migrations)
- Bootstrap (for frontend UI)
- JavaScript (AJAX)
- xUnit & Moq (Unit Testing)
 
---
 
##  Project Structure

FreelancerManager/
**Domain/ # Information of user (Freelancer, Skillset, Hobby)
**Application/ # Interfaces & services (Data, validation, business logic)
**Infrastructure/ # EF DbContext, Repositories
**WebAPI/ # REST Controllers, Dependency Injection, Startup config
**Tests/ # Unit Tests using xUnit and Moq

----------------------------------------------------------------------------

## Features Implemented
 
| Feature                       | Status |
|-------------------------------|--------|
| Add, Edit, Delete Freelancer  |  Done  |
| Archive/Unarchive Freelancer  |  Done  |
| Wildcard Search (name/email)  |  Done  |
| Clean Architecture            |  Done  |
| One-to-Many Skillsets/Hobbies |  Done  |
| Unit Tests (xUnit + Moq)      |  Done  |
| Frontend (HTML/Bootstrap)     |  Done  |
| Swagger API Explorer          |  Done  |
 
-----------------------------------------------------------------------------------
 
## API Endpoints
 
| Method | Endpoint                            | Description                    |
|--------|-------------------------------------|--------------------------------|
| GET    | `/api/freelancer`                   | List all freelancers           |
| GET    | `/api/freelancer/search?keyword=`   | Search by username/email       |
| POST   | `/api/freelancer`                   | Add a new freelancer           |
| PUT    | `/api/freelancer/{id}`              | Update freelancer info         |
| DELETE | `/api/freelancer/{id}`              | Delete a freelancer            |
| PATCH  | `/api/freelancer/{id}/archive`      | Archive a freelancer           |
| PATCH  | `/api/freelancer/{id}/unarchive`    | Unarchive a freelancer         |
 
> You can test these endpoints using Swagger at `http://localhost:5233/swagger`
 
---
 
##  Frontend UI (Optional but Done)
 
- Located in: `WebAPI/wwwroot/FreelanceInfo.html`
- Use a browser to open:  
`http://localhost:5233/FreelanceInfo.html`
- Includes form to add freelancers, table list, and delete button.
 
---
 
##  Unit Testing
 
Test project located in `/Tests` folder using:
- `xUnit` for test framework
- `Moq` for mocking service dependencies
 
Run tests:
``bash
cd Tests
dotnet test

 
** How to Run the Project
 git clone https://github.com/ftninhnan/FreelancerManager.git
cd FreelancerManager
 
# Apply database migration
dotnet ef database update --project Infrastructure --startup-project WebAPI
 
# Run the API
dotnet run --project WebAPI

# Html Interface
http://localhost:5233/FreelanceInfo.html

Display all freelancer data and add a new freelancer

# For API Testing
http://localhost:5233/swagger

** GitHub & GitFront Submission

GitHub profile: https://github.com/ftninhnan
