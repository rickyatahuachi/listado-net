CREATE DATABASE [BD_PRUEBA]
GO
USE [BD_PRUEBA]
GO

/****** Object:  Table [dbo].[negocios]    Script Date: 2/5/2021 10:52:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[negocios](
	[id_negocio] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](80) NULL,
	[descripcion] [nvarchar](150) NULL,
	[distancia] [nchar](10) NULL,
	[ruta] [nchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_negocio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO [dbo].[negocios]
VALUES 
(1, 'HIPERMAXI', 'CALLE OBRAJES', '12 KM', ''),
(1, 'POLLOS COPACABANA', '6 DE AGOSTO', '20 KM', ''),
(1, 'SNACK', '6 DE AGOSTO', '25 KM', '');

