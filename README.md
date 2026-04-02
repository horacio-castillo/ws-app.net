# ws-app.net
Arquitectura del Proyecto

El proyecto sigue el patrón de Clean Architecture, separando responsabilidades en diferentes capas para lograr escalabilidad, mantenibilidad y bajo acoplamiento.


Estructura de Proyectos

wsApp.sln 

wsApp.API               → Capa de presentación

wsApp.Application       → Casos de uso / lógica de negocio

wsApp.Domain            → Entidades y reglas del negocio

wsApp.Infrastructure    → Acceso a datos y servicios externos


Relación entre capas

wsApp.API
   
    wsApp.Application       → wsApp.Domain
   
    wsApp.Infrastructure    → wsApp.Application

Descripción de cada proyecto

wsApp.API

    Controladores (Endpoints REST)
    Configuración de servicios (Dependency Injection)
    Swagger / Scalar
    Punto de entrada de la aplicación

wsApp.Application

    Casos de uso  
    Interfaces  
    DTOs
    Lógica de aplicación

wsApp.Domain

    Entidades  
    Reglas del negocio
    Value Objects

wsApp.Infrastructure

    DbContext   
    Repositorios  
    Servicios externos 

Tecnologías

    .NET 10
    Entity Framework Core
    SQL Server
    Clean Architecture
    Swagger / Scalar


Swagger
https://localhost:7280/swagger

Scalar
https://localhost:7280/scalar/v1

Notas
La conexión a base de datos se maneja mediante variables de entorno
Se sigue el principio de inversión de dependencias

# wsApp API

API REST desarrollada con .NET 10, Entity Framework Core y JWT Authentication.

## 🚀 Demo en vivo

📖 Documentación interactiva: https://wsappnet10-h4dwfyduh4dwg2gw.mexicocentral-01.azurewebsites.net/scalar/v1
