\# TiendaOnline – Prueba Técnica



Aplicación desarrollada en \*\*ASP.NET Core MVC (.NET 10)\*\* para la gestión de productos de una tienda en línea.



\## Funcionalidades

\- Listado de productos

\- Creación de productos

\- Edición de productos y precios

\- Eliminación de productos

\- Validación de precios (mayores que cero)

\- Precio con descuento opcional

\- Visualización de imagen mediante URL



\## Tecnologías utilizadas

\- ASP.NET Core MVC (.NET 10)

\- SQL Server

\- Dapper

\- xUnit (pruebas unitarias)

\- Bootstrap (interfaz básica)



\## Base de datos

La solución utiliza SQL Server y procedimientos almacenados.



En la carpeta \*\*Database\*\* se incluyen los scripts necesarios para:

\- Creación de la base de datos

\- Creación de la tabla Productos

\- Procedimientos almacenados (listar, insertar, actualizar, eliminar)



\### Pasos para configurar la base de datos

1\. Ejecutar los scripts SQL en SQL Server.

2\. Actualizar la cadena de conexión en el archivo `appsettings.json`.



Ejemplo:

```json

"ConnectionStrings": {

&nbsp; "ConexionSQL": "Server=TU\_SERVIDOR;Database=TiendaOnline;Trusted\_Connection=True;TrustServerCertificate=True"

}



