ASP.NET Core API and Angular

dotnet --info
dotnet -h
dotnet new list
dotnet new sln
dotnet new webapi -o API
dotnet sln add .\API\
dotnet sln list
code .

Install packages via nuget
	-- NuGet Gallery
	-- Microsoft.EntityFrameworkCore.Design
	-- Microsoft.EntityFrameworkCore.Sqlite
	-- sqlite
	
Git
	-- git status
	-- git init
	-- dotnet new gitignore
	-- dotnet new globaljson -- To change SDK version
	-- git branch -M main
	-- git remote add origin https://github.com/vijaybabar268/2023-DatingApp.git
	-- Click git publish btn in vs code editor


.NET Core 7
	-- Web application framwork	

Entity Framework
	-- ORM tool
	-- Translate our code into sql commands that update our tables in the database.
	-- Write LINQ queries
	-- Provider SQLite, SQLServer
	-- Querying
	-- Change Tracking
	-- Saving
	-- Concurrency
	-- Automatic Transactions Management
	-- Caching
	-- Built-in conventions
	-- Confugurations
	-- Migrations (CodeFirst & DatabaseFirst)
	
Migrations
	-- dotnet tool list -g
	-- dotnet tool install --global dotnet-ef --version 7.0.5
	-- dotnet-ef
	-- dotnet ef migrations add InitialCreate -o Data/Migrations
	-- dotnet ef database update -v
	

API
	-- Entities
		-- AppUser.cs
	-- Data
		-- DataContext.cs
		Migrations
		
	
