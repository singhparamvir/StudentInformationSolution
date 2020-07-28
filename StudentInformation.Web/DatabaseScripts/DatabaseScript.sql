GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentInfo]') AND type in (N'U'))
DROP TABLE [dbo].[StudentInfo]
GO

CREATE TABLE [dbo].[StudentInfo] (
    [Id]                       INT           IDENTITY (1, 1) NOT NULL,
    [userName]                 VARCHAR (15)  NULL,
    [Password]                 VARCHAR (100) NULL,
    [student_first_name]       VARCHAR (100) NULL,
    [student_middle_name]      VARCHAR (100) NULL,
    [student_last_name]        VARCHAR (100) NULL,
    [student_address1]         VARCHAR (500) NULL,
    [student_city]             VARCHAR (50)  NULL,
    [student_country]          VARCHAR (50)  NULL,
    [student_email]            VARCHAR (150) NULL,
    [student_graduation_year]  INT           NULL,
    [student_id]               INT           NULL,
    [is_international_student] BIT           NULL,
    [date_created]             SMALLDATETIME NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO
--------------------------------------------------------------------------------------

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[getAllStudents]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[getAllStudents]
GO

CREATE PROCEDURE [dbo].[getAllStudents]
AS
Begin
	SELECT * from StudentInfo with (nolock)
End

GO
--------------------------------------------------------------------------------------

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_deleteStudentById]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_deleteStudentById]
GO

CREATE PROCEDURE [dbo].[sp_deleteStudentById]
	@id int
AS
Begin 
	Delete from dbo.StudentInfo where id= @id
End

GO
--------------------------------------------------------------------------------------

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_getAllStudents]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_getAllStudents]
GO

create PROCEDURE [dbo].[sp_getAllStudents]
AS
Begin
	SELECT * from StudentInfo with (nolock)

End

GO
--------------------------------------------------------------------------------------

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_getStudentById]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_getStudentById]
GO
CREATE PROCEDURE [dbo].[sp_getStudentById]
	@id int
AS
Begin
	SELECT * from dbo.StudentInfo where id=@id
end

GO
--------------------------------------------------------------------------------------
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_insertStudentData]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_insertStudentData]
GO


CREATE PROCEDURE [dbo].[sp_insertStudentData]
	@UserName varchar(15),
	@Password varchar(100),
	@student_first_name varchar(100),
	@student_middle_name	varchar(100),		
	@student_last_name	varchar(100),		
	@student_address1	varchar(500),		
	@student_city	varchar(50),		
	@student_country	varchar(50),		
	@student_email	varchar(150),		
	@student_graduation_year	int,		
	--@student_id	varchar(50),		
	@is_international_student	bit,		
	@date_created	smalldatetime	
AS
Begin
	insert into dbo.StudentInfo (UserName,
	Password,
	student_first_name,
	student_middle_name,
	student_last_name,
	student_address1,
	student_city,
	student_country,
	student_email,
	student_graduation_year,
	--student_id,
	is_international_student,
	date_created)
	values (@UserName ,
	@Password ,
	@student_first_name,
	@student_middle_name,		
	@student_last_name,		
	@student_address1,		
	@student_city,		
	@student_country,		
	@student_email,		
	@student_graduation_year,		
	--@student_id,		
	@is_international_student,		
	@date_created)
End

GO