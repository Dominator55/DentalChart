// Generated by https://quicktype.io

export interface Patient {
    id:                       number;
    nationalId:               string;
    name:                     string;
    address:                  string;
    email:                    string;
    phone:                    string;
    age:                      number;
    healthInsuranceCompany:   number;
    personalAnamnesis:        string;
    allergies:                string;
    pharmacologicalAnamnesis: string;
    smoker:                   boolean;
    smokingDetail:            string;
    alcohol:                  boolean;
    alcoholDetail:            string;
    drugs:                    boolean;
    drugsDetail:              boolean;
    encounters:               Encounter[];
    toothRecords:             ToothRecord[];
}

export interface Encounter {
    id:         number;
    date:       string;
    reportText: string;
    diagnoses:  Diagnosis[];
}

export interface Diagnosis {
    id:                      number;
    classificationOfDisease: ClassificationOfDisease;
    state:                   number;
    toothSurfaces:           ToothSurface[];
}

export interface ClassificationOfDisease {
    id:   number;
    code: string;
    name: string;
}

export interface ToothSurface {
    toothSurfaceRecordId: number;
    diagnosisId:          number;
}

export interface ToothRecord {
    id:            number;
    tooth:         Tooth;
    state:         number;
    toothSurfaces: ToothRecordToothSurface[];
    diagnoses:     Diagnosis[];
}

export interface Tooth {
    id:                number;
    localization:      string;
    deciduous:         boolean;
    toothToothSurface: ToothToothSurface[];
}

export interface ToothToothSurface {
    toothId:   number;
    surfaceId: number;
    surface:   Surface;
}

export interface Surface {
    id:                number;
    name:              string;
    toothToothSurface: null[];
}

export interface ToothRecordToothSurface {
    id:           number;
    toothSurface: Surface;
    state:        number;
    diagnoses:    ToothSurface[];
}