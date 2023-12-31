USE [AdventureWorks2022]
GO
/****** Object:  StoredProcedure [dbo].[GetPersons]    Script Date: 9. 10. 2023 19:42:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetPersons] @Parameter nvarchar(50)
AS
    if(@Parameter is not NULL)
	Begin
	    Declare @ParameterAsNumeric nvarchar(50);
	    SET @ParameterAsNumeric=REPLACE(@Parameter,'-','');
		if ISNUMERIC(@ParameterAsNumeric)=1
			Begin
				Select	Person.Person.FirstName,
				Person.Person.LastName,
				Person.PersonPhone.PhoneNumber,
				Person.PersonPhone.PhoneNumberTypeID,
				Person.PhoneNumberType.Name as 'Type of phone'
				From Person.Person LEFT JOIN Person.PersonPhone ON Person.BusinessEntityID=PersonPhone.BusinessEntityID
								   LEFT JOIN Person.PhoneNumberType ON Person.PersonPhone.PhoneNumberTypeID=Person.PhoneNumberType.PhoneNumberTypeID
				Where Person.PersonPhone.PhoneNumber=@Parameter
				Order by  Person.Person.LastName ASC
			End
		ELSE
		Begin
			Select	Person.Person.FirstName,
			Person.Person.LastName,
			Person.PersonPhone.PhoneNumber,
			Person.PersonPhone.PhoneNumberTypeID,
			Person.PhoneNumberType.Name as 'Type of phone'
			From Person.Person  LEFT JOIN Person.PersonPhone ON Person.BusinessEntityID=PersonPhone.BusinessEntityID
								LEFT JOIN Person.PhoneNumberType ON Person.PersonPhone.PhoneNumberTypeID=Person.PhoneNumberType.PhoneNumberTypeID
			Where Person.FirstName=@Parameter OR Person.LastName=@Parameter 
			Order by  Person.Person.LastName ASC
		End
    End
	Else
		THROW 51000, 'The record does not exist.', 1; 


