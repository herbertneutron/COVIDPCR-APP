# CovidPCR-App

A Web Application built using Aurelia Framework, ASP.NET Core, EntityFrameworkCore.InMemory, Bootstrap and FluentValidation.

## Architecture

The Project is largely inspired by the Clean Architcture also known
as [Onion Architectue] and uses the [Command Query Responsibility Segregation (CQRS) Pattern] 

Follow the steps below to run the application:

# Prerequisities:
In order to use this application, you will need Aurelia CLI, .NET 5 and NodeJs.

If you don't have any, kindly install the following

1. Install NodeJS version 10 or above.

2. Install .NET 5 

3. run "sudo npm install -g aurelia-cli" on terminal for MacOS or run "npm install -g aurelia-cli" on Command prompt for windows.

# API:
To startup the API project, follow these steps:

* Navigate to the [src.API](src/API) project folder
  `cd ..`
  `cd API`
  `dotnet build`
* Startup the API project
  `dotnet run`

# CLIENT:
To startup the CLIENT project, follow these steps:

* Navigate to the [client](client) project folder
  `cd client`
* Run the code below to install dependencies.
  `npm install`  
* Startup the CLIENT project
  `npm start`

# APPLICATION GUIDE:
To begin booking on the application, Here are a few steps:

* The USER or ADMIN is required to register. it also shows already registered users on page load
  `http://localhost:8080` 

* only ADMIN can create a new location or update a location and available spaces. 
Note: the user id is always the row number of the admin user from the users table.
  `http://localhost:8080/location`  

* Admin can select a location and update(also shows details of the location)
  `http://localhost:8080/locationList` 

* users are expected to book a test using this link
  `http://localhost:8080/booking`  

* Details about a booking are available on this page. Admin can select a booking and update the test result.
  `http://localhost:8080/bookingList`   

* Reports on the available resources and necessary data
  `http://localhost:8080/report`    
  
Developer : Herbert Onuoha

