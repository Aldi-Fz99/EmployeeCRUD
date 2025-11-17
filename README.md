# EmployeeCRUD
# Technical Test Aldi Fahroza

A simple ASP.NET MVC application that performs CRUD (Create, Read, Update, Delete) operations for managing employee data.

## Features
- Add new employees
- Edit employee information
- Delete employees
- View employee list
- AJAX-based operations
- SQL Server database integration

## Tech Stack
- ASP.NET MVC 5
- C#
- SQL Server
- jQuery AJAX
- Bootstrap

## Database
The database script is included in

## Web.config – Connection Strings

Pastikan bagian `connectionStrings` pada **Web.config** sesuai dengan nama database dan server SQL Server yang kamu gunakan.

Contoh konfigurasi:

```xml
<connectionStrings>
  <add name="DefaultConnection"
       connectionString="Data Source=NAMASERVER\\SQLEXPRESS;Initial Catalog=EmployeeDB;Integrated Security=True"
       providerName="System.Data.SqlClient" />
</connectionStrings>
