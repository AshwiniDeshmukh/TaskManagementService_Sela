-- **********************************************************************************************************************************
-- UpdatePatientAllergy.sql
-- 1. Update entry for PatientAllergy
-- 2. If PatientAllergy does not exist, throws not found

-- Transform Notes:
-- 1. Error code:
--    * Postgres throws error code 50001 (user-defined code for not found).
--    * For SqlServer, we also throw 50001. The error location indicator (1) is required in the syntax but not used by the caller.
-- 2. Validation exception handling:
--    The coalesce and "select raise" from postgres is replaced by assigning the conditional logic to variables, checking those variables,
--    and raising the exception in the query script, because error handling in sql server cannot be done a user-defined function.

-- Change log:
-- 2023.08.21 - It executes a stored procedure created from the below file in CareTend-Desktop
--  PatientAllergyUpdate.proc.sql

-- **********************************************************************************************************************************

DECLARE 
    @PatientAllergyWithCorrectVersion BIGINT,
    @PatientAllergyWithAnyVersion INT,
    @ErrorReason varchar(max),
    @ErrorCode int

    -- Finding PatientDiagnosis with correct version
SELECT 
    @PatientAllergyWithCorrectVersion = Id
FROM 
    Patient.PatientAllergy
WHERE PatientAllergy_Key = @PatientAllergyKey
    AND RecStatus > 0

IF (@PatientAllergyWithCorrectVersion IS NULL)
BEGIN
    SELECT @ErrorCode = code, @ErrorReason = reason FROM Utilities.error_not_found('PatientAllergy',@PatientAllergyKey);
    THROW @ErrorCode, @ErrorReason, 1
END

DECLARE @Id bigint = @PatientAllergyWithCorrectVersion
DECLARE @PatientId bigint = (SELECT Patient_Id FROM Patient.PatientAllergy WHERE PatientAllergy_Key = @PatientAllergyKey)
DECLARE @UserDefinedAllergy_Id int = CAST(CASE WHEN @AllergyType = 4 THEN @ExternalRefKey END AS int)
DECLARE @AllergyName varchar(200) = (CASE WHEN @AllergyType = 4 AND @ExternalRefKey IS NOT NULL THEN NULL ELSE @Name END)
DECLARE @IsAffectingSkinRashesOrHives bit
DECLARE @IsAffectingShockUnconsciousness bit
DECLARE @IsAffectingAsthmaBreathing bit
DECLARE @IsAffectingNauseaVomitingDiarrhea bit
DECLARE @IsAffectingBloodDisorders bit
DECLARE @ScreeningIdentifier varchar(50) = NULL
DECLARE @ScreeningIdentifierType int = CAST(CASE WHEN @AllergyType = 1 THEN 1
                                            WHEN @AllergyType = 5 THEN 2
                                            WHEN @AllergyType = 2 THEN 3
                                            ELSE NULL END AS int)
DECLARE @ModifiedBy bigint = (SELECT ID FROM Security.DHSUser WHERE Username = @Username)

SELECT @IsAffectingSkinRashesOrHives = IsAffectingSkinRashesOrHives,
    @IsAffectingShockUnconsciousness = IsAffectingShockUnconsciousness,
    @IsAffectingAsthmaBreathing = IsAffectingAsthmaBreathing,
    @IsAffectingNauseaVomitingDiarrhea = IsAffectingNauseaVomitingDiarrhea,
    @IsAffectingBloodDisorders = IsAffectingBloodDisorders
    FROM Patient.PatientAllergy WHERE Id = @Id

EXECUTE [Patient].[PatientAllergyUpdate]
   @Id = @Id
  ,@Patient_Id = @PatientId
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
  ,@ModifiedBy = @ModifiedBy
