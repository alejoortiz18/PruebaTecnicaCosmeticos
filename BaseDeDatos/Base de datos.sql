USE [SalaBelleza]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 20/06/2023 6:15:04 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[ClienteID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Identificacion] [int] NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[ClienteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Colores]    Script Date: 20/06/2023 6:15:04 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Colores](
	[ColorID] [int] IDENTITY(1,1) NOT NULL,
	[Color] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Colores] PRIMARY KEY CLUSTERED 
(
	[ColorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleFactura]    Script Date: 20/06/2023 6:15:04 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleFactura](
	[FacturaID] [int] NOT NULL,
	[ProductoID] [int] NOT NULL,
	[Cantidad] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetallePlanSepareXProducto]    Script Date: 20/06/2023 6:15:04 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallePlanSepareXProducto](
	[PlanSepareID] [int] NOT NULL,
	[ProductoXColorID] [int] NOT NULL,
	[Cantidad] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Facturas]    Script Date: 20/06/2023 6:15:04 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facturas](
	[FacturaID] [int] IDENTITY(1,1) NOT NULL,
	[ClienteID] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Total] [money] NOT NULL,
 CONSTRAINT [PK_Facturas] PRIMARY KEY CLUSTERED 
(
	[FacturaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlanSepare]    Script Date: 20/06/2023 6:15:04 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlanSepare](
	[PlanSepareID] [int] IDENTITY(1,1) NOT NULL,
	[ClienteID] [int] NOT NULL,
	[FechaSepare] [datetime] NOT NULL,
	[TotalPrecioSepare] [money] NOT NULL,
	[ValorMinimo] [money] NOT NULL,
 CONSTRAINT [PK_PlanSepare] PRIMARY KEY CLUSTERED 
(
	[PlanSepareID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 20/06/2023 6:15:04 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[ProductoID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[ProductoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductoXColor]    Script Date: 20/06/2023 6:15:04 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductoXColor](
	[ProductoXColorID] [int] IDENTITY(1,1) NOT NULL,
	[ProductoID] [int] NOT NULL,
	[ColorID] [int] NOT NULL,
	[CantidadStock] [int] NOT NULL,
	[PrecioUnidad] [money] NOT NULL,
	[Referencia] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ProductoXColor] PRIMARY KEY CLUSTERED 
(
	[ProductoXColorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Promociones]    Script Date: 20/06/2023 6:15:04 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promociones](
	[PromocionID] [int] IDENTITY(1,1) NOT NULL,
	[ProductoID] [int] NOT NULL,
	[PorcentajeDescuento] [int] NOT NULL,
 CONSTRAINT [PK_Promociones] PRIMARY KEY CLUSTERED 
(
	[PromocionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([ClienteID], [Nombre], [Identificacion]) VALUES (1, N'Pedro Pa', 12540)
INSERT [dbo].[Clientes] ([ClienteID], [Nombre], [Identificacion]) VALUES (2, N'Pedro', 321654987)
INSERT [dbo].[Clientes] ([ClienteID], [Nombre], [Identificacion]) VALUES (3, N'Maria', 654321987)
INSERT [dbo].[Clientes] ([ClienteID], [Nombre], [Identificacion]) VALUES (4, N'Marta', 654987)
INSERT [dbo].[Clientes] ([ClienteID], [Nombre], [Identificacion]) VALUES (34, N'string', 20)
INSERT [dbo].[Clientes] ([ClienteID], [Nombre], [Identificacion]) VALUES (35, N'string', 20)
INSERT [dbo].[Clientes] ([ClienteID], [Nombre], [Identificacion]) VALUES (36, N'string', 50)
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[Colores] ON 

INSERT [dbo].[Colores] ([ColorID], [Color]) VALUES (1, N'Amarillo')
INSERT [dbo].[Colores] ([ColorID], [Color]) VALUES (2, N'Azul')
INSERT [dbo].[Colores] ([ColorID], [Color]) VALUES (3, N'Rojo')
INSERT [dbo].[Colores] ([ColorID], [Color]) VALUES (4, N'Naranja')
INSERT [dbo].[Colores] ([ColorID], [Color]) VALUES (5, N'Morado')
INSERT [dbo].[Colores] ([ColorID], [Color]) VALUES (6, N'Verde')
INSERT [dbo].[Colores] ([ColorID], [Color]) VALUES (7, N'Cafe')
INSERT [dbo].[Colores] ([ColorID], [Color]) VALUES (8, N'Dorado')
INSERT [dbo].[Colores] ([ColorID], [Color]) VALUES (9, N'Blanco-Negro')
INSERT [dbo].[Colores] ([ColorID], [Color]) VALUES (10, N'azul')
INSERT [dbo].[Colores] ([ColorID], [Color]) VALUES (11, N'oro')
SET IDENTITY_INSERT [dbo].[Colores] OFF
GO
INSERT [dbo].[DetalleFactura] ([FacturaID], [ProductoID], [Cantidad]) VALUES (1, 1, 2)
INSERT [dbo].[DetalleFactura] ([FacturaID], [ProductoID], [Cantidad]) VALUES (2, 2, 3)
GO
INSERT [dbo].[DetallePlanSepareXProducto] ([PlanSepareID], [ProductoXColorID], [Cantidad]) VALUES (1, 1, 2)
INSERT [dbo].[DetallePlanSepareXProducto] ([PlanSepareID], [ProductoXColorID], [Cantidad]) VALUES (2, 3, 3)
INSERT [dbo].[DetallePlanSepareXProducto] ([PlanSepareID], [ProductoXColorID], [Cantidad]) VALUES (4, 5, 1)
INSERT [dbo].[DetallePlanSepareXProducto] ([PlanSepareID], [ProductoXColorID], [Cantidad]) VALUES (4, 2, 2)
GO
SET IDENTITY_INSERT [dbo].[Facturas] ON 

INSERT [dbo].[Facturas] ([FacturaID], [ClienteID], [Fecha], [Total]) VALUES (1, 1, CAST(N'2023-06-09T00:00:00.000' AS DateTime), 5000.0000)
INSERT [dbo].[Facturas] ([FacturaID], [ClienteID], [Fecha], [Total]) VALUES (2, 2, CAST(N'2023-06-01T00:00:00.000' AS DateTime), 9600.0000)
SET IDENTITY_INSERT [dbo].[Facturas] OFF
GO
SET IDENTITY_INSERT [dbo].[PlanSepare] ON 

INSERT [dbo].[PlanSepare] ([PlanSepareID], [ClienteID], [FechaSepare], [TotalPrecioSepare], [ValorMinimo]) VALUES (1, 1, CAST(N'2023-06-09T00:00:00.000' AS DateTime), 5000.0000, 4000.0000)
INSERT [dbo].[PlanSepare] ([PlanSepareID], [ClienteID], [FechaSepare], [TotalPrecioSepare], [ValorMinimo]) VALUES (2, 2, CAST(N'2023-06-05T00:00:00.000' AS DateTime), 12000.0000, 10000.0000)
INSERT [dbo].[PlanSepare] ([PlanSepareID], [ClienteID], [FechaSepare], [TotalPrecioSepare], [ValorMinimo]) VALUES (3, 2, CAST(N'2023-04-01T00:00:00.000' AS DateTime), 45000.0000, 31000.0000)
INSERT [dbo].[PlanSepare] ([PlanSepareID], [ClienteID], [FechaSepare], [TotalPrecioSepare], [ValorMinimo]) VALUES (4, 1, CAST(N'2023-06-06T00:00:00.000' AS DateTime), 10000.0000, 2000.0000)
INSERT [dbo].[PlanSepare] ([PlanSepareID], [ClienteID], [FechaSepare], [TotalPrecioSepare], [ValorMinimo]) VALUES (6, 2, CAST(N'2023-06-06T00:00:00.000' AS DateTime), 10000.0000, 2000.0000)
SET IDENTITY_INSERT [dbo].[PlanSepare] OFF
GO
SET IDENTITY_INSERT [dbo].[Productos] ON 

INSERT [dbo].[Productos] ([ProductoID], [Nombre]) VALUES (1, N'Labial')
INSERT [dbo].[Productos] ([ProductoID], [Nombre]) VALUES (2, N'Base de maquillaje')
INSERT [dbo].[Productos] ([ProductoID], [Nombre]) VALUES (3, N'Crema Hidratante')
INSERT [dbo].[Productos] ([ProductoID], [Nombre]) VALUES (4, N'Perfume')
INSERT [dbo].[Productos] ([ProductoID], [Nombre]) VALUES (5, N'Tintura')
SET IDENTITY_INSERT [dbo].[Productos] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductoXColor] ON 

INSERT [dbo].[ProductoXColor] ([ProductoXColorID], [ProductoID], [ColorID], [CantidadStock], [PrecioUnidad], [Referencia]) VALUES (1, 1, 1, 5, 2500.0000, N'labi-001')
INSERT [dbo].[ProductoXColor] ([ProductoXColorID], [ProductoID], [ColorID], [CantidadStock], [PrecioUnidad], [Referencia]) VALUES (2, 1, 2, 3, 2500.0000, N'labi-002')
INSERT [dbo].[ProductoXColor] ([ProductoXColorID], [ProductoID], [ColorID], [CantidadStock], [PrecioUnidad], [Referencia]) VALUES (3, 2, 3, 10, 3200.0000, N'Maqu-003')
INSERT [dbo].[ProductoXColor] ([ProductoXColorID], [ProductoID], [ColorID], [CantidadStock], [PrecioUnidad], [Referencia]) VALUES (5, 2, 5, 1, 3200.0000, N'Maqu-005')
INSERT [dbo].[ProductoXColor] ([ProductoXColorID], [ProductoID], [ColorID], [CantidadStock], [PrecioUnidad], [Referencia]) VALUES (6, 3, 1, 0, 4000.0000, N'Crem-hid-001')
INSERT [dbo].[ProductoXColor] ([ProductoXColorID], [ProductoID], [ColorID], [CantidadStock], [PrecioUnidad], [Referencia]) VALUES (7, 4, 7, 8, 15000.0000, N'Perf-007')
INSERT [dbo].[ProductoXColor] ([ProductoXColorID], [ProductoID], [ColorID], [CantidadStock], [PrecioUnidad], [Referencia]) VALUES (8, 5, 6, 3, 32000.0000, N'Tint-006')
SET IDENTITY_INSERT [dbo].[ProductoXColor] OFF
GO
ALTER TABLE [dbo].[DetalleFactura]  WITH CHECK ADD  CONSTRAINT [FK_DetalleFactura_Facturas] FOREIGN KEY([FacturaID])
REFERENCES [dbo].[Facturas] ([FacturaID])
GO
ALTER TABLE [dbo].[DetalleFactura] CHECK CONSTRAINT [FK_DetalleFactura_Facturas]
GO
ALTER TABLE [dbo].[DetalleFactura]  WITH CHECK ADD  CONSTRAINT [FK_DetalleFactura_Productos] FOREIGN KEY([ProductoID])
REFERENCES [dbo].[Productos] ([ProductoID])
GO
ALTER TABLE [dbo].[DetalleFactura] CHECK CONSTRAINT [FK_DetalleFactura_Productos]
GO
ALTER TABLE [dbo].[DetallePlanSepareXProducto]  WITH CHECK ADD  CONSTRAINT [FK_DetallePlanSepareXProducto_PlanSepare] FOREIGN KEY([PlanSepareID])
REFERENCES [dbo].[PlanSepare] ([PlanSepareID])
GO
ALTER TABLE [dbo].[DetallePlanSepareXProducto] CHECK CONSTRAINT [FK_DetallePlanSepareXProducto_PlanSepare]
GO
ALTER TABLE [dbo].[DetallePlanSepareXProducto]  WITH CHECK ADD  CONSTRAINT [FK_DetallePlanSepareXProducto_ProductoXColor] FOREIGN KEY([ProductoXColorID])
REFERENCES [dbo].[ProductoXColor] ([ProductoXColorID])
GO
ALTER TABLE [dbo].[DetallePlanSepareXProducto] CHECK CONSTRAINT [FK_DetallePlanSepareXProducto_ProductoXColor]
GO
ALTER TABLE [dbo].[Facturas]  WITH CHECK ADD  CONSTRAINT [FK_Facturas_Clientes] FOREIGN KEY([ClienteID])
REFERENCES [dbo].[Clientes] ([ClienteID])
GO
ALTER TABLE [dbo].[Facturas] CHECK CONSTRAINT [FK_Facturas_Clientes]
GO
ALTER TABLE [dbo].[PlanSepare]  WITH CHECK ADD  CONSTRAINT [FK_PlanSepare_Clientes] FOREIGN KEY([ClienteID])
REFERENCES [dbo].[Clientes] ([ClienteID])
GO
ALTER TABLE [dbo].[PlanSepare] CHECK CONSTRAINT [FK_PlanSepare_Clientes]
GO
ALTER TABLE [dbo].[ProductoXColor]  WITH CHECK ADD  CONSTRAINT [FK_ProductoXColor_Colores] FOREIGN KEY([ColorID])
REFERENCES [dbo].[Colores] ([ColorID])
GO
ALTER TABLE [dbo].[ProductoXColor] CHECK CONSTRAINT [FK_ProductoXColor_Colores]
GO
ALTER TABLE [dbo].[ProductoXColor]  WITH CHECK ADD  CONSTRAINT [FK_ProductoXColor_Productos] FOREIGN KEY([ProductoID])
REFERENCES [dbo].[Productos] ([ProductoID])
GO
ALTER TABLE [dbo].[ProductoXColor] CHECK CONSTRAINT [FK_ProductoXColor_Productos]
GO
ALTER TABLE [dbo].[Promociones]  WITH CHECK ADD  CONSTRAINT [FK_Promociones_Productos] FOREIGN KEY([ProductoID])
REFERENCES [dbo].[Productos] ([ProductoID])
GO
ALTER TABLE [dbo].[Promociones] CHECK CONSTRAINT [FK_Promociones_Productos]
GO
/****** Object:  StoredProcedure [dbo].[InsertarCliente]    Script Date: 20/06/2023 6:15:05 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
--EXEC InsertarRegistro 2, '06-06-2023',10000,2000
--select * from Cliente
-- =============================================
CREATE PROCEDURE [dbo].[InsertarCliente]
    @Nombre NVARCHAR(50),
    @Cedula INT
AS
BEGIN
    -- Insertar el registro en la tabla
    INSERT INTO Clientes(Nombre,Identificacion)
    VALUES (@Nombre, @Cedula);

	SELECT @@IDENTITY
END




GO
/****** Object:  StoredProcedure [dbo].[InsertarColor]    Script Date: 20/06/2023 6:15:05 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
--EXEC InsertarColor 'Blanco-Negro'
--select * from Colores 
-- =============================================
CREATE PROCEDURE [dbo].[InsertarColor]
    @Nombre NVARCHAR(50)
AS
BEGIN
    -- Insertar el registro en la tabla
    INSERT INTO Colores(Color)
    VALUES (@Nombre);

	SELECT @@IDENTITY
END




GO
/****** Object:  StoredProcedure [dbo].[InsertarDetallePlanSepare]    Script Date: 20/06/2023 6:15:05 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
--EXEC InsertarRegistro 2, '06-06-2023',10000,2000
--select * from DetallePlanSepareXProducto
-- =============================================
CREATE PROCEDURE [dbo].[InsertarDetallePlanSepare]
    @PlanSepareID INT,
    @ProductoID INT,
    @Cantidad INT
AS
BEGIN
    INSERT INTO DetallePlanSepareXProducto(PlanSepareID,ProductoID,Cantidad)
    VALUES (@PlanSepareID, @ProductoID,@Cantidad );

END




GO
/****** Object:  StoredProcedure [dbo].[InsertarRegistro]    Script Date: 20/06/2023 6:15:05 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
--EXEC InsertarRegistro 2, '06-06-2023',10000,2000
--select * from PlanSepare
-- =============================================
CREATE PROCEDURE [dbo].[InsertarRegistro]
    @ClienteId INT,
    @FechaSepare DATETIME,
    @TotalPrecioSepare MONEY,
    @ValorMinimo MONEY
AS
BEGIN
DECLARE @IdentityValue AS INT
    -- Insertar el registro en la tabla
    INSERT INTO PlanSepare(ClienteID,FechaSepare,TotalPrecioSepare,ValorMinimo)
    VALUES (@ClienteId, @FechaSepare, @TotalPrecioSepare,@ValorMinimo);

    -- Obtener el valor del campo identity insertado
    SET @IdentityValue = SCOPE_IDENTITY();
	SELECT @IdentityValue
END




GO
/****** Object:  StoredProcedure [dbo].[SeleccionarPlanSepare]    Script Date: 20/06/2023 6:15:05 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
--EXEC SeleccionarPlanSepare 2
--
-- =============================================
CREATE PROCEDURE [dbo].[SeleccionarPlanSepare]
     @Cedula INT
AS
BEGIN
    SELECT	PS.ClienteID, PS.FechaSepare, PS.TotalPrecioSepare, PS.ValorMinimo, PS.PlanSepareID,
		DPP.Cantidad, 
		PXC.CantidadStock,PXC.PrecioUnidad, PXC.Referencia,PXC.ProductoXColorID
	FROM DetallePlanSepareXProducto DPP INNER JOIN
		PlanSepare PS ON DPP.PlanSepareID = PS.PlanSepareID INNER JOIN
		ProductoXColor PXC ON DPP.ProductoXColorID = PXC.ProductoXColorID
		where PS.ClienteID = @Cedula
END




GO
/****** Object:  StoredProcedure [dbo].[SeleccionarPlanSepareXClienteID]    Script Date: 20/06/2023 6:15:05 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SeleccionarPlanSepareXClienteID] 
	@ClienteID int
AS
BEGIN
	SET NOCOUNT ON;
	select PlanSepareID,ClienteID,FechaSepare,TotalPrecioSepare,ValorMinimo
	from PlanSepare
	where ClienteID=@ClienteID
END
GO
