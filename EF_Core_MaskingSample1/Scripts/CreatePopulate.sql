USE [MaskingDatabase]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 4/28/2025 8:07:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[BirthDate] [date] NOT NULL,
	[SocialSecurity] [nvarchar](max) NOT NULL,
	[CreditCard] [nvarchar](max) NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Person] ON 
GO
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [BirthDate], [SocialSecurity], [CreditCard]) VALUES (1, N'Stefanie', N'Buckley', CAST(N'1973-11-03' AS Date), N'954064725', N'5533836984057788')
GO
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [BirthDate], [SocialSecurity], [CreditCard]) VALUES (2, N'Sandy', N'Mc Gee', CAST(N'2002-07-12' AS Date), N'575473864', N'372844184478387')
GO
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [BirthDate], [SocialSecurity], [CreditCard]) VALUES (3, N'Lee', N'Warren', CAST(N'2014-05-31' AS Date), N'031369009', N'372629626418020')
GO
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [BirthDate], [SocialSecurity], [CreditCard]) VALUES (4, N'Regina', N'Forbes', CAST(N'1967-02-04' AS Date), N'102840365', N'5362537584445227')
GO
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [BirthDate], [SocialSecurity], [CreditCard]) VALUES (5, N'Daniel', N'Kim', CAST(N'1992-10-17' AS Date), N'785393139', N'5446346185248620')
GO
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [BirthDate], [SocialSecurity], [CreditCard]) VALUES (6, N'Dennis', N'Nunez', CAST(N'1965-10-27' AS Date), N'571765814', N'4792837382815164')
GO
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [BirthDate], [SocialSecurity], [CreditCard]) VALUES (7, N'Myra', N'Zuniga', CAST(N'1970-10-07' AS Date), N'525944869', N'371463105535919')
GO
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [BirthDate], [SocialSecurity], [CreditCard]) VALUES (8, N'Teddy', N'Ingram', CAST(N'2020-04-02' AS Date), N'196067150', N'4395059988777745')
GO
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [BirthDate], [SocialSecurity], [CreditCard]) VALUES (9, N'Annie', N'Larson', CAST(N'1977-10-04' AS Date), N'262405409', N'5259613325571534')
GO
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [BirthDate], [SocialSecurity], [CreditCard]) VALUES (10, N'Herman', N'Anderson', CAST(N'1979-12-24' AS Date), N'453559879', N'371174599456377')
GO
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [BirthDate], [SocialSecurity], [CreditCard]) VALUES (11, N'Jenifer', N'Livingston', CAST(N'1988-08-25' AS Date), N'024960241', N'4697555892432009')
GO
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [BirthDate], [SocialSecurity], [CreditCard]) VALUES (12, N'Stefanie', N'Perez', CAST(N'2010-06-21' AS Date), N'119930056', N'5137088692612872')
GO
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [BirthDate], [SocialSecurity], [CreditCard]) VALUES (13, N'Chastity', N'Garcia', CAST(N'2002-05-07' AS Date), N'242714655', N'340699143673851')
GO
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [BirthDate], [SocialSecurity], [CreditCard]) VALUES (14, N'Evelyn', N'Stokes', CAST(N'1955-02-25' AS Date), N'545799305', N'340707882244055')
GO
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [BirthDate], [SocialSecurity], [CreditCard]) VALUES (15, N'Jeannie', N'Daniel', CAST(N'1958-10-30' AS Date), N'599784590', N'5248201058191326')
GO
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [BirthDate], [SocialSecurity], [CreditCard]) VALUES (16, N'Rickey', N'Santos', CAST(N'2017-03-06' AS Date), N'472365572', N'341529714720337')
GO
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [BirthDate], [SocialSecurity], [CreditCard]) VALUES (17, N'Bobbie', N'Hurst', CAST(N'1961-10-07' AS Date), N'723861880', N'4796416550413890')
GO
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [BirthDate], [SocialSecurity], [CreditCard]) VALUES (18, N'Lesley', N'Lawson', CAST(N'2013-09-23' AS Date), N'157705413', N'370953437160221')
GO
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [BirthDate], [SocialSecurity], [CreditCard]) VALUES (19, N'Shawna', N'Browning', CAST(N'2006-11-05' AS Date), N'666497648', N'4281253308046991')
GO
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [BirthDate], [SocialSecurity], [CreditCard]) VALUES (20, N'Theresa', N'Ross', CAST(N'1986-10-23' AS Date), N'566885659', N'342506162053642')
GO
SET IDENTITY_INSERT [dbo].[Person] OFF
GO
USE [master]
GO
ALTER DATABASE [MaskingDatabase] SET  READ_WRITE 
GO
