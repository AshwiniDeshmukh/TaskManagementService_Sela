-- **********************************************************************************************************************************
-- CreatePatientAllergy.sql
-- 1. Create entry for PatientAllergy
-- 2. If Patient does not exist, throws not found, else returns newly created Id

-- Transform Notes:
-- 1. Error code:
--    * Postgres throws error code 50001 (user-defined code for not found).
--    * For SqlServer, we also throw 50001. The error location indicator (1) is required in the syntax but not used by the caller.
-- 2. Validation exception handling:
--    The coalesce and "select raise" from postgres is replaced by assigning the conditional logic to variables, checking those variables,
--    and raising the exception in the query script, because error handling in sql server cannot be done a user-defined function.

-- Change log:
-- 2023.08.18 - It executes a stored procedure created from the below file in CareTend-Desktop
--  PatientAllergyInsert.proc.sql

-- **********************************************************************************************************************************

DECLARE
    @PatientId bigint,
    @ErrorReason varchar(max),
    @ErrorCode int

SELECT @PatientId = P.Id
FROM 
    Patient.Patient P
JOIN
    Common.Party PAR on PAR.Id = P.Id
WHERE 
    PAR.Party_Key = @PatientKey
AND 
    PAR.RecStatus > 0

IF (@PatientId IS NULL)
BEGIN 
    SELECT @ErrorCode = Code, @ErrorReason = Reason FROM Utilities.error_not_found('Patient', @PatientKey);
    THROW @ErrorCode, @ErrorReason, 1
END

DECLARE @UserDefinedAllergy_Id int = CAST(CASE WHEN @AllergyType = 4 THEN @ExternalRefKey END AS int)
DECLARE @AllergyName varchar(200) = (CASE WHEN @AllergyType = 4 AND @ExternalRefKey IS NOT NULL THEN NULL ELSE @Name END)
DECLARE @IsAffectingSkinRashesOrHives bit = 0
DECLARE @IsAffectingShockUnconsciousness bit = 0
DECLARE @IsAffectingAsthmaBreathing bit = 0
DECLARE @IsAffectingNauseaVomitingDiarrhea bit = 0
DECLARE @IsAffectingBloodDisorders bit = 0
DECLARE @ScreeningIdentifier varchar(50) = NULL
DECLARE @ScreeningIdentifierType int = CAST(CASE WHEN @AllergyType = 1 THEN 1
                                            WHEN @AllergyType = 5 THEN 2
                                            WHEN @AllergyType = 2 THEN 3
                                            ELSE NULL END AS int)
DECLARE @CreatedBy bigint = (SELECT ID FROM Security.DHSUser WHERE Username = @Username)
DECLARE @Id bigint

DECLARE @ProcResults TABLE (Id bigint, CreatedDate datetime2)

INSERT INTO @ProcResults
EXECUTE [Patient].[PatientAllergyInsert] 
   @Patient_Id = @PatientId
  ,@UserDefinedAllergy_Id = @UserDefinedAllergy_Id
  ,@Name = @AllergyName
  ,@IsAffectingSkinRashesOrHives = @IsAffectingSkinRashesOrHives
  ,@IsAffectingShockUnconsciousness = @IsAffectingShockUnconsciousness
  ,@IsAffectingAsthmaBreathing = @IsAffectingAsthmaBreathing
  ,@IsAffectingNauseaVomitingDiarrhea = @IsAffectingNauseaVomitingDiarrhea
  ,@IsAffectingBloodDisorders = @IsAffectingBloodDisorders
  ,@Note = @Note
  ,@ScreeningIdentifier = @ScreeningIdentifier
  ,@ScreeningIdentifierType = @ScreeningIdentifierType
  ,@CreatedBy = @CreatedBy
  ,@Id = @Id OUTPUT

SELECT PatientAllergy_Key FROM Patient.PatientAllergy WHERE Id = @Id
