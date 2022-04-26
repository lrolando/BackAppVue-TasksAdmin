USE [TasksManager_DB]
GO

/****** Object:  StoredProcedure [dbo].[UpdateItem]    Script Date: 26/04/2022 1:53:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateItem] 
@Id int,
@IsActive bit
AS
BEGIN

	UPDATE dbo.Tasks SET Active = @IsActive WHERE Id=@Id;
	
    Select * from Tasks

END
GO