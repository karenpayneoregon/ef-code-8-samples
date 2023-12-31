
USE [ComputedSample]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 12/18/2022 2:33:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[BirthDate] [date] NULL,
	[YearsOld]  AS (datediff(year,[BirthDate],getdate())),
	[FullName]  AS (([FirstName]+' ')+[LastName]),
	[BirthYear]  AS (datepart(year,[BirthDate])),
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Contact] ON 

INSERT [dbo].[Contact] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (1, N'Karen', N'Payne', CAST(N'1956-09-24' AS Date))
INSERT [dbo].[Contact] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (2, N'Mike', N'Williams', CAST(N'1999-11-02' AS Date))
INSERT [dbo].[Contact] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (3, N'Jane', N'Adams', CAST(N'1999-10-11' AS Date))
INSERT [dbo].[Contact] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (4, N'Greg', N'Smith', CAST(N'1970-01-05' AS Date))
INSERT [dbo].[Contact] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (5, N'Anne', N'Harrison', CAST(N'1955-04-05' AS Date))
SET IDENTITY_INSERT [dbo].[Contact] OFF
GO
/****** Object:  Index [NonClusteredIndexYearsOld]    Script Date: 12/18/2022 2:33:22 PM ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndexYearsOld] ON [dbo].[Contact]
(
	[BirthDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [ComputedSample] SET  READ_WRITE 
GO
