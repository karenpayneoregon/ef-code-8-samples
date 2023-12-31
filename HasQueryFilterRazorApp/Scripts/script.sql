SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[ContactId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[LastUpdated] [datetime2](7) NULL,
	[LastUser] [nvarchar](max) NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[ContactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact1](
	[ContactId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[LastUpdated] [datetime2](7) NULL,
	[LastUser] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[isDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Contact1] PRIMARY KEY CLUSTERED 
(
	[ContactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Contact1] ON 

INSERT [dbo].[Contact1] ([ContactId], [FirstName], [LastName], [LastUpdated], [LastUser], [CreatedAt], [CreatedBy], [isDeleted]) VALUES (1, N'Claude', N'Murray', CAST(N'2022-04-22T16:38:08.7636853' AS DateTime2), N'PayneK', CAST(N'2022-04-22T16:38:08.7714327' AS DateTime2), N'PayneK', 0)
INSERT [dbo].[Contact1] ([ContactId], [FirstName], [LastName], [LastUpdated], [LastUser], [CreatedAt], [CreatedBy], [isDeleted]) VALUES (2, N'Lamar', N'Sporer', CAST(N'2022-04-22T16:38:08.7723615' AS DateTime2), N'PayneK', CAST(N'2022-04-22T16:38:08.7727438' AS DateTime2), N'PayneK', 0)
INSERT [dbo].[Contact1] ([ContactId], [FirstName], [LastName], [LastUpdated], [LastUser], [CreatedAt], [CreatedBy], [isDeleted]) VALUES (3, N'Alicia', N'Murphy', CAST(N'2022-04-22T16:38:08.7729828' AS DateTime2), N'PayneK', CAST(N'2022-04-22T16:38:08.7732037' AS DateTime2), N'PayneK', 0)
INSERT [dbo].[Contact1] ([ContactId], [FirstName], [LastName], [LastUpdated], [LastUser], [CreatedAt], [CreatedBy], [isDeleted]) VALUES (4, N'Kirk', N'Stiedemann', CAST(N'2022-04-22T16:38:08.7734284' AS DateTime2), N'PayneK', CAST(N'2022-04-22T16:38:08.7736909' AS DateTime2), N'PayneK', 0)
INSERT [dbo].[Contact1] ([ContactId], [FirstName], [LastName], [LastUpdated], [LastUser], [CreatedAt], [CreatedBy], [isDeleted]) VALUES (5, N'Matthew', N'Abernathy', CAST(N'2022-04-22T16:38:08.7739325' AS DateTime2), N'PayneK', CAST(N'2022-04-22T16:38:08.7742232' AS DateTime2), N'PayneK', 0)
INSERT [dbo].[Contact1] ([ContactId], [FirstName], [LastName], [LastUpdated], [LastUser], [CreatedAt], [CreatedBy], [isDeleted]) VALUES (6, N'Elena', N'Okuneva', CAST(N'2022-04-22T16:38:08.7744511' AS DateTime2), N'PayneK', CAST(N'2022-04-22T16:38:08.7746712' AS DateTime2), N'PayneK', 0)
INSERT [dbo].[Contact1] ([ContactId], [FirstName], [LastName], [LastUpdated], [LastUser], [CreatedAt], [CreatedBy], [isDeleted]) VALUES (7, N'Luz', N'Feest', CAST(N'2022-04-22T16:38:08.7748969' AS DateTime2), N'PayneK', CAST(N'2022-04-22T16:38:08.7751223' AS DateTime2), N'PayneK', 0)
INSERT [dbo].[Contact1] ([ContactId], [FirstName], [LastName], [LastUpdated], [LastUser], [CreatedAt], [CreatedBy], [isDeleted]) VALUES (8, N'Kenneth', N'Conn', CAST(N'2022-04-22T16:38:08.7753336' AS DateTime2), N'PayneK', CAST(N'2022-04-22T16:38:08.7755557' AS DateTime2), N'PayneK', 0)
INSERT [dbo].[Contact1] ([ContactId], [FirstName], [LastName], [LastUpdated], [LastUser], [CreatedAt], [CreatedBy], [isDeleted]) VALUES (9, N'Jeffery', N'Collins', CAST(N'2022-04-22T16:38:08.7757921' AS DateTime2), N'PayneK', CAST(N'2022-04-22T16:38:08.7760053' AS DateTime2), N'PayneK', 0)
INSERT [dbo].[Contact1] ([ContactId], [FirstName], [LastName], [LastUpdated], [LastUser], [CreatedAt], [CreatedBy], [isDeleted]) VALUES (10, N'Seth', N'Sipes', CAST(N'2022-04-22T16:38:08.7762164' AS DateTime2), N'PayneK', CAST(N'2022-04-22T16:38:08.7764254' AS DateTime2), N'PayneK', 0)
SET IDENTITY_INSERT [dbo].[Contact1] OFF
USE [master]
GO
ALTER DATABASE [EF.ShadowEntityCore] SET  READ_WRITE 
GO
