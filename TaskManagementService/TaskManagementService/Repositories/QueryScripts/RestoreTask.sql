-- **********************************************************************************************************************************
-- RestorePatientAllergy.sql
-- 1. Determine whether the requested PatientAllergy exists in PatientAllergy table, finds only deleted records
--    * If yes then restore the requested PatientAllergy key else raise an exception error not found.
-- 2. To restore PatientAllergy we update RecStatus to 1.

-- Transform Notes:
-- 1. Error code:
--    * Postgres throws error code 50001 (user-defined code for not found).
--    * For SqlServer, we also throw 50001. The error location indicator (1) is required in the syntax but not used by the caller.
-- 2. Validation exception handling:
--    The coalesce and "select raise" from postgres is replaced by assigning the conditional logic to variables, checking those variables,
--    and raising the exception in the query script, because error handling in sql server cannot be done a user-defined function.

-- Change log:
-- 2023.08.22 - It executes a stored procedure created from the below file in CareTend-Desktop
--  PatientAllergyDelete.proc.sql

-- ***********************************************************************************************************************************

DECLARE
    @PatientAllergyId bigint,
    @ErrorReason varchar(max),
    @ErrorCode int

SELECT @PatientAllergyId = PA.Id
    FROM Patient.PatientAllergy PA
    WHERE
        PA.PatientAllergy_Key = @PatientAllergyKey
    AND
        PA.RecStatus = 0

IF (@PatientAllergyId IS NULL)
BEGIN 
    SELECT @ErrorCode = Code, @ErrorReason = Reason FROM Utilities.error_not_found('PatientAllergy', @PatientAllergyKey);
    THROW @ErrorCode, @ErrorReason, 1
END

DECLARE @DeletedDate datetime2(7) = utilities.utc_now()
DECLARE @Restore bit = 1
DECLARE @DeletedBy bigint = (SELECT ID FROM Security.DHSUser WHERE Username = @Username)
DECLARE @IDs AS IDList

INSERT INTO @IDs
	SELECT PA.Id FROM Patient.PatientAllergy PA
    WHERE PA.Id = @PatientAllergyId

EXECUTE [Patient].[PatientAllergyDelete] 
   @DeletedBy = @DeletedBy
  ,@DeletedDate = @DeletedDate
  ,@Restore = @Restore
  ,@IDs = @IDs
