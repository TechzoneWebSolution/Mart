USE [master]
GO
/****** Object:  Database [Mart]    Script Date: 2/7/2022 12:24:53 AM ******/
CREATE DATABASE [Mart]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Mart', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVERNEW\MSSQL\DATA\Mart.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Mart_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVERNEW\MSSQL\DATA\Mart_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Mart] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Mart].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Mart] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Mart] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Mart] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Mart] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Mart] SET ARITHABORT OFF 
GO
ALTER DATABASE [Mart] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Mart] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Mart] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Mart] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Mart] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Mart] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Mart] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Mart] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Mart] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Mart] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Mart] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Mart] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Mart] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Mart] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Mart] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Mart] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Mart] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Mart] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Mart] SET  MULTI_USER 
GO
ALTER DATABASE [Mart] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Mart] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Mart] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Mart] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Mart] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Mart] SET QUERY_STORE = OFF
GO
USE [Mart]
GO
/****** Object:  Table [dbo].[District]    Script Date: 2/7/2022 12:24:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[District](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StateId] [int] NULL,
	[Name] [nvarchar](250) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [varchar](50) NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [varchar](50) NULL,
	[DeletedBy] [int] NULL,
	[DeletedDate] [varchar](50) NULL,
 CONSTRAINT [PK_dbo.District] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_Types]    Script Date: 2/7/2022 12:24:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Types](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [nvarchar](50) NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [nvarchar](50) NULL,
 CONSTRAINT [PK_Product_Types] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 2/7/2022 12:24:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](100) NULL,
	[Price] [decimal](18, 2) NULL,
	[SellingPrice] [decimal](18, 2) NULL,
	[Stock] [int] NULL,
	[ProductImages] [nvarchar](100) NULL,
	[ProductTypeId] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [nvarchar](50) NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [nvarchar](50) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductStockLedger]    Script Date: 2/7/2022 12:24:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductStockLedger](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NULL,
	[Stock] [int] NULL,
	[Price] [decimal](18, 2) NULL,
	[SellingPrice] [decimal](18, 2) NULL,
	[CommentText] [nvarchar](1000) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [nvarchar](50) NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [nvarchar](50) NULL,
 CONSTRAINT [PK_ProductStockLedger] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[State]    Script Date: 2/7/2022 12:24:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [varchar](50) NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [varchar](50) NULL,
	[DeletedBy] [int] NULL,
	[DeletedDate] [varchar](50) NULL,
 CONSTRAINT [PK_dbo.State] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Taluka]    Script Date: 2/7/2022 12:24:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Taluka](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DistrictId] [int] NULL,
	[Name] [nvarchar](250) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [varchar](50) NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [varchar](50) NULL,
	[DeletedBy] [int] NULL,
	[DeletedDate] [varchar](50) NULL,
 CONSTRAINT [PK_dbo.Taluka] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2/7/2022 12:24:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Mobile] [varchar](20) NULL,
	[Salt] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[StateId] [int] NULL,
	[DistrictId] [int] NULL,
	[UserType] [int] NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [varchar](50) NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [varchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserType]    Script Date: 2/7/2022 12:24:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [varchar](50) NULL,
 CONSTRAINT [PK_UserType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[DistrictById]    Script Date: 2/7/2022 12:24:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,Payal>
-- Create date: <Create Date,24-12-2019>
-- Description:	<Description,Select User By Id>
-- EXEC [dbo].[DistrictById] 1
-- =============================================
CREATE   PROCEDURE [dbo].[DistrictById]
	@Id int
AS
BEGIN
	
	SET NOCOUNT ON;

	DECLARE @Code INT = 200,
	       @Message VARCHAR(255) = 'District Retrived Successfully'
	SELECT @Code AS Code, @Message AS [Message]
    
	select	
	*
  FROM [District] where Id=@Id
    
END
GO
/****** Object:  StoredProcedure [dbo].[DistrictDelete]    Script Date: 2/7/2022 12:24:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,Payal>
-- Create date: <Create Date,24-12-2019>
-- Description:	<Description,Delete District by Id>
-- EXEC [dbo].[DistrictDelete] 1
-- =============================================
CREATE   PROCEDURE [dbo].[DistrictDelete]
	@Id int,
	@UserId int
AS
BEGIN
	
	SET NOCOUNT ON;

    IF not exists (select * from [District] where Id=@Id)
	BEGIN
	     SELECT 0
	END
    ELSE
	BEGIN
	     
		Update [District]	set DeletedBy=@UserId , DeletedDate = GETDATE() where Id=@Id
		 
		 select 1
	END   
END
GO
/****** Object:  StoredProcedure [dbo].[DistrictSelectAllByStateId]    Script Date: 2/7/2022 12:24:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		DARSHAN S
-- Create date: 15-11-2021
-- Description:	SELECT ALL District
-- EXEC [dbo].[DistrictSelectAllByStateId] 0,'',0,0
-- =============================================
CREATE   PROCEDURE [dbo].[DistrictSelectAllByStateId]
@StateId int,
@Search varchar(100) = '',
@Offset INT,
@Limit INT
AS
BEGIN
	
	SET NOCOUNT ON;

	DECLARE @TotalRecords BIGINT;

	SET @TotalRecords = (select count(1) FROM [District] where StateId=ISNULL(@StateId,0) and ISNULL(DeletedBy,0) = 0 and ISNUll(DeletedDate,'') = '' and
	(ISNULL(@Search,'')=''  OR [Name] like '%'+@Search+'%' ))

	IF @Limit = 0 
	BEGIN 
	     set @Limit = @TotalRecords
		 IF @Limit=0
		 BEGIN
		 set @Limit=10000000
		 END
	END

	select *
	,(Select Name from [State] where Id=@StateId) as StateName
	from [District] where  StateId=ISNULL(@StateId,0) and ISNULL(DeletedBy,0) = 0 and ISNUll(DeletedDate,'') = '' and
	(ISNULL(@Search,'')=''  OR [Name] like '%'+@Search+'%' ) order by Id asc

	OFFSET @Offset ROWS FETCH NEXT @Limit ROWS ONLY
	SELECT @TotalRecords AS TotalRecords
END
GO
/****** Object:  StoredProcedure [dbo].[DistrictSelectAllForDropdown]    Script Date: 2/7/2022 12:24:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		DARSHAN S
-- Create date: 15-11-2021
-- Description:	SELECT ALL DISTRICT
-- EXEC [dbo].[DistrictSelectAllForDropdown]
-- =============================================
CREATE   PROCEDURE [dbo].[DistrictSelectAllForDropdown]
@StateId int = 0
AS
BEGIN
	
	SET NOCOUNT ON;

	DECLARE @TotalRecords BIGINT;

	SET @TotalRecords = (select count(1) FROM District where StateId = @StateId)

	select * From District where StateId = @StateId order by id asc

	SELECT @TotalRecords AS TotalRecords
	END
GO
/****** Object:  StoredProcedure [dbo].[DistrictUpsert]    Script Date: 2/7/2022 12:24:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:       
-- Create date:   
-- Description: Get User Group Permission Lists for specific User Group (Task = 1),   
--    Save Permission for User Group (Task = 2)  
-- =============================================  
-- EXEC [dbo].[DistrictUpsert]   
CREATE   PROCEDURE [dbo].[DistrictUpsert] 
 @Id int=0
 ,@Name varchar(500)=NULL
 ,@StateId int=NULL
 ,@CreatedBy int=NULL
 ,@ModifiedBy int=NULL
AS
BEGIN
	SET NOCOUNT ON;

	 DECLARE @Code INT = 200,
			 @Message VARCHAR(255) = '';
	
	 IF @Id=0
	    BEGIN
			INSERT INTO [District]
				(	
					Name
					,StateId
					,CreatedBy
					,CreatedDate
				)
				Values
				(
					 @Name
					 ,@StateId
					,@CreatedBy
					,GETDATE()
				)
						
			 set @Id = SCOPE_IDENTITY()
			 set @Message = 'District added successfully'	

			SELECT @Code AS Code, @Message AS [Message]
		END
	 
	 ELSE
	 BEGIN
			Update [District]
			set 
			Name				= ISNULL(@Name,Name),
			StateId				= ISNULL(@StateId,StateId),
			ModifiedBy			= ISNULL(@ModifiedBy,ModifiedBy),
			ModifiedDate	    = GETDATE()
			where Id=@Id

			set @Message = 'District updated successfully'	

			SELECT @Code AS Code, @Message AS [Message]
	  END

	select * from District where Id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[ProductsById]    Script Date: 2/7/2022 12:24:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,DarshanV>
-- Create date: <Create Date,07-01-2022>
-- Description:	<Description,Select Products By Id>
-- EXEC [dbo].[ProductsById] 1
-- =============================================
CREATE   PROCEDURE [dbo].[ProductsById]
	@Id int
AS
BEGIN
	
	SET NOCOUNT ON;

	DECLARE @Code INT = 200,
	       @Message VARCHAR(255) = 'Products Retrived Successfully'
	SELECT @Code AS Code, @Message AS [Message]
    
	select	
	*
   FROM Products where Id=@Id
    
END
GO
/****** Object:  StoredProcedure [dbo].[ProductsDelete]    Script Date: 2/7/2022 12:24:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,DarshanV>
-- Create date: <Create Date,07-01-2022>
-- Description:	<Description,Delete District by Id>
-- EXEC [dbo].[ProductsDelete] 1
-- =============================================
CREATE   PROCEDURE [dbo].[ProductsDelete]
	@Id int
AS
BEGIN
	
	SET NOCOUNT ON;

    IF not exists (select * from Products where Id=@Id)
	BEGIN
	     SELECT 0
	END
    ELSE
	BEGIN
	     
		 delete from Products where  Id=@Id
		 select 1
	END   
END
GO
/****** Object:  StoredProcedure [dbo].[ProductsSelectAll]    Script Date: 2/7/2022 12:24:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		DARSHAN S
-- Create date: 15-11-2021
-- Description:	SELECT ALL District
-- EXEC [dbo].[ProductsSelectAll] 0,'',0,0
-- =============================================
CREATE   PROCEDURE [dbo].[ProductsSelectAll]
@Search varchar(100) = '',
@Offset INT,
@Limit INT
AS
BEGIN
	
	SET NOCOUNT ON;

	DECLARE @TotalRecords BIGINT;

	SET @TotalRecords = (select count(1) FROM Products P
			inner join Product_Types pt ON pt.Id = p.ProductTypeId
			where (ISNULL(@Search,'')='' OR P.ProductName like '%'+@Search+'%' OR P.Price like '%'+@Search+'%' 
			OR P.SellingPrice like '%'+@Search+'%' OR pt.[Name] like '%'+@Search+'%'))

	IF @Limit = 0 
	BEGIN 
	     set @Limit = @TotalRecords
		 IF @Limit=0
		 BEGIN
		 set @Limit=10
		 END
	END

	select P.*,pt.[Name] as ProductType
	from Products P 
	inner join Product_Types pt ON pt.Id = p.ProductTypeId 
	where (ISNULL(@Search,'')='' OR P.ProductName like '%'+@Search+'%' OR P.Price like '%'+@Search+'%' 
				OR P.SellingPrice like '%'+@Search+'%'	OR pt.[Name] like '%'+@Search+'%')
	order by P.Id asc

	OFFSET @Offset ROWS FETCH NEXT @Limit ROWS ONLY
	SELECT @TotalRecords AS TotalRecords
END
GO
/****** Object:  StoredProcedure [dbo].[ProductStockLedgerById]    Script Date: 2/7/2022 12:24:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,DarshanV>
-- Create date: <Create Date,07-01-2022>
-- Description:	<Description,Select Products By Id>
-- EXEC [dbo].[ProductStockLedgerById] 1
-- =============================================
CREATE   PROCEDURE [dbo].[ProductStockLedgerById]
	@Id int
AS
BEGIN
	
	SET NOCOUNT ON;

	DECLARE @Code INT = 200,
	       @Message VARCHAR(255) = 'Product stock ledger Successfully'
	SELECT @Code AS Code, @Message AS [Message]
    
	select	
	*
   FROM ProductStockLedger where Id=@Id
    
END
GO
/****** Object:  StoredProcedure [dbo].[ProductStockLedgerDelete]    Script Date: 2/7/2022 12:24:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,DarshanV>
-- Create date: <Create Date,07-01-2022>
-- Description:	<Description,Delete District by Id>
-- EXEC [dbo].[ProductStockLedgerDelete] 1
-- =============================================
CREATE   PROCEDURE [dbo].[ProductStockLedgerDelete]
	@Id int
AS
BEGIN
	
	SET NOCOUNT ON;

    IF not exists (select * from ProductStockLedger where Id=@Id)
	BEGIN
	     SELECT 0
	END
    ELSE
	BEGIN
	     
		 delete from ProductStockLedger where  Id=@Id
		 select 1
	END   
END
GO
/****** Object:  StoredProcedure [dbo].[ProductStockLedgerSelectAllByProductId]    Script Date: 2/7/2022 12:24:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		DARSHAN S
-- Create date: 15-11-2021
-- Description:	SELECT ALL District
-- EXEC [dbo].[ProductStockLedgerSelectAllByProductId] '',0,10,0
-- =============================================
CREATE   PROCEDURE [dbo].[ProductStockLedgerSelectAllByProductId]
@Search varchar(100) = '',
@Offset INT,
@Limit INT,
@ProductId INT
AS
BEGIN
	
	SET NOCOUNT ON;

	DECLARE @TotalRecords BIGINT;

	SET @TotalRecords = (select COUNT(1)
	from ProductStockLedger PS
	inner join Products P  ON PS.ProductId = P.Id
	where (ISNULL(@Search,'')='' OR PS.Price like '%'+@Search+'%' 
			OR PS.SellingPrice like '%'+@Search+'%' OR P.ProductName like '%'+@Search+'%') and ProductId = @ProductId)

	IF @Limit = 0 
	BEGIN 
	     set @Limit = @TotalRecords
		 IF @Limit=0
		 BEGIN
		 set @Limit=10
		 END
	END

	select PS.*, P.ProductName
	from ProductStockLedger PS
	inner join Products P  ON PS.ProductId = P.Id
	where (ISNULL(@Search,'')='' OR PS.Price like '%'+@Search+'%' 
			OR PS.SellingPrice like '%'+@Search+'%' OR P.ProductName like '%'+@Search+'%') and ProductId = @ProductId
	order by PS.Id DESC

	OFFSET @Offset ROWS FETCH NEXT @Limit ROWS ONLY
	SELECT @TotalRecords AS TotalRecords
END
GO
/****** Object:  StoredProcedure [dbo].[ProductStockLedgerUpsert]    Script Date: 2/7/2022 12:24:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:       
-- Create date:   
-- Description: Get User Group Permission Lists for specific User Group (Task = 1),   
--    Save Permission for User Group (Task = 2)  
-- =============================================  
-- EXEC [dbo].[ProductStockLedgerUpsert]   
CREATE   PROCEDURE [dbo].[ProductStockLedgerUpsert] 
 @Id int=0 
 ,@ProductId int
 ,@Price decimal(18,2)=0
 ,@SellingPrice decimal(18,2)=0
 ,@Stock int
 ,@CommentText nvarchar(1000)
 ,@CreatedBy int=NULL
 ,@ModifiedBy int=NULL
AS
BEGIN
	SET NOCOUNT ON;

	 DECLARE @Code INT = 200,
			 @Message VARCHAR(255) = '';
	
	 IF @Id=0
	    BEGIN

		  INSERT INTO ProductStockLedger
				(	
					ProductId
					,Price
					,SellingPrice
					,Stock
					,CommentText
					,CreatedBy
					,CreatedDate
				)
				Values
				(
					@ProductId
					,@Price
					,@SellingPrice
					,@Stock
					,@CommentText
					,@CreatedBy
					,GETDATE()
				)
		
			 set @Id = SCOPE_IDENTITY()
			 set @Message = 'Stock added successfully'	
			 SELECT @Code AS Code, @Message AS [Message]

			UPDATE Products SET Stock = (ISNULL(Stock,0) + @Stock), Price = @Price,
						SellingPrice= CASE WHEN SellingPrice < @SellingPrice THEN @SellingPrice ELSE SellingPrice END where Id = @ProductId

	END
	 ELSE
	 BEGIN
		DECLARE @OldStock int = 0;
		
		SELECT @OldStock =Stock from ProductStockLedger Where Id = @Id
			UPDATE Products SET Stock = (ISNULL(Stock,0) + (@Stock - @OldStock)), Price = @Price,
				 SellingPrice= CASE WHEN SellingPrice < @SellingPrice THEN @SellingPrice ELSE SellingPrice END where Id = @ProductId

			Update ProductStockLedger
			set 
			ProductId = ISNULL(@ProductId, ProductId)
			,Price = ISNULL(@Price, Price)
			,SellingPrice = ISNULL(@SellingPrice, SellingPrice)
			,Stock = ISNULL(@Stock, Stock)
			,CommentText = ISNULL(@CommentText,CommentText)
			,ModifiedBy = ISNULL(@ModifiedBy,ModifiedBy),
			ModifiedDate = GETDATE()
			where Id=@Id

			set @Message = 'Stock updated successfully'	

			SELECT @Code AS Code, @Message AS [Message]
	  END

	select * from ProductStockLedger where Id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[ProductsUpsert]    Script Date: 2/7/2022 12:24:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:       
-- Create date:   
-- Description: Get User Group Permission Lists for specific User Group (Task = 1),   
--    Save Permission for User Group (Task = 2)  
-- =============================================  
-- EXEC [dbo].[ProductsUpsert]   
CREATE   PROCEDURE [dbo].[ProductsUpsert] 
 @Id int=0
 ,@ProductName varchar(100)=NULL
 ,@Price decimal(18,2)=0
 ,@SellingPrice decimal(18,2)=0
 ,@Stock int
 ,@ProductImages varchar(100)=NULL
 ,@ProductTypeId int
 ,@CreatedBy int=NULL
 ,@ModifiedBy int=NULL
AS
BEGIN
	SET NOCOUNT ON;

	 DECLARE @Code INT = 200,
			 @Message VARCHAR(255) = '';
	
	 IF @Id=0
	    BEGIN

		IF NOT EXISTS (SELECT 1 from Products where ProductName = RTRIM(LTRIM(@ProductName)))
		BEGIN
			INSERT INTO Products
				(	
					ProductName
					,Price
					,SellingPrice
					,Stock
					,ProductImages
					,ProductTypeId
					,CreatedBy
					,CreatedDate
				)
				Values
				(
					RTRIM(LTRIM(@ProductName))
					,@Price
					,@SellingPrice
					,@Stock
					,@ProductImages
					,@ProductTypeId
					,@CreatedBy
					,GETDATE()
				)
						
			 set @Id = SCOPE_IDENTITY()
			 set @Message = 'Product added successfully'	

			 Insert into ProductStockLedger 
					(ProductId
					,Stock
					,Price
					,SellingPrice
					,CommentText
					,CreatedBy
					,CreatedDate)
			Values (@Id
					,@Stock
					,@Price
					,@SellingPrice
					,'Product add time added stocks'
					,@CreatedBy
					,GETDATE())
		END
		ELSE
		BEGIN
			SET @Code = 403
			set @Message = 'Added Products '+ RTRIM(LTRIM(@ProductName)) +' is already Exists !'	
		END
			SELECT @Code AS Code, @Message AS [Message]
		END
	 
	 ELSE
	 BEGIN
			Update Products
			set 
			ProductName=  ISNULL(RTRIM(LTRIM(@ProductName)),[ProductName])
			,Price = ISNULL(@Price, Price)
			,SellingPrice = ISNULL(@SellingPrice, SellingPrice)
			,Stock = ISNULL(@Stock, Stock)
			,ProductImages = ISNULL(@ProductImages, ProductImages)
			,ProductTypeId = ISNULL(@ProductTypeId, ProductTypeId),
			ModifiedBy			= ISNULL(@ModifiedBy,ModifiedBy),
			ModifiedDate	    = GETDATE()
			where Id=@Id

			set @Message = 'Products updated successfully'	

			SELECT @Code AS Code, @Message AS [Message]
	  END

	select * from Products where Id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[ProductTypeById]    Script Date: 2/7/2022 12:24:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,Payal>
-- Create date: <Create Date,24-12-2019>
-- Description:	<Description,Select User By Id>
-- EXEC [dbo].[ProductTypeById] 1
-- =============================================
CREATE   PROCEDURE [dbo].[ProductTypeById]
	@Id int
AS
BEGIN
	
	SET NOCOUNT ON;

	DECLARE @Code INT = 200,
	       @Message VARCHAR(255) = 'Product Type Retrived Successfully'
	SELECT @Code AS Code, @Message AS [Message]
    
	select	
	*
  FROM Product_Types where Id=@Id
    
END
GO
/****** Object:  StoredProcedure [dbo].[ProductTypeDelete]    Script Date: 2/7/2022 12:24:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,Payal>
-- Create date: <Create Date,24-12-2019>
-- Description:	<Description,Delete District by Id>
-- EXEC [dbo].[ProductTypeDelete] 1
-- =============================================
CREATE   PROCEDURE [dbo].[ProductTypeDelete]
	@Id int
AS
BEGIN
	
	SET NOCOUNT ON;

    IF not exists (select * from Product_Types where Id=@Id)
	BEGIN
	     SELECT 0
	END
    ELSE
	BEGIN
	     
		 delete from Product_Types where  Id=@Id
		 select 1
	END   
END
GO
/****** Object:  StoredProcedure [dbo].[ProductTypeSelectAll]    Script Date: 2/7/2022 12:24:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		DARSHAN S
-- Create date: 15-11-2021
-- Description:	SELECT ALL District
-- EXEC [dbo].[ProductTypeSelectAll] 0,'',0,0
-- =============================================
CREATE   PROCEDURE [dbo].[ProductTypeSelectAll]
@Search varchar(100) = '',
@Offset INT,
@Limit INT
AS
BEGIN
	
	SET NOCOUNT ON;

	DECLARE @TotalRecords BIGINT;

	SET @TotalRecords = (select count(1) FROM Product_Types where (ISNULL(@Search,'')=''  OR [Name] like '%'+@Search+'%' ))

	IF @Limit = 0 
	BEGIN 
	     set @Limit = @TotalRecords
		 IF @Limit=0
		 BEGIN
		 set @Limit=10
		 END
	END

	select *
	from Product_Types where (ISNULL(@Search,'')=''  OR [Name] like '%'+@Search+'%' ) order by Id asc

	OFFSET @Offset ROWS FETCH NEXT @Limit ROWS ONLY
	SELECT @TotalRecords AS TotalRecords
END
GO
/****** Object:  StoredProcedure [dbo].[ProductTypeUpsert]    Script Date: 2/7/2022 12:24:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:       
-- Create date:   
-- Description: Get User Group Permission Lists for specific User Group (Task = 1),   
--    Save Permission for User Group (Task = 2)  
-- =============================================  
-- EXEC [dbo].[ProductTypeUpsert]   
CREATE   PROCEDURE [dbo].[ProductTypeUpsert] 
 @Id int=0
 ,@Name varchar(500)=NULL
 ,@CreatedBy int=NULL
 ,@ModifiedBy int=NULL
AS
BEGIN
	SET NOCOUNT ON;

	 DECLARE @Code INT = 200,
			 @Message VARCHAR(255) = '';
	
	 IF @Id=0
	    BEGIN

		IF NOT EXISTS (SELECT 1 from Product_Types where [Name] = RTRIM(LTRIM(@Name)))
		BEGIN
			INSERT INTO Product_Types
				(	
					[Name]
					,CreatedBy
					,CreatedDate
				)
				Values
				(
					 RTRIM(LTRIM(@Name))
					,@CreatedBy
					,GETDATE()
				)
						
			 set @Id = SCOPE_IDENTITY()
			 set @Message = 'Product Type added successfully'	
		END
		ELSE
		BEGIN
			SET @Code = 403
			set @Message = 'Added Product Type '+ RTRIM(LTRIM(@Name)) +' is already Exists !'	
		END
			SELECT @Code AS Code, @Message AS [Message]
		END
	 
	 ELSE
	 BEGIN
			Update Product_Types
			set 
			[Name]				= ISNULL(RTRIM(LTRIM(@Name)),[Name]),
			ModifiedBy			= ISNULL(@ModifiedBy,ModifiedBy),
			ModifiedDate	    = GETDATE()
			where Id=@Id

			set @Message = 'Product Type updated successfully'	

			SELECT @Code AS Code, @Message AS [Message]
	  END

	select * from Product_Types where Id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[StateById]    Script Date: 2/7/2022 12:24:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,Datshan>
-- Create date: <Create Date,24-12-2019>
-- Description:	<Description,Select User By Id>
-- EXEC [dbo].[StateById] 1
-- =============================================
CREATE   PROCEDURE [dbo].[StateById]
	@Id int
AS
BEGIN
	
	SET NOCOUNT ON;

	DECLARE @Code INT = 200,
	       @Message VARCHAR(255) = 'State Retrived Successfully'
	SELECT @Code AS Code, @Message AS [Message]
    
	select	
	*
  FROM [State] where Id=@Id
    
END
GO
/****** Object:  StoredProcedure [dbo].[StateDelete]    Script Date: 2/7/2022 12:24:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,Payal>
-- Create date: <Create Date,24-12-2019>
-- Description:	<Description,Delete State by Id>
-- EXEC [dbo].[StateDelete] 1
-- =============================================
CREATE   PROCEDURE [dbo].[StateDelete]
	@Id int,
	@UserId int
AS
BEGIN
	
	SET NOCOUNT ON;

    IF not exists (select * from [State] where Id=@Id)
	BEGIN
	     SELECT 0
	END
    ELSE
	BEGIN
	     
		Update [State]	set DeletedBy=@UserId , DeletedDate = GETDATE() where Id=@Id
		 
		 select 1
	END   
END
GO
/****** Object:  StoredProcedure [dbo].[StateSelectAll]    Script Date: 2/7/2022 12:24:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		DARSHAN S
-- Create date: 15-11-2021
-- Description:	SELECT ALL STATE
-- EXEC [dbo].[StateSelectAll] 0,10,''
-- =============================================
CREATE   PROCEDURE [dbo].[StateSelectAll]
	@Offset INT,
	@Limit INT,
	@Search varchar(100) = ''
AS
BEGIN
	
	SET NOCOUNT ON;

	DECLARE @TotalRecords BIGINT;

	SET @TotalRecords = (select count(1) FROM [State] where ISNULL(DeletedBy,0) = 0 and ISNUll(DeletedDate,'') = '' and
	(ISNULL(@Search,'')=''  OR [Name] like '%'+@Search+'%' ))

	IF @Limit = 0 
	BEGIN 
	     set @Limit = @TotalRecords
		 IF @Limit=0
		 BEGIN
		 set @Limit=10000000
		 END
	END

	select * from [State] where ISNULL(DeletedBy,0) = 0 and ISNUll(DeletedDate,'') = '' and
	(ISNULL(@Search,'')=''  OR [Name] like '%'+@Search+'%' )  order by Id asc

	OFFSET @Offset ROWS FETCH NEXT @Limit ROWS ONLY
	SELECT @TotalRecords AS TotalRecords
END
GO
/****** Object:  StoredProcedure [dbo].[StateSelectAllForDropdown]    Script Date: 2/7/2022 12:24:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		DARSHAN S
-- Create date: 15-11-2021
-- Description:	SELECT ALL STATE
-- EXEC [dbo].[StateSelectAllForDropdown]
-- =============================================
CREATE   PROCEDURE [dbo].[StateSelectAllForDropdown]
AS
BEGIN
	
	SET NOCOUNT ON;

	DECLARE @TotalRecords BIGINT;

	SET @TotalRecords = (select count(1) FROM [State])

	select* from [State] order by id asc

	SELECT @TotalRecords AS TotalRecords
	END
GO
/****** Object:  StoredProcedure [dbo].[StateUpsert]    Script Date: 2/7/2022 12:24:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:       
-- Create date:   
-- Description: Get User Group Permission Lists for specific User Group (Task = 1),   
--    Save Permission for User Group (Task = 2)  
-- =============================================  
-- EXEC [dbo].[StateUpsert]   
CREATE   PROCEDURE [dbo].[StateUpsert] 
 @Id int=0
 ,@Name varchar(500)=NULL
 ,@CreatedBy int=NULL
 ,@ModifiedBy int=NULL
AS
BEGIN
	SET NOCOUNT ON;

	 DECLARE @Code INT = 200,
			 @Message VARCHAR(255) = '';
	
	 IF @Id=0
	    BEGIN
			INSERT INTO [State]
				(	
					Name
					,CreatedBy
					,CreatedDate
				)
				Values
				(
					 @Name
					,@CreatedBy
					,GETDATE()
				)
						
			 set @Id = SCOPE_IDENTITY()
			 set @Message = 'State added successfully'	

			SELECT @Code AS Code, @Message AS [Message]
		END
	 
	 ELSE
	 BEGIN
			Update [State]
			set 
			Name				= ISNULL(@Name,Name),
			ModifiedBy			= ISNULL(@ModifiedBy,ModifiedBy),
			ModifiedDate	    = GETDATE()
			where Id=@Id

			set @Message = 'State updated successfully'	

			SELECT @Code AS Code, @Message AS [Message]
	  END

	select * from State where Id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[UserById]    Script Date: 2/7/2022 12:24:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,Darshan>
-- Create date: <Create Date,24-12-2019>
-- Description:	<Description,Select User By Id>
-- EXEC [dbo].[StateById] 1
-- =============================================
CREATE   PROCEDURE [dbo].[UserById]
	@Id int
AS
BEGIN
	
	SET NOCOUNT ON;

	DECLARE @Code INT = 200,
	       @Message VARCHAR(255) = 'User data Retrived Successfully'
	SELECT @Code AS Code, @Message AS [Message]
    
	select	
	*
  FROM Users where Id=@Id
    
END
GO
/****** Object:  StoredProcedure [dbo].[UserLogin]    Script Date: 2/7/2022 12:24:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- exec [UserLogin] '8160544874','123'
CREATE PROCEDURE [dbo].[UserLogin]
	@UserName varchar(100),
	@Password varchar(200)
AS
BEGIN
	DECLARE @Code INT = 401,
			@Message VARCHAR(255) = '',
			@PId varchar(250),
			@CId int

	If exists (select 1 from Users where (Email = @UserName or Mobile = @UserName) ) 
	BEGIN
			If exists (select 1 from Users where (Email = @UserName or Mobile = @UserName) and [Password] = CONVERT(VARCHAR(300), HASHBYTES('SHA1', @Password  + Salt), 1) and IsActive=1)
			BEGIN
					SET @Code = 200
					SET @Message = 'Login Successfully'

					SELECT @Code AS Code, @Message AS Message


					SELECT 
						*
					FROM Users 
					 where (Email = @UserName or Mobile = @UserName)

			END
			ELSE IF exists(select 1 from Users where (Email = @UserName or Mobile = @UserName) and [Password] = CONVERT(VARCHAR(300), HASHBYTES('SHA1', @Password  + Salt), 1) and IsActive=0)
			BEGIN
				SET @Message = 'User is InActive!!'
					SET @Code = 400
					SELECT @Code AS Code, @Message AS Message
					select * from Users where Id=0
			END
			ELSE
			BEGIN
				SET @Message = 'Incorrect Password !!'
				SET @Code = 400
				SELECT @Code AS Code, @Message AS Message
				select * from Users where Id=0
			END
	END
	ELSE
		BEGIN
			SET @Code = 404
			SET @Message = 'This User can''t Exists !!'
			SELECT @Code AS Code, @Message AS Message
			select * from Users where Id=0
		END

END
GO
/****** Object:  StoredProcedure [dbo].[UsersUpsert]    Script Date: 2/7/2022 12:24:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,Darshan>
-- Create date: <Create Date,24-12-2019>
-- Description:	<Description,Insert Update Users>
-- EXEC [UsersUpsert] 
-- =============================================
CREATE PROCEDURE [dbo].[UsersUpsert]
 @Id int=0
,@FirstName  varchar(50) = NULL
,@LastName  varchar(50) = NULL
,@Email varchar(100) = NULL
,@Mobile varchar(50) = NULL
,@Password varchar(200) = NULL
,@Address varchar(MAX) = NULL
,@StateId int = 0
,@DistrictId int = 0
,@UserType int =0
,@CreatedBy int = 0
,@ModifiedBy int = 0
AS
BEGIN
	
	SET NOCOUNT ON;

	 DECLARE @Code INT = 200,
			 @Message VARCHAR(255) = '',	
			 @B int 
			 ,@Salt VARCHAR(MAX)=''
    
	BEGIN
		--IF @FullName IS NULL OR @FullName = ''
		--BEGIN 
		--	set @Id = 0
		--	 set @Code = 400
		--	 set @Message = 'Full Name is required'		
		--END
		IF @Email IS NULL OR @Email = ''
		BEGIN 
				set @Id = 0
				set @Code = 400
				set @Message = 'Email is required'		
		END
		--ELSE IF @Password IS NULL OR @Password = ''
		--BEGIN 
		--		set @Id = 0
		--		set @Code = 400
		--		set @Message = 'Password is required'		
		--END
		ELSE IF @Mobile IS NULL OR @Mobile = ''
		BEGIN 
				set @Id = 0
				set @Code = 400
				set @Message = 'Mobile is required'		
		END
		 ELSE
			 BEGIN
			 Set @Salt = CONVERT(NVARCHAR(100),NEWID())
			 Set @Password = CONVERT(VARCHAR(300),HASHBYTES('SHA1',@Password + @Salt),1)
					 IF @Id = 0
						BEGIN
							IF exists (select * from Users where lower(Email)=lower(@Email))
									 BEGIN
										  set @Id = 0
										  set @Code = 403
										  set @Message = 'Failed to add the User as '+@Email+' already exists! Kindly add a different email.'			  
									 END
							ELSE IF exists (select * from Users where lower(Mobile)= @Mobile)
							BEGIN
									  set @Id = 0
									  set @Code = 403
									  set @Message = 'Failed to add the User as '+@Mobile+' already exists! Kindly add a different Mobile.'	
							END
							 ELSE
								BEGIN
									INSERT INTO Users
									  (		 
										 FirstName
										,LastName
										,Email
										,Mobile
										,Salt
										,[Password]
										,[Address]
										,UserType
										,StateId
										,DistrictId
										,CreatedDate
										,IsActive
									   ) 
									  VALUEs
									  (	
									     @FirstName
										,@LastName
										,@Email
										,@Mobile
										,@Salt
										,@Password
										,@Address
										,@UserType
										,@StateId
										,@DistrictId
										,GETDATE()
										,1
									  )
			  
									  set @Id = SCOPE_IDENTITY()
									  set @Message = 'User added successfully'	
									 
								END
						END
					 ELSE
						BEGIN
							IF exists (select * from Users where lower(Email)=lower(@Email)and Id != @Id)
								BEGIN
									set @Id = 0
									set @Code = 403
									set @Message = 'Failed to update the User as '+@Email+' already exists! Kindly add a different name.'			  
								END
							ELSE IF exists (select * from Users where lower(Mobile)= @Mobile and Id != @Id)
							BEGIN
									  set @Id = 0
									  set @Code = 403
									  set @Message = 'Failed to add the User as '+@Mobile+' already exists! Kindly add a different Mobile.'	
							END
							ELSE
								 BEGIN
										  UPDATE Users
										  SET 
										 FirstName	=ISNULL(@FirstName,FirstName	)
										,LastName	=ISNULL(@LastName ,LastName		)
										,Email		=ISNULL(@Email	  ,Email		)
										,Mobile		=ISNULL(@Mobile	  ,Mobile		)
										,Salt		=ISNULL(@Salt	  ,Salt			)
										,[Password]	=ISNULL(@Password ,[Password]	)
										,[Address]	=ISNULL(@Address  ,[Address]	)
										,UserType	=ISNULL(@UserType ,UserType		)
										,StateId	=ISNULL(@StateId ,StateId		)
										,DistrictId	=ISNULL(@DistrictId ,DistrictId		)
										,ModifiedDate= GETDATE()
										    WHERE 
											id=@Id			  
		
										 set @Message = 'User updated successfully'
								 END
						END
			 END
	END

	SELECT @Code AS Code, @Message AS [Message]

    SELECT * from Users
	where id = @Id
END
GO
USE [master]
GO
ALTER DATABASE [Mart] SET  READ_WRITE 
GO
