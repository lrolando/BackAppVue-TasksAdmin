USE [TasksManager_DB]
GO

/****** Object:  StoredProcedure [dbo].[DeleteItem]    Script Date: 26/04/2022 1:52:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteItem] 
@Id int,
@IsActive bit
AS
BEGIN

	Delete from Tasks where Id = @Id;
	
    Select * from Tasks where active = @IsActive
END
GO