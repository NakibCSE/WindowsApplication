USE [Econtact]
GO
/****** Object:  StoredProcedure [dbo].[sprInsertContact]    Script Date: 2023-08-26 14:43:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[sprInsertContact]
@FirstName varchar(50),
@LastName varchar(50),
@ContactNo varchar(20),
@Address varchar(255),
@Gender varchar(10),
@ResultMessage NVARCHAR(100) OUTPUT
AS
Begin
	BEGIN TRY
		insert into tbl_contact(FirstName, LastName, ContactNo, Address, Gender) values (@FirstName, @LastName,@ContactNo,@Address,@Gender);
		set @ResultMessage = 'Data INSERTED Successfully.';
	END TRY
	BEGIN CATCH
		set @ResultMessage = 'Data Failed to insert.';
	END CATCH
End;