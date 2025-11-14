# ColegioGXC API

API RESTful para gestión de colegios y materias. Construida con ASP.NET Core y SQL Server.


Levantar SQL Server con Docker

docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=TuPassword123!" \
   -p 1433:1433 --name sqlserver-colegio \
   -d mcr.microsoft.com/mssql/server:2022-latest
