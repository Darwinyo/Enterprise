# Multi Platform Apps
 
## What is this app?

This App is E-Commerce App
 
## Why E-Commerce?

Well, I want to give all my best into 1 Solution,
Since E-Commerce itself can be really Complex (use variaties tech stack), i think this would fit for my playground.
 
## (Currently) What tech stack required to build this app? 

### Database

* MSSQL
* MongoDB
* Redis
 
### Back-End

* C#
* .NET Core 2.0
* .NET Framework 4.6
* .NET Standard 2.0
* API(Both Frameworks)
* LINQ, SignalR(Core)
* Workflow Foundation (.Net Framework)
* Razor Page
* EntityFramework(Both Frameworks)
 
### Front-End

* TypeScript
* Angular4
* Webpack
* @ngrx/Store(Inspired by Redux)
* @ngrx/Router-store
* @ngrx/Effects
* ReactiveX(RxJs)
 
### Mobile
* Xamarin.Forms
 
## The structure of projects

We can separate into 5 big modules

* Backend
  * Enterprise.Core (DataAccess (EF Core)) => .NET Standard 2.0 Libraries
  * Enterprise.Framework  (Data Access (EF Framework)) => .NET Framework 4.5 Libraries
  * Enterprise.API => .NET Core 2.0
  * Enterprise.Workflows => .NET Framework 4.5 Libraries
  * Enterprise.SignalR => .NET Standard 2.0
  
* SPA
  * Enterprise.Web.SPA (Angular4)
  
* MPA
  * Enterprise.Web.MPA (.Net Core 2.0 Razor Pages)
  
* DB
  * Enterprise.MSSQL
  * Enterprise.Redis
  * Enterprise.MongoDB
  
* Mobile
  * Enterprise.Mobile (Xamarin.Forms)

## Projects Roles

* DB : [More Details](https://github.com/Darwinyo/Enterprise/tree/master/Enterprise.Database)
* SPA : [More Details](https://github.com/Darwinyo/Enterprise/tree/master/Enterprise.Web.SPA)
* MPA : [More Details](https://github.com/Darwinyo/Enterprise/tree/master/Enterprise.Web.MPA)
* Mobile : [More Details](https://github.com/Darwinyo/Enterprise/tree/master/Enterprise.Mobile)
* Backend : [More Details](https://github.com/Darwinyo/Enterprise/tree/master/Enterprise.Backend)

