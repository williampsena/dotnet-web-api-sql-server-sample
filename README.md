# Setup database

```bash
docker-compose up -d sql-server
docker-compose -f docker-compose.migration.yml -p migration run --rm sql-server-setup
```

# Run migrations

```bash
dotnet ef database update
```

# Entity Framework

## Creating migrations

```bash
dotnet ef migrations add NextMigration
```