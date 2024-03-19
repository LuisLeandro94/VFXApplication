# VFXApplication
This project is built with ASP.NET Core MVC

## Prerequisites
Before running this project, ensure that you have the following installed:

[.NET Core SDK](https://dotnet.microsoft.com/download)

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
- **Services:** Contains service classes that handle various application logic.
- **wwwroot:** Contains static files such as CSS, Javascript and images.
- **Program.cs:** Configures services and the request pipeline.
- **DependencyInjection.cs:** Contains service registration logic using ASP.NET Core's built-in dependency injection.

## License

This project is licensed under the MIT License. See the [License](https://github.com/git/git-scm.com/blob/main/MIT-LICENSE.txt) file for details.
