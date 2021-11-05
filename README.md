# CovidPCR-App

A Covid 19 test management system developed using Aurelia Framework,.NET Core(5.0), EntityFrameworkCore.InMemory, Bootstrap.

# Architecture

This app is developed following the Onion Architecture and uses the CQRS Pattern 

Follow the steps below to run the application:

In order to use this application, you will need Aurelia CLI, .NET 5 and NodeJs (10 or above).

To install Aurelia CLI : run "sudo npm install -g aurelia-cli" on terminal for MacOS or run "npm install -g aurelia-cli" on Command prompt for windows.

# TO START API:

 Navigate to the API folder to start the API befrore running the client
 then run 'dotnet build' to build it
 then run 'dotnet run' to start it

# TO START CLIENT:

 Navigate to the client folder to start the API befrore running the client
 then run 'npm install' to install
 then run 'npm start' to start the service


# APPLICATION GUIDE:
To begin using the application, Here are a few steps:

* The USER or ADMIN is required to register. it also shows already registered users on page load
  http://localhost:8080

* only ADMIN can create a new location or update a location and available spaces. 
Note: the user id is always the row number of the admin user from the users table.
  http://localhost:8080/location  

* Admin can select a location and update (also shows details of the location)
  http://localhost:8080/locationList 

* users are expected to book a test using this link
  http://localhost:8080/booking  

* Details about a booking are available on this page, Admin can select a booking and update the test result.
  http://localhost:8080/bookingList   

* Reports on the bookings
  http://localhost:8080/report   


  
Developer : Herbert Onuoha 

