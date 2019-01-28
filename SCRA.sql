USE [SCRA]
GO
/****** Object:  Table [dbo].[Application]    Script Date: 1/28/2019 9:28:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Application](
	[ApplicationId] [int] NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[Code] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Application] PRIMARY KEY CLUSTERED 
(
	[ApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Contract]    Script Date: 1/28/2019 9:28:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contract](
	[ContractId] [int] NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Contract] PRIMARY KEY CLUSTERED 
(
	[ContractId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ContractPBP]    Script Date: 1/28/2019 9:28:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContractPBP](
	[ContractPBPId] [int] IDENTITY(1,1) NOT NULL,
	[ContractId] [int] NOT NULL,
	[PBPId] [int] NOT NULL,
 CONSTRAINT [PK_ContractPBP] PRIMARY KEY CLUSTERED 
(
	[ContractPBPId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Measure]    Script Date: 1/28/2019 9:28:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Measure](
	[MeasureId] [int] NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Measure] PRIMARY KEY CLUSTERED 
(
	[MeasureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PBP]    Script Date: 1/28/2019 9:28:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PBP](
	[PBPId] [int] NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_PBP] PRIMARY KEY CLUSTERED 
(
	[PBPId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rule]    Script Date: 1/28/2019 9:28:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rule](
	[RuleId] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Description] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Rule] PRIMARY KEY CLUSTERED 
(
	[RuleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RuleApplication]    Script Date: 1/28/2019 9:28:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RuleApplication](
	[RuleId] [int] NOT NULL,
	[ApplicationId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RuleId] ASC,
	[ApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RuleContract]    Script Date: 1/28/2019 9:28:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RuleContract](
	[RuleId] [int] NOT NULL,
	[ContractId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RuleId] ASC,
	[ContractId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RuleMeasure]    Script Date: 1/28/2019 9:28:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RuleMeasure](
	[RuleId] [int] NOT NULL,
	[MeasureId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RuleId] ASC,
	[MeasureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RulePBP]    Script Date: 1/28/2019 9:28:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RulePBP](
	[RuleId] [int] NOT NULL,
	[PBPId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RuleId] ASC,
	[PBPId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RuleSegment]    Script Date: 1/28/2019 9:28:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RuleSegment](
	[RuleId] [int] NOT NULL,
	[SegmentId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RuleId] ASC,
	[SegmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RuleTIN]    Script Date: 1/28/2019 9:28:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RuleTIN](
	[RuleId] [int] NOT NULL,
	[TINId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RuleId] ASC,
	[TINId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Segment]    Script Date: 1/28/2019 9:28:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Segment](
	[SegmentId] [int] NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Segment] PRIMARY KEY CLUSTERED 
(
	[SegmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TIN]    Script Date: 1/28/2019 9:28:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIN](
	[TINId] [int] NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TIN] PRIMARY KEY CLUSTERED 
(
	[TINId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 1/28/2019 9:28:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] NOT NULL,
	[UserName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserApplication]    Script Date: 1/28/2019 9:28:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserApplication](
	[UserId] [int] NOT NULL,
	[ApplicationId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[ApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserRule]    Script Date: 1/28/2019 9:28:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRule](
	[UserId] [int] NOT NULL,
	[RuleId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RuleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Application] ([ApplicationId], [Description], [Code]) VALUES (1, N'Application-1', N'App1')
GO
INSERT [dbo].[Application] ([ApplicationId], [Description], [Code]) VALUES (2, N'Application-2', N'App2')
GO
INSERT [dbo].[Application] ([ApplicationId], [Description], [Code]) VALUES (3, N'Application-3', N'App3')
GO
INSERT [dbo].[Contract] ([ContractId], [Description]) VALUES (1, N'H1045')
GO
INSERT [dbo].[Contract] ([ContractId], [Description]) VALUES (2, N'H2228')
GO
INSERT [dbo].[Contract] ([ContractId], [Description]) VALUES (3, N'H2406')
GO
INSERT [dbo].[Contract] ([ContractId], [Description]) VALUES (4, N'R5420')
GO
INSERT [dbo].[Contract] ([ContractId], [Description]) VALUES (5, N'R7444')
GO
SET IDENTITY_INSERT [dbo].[ContractPBP] ON 

GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (1, 1, 1)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (2, 1, 2)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (3, 1, 3)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (4, 1, 4)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (5, 1, 5)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (6, 1, 6)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (7, 1, 7)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (8, 2, 8)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (9, 2, 9)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (10, 2, 10)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (11, 2, 11)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (12, 2, 12)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (13, 2, 13)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (14, 2, 14)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (15, 2, 15)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (16, 2, 16)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (17, 2, 17)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (18, 3, 18)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (19, 3, 19)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (20, 3, 20)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (21, 3, 21)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (22, 3, 22)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (23, 3, 23)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (24, 4, 24)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (25, 4, 25)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (26, 4, 26)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (27, 4, 27)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (28, 4, 28)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (29, 4, 29)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (30, 4, 30)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (31, 5, 31)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (32, 5, 32)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (33, 5, 33)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (34, 5, 34)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (35, 5, 35)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (36, 5, 36)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (37, 5, 37)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (38, 5, 38)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (39, 5, 39)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (40, 5, 40)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (41, 5, 41)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (42, 5, 42)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (43, 5, 43)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (44, 5, 44)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (45, 5, 45)
GO
SET IDENTITY_INSERT [dbo].[ContractPBP] OFF
GO
INSERT [dbo].[Measure] ([MeasureId], [Description]) VALUES (1, N'MA')
GO
INSERT [dbo].[Measure] ([MeasureId], [Description]) VALUES (2, N'MRP')
GO
INSERT [dbo].[Measure] ([MeasureId], [Description]) VALUES (3, N'ART')
GO
INSERT [dbo].[Measure] ([MeasureId], [Description]) VALUES (4, N'OMW')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (1, N'001')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (2, N'002')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (3, N'003')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (4, N'004')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (5, N'005')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (6, N'006')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (7, N'007')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (8, N'008')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (9, N'009')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (10, N'010')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (11, N'011')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (12, N'012')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (13, N'013')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (14, N'014')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (15, N'015')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (16, N'016')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (17, N'017')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (18, N'018')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (19, N'019')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (20, N'020')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (21, N'021')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (22, N'022')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (23, N'023')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (24, N'024')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (25, N'025')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (26, N'026')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (27, N'027')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (28, N'028')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (29, N'029')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (30, N'030')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (31, N'031')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (32, N'032')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (33, N'033')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (34, N'034')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (35, N'035')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (36, N'036')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (37, N'037')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (38, N'038')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (39, N'039')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (40, N'040')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (41, N'041')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (42, N'042')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (43, N'043')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (44, N'044')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (45, N'045')
GO
SET IDENTITY_INSERT [dbo].[Rule] ON 

GO
INSERT [dbo].[Rule] ([RuleId], [Code], [Description]) VALUES (42, N'R1', N'Test Core - 2')
GO
INSERT [dbo].[Rule] ([RuleId], [Code], [Description]) VALUES (44, N'R1', N'Test Core - 3')
GO
SET IDENTITY_INSERT [dbo].[Rule] OFF
GO
INSERT [dbo].[RuleApplication] ([RuleId], [ApplicationId]) VALUES (42, 2)
GO
INSERT [dbo].[RuleApplication] ([RuleId], [ApplicationId]) VALUES (44, 2)
GO
INSERT [dbo].[RuleContract] ([RuleId], [ContractId]) VALUES (42, 1)
GO
INSERT [dbo].[RuleContract] ([RuleId], [ContractId]) VALUES (44, 1)
GO
INSERT [dbo].[RuleMeasure] ([RuleId], [MeasureId]) VALUES (42, 1)
GO
INSERT [dbo].[RuleMeasure] ([RuleId], [MeasureId]) VALUES (44, 1)
GO
INSERT [dbo].[RulePBP] ([RuleId], [PBPId]) VALUES (42, 1)
GO
INSERT [dbo].[RulePBP] ([RuleId], [PBPId]) VALUES (42, 2)
GO
INSERT [dbo].[RulePBP] ([RuleId], [PBPId]) VALUES (44, 1)
GO
INSERT [dbo].[RuleSegment] ([RuleId], [SegmentId]) VALUES (42, 1)
GO
INSERT [dbo].[RuleSegment] ([RuleId], [SegmentId]) VALUES (44, 1)
GO
INSERT [dbo].[RuleTIN] ([RuleId], [TINId]) VALUES (42, 2)
GO
INSERT [dbo].[RuleTIN] ([RuleId], [TINId]) VALUES (44, 2)
GO
INSERT [dbo].[Segment] ([SegmentId], [Description]) VALUES (1, N'ACO')
GO
INSERT [dbo].[Segment] ([SegmentId], [Description]) VALUES (2, N'DNSP')
GO
INSERT [dbo].[Segment] ([SegmentId], [Description]) VALUES (3, N'FL-N')
GO
INSERT [dbo].[Segment] ([SegmentId], [Description]) VALUES (4, N'FL-S')
GO
INSERT [dbo].[Segment] ([SegmentId], [Description]) VALUES (5, N'FL-S DSNP')
GO
INSERT [dbo].[Segment] ([SegmentId], [Description]) VALUES (6, N'FL-S WELLMED')
GO
INSERT [dbo].[Segment] ([SegmentId], [Description]) VALUES (7, N'GROUP')
GO
INSERT [dbo].[Segment] ([SegmentId], [Description]) VALUES (8, N'TVH')
GO
INSERT [dbo].[Segment] ([SegmentId], [Description]) VALUES (9, N'WELLMED')
GO
INSERT [dbo].[TIN] ([TINId], [Description]) VALUES (1, N'152454')
GO
INSERT [dbo].[TIN] ([TINId], [Description]) VALUES (2, N'548444')
GO
INSERT [dbo].[TIN] ([TINId], [Description]) VALUES (3, N'456845')
GO
INSERT [dbo].[TIN] ([TINId], [Description]) VALUES (4, N'456344')
GO
INSERT [dbo].[TIN] ([TINId], [Description]) VALUES (5, N'654745')
GO
INSERT [dbo].[TIN] ([TINId], [Description]) VALUES (6, N'654647')
GO
INSERT [dbo].[TIN] ([TINId], [Description]) VALUES (7, N'656134')
GO
INSERT [dbo].[TIN] ([TINId], [Description]) VALUES (8, N'987538')
GO
INSERT [dbo].[TIN] ([TINId], [Description]) VALUES (9, N'553845')
GO
INSERT [dbo].[TIN] ([TINId], [Description]) VALUES (10, N'77897')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (1, N'Ana Paula')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (2, N'Juan Perez')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (3, N'Alejandro Fernandez')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (4, N'Alexa Cruz')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (5, N'Dan Duffield')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (6, N'Alysia Adger')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (7, N'Cathern Crew')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (8, N'Joseph Jeanbaptiste')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (9, N'Mandie Mciver')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (10, N'Deetta Donato')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (11, N'Carmela Capasso')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (12, N'Laine Lunt')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (13, N'Latonya Lawerence')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (14, N'Jon Corrie')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (15, N'Peter Pittmon')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (16, N'Ken Kneeland')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (17, N'Eleanora Egerton')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (18, N'Shelley Sheffey')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (19, N'Catina Cattaneo')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (20, N'Tasia Tarkington')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (21, N'Wally Wieczorek')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (22, N'Jule Joye')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (23, N'Enoch Espitia')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (24, N'Kenyetta Kayser')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (25, N'Doyle Dennis')
GO
INSERT [dbo].[UserApplication] ([UserId], [ApplicationId]) VALUES (1, 1)
GO
INSERT [dbo].[UserApplication] ([UserId], [ApplicationId]) VALUES (1, 2)
GO
INSERT [dbo].[UserApplication] ([UserId], [ApplicationId]) VALUES (2, 1)
GO
INSERT [dbo].[UserApplication] ([UserId], [ApplicationId]) VALUES (2, 2)
GO
INSERT [dbo].[UserApplication] ([UserId], [ApplicationId]) VALUES (3, 1)
GO
INSERT [dbo].[UserApplication] ([UserId], [ApplicationId]) VALUES (3, 2)
GO
INSERT [dbo].[UserApplication] ([UserId], [ApplicationId]) VALUES (4, 1)
GO
INSERT [dbo].[UserApplication] ([UserId], [ApplicationId]) VALUES (5, 1)
GO
INSERT [dbo].[UserApplication] ([UserId], [ApplicationId]) VALUES (6, 1)
GO
INSERT [dbo].[UserApplication] ([UserId], [ApplicationId]) VALUES (7, 1)
GO
INSERT [dbo].[UserApplication] ([UserId], [ApplicationId]) VALUES (8, 1)
GO
INSERT [dbo].[UserApplication] ([UserId], [ApplicationId]) VALUES (9, 1)
GO
INSERT [dbo].[UserApplication] ([UserId], [ApplicationId]) VALUES (10, 1)
GO
INSERT [dbo].[UserApplication] ([UserId], [ApplicationId]) VALUES (10, 2)
GO
INSERT [dbo].[UserApplication] ([UserId], [ApplicationId]) VALUES (11, 2)
GO
INSERT [dbo].[UserApplication] ([UserId], [ApplicationId]) VALUES (12, 2)
GO
INSERT [dbo].[UserApplication] ([UserId], [ApplicationId]) VALUES (13, 2)
GO
INSERT [dbo].[UserApplication] ([UserId], [ApplicationId]) VALUES (14, 2)
GO
INSERT [dbo].[UserApplication] ([UserId], [ApplicationId]) VALUES (15, 2)
GO
INSERT [dbo].[UserApplication] ([UserId], [ApplicationId]) VALUES (16, 3)
GO
INSERT [dbo].[UserApplication] ([UserId], [ApplicationId]) VALUES (17, 3)
GO
INSERT [dbo].[UserApplication] ([UserId], [ApplicationId]) VALUES (18, 3)
GO
INSERT [dbo].[UserApplication] ([UserId], [ApplicationId]) VALUES (19, 3)
GO
INSERT [dbo].[UserApplication] ([UserId], [ApplicationId]) VALUES (20, 3)
GO
INSERT [dbo].[UserApplication] ([UserId], [ApplicationId]) VALUES (21, 3)
GO
INSERT [dbo].[UserApplication] ([UserId], [ApplicationId]) VALUES (22, 3)
GO
INSERT [dbo].[UserApplication] ([UserId], [ApplicationId]) VALUES (23, 3)
GO
INSERT [dbo].[UserApplication] ([UserId], [ApplicationId]) VALUES (24, 3)
GO
INSERT [dbo].[UserApplication] ([UserId], [ApplicationId]) VALUES (25, 3)
GO
INSERT [dbo].[UserRule] ([UserId], [RuleId]) VALUES (1, 42)
GO
INSERT [dbo].[UserRule] ([UserId], [RuleId]) VALUES (2, 42)
GO
/****** Object:  Index [IX_ContractPBP]    Script Date: 1/28/2019 9:28:05 AM ******/
ALTER TABLE [dbo].[ContractPBP] ADD  CONSTRAINT [IX_ContractPBP] UNIQUE NONCLUSTERED 
(
	[ContractId] ASC,
	[PBPId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RuleApplication]    Script Date: 1/28/2019 9:28:05 AM ******/
ALTER TABLE [dbo].[RuleApplication] ADD  CONSTRAINT [IX_RuleApplication] UNIQUE NONCLUSTERED 
(
	[RuleId] ASC,
	[ApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RuleContract]    Script Date: 1/28/2019 9:28:05 AM ******/
ALTER TABLE [dbo].[RuleContract] ADD  CONSTRAINT [IX_RuleContract] UNIQUE NONCLUSTERED 
(
	[RuleId] ASC,
	[ContractId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RuleMeasure]    Script Date: 1/28/2019 9:28:05 AM ******/
ALTER TABLE [dbo].[RuleMeasure] ADD  CONSTRAINT [IX_RuleMeasure] UNIQUE NONCLUSTERED 
(
	[RuleId] ASC,
	[MeasureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RulePBP]    Script Date: 1/28/2019 9:28:05 AM ******/
ALTER TABLE [dbo].[RulePBP] ADD  CONSTRAINT [IX_RulePBP] UNIQUE NONCLUSTERED 
(
	[RuleId] ASC,
	[PBPId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RuleSegment]    Script Date: 1/28/2019 9:28:05 AM ******/
ALTER TABLE [dbo].[RuleSegment] ADD  CONSTRAINT [IX_RuleSegment] UNIQUE NONCLUSTERED 
(
	[RuleId] ASC,
	[SegmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RuleTIN]    Script Date: 1/28/2019 9:28:05 AM ******/
ALTER TABLE [dbo].[RuleTIN] ADD  CONSTRAINT [IX_RuleTIN] UNIQUE NONCLUSTERED 
(
	[RuleId] ASC,
	[TINId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserApplication]    Script Date: 1/28/2019 9:28:05 AM ******/
ALTER TABLE [dbo].[UserApplication] ADD  CONSTRAINT [IX_UserApplication] UNIQUE NONCLUSTERED 
(
	[UserId] ASC,
	[ApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserRule]    Script Date: 1/28/2019 9:28:05 AM ******/
ALTER TABLE [dbo].[UserRule] ADD  CONSTRAINT [IX_UserRule] UNIQUE NONCLUSTERED 
(
	[RuleId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ContractPBP]  WITH CHECK ADD  CONSTRAINT [FK_ContractPBP_Contract] FOREIGN KEY([ContractId])
REFERENCES [dbo].[Contract] ([ContractId])
GO
ALTER TABLE [dbo].[ContractPBP] CHECK CONSTRAINT [FK_ContractPBP_Contract]
GO
ALTER TABLE [dbo].[ContractPBP]  WITH CHECK ADD  CONSTRAINT [FK_ContractPBP_PBP] FOREIGN KEY([PBPId])
REFERENCES [dbo].[PBP] ([PBPId])
GO
ALTER TABLE [dbo].[ContractPBP] CHECK CONSTRAINT [FK_ContractPBP_PBP]
GO
ALTER TABLE [dbo].[RuleApplication]  WITH CHECK ADD  CONSTRAINT [FK_RuleApplication_Application] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[Application] ([ApplicationId])
GO
ALTER TABLE [dbo].[RuleApplication] CHECK CONSTRAINT [FK_RuleApplication_Application]
GO
ALTER TABLE [dbo].[RuleApplication]  WITH CHECK ADD  CONSTRAINT [FK_RuleApplication_Rule] FOREIGN KEY([RuleId])
REFERENCES [dbo].[Rule] ([RuleId])
GO
ALTER TABLE [dbo].[RuleApplication] CHECK CONSTRAINT [FK_RuleApplication_Rule]
GO
ALTER TABLE [dbo].[RuleContract]  WITH CHECK ADD  CONSTRAINT [FK_RuleContract_Contract] FOREIGN KEY([ContractId])
REFERENCES [dbo].[Contract] ([ContractId])
GO
ALTER TABLE [dbo].[RuleContract] CHECK CONSTRAINT [FK_RuleContract_Contract]
GO
ALTER TABLE [dbo].[RuleContract]  WITH CHECK ADD  CONSTRAINT [FK_RuleContract_Rule] FOREIGN KEY([RuleId])
REFERENCES [dbo].[Rule] ([RuleId])
GO
ALTER TABLE [dbo].[RuleContract] CHECK CONSTRAINT [FK_RuleContract_Rule]
GO
ALTER TABLE [dbo].[RuleMeasure]  WITH CHECK ADD  CONSTRAINT [FK_RuleMeasure_Measure] FOREIGN KEY([MeasureId])
REFERENCES [dbo].[Measure] ([MeasureId])
GO
ALTER TABLE [dbo].[RuleMeasure] CHECK CONSTRAINT [FK_RuleMeasure_Measure]
GO
ALTER TABLE [dbo].[RuleMeasure]  WITH CHECK ADD  CONSTRAINT [FK_RuleMeasure_Rule] FOREIGN KEY([RuleId])
REFERENCES [dbo].[Rule] ([RuleId])
GO
ALTER TABLE [dbo].[RuleMeasure] CHECK CONSTRAINT [FK_RuleMeasure_Rule]
GO
ALTER TABLE [dbo].[RulePBP]  WITH CHECK ADD  CONSTRAINT [FK_RulePBP_PBP] FOREIGN KEY([PBPId])
REFERENCES [dbo].[PBP] ([PBPId])
GO
ALTER TABLE [dbo].[RulePBP] CHECK CONSTRAINT [FK_RulePBP_PBP]
GO
ALTER TABLE [dbo].[RulePBP]  WITH CHECK ADD  CONSTRAINT [FK_RulePBP_Rule] FOREIGN KEY([RuleId])
REFERENCES [dbo].[Rule] ([RuleId])
GO
ALTER TABLE [dbo].[RulePBP] CHECK CONSTRAINT [FK_RulePBP_Rule]
GO
ALTER TABLE [dbo].[RuleSegment]  WITH CHECK ADD  CONSTRAINT [FK_RuleSegment_Rule] FOREIGN KEY([RuleId])
REFERENCES [dbo].[Rule] ([RuleId])
GO
ALTER TABLE [dbo].[RuleSegment] CHECK CONSTRAINT [FK_RuleSegment_Rule]
GO
ALTER TABLE [dbo].[RuleSegment]  WITH CHECK ADD  CONSTRAINT [FK_RuleSegment_Segment] FOREIGN KEY([SegmentId])
REFERENCES [dbo].[Segment] ([SegmentId])
GO
ALTER TABLE [dbo].[RuleSegment] CHECK CONSTRAINT [FK_RuleSegment_Segment]
GO
ALTER TABLE [dbo].[RuleTIN]  WITH CHECK ADD  CONSTRAINT [FK_RuleTIN_Rule] FOREIGN KEY([RuleId])
REFERENCES [dbo].[Rule] ([RuleId])
GO
ALTER TABLE [dbo].[RuleTIN] CHECK CONSTRAINT [FK_RuleTIN_Rule]
GO
ALTER TABLE [dbo].[RuleTIN]  WITH CHECK ADD  CONSTRAINT [FK_RuleTIN_TIN] FOREIGN KEY([TINId])
REFERENCES [dbo].[TIN] ([TINId])
GO
ALTER TABLE [dbo].[RuleTIN] CHECK CONSTRAINT [FK_RuleTIN_TIN]
GO
ALTER TABLE [dbo].[UserApplication]  WITH CHECK ADD  CONSTRAINT [FK_UserApplication_Application] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[Application] ([ApplicationId])
GO
ALTER TABLE [dbo].[UserApplication] CHECK CONSTRAINT [FK_UserApplication_Application]
GO
ALTER TABLE [dbo].[UserApplication]  WITH CHECK ADD  CONSTRAINT [FK_UserApplication_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[UserApplication] CHECK CONSTRAINT [FK_UserApplication_User]
GO
ALTER TABLE [dbo].[UserRule]  WITH CHECK ADD  CONSTRAINT [FK_UserRule_Rule] FOREIGN KEY([RuleId])
REFERENCES [dbo].[Rule] ([RuleId])
GO
ALTER TABLE [dbo].[UserRule] CHECK CONSTRAINT [FK_UserRule_Rule]
GO
ALTER TABLE [dbo].[UserRule]  WITH CHECK ADD  CONSTRAINT [FK_UserRule_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[UserRule] CHECK CONSTRAINT [FK_UserRule_User]
GO
