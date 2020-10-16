USE [Demo]
GO
/****** Object:  Table [dbo].[tblBranch]    Script Date: 10/9/2020 3:16:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblBranch](
	[BranchID] [int] IDENTITY(1,1) NOT NULL,
	[BranchName] [varchar](50) NULL,
 CONSTRAINT [PK_tblBranch] PRIMARY KEY CLUSTERED 
(
	[BranchID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[DeleteBranch]    Script Date: 10/9/2020 3:16:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteBranch]
	@Id INT
AS
BEGIN

DELETE FROM [dbo].[tblBranch] WHERE BranchID = @Id

END
GO
/****** Object:  StoredProcedure [dbo].[GetAllBranch]    Script Date: 10/9/2020 3:16:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllBranch]
AS
BEGIN
	SET NOCOUNT ON;

SELECT BranchID, BranchName FROM tblBranch

END
GO
/****** Object:  StoredProcedure [dbo].[GetBranchById]    Script Date: 10/9/2020 3:16:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetBranchById]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

SELECT BranchID, BranchName FROM tblBranch WHERE BranchID = @Id

END
GO
/****** Object:  StoredProcedure [dbo].[InsertBranch]    Script Date: 10/9/2020 3:16:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertBranch]
	@Branch VARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

INSERT INTO [dbo].[tblBranch]
           ([BranchName])
     VALUES
           (@Branch)		 
		   
SELECT @@IDENTITY

END
GO
/****** Object:  StoredProcedure [dbo].[UpdateBranch]    Script Date: 10/9/2020 3:16:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateBranch]
	@Id INT,
	@Branch VARCHAR(50)
AS
BEGIN

UPDATE [dbo].[tblBranch]
   SET [BranchName] = @Branch
 WHERE BranchID = @Id

END
GO
