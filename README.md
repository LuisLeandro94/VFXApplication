# VFXApplication

## Getting started

### Visual Studio
Ctrl + F5 in order to run the app without the debugger.
This will prompt a dialog to open. Select Yes to trust the IIS Express SSL certificate.
Select Yes to trust the development certificate.
You can also debug the app by selecting the https button in the toolbar!

### Visual Studio Code
After opening your terminal and cd'ing into the project folder, trust the HTTPS development certificate by running the following command:

```
$ dotnet dev-certs https --trust
```
This will prompt a dialog to open. Select Yes to trust the development certificate.
Ctrl + F5 to run the app without debugging.
Visual Studio Code:
  - Starts Kestrel
  - Launches a browser
  - Navigates to url
