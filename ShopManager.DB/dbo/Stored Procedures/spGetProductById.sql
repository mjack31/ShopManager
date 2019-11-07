CREATE PROCEDURE [dbo].[spGetProductById]
	@Id int
AS
BEGIN
	SELECT *
	FROM dbo.Product
	WHERE Id = @Id
END
