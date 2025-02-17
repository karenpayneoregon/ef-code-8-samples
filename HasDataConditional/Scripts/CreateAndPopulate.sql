USE [HasDataExample]
GO
/****** Object:  Table [dbo].[ContactDevices]    Script Date: 1/22/2025 8:45:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactDevices](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ContactId] [int] NULL,
	[PhoneTypeIdentifier] [int] NULL,
	[PhoneNumber] [nvarchar](max) NULL,
 CONSTRAINT [PK_ContactDevices] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 1/22/2025 8:45:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[ContactId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[ContactTypeIdentifier] [int] NULL,
 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[ContactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContactType]    Script Date: 1/22/2025 8:45:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactType](
	[ContactTypeIdentifier] [int] IDENTITY(1,1) NOT NULL,
	[ContactTitle] [nvarchar](max) NULL,
 CONSTRAINT [PK_ContactType] PRIMARY KEY CLUSTERED 
(
	[ContactTypeIdentifier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhoneType]    Script Date: 1/22/2025 8:45:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhoneType](
	[PhoneTypeIdenitfier] [int] IDENTITY(1,1) NOT NULL,
	[PhoneTypeDescription] [nvarchar](max) NULL,
 CONSTRAINT [PK_PhoneType] PRIMARY KEY CLUSTERED 
(
	[PhoneTypeIdenitfier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ContactDevices] ON 

INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (1, 1, 3, N'(5) 555-4729')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (2, 2, 3, N'(5) 555-3932')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (3, 3, 3, N'(171) 555-7788')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (4, 4, 3, N'0921-12 34 65')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (5, 1, 1, N'(5) 555-4729')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (6, 5, 3, N'0921-12 34 35')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (7, 5, 2, N'0921-11 34 65')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (8, 5, 1, N'0921-10 34 65')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (9, 6, 3, N'0621-08460')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (10, 6, 2, N'0621-08444')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (11, 6, 1, N'0555-08460')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (12, 7, 3, N'88.60.15.31')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (13, 8, 3, N'(91) 555 22 82')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (14, 9, 3, N'91.24.45.40')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (15, 11, 3, N'(1) 135-5555')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (16, 12, 3, N'(5) 555-3392')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (17, 14, 3, N'(171) 555-2282')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (18, 15, 3, N'0241-039123')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (19, 16, 3, N'40.67.88.88')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (20, 17, 3, N'(171) 555-0297')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (21, 18, 3, N'7675-3425')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (22, 19, 3, N'(91) 555 94 44')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (23, 20, 3, N'20.16.10.16')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (24, 21, 3, N'0695-34 67 21')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (25, 22, 3, N'089-0877310')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (26, 23, 3, N'40.32.21.21')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (27, 24, 3, N'011-4988269')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (28, 25, 3, N'(1) 354-2534')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (29, 26, 3, N'(93) 203 4560')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (30, 27, 3, N'(95) 555 82 82')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (31, 28, 3, N'0555-09876')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (32, 29, 3, N'30.59.84.10')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (33, 30, 3, N'61.77.61.10')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (34, 31, 3, N'069-0245984')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (35, 32, 3, N'035-640230')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (36, 33, 3, N'(02) 201 24 67')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (37, 34, 3, N'0342-023176')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (38, 35, 3, N'(171) 555-7733')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (39, 36, 3, N'(1) 135-5333')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (40, 37, 3, N'0221-0644327')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (41, 38, 3, N'(1) 42.34.22.66')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (42, 39, 3, N'(5) 552-3745')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (43, 40, 3, N'6562-9722')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (44, 41, 3, N'(1) 356-5634')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (45, 42, 3, N'0372-035188')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (46, 43, 3, N'(1) 123-5555')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (47, 44, 3, N'0522-556721')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (48, 45, 3, N'0897-034214')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (49, 46, 3, N'(91) 745 6200')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (50, 47, 3, N'07-98 92 35')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (51, 48, 3, N'(171) 555-1717')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (52, 49, 3, N'31 12 34 56')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (53, 50, 3, N'(1) 47.55.60.10')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (54, 51, 3, N'(071) 23 67 22 20')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (55, 52, 3, N'0251-031259')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (56, 53, 3, N'(5) 555-2933')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (57, 54, 3, N'86 21 32 43')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (58, 55, 3, N'78.32.54.86')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (59, 56, 3, N'26.47.15.10')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (60, 57, 3, N'0711-020361')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (61, 58, 3, N'981-443655')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (62, 60, 3, N'(26) 642-7012')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (63, 61, 3, N'(907) 555-7584')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (64, 62, 3, N'(604) 555-4729')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (65, 63, 3, N'(604) 555-3392')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (66, 64, 3, N'(415) 555-5938')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (67, 65, 3, N'2967 542')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (68, 66, 3, N'(2) 283-2951')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (69, 67, 3, N'(208) 555-8097')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (70, 68, 3, N'(198) 555-8888')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (71, 69, 3, N'(9) 331-6954')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (72, 70, 3, N'(406) 555-5834')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (73, 71, 3, N'(505) 555-5939')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (74, 72, 3, N'(8) 34-56-12')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (75, 73, 3, N'(503) 555-7555')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (76, 74, 3, N'(503) 555-6874')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (77, 75, 3, N'(503) 555-9573')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (78, 76, 3, N'(503) 555-3612')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (79, 77, 3, N'(514) 555-8054')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (80, 78, 3, N'(21) 555-0091')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (81, 79, 3, N'(21) 555-4252')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (82, 80, 3, N'(21) 555-3412')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (83, 81, 3, N'(11) 555-7647')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (84, 82, 3, N'(11) 555-9857')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (85, 83, 3, N'(11) 555-9482')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (86, 84, 3, N'(11) 555-1189')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (87, 85, 3, N'(11) 555-2167')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (88, 86, 3, N'(14) 555-8122')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (89, 87, 3, N'(5) 555-1340')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (90, 88, 3, N'(509) 555-7969')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (91, 90, 3, N'(206) 555-8257')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (92, 91, 3, N'(206) 555-4112')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (93, 24, 1, N'011-4988270')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (94, 24, 2, N'022-4988255')
INSERT [dbo].[ContactDevices] ([id], [ContactId], [PhoneTypeIdentifier], [PhoneNumber]) VALUES (95, 1, 2, N'456-987-1234')
SET IDENTITY_INSERT [dbo].[ContactDevices] OFF
GO
SET IDENTITY_INSERT [dbo].[Contacts] ON 

INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (1, N'Maria', N'Anders', 1)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (2, N'Ana', N'Trujillo', 7)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (3, N'Antonio', N'Moreno', 7)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (4, N'Thomas', N'Hardy', 12)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (5, N'Christina', N'Berglund', 6)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (6, N'Hanna', N'Moos', 12)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (7, N'FrÃ©dÃ©rique', N'Citeaux', 5)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (8, N'MartÃ­n', N'Sommer', 7)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (9, N'Laurence', N'Lebihan', 7)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (10, N'Victoria', N'Ashworth', 1)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (11, N'Patricio', N'Simpson', 12)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (12, N'Francisco', N'Chang', 5)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (13, N'Yang', N'Wang', 7)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (14, N'Elizabeth', N'Brown', 12)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (15, N'Sven', N'Ottlieb', 6)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (16, N'Janine', N'Labrune', 7)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (17, N'Ann', N'Devon', 9)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (18, N'Roland', N'Mendel', 11)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (19, N'Die', N'Roel', 1)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (20, N'Martine', N'RancÃ©', 2)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (21, N'Maria', N'Larsson', 7)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (22, N'Peter', N'Franken', 5)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (23, N'Carine', N'Schmitt', 5)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (24, N'Paolo', N'Accorti', 12)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (25, N'Lino', N'Rodriguez', 11)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (26, N'Eduardo', N'Saavedra', 5)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (27, N'JosÃ©', N'Pedro Freyre', 11)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (28, N'Philip', N'Cramer', 10)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (29, N'Daniel', N'Tonini', 12)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (30, N'Annette', N'Roulet', 11)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (31, N'Renate', N'Messner', 12)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (32, N'Giovanni', N'Rovelli', 5)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (33, N'Catherine', N'Dewey', 9)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (34, N'Alexander', N'Feuer', 4)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (35, N'Simon', N'Crowther', 10)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (36, N'Yvonne', N'Moncada', 9)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (37, N'Henriette', N'Pfalzheim', 7)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (38, N'Marie', N'Bertrand', 7)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (39, N'Guillermo', N'FernÃ¡ndez', 12)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (40, N'Georg', N'Pipps', 11)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (41, N'Isabel', N'de Castro', 12)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (42, N'Horst', N'Kloss', 1)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (43, N'Sergio', N'GutiÃ©rrez', 12)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (44, N'Maurizio', N'Moroni', 10)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (45, N'Michael', N'Holz', 11)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (46, N'Alejandra', N'Camino', 1)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (47, N'Jonas', N'Bergulfsen', 7)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (48, N'Hari', N'Kumar', 11)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (49, N'Jytte', N'Petersen', 7)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (50, N'Dominique', N'Perrier', 5)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (51, N'Pascale', N'Cartrain', 1)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (52, N'Karin', N'Josephs', 5)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (53, N'Miguel', N'Angel Paolino', 7)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (54, N'Palle', N'Ibsen', 11)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (55, N'Mary', N'Saveley', 9)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (56, N'Paul', N'Henriot', 1)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (57, N'Rita', N'MÃ¼ller', 12)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (58, N'Pirkko', N'Koskitalo', 1)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (59, N'Matti', N'Karttunen', 8)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (60, N'Zbyszek', N'Piestrzeniewicz', 7)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (61, N'Rene', N'Phillips', 12)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (62, N'Elizabeth', N'Lincoln', 1)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (63, N'Yoshi', N'Tannamuri', 4)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (64, N'Jaime', N'Yorres', 7)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (65, N'Patricia', N'McKenna', 10)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (66, N'Manuel', N'Pereira', 7)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (67, N'Jose', N'Pavarotti', 12)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (68, N'Helen', N'Bennett', 5)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (69, N'Carlos', N'nzÃ¡lez', 1)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (70, N'Liu', N'Wong', 4)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (71, N'Paula', N'Wilson', 3)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (72, N'Felipe', N'Izquierdo', 7)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (73, N'Howard', N'Snyder', 5)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (74, N'Yoshi', N'Latimer', 12)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (75, N'Fran', N'Wilson', 11)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (76, N'Liz', N'Nixon', 5)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (77, N'Jean', N'FresniÃ¨re', 4)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (78, N'Mario', N'Pontes', 1)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (79, N'Bernardo', N'Batista', 1)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (80, N'Janete', N'Limeira', 2)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (81, N'Pedro', N'Afonso', 10)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (82, N'Aria', N'Cruz', 4)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (83, N'AndrÃ©', N'Fonseca', 10)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (84, N'LÃºcia', N'Carvalho', 4)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (85, N'Anabela', N'Domingues', 12)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (86, N'Paula', N'Parente', 11)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (87, N'Carlos', N'HernÃ¡ndez', 12)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (88, N'John', N'Steel', 5)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (89, N'Helvetius', N'Nagy', 10)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (90, N'Karl', N'Jablonski', 7)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (91, N'Art', N'Braunschweiger', 11)
SET IDENTITY_INSERT [dbo].[Contacts] OFF
GO
SET IDENTITY_INSERT [dbo].[ContactType] ON 

INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (1, N'Accounting Manager')
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (2, N'Assistant Sales Agent')
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (3, N'Assistant Sales Representative')
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (4, N'Marketing Assistant')
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (5, N'Marketing Manager')
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (6, N'Order Administrator')
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (7, N'Owner')
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (8, N'Owner/Marketing Assistant')
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (9, N'Sales Agent')
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (10, N'Sales Associate')
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (11, N'Sales Manager')
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (12, N'Sales Representative')
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (13, N'Vice President, Sales')
SET IDENTITY_INSERT [dbo].[ContactType] OFF
GO
SET IDENTITY_INSERT [dbo].[PhoneType] ON 

INSERT [dbo].[PhoneType] ([PhoneTypeIdenitfier], [PhoneTypeDescription]) VALUES (1, N'Home')
INSERT [dbo].[PhoneType] ([PhoneTypeIdenitfier], [PhoneTypeDescription]) VALUES (2, N'Cell')
INSERT [dbo].[PhoneType] ([PhoneTypeIdenitfier], [PhoneTypeDescription]) VALUES (3, N'Office')
SET IDENTITY_INSERT [dbo].[PhoneType] OFF
GO
ALTER TABLE [dbo].[ContactDevices]  WITH CHECK ADD  CONSTRAINT [FK_ContactDevices_Contacts1] FOREIGN KEY([ContactId])
REFERENCES [dbo].[Contacts] ([ContactId])
GO
ALTER TABLE [dbo].[ContactDevices] CHECK CONSTRAINT [FK_ContactDevices_Contacts1]
GO
ALTER TABLE [dbo].[ContactDevices]  WITH CHECK ADD  CONSTRAINT [FK_ContactDevices_PhoneType1] FOREIGN KEY([PhoneTypeIdentifier])
REFERENCES [dbo].[PhoneType] ([PhoneTypeIdenitfier])
GO
ALTER TABLE [dbo].[ContactDevices] CHECK CONSTRAINT [FK_ContactDevices_PhoneType1]
GO
ALTER TABLE [dbo].[Contacts]  WITH CHECK ADD  CONSTRAINT [FK_Contacts_ContactType] FOREIGN KEY([ContactTypeIdentifier])
REFERENCES [dbo].[ContactType] ([ContactTypeIdentifier])
GO
ALTER TABLE [dbo].[Contacts] CHECK CONSTRAINT [FK_Contacts_ContactType]
GO
USE [master]
GO
ALTER DATABASE [HasDataExample] SET  READ_WRITE 
GO
