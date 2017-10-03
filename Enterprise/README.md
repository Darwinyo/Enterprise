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

Back-End : C#, .NET Core 2.0,.NET Framework 4.6,.NET Standard 2.0, API(Both Frameworks), LINQ, SignalR(Core), Workflow Foundation (.Net Framework), Razor Page
EntityFramework(Both Frameworks)

Front-End: TypeScript, Angular4, Webpack, @ngrx/Store(Inspired by Redux), @ngrx/Router-store, @ngrx/Effects, ReactiveX(RxJs)

Mobile : Xamarin.Forms

The structure of projects:
we can separate into 4 big modules:
- Backend : all projects in https://github.com/Darwinyo/Enterprise/tree/master/Enterprise
(except SPA, MPA, Mobile)
- SPA : Enterprise.Web.SPA (Angular4)
- MPA : Enterprise.Web.MPA (.Net Core 2.0 Razor Pages)
- DB : Enterprise.Database, Enterprise.Redis, Enterprise.MongoDB
- Mobile : Enterprise.Mobile (Xamarin.Forms)
Currently the projects structure in big mess. i'll fix it near future.

Projects Roles:

-DB : This Kinds of Project (as mentions above) only for dump data / sync with current db schema.

-SPA : /GOTO THIS DOC/
-MPA : /GOTO THIS DOC/
-Mobile : /GOTO THIS DOC/
- Backend : We can separate again this project into 6 pieces
-- API Core : this API is responsible for every transaction(expose to outer world), also has responsible for bypassing some request (that can't be done with .Net Core) to API Framework
-- API Framework : This API is only responsible for Invoking Workflow. and fill some feature gaps (that can't be done with .Net Core) /GOTO THIS DOC/
-- SignalR : this project has its own world, this project only responsible for SignalR related stuffs /GOTO THIS DOC/
-- .Net Core DataAccess : these projects using .Net Standard 2.0 , also implements Unit of works Patterns, Repositories Patterns.
/GOTO THIS DOC/
-- Workflows: Workflows Project has all things about WF, such as Activities Codes, Workflows designs./GOTO THIS DOC/
-- .Net Framework DataAccess : Since workflow can generate errors for adding .net standard reference. so this project is only intended for workflow data access. /GOTO THIS DOC/
