# Enterprise.Backend
Backend
Enterprise.Backend

## The structure of projects

We can separate into 5 big modules

- Backend 
  - Enterprise.API
    - Enterprise.API
    - Enterprise.API.Helpers
    - Enterprise.API.Models
  - Enterprise.Framework
    - Enterprise.Framework.DataLayers
    - Enterprise.Framework.DataLayers.DTOs
    - Enterprise.Framework.Repository
    - Enterprise.Framework.BusinessLogics
  - Enterprise.Workflows
    - Enterprise.Workflows
    - Enterprise.Workflows.Clients
    - Enterprise.Workflows.Invoker
    - Enterprise.Workflows.Helpers
    - Enterprise.Workflows.Models
  - Enterprise.SignalR 
    - Enterprise.SignalR
  - Enterprise.Core
    - Enterprise.Core.BusinessLogics
    - Enterprise.Core.DataLayers.DTOs.Models
    - Enterprise.Core.DataLayers.DTOs
    - Enterprise.Core.DataLayers
    - Enterprise.Core.Repository
    - Enterprise.Core.Services


## Projects Roles
### Enterprise.API
### Enterprise.API.Helpers
### Enterprise.API.Models  
### Enterprise.Framework.DataLayers
### Enterprise.Framework.DataLayers.DTOs
### Enterprise.Framework.Repository
### Enterprise.Framework.BusinessLogics
### Enterprise.Workflows
### Enterprise.Workflows.Clients
### Enterprise.Workflows.Invoker
### Enterprise.Workflows.Helpers
### Enterprise.Workflows.Models
### Enterprise.SignalR 
### Enterprise.Core.BusinessLogics
### Enterprise.Core.DataLayers.DTOs.Models
### Enterprise.Core.DataLayers.DTOs
### Enterprise.Core.DataLayers
### Enterprise.Core.Repository
### Enterprise.Core.Services

- Backend : We can separate again this project into 6 pieces
-- API Core : this API is responsible for every transaction(expose to outer world), also has responsible for bypassing some request (that can't be done with .Net Core) to API Framework
-- API Framework : This API is only responsible for Invoking Workflow. and fill some feature gaps (that can't be done with .Net Core) /GOTO THIS DOC/

-- SignalR : this project has its own world, this project only responsible for SignalR related stuffs /GOTO THIS DOC/

-- .Net Core DataAccess : these projects using .Net Standard 2.0 , also implements Unit of works Patterns, Repositories Patterns.
/GOTO THIS DOC/

-- Workflows: Workflows Project has all things about WF, such as Activities Codes, Workflows designs./GOTO THIS DOC/

-- .Net Framework DataAccess : Since workflow can generate errors for adding .net standard reference. so this project is only intended for workflow data access. 

.NET API : has 5 layers. 
- DataLayers.DTO this project only storing DTO models. which that useful for selecting item that i only want small piece of colomn,or avoid serialize obj error since my db schema all has relationship.
- DataLayers.DTOs.Models this project is model for inner select.
- DataLayers this project is EF project. also i have define mongodb entity in this project.
- Repository this project is the boiler plate for select, insert, delete, update data in DataLayers. this has abstraction for one entity. and also have abstraction for every tbl in that entity.
- Business Logic this layer role is for having some logic for select, insert, anything in DataLayers
- Services this Layer could possibly to call Workflow Client (Become Proxy for Framework API) or calling BusinessLogic
- API this Layer only able to calling services. in this project we define our abstraction that we define in every project for Dependencies Injection Purpose (In Startup.cs). also we calling our Caching system in this project.
- Models is for storing Hubs(SignalR), Responses(Comes from Workflow clients),Settings(MongoDB) POCOs
- Helpers has Consts items for strong typings sake (Avoid Magic Strings), ProxyAPI(Abstract Class for services would like to call inner API).

SignalR
- SignalR this project only  store hubs, and its abstractions

Workflow: has 6 layers
- Framework.Datalayer.DTO : similar like above.
- Framework.Datalayer : This project has same as Datalayer but this project is in .NET Framework.
- Framework.Repository : same like Repository, written in .NET Framework
- Framework.BusinessLogic : same like BusinessLogic, written in .NET Framework
- Workflows : this project has contains Activities(that written in Activity Code)
that calling BusinessLogic to run. Also this project has Workflows that implements some Code Activities,and another workflows.
- Workflow.Models has Responses model that workflows return.
- Workflow.Helpers has Consts for strong typings, Encryption Decrpytion Helper, Also Has Converters helpers(of course written with abstraction).
- Workflow.Invoker this project is intended for invoking workflows.
- Workflow.Clients : Actually this project is API Project, creating this API main purpose is to invoke Workflows, and fill gaps that Features NET Core can't done. Invoking this API is Service responsibility. This project has also Unit of Work Patterns, Repository patterns, So this project has to define all those project Abstraction. I'm using Unity for Dependencies Injections.
