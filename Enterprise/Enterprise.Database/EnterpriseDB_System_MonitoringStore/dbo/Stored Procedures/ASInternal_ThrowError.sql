create procedure [ASInternal_ThrowError] 
(
  @errorCode int,
  @errorMessage nvarchar(1024),
  @errorState int = 0  
)
as
  begin
    set nocount on;

    declare @errorMessageThrown nvarchar(2047);
    
    set @errorMessage = replace(@errorMessage, N'\', N'\\');
    set @errorMessage = replace(@errorMessage, N'"', N'\"');
    
    set @errorMessageThrown = N'MSAS' + convert(nvarchar(12), @errorCode) + N':' + @errorMessage;      

    raiserror (@errorMessageThrown, 16, @errorState) with seterror;
  end;