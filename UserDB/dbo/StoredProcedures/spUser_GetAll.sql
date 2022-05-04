CREATE PROCEDURE [dbo].[spUser_GetAll]
AS
begin
	SELECT Id, FirstName, LastName
	from dbo.[User];
end
