GO

SET QUOTED_IDENTIFIER ON
GO
use [4097-Haseeb-Angular]
CREATE PROCEDURE [dbo].[getinfo]
@country varchar(50)
AS
begin
SELECT * FROM Calculator where country=@country
end
GO
drop procedure getinfo

exec getinfo 'Pakistan'
