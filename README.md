# ws-app.net
Arquitectura del Proyecto

El proyecto está basado en Clean Architecture, estructurado en capas: 
presentación (API), aplicación (Application), dominio (Domain), infraestructura (Infrastructure) y pruebas automatizadas (Tests). Este enfoque garantiza una separación estricta de responsabilidades, bajo acoplamiento y alta cohesión. Además, la inclusión de un proyecto de pruebas permite validar la lógica de negocio y los componentes de forma aislada, mejorando la confiabilidad del sistema, facilitando el mantenimiento y promoviendo prácticas de desarrollo orientadas a calidad.

## Estructura de Proyectos

wsApp.sln 

wsApp.API               → Capa de presentación

wsApp.Application       → Casos de uso / lógica de negocio

wsApp.Domain            → Entidades y reglas del negocio

wsApp.Infrastructure    → Acceso a datos y servicios externos

wsApp.Tests             → Proyecto de tests automatizados Unit tests/Integration tests


## Relación entre capas

wsApp.API
   
    wsApp.Application       → wsApp.Domain
   
    wsApp.Infrastructure    → wsApp.Application

## Descripción de cada proyecto

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

## Tecnologías

    .NET 10
    Entity Framework Core
    SQL Server
    Clean Architecture
    Swagger / Scalar


Swagger
https://localhost:7280/swagger

Scalar
https://localhost:7280/scalar/v1

## Notas
La conexión a base de datos se maneja mediante variables de entorno
Se sigue el principio de inversión de dependencias



## 🚀 Demo en vivo
FrontEnd
    https://gray-wave-0ea61b210.2.azurestaticapps.net/

📖 Documentación interactiva: https://wsappnet10-h4dwfyduh4dwg2gw.mexicocentral-01.azurewebsites.net/scalar/v1
