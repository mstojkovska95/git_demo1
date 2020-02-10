USE [TicketSales]
GO
/****** Object:  Table [dbo].[Concert]    Script Date: 10-Feb-20 8:36:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Concert](
	[Concert_Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](500) NULL,
	[Artist_Name] [varchar](50) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Venue] [varchar](50) NULL,
	[City] [varchar](50) NOT NULL,
	[Country] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Concert_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 10-Feb-20 8:36:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Customer_Id] [int] IDENTITY(1,1) NOT NULL,
	[First_Name] [varchar](50) NOT NULL,
	[Last_Name] [varchar](50) NOT NULL,
	[Age] [int] NOT NULL,
	[Email] [varchar](50) NULL,
	[Address] [varchar](50) NOT NULL,
	[City] [varchar](50) NULL,
	[Country] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Customer_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservations]    Script Date: 10-Feb-20 8:36:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Customer_Id] [int] NOT NULL,
	[Ticket_Id] [int] NOT NULL,
	[Reservation_Time] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ticket]    Script Date: 10-Feb-20 8:36:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ticket](
	[Ticket_Id] [int] IDENTITY(1,1) NOT NULL,
	[Concert_Id] [int] NOT NULL,
	[Price] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Ticket_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLogin]    Script Date: 10-Feb-20 8:36:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Role] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Concert] ON 

INSERT [dbo].[Concert] ([Concert_Id], [Name], [Description], [Artist_Name], [Date], [Venue], [City], [Country]) VALUES (1, N'Sting-My Songs', N'The My Songs Tour is a world tour by British singer-songwriter Sting, in support of his thirteenth solo studio album My Songs, released on 24 May 2020.', N'Sting', CAST(N'2020-06-02T20:00:00.000' AS DateTime), N'Philip II Arena', N'Skopje', N'Macedonia')
INSERT [dbo].[Concert] ([Concert_Id], [Name], [Description], [Artist_Name], [Date], [Venue], [City], [Country]) VALUES (2, N'Lenny Kravitz Tour', N'As part of his european tour presenting the newest album “Raise Vibration” , LENNY KRAVITZ is having a show in Skopje on May 3th in VIP ARENA.', N'Lenny Kravitz', CAST(N'2020-05-03T20:00:00.000' AS DateTime), N'VIP ARENA', N'Skopje', N'Macedonia')
INSERT [dbo].[Concert] ([Concert_Id], [Name], [Description], [Artist_Name], [Date], [Venue], [City], [Country]) VALUES (3, N'Vita ce n`e-Tour', N'As part of its world tour "Vita ce n`e", which will cover all continents, one of the worlds biggest singing stars, EROS RAMAZZOTTI will also hold a concert in Skopje at the VIP Arena on September 30, 2020', N'Eros Ramazzotti', CAST(N'2020-09-30T20:00:00.000' AS DateTime), N'VIP Arena', N'Skopje', N'Macedonia')
SET IDENTITY_INSERT [dbo].[Concert] OFF
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([Customer_Id], [First_Name], [Last_Name], [Age], [Email], [Address], [City], [Country]) VALUES (1, N'Rachel', N'Green', 24, N'Rachelgreen@gmail.com', N'Hinkle Deegan Lake Road', N'Long Island', N'New York')
INSERT [dbo].[Customers] ([Customer_Id], [First_Name], [Last_Name], [Age], [Email], [Address], [City], [Country]) VALUES (2, N'Cynthia', N'Gill', 32, N'CynthiaJGill@dayrep.com', N'63 Hall Street', N'Las Vegas', N'Nevada')
INSERT [dbo].[Customers] ([Customer_Id], [First_Name], [Last_Name], [Age], [Email], [Address], [City], [Country]) VALUES (3, N'Lucas', N'Obryan', 33, N'LucasFObryan@teleworm.us', N'477 Frosty Lane', N'Brooklyn', N'New York')
INSERT [dbo].[Customers] ([Customer_Id], [First_Name], [Last_Name], [Age], [Email], [Address], [City], [Country]) VALUES (4, N'Marco', N'Wagner', 41, N' MarcoWagner@teleworm.de', N'Prenzlauer Allee 85', N'Leipzig', N'Germany')
INSERT [dbo].[Customers] ([Customer_Id], [First_Name], [Last_Name], [Age], [Email], [Address], [City], [Country]) VALUES (5, N'Emmanuel', N'Bois', 29, N'EmmanuelBois@teleworm.fr', N'99, rue Nationale', N'Paris', N'France')
INSERT [dbo].[Customers] ([Customer_Id], [First_Name], [Last_Name], [Age], [Email], [Address], [City], [Country]) VALUES (6, N'Marija', N'Stojkovska', 24, N'stojkovska@gmail.com', N'bitola', N'bitola', N'makedonija')
SET IDENTITY_INSERT [dbo].[Customers] OFF
SET IDENTITY_INSERT [dbo].[Reservations] ON 

INSERT [dbo].[Reservations] ([Id], [Customer_Id], [Ticket_Id], [Reservation_Time]) VALUES (1, 1, 1, CAST(N'2020-02-10T14:28:11.627' AS DateTime))
INSERT [dbo].[Reservations] ([Id], [Customer_Id], [Ticket_Id], [Reservation_Time]) VALUES (2, 6, 2, CAST(N'2020-02-10T19:01:10.450' AS DateTime))
SET IDENTITY_INSERT [dbo].[Reservations] OFF
SET IDENTITY_INSERT [dbo].[Ticket] ON 

INSERT [dbo].[Ticket] ([Ticket_Id], [Concert_Id], [Price]) VALUES (1, 1, 2000)
INSERT [dbo].[Ticket] ([Ticket_Id], [Concert_Id], [Price]) VALUES (2, 1, 2000)
INSERT [dbo].[Ticket] ([Ticket_Id], [Concert_Id], [Price]) VALUES (3, 1, 2000)
INSERT [dbo].[Ticket] ([Ticket_Id], [Concert_Id], [Price]) VALUES (4, 1, 2000)
INSERT [dbo].[Ticket] ([Ticket_Id], [Concert_Id], [Price]) VALUES (5, 1, 2000)
INSERT [dbo].[Ticket] ([Ticket_Id], [Concert_Id], [Price]) VALUES (6, 2, 2500)
INSERT [dbo].[Ticket] ([Ticket_Id], [Concert_Id], [Price]) VALUES (8, 2, 2500)
INSERT [dbo].[Ticket] ([Ticket_Id], [Concert_Id], [Price]) VALUES (9, 2, 2500)
INSERT [dbo].[Ticket] ([Ticket_Id], [Concert_Id], [Price]) VALUES (10, 2, 2500)
INSERT [dbo].[Ticket] ([Ticket_Id], [Concert_Id], [Price]) VALUES (11, 3, 1500)
INSERT [dbo].[Ticket] ([Ticket_Id], [Concert_Id], [Price]) VALUES (12, 3, 1500)
INSERT [dbo].[Ticket] ([Ticket_Id], [Concert_Id], [Price]) VALUES (13, 3, 1500)
INSERT [dbo].[Ticket] ([Ticket_Id], [Concert_Id], [Price]) VALUES (14, 3, 1500)
INSERT [dbo].[Ticket] ([Ticket_Id], [Concert_Id], [Price]) VALUES (15, 3, 1500)
SET IDENTITY_INSERT [dbo].[Ticket] OFF
SET IDENTITY_INSERT [dbo].[UserLogin] ON 

INSERT [dbo].[UserLogin] ([Id], [UserName], [Password], [Email], [Role]) VALUES (1, N'admin', N'123456', N'admin@gmail.com', N'admin')
INSERT [dbo].[UserLogin] ([Id], [UserName], [Password], [Email], [Role]) VALUES (2, N'user123', N'123456', N'user123@gmail.com', N'user')
SET IDENTITY_INSERT [dbo].[UserLogin] OFF
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD FOREIGN KEY([Customer_Id])
REFERENCES [dbo].[Customers] ([Customer_Id])
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD  CONSTRAINT [FK_Reservations] FOREIGN KEY([Ticket_Id])
REFERENCES [dbo].[Ticket] ([Ticket_Id])
GO
ALTER TABLE [dbo].[Reservations] CHECK CONSTRAINT [FK_Reservations]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD FOREIGN KEY([Concert_Id])
REFERENCES [dbo].[Concert] ([Concert_Id])
GO
/****** Object:  StoredProcedure [dbo].[AddTicket]    Script Date: 10-Feb-20 8:36:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddTicket]
@Concert_Id int,
@Price int
AS
	INSERT INTO Ticket(Concert_Id,Price)
	VALUES(@Concert_Id,@Price);
GO
/****** Object:  StoredProcedure [dbo].[BuyTicket]    Script Date: 10-Feb-20 8:36:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BuyTicket]
@Customer_Id int,
@Ticket_Id int
AS
	INSERT INTO Reservations(Customer_Id,Ticket_Id,Reservation_Time)
	VALUES(@Customer_Id,@Ticket_Id,GETDATE());
GO
/****** Object:  StoredProcedure [dbo].[CreateCustomer]    Script Date: 10-Feb-20 8:36:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateCustomer]
@First_Name varchar(50),
@Last_Name varchar(50),
@Age int,
@Email varchar(50),
@Address varchar(50),
@City varchar(50),
@Country varchar(50)
AS
INSERT INTO Customers(First_Name,Last_Name,Age,Email,Address,City,Country)
VALUES(@First_Name,@Last_Name,@Age,@Email,@Address,@City,@Country);
GO
/****** Object:  StoredProcedure [dbo].[CreateEvent]    Script Date: 10-Feb-20 8:36:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateEvent]
@Name varchar(50),
@Description varchar(500),
@Artist_Name varchar(50),
@Date datetime,
@Venue varchar(50),
@City varchar(50),
@Country varchar(50)
AS
INSERT INTO Concert(Name,Description,Artist_Name,Date,Venue,City,Country)
VALUES(@Name,@Description,@Artist_Name,@Date,@Venue,@City,@Country);
GO
/****** Object:  StoredProcedure [dbo].[DeleteCustomer]    Script Date: 10-Feb-20 8:36:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteCustomer]
@Id int
AS
DELETE FROM Customers
WHERE Customer_Id=@Id;
GO
/****** Object:  StoredProcedure [dbo].[DeleteEvent]    Script Date: 10-Feb-20 8:36:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteEvent]
@Id int
AS
DELETE FROM Concert
WHERE Concert_Id=@Id;
GO
/****** Object:  StoredProcedure [dbo].[DeleteTicket]    Script Date: 10-Feb-20 8:36:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteTicket]
@Id int
AS
	DELETE FROM Ticket
	WHERE Ticket_Id=@Id;
GO
/****** Object:  StoredProcedure [dbo].[GetBoughtTicketsByConcert]    Script Date: 10-Feb-20 8:36:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBoughtTicketsByConcert]
@Concert_Id int
AS
SELECT COUNT(t.Ticket_Id) AS TicketsBought, c.Concert_Id,c.Name,c.Description ,c.Artist_Name,c.Date,c.Venue,c.City,c.Country
FROM Concert c INNER JOIN Ticket t ON c.Concert_Id=t.Concert_Id
INNER JOIN Reservations r ON  t.Ticket_Id=r.Ticket_Id
WHERE c.Concert_Id=@Concert_Id AND Reservation_Time IS NOT NULL
GROUP BY c.Concert_Id,c.Name,c.Description ,c.Artist_Name,c.Date,c.Venue,c.City,c.Country;
GO
/****** Object:  StoredProcedure [dbo].[GetBoughtTicketsByCustomers]    Script Date: 10-Feb-20 8:36:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBoughtTicketsByCustomers]
@Customer_Id int
AS
SELECT COUNT(t.Ticket_Id) AS Tickets_Bought ,c.Customer_Id,c.First_Name,c.Last_Name,c.Age,c.Address,c.City,c.Country
FROM Customers c INNER JOIN Reservations r ON c.Customer_Id=r.Customer_Id
INNER JOIN Ticket t ON  r.Ticket_Id=t.Ticket_Id
WHERE c.Customer_Id=@Customer_Id 
GROUP BY c.Customer_Id,c.First_Name,c.Last_Name,c.Age,c.Address,c.City,c.Country;
GO
/****** Object:  StoredProcedure [dbo].[GetCustomer]    Script Date: 10-Feb-20 8:36:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCustomer]
@Id int
AS

SELECT Customer_Id,First_Name,Last_Name,Age,Email,Address,City,Country
FROM Customers
WHERE Customer_Id=@Id;
GO
/****** Object:  StoredProcedure [dbo].[GetReservations]    Script Date: 10-Feb-20 8:36:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetReservations]
AS
	SELECT *
	FROM Reservations;
GO
/****** Object:  StoredProcedure [dbo].[GetTicketId]    Script Date: 10-Feb-20 8:36:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTicketId]
@Id int
AS
	SELECT Ticket_Id,Concert_Id,Price
	FROM Ticket
	WHERE Ticket_Id=@Id;
GO
/****** Object:  StoredProcedure [dbo].[GetTickets]    Script Date: 10-Feb-20 8:36:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTickets]
AS
	SELECT Ticket_Id,Concert_Id,Price
	FROM Ticket;
GO
/****** Object:  StoredProcedure [dbo].[SelectConcerts]    Script Date: 10-Feb-20 8:36:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectConcerts]
AS
SELECT Concert_Id,Name,Description,Artist_Name,Date,Venue,City,Country
FROM Concert;
GO
/****** Object:  StoredProcedure [dbo].[SelectCustomers]    Script Date: 10-Feb-20 8:36:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectCustomers]
AS
SELECT Customer_Id,First_Name,Last_Name,Age,Email,Address,City,Country 
FROM Customers;
GO
/****** Object:  StoredProcedure [dbo].[SelectEvent]    Script Date: 10-Feb-20 8:36:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectEvent]
@Id int
AS
SELECT Concert_Id,Name,Description,Artist_Name,Date,Venue,City,Country
FROM Concert
WHERE Concert_Id =@Id;
GO
/****** Object:  StoredProcedure [dbo].[spUserLogin]    Script Date: 10-Feb-20 8:36:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUserLogin]   
    @username varchar(50)=null,  
    @password varchar(50)=null  
AS   
    SELECT  UserName, Password, Email, Role
	from UserLogin
	where UserName=@username and password=@password  
GO
/****** Object:  StoredProcedure [dbo].[UpdateAddress]    Script Date: 10-Feb-20 8:36:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateAddress]
@Id int,
@Address varchar(50)
AS
UPDATE Customers
SET Address=@Address 
WHERE Customer_Id=@Id;
GO
/****** Object:  StoredProcedure [dbo].[UpdateEvent]    Script Date: 10-Feb-20 8:36:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateEvent]
@Id int,
@Name varchar(50),
@Description varchar(500),
@Artist_Name varchar(50),
@Date datetime,
@Venue varchar(50),
@City varchar(50),
@Country varchar(50)
AS
UPDATE Concert
SET Name=@Name,Description=@Description,Artist_Name=@Artist_Name,Date=@Date,Venue=@Venue,City=@City,Country=@Country
WHERE Concert_Id=@Id;
GO
/****** Object:  StoredProcedure [dbo].[UpdateTicket]    Script Date: 10-Feb-20 8:36:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateTicket]
@Id int,
@Price int
AS
	UPDATE Ticket
	SET Price=@Price
	WHERE Ticket_Id=@Id;
GO
