USE [master]
GO
/****** Object:  Database [PMSPocDB]    Script Date: 11/30/2019 7:40:01 PM ******/
CREATE DATABASE PatMSPocDB
CREATE TABLE [dbo].[TbInvoice](
	[InvoiceId] [int] IDENTITY(1,1) NOT NULL,
	[PatientId] [int] NULL,
	[TotalAmt] [money] NULL,
	[InvoiceDate] [datetime] NULL,
	[Status] [nvarchar](50) NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_TbInvoice] PRIMARY KEY CLUSTERED 
(
	[InvoiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbInvoiceItem]    Script Date: 11/30/2019 7:40:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbInvoiceItem](
	[InvoiceItemId] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceId] [int] NULL,
	[ItemDescription] [nvarchar](500) NULL,
	[ItemAmt] [money] NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_TbInvoiceItem] PRIMARY KEY CLUSTERED 
(
	[InvoiceItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbPatientInfo]    Script Date: 11/30/2019 7:40:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbPatientInfo](
	[PatientId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](500) NULL,
	[LastName] [nvarchar](500) NULL,
	[DOB] [datetime] NULL,
	[Email] [nvarchar](500) NULL,
	[PhoneNo] [nvarchar](50) NULL,
	[State] [nvarchar](500) NULL,
	[LGA] [nvarchar](500) NULL,
	[Gender] [nvarchar](500) NULL,
	[BGroup] [nvarchar](500) NULL,
	[GType] [nvarchar](500) NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_TbPatientInfo] PRIMARY KEY CLUSTERED 
(
	[PatientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbPayments]    Script Date: 11/30/2019 7:40:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbPayments](
	[PaymentId] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceId] [int] NULL,
	[InvoiceTotalAmt] [money] NULL,
	[AmtPaidSoFar] [money] NULL,
	[AmtPaidNow] [money] NULL,
	[Balance] [money] NULL,
	[PaymentDate] [datetime] NULL,
	[Status] [nvarchar](50) NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_TbPayments] PRIMARY KEY CLUSTERED 
(
	[PaymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
