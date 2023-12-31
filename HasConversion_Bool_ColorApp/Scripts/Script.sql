
USE [EF.Friends]
GO
/****** Object:  Table [dbo].[People]    Script Date: 1/8/2024 4:08:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[People](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[IsFriend] [nvarchar](3) NOT NULL,
	[Color] [nvarchar](max) NOT NULL,
	[DateTime] [datetime2](7) NULL,
	[BirthDate] [date] NULL,
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[People] ON 

INSERT [dbo].[People] ([Id], [FirstName], [LastName], [IsFriend], [Color], [DateTime], [BirthDate]) VALUES (1, N'Jim', N'Jacobe', N'Yes', N'AliceBlue', CAST(N'2022-05-05T00:00:00.0000000' AS DateTime2), CAST(N'1943-03-04' AS Date))
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [IsFriend], [Color], [DateTime], [BirthDate]) VALUES (2, N'Bob', N'Smith', N'No', N'Coral', NULL, CAST(N'1967-12-12' AS Date))
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [IsFriend], [Color], [DateTime], [BirthDate]) VALUES (3, N'Karen', N'Payne', N'Yes', N'Red', NULL, CAST(N'1956-09-24' AS Date))
SET IDENTITY_INSERT [dbo].[People] OFF
GO
USE [master]
GO
ALTER DATABASE [EF.Friends] SET  READ_WRITE 
GO
