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

	Incase remove recent migrations
		-- dotnet ef migrations list
		-- dotnet ef migrations remove
		-- dotnet ef migrations list 
	
Architecture / project stucture
API
	-- Entities
		-- AppUser.cs
	-- Data
		-- DataContext.cs
		Migrations
	-- Dtos
		-- RegisterDto.cs
	--Extentions
		-- ApplicationServiceExtentions.cs
	-- Interfaces
		-- ITokenService.cs
	-- Services
		-- TokenService.cs
	Dockerfile
client
	

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
-- use cli to create new angular app 
-- angular project Files
-- added bootstrap
-- use https
-- add packages using NPM

Summary: End of section 4 : Authentication basics
-- Implement basic authentication and store password
-- Using inheritance in C# - DRY
-- Use C# debugger
-- Concepts of DTO's
-- Validations
-- JWT's token 
-- services in C#
-- Middleware in C#
-- Extenstions in C#

Summary: End of section 5 : Login and Registration in Angular
-- Creating components using angular cli
-- using angular template forms
-- angular services
-- obervables
-- structural directives
-- component communication - using input & output properties

Summary: End of section 6 : Anular Routing
-- Routing
-- Adding boottsrap theme
-- Route guard
-- Shared module

List Requirements
-- users should be able to login
-- users should be able to register
-- users should be able to view other users
-- users should be able to privetely message other users

Entity
	Users

How we can go and store user password (how Authentication works?)
	-- store password in clear text - bad idea?
	-- hasing the password - secure way but same password same hash created - again not good idea?
	-- hasing and salting password - Good idea more secure, better way of doing this.

Run app in Docker commands
	-- docker build -t datingapp .
	-- docker run --rm  -p 5000:5000 -p 5001:5001 -e ASPNETCORE_HTTP_PORT=https://+:5001 -e ASPNETCORE_URLS=http://+:5000 datingapp


import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
imports --> BsDropdownModule.forRoot()
	-- npm install ngx-bootstrap@latest --legacy-peer-deps


npm install bootswatch

End of the section 8
-- Entity framework relationship
-- Entity framework conventions
-- Seeding data into database
-- The repository pattern [Architecture pattern]
-- Use AutoMapper [Utility tool]

End of the section 9
-- Using Typescript
-- Using interceptor to send jwt token
-- using bootstrap for styling
-- basic css trick to inhanced look and feel
-- using 3rd party photo gallery
-- using route params