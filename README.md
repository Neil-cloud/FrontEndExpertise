# Developing Front-End Expertise Assignment

## Setup

This project uses SQL Server to store local user account data. Perform the following steps to setup the backend DB:

1. Clone the project
2. Open the project directory in VS Code / Open the project in Visual Studio
3. In VS Code, run this command

    ```.NET Core CLI
    dotnet ef migrations add InitialCreate
    dotnet ef database update
    ```

    In Visual Studio, in the package manager console, run these commands:

    ```PowerShell
    Add-Migration InitialCreate
    Update-Database
    ```

    These steps will create a database and apply the schema we will be using
4. Add data to the database - Server name for SSMS - (localdb)\mssqllocaldb. You can either use the sample data CSV files provided or enter the data yourself. Be sure to enter data for the Users, Roles and UserClaims tables.
