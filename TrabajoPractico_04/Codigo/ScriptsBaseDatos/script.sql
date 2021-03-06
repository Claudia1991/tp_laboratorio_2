USE [SistemaVentasDB]
GO
/****** Object:  Table [dbo].[producto]    Script Date: 11/12/2020 10:50:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[producto](
	[id_producto] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
	[precio] [float] NOT NULL,
 CONSTRAINT [PK_producto] PRIMARY KEY CLUSTERED 
(
	[id_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ventas]    Script Date: 11/12/2020 10:50:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ventas](
	[id_venta] [int] IDENTITY(1,1) NOT NULL,
	[monto_total] [float] NOT NULL,
	[fecha_venta] [datetime] NOT NULL,
 CONSTRAINT [PK_ventas] PRIMARY KEY CLUSTERED 
(
	[id_venta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ventas_detalle]    Script Date: 11/12/2020 10:50:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ventas_detalle](
	[id_venta] [int] NOT NULL,
	[id_producto] [int] NOT NULL,
	[cantidad_productos] [int] NOT NULL,
	[monto_por_producto] [float] NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[producto] ON 

INSERT [dbo].[producto] ([id_producto], [descripcion], [precio]) VALUES (1, N'PRODUCTO UNO', 524.3)
INSERT [dbo].[producto] ([id_producto], [descripcion], [precio]) VALUES (2, N'producto seis', 123.5)
INSERT [dbo].[producto] ([id_producto], [descripcion], [precio]) VALUES (3, N'producto dos', 23.5)
INSERT [dbo].[producto] ([id_producto], [descripcion], [precio]) VALUES (4, N'producto tres', 5123.5)
INSERT [dbo].[producto] ([id_producto], [descripcion], [precio]) VALUES (5, N'producto cuatro', 250)
INSERT [dbo].[producto] ([id_producto], [descripcion], [precio]) VALUES (6, N'producto cinco', 83.5)
SET IDENTITY_INSERT [dbo].[producto] OFF
GO
SET IDENTITY_INSERT [dbo].[ventas] ON 

INSERT [dbo].[ventas] ([id_venta], [monto_total], [fecha_venta]) VALUES (1, 12540, CAST(N'2020-11-11T18:25:55.990' AS DateTime))
INSERT [dbo].[ventas] ([id_venta], [monto_total], [fecha_venta]) VALUES (2, 125.6, CAST(N'2020-11-12T20:09:40.080' AS DateTime))
INSERT [dbo].[ventas] ([id_venta], [monto_total], [fecha_venta]) VALUES (3, 524.3, CAST(N'2020-11-12T22:35:52.620' AS DateTime))
INSERT [dbo].[ventas] ([id_venta], [monto_total], [fecha_venta]) VALUES (4, 524.3, CAST(N'2020-11-12T22:43:04.557' AS DateTime))
INSERT [dbo].[ventas] ([id_venta], [monto_total], [fecha_venta]) VALUES (5, 524.3, CAST(N'2020-11-12T22:46:58.547' AS DateTime))
INSERT [dbo].[ventas] ([id_venta], [monto_total], [fecha_venta]) VALUES (6, 523.5, CAST(N'2020-11-12T22:48:27.177' AS DateTime))
SET IDENTITY_INSERT [dbo].[ventas] OFF
GO
INSERT [dbo].[ventas_detalle] ([id_venta], [id_producto], [cantidad_productos], [monto_por_producto]) VALUES (1, 1, 3, 250.3)
INSERT [dbo].[ventas_detalle] ([id_venta], [id_producto], [cantidad_productos], [monto_por_producto]) VALUES (1, 2, 2, 548)
INSERT [dbo].[ventas_detalle] ([id_venta], [id_producto], [cantidad_productos], [monto_por_producto]) VALUES (2, 1, 2, 548)
INSERT [dbo].[ventas_detalle] ([id_venta], [id_producto], [cantidad_productos], [monto_por_producto]) VALUES (2, 3, 2, 548)
INSERT [dbo].[ventas_detalle] ([id_venta], [id_producto], [cantidad_productos], [monto_por_producto]) VALUES (5, 1, 1, 524.3)
INSERT [dbo].[ventas_detalle] ([id_venta], [id_producto], [cantidad_productos], [monto_por_producto]) VALUES (6, 5, 2, 500)
INSERT [dbo].[ventas_detalle] ([id_venta], [id_producto], [cantidad_productos], [monto_por_producto]) VALUES (6, 3, 1, 23.5)
GO
ALTER TABLE [dbo].[ventas_detalle]  WITH CHECK ADD  CONSTRAINT [FK_ventas_detalle_producto] FOREIGN KEY([id_producto])
REFERENCES [dbo].[producto] ([id_producto])
GO
ALTER TABLE [dbo].[ventas_detalle] CHECK CONSTRAINT [FK_ventas_detalle_producto]
GO
ALTER TABLE [dbo].[ventas_detalle]  WITH CHECK ADD  CONSTRAINT [FK_ventas_detalle_ventas] FOREIGN KEY([id_venta])
REFERENCES [dbo].[ventas] ([id_venta])
GO
ALTER TABLE [dbo].[ventas_detalle] CHECK CONSTRAINT [FK_ventas_detalle_ventas]
GO
