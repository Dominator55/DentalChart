import axios from 'axios'
export default class DiagnosesService {
    static async GetPatientDiagnosesAsList(){
        //TODO: getDiagnoses API call
    }
    
    static async CreateDiagnosis(diagnosis){
        var result = await axios.post('https://localhost:44351/api/Diagnoses', diagnosis)
        return result
    }

    static async UpdateDiagnosis(diagnosis, id){
        return await axios.put('https://localhost:44351/api/Diagnoses/'+id, diagnosis)
    }

    static async DeleteDiagnosis(id){
        return await axios.delete('https://localhost:44351/api/Diagnoses/'+id)
    }

    static async GetClassificationOfDiseaseById(id){
        return axios.get('https://localhost:44351/api/ClassificationOfDiseases/'+id)
    }

    static async GetClassificationsOfDisease(){
        return await axios.get('https://localhost:44351/api/ClassificationOfDiseases/') 
    }
}
