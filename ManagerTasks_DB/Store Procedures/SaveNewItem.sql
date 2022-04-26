USE [TasksManager_DB]
GO

/****** Object:  StoredProcedure [dbo].[SaveNewItem]    Script Date: 26/04/2022 1:52:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SaveNewItem] 
@description varchar(256)
AS
BEGIN

	INSERT INTO [dbo].[Tasks] ([Description],[Active]) VALUES (@Description, 1)
	
    Select * from Tasks where active = 1
END
GO
