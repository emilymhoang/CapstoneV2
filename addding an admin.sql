CREATE PROCEDURE dbo.AddUser(
    @Username NVARCHAR(50), 
    @Password NVARCHAR(50), 
    @TenantID NVARCHAR(40) = NULL, 
    @HostID NVARCHAR(40) = NULL,
	@AdminID NVARCHAR(40) = NULL,
	@AccountID NVARCHAR(40) = NULL)
AS
BEGIN
    SET NOCOUNT ON
        INSERT INTO dbo.[Login] (Username, Password, TenantID, HostID, AdminID, AccountID)
        VALUES(@Username, HASHBYTES('SHA2_512', @Password), @TenantID, @HostID, @AdminID, @AccountID)
END