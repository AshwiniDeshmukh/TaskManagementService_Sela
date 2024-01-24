-- **********************************************************************************************************************************
-- GetPatientAllergies.sql
-- 1.  GET various patient allergies-related information from PatientAllergy.

-- Change log:
-- 2023.07.31 - Created from the following postgres file
--  New script, not in postgres

-- ***********************************************************************************************************************************

CREATE TABLE #PatientAllergyKeys(Id bigint, RowNum INT, PatientAllergy_Key UNIQUEIDENTIFIER)

IF( @PatientAllergyKeysAsCsv <> '' )
BEGIN
    INSERT INTO #PatientAllergyKeys(Id, RowNum, PatientAllergy_Key)
    SELECT PA.Id, T.RowNum, T.PatientAllergy_Key
    FROM
        (
            SELECT O.Value as PatientAllergy_Key, ROW_NUMBER() OVER(ORDER BY (SELECT NULL)) as RowNum
            FROM string_split(CAST(@PatientAllergyKeysAsCsv AS varchar(max)),',') O
        ) T
    LEFT JOIN Patient.PatientAllergy PA ON T.PatientAllergy_Key = PA.PatientAllergy_Key
    AND
        1 = 
        CASE WHEN @IncludeRemoved IS NULL THEN 1
            WHEN @IncludeRemoved = 1 THEN 1
            WHEN @IncludeRemoved = 0 THEN (CASE WHEN PA.RecStatus > 0 THEN 1 ELSE 0 END)
        ELSE 0
        END
END

DECLARE
    @AnyNotFoundKey VARCHAR(36),
    @ErrorReason varchar(max),
    @ErrorCode int

SET @AnyNotFoundKey = (SELECT TOP 1 PatientAllergy_Key FROM #PatientAllergyKeys WHERE Id IS NULL)

IF (@AnyNotFoundKey IS NOT NULL)
BEGIN 
    SELECT @ErrorCode = Code, @ErrorReason = Reason FROM Utilities.error_not_found('PatientAllergy', @AnyNotFoundKey);
    THROW @ErrorCode, @ErrorReason, 1
END

SELECT
    PA.PatientAllergy_Key AS PatientAllergyKey,
    (SELECT TOP 1 Party_Key FROM Common.Party P WHERE P.Id = PA.Patient_Id) AS PatientKey,
    COALESCE(UDA.Name, PA.Name) AS Name,
	CAST(CASE WHEN PA.UserDefinedAllergy_Id IS NOT NULL THEN 4
	        WHEN PA.ScreeningIdentifierType = 1 THEN 1
			WHEN PA.ScreeningIdentifierType = 2 THEN 5
			WHEN PA.ScreeningIdentifierType = 3 THEN 2
			ELSE 4 END AS int) AS AllergyType,	
	1 AS [ClinicalStatusType],
	1 AS [AllergySeverityType],
	1 AS [VerificationStatusType],
	PA.Note,
    CAST(NULL AS varchar) AS ReportingIndividual,
    PE.FirstName + ' ' + PE.LastName AS RecordingIndividual,
    PA.CreatedDate AS DateRecorded,
    1 AS [Version],
    COALESCE(PA.ModifiedDate,PA.CreatedDate) AS VersionOn,
    COALESCE(DU_M.UserName,DU.UserName) AS VersionBy,
    @ClientId AS ClientId
FROM
    #PatientAllergyKeys T
INNER JOIN 
    Patient.PatientAllergy PA ON T.Id = PA.Id	
LEFT JOIN 
	Security.DHSUser DU ON DU.Id = PA.CreatedBy
LEFT JOIN
	Common.Person PE ON PE.Id = DU.Employee_ID
LEFT JOIN 
	Security.DHSUser DU_M ON DU_M.Id = PA.ModifiedBy
LEFT JOIN
    Lookups.UserDefinedAllergy UDA ON UDA.Id = PA.UserDefinedAllergy_Id
ORDER BY T.RowNum;
