-- **********************************************************************************************************************************
-- SearchPatientAllergies.sql
-- 1.  Search for indicated PatientAllergy, based on key and active status.

-- Change log:
-- 2023.07.31 - Created from the following postgres file
--  New script, not in postgres

-- ***********************************************************************************************************************************

;WITH SearchResults(PatientAllergy_Key, AllergyTypeId)
AS
(
    SELECT DISTINCT
        PA.PatientAllergy_Key,
	    CAST(CASE WHEN PA.UserDefinedAllergy_Id IS NOT NULL THEN 4
	        WHEN PA.ScreeningIdentifierType = 1 THEN 1
			WHEN PA.ScreeningIdentifierType = 2 THEN 5
			WHEN PA.ScreeningIdentifierType = 3 THEN 2
			ELSE 4 END AS int) AS AllergyTypeId
    FROM Patient.PatientAllergy PA
    INNER JOIN
        Patient.Patient P ON P.Id = PA.Patient_Id
	INNER JOIN
	    Common.Party PAR ON P.Id = PAR.Id
    WHERE
        1 =
        CASE WHEN @PatientKeysAsCsv IS NULL OR LEN(@PatientKeysAsCsv) = 0 THEN 0
            WHEN PAR.Party_Key IN (SELECT Value FROM STRING_SPLIT(@PatientKeysAsCsv, ',')) THEN 1
        ELSE 0
        END
    AND
	    1 =
        CASE WHEN @IsRemoved IS NULL THEN 1
            WHEN @IsRemoved = 1 AND PA.RecStatus = 0 THEN 1
            WHEN @IsRemoved = 0 AND PA.RecStatus > 0 THEN 1
        ELSE 0
        END
	AND
        1 = 
        CASE WHEN @Status IS NULL THEN 1
		    WHEN LEN(@Status) = 0 THEN 0
            WHEN @Status = 1 THEN 1
        ELSE 0
        END
),
PagedSearchResults(PatientAllergy_Key)
AS
(
    SELECT
        PA.PatientAllergy_Key
    FROM SearchResults T
        INNER JOIN Patient.PatientAllergy PA ON T.PatientAllergy_Key = PA.PatientAllergy_Key
    @PagedRequest
),
SearchResultCount(TotalCount)
AS
(
    SELECT COUNT(*)
    FROM SearchResults
)
SELECT
(
    SELECT STUFF((SELECT ',' + CAST(T.PatientAllergy_Key as varchar(max))
    FROM PagedSearchResults T
    WHERE T.PatientAllergy_Key IS NOT NULL
    FOR XML PATH('')),1,1,'')
) As KeysAsCsv, -- This will be mapped to the entity model property KeysAsCsv.
SRC.TotalCount
FROM SearchResultCount SRC;
