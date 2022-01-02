# MicroVideosCatalog
---
### Adopted development approaches:
 - DDD
 - CQRS
---
### Running Migrations with EF Core 6:
#### Generate migration:
```
❯❯❯ dotnet-ef migrations add "Initial" -s src/MicroVideosCatalog.API -p src/MicroVideosCatalog.Infrastructure -o ./Data/Migrations -c VideoCatalogContext
````

#### Applying migration:
```
❯❯❯ dotnet-ef database update -s src/MicroVideosCatalog.API -c VideoCatalogContext
````