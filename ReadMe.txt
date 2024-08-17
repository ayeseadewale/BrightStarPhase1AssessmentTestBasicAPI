Event Management System - Phase 1 (API) Project Setup
Step 1: Clone the Repository
1.	Clone the repository from GitHub to your local machine using the following command:
git clone < https://github.com/ayeseadewale/BrightStarPhase1AssessmentTestBasicAPI.git>
2.	Navigate to the project directory:
cd EventManagementSystemAPI
Step 2: Configure the Database Connection
1.	Open the project in Visual Studio 2022 (or Visual Studio Code).
2.	Locate the appsettings.json file in the root of the project.
3.	Update the ConnectionStrings section with your SQL Server credentials.
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=EventManagementDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}
o	Replace YOUR_SERVER_NAME with your SQL Server instance name.
o	If you're using SQL Server authentication, replace Trusted_Connection=True with User Id=<YourUsername>;Password=<YourPassword>.
Step 3: Apply Migrations and Seed the Database
1.	Open the Package Manager Console in Visual Studio by navigating to Tools > NuGet Package Manager > Package Manager Console.
2.	Run the following command to apply migrations and create the database:
Update-Database
This will create the EventManagementDB database and apply the necessary tables.
Step 4: Run the Application
1.	In Visual Studio 2022, press F5 or click on the Run button to start the application. This will launch the API on your local machine.
2.	By default, the API should be running at https://localhost:5001 (HTTPS) and http://localhost:5000 (HTTP).
Step 5: Test the API Endpoints
1.	Using Postman: You can use Postman to send HTTP requests to the API and validate the responses.
o	Login Endpoint:
	URL: POST https://localhost:5001/api/login
	Request Body (JSON):
{
  "serviceId": 1,
  "password": "your_password"
}
o	Subscribe Endpoint:
	URL: POST https://localhost:5001/api/subscription/subscribe
	Request Body (JSON):
{
  "serviceId": 1,
  "tokenId": "your_token",
  "phoneNumber": "1234567890"
}
o	Unsubscribe Endpoint:
	URL: POST https://localhost:5001/api/subscription/unsubscribe
	Request Body (JSON):
{
  "serviceId": 1,
  "tokenId": "your_token",
  "phoneNumber": "1234567890"
}
o	Check Status Endpoint:
	URL: POST https://localhost:5001/api/subscription/check-status
	Request Body (JSON):
{
  "serviceId": 1,
  "tokenId": "your_token",
  "phoneNumber": "1234567890"
}
2.	Using Swagger: The project has built-in Swagger for testing the API endpoints.
o	Once the application is running, navigate to https://localhost:5001/swagger in your browser.
o	You can use the Swagger UI to interact with the API and send requests to different endpoints.
Step 6: Project Structure Overview
1.	Controllers: The API endpoints are defined in the Controllers folder. Each controller handles different operations like login, subscription, etc.
2.	Repositories: The data access logic is encapsulated in repository classes under the Repositories folder. This follows the Repository pattern, providing a clean separation between business logic and data access.
3.	Models: The domain models, such as Service, Subscriber, and Token, are defined in the Models folder. These models represent the entities in the database.
4.	Data: The ApplicationDbContext.cs file in the Data folder defines the database context and manages the entity sets (tables).
Step 7: Configuration of Expiration Time for Tokens
The expiration time for tokens is configurable in the database. You can update the expiration hours in the Tokens table after generating tokens or implement a configurable setting in the appsettings.json and use it while generating the token in the LoginController.

