# .NET Core with MVC
Simple .NET Core project with MVC and Entity framework.

## Definition
Basic example of a web project created with .NET Core MVC.
Hope this example help others as point of reference to start learning programming with .NET Core and MVC.

## Project Definition
Book Store
- CRUD of Books.
- MVC architecture


## Basic Concepts
- MVC Routing: Allows the match between a particular request with an action in a particular controller defined on the route table.
- Endpoints: Allows to map controller routes by patterns. Middleware. Action maps to view.

## Creating our project
To create an MVC project follow next steps:
1. Add a new projet
    - Open Visual Studio --> New Project --> ASP.Net Core Web application --> MVC
    - Specify a name and path for the project
    - Click on create button.
2. Install Nuget packages
    - Microsoft.EntityFrameworkCore
    - Microsoft.EntityFrameworkCore.SqlServer
    - Microsoft.EntityFrameworkCore.Tools
    - Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation
    
3. Add New model named Book
    - Right-click in Model Folder
    - Add new class named Book
    - Add properties
    ```C#
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Author { get; set; }
    }
    ```
4. Add ApplicationDbContext
    - Right-click in Model Folder
    - Add new class named ApplicationDbcontext
    - Add Constructor
    ```C#
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {
    }    
    ```
    - Add DbSet table property
    ```C#
    public DbSet<Book> Books { get; set; }
    ```
5. Add ConnectionString into the appsetings.json
6. Add Service call to the DbContext in Startup.cs
```C#
services.AddDbContext<ApplicationDbContext>(options=>options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
```
7. Add database 
    - Add-migration in the Package Manager Console
    ```C#
    add-migration AddBookToDb
    ```
    - Update database in the Package Manager Console
    ```C#
    update-database
    ```
8. Add Controller
    - Right-Click on controller folder
    - Add new Controller named BookController
9. Add New folder Named Book in the Views folder
10. Add Book\Index View
    - Go to Book Controller
    - Right-click on the Index Method -- > Add View
11. Add link to the BookController in the __Layout.cshtml
12. Add Third parties
    - Add datatables.js
