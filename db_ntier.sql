USE [NTier]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 11/18/2022 10:51:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeNo] [nvarchar](max) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[MidleName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Gender] [nvarchar](max) NOT NULL,
	[ImageUrl] [nvarchar](max) NOT NULL,
	[DOB] [datetime2](7) NOT NULL,
	[DateJoined] [datetime2](7) NOT NULL,
	[Designation] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[NationalInsuranceNo] [nvarchar](50) NOT NULL,
	[PaymentMethod] [int] NOT NULL,
	[StudentLoan] [int] NOT NULL,
	[UnionMember] [int] NOT NULL,
	[Address] [nvarchar](150) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[Postcode] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentRecords]    Script Date: 11/18/2022 10:51:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentRecords](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[NiNo] [nvarchar](max) NOT NULL,
	[PayDate] [datetime2](7) NOT NULL,
	[PayMonth] [nvarchar](max) NOT NULL,
	[TaxYearId] [int] NOT NULL,
	[TaxCode] [nvarchar](max) NOT NULL,
	[HourlyRate] [decimal](18, 2) NOT NULL,
	[HoursWorked] [decimal](18, 2) NOT NULL,
	[ContractualHours] [decimal](18, 2) NOT NULL,
	[OvertimeHours] [decimal](18, 2) NOT NULL,
	[ContractualEarnings] [money] NOT NULL,
	[OvertimeEarnings] [money] NOT NULL,
	[Tax] [money] NOT NULL,
	[NIC] [money] NOT NULL,
	[UnionFee] [money] NULL,
	[SLC] [money] NULL,
	[TotalEarnings] [money] NOT NULL,
	[TotalDeduction] [money] NOT NULL,
	[NetPayment] [money] NOT NULL,
 CONSTRAINT [PK_PaymentRecords] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaxYears]    Script Date: 11/18/2022 10:51:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaxYears](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[YearOfTax] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_TaxYears] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[PaymentRecords]  WITH CHECK ADD  CONSTRAINT [FK_PaymentRecords_Employees_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PaymentRecords] CHECK CONSTRAINT [FK_PaymentRecords_Employees_EmployeeId]
GO
