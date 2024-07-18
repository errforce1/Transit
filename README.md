# Dotnet 5.0 Transit Application

## Overview

This repository contains a Dotnet 5.0 application. Upon running the project, the application will automatically generate and populate the database if it does not already exist. The repository also includes end-to-end (e2e) tests that can be executed using Cypress.

## Getting Started

### Prerequisites

- [dotnet 5.0 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
- [Node.js](https://nodejs.org/) (for running the e2e tests)

### Running the Application

1. **Clone the repository:**

   ```bash
   git clone https://github.com/errforce1/Transit.git
   cd Transit
   ```

2. **Restore the dotnet dependencies and run the application:**

   ```bash
   dotnet restore
   dotnet run --project Transit
   ```

   Running the application will:
    - Generate the database if it does not exist.
    - Populate the database with initial data.

### Running Unit Tests

 ```bash
   dotnet restore
   dotnet test
   ```

### Running End-to-End (e2e) Tests

The e2e tests are powered by [Cypress](https://www.cypress.io/).

1. **Install the required Node.js packages:**

   ```bash
   npm install
   ```

2. **Run the e2e tests:**

> **Note:** Ensure the Dotnet solution is running before executing the e2e tests.

   By default, the tests will run in headless Chrome.

   ```bash
   npm test
   ```

   If you prefer to run the tests in Firefox, use the following command:

   ```bash
   npm run test:cypress:e2e:ff
   ```

## Notes

- The application is intentionally minimal with abstractions exemplification purposes.
- The northbound and southbound routes have been combine into a single route.
- The route times are generated dynamically according to a M-F 6am to 9pm schedule.
  - The times enumerate the stops and ping-pong to generate a list of schedules.
- No validation is in place for input due to the simplistic nature of the exercise.
- No frontend libraries are consumed, everything is vanilla JS and browser native because the project did not necessitate a library or framework.
- The project doesn't utilize many explicitly selected design patterns that are not part of the project template outside of repository and dto.