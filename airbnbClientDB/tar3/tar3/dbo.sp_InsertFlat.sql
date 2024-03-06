-- =============================================
-- Author:		<Eden Ahrak>
-- Create date: <>
-- Description:	<this sp insert flats into flightsTable>
-- =============================================
ALTER PROCEDURE sp_InsertFlat
	-- Add the parameters for the stored procedure here
	@id varchar(30),
	@city nvarchar (30),
	@address varchar (30),
	@price float,
	@number_of_rooms int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		INSERT INTO FlatsTable(id,city,[address],price,number_of_rooms) values (@id,@city,@address,@price,@number_of_rooms)
END