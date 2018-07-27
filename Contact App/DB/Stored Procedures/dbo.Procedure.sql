CREATE PROCEDURE [dbo].[ContactAddOrEdit]
	@mode nvarchar(10),
	@ContactId int,
	@Name nvarchar(50),
	@MobileNumber nvarchar(50),
	@Address nvarchar(250)

AS
	IF @mode='Add'
	BEGIN
	INSERT INTO tbl_Contact
		(
		Name,
		MobileNumber, 
		Address
		)
	VALUES
		(
			@Name,
			@MobileNumber,
			@Address
		)
		END