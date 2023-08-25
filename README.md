# Library Exercise with Docker

This repository contains a .NET application that serves as a library management system, upgraded to have a RESTful API along with a Console UI with an actionable menu. The application is designed to run both locally and within a Docker container, providing flexibility for development and deployment.
This example does not require you to have Docker installed since you can run it locally, but I'm also including a dockerfile basic configuration so you can run it on a Container. I highly advice you to do that so you can practice Docker playing around with this exercise.

## Features

- RESTful API with exposed endpoints with CRUD operations for books
- Clean architecture design.
- Command Pattern for user interactions (CONSOLE APP - LEGACY).
- Repository Pattern and the use of an In-Memory database for data handling
- Default books added through a Seed operation
- Docker support for easy deployment.

## Prerequisites

- .NET SDK (version 7 or higher)
- Docker (if you want to run the application in a container)

## Running the Application Locally

1. **Clone the repository**:
   ```bash
   git clone https://github.com/marcelomusza/LibraryExerciseAPIWithDocker.git
   ```

2. **Navigate to the project directory and build the solution**:
   ```bash
   cd LibraryExerciseAPIWithDocker
   dotnet build
   ```

3. **Run the application**:
   ```bash
   dotnet run --project .\LibraryExercise.API\LibraryExercise.API.csproj
   ```   

## Running the Application in Docker

NOTE: The dockerfile configuration is pointing to a default published version of the ConsoleUI project, which you might not have until you publish the Application on your end. Feel free to update these values to make them working for your environment

1. **Build the Docker image**:
   ```bash
   docker build -t libraryexercise .
   ```

2. **Run the Docker container**:
   ```bash
   docker run -d -p 8080:80 --name library_container libraryexercise
   ```

## Contributing

Feel free to fork this repository, make changes, and submit pull requests. If you have any issues or feature requests, please submit them through the GitHub issues page.
