import axios from 'axios'
const MAX_SAFE_INTEGER = 9007199254740991

export default class ToothRecordService {
    static async UpdateToothRecord(toothRecord){
        axios.put("https://localhost:44351/api/ToothRecords/"+toothRecord.id, toothRecord)

        var diagnosis = {
            name: "decay",
            tooth: toothRecord.tooth.localization,
        }
        console.log("returning " + diagnosis)
        return diagnosis
    }
}
