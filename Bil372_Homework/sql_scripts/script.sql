/****** Object:  Database [Bil372HW]    Script Date: 2.12.2020 23:38:36 ******/
CREATE DATABASE [Bil372HW]  (EDITION = 'Basic', SERVICE_OBJECTIVE = 'Basic', MAXSIZE = 2 GB) WITH CATALOG_COLLATION = SQL_Latin1_General_CP1_CI_AS;
GO
ALTER DATABASE [Bil372HW] SET COMPATIBILITY_LEVEL = 150
GO
ALTER DATABASE [Bil372HW] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Bil372HW] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Bil372HW] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Bil372HW] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Bil372HW] SET ARITHABORT OFF 
GO
ALTER DATABASE [Bil372HW] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Bil372HW] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Bil372HW] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Bil372HW] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Bil372HW] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Bil372HW] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Bil372HW] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Bil372HW] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Bil372HW] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [Bil372HW] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Bil372HW] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Bil372HW] SET  MULTI_USER 
GO
ALTER DATABASE [Bil372HW] SET ENCRYPTION ON
GO
ALTER DATABASE [Bil372HW] SET QUERY_STORE = ON
GO
ALTER DATABASE [Bil372HW] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 7), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 10, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
/*** The scripts of database scoped configurations in Azure should be executed inside the target database connection. ***/
GO
-- ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 8;
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 2.12.2020 23:38:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConferenceRoles]    Script Date: 2.12.2020 23:38:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConferenceRoles](
	[AuthenticationID] [int] NOT NULL,
	[ConfID] [nvarchar](128) NOT NULL,
	[ConferenceRole] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ConferenceRoles] PRIMARY KEY CLUSTERED 
(
	[AuthenticationID] ASC,
	[ConfID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Conferences]    Script Date: 2.12.2020 23:38:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Conferences](
	[ConfID] [nvarchar](20) NOT NULL,
	[CreationDateTime] [datetime] NOT NULL,
	[Name] [nvarchar](100) NULL,
	[ShortName] [nvarchar](19) NULL,
	[Year] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[SubmisionDeadline] [datetime] NOT NULL,
	[CreatorUser] [int] NULL,
	[WebSite] [nvarchar](19) NULL,
 CONSTRAINT [PK_dbo.Conferences] PRIMARY KEY CLUSTERED 
(
	[ConfID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Submissions]    Script Date: 2.12.2020 23:38:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Submissions](
	[AuthenticationID] [int] NOT NULL,
	[ConfID] [int] NOT NULL,
	[SubmissionID] [int] NOT NULL,
	[prevSubmissionID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Submissions] PRIMARY KEY CLUSTERED 
(
	[AuthenticationID] ASC,
	[ConfID] ASC,
	[SubmissionID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserInfoes]    Script Date: 2.12.2020 23:38:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfoes](
	[AuthenticationID] [int] NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Affilation] [nvarchar](max) NULL,
	[primaryEmail] [nvarchar](max) NULL,
	[secondaryEmail] [nvarchar](max) NULL,
	[password] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[fax] [nvarchar](max) NULL,
	[URL] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[Country] [nvarchar](max) NULL,
	[Record] [nvarchar](max) NULL,
	[CreationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.UserInfoes] PRIMARY KEY CLUSTERED 
(
	[AuthenticationID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLogs]    Script Date: 2.12.2020 23:38:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogs](
	[AuthenticationID] [int] NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Affilation] [nvarchar](max) NULL,
	[primaryEmail] [nvarchar](max) NULL,
	[secondaryEmail] [nvarchar](max) NULL,
	[password] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[fax] [nvarchar](max) NULL,
	[URL] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[Country] [nvarchar](max) NULL,
	[Record] [nvarchar](max) NULL,
	[CreationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.UserLogs] PRIMARY KEY CLUSTERED 
(
	[AuthenticationID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2.12.2020 23:38:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[AuthenticationID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](20) NULL,
	[Password] [nvarchar](50) NULL,
	[Confirm] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[AuthenticationID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'202012021931121_InitialCreate', N'Bil372_Homework.Data.AppDbContext', 0x1F8B0800000000000400ED5D5B6FE4B6157E2FD0FF20E8A92D1C6BEC45D0AC3193C0F1A535BA5E1B1E6F9A3C2D3812672C44A2148A72ED16FD657DC84FCA5F28A92B6FBA50D2CC8E8341806087978F878747E7F072BEDDDFFEF7EBFCBB9730B09E214EFC082DEC93E3996D41E4469E8F360B3B25EBAFBEB1BFFBF68F7F985F79E18BF543D9EE1D6B477BA264613F11129F394EE23EC11024C7A1EFE22889D6E4D88D42077891733A9BBD774E4E1C48216C8A6559F38714113F84D90FFAF322422E8C490A82DBC883415294D39A65866A7D04214C62E0C285FDBD1FBCFBEBE9E7BF4721FC57847F3EBE0404D8D679E0032ACB12066BDB02084504102AE9D9A7042E098ED06619D302103CBEC690B65B832081C50CCEEAE67D27333B659371EA8E25949B26240A0D014FDE15DA71E4EE83746C57DAA3FABBA27A26AF6CD6990E173655F51A62BAC4F0210A60625BF29867170166ED554DE76B732C211C5952BBA3CA4CA835B1FF8EAC8B342029860B045382417064DDA7ABC077FF015F1FA39F215AA0340878B1A9E0B44E28A045F7388A2126AF0F705D4CE63C254F90CED0CD24BFB9B42DA7BB13935F6D3A77E411ABAE8D83E56ABA41E4DDA96D7DA47300AB0056C6E5B4A29552E418D446E907675BB7E0E503441BF2443FC5D36F6CEBDA7F815E5952E07E423EFD3E692782533868DC7AF54CE630776A63EA6962A3ACEB4B1AD6501BE95CD5D3D9561615C34CBBD417C247EA574B01EADF8680ECFF6DB639EB378DF641964F11265D23BD9F60A09F20C0E3BED6250198306D8ED6EC15F226C159A6ABD0671FC325045EE0A3F18899114598464C5959EDFDFE09574B9F4CBF881FC1B3BFC9CC5A1A3097F001065965F2E4C779E0E77CC7E7BCCD358E42E6E6789F94557D5E462966FEE931D2D73F02BC8164A003CC0737767DACDB3E47D3E94324A79C25353DF8378820A6F6EBDD034220A6DBA71B0F66DAED3242A6BB0E57D2D3F5B68F730F92842E8BD732CED7538CC3ECD1C7E156E273EE3A926C7F696CA475E77D365583A0AE6D5ACF72DF768A03E397309F31483186CF43D18C1CE80D5A47039D28EBBACFD6B96B0B7AF449D0E619E91F2770591DEE779A41CED76B3F28CEC65B1E2AC67E08F0EB5508FC60EB8325D08D90B7B3E1E2EE3036CD40F74F11DABE55AC19CA96C7F8F4F061FBD6ED791826C9D6C7B9C87654DB1E244A11C1DB1FE7817E3A3BB064FE8C6D7ED6323FCC94814C39CA0815CA4146AC1D7D8CF9106D060661DAF310830F31F810831BE77688C187187C88C1FB1E83691CD386E0B25C1B81AB4A93007C9E2491EB6732282F29B908E27CAE906775DC6EE6CB21DE8DD275A131D78F6994A5422CECBF288A6A062EA7C301E7BA112167C7C7270A2A8DCD0C8ABDC252D884467B1F113590FBC8F56310B40B20751B7A47E454C3C93597308688DD3DB66BB88F1CC2BDBA2A423592B43DE952D7DCE1ECA5DD8CC4AD64D35A37EC2BC595CE6F657AAC76136E4F0B9AC87CB463EFDC78B49A9D4A8A1DD94FE506DB9659F589E22A67A70963E3519CE9EE6C471EFA8B988EACD5BDB59C3CACD13E84F680B814258E2F57AC10BE10CD5992CEAC384E26C52640B60506BA84A42981A50EA64AA82B5A28D6D584D88ED609C4164907A173FD4AE7FA525D07C1BFD9F49082799B26497217DE0384DA5D1346F6214B109C51E8745B6CA2B8560DAFB6B29D766F732AE1A5B5544CBE7B63C34115AB295F1B88D3ECA102E9224755404B78EE11A025898B956F99BA3E1E6F69E2F5EE593F6F7D58E90E2C92B8B9A9764C5A892323E65CEEE12B6757D5CD9D3C67B128983B0DC98DF35B10C7F498C4253B1625D632CF74BCF86A699E0018E6188E9B68F2002B69AB91E8C6146CA054CB3E0F0F5EFB3861392F6005D861EAC20B9566826B6F7028E5507AEFADAE58E96DCA7EECCF795F5DE6A7E2ECD5E058005DD389862CB06699065A97D18060B134541000DC79417811056988FA46E066E4F2C997C76B7ABD6E47E153FD6434BE4E459D3B92E294FD83B256D2C7239B80A1814C6A1CA3ECA2BF494CB4704A3A9F80A7D4F647CEEF8779B4BCA43F0297B4C7C370C5FDB1F2BC3C1E262F3190A6CECB13A4A98BFB635599793C52556820939A9927C8A6561B5A467997A01845D32543335E95BBC76355857BE314F2E83CDA1DE8361A3D1C81BEDBEEA3429DE3C623D6A5FD91EA2C361EA92E358B31599E9AECF1B2C2BD3120FE7035DA8CB8B398B931B5757EAB1B0D311F4C7576FA3CBA364435CB8C47556BF7C6D0EA23D824DE2A3BAB0FF358FAAEBB37B1E2E19B872B8A76B96DE1DFAC859971E526E6C93F4B8BA6C9D7F44794DF9E794CB9CE404EAD9F8F07F8F9E20D59081779517F8CEC859847C80A0CE21F7BFD15421F2B30B081F265573080B2D0C069662FB782CBD464A8B72294CFB2A2DF2D0AFBE394CFAE3C4C5936ECB8D17CD4D833279BDDF84CE263D95DE63017ABED79F0B0070F7BF0B0070FFB063CAC72892D37A946AF2EB3A54BEB797181DC4DDB576E94F326B64555F5EC7BEC3679F99A10181667AC5F828BC0A7F3AD1BDC02E4AF6142F2BC50FB7476727A7CFEEF144389FDBF3F4C7C2749BC40730DDF42C71717EFED90E07DB652A3884DE81960F7895DFFC924F84918EEDD020EE1B70F58AE69A8E55A6D3186E344CC718FFE266399E3FA259D09520E228AEB81DF9BE2F2BCF02106ACB0C2076B4D62850FC66964850F46D4B0C2335529791C37C8832F0BFB3F59BF33EBE6C7CF5CD723EB0E53177E66CDACFF9AAE92C42F1FB4F666D4ED2D38E1919EB5931D6DB8AA325DBA873B19C28ED6C27E6D0C2B91A12774E54DB7B1BF6716F2F8503DC8576A38C343709AF8C7131A85FEF6742FFC400FAF2BF76F72BDE6ACA5F26BFE53085EFE6CFA0DEBBCCD2020957D340A4EC7301A05A867118D93B1C1AD0E0213D840A39038C6CF281C8ED533CE3244E6CE282C9E9D330E4864E08CC2125936E3C4D230697AEE118DF9A307377A70A30737DA887470A30737CA150F6701F26774336A9E2E2F7E307B7030D9E64BB2FA7E774CBE012C299522309CFEF7868CA025CF664F7855231879A3CD2063FA0CA4F1BD3123D02702EC890DE8B9752A4F435ECBD1E4B9FC9D8E86B515730779381BCEB0EB20D8B50FD63D506EE10D043C1DB89EF7D3CCCDEBA0E6E98610887D3DE4CF7D6C0B75AF691EACB6A78EB22FB899D9D734828E66B503DE1FBFAA7546B6FAD5E9B7317A4A8772A0FCB2BC3EB3E9C96622267D4E33B589987BE613E36C53C8B4EA3F2D03729E9ABF407D34F78F13D04091F89B1A82FD530508BA8277AEDA30ED97E14292A86C229D1F6E2101F4BC00CE31F1D7C025B49ABAB924FBDB537E00414A9B5C852BE8DDA0BB94C429A15386E12A10525858B0691B3F63208A32CFEFE2EC6F3A99620A544C9F1D79EED0F7A91F7895DCD79A234F03048B62C5E3165B4BC21EB936AF15D247250BAA09A8505F157C1F611807142CB9434BF00C87C846ADEF03DC00F7B54C436906E95E0851EDF34B1F6C30089302A3EE4F7F521BF6C2976FFF0FFBAF36AAA3630000, N'6.4.4')
GO
INSERT [dbo].[ConferenceRoles] ([AuthenticationID], [ConfID], [ConferenceRole]) VALUES (2, N'1', 0)
INSERT [dbo].[ConferenceRoles] ([AuthenticationID], [ConfID], [ConferenceRole]) VALUES (2, N'2', 2)
INSERT [dbo].[ConferenceRoles] ([AuthenticationID], [ConfID], [ConferenceRole]) VALUES (2, N'3', 1)
INSERT [dbo].[ConferenceRoles] ([AuthenticationID], [ConfID], [ConferenceRole]) VALUES (2, N'4', 0)
INSERT [dbo].[ConferenceRoles] ([AuthenticationID], [ConfID], [ConferenceRole]) VALUES (2, N'5', 0)
INSERT [dbo].[ConferenceRoles] ([AuthenticationID], [ConfID], [ConferenceRole]) VALUES (2, N'6', 0)
INSERT [dbo].[ConferenceRoles] ([AuthenticationID], [ConfID], [ConferenceRole]) VALUES (2, N'7', 0)
INSERT [dbo].[ConferenceRoles] ([AuthenticationID], [ConfID], [ConferenceRole]) VALUES (2, N'8', 1)
INSERT [dbo].[ConferenceRoles] ([AuthenticationID], [ConfID], [ConferenceRole]) VALUES (3, N'1', 0)
INSERT [dbo].[ConferenceRoles] ([AuthenticationID], [ConfID], [ConferenceRole]) VALUES (3, N'2', 2)
INSERT [dbo].[ConferenceRoles] ([AuthenticationID], [ConfID], [ConferenceRole]) VALUES (3, N'3', 1)
INSERT [dbo].[ConferenceRoles] ([AuthenticationID], [ConfID], [ConferenceRole]) VALUES (3, N'4', 0)
INSERT [dbo].[ConferenceRoles] ([AuthenticationID], [ConfID], [ConferenceRole]) VALUES (3, N'5', 0)
INSERT [dbo].[ConferenceRoles] ([AuthenticationID], [ConfID], [ConferenceRole]) VALUES (3, N'6', 0)
INSERT [dbo].[ConferenceRoles] ([AuthenticationID], [ConfID], [ConferenceRole]) VALUES (3, N'7', 0)
INSERT [dbo].[ConferenceRoles] ([AuthenticationID], [ConfID], [ConferenceRole]) VALUES (3, N'8', 1)
INSERT [dbo].[ConferenceRoles] ([AuthenticationID], [ConfID], [ConferenceRole]) VALUES (4, N'1', 0)
INSERT [dbo].[ConferenceRoles] ([AuthenticationID], [ConfID], [ConferenceRole]) VALUES (4, N'2', 2)
INSERT [dbo].[ConferenceRoles] ([AuthenticationID], [ConfID], [ConferenceRole]) VALUES (4, N'3', 1)
INSERT [dbo].[ConferenceRoles] ([AuthenticationID], [ConfID], [ConferenceRole]) VALUES (4, N'4', 0)
INSERT [dbo].[ConferenceRoles] ([AuthenticationID], [ConfID], [ConferenceRole]) VALUES (4, N'5', 0)
INSERT [dbo].[ConferenceRoles] ([AuthenticationID], [ConfID], [ConferenceRole]) VALUES (4, N'6', 0)
INSERT [dbo].[ConferenceRoles] ([AuthenticationID], [ConfID], [ConferenceRole]) VALUES (4, N'7', 0)
INSERT [dbo].[ConferenceRoles] ([AuthenticationID], [ConfID], [ConferenceRole]) VALUES (4, N'8', 1)
INSERT [dbo].[ConferenceRoles] ([AuthenticationID], [ConfID], [ConferenceRole]) VALUES (5, N'1', 0)
INSERT [dbo].[ConferenceRoles] ([AuthenticationID], [ConfID], [ConferenceRole]) VALUES (5, N'2', 2)
INSERT [dbo].[ConferenceRoles] ([AuthenticationID], [ConfID], [ConferenceRole]) VALUES (5, N'3', 1)
INSERT [dbo].[ConferenceRoles] ([AuthenticationID], [ConfID], [ConferenceRole]) VALUES (5, N'4', 0)
INSERT [dbo].[ConferenceRoles] ([AuthenticationID], [ConfID], [ConferenceRole]) VALUES (5, N'5', 0)
INSERT [dbo].[ConferenceRoles] ([AuthenticationID], [ConfID], [ConferenceRole]) VALUES (5, N'6', 0)
INSERT [dbo].[ConferenceRoles] ([AuthenticationID], [ConfID], [ConferenceRole]) VALUES (5, N'7', 0)
INSERT [dbo].[ConferenceRoles] ([AuthenticationID], [ConfID], [ConferenceRole]) VALUES (5, N'8', 1)
GO
INSERT [dbo].[Conferences] ([ConfID], [CreationDateTime], [Name], [ShortName], [Year], [StartDate], [EndDate], [SubmisionDeadline], [CreatorUser], [WebSite]) VALUES (N'_py_2021', CAST(N'2021-01-01T00:00:00.000' AS DateTime), N'Python', N'pyyy', 2021, CAST(N'2021-02-01T00:00:00.000' AS DateTime), CAST(N'2021-02-03T00:00:00.000' AS DateTime), CAST(N'2021-01-10T00:00:00.000' AS DateTime), 7, N'python.etu.edu.tr')
INSERT [dbo].[Conferences] ([ConfID], [CreationDateTime], [Name], [ShortName], [Year], [StartDate], [EndDate], [SubmisionDeadline], [CreatorUser], [WebSite]) VALUES (N'1', CAST(N'1894-06-13T00:00:00.000' AS DateTime), N'nano', N'mr', 2021, CAST(N'1894-07-07T00:00:00.000' AS DateTime), CAST(N'1894-07-11T00:00:00.000' AS DateTime), CAST(N'1894-07-03T00:00:00.000' AS DateTime), 1, N'www.bils.gov.tr')
INSERT [dbo].[Conferences] ([ConfID], [CreationDateTime], [Name], [ShortName], [Year], [StartDate], [EndDate], [SubmisionDeadline], [CreatorUser], [WebSite]) VALUES (N'10', CAST(N'1894-06-14T00:00:00.000' AS DateTime), N'nano', N'mr', 2021, CAST(N'1894-07-07T00:00:00.000' AS DateTime), CAST(N'1894-07-11T00:00:00.000' AS DateTime), CAST(N'1894-07-03T00:00:00.000' AS DateTime), 1, N'www.bils.gov.tr')
INSERT [dbo].[Conferences] ([ConfID], [CreationDateTime], [Name], [ShortName], [Year], [StartDate], [EndDate], [SubmisionDeadline], [CreatorUser], [WebSite]) VALUES (N'2', CAST(N'1894-06-11T00:00:00.000' AS DateTime), N'bmmm', N'mr', 2021, CAST(N'1894-07-07T00:00:00.000' AS DateTime), CAST(N'1894-07-12T00:00:00.000' AS DateTime), CAST(N'1894-07-04T00:00:00.000' AS DateTime), 1, N'www.bmm.gov.tr')
INSERT [dbo].[Conferences] ([ConfID], [CreationDateTime], [Name], [ShortName], [Year], [StartDate], [EndDate], [SubmisionDeadline], [CreatorUser], [WebSite]) VALUES (N'3', CAST(N'1894-06-13T00:00:00.000' AS DateTime), N'bilgisayar', N'mr', 2020, CAST(N'1894-07-07T00:00:00.000' AS DateTime), CAST(N'1894-07-12T00:00:00.000' AS DateTime), CAST(N'1894-07-03T00:00:00.000' AS DateTime), 1, N'www.bil.gov.tr')
INSERT [dbo].[Conferences] ([ConfID], [CreationDateTime], [Name], [ShortName], [Year], [StartDate], [EndDate], [SubmisionDeadline], [CreatorUser], [WebSite]) VALUES (N'4', CAST(N'1894-06-15T00:00:00.000' AS DateTime), N'ele', N'mr', 2020, CAST(N'1894-07-07T00:00:00.000' AS DateTime), CAST(N'1894-07-12T00:00:00.000' AS DateTime), CAST(N'1894-07-04T00:00:00.000' AS DateTime), 1, N'www.ele.gov.tr')
INSERT [dbo].[Conferences] ([ConfID], [CreationDateTime], [Name], [ShortName], [Year], [StartDate], [EndDate], [SubmisionDeadline], [CreatorUser], [WebSite]) VALUES (N'5', CAST(N'1894-06-16T00:00:00.000' AS DateTime), N'bilgisayar', N'mr', 2021, CAST(N'1894-07-07T00:00:00.000' AS DateTime), CAST(N'1894-07-12T00:00:00.000' AS DateTime), CAST(N'1894-07-05T00:00:00.000' AS DateTime), 1, N'www.pc.gov.tr')
INSERT [dbo].[Conferences] ([ConfID], [CreationDateTime], [Name], [ShortName], [Year], [StartDate], [EndDate], [SubmisionDeadline], [CreatorUser], [WebSite]) VALUES (N'6', CAST(N'1894-06-14T00:00:00.000' AS DateTime), N'bilgisayar', N'mr', 2021, CAST(N'1894-07-07T00:00:00.000' AS DateTime), CAST(N'1894-07-12T00:00:00.000' AS DateTime), CAST(N'1894-07-05T00:00:00.000' AS DateTime), 1, N'www.pc.gov.tr')
INSERT [dbo].[Conferences] ([ConfID], [CreationDateTime], [Name], [ShortName], [Year], [StartDate], [EndDate], [SubmisionDeadline], [CreatorUser], [WebSite]) VALUES (N'7', CAST(N'1894-06-23T00:00:00.000' AS DateTime), N'ele', N'mr', 2020, CAST(N'1894-07-07T00:00:00.000' AS DateTime), CAST(N'1894-07-12T00:00:00.000' AS DateTime), CAST(N'1894-07-04T00:00:00.000' AS DateTime), 1, N'www.ele.gov.tr')
INSERT [dbo].[Conferences] ([ConfID], [CreationDateTime], [Name], [ShortName], [Year], [StartDate], [EndDate], [SubmisionDeadline], [CreatorUser], [WebSite]) VALUES (N'8', CAST(N'1894-06-22T00:00:00.000' AS DateTime), N'bilgisayar', N'mr', 2020, CAST(N'1894-07-07T00:00:00.000' AS DateTime), CAST(N'1894-07-12T00:00:00.000' AS DateTime), CAST(N'1894-07-03T00:00:00.000' AS DateTime), 1, N'www.bil.gov.tr')
INSERT [dbo].[Conferences] ([ConfID], [CreationDateTime], [Name], [ShortName], [Year], [StartDate], [EndDate], [SubmisionDeadline], [CreatorUser], [WebSite]) VALUES (N'9', CAST(N'1894-07-03T00:00:00.000' AS DateTime), N'bmmm', N'mr', 2021, CAST(N'1894-07-07T00:00:00.000' AS DateTime), CAST(N'1894-07-12T00:00:00.000' AS DateTime), CAST(N'1894-07-04T00:00:00.000' AS DateTime), 1, N'www.bmm.gov.tr')
GO
INSERT [dbo].[UserInfoes] ([AuthenticationID], [Title], [Name], [Affilation], [primaryEmail], [secondaryEmail], [password], [Phone], [fax], [URL], [Address], [City], [Country], [Record], [CreationDate]) VALUES (1, N'', N'', N'', N'', N'', N'admin', N'', N'', N'', N'', N'', N'', N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[UserInfoes] ([AuthenticationID], [Title], [Name], [Affilation], [primaryEmail], [secondaryEmail], [password], [Phone], [fax], [URL], [Address], [City], [Country], [Record], [CreationDate]) VALUES (2, N'Prof', N'name', N'Aselsan', N'yavuzalgun34@gmail.com', N'yavuzalgun34@gmail.com', N'deneme', N'+905442826705', N'', N'', N'TOBB ETU ÖGRENCI KONUKEVI B1-508 22. SOKAK BESTEPE MAH. YENIMAHALLE/ANKARA', N'Ödemis', N'Türkiye', N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[UserInfoes] ([AuthenticationID], [Title], [Name], [Affilation], [primaryEmail], [secondaryEmail], [password], [Phone], [fax], [URL], [Address], [City], [Country], [Record], [CreationDate]) VALUES (3, N'CEO', N'BIL372', N'Havelsan', N'ryunusoglu@etu.edu.tr', N'ryunusoglu@etu.edu.tr', N'372', N'05060555882', N'98554', N'www.bil372.tr', N'yeni mahalle ankara', N'ankara', N'Türkiye', N'2', CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[UserInfoes] ([AuthenticationID], [Title], [Name], [Affilation], [primaryEmail], [secondaryEmail], [password], [Phone], [fax], [URL], [Address], [City], [Country], [Record], [CreationDate]) VALUES (4, N'bilgisayar', N'funda', N'aselsan', N'funda@etu.edu.tr', N'ryunusoglu@etu.edu.tr', N'funda1', N'05060555882', N'98555', N'www.funda.tr', N'yeni mahalle ankara', N'ankara', N'Türkiye', N'4', CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[UserInfoes] ([AuthenticationID], [Title], [Name], [Affilation], [primaryEmail], [secondaryEmail], [password], [Phone], [fax], [URL], [Address], [City], [Country], [Record], [CreationDate]) VALUES (5, N'yazilim', N'melis', N'simbt', N'melis@etu.edu.tr', N'ryunusoglu@etu.edu.tr', N'melis1', N'05060555882', N'98556', N'www.melis.tr', N'yeni mahalle ankara', N'istanbul', N'Türkiye', N'7', CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[UserInfoes] ([AuthenticationID], [Title], [Name], [Affilation], [primaryEmail], [secondaryEmail], [password], [Phone], [fax], [URL], [Address], [City], [Country], [Record], [CreationDate]) VALUES (6, N'bilgisayar', N'mehmet', N'Ayesas', N'mehmet@gmail.com', N'rabiayunusoglu@gmail.com', N'mehmet1', N'0501231', N'98556', N'www.mehmet.tr', N'yüksekalan mahallesi 519 sokak Yunusoglu apt. No:1 kat:5 daire:10 Antalya/Muratpasa, (Nur pastanesi üstü)', N'Muratpasa', N'Türkiye', N'4', CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[UserInfoes] ([AuthenticationID], [Title], [Name], [Affilation], [primaryEmail], [secondaryEmail], [password], [Phone], [fax], [URL], [Address], [City], [Country], [Record], [CreationDate]) VALUES (7, N'CEO', N'Yavuz', N'Aselsan', N'yalgun@etu.edu.tr', N'yavuzalgun34@gmail.com', N'9876', N'5442826705', N'9685498979', N'url/denme', N'adress', N'Izmir', N'Turkey', N'record', CAST(N'1900-01-01T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([AuthenticationID], [UserName], [Password], [Confirm]) VALUES (1, N'admin', N'admin', 1)
INSERT [dbo].[Users] ([AuthenticationID], [UserName], [Password], [Confirm]) VALUES (2, N'deneme', N'deneme', 1)
INSERT [dbo].[Users] ([AuthenticationID], [UserName], [Password], [Confirm]) VALUES (3, N'BIL372', N'372', 1)
INSERT [dbo].[Users] ([AuthenticationID], [UserName], [Password], [Confirm]) VALUES (4, N'funda', N'funda1', 1)
INSERT [dbo].[Users] ([AuthenticationID], [UserName], [Password], [Confirm]) VALUES (5, N'melis', N'melis1', 1)
INSERT [dbo].[Users] ([AuthenticationID], [UserName], [Password], [Confirm]) VALUES (6, N'mehmet', N'mehmet1', 1)
INSERT [dbo].[Users] ([AuthenticationID], [UserName], [Password], [Confirm]) VALUES (7, N'yavuz', N'9876', 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [IX_CreatorUser]    Script Date: 2.12.2020 23:38:48 ******/
CREATE NONCLUSTERED INDEX [IX_CreatorUser] ON [dbo].[Conferences]
(
	[CreatorUser] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AuthenticationID]    Script Date: 2.12.2020 23:38:48 ******/
CREATE NONCLUSTERED INDEX [IX_AuthenticationID] ON [dbo].[UserInfoes]
(
	[AuthenticationID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AuthenticationID]    Script Date: 2.12.2020 23:38:48 ******/
CREATE NONCLUSTERED INDEX [IX_AuthenticationID] ON [dbo].[UserLogs]
(
	[AuthenticationID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Conferences]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Conferences_dbo.Users_CreatorUser] FOREIGN KEY([CreatorUser])
REFERENCES [dbo].[Users] ([AuthenticationID])
GO
ALTER TABLE [dbo].[Conferences] CHECK CONSTRAINT [FK_dbo.Conferences_dbo.Users_CreatorUser]
GO
ALTER TABLE [dbo].[UserInfoes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserInfoes_dbo.Users_AuthenticationID] FOREIGN KEY([AuthenticationID])
REFERENCES [dbo].[Users] ([AuthenticationID])
GO
ALTER TABLE [dbo].[UserInfoes] CHECK CONSTRAINT [FK_dbo.UserInfoes_dbo.Users_AuthenticationID]
GO
ALTER TABLE [dbo].[UserLogs]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserLogs_dbo.Users_AuthenticationID] FOREIGN KEY([AuthenticationID])
REFERENCES [dbo].[Users] ([AuthenticationID])
GO
ALTER TABLE [dbo].[UserLogs] CHECK CONSTRAINT [FK_dbo.UserLogs_dbo.Users_AuthenticationID]
GO
ALTER DATABASE [Bil372HW] SET  READ_WRITE 
GO
