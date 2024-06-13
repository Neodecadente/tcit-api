# TCIT API

 Construida con ASP.NET Core y PostgreSQL.

## Requisitos

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [PostgreSQL](https://www.postgresql.org/download/)

## Comienzo

### Conexión a PostgreSQL

Debe configurar el string de conexión en appsettings.json:

      - "PsqlConnection": "Host=;Database=;Username=;Password="

      Host: La dirección de red de su base de datos (localhost si está en el mismo equipo)
      Database: El nombre de la base de datos
      Username: El nombre de usuario de conexión a la base de datos
      Password: La contraseña del usuario de conexión a la base de datos

### Base de Datos

1- Importe el esquema a su base de datos PostgreSQL:

   psql -U su_usuario -d su_base_de-datos -f ruta/a/schema.sql

   ***Opcionalmente puede utilizar un cliente de SQL como [DBeaver](https://dbeaver.io/download/) (optional for database management) ***

### Aplicación

  Clone el repositorio:

    git clone https://github.com/Neodecadente/tcit-api.git
    cd tcit-api

  Instale/restaure las dependencias del proyecto y ejecute

    dotnet restore
    dotnet run

  La API ya debería estar funcionando en https://localhost:5289.

## Endpoints

      GET /api/posts: Obtiene todos los posts.
      POST /api/posts: Crea un nuevo post.
      DELETE /api/posts/{id}: Elimina un post por ID.