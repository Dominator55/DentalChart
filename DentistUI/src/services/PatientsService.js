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
        axios.put("https://localhost:44351/api/Patients/"+patient.id, patient)
        //TODO: not tested
    }

    static async CreatePatient(patient){
        axios.post("https://localhost:44351/api/Patients/", patient)
        //TODO: not tested
    }
}
