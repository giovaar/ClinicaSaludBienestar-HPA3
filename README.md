# 🏥 Clínica Salud y Bienestar

### Sistema de gestión clínica y seguimiento del Índice de Masa Corporal (IMC)

Aplicación de escritorio desarrollada en **C# y Windows Forms**, conectada a una base de datos **Azure SQL**, diseñada para administrar pacientes, registrar consultas médicas y analizar la evolución de su Índice de Masa Corporal.

Este proyecto fue desarrollado como parte de la asignatura **Herramientas de Programación Aplicadas III (HPA III)** de la Universidad Tecnológica de Panamá (UTP).

## 📋 Descripción

Clínica Salud y Bienestar permite gestionar información de pacientes y sus consultas, calcular automáticamente el IMC, clasificar los resultados según rangos almacenados en la base de datos y visualizar estadísticas mediante informes y gráficos.

El sistema integra una interfaz gráfica, operaciones CRUD y consultas SQL parametrizadas.

## ✨ Funcionalidades principales

- 🔐 Inicio de sesión con un máximo de tres intentos.
- 👥 Registro y administración de pacientes.
- 🩺 Registro y administración de consultas médicas.
- 📊 Cálculo automático del IMC.
- 🏷️ Clasificación por categorías de IMC.
- 📈 Gráfico de evolución del IMC por paciente.
- 🔄 Identificación de tendencias: Sube, Baja o Estable.
- 📋 Historial de consultas médicas.
- 📑 Informe general con estadísticas de pacientes.
- ☁️ Conexión a una base de datos alojada en Azure SQL.
- ✅ Validaciones y manejo de excepciones.

## 🛠️ Tecnologías utilizadas

| Tecnología | Uso |
|---|---|
| C# | Lenguaje de programación |
| .NET 10 | Plataforma de desarrollo |
| Windows Forms | Interfaz gráfica |
| Azure SQL Database | Base de datos |
| Microsoft.Data.SqlClient | Conexión y consultas SQL |
| WinForms.DataVisualization | Visualización de gráficos |
| Visual Studio | Entorno de desarrollo |
| Git y GitHub | Control de versiones |

## 🗄️ Base de datos

La base de datos se organiza en tres entidades principales:

**Paciente:** almacena los datos personales de cada paciente.

**Consulta:** registra las visitas médicas, el peso, la estatura, el IMC y la categoría correspondiente.

**Categoria:** contiene los rangos utilizados para clasificar el IMC.

### Relaciones

- Un paciente puede tener múltiples consultas.
- Cada consulta pertenece a un paciente.
- Cada consulta tiene una categoría de IMC.
- Una categoría puede estar asociada a múltiples consultas.

## 🖥️ Capturas de pantalla

Aquí se incluirán imágenes de las principales pantallas del sistema:

- Inicio de sesión.
- Panel principal.
- Gestión de pacientes.
- Gestión de consultas.
- Informe general.
- Evolución del IMC.

## 🚀 Instalación y ejecución

### Requisitos

- Windows 10 u 11.
- Visual Studio con soporte para desarrollo de escritorio con .NET.
- SDK de .NET 10.
- Acceso a una instancia compatible de SQL Server o Azure SQL Database.
- Paquetes NuGet del proyecto restaurados.

### Pasos

1. Clonar el repositorio:

```bash
git clone https://github.com/giovaar/ClinicaSaludBienestar-HPA3.git
```

2. Abrir la solución `ClinicaSaludBienestar.slnx` en Visual Studio.

3. Restaurar los paquetes NuGet.

4. Preparar una base de datos con el esquema requerido.

5. Configurar la conexión SQL y las credenciales propias del entorno.

6. Compilar y ejecutar el proyecto.

**Nota:** la aplicación utiliza una variable de entorno llamada `CLINICA_SQL_PASSWORD` para recuperar la contraseña de conexión. No se incluyen contraseñas ni credenciales privadas en el repositorio.

La configuración actual de conexión está preparada para el entorno académico utilizado durante el desarrollo. Para utilizar una base de datos diferente, es necesario adaptar dicha configuración.

## 📐 Reglas de cálculo

El Índice de Masa Corporal se calcula mediante:

**IMC = Peso (kg) / Estatura (m)²**

El resultado se redondea a un decimal y su categoría se determina utilizando los límites almacenados en la base de datos.

Para analizar la evolución, se compara el IMC de la primera consulta con el de la última:

- **Sube:** diferencia mayor a 0.5.
- **Baja:** diferencia menor a -0.5.
- **Estable:** diferencia entre -0.5 y 0.5, inclusive.

## 👨‍💻 Desarrollo académico

**Institución:** Universidad Tecnológica de Panamá (UTP)  
**Asignatura:** Herramientas de Programación Aplicadas III  
**Grupo:** 1  
**Año:** 2026

Proyecto académico desarrollado mediante trabajo colaborativo.

## 🔒 Seguridad y privacidad

El repositorio no debe contener contraseñas, claves privadas ni datos clínicos reales.

Los datos utilizados para las pruebas académicas son ficticios y no deben interpretarse como información médica real.

## 🔮 Mejoras futuras

- Modernización de la interfaz gráfica.
- Autenticación y administración de roles.
- Exportación de informes.
- Desarrollo de una versión web.
- API REST con ASP.NET Core.
- Implementación de una plataforma accesible mediante dominio propio.

## 📄 Licencia

Proyecto académico. Las condiciones de reutilización y distribución se definirán antes de publicar una licencia.

---

*Desarrollado como proyecto de Ingeniería de Sistemas y Computacional — Universidad Tecnológica de Panamá.*
