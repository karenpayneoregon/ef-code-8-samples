USE [NorthWind2024]
GO
/****** Object:  UserDefinedFunction [dbo].[ConcatStrings]    Script Date: 2/9/2024 3:50:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ConcatStrings] (@prm1 nvarchar(max), @prm2 nvarchar(max))
RETURNS nvarchar(max)
AS
BEGIN
    RETURN @prm1 + ' ' +  @prm2;
END
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 2/9/2024 3:50:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[ContactId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[ContactTypeIdentifier] [int] NULL,
	[FullName]  AS (([FirstName]+' ')+[LastName]),
 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[ContactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContactType]    Script Date: 2/9/2024 3:50:37 AM ******/
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
SET IDENTITY_INSERT [dbo].[Contacts] ON 
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (1, N'Maria', N'Anders', 1)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (2, N'Ana', N'Trujillo', 7)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (3, N'Antonio', N'Moreno', 7)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (4, N'Thomas', N'Hardy', 12)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (5, N'Christina', N'Berglund', 6)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (6, N'Hanna', N'Moos', 12)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (7, N'FrÃ©dÃ©rique', N'Citeaux', 5)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (8, N'MartÃ­n', N'Sommer', 7)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (9, N'Laurence', N'Lebihan', 7)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (10, N'Victoria', N'Ashworth', 1)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (11, N'Patricio', N'Simpson', 12)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (12, N'Francisco', N'Chang', 5)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (13, N'Yang', N'Wang', 7)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (14, N'Elizabeth', N'Brown', 12)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (15, N'Sven', N'Ottlieb', 6)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (16, N'Janine', N'Labrune', 7)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (17, N'Ann', N'Devon', 9)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (18, N'Roland', N'Mendel', 11)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (19, N'Die', N'Roel', 1)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (20, N'Martine', N'RancÃ©', 2)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (21, N'Maria', N'Larsson', 7)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (22, N'Peter', N'Franken', 5)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (23, N'Carine', N'Schmitt', 5)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (24, N'Paolo', N'Accorti', 12)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (25, N'Lino', N'Rodriguez', 11)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (26, N'Eduardo', N'Saavedra', 5)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (27, N'JosÃ©', N'Pedro Freyre', 11)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (28, N'Philip', N'Cramer', 10)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (29, N'Daniel', N'Tonini', 12)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (30, N'Annette', N'Roulet', 11)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (31, N'Renate', N'Messner', 12)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (32, N'Giovanni', N'Rovelli', 5)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (33, N'Catherine', N'Dewey', 9)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (34, N'Alexander', N'Feuer', 4)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (35, N'Simon', N'Crowther', 10)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (36, N'Yvonne', N'Moncada', 9)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (37, N'Henriette', N'Pfalzheim', 7)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (38, N'Marie', N'Bertrand', 7)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (39, N'Guillermo', N'FernÃ¡ndez', 12)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (40, N'Georg', N'Pipps', 11)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (41, N'Isabel', N'de Castro', 12)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (42, N'Horst', N'Kloss', 1)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (43, N'Sergio', N'GutiÃ©rrez', 12)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (44, N'Maurizio', N'Moroni', 10)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (45, N'Michael', N'Holz', 11)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (46, N'Alejandra', N'Camino', 1)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (47, N'Jonas', N'Bergulfsen', 7)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (48, N'Hari', N'Kumar', 11)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (49, N'Jytte', N'Petersen', 7)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (50, N'Dominique', N'Perrier', 5)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (51, N'Pascale', N'Cartrain', 1)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (52, N'Karin', N'Josephs', 5)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (53, N'Miguel', N'Angel Paolino', 7)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (54, N'Palle', N'Ibsen', 11)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (55, N'Mary', N'Saveley', 9)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (56, N'Paul', N'Henriot', 1)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (57, N'Rita', N'MÃ¼ller', 12)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (58, N'Pirkko', N'Koskitalo', 1)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (59, N'Matti', N'Karttunen', 8)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (60, N'Zbyszek', N'Piestrzeniewicz', 7)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (61, N'Rene', N'Phillips', 12)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (62, N'Elizabeth', N'Lincoln', 1)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (63, N'Yoshi', N'Tannamuri', 4)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (64, N'Jaime', N'Yorres', 7)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (65, N'Patricia', N'McKenna', 10)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (66, N'Manuel', N'Pereira', 7)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (67, N'Jose', N'Pavarotti', 12)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (68, N'Helen', N'Bennett', 5)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (69, N'Carlos', N'nzÃ¡lez', 1)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (70, N'Liu', N'Wong', 4)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (71, N'Paula', N'Wilson', 3)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (72, N'Felipe', N'Izquierdo', 7)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (73, N'Howard', N'Snyder', 5)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (74, N'Yoshi', N'Latimer', 12)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (75, N'Fran', N'Wilson', 11)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (76, N'Liz', N'Nixon', 5)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (77, N'Jean', N'FresniÃ¨re', 4)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (78, N'Mario', N'Pontes', 1)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (79, N'Bernardo', N'Batista', 1)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (80, N'Janete', N'Limeira', 2)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (81, N'Pedro', N'Afonso', 10)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (82, N'Aria', N'Cruz', 4)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (83, N'AndrÃ©', N'Fonseca', 10)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (84, N'LÃºcia', N'Carvalho', 4)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (85, N'Anabela', N'Domingues', 12)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (86, N'Paula', N'Parente', 11)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (87, N'Carlos', N'HernÃ¡ndez', 12)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (88, N'John', N'Steel', 5)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (89, N'Helvetius', N'Nagy', 10)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (90, N'Karl', N'Jablonski', 7)
GO
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (91, N'Art', N'Braunschweiger', 11)
GO
SET IDENTITY_INSERT [dbo].[Contacts] OFF
GO
SET IDENTITY_INSERT [dbo].[ContactType] ON 
GO
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (1, N'Accounting Manager')
GO
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (2, N'Assistant Sales Agent')
GO
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (3, N'Assistant Sales Representative')
GO
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (4, N'Marketing Assistant')
GO
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (5, N'Marketing Manager')
GO
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (6, N'Order Administrator')
GO
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (7, N'Owner')
GO
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (8, N'Owner/Marketing Assistant')
GO
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (9, N'Sales Agent')
GO
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (10, N'Sales Associate')
GO
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (11, N'Sales Manager')
GO
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (12, N'Sales Representative')
GO
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (13, N'Vice President, Sales')
GO
SET IDENTITY_INSERT [dbo].[ContactType] OFF
GO
ALTER TABLE [dbo].[Contacts]  WITH CHECK ADD  CONSTRAINT [FK_Contacts_ContactType] FOREIGN KEY([ContactTypeIdentifier])
REFERENCES [dbo].[ContactType] ([ContactTypeIdentifier])
GO
ALTER TABLE [dbo].[Contacts] CHECK CONSTRAINT [FK_Contacts_ContactType]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Contacts', @level2type=N'COLUMN',@level2name=N'ContactId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'First name' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Contacts', @level2type=N'COLUMN',@level2name=N'FirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Last name' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Contacts', @level2type=N'COLUMN',@level2name=N'LastName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contact Type Identifier' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Contacts', @level2type=N'COLUMN',@level2name=N'ContactTypeIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Full name' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Contacts', @level2type=N'COLUMN',@level2name=N'FullName'
GO
