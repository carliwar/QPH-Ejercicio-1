# QPH-Ejercicio-1 - CRUD Libros

## General
Diseñado en base a Arquitectura ONION 

- Core
- Business
- Repository Pattern

Data Access: Entity Framework Core

## Testing Local

1. Ejecutar el script adjunto en la raiz del repositorio: script.sql, en la instancia local de SQL Server
2. Modificar el appsettings.json del proyecto QPH.Eval.Ej1.REST para apuntar a la instancia local de base de datos.
  - "QPHDB": "Data Source={base de datos local};Initial Catalog=TestDBLibro;Integrated Security=True;"
3. Modificar los Startup Projects de la solución para correr los proyectos:
  - QPH.Eval.Ej1.WebApp
  - QPH.Eval.Ej1.REST
 
 Nota: Para correr los tests verificar que se tenga instalada la extensión: NUnit 3 Test Adapter.

