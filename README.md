# ColegioGXC API

API RESTful para gestión de colegios y materias. Construida con ASP.NET Core y SQL Server.


Levantar SQL Server con Docker
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Contrasena123!" -p 1433:1433 --name sqlservercolegio -d mcr.microsoft.com/mssql/server:2022-latest

//MIGRACION
//ELIMINAR 
dotnet ef migrations remove -p Infraestructura -s PresentacionApi

//CREAR
dotnet ef migrations add InitialCreate -p Infraestructura -s PresentacionApi

//EJECUTAR
dotnet ef database update -p Infraestructura -s PresentacionApi
