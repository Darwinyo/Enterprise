create procedure [ASInternal_RethrowError] 
as
  begin
    set nocount on;
    
    -- Return if there is no error information to retrieve.
    if (error_number() is null)
        return;

    declare 
        @errorMessage    nvarchar(2048),
        @errorNumber     int,
        @errorSeverity   int,
        @errorState      int,
        @errorLine       int,
        @errorProcedure  nvarchar(200);

    -- Assign variables to error-handling functions that 
    -- capture information for RAISERROR.
    select 
        @errorNumber = error_number(),
        @errorSeverity = error_severity(),
        @errorState = error_state(),
        @errorLine = error_line(),
        @errorProcedure = isnull(error_procedure(), '-');

    -- Build the message string that will contain original
    -- error information.
    select @errorMessage = 
        N'Error %d, Level %d, State %d, Procedure %s, Line %d, ' + 
            'Message: '+ error_message();

    -- Raise an error: msg_str parameter of RAISERROR will contain
    -- the original error information.
    raiserror 
        (
        @errorMessage, 
        @errorSeverity, 
        @errorState,               
        @errorNumber,    -- parameter: original error number.
        @errorSeverity,  -- parameter: original error severity.
        @errorState,     -- parameter: original error state.
        @errorProcedure, -- parameter: original error procedure name.
        @errorLine       -- parameter: original error line number.
        );
  end