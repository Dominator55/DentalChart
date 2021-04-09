import {VisualisationEnum} from "./Enums";

export default class HelperService {
    static visualizeRecord(record){
        var localization = record.toothRecord.tooth.localization
        if(record.procedure==null){
            switch(record.classificationOfDisease.id){
                case 1:
                    this.colorTooth(localization, VisualisationEnum.Decay)
                    break
            }
        }
        else{
            switch(record.procedure.id){
                case 1:
                    this.colorTooth(localization, VisualisationEnum.WhiteFilling)
                    break
            }
        }
    }
    static clearVisualization(localization){
        document.getElementById('t' + localization).children.forEach(child => {
            if (child.style.fill != VisualisationEnum.SelectedTooth && child.style.fill != VisualisationEnum.NonSelectedTooth) {
                child.style.fill = VisualisationEnum.None
            }
        })
    }
    static colorTooth(localization, resultVisualization) {
        try{
            document.getElementById('t' + localization).children.forEach(child => {        //get tooth of the localitazation
                if (child.style.fill != VisualisationEnum.SelectedTooth && child.style.fill != VisualisationEnum.NonSelectedTooth) {
                    child.style.fill = resultVisualization;
                }
            })
            var records = document.querySelectorAll('[tooth="' + localization + '"]')
            records.forEach(record => {
                record.style.borderColor = resultVisualization
            })
        }
        catch{
            null
        }
    }

    static selectTooth(localization){
        document.getElementById('t' + localization).children.forEach(child => {        //get tooth of the localitazation
            if (child.style.fill == VisualisationEnum.NonSelectedTooth) {
                child.style.fill = VisualisationEnum.SelectedTooth;
            }
        })
    }

    static unselectTooth(localization){
        document.getElementById('t' + localization).children.forEach(child => {        //get tooth of the localitazation
            if (child.style.fill == VisualisationEnum.SelectedTooth) {
                child.style.fill = VisualisationEnum.NonSelectedTooth;
            }
        })
    }
    static unpackDiagnosisFromEncounters(encounters, diagnoses = []) {
        encounters.forEach(encounter => {
            encounter.diagnoses.forEach(diagnosis => diagnosis.encounter = { id: encounter.id, date: encounter.date })
            diagnoses = [...new Set([...diagnoses, ...encounter.diagnoses])]
        })
        return diagnoses
    }

    static unpackProcedureRecordsFromEncounters(encounters, procedureRecords = []) {
        encounters.forEach(encounter => {
            encounter.procedureRecords.forEach(procedureRecord => procedureRecord.encounter = { id: encounter.id, date: encounter.date })
            procedureRecords = [...new Set([...procedureRecords, ...encounter.procedureRecords])]
        })
        return procedureRecords
    }
}