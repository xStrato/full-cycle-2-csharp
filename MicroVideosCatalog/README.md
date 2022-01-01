# MicroVideosCatalog
---
### Running Migrations with EF Core 6:
#### Generate migration:
```
❯❯❯ dotnet-ef migrations add "InitialCreation" -p src/MicroVideosCatalog.API -c VideoCatalogContext
````

#### Applying migration:
```
❯❯❯ dotnet-ef database update -p src/MicroVideosCatalog.API -c VideoCatalogContext
````