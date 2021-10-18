create database Rentlock

USE [Rentlock]
GO

/****** Object:  Table [dbo].[RoleID]    Script Date: 21.05.2021 11:59:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RoleID](
	[id] [int] NOT NULL,
	[roleName] [nvarchar](20) NULL,
 CONSTRAINT [PK_RoleID] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[Users]    Script Date: 21.05.2021 11:58:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[login] [nchar](50) NULL,
	[password] [nchar](50) NULL,
	[email] [nchar](50) NULL,
	[roleId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_RoleID] FOREIGN KEY([roleId])
REFERENCES [dbo].[RoleID] ([id])
GO

ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_RoleID]
GO

/****** Object:  Table [dbo].[Rent]    Script Date: 21.05.2021 12:04:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Rent](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](50) NULL,
	[phone] [nchar](20) NULL,
	[date] [nchar](30) NULL,
	[car] [nchar](50) NULL,
	[userid] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Rent]  WITH CHECK ADD  CONSTRAINT [FK_Rent_Users] FOREIGN KEY([userid])
REFERENCES [dbo].[Users] ([id])
GO

ALTER TABLE [dbo].[Rent] CHECK CONSTRAINT [FK_Rent_Users]
GO

/****** Object:  Table [dbo].[Sedans]    Script Date: 21.05.2021 12:01:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Sedans](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[company] [nvarchar](50) NULL,
	[model] [nvarchar](50) NULL,
	[class] [nvarchar](50) NULL,
	[power] [nvarchar](30) NULL,
	[engine] [nvarchar](50) NULL,
	[drive] [nvarchar](20) NULL,
	[places] [nvarchar](20) NULL,
	[price] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Reviews]    Script Date: 21.05.2021 12:03:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Reviews](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](50) NULL,
	[review] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

insert into RoleID(id, roleName)
	values(0, 'Администратор'),
		(1, 'Пользователь')

GO

insert into Sedans(company, model, class, power, engine, drive, places, price)
	values('Mercedes-Benz', 'GT63S AMG', 'Sedan', 585, 4.0, 'AWD', 5, 400),
			('Rolls-Royce', 'Ghost', 'Lux', 624, 6.6, 'RWD', 4, 1050),
			('Bentley', 'Mulsanne', 'Lux', 512, 6.7, 'RWD', 4, 925),
			('BMW', 'M5', 'Sedan', 625, 4.4, 'AWD', 5, 400),
			('Mercedes-Benz', 'E63S AMG', 'Sedan', 612, 4.0, 'AWD', 5, 520),
			('Mercedes-Benz', 'S63 AMG', 'Lux', 585, 5.5, 'AWD', 4, 500),
			('Porsche', 'Panamera Turbo', 'Sedan', 550, 4.0, 'AWD', 5, 400),
			('BMW', 'M8', 'Sedan', 625, 4.4, 'AWD', 4, 400),
			('Lamborghini', 'Huracan', 'Sportcar', 610, 5.2, 'AWD', 2, 1200),
			('Bentley', 'Continental GT', 'Sportcar', 507, 4.0, 'AWD', 4, 250),
			('Lamborghini', 'Aventador S', 'Sportcar', 740, 6.5, 'AWD', 2, 1600),
			('Audi', 'R8', 'Sportcar', 610, 5.2, 'AWD', 2, 400),
			('Lamborghini', 'Gallardo', 'Sportcar', 560, 5.2, 'AWD', 2, 660),
			('Nissan', 'GT-R', 'Sportcar', 570, 3.8, 'AWD', 4, 400),
			('Porsche', '911 4S', 'Sportcar', 450, 3.0, 'AWD', 4, 520),
			('Rolls-Royce', 'Wraith', 'Lux', 624, 6.6, 'AWD', 4, 800),
			('Bentley', 'Bentayga', 'Suv', 608, 6.0, 'AWD', 4, 520),
			('Lamborghini', 'Urus', 'Suv', 650, 4.0, 'AWD', 5, 500),
			('Mercedes-Benz', 'G63 AMG', 'Suv', 571, 4.0, 'AWD', 5, 500),
			('BMW', 'X5M', 'Suv', 625, 4.4, 'AWD', 5, 400),
			('Range Rover', 'Vogue', 'Suv', 339, 4.4, 'AWD', 5, 200),
			('Porsche', 'Cayenne', 'Suv', 350, 3.0, 'AWD', 5, 160)

GO