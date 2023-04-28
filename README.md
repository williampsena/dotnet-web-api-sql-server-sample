# About

This repository contains a sample dotnet web application with SQL Server powered by Entity Framework and Docker Containers.

# Start and prepare database

```bash
docker compose up -d sql-server
docker compose -f docker-compose.migration.yml run --rm sql-server-setup
```

# Run migrations

To prepare your database, perform migrations before starting apps.

```bash
docker compose -f docker-compose.migration.yml run --rm sql-server-migration
```

# Web

Routes may be tested using the following commands or the Postman collection.

```bash
curl --location --request GET 'http://localhost:8000/coupon/1' \
--header 'Content-Type: application/json' \
--data '{
    "Code": "Coupon-01",
    "Description": "Frete grátis"
}'
curl --location 'http://localhost:8000/coupon'
curl --location 'http://localhost:8000/coupon/1' \
--header 'Content-Type: application/json'
curl --location --request DELETE 'http://localhost:8000/coupon/1'
```

## Nginx

# Testing static routes

It's time to have some "memes" fun.

- http://localhost:8000/coffee.gif
- http://localhost:8000/fire.gif
- http://localhost:8000/hello-it.gif
- http://localhost:8000/the-office.gif