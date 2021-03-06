USE [master]
GO
/****** Object:  Database [HotelManagementSystem]    Script Date: 13-01-2021 19:02:11 ******/
CREATE DATABASE [HotelManagementSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HotelManagementSystem', FILENAME = N'C:\Users\Gamers\HotelManagementSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HotelManagementSystem_log', FILENAME = N'C:\Users\Gamers\HotelManagementSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [HotelManagementSystem] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HotelManagementSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HotelManagementSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HotelManagementSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HotelManagementSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HotelManagementSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HotelManagementSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [HotelManagementSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HotelManagementSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HotelManagementSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HotelManagementSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HotelManagementSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HotelManagementSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HotelManagementSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HotelManagementSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HotelManagementSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HotelManagementSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HotelManagementSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HotelManagementSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HotelManagementSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HotelManagementSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HotelManagementSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HotelManagementSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HotelManagementSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HotelManagementSystem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HotelManagementSystem] SET  MULTI_USER 
GO
ALTER DATABASE [HotelManagementSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HotelManagementSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HotelManagementSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HotelManagementSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HotelManagementSystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HotelManagementSystem] SET QUERY_STORE = OFF
GO
USE [HotelManagementSystem]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [HotelManagementSystem]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 13-01-2021 19:02:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[BookingId] [int] IDENTITY(1,1) NOT NULL,
	[RoomId] [int] NULL,
	[BookingDate] [datetime] NULL,
	[StatusOfBooking] [nvarchar](50) NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[BookingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hotel]    Script Date: 13-01-2021 19:02:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HotelName] [nvarchar](100) NULL,
	[Address] [nvarchar](500) NULL,
	[City] [nvarchar](50) NULL,
	[Pincode] [nvarchar](50) NULL,
	[ContactNumber] [nvarchar](50) NULL,
	[ContactPerson] [nvarchar](50) NULL,
	[Website] [nvarchar](500) NULL,
	[IsActive] [nvarchar](10) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[Facebook] [nvarchar](500) NULL,
	[Twitter] [nvarchar](500) NULL,
 CONSTRAINT [PK_Hotel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 13-01-2021 19:02:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[RoomId] [int] IDENTITY(1,1) NOT NULL,
	[HotelId] [int] NULL,
	[RoomName] [nvarchar](50) NULL,
	[RoomCategory] [nvarchar](50) NULL,
	[RoomPrice] [decimal](18, 0) NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[RoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Booking] ON 

INSERT [dbo].[Booking] ([BookingId], [RoomId], [BookingDate], [StatusOfBooking]) VALUES (1, 2, CAST(N'2021-02-03T00:00:00.000' AS DateTime), N'Deleted')
INSERT [dbo].[Booking] ([BookingId], [RoomId], [BookingDate], [StatusOfBooking]) VALUES (2, 2, CAST(N'2021-02-04T00:00:00.000' AS DateTime), N'Deleted')
INSERT [dbo].[Booking] ([BookingId], [RoomId], [BookingDate], [StatusOfBooking]) VALUES (3, 1, CAST(N'2021-02-08T00:00:00.000' AS DateTime), N'Cancelled')
INSERT [dbo].[Booking] ([BookingId], [RoomId], [BookingDate], [StatusOfBooking]) VALUES (4, 3, CAST(N'2021-02-09T00:00:00.000' AS DateTime), N'Definitive')
INSERT [dbo].[Booking] ([BookingId], [RoomId], [BookingDate], [StatusOfBooking]) VALUES (5, 1, CAST(N'2021-02-02T00:00:00.000' AS DateTime), N'Deleted')
INSERT [dbo].[Booking] ([BookingId], [RoomId], [BookingDate], [StatusOfBooking]) VALUES (6, 1, CAST(N'2021-10-02T00:00:00.000' AS DateTime), N'Optional')
SET IDENTITY_INSERT [dbo].[Booking] OFF
GO
SET IDENTITY_INSERT [dbo].[Hotel] ON 

INSERT [dbo].[Hotel] ([Id], [HotelName], [Address], [City], [Pincode], [ContactNumber], [ContactPerson], [Website], [IsActive], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [Facebook], [Twitter]) VALUES (1, N'Ruby Guest House', N'11, PQR road, Ahmedabad', N'Ahmedabad', N'382350', N'9876543210', N'Freney', N'Ruby.com', N'true', CAST(N'2020-08-12T00:00:00.000' AS DateTime), N'Freney', CAST(N'2020-08-15T00:00:00.000' AS DateTime), N'Freney', N'https://www.facebook.com/RubyGuestHouse', N'https://www.twitter.com/RubyGuestHouse')
INSERT [dbo].[Hotel] ([Id], [HotelName], [Address], [City], [Pincode], [ContactNumber], [ContactPerson], [Website], [IsActive], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [Facebook], [Twitter]) VALUES (2, N'Emrald Hotel', N'99, XYZ road, Delhi', N'Delhi', N'480095', N'9898989898', N'Kenish', N'Emrald.com', N'true', CAST(N'2019-04-21T00:00:00.000' AS DateTime), N'Kenish', CAST(N'2019-04-23T00:00:00.000' AS DateTime), N'Kenish', N'https://www.facebook.com/EmraldHotel', N'https://www.twitter/EmraldHotel')
INSERT [dbo].[Hotel] ([Id], [HotelName], [Address], [City], [Pincode], [ContactNumber], [ContactPerson], [Website], [IsActive], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [Facebook], [Twitter]) VALUES (3, N'Diamond High', N'B/93, ABC road, Kolkata', N'Kolkata', N'342005', N'8978978976', N'Chandler', N'Diamond.com', N'true', CAST(N'2018-02-17T00:00:00.000' AS DateTime), N'Chandler', CAST(N'2018-02-21T00:00:00.000' AS DateTime), N'Chandler', N'https://www.facebook.com/DiamondHigh', N'https://www.twitter/DiamondHigh')
INSERT [dbo].[Hotel] ([Id], [HotelName], [Address], [City], [Pincode], [ContactNumber], [ContactPerson], [Website], [IsActive], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [Facebook], [Twitter]) VALUES (4, N'Hotel Paradise', N'D/93, C.G road, Pune', N'Pune', N'346205', N'7989675678', N'Phoebe', N'Paradise.com', N'True', CAST(N'2021-01-13T17:47:25.227' AS DateTime), N'Phoebe', CAST(N'2021-01-13T17:47:25.227' AS DateTime), N'Phoebe', N'https://www.facebook.com/HotelParadise', N'https://www.twitter.com/HotelParadise')
INSERT [dbo].[Hotel] ([Id], [HotelName], [Address], [City], [Pincode], [ContactNumber], [ContactPerson], [Website], [IsActive], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [Facebook], [Twitter]) VALUES (5, N'Greenland Exotica', N'sector-9, Shivji road, Mumbai', N'Mumbai', N'396209', N'7768988743', N'Monica', N'Greenland.com', N'True', CAST(N'2021-01-13T17:52:03.940' AS DateTime), N'Monica', CAST(N'2021-01-13T17:52:03.940' AS DateTime), N'Monica', N'https://www.facebook.com/GreenlandExotica', N'https://www.twitter.com/GreenlandExotica')
INSERT [dbo].[Hotel] ([Id], [HotelName], [Address], [City], [Pincode], [ContactNumber], [ContactPerson], [Website], [IsActive], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [Facebook], [Twitter]) VALUES (6, N'Karnavati Kingdom', N'11, Gota road, Ahmedabad', N'Ahmedabad', N'382350', N'8897654320', N'Rachel', N'KarnavatiKingdom.com', N'True', CAST(N'2021-01-13T17:58:23.003' AS DateTime), N'Rachel', CAST(N'2021-01-13T17:58:23.003' AS DateTime), N'Rachel', N'https://www.facebook.com/KarnavatiKingdom', N'https://www.twitter.com/KarnavatiKingdom')
INSERT [dbo].[Hotel] ([Id], [HotelName], [Address], [City], [Pincode], [ContactNumber], [ContactPerson], [Website], [IsActive], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [Facebook], [Twitter]) VALUES (7, N'Dastan Hotel', N'11, Nikol road, Ahmedabad', N'Ahmedabad', N'382350', N'8897687659', N'Ross', N'DastanHotel.com', N'True', CAST(N'2021-01-13T18:04:55.627' AS DateTime), N'Ross', CAST(N'2021-01-13T18:04:55.627' AS DateTime), N'Ross', N'https://www.facebook.com/DastanHotel', N'https://www.twitter.com/DastanHotel')
SET IDENTITY_INSERT [dbo].[Hotel] OFF
GO
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([RoomId], [HotelId], [RoomName], [RoomCategory], [RoomPrice], [IsActive], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (1, 2, N'Gold', N'Category1', CAST(790 AS Decimal(18, 0)), 1, CAST(N'2019-09-09T00:00:00.000' AS DateTime), N'Kenish', CAST(N'2019-09-09T00:00:00.000' AS DateTime), N'Kenish')
INSERT [dbo].[Room] ([RoomId], [HotelId], [RoomName], [RoomCategory], [RoomPrice], [IsActive], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (2, 3, N'Queen', N'Category2', CAST(1100 AS Decimal(18, 0)), 1, CAST(N'2018-02-22T00:00:00.000' AS DateTime), N'Chandler', CAST(N'2018-02-23T00:00:00.000' AS DateTime), N'Chandler')
INSERT [dbo].[Room] ([RoomId], [HotelId], [RoomName], [RoomCategory], [RoomPrice], [IsActive], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (3, 1, N'King', N'Category3', CAST(1300 AS Decimal(18, 0)), 1, CAST(N'2020-09-01T00:00:00.000' AS DateTime), N'Freney', CAST(N'2020-09-02T00:00:00.000' AS DateTime), N'Freney')
INSERT [dbo].[Room] ([RoomId], [HotelId], [RoomName], [RoomCategory], [RoomPrice], [IsActive], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (4, 4, N'Studio', N'Category3', CAST(1900 AS Decimal(18, 0)), 1, CAST(N'2020-09-01T00:00:00.000' AS DateTime), N'Phoebe', CAST(N'2020-09-02T00:00:00.000' AS DateTime), N'Phoebe')
INSERT [dbo].[Room] ([RoomId], [HotelId], [RoomName], [RoomCategory], [RoomPrice], [IsActive], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (5, 4, N'Twin', N'Category3', CAST(2200 AS Decimal(18, 0)), 1, CAST(N'2020-09-01T00:00:00.000' AS DateTime), N'Phoebe', CAST(N'2020-09-02T00:00:00.000' AS DateTime), N'Phoebe')
INSERT [dbo].[Room] ([RoomId], [HotelId], [RoomName], [RoomCategory], [RoomPrice], [IsActive], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (6, 4, N'Master', N'Category1', CAST(1500 AS Decimal(18, 0)), 1, CAST(N'2020-09-01T00:00:00.000' AS DateTime), N'Phoebe', CAST(N'2020-09-02T00:00:00.000' AS DateTime), N'Phoebe')
INSERT [dbo].[Room] ([RoomId], [HotelId], [RoomName], [RoomCategory], [RoomPrice], [IsActive], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (7, 5, N'Master', N'Category2', CAST(1600 AS Decimal(18, 0)), 1, CAST(N'2020-09-09T00:00:00.000' AS DateTime), N'Monica', CAST(N'2020-09-09T00:00:00.000' AS DateTime), N'Monica')
INSERT [dbo].[Room] ([RoomId], [HotelId], [RoomName], [RoomCategory], [RoomPrice], [IsActive], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (8, 5, N'Space', N'Category3', CAST(2200 AS Decimal(18, 0)), 1, CAST(N'2020-09-09T00:00:00.000' AS DateTime), N'Monica', CAST(N'2020-09-09T00:00:00.000' AS DateTime), N'Monica')
INSERT [dbo].[Room] ([RoomId], [HotelId], [RoomName], [RoomCategory], [RoomPrice], [IsActive], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (9, 5, N'Small', N'Category1', CAST(1400 AS Decimal(18, 0)), 1, CAST(N'2020-09-09T00:00:00.000' AS DateTime), N'Monica', CAST(N'2020-09-09T00:00:00.000' AS DateTime), N'Monica')
INSERT [dbo].[Room] ([RoomId], [HotelId], [RoomName], [RoomCategory], [RoomPrice], [IsActive], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (10, 6, N'Mini', N'Category1', CAST(1100 AS Decimal(18, 0)), 1, CAST(N'2020-05-09T00:00:00.000' AS DateTime), N'Rachel', CAST(N'2020-05-09T00:00:00.000' AS DateTime), N'Rachel')
INSERT [dbo].[Room] ([RoomId], [HotelId], [RoomName], [RoomCategory], [RoomPrice], [IsActive], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (11, 6, N'President', N'Category3', CAST(3000 AS Decimal(18, 0)), 1, CAST(N'2020-05-09T00:00:00.000' AS DateTime), N'Rachel', CAST(N'2020-05-09T00:00:00.000' AS DateTime), N'Rachel')
INSERT [dbo].[Room] ([RoomId], [HotelId], [RoomName], [RoomCategory], [RoomPrice], [IsActive], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (12, 6, N'Murphy', N'Category2', CAST(2500 AS Decimal(18, 0)), 1, CAST(N'2020-05-09T00:00:00.000' AS DateTime), N'Rachel', CAST(N'2020-05-09T00:00:00.000' AS DateTime), N'Rachel')
INSERT [dbo].[Room] ([RoomId], [HotelId], [RoomName], [RoomCategory], [RoomPrice], [IsActive], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (13, 7, N'Cabana', N'Category3', CAST(5000 AS Decimal(18, 0)), 1, CAST(N'2020-05-09T00:00:00.000' AS DateTime), N'Ross', CAST(N'2020-05-09T00:00:00.000' AS DateTime), N'Ross')
INSERT [dbo].[Room] ([RoomId], [HotelId], [RoomName], [RoomCategory], [RoomPrice], [IsActive], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (14, 7, N'Single', N'Category1', CAST(2500 AS Decimal(18, 0)), 1, CAST(N'2020-05-09T00:00:00.000' AS DateTime), N'Ross', CAST(N'2020-05-09T00:00:00.000' AS DateTime), N'Ross')
INSERT [dbo].[Room] ([RoomId], [HotelId], [RoomName], [RoomCategory], [RoomPrice], [IsActive], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (15, 7, N'Double', N'Category2', CAST(3500 AS Decimal(18, 0)), 1, CAST(N'2020-05-09T00:00:00.000' AS DateTime), N'Ross', CAST(N'2020-05-09T00:00:00.000' AS DateTime), N'Ross')
SET IDENTITY_INSERT [dbo].[Room] OFF
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Room] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Room] ([RoomId])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Room]
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_Hotel] FOREIGN KEY([HotelId])
REFERENCES [dbo].[Hotel] ([Id])
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [FK_Room_Hotel]
GO
USE [master]
GO
ALTER DATABASE [HotelManagementSystem] SET  READ_WRITE 
GO
