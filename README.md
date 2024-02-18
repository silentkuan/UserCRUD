
# User Management MVC Application

This project is a simple ASP.NET Core MVC application for managing user data using a Web API.

## Introduction

The User Management MVC Application provides a user interface for performing basic CRUD (Create, Read, Update, Delete) operations on user data. It interacts with a Web API to retrieve and manipulate user resources without relying on a database.

## Features

- Create a new user
- View a list of users retrieved from the Web API
- View details of a single user retrieved from the Web API
- Edit an existing user
- Delete a user

## Technologies Used

- ASP.NET Core 8.0
- Razor views
- ASP.NET Core Web API (for data retrieval)

## Getting Started

To run the project locally, follow these steps:

1. Clone this repository to your local machine.
2. Open the solution in Visual Studio.
3. Ensure that the ASP.NET Core Web API project is running and accessible. If not, follow the instructions in the Web API project's README file to set it up and run it.
4. Build and run the ASP.NET Core MVC project in Visual Studio.

Once the project is running, you can navigate to the user management interface in your web browser and start using the application to manage user data.

## Controllers and Views

The project contains the following controllers:

- `HomeController`: Handles the home page and error views.
- `UserController`: Handles user-related views and actions, including Create, Read, Update, and Delete operations.

