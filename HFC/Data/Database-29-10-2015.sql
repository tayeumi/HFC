USE [master]
GO
/****** Object:  Database [NWManagement]    Script Date: 10/29/2015 08:25:09 ******/
CREATE DATABASE [NWManagement] ON  PRIMARY 
( NAME = N'NWManagement', FILENAME = N'D:\NWManagement\Data\NWManagement.mdf' , SIZE = 5472256KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'NWManagement_log', FILENAME = N'D:\NWManagement\Data\NWManagement_log.LDF' , SIZE = 5121024KB , MAXSIZE = 2048GB , FILEGROWTH = 2048000KB )
GO
ALTER DATABASE [NWManagement] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NWManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NWManagement] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [NWManagement] SET ANSI_NULLS OFF
GO
ALTER DATABASE [NWManagement] SET ANSI_PADDING OFF
GO
ALTER DATABASE [NWManagement] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [NWManagement] SET ARITHABORT OFF
GO
ALTER DATABASE [NWManagement] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [NWManagement] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [NWManagement] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [NWManagement] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [NWManagement] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [NWManagement] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [NWManagement] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [NWManagement] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [NWManagement] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [NWManagement] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [NWManagement] SET  DISABLE_BROKER
GO
ALTER DATABASE [NWManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [NWManagement] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [NWManagement] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [NWManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [NWManagement] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [NWManagement] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [NWManagement] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [NWManagement] SET  READ_WRITE
GO
ALTER DATABASE [NWManagement] SET RECOVERY SIMPLE
GO
ALTER DATABASE [NWManagement] SET  MULTI_USER
GO
ALTER DATABASE [NWManagement] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [NWManagement] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'NWManagement', N'ON'
GO
USE [NWManagement]
GO
/****** Object:  StoredProcedure [dbo].[NW_CurrentTrafic_CreateTable]    Script Date: 10/29/2015 08:25:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[NW_CurrentTrafic_CreateTable]
@table nvarchar(50)
as
begin
	declare @query nvarchar(500)
	if Len(@table)>2
		begin
			IF (not EXISTS (SELECT * 
							 FROM INFORMATION_SCHEMA.TABLES 
							 WHERE 
							 TABLE_NAME = @table))               
			BEGIN	
				
				set @query= 'CREATE TABLE '+@table+'(MacAddress nvarchar(50),DS nvarchar(50),US nvarchar(50),DateTime datetime,CurrentDS nvarchar(50),CurrentUS nvarchar(50))'
				EXECUTE sp_executesql @query
			END
		end
end
GO
/****** Object:  Table [dbo].[NW_CurrentTrafic]    Script Date: 10/29/2015 08:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NW_CurrentTrafic](
	[MacAddress] [nvarchar](50) NOT NULL,
	[DS] [nvarchar](50) NULL,
	[US] [nvarchar](50) NULL,
	[DateTime] [datetime] NULL,
	[CurrentDS] [nvarchar](50) NULL,
	[CurrentUS] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NW_Interface]    Script Date: 10/29/2015 08:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NW_Interface](
	[Interface] [nvarchar](50) NOT NULL,
	[SignalGroup] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
 CONSTRAINT [PK_NW_Interface] PRIMARY KEY CLUSTERED 
(
	[Interface] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NW_InterfaceControllerWarning]    Script Date: 10/29/2015 08:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NW_InterfaceControllerWarning](
	[InterfaceController] [nvarchar](50) NULL,
	[Signal] [nvarchar](50) NULL,
	[Datetime] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NW_InterfaceGauge]    Script Date: 10/29/2015 08:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NW_InterfaceGauge](
	[Interface] [nvarchar](50) NULL,
	[OIDIn] [nvarchar](50) NULL,
	[OIDOut] [nvarchar](50) NULL,
	[InBandwidth] [real] NULL,
	[OutBandwidth] [real] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NW_Device_Temp]    Script Date: 10/29/2015 08:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NW_Device_Temp](
	[NodeName] [nvarchar](500) NULL,
	[Value1] [int] NULL,
	[Value2] [int] NULL,
	[DateTime] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[NW_Trafic_Getlike]    Script Date: 10/29/2015 08:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[NW_Trafic_Getlike]
@MacAddress nvarchar(50),
@Month nvarchar(50),
@Year nvarchar(50)
as
begin
	declare @sql nvarchar(500)
	set @sql= 'select * from NW_Traffic_'+@Month+'_'+@Year+' where MacAddress like '+'''%'+@MacAddress + ''' order by DateTime ASC'
	print @sql
	EXECUTE sp_executesql @sql
end

--exec NW_Trafic_Getlike '92a9','8','2015'
GO
/****** Object:  StoredProcedure [dbo].[NW_Trafic_GetByDay]    Script Date: 10/29/2015 08:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[NW_Trafic_GetByDay]
@Day nvarchar(50),
@Month nvarchar(50),
@Year nvarchar(50)
as
begin
	declare @sql nvarchar(500)
	set @sql= 'select * from NW_Traffic_'+@Month+'_'+@Year+' where Day(DateTime)='+''''+@Day + ''''
	print @sql
	EXECUTE sp_executesql @sql
end

--exec NW_Trafic_GetByDay '1','9','2015'
GO
/****** Object:  StoredProcedure [dbo].[NW_Trafic_Get]    Script Date: 10/29/2015 08:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[NW_Trafic_Get]
@MacAddress nvarchar(50),
@Month nvarchar(50),
@Year nvarchar(50)
as
begin
	declare @sql nvarchar(500)
	set @sql= 'select * from NW_Traffic_'+@Month+'_'+@Year+' where MacAddress='+''''+@MacAddress + ''' order by DateTime ASC'
	print @sql
	EXECUTE sp_executesql @sql
end

--exec NW_Trafic_Get '000e.0923.92a9','7','2015'
GO
/****** Object:  Table [dbo].[NW_Traffic_9_2015]    Script Date: 10/29/2015 08:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NW_Traffic_9_2015](
	[MacAddress] [nvarchar](50) NULL,
	[DS] [nvarchar](50) NULL,
	[US] [nvarchar](50) NULL,
	[DateTime] [datetime] NULL,
	[CurrentDS] [nvarchar](50) NULL,
	[CurrentUS] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NW_Traffic_8_2015]    Script Date: 10/29/2015 08:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NW_Traffic_8_2015](
	[MacAddress] [nvarchar](50) NULL,
	[DS] [nvarchar](50) NULL,
	[US] [nvarchar](50) NULL,
	[DateTime] [datetime] NULL,
	[CurrentDS] [nvarchar](50) NULL,
	[CurrentUS] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NW_Traffic_7_2015]    Script Date: 10/29/2015 08:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NW_Traffic_7_2015](
	[MacAddress] [nvarchar](50) NULL,
	[DS] [nvarchar](50) NULL,
	[US] [nvarchar](50) NULL,
	[DateTime] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NW_Traffic_10_2015]    Script Date: 10/29/2015 08:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NW_Traffic_10_2015](
	[MacAddress] [nvarchar](50) NULL,
	[DS] [nvarchar](50) NULL,
	[US] [nvarchar](50) NULL,
	[DateTime] [datetime] NULL,
	[CurrentDS] [nvarchar](50) NULL,
	[CurrentUS] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NW_SignalLog_5Day]    Script Date: 10/29/2015 08:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NW_SignalLog_5Day](
	[MacAddress] [nvarchar](50) NULL,
	[IpPrivate] [nvarchar](50) NULL,
	[IpPublic1] [nvarchar](50) NULL,
	[IpPublic2] [nvarchar](50) NULL,
	[Value1] [nvarchar](50) NULL,
	[Value2] [nvarchar](50) NULL,
	[Value3] [nvarchar](50) NULL,
	[Value4] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
	[Location] [nvarchar](50) NULL,
	[DateTime] [datetime] NULL,
	[Description] [nvarchar](500) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NW_Node]    Script Date: 10/29/2015 08:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NW_Node](
	[NodeCode] [nvarchar](50) NOT NULL,
	[NodeName] [nvarchar](500) NULL,
	[NodeGroup] [nvarchar](500) NULL,
	[Total] [int] NULL,
	[Description] [nvarchar](500) NULL,
	[Path] [nvarchar](1000) NULL,
 CONSTRAINT [PK_NW_Node] PRIMARY KEY CLUSTERED 
(
	[NodeCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NW_InterfaceLog]    Script Date: 10/29/2015 08:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NW_InterfaceLog](
	[InterfaceName] [nvarchar](255) NULL,
	[FullName] [nvarchar](255) NULL,
	[Inbps] [real] NULL,
	[Outbps] [real] NULL,
	[InBandwidth] [float] NULL,
	[OutBandwidth] [float] NULL,
	[InPercentUtil] [real] NULL,
	[OutPercentUtil] [real] NULL,
	[DateTime] [datetime] NULL,
	[StrDate] [nvarchar](255) NULL,
	[LastSync] [datetime] NULL,
	[Status] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[NW_SignalLog_5Day_GetByMacLike]    Script Date: 10/29/2015 08:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[NW_SignalLog_5Day_GetByMacLike]
@MacAddress nvarchar(50)
as
begin
--exec [dbo].[NW_SignalLog_DeleteFor30Day]

select *,Convert(date,DateTime) as Date from NW_SignalLog_5Day
where MacAddress like '%'+ @MacAddress +'%'
order by DateTime Desc
end
GO
/****** Object:  StoredProcedure [dbo].[NW_SignalLog_5Day_GetByMac]    Script Date: 10/29/2015 08:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[NW_SignalLog_5Day_GetByMac]
@MacAddress nvarchar(50)
as
begin
--exec [dbo].[NW_SignalLog_DeleteFor30Day]

select *,Convert(date,DateTime) as Date from NW_SignalLog_5Day
where MacAddress=@MacAddress
order by DateTime Asc
end
GO
/****** Object:  StoredProcedure [dbo].[NW_SignalLog_5Day_DeleteFor5Day]    Script Date: 10/29/2015 08:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[NW_SignalLog_5Day_DeleteFor5Day]
as
begin
delete from NW_SignalLog_5Day
where DATEDIFF ( day,DateTime,GETDATE())>5
end
GO
/****** Object:  StoredProcedure [dbo].[NW_InterfaceLog_DeleteFor30Day]    Script Date: 10/29/2015 08:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[NW_InterfaceLog_DeleteFor30Day]
as
begin
delete from NW_InterfaceLog
where DATEDIFF ( day,DateTime,GETDATE())>30
end
GO
/****** Object:  StoredProcedure [dbo].[NW_Node_UpdateByPath]    Script Date: 10/29/2015 08:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[NW_Node_UpdateByPath]
@NodeCode nvarchar(50),
@Path nvarchar(1000)
AS
BEGIN

update NW_Node set Path=@Path
where
	NodeCode=@NodeCode			 

END
GO
/****** Object:  StoredProcedure [dbo].[NW_Node_Update]    Script Date: 10/29/2015 08:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[NW_Node_Update]
@NodeCode nvarchar(50),
@NodeName nvarchar(500),
@NodeGroup nvarchar(500),
@Description nvarchar(500)
AS
BEGIN

update NW_Node set NodeName=@NodeName,NodeGroup=@NodeGroup,Description=@Description
where
	NodeCode=@NodeCode			 

END
GO
/****** Object:  StoredProcedure [dbo].[NW_Node_Insert]    Script Date: 10/29/2015 08:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[NW_Node_Insert]
@NodeCode nvarchar(50),
@NodeName nvarchar(500),
@NodeGroup nvarchar(500),
@Description nvarchar(500)
AS
BEGIN

insert into  NW_Node( NodeCode,NodeName,NodeGroup,Description)
			 values(@NodeCode,@NodeName,@NodeGroup,@Description)

END
GO
/****** Object:  StoredProcedure [dbo].[NW_Node_GetList]    Script Date: 10/29/2015 08:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[NW_Node_GetList]
AS
BEGIN

Select * From [NW_Node]   

END
GO
/****** Object:  StoredProcedure [dbo].[NW_Node_Get]    Script Date: 10/29/2015 08:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[NW_Node_Get]
    @NodeCode nvarchar(50)

AS
BEGIN

Select * From [NW_Node]
 Where 
    [NodeCode] = @NodeCode


END
GO
/****** Object:  StoredProcedure [dbo].[NW_Node_Delete]    Script Date: 10/29/2015 08:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[NW_Node_Delete]
@NodeCode nvarchar(50)
AS
BEGIN

delete NW_Node 
where
	NodeCode=@NodeCode		 

END
GO
/****** Object:  StoredProcedure [dbo].[NW_InterfaceGauge_GetList]    Script Date: 10/29/2015 08:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[NW_InterfaceGauge_GetList]
AS
BEGIN

Select * From NW_InterfaceGauge  

END
GO
/****** Object:  StoredProcedure [dbo].[NW_InterfaceLog_Insert]    Script Date: 10/29/2015 08:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[NW_InterfaceLog_Insert]
@InterfaceName nvarchar(255),
@FullName nvarchar(255),
@Inbps real,
@Outbps real,
@InBandwidth float,
@OutBandwidth float,
@InPercentUtil real,
@OutPercentUtil real,
@DateTime Datetime,
@StrDate nvarchar(255),
@LastSync Datetime,
@Status	nvarchar(50)
as 
begin
	insert into NW_InterfaceLog(InterfaceName,FullName,Inbps,Outbps,InBandwidth,OutBandwidth,InPercentUtil,OutPercentUtil,DateTime,StrDate,LastSync,Status)
	values(@InterfaceName,@FullName,@Inbps,@Outbps,@InBandwidth,@OutBandwidth,@InPercentUtil,@OutPercentUtil,@DateTime,@StrDate,@LastSync,@Status)
end
GO
/****** Object:  Table [dbo].[NW_Device]    Script Date: 10/29/2015 08:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NW_Device](
	[MacAddress] [nvarchar](50) NOT NULL,
	[NodeCode] [nvarchar](50) NULL,
	[CustomerName] [nvarchar](100) NULL,
	[CustomerAddress] [nvarchar](500) NULL,
	[Ward] [nvarchar](50) NULL,
	[District] [nvarchar](50) NULL,
	[CustomerTelephone] [nvarchar](50) NULL,
	[IpPrivate] [nvarchar](50) NULL,
	[IpPublic1] [nvarchar](50) NULL,
	[IpPublic2] [nvarchar](50) NULL,
	[Value1] [nvarchar](50) NULL,
	[Value2] [nvarchar](50) NULL,
	[Value3] [nvarchar](50) NULL,
	[Value4] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
	[Location] [nvarchar](50) NULL,
	[DateTime] [datetime] NULL,
	[Description] [nvarchar](500) NULL,
	[Checked] [bit] NULL,
	[CurrentDS] [nvarchar](50) NULL,
	[OldDS] [nvarchar](50) NULL,
	[CurrentUS] [nvarchar](50) NULL,
	[OldUS] [nvarchar](50) NULL,
	[DS] [nvarchar](50) NULL,
	[US] [nvarchar](50) NULL,
 CONSTRAINT [PK_NW_Device] PRIMARY KEY CLUSTERED 
(
	[MacAddress] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[NW_CurrentTrafic_Insert]    Script Date: 10/29/2015 08:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[NW_CurrentTrafic_Insert]
@MacAddress nvarchar(50),
@DS nvarchar(50),
@US nvarchar(50),
@DateTime datetime,
@CurrentDS nvarchar(50),
@CurrentUS nvarchar(50)
as
begin

insert into NW_CurrentTrafic(MacAddress,DS,US,DateTime,CurrentDS,CurrentUS)
values
(@MacAddress,@DS,@US,@DateTime,@CurrentDS,@CurrentUS)
end
GO
/****** Object:  StoredProcedure [dbo].[NW_CurrentTrafic_GetAll]    Script Date: 10/29/2015 08:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[NW_CurrentTrafic_GetAll]
as
begin
select * from NW_CurrentTrafic
end
GO
/****** Object:  StoredProcedure [dbo].[NW_CurrentTrafic_DeleteAll]    Script Date: 10/29/2015 08:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[NW_CurrentTrafic_DeleteAll]
as
begin
delete from NW_CurrentTrafic
end
GO
/****** Object:  StoredProcedure [dbo].[NW_InterfaceControllerWarning_Insert]    Script Date: 10/29/2015 08:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[NW_InterfaceControllerWarning_Insert]
@InterfaceController nvarchar(50),
@Signal nvarchar(50),
@Datetime Datetime
as
begin
insert into NW_InterfaceControllerWarning(InterfaceController,Signal,Datetime)
			values (@InterfaceController,@Signal,@Datetime)
end
GO
/****** Object:  StoredProcedure [dbo].[NW_InterfaceControllerWarning_GetList_Low]    Script Date: 10/29/2015 08:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[NW_InterfaceControllerWarning_GetList_Low]
as
begin
select * from NW_InterfaceControllerWarning
where CONVERT(float, Signal)<20 and Signal <>'0.0' and Signal <>''
end
GO
/****** Object:  StoredProcedure [dbo].[NW_InterfaceControllerWarning_GetList]    Script Date: 10/29/2015 08:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[NW_InterfaceControllerWarning_GetList]
as
begin
select * from NW_InterfaceControllerWarning
end
GO
/****** Object:  StoredProcedure [dbo].[NW_InterfaceControllerWarning_DeleteAll]    Script Date: 10/29/2015 08:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[NW_InterfaceControllerWarning_DeleteAll]
as
begin
delete from NW_InterfaceControllerWarning
end
GO
/****** Object:  StoredProcedure [dbo].[NW_Interface_Insert]    Script Date: 10/29/2015 08:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[NW_Interface_Insert]
@Interface nvarchar(50),
@SignalGroup nvarchar(50),
@Description nvarchar(50)
AS
BEGIN
insert into NW_Interface (Interface,SignalGroup,Description) 
values (@Interface,@SignalGroup,@Description)

END
GO
/****** Object:  StoredProcedure [dbo].[NW_Interface_Getlist]    Script Date: 10/29/2015 08:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[NW_Interface_Getlist]
AS
BEGIN
select * from NW_Interface 
END
GO
/****** Object:  StoredProcedure [dbo].[NW_Device_UpdateSignal]    Script Date: 10/29/2015 08:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[NW_Device_UpdateSignal]
@MacAddress nvarchar(50),
@IpPrivate nvarchar(50),
@IpPublic1 nvarchar(50),
@IpPublic2 nvarchar(50),
@Value1 nvarchar(50),
@Value2 nvarchar(50),
@Value3 nvarchar(50),
@Value4 nvarchar(50),
@Location nvarchar(50),
@Status nvarchar(50),
@DateTime Datetime
AS
BEGIN

update [NW_Device] set
IpPrivate=@IpPrivate,
IpPublic1=@IpPublic1,
IpPublic2=@IpPublic2,
Value1=@Value1,
Value2=@Value2,
Value3=@Value3,
Value4=@Value4,
Location=@Location,
Status=@Status,
DateTime=@DateTime
where MacAddress=@MacAddress 

END
GO
/****** Object:  StoredProcedure [dbo].[NW_Device_Update]    Script Date: 10/29/2015 08:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[NW_Device_Update]
	@MacAddress nvarchar(50),
	@Value1 nvarchar(50),
	@Value2 nvarchar(50),
	@Value3 nvarchar(50),
	@DateTime datetime,
	@Status nvarchar(50)
AS
BEGIN

update  NW_Device set Value1=@Value1,Value2=@Value2,Value3=Value3,Status=@Status,DateTime=@DateTime					
	where MacAddress=@MacAddress

END
GO
/****** Object:  StoredProcedure [dbo].[NW_Device_Insert]    Script Date: 10/29/2015 08:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[NW_Device_Insert]
@MacAddress nvarchar(50),
@NodeCode nvarchar(50),
@Description nvarchar(500)
AS
BEGIN

insert into NW_Device(MacAddress,NodeCode,Description) 
					values (@MacAddress,@NodeCode,@Description)

END
GO
/****** Object:  StoredProcedure [dbo].[NW_Device_GetStatic]    Script Date: 10/29/2015 08:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[NW_Device_GetStatic]
as
begin
begin transaction
	--create table NW_Device_Temp(NodeName nvarchar(500), [Value1] int,[Value2] int)
	delete  from NW_Device_Temp
	DECLARE cs1 CURSOR FOR
	select NodeCode,NodeName from NW_Node where Total>0 and Total is not null
	Open cs1		
	declare @NodeCode nvarchar(50)
	declare @NodeName nvarchar(500)
	declare @value1 int
	declare @value2 int
	declare @DateTime datetime
	fetch next from cs1 into @NodeCode,@NodeName	
	while @@FETCH_STATUS=0
	begin
		select @value1=COUNT(*) from NW_Device where NodeCode=@NodeCode and Status='online'	
		select @value2=COUNT(*) from NW_Device where NodeCode=@NodeCode and Status='offline'
		select @DateTime=DateTime from NW_Device where NodeCode=@NodeCode	
	insert into NW_Device_Temp (NodeName,Value1,Value2,DateTime) values (@NodeName,@value1,@value2,@DateTime)
	fetch next from cs1 into @NodeCode,@NodeName
	end
	close cs1
	deallocate cs1 
	select NW_Device_Temp.*,NW_Node.Description,NW_Node.NodeCode,NW_Node.NodeGroup,NW_Node.Path from NW_Device_Temp inner join NW_Node on NW_Node.NodeName=NW_Device_Temp.NodeName
	--drop table TEMPORARY1
	if(@@error<>0) rollback transaction
	else commit
end
GO
/****** Object:  StoredProcedure [dbo].[NW_Device_GetList]    Script Date: 10/29/2015 08:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[NW_Device_GetList]
AS
BEGIN

Select * From [NW_Device]   

END
GO
/****** Object:  StoredProcedure [dbo].[NW_Device_GetByNodeCode]    Script Date: 10/29/2015 08:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[NW_Device_GetByNodeCode]
@NodeCode nvarchar(50)
AS
BEGIN

Select * From [NW_Device]  where NodeCode=@NodeCode

END
GO
/****** Object:  StoredProcedure [dbo].[NW_Device_GetByMac]    Script Date: 10/29/2015 08:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[NW_Device_GetByMac]
@MacAddress nvarchar(50)
AS
BEGIN

Select * From [NW_Device]  where MacAddress=@MacAddress 

END
GO
/****** Object:  StoredProcedure [dbo].[NW_Device_Delete]    Script Date: 10/29/2015 08:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[NW_Device_Delete]
@MacAddress nvarchar(50)
AS
BEGIN

delete NW_Device
where MacAddress=@MacAddress

END
GO
/****** Object:  StoredProcedure [dbo].[NW_InterfaceLog_GetList]    Script Date: 10/29/2015 08:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[NW_InterfaceLog_GetList]
AS
BEGIN
exec NW_InterfaceLog_DeleteFor30Day

select *from  NW_InterfaceLog

END
GO
/****** Object:  Table [dbo].[NW_SignalLog]    Script Date: 10/29/2015 08:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NW_SignalLog](
	[MacAddress] [nvarchar](50) NULL,
	[IpPrivate] [nvarchar](50) NULL,
	[IpPublic1] [nvarchar](50) NULL,
	[IpPublic2] [nvarchar](50) NULL,
	[Value1] [nvarchar](50) NULL,
	[Value2] [nvarchar](50) NULL,
	[Value3] [nvarchar](50) NULL,
	[Value4] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
	[Location] [nvarchar](50) NULL,
	[DateTime] [datetime] NULL,
	[Description] [nvarchar](500) NULL,
	[CurrentDS] [nvarchar](50) NULL,
	[CurrentUS] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[NW_SignalLog_Insert]    Script Date: 10/29/2015 08:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[NW_SignalLog_Insert]
@MacAddress nvarchar(50),
@IpPrivate nvarchar(50),
@IpPublic1 nvarchar(50),
@IpPublic2 nvarchar(50),
@Value1 nvarchar(50),
@Value2 nvarchar(50),
@Value3 nvarchar(50),
@Value4 nvarchar(50),
@Status nvarchar(50),
@Location nvarchar(50),
@DateTime datetime,
@Description nvarchar(50),
@CurrentDS nvarchar(50),
@CurrentUS nvarchar(50)
as
begin

insert into NW_SignalLog(MacAddress,IpPrivate,IpPublic1,IpPublic2,Value1,Value2,Value3,Value4,Status,Location,DateTime,Description,CurrentDS,CurrentUS)
values
(@MacAddress,@IpPrivate,@IpPublic1,@IpPublic2,@Value1,@Value2,@Value3,@Value4,@Status,@Location,@DateTime,@Description,@CurrentDS,@CurrentUS)

end
GO
/****** Object:  StoredProcedure [dbo].[NW_SignalLog_GetByMacDate]    Script Date: 10/29/2015 08:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[NW_SignalLog_GetByMacDate]
@MacAddress nvarchar(50)
as
begin
--exec [dbo].[NW_SignalLog_DeleteFor30Day]

select *,Convert(date,DateTime) as Date from NW_SignalLog
where MacAddress=@MacAddress
and 
(Day(DateTime)=DAY(getdate()) and MONTH(DateTime)=MONTH(getdate()) and YEAR(DateTime)=YEAR(getdate()))
order by DateTime Asc
end
GO
/****** Object:  StoredProcedure [dbo].[NW_SignalLog_GetByMac]    Script Date: 10/29/2015 08:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[NW_SignalLog_GetByMac]
@MacAddress nvarchar(50)
as
begin
--exec [dbo].[NW_SignalLog_DeleteFor30Day]

select *,Convert(date,DateTime) as Date from NW_SignalLog
where MacAddress=@MacAddress
order by DateTime Asc
end
GO
/****** Object:  StoredProcedure [dbo].[NW_SignalLog_DeleteFor30Day]    Script Date: 10/29/2015 08:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[NW_SignalLog_DeleteFor30Day]
as
begin
delete from NW_SignalLog
where DATEDIFF ( day,DateTime,GETDATE())>30
end
GO
/****** Object:  StoredProcedure [dbo].[NW_SignalLog_DeleteAll]    Script Date: 10/29/2015 08:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[NW_SignalLog_DeleteAll]
as
begin

delete from NW_SignalLog

end
GO
