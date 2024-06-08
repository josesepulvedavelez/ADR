
CREATE DATABASE ADR;
USE ADR;

CREATE TABLE Adquisicion 
(
	Presupuesto AS (ValorUnitario * Cantidad),
	Unidad VARCHAR(200) NOT NULL,
	TipoBien VARCHAR(100) NOT NULL,
	Cantidad INT NOT NULL,
	ValorUnitario MONEY NOT NULL,
	ValorTotal MONEY NOT NULL,
	FechaAdquisicion DATE NOT NULL,
	Proveedor VARCHAR(200) NOT NULL,
	Documentacion VARCHAR(150) NOT NULL,
	AdquisicionId INT IDENTITY(1, 1) PRIMARY KEY,
	Estado BIT
);

SELECT * FROM Adquisicion;
