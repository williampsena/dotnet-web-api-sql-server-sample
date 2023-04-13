# About

This repository contains a sample dotnet web application with SQL Server powered by Entity Framework and Docker Containers.

# Setup database

```bash
docker-compose up -d sql-server
docker-compose -f docker-compose.migration.yml -p migration run --rm sql-server-setup
```

# Run migrations

To prepare your database, perform migrations before starting apps.

```bash
dotnet ef database update
```

# Entity Framework
## Creating migrations

If you want to make new migrations, use this handy command.


```bash
dotnet ef migrations add NextMigration
```