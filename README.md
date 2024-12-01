# SURIS CHALLENGE  
**Challenge Técnico - Suris Code Software Factory**

Este repositorio contiene una aplicación dividida en dos partes principales: el backend (API) y el frontend (React con Vite). A continuación, te guiaré sobre cómo iniciar la aplicación localmente.

---

## Requisitos Previos

Antes de comenzar, asegúrate de tener las siguientes herramientas instaladas:

- **Node.js** (versión 14 o superior) y **npm** o **yarn** para gestionar las dependencias del frontend.
- **.NET SDK** (versión 6.0 o superior) para manejar el backend.

---

## Iniciar la App

### 1. Backend (API en .NET)

#### Navegar a la carpeta `BACK`:
```bash
cd BACK
```
#### Restaura las dependencias:
```bash
dotnet restore  
```
#### Ejecuta el servidor de la API:
```bash
dotnet run  
```

### 2. Frontendt (React con vite)

### Navega a la carpeta FRONT:
```bash
cd FRONT  
```
#### Instala las dependencias:
```bash
npm install  
```
#### Inicia la aplicación:
```bash
npm run dev
```

# Tener en cuenta

La app de Back tiene CORS lo cual necesita tener la url del Front para poder permitir las request, el Front tiene configurada una instancia de axios la cual tiene la url base de la api
