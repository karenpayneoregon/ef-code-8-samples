USE [BookCatalog]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 11/19/2023 5:41:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Price] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Book] ON 

INSERT [dbo].[Book] ([Id], [Title], [Price]) VALUES (1, N'Learn EF Core', CAST(19 AS Decimal(18, 0)))
INSERT [dbo].[Book] ([Id], [Title], [Price]) VALUES (2, N'C# Basics', CAST(18 AS Decimal(18, 0)))
INSERT [dbo].[Book] ([Id], [Title], [Price]) VALUES (3, N'ASP.NET Core advance', CAST(30 AS Decimal(18, 0)))
INSERT [dbo].[Book] ([Id], [Title], [Price]) VALUES (4, N'VB.NET To C#', CAST(9 AS Decimal(18, 0)))
INSERT [dbo].[Book] ([Id], [Title], [Price]) VALUES (5, N'Basic Azure', CAST(59 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[Book] OFF
GO
USE [master]
GO
ALTER DATABASE [BookCatalog] SET  READ_WRITE 
GO
