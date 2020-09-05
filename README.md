# General
Solution includes two projects: A Web API and a Web App those created as ASP.NET Core Version 2.2
After you pulled or download this repository you can build the solution and make some changes for your system.
# Web API (TestDevWebService)
API is a .Net Core Web API project and it provides User-Item-Property data to the web app from it's own db. Web API includes Swashbuckle.AspNetCore package (Swagger tool for .Net Core) and it has a user guide for how to use.
# Web App
Web app was created as .Net Core Web App that includes a login page and a user page to show user-item information (gets from web api) depends on the active user role. (app has a direct access for user and role entities from another db) 

# Common Features
Both projects created as .Net Core apps and coded with C# and uses EF Core as ORM tool with code first approach for Ms Sql (until you change). Projects have seed methods for db migrations. 
For setting up the solution please follow this steps:
- Open the solution that you have downloaded or pulled.
- VS will install the packages for dependencies. Build solution.
- Connection strings are in appsettings.json:

   "ConnectionStrings": {
    "DevConnection": "Server=(localdb)\\MSSQLLocalDB;Database=TestWebApp;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
  
  and
  
  "ConnectionStrings": {
    "DevConnection": "Server=(localdb)\\MSSQLLocalDB;Database=UserWebApp;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
  
  You may change whereever you want to store the seed data.

+++++++++++++++++++++++++++++++++++++++++++++++++

- For using MySql, open Nuget Package Manager Console and run this 

  Install-Package MySql.Data.EntityFrameworkCore -Version 8.0.11
 
 - In Startup.cs files you can change db type registration inside of ConfigureServices method as
 
   services.AddDbContext<TestWebAppContext>(options =>
          options.UseMySQL(Configuration.GetConnectionString("DevConnection"))
   );
   
+++++++++++++++++++++++++++++++++++++++++++++++++

- On Package Manager Console select Default project as TestDevWebService and run these commands
  
  Add-Migration InitialForWebAPI
  Update-Database
  
  those are going to create our tables and related data.
  
- Repeat the previous step for TestDevWebApp project on PM Console (migration may be InitialForWebApp)
- Web app needs up and running Web API. So, on solution properties under Common Properties/Startup Project choose Multiple Startup projects, set both project as Start (or Start without debugging).
