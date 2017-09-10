CREATE TABLE Productos(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Nombre NVARCHAR(MAX) NOT NULL,
	CantidadMinima INT NOT NULL,
	StockActual INT NOT NULL
)

GO

CREATE PROCEDURE CrearProducto
	@Nombre NVARCHAR(MAX),
	@CantidadMinima INT,
	@StockActual INT
AS
BEGIN
	INSERT INTO Productos(Nombre,CantidadMinima,StockActual)
	VALUES (@Nombre,@CantidadMinima,@StockActual)
END

GO

CREATE PROCEDURE ListarTodosLosProductos
AS
BEGIN
	SELECT	Id,
			Nombre,
			CantidadMinima,
			StockActual
	FROM Productos
END


