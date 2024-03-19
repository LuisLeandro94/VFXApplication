# VFXApplication
This project is built with ASP.NET Core MVC

## Prerequisites
Before running this project, ensure that you have the following installed:

-[.NET Core SDK](https://dotnet.microsoft.com/download)

## Getting Started

To run this project locally, follow these steps:

1. Clone this repositry to your local machine:

  ```bash
  git clone https://github.com/luisleandro94/vfxapplication.git
  ```

2. Navigate to the project directory:

  ```bash
  cd your-repository
  ```

3. Build the project:

  ```bash
  dotnet build
  ```

4. Run the project:

  ```bash
  dotnet run
  ```

5. Open your web browser and navigate to `https://localhost:5001` to view the application.

## Default User Credentials

The default user credentials for accessing the application are as follows:

- **ClientID:** admin
- **UserID:** admin
- **Password:** vfxfinancial

You can use these credentials to log in to the application and explore its features.

## Project Structure

The project structure is as follows:

- **Controllers:** Contains controllers classes that handle incoming requests.
- **Models:** Contains model classes that represent data in the application.
- **Views:** Contains view files (Razor files) that define the user interface of the application.
- **wwwroot:** Contains static files such as CSS, Javascript and images.
- **Program.cs:** Configures the request pipeline.
- **DependencyInjection.cs:** Configures the services. Is then injected into **Program.cs**.
