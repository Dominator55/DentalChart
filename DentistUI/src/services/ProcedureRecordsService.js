import axios from 'axios'
export default class ProcedureRecordsService {
    static async GetPatientProcedureRecordsAsList(){
        //TODO: getProcedureRecords API call
    }
    
    static async CreateProcedureRecord(procedureRecord){
        var result = await axios.post('https://localhost:44351/api/ProcedureRecords', procedureRecord)
        return result
    }

    static async UpdateProcedureRecord(procedureRecord, id){
        return await axios.put('https://localhost:44351/api/ProcedureRecords/'+id, procedureRecord)
    }

    static async DeleteProcedureRecord(id){
        return await axios.delete('https://localhost:44351/api/ProcedureRecords/'+id)
    }

    static async GetProcedureById(id){
        return axios.get('https://localhost:44351/api/Procedures/'+id)
    }

    static async GetProcedures(){
        return await axios.get('https://localhost:44351/api/Procedures/') 
    }
}
