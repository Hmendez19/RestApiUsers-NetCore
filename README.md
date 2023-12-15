# REST API USERS
-------------------

## Funcionalidades principales
1. **Listar usuario**
	- Obtendrá un listado de usuarios de un base de datos MySQL (corriendo en local).
2. **Crear usuario**
	- Inserta los datos del usuario enviado desde el payload hacia la base de datos y notifica al usuario mediante un email (Solo simulación de envío).

## Estructura general de carpetas:
    ├── Properties
    │    ├── launchSettings.json
    ├── Common
    │   ├── Database
    │   ├── Exceptions
    │   ├── Interfaces
    │   ├── Validators
    ├── Modules
    │   ├── Users
    │   │   ├── Application
    │   │   ├── Domain
    │   │   ├── Infrastructure
    ├── Program.cs
    ├── RestApiUsers.csproj
    ├── RestApiUsers.csproj.user
    ├── RestApiUsers.http
    ├── appsettings.Development.json
    └── appsettings.json

  > Se implementa Arquitectura Hexagonal + Vertical Slicing + DDD + Principios SOLID.


## Estructura de la tabla **user**
| Columna | Tipo |Longitud|Nulable|Indexado|Restricción
|--------|--------|--------|--------|--------|--------|
|  id      | int       |        |  No       |  Si      |   auto_increment primary key    |
|   first_name     |  varchar      |   100     |     NO   |   Si     |        |
|   last_name     |  varchar      |   100     |     NO   |   No     |        |
|   email     |  varchar      |   150    |     NO   |   Si     |   unique     |
|   country     |  varchar      |   100     |     NO   |   Si     |        |
|   created_at     |  datetime      |   |     NO   |   No     |        |
|   updated_at     |  datetime      |   |     NO   |   No     |        |


## Requerimientos para el proyecto
1. JetBrains Rider como IDE de preferencia
2. SDK .Net 8.0
3. Instalación de los paquetes desde Nuget
      - **MySql.Data 8.2.0**  [Conector cliente para gestión de la base de datos en Mysql]
      - **NHibernate 5.4.7** [ORM para mapeo de las tablas]
      - **Swashbuckle.AspNetCore 6.4.0** [Documentación con Swagger]
      - **Newtonsoft.Json 13.0.3**  [Utilidad formateo de JSON]

## Configuración del proyecto

1. Clonar este repositorio:

    ```bash
    git clone https://github.com/Hmendez19/RestApiUsers-NetCore.git
    ```

2. Navegue hasta el directorio del proyecto:

    ```bash
    cd RestApiUsers-NetCore
    ```
3. Abrir la solución con JetBrains Rider
	 - Previo a la ejecución del proyecto .Net, asegurarse que esté el servicio de Mysql corriendo ya sea a nivel local o en el contenedor.

4. Ruta de la configuración de la base de datos:
    ├── Common
    │   ├── Database
    │   │   ├── Config
    │   │   │     ├── **DatabaseIntegrationSetup.cs**
5. Cambiar cadena de conexión en DatabaseIntegrationSetup.cs *(Opcional)*
    ``` csharp  
    db.ConnectionString = "Server=localhost;Port=3306;Database=testing_net;User ID=root;Password=mauFJcuf5dhRMQrjj;";
    ```
    


## Requerimientos para el contenedor de Myql *(Opcional)*
1.  Visitar el sitio ofical de docker
	- [Clic aquí para visitar Docker container](http://https://www.docker.com/)
	- Seleccionar el producto de su preferencia según el Sistema Operativo
		- **Windows** [Docker desktop]
		- **Unix** [Docker CLI]
2. Docker version 20.10.13, build a224086
3. Docker Compose version v2.3.3
4. Una vez instalado, ubicarse en el directorio donde se encuentra el archivo **docker-compose.yml**
	- Ejecutar los comandos:
		```bash
          # Dar de baja al contenedor si existe anteriormente
          docker-compose down

          # Crear el contenedor y dejarlo en segundo plano
          docker-compose up -d

          # Verificar si se creó correctamente (mysql_container es el nombre del contenedor)
          docker ps
        ```


## Response
- **api/v1/Users** [Crear usuario]
	- **Método**: POST
	- **Content-Type**: application/json
	- **User-Agent**: insomnia/2023.5.8
	- **accept**: ```*/*```
	- **Payload**:
		```json 
		  {
            "firstName": "Testing",
            "lastName": ".Net Core",
            "email": "testing@gmail.com",
            "country": "Any"
          }
		```
    - **Response** 
        - HttpCode 400 (Bad request) [Campo vacío]
            ```json
            {
                "error_message": "{Nombre del campo} no puede ser vacío"
            }
            ```
        - HttpCode 400 (Bad request) [Formato de email inválido]
            ```json
            {
                "error_message": "Email no tiene el formato correcto"
            }
            ```
        - HttpCode 409 (Conflicto)
            ```json
            {
                "error_message": "El email {email enviado desde el payload} ya está en uso"
            }
            ```
        - HttpCode 422 (Contenido no procesable) [El valor excede la longitud que presenta el campo en la base de datos]
        	```json
            {
                "error_message": "{Nombre del campo} no puede tener más de {Longitud} caracteres"
            }
            ```
    	- HttpCode 201 (Creado)
            ```json
            {
                "message": "El usuario se ha registrado correctamente"
            }
            ```
- **api/v1/Users** [Listar los usuarios]
	- **Método**: GET
	- **Content-Type**: application/json
    - **Response** 
        - HttpCode 200 [Sin datos]
            ```json
            []
            ```
    	- HttpCode 200 [Con datos]
            ```json
            [
              {
                "id": 1,
                "firstName": "Testing",
                "lastName": ".Net Core",
                "email": "testing@gmail.com",
                "country": "Any",
                "createdAt": "2023-12-14T19:06:10",
                "updatedAt": "2023-12-14T19:06:10"
             },
             ...
            ]
            ```