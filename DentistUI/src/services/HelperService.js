export default class HelperService {
    static colorTooth(localization, originalColor, resultColor){            
        document.getElementById('t'+localization).children.forEach(child=> {        //get tooth of the localitazation
            if (child.style.fill == originalColor) {
                child.style.fill = resultColor;
            }
        })
        var records = document.querySelectorAll('[tooth="'+localization+'"]')
        records.forEach(record=>{
            record.style.borderColor = resultColor
        })
    }

    static unpackDiagnosisFromEncounters(encounters, diagnoses = []){
        encounters.forEach(encounter => {
            encounter.diagnoses.forEach(diagnosis=>diagnosis.encounter = {id:encounter.id, date:encounter.date}) 
             diagnoses = [...new Set([...diagnoses, ...encounter.diagnoses])]
          })
        return diagnoses
    }

    static unpackProcedureRecordsFromEncounters(encounters, procedureRecords = []){
        encounters.forEach(encounter => {
            encounter.procedureRecords.forEach(procedureRecord=>procedureRecord.encounter = {id:encounter.id, date:encounter.date}) 
            procedureRecords = [...new Set([...procedureRecords, ...encounter.procedureRecords])]
          })
        return procedureRecords
    }
}