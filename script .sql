CREATE DATABASE prueba_tecnica;
GO
USE prueba_tecnica;
GO
CREATE TABLE Clientes (
ID INT PRIMARY KEY IDENTITY(1,1),  
Nombre NVARCHAR(50) NOT NULL,    
Apellido NVARCHAR(50) NOT NULL,    
FechaNacimiento DATE NOT NULL     
);
GO
