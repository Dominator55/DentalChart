import axios from 'axios'
export default class PatientService {
    static async GetPatientsAsList(){
        return axios.get("https://localhost:44351/api/Patients")
    }
    
    static async GetPatientById(id){
        //TODO: FilterDate for different encounters
        return axios.get("https://localhost:44351/api/Patients/"+id)
    }

    static async UpdatePatient(patient){
        //TODO: UpdatePatient API call
    }

    static async CreatePatient(patient){
        //TODO: CreatePatient API call
    }
}
