# MusicDatabase API :musical_note:

This project is able to manage your songs, artists, albums and more by RESTful API. Developed with ASP.NET Core 2.0 &amp; EF Core and used PostgreSQL Database Provider. Implemented Swagger to project.

## Getting Started

First of all, you need to clone the project to your local machine

```
git clone https://github.com/sinemhasircioglu/MusicDatabase-API.git
cd MusicDatabase-API
```

### Building

A step by step series of building that project

1. Restore the project :hammer:

```
dotnet restore
```

2. Change connection string of Database (File: appsettings.Development.json, Line: 3)

3. If you want to use change Database Provider to MS SQL, MySQL etc... You can change on Startup.cs File (Line: 33)

```
    //For Microsoft SQL Server
    options.UseSqlServer(Configuration.GetConnectionString("MusicDbConnectionString"));
```

4. Run EF Core Migrations

```
dotnet ef database update
```

5. Run the project and Enjoy! :bomb:

```
dotnet run
```
## Demo

You can try it on [this demo link.](http://musicdatabase.azurewebsites.net/swagger/) :gun:

## Built With

* [.NET Core 2.0](https://www.microsoft.com/net/) 
* [Entitiy Framework Core](https://docs.microsoft.com/en-us/ef/core/) - .NET ORM Tool
* [NpgSQL for EF Core](http://www.npgsql.org/efcore/) - PostgreSQL extension for EF 
* [Swagger](https://swagger.io/) - API developer tools for testing and documention

## Contributing

* If you want to contribute to codes, create pull request
* If you find any bugs or error, create an issue

## License

This project is licensed under the MIT License
