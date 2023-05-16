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

Angular


Angular Versions
	-- node --version
		v18.16.0
	-- npm --version
		9.5.1

Start with angular
	-- npm install -g @angular/cli@14
	-- ng version

Create new angular App
	-- ng new client
	-- routing (y)
	-- css (select)

Run new angular App
	-- ng serve

Angular Extension
	-- Angular language service

Other packages
	-- npm install ngx-bootstrap
	-- npm install bootstrap@5
	-- npm install font-awesome

Angular goes to https
	--
		
Summary: End of section 2 : WebAPI
-- use cli to create sln and project
-- API Controllers and Endpoints
-- Entity Framework
-- API project structure
-- Configguration & Envionment variables
-- Source control github	

Summary: End of section 3 : Angular
-- 