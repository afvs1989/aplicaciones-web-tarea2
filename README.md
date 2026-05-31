# Tarea 2 — Programación Web

**Autor:** Andrés Valenzuela  
**Curso:** Programación Web — Universidad de los Andes  
**Proyecto:** `tarea2_clientes`

---

## Descripción

Sistema web para la **gestión de clientes y alumnos** (CRUD completo). Permite registrar, consultar, editar y eliminar registros almacenados en una base de datos **Microsoft SQL Server**, mediante una aplicación **ASP.NET Core MVC** con **Entity Framework Core**.

La aplicación incluye además el módulo de **ASP.NET Core Identity** para autenticación de usuarios (registro, inicio de sesión y gestión de cuentas).

---

## Tecnologías

| Componente | Tecnología |
|------------|------------|
| Framework | ASP.NET Core 10 (.NET 10) |
| Patrón | MVC (Modelo – Vista – Controlador) |
| ORM | Entity Framework Core 10 |
| Base de datos | SQL Server 2022 (Docker) |
| Autenticación | ASP.NET Core Identity |
| Frontend | Razor Views, Bootstrap |

---

## Arquitectura del sistema

```
┌─────────────┐     HTTP      ┌──────────────────┐     EF Core     ┌─────────────┐
│   Navegador │ ◄───────────► │  ASP.NET Core    │ ◄─────────────► │  SQL Server │
│  (Razor UI) │               │  MVC + Identity  │                 │  (Docker)   │
└─────────────┘               └──────────────────┘                 └─────────────┘
                                      │
                              ClienteController / AlumnoController
                              ApplicationDbContext
                              ClienteModel / AlumnoModel
```

### Flujo de una petición

1. El usuario accede a una URL (por ejemplo `/Cliente/Index` o `/Alumno/Index`).
2. **ASP.NET Core** enruta la petición al controlador correspondiente.
3. El controlador usa **`ApplicationDbContext`** para leer o modificar datos en SQL Server.
4. El resultado se envía a una **vista Razor** (`.cshtml`) que genera el HTML de respuesta.

---

## Modelo de datos

### Cliente (`ClienteModel`)

| Campo | Tipo | Validación |
|-------|------|------------|
| `Id` | `int` | Clave primaria (autoincremental) |
| `Nombre` | `string` | Requerido, 2–50 caracteres |
| `Apellido` | `string` | Requerido, 2–50 caracteres |
| `Direccion` | `string` | Requerido, 5–200 caracteres |
| `Telefono` | `string` | Requerido, exactamente 10 dígitos numéricos |
| `Correo` | `string` | Requerido, formato de correo válido |

### Alumno (`AlumnoModel`)

| Campo | Tipo | Validación |
|-------|------|------------|
| `Id` | `int` | Clave primaria (autoincremental) |
| `Nombre` | `string` | Requerido, 2–50 caracteres |
| `Apellido` | `string` | Requerido, 2–50 caracteres |
| `Codigo` | `string` | Requerido, 3–20 caracteres, solo letras y números |
| `Carrera` | `string` | Requerido, 3–100 caracteres |
| `Correo` | `string` | Requerido, formato de correo válido |

Las tablas `Clientes` y `Alumnos` se crean mediante migraciones de Entity Framework en la base de datos `Tarea2_Clientes`.

---

## Funcionalidades

### Gestión de clientes (CRUD)

| Acción | Ruta | Descripción |
|--------|------|-------------|
| Listar | `GET /Cliente/Index` | Muestra todos los clientes |
| Detalle | `GET /Cliente/Details/{id}` | Consulta un cliente por ID |
| Crear | `GET/POST /Cliente/Create` | Formulario para nuevo cliente |
| Editar | `GET/POST /Cliente/Edit/{id}` | Modifica un cliente existente |
| Eliminar | `GET/POST /Cliente/Delete/{id}` | Confirma y elimina un cliente |

### Gestión de alumnos (CRUD)

| Acción | Ruta | Descripción |
|--------|------|-------------|
| Listar | `GET /Alumno/Index` | Muestra todos los alumnos |
| Detalle | `GET /Alumno/Details/{id}` | Consulta un alumno por ID |
| Crear | `GET/POST /Alumno/Create` | Formulario para nuevo alumno |
| Editar | `GET/POST /Alumno/Edit/{id}` | Modifica un alumno existente |
| Eliminar | `GET/POST /Alumno/Delete/{id}` | Confirma y elimina un alumno |

Las operaciones POST usan **`[ValidateAntiForgeryToken]`** para protección CSRF y validan el modelo con **Data Annotations** antes de guardar. Los formularios Create y Edit incluyen **validación del lado cliente** (jQuery Validation Unobtrusive) con mensajes en español debajo de cada campo.

### Páginas generales

- **`/Home/Index`** — Página de inicio.
- **`/Home/Privacy`** — Política de privacidad.
- **Identity** — Registro e inicio de sesión de usuarios (`/Identity/Account/...`).

---

## Estructura del proyecto

```
tarea2/
├── Controllers/
│   ├── ClienteController.cs    # Lógica CRUD de clientes
│   ├── AlumnoController.cs     # Lógica CRUD de alumnos
│   └── HomeController.cs       # Páginas de inicio y error
├── Data/
│   ├── ApplicationDbContext.cs # Contexto de EF Core
│   └── Migrations/             # Migraciones de la base de datos
├── Models/
│   ├── ClienteModel.cs         # Entidad Cliente
│   ├── AlumnoModel.cs          # Entidad Alumno
│   └── ErrorViewModel.cs
├── Views/
│   ├── Cliente/                # Vistas CRUD de clientes
│   ├── Alumno/                 # Vistas CRUD de alumnos
│   ├── Home/
│   └── Shared/
├── Areas/Identity/               # Páginas de autenticación
├── Program.cs                    # Configuración y pipeline HTTP
├── appsettings.json              # Cadena de conexión y configuración
└── tarea2_clientes.csproj
```

---

## Requisitos previos

- [.NET SDK 10](https://dotnet.microsoft.com/download)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/) (para SQL Server)
- Herramienta EF (opcional, para migraciones):

  ```bash
  dotnet tool install --global dotnet-ef
  ```

---

## Configuración y ejecución

### 1. Levantar SQL Server en Docker

```bash
docker run --platform linux/amd64 \
  -e 'ACCEPT_EULA=Y' \
  -e 'MSSQL_SA_PASSWORD=TuPasswordSeguro123!' \
  -p 1433:1433 \
  --name sql_server \
  -d mcr.microsoft.com/mssql/server:2022-latest
```

Si el contenedor ya existe:

```bash
docker start sql_server
```

Espera **15–20 segundos** después de iniciar el contenedor para que SQL Server esté listo.

### 2. Cadena de conexión

En `appsettings.json` debe apuntar al servidor local:

```
Server=localhost,1433;Database=Tarea2_Clientes;User Id=sa;Password=TuPasswordSeguro123!;TrustServerCertificate=True;MultipleActiveResultSets=true
```

### 3. Aplicar migraciones (primera vez)

```bash
cd tarea2
dotnet ef database update
```

Esto crea la base `Tarea2_Clientes` y las tablas (`Clientes`, `Alumnos`, tablas de Identity, etc.).

### 4. Ejecutar la aplicación

```bash
dotnet restore
dotnet build
dotnet run
```

Abre el navegador en:

- **HTTP:** http://localhost:5204  
- **HTTPS:** https://localhost:7045  

Desde el menú de navegación puedes acceder a **Clientes** (`/Cliente/Index`) y **Alumnos** (`/Alumno/Index`).

---

## Configuración principal (`Program.cs`)

- Registra **`ApplicationDbContext`** con SQL Server.
- Configura **Identity** con confirmación de cuenta por correo.
- En desarrollo, habilita la página de errores de migraciones de EF.
- Define el enrutamiento MVC por defecto: `{controller=Home}/{action=Index}/{id?}`.

---

## Notas importantes

- No subas al repositorio las carpetas `bin/`, `obj/` ni `.vs/` (están en `.gitignore`).
- Si copias el proyecto desde Windows, ejecuta `chmod -R u+w .` y borra `obj`/`bin` antes de compilar en macOS.
- La contraseña de SQL en `appsettings.json` es solo para desarrollo local; en producción usa variables de entorno o User Secrets.

---

## Licencia

Proyecto académico — Universidad de los Andes.
