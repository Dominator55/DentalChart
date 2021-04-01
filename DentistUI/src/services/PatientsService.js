import axios from 'axios'
export default class PatientService {
    static async GetPatientsAsList(){
        return axios.get('https://localhost:44351/api/Patients')
    }
    
    static async GetPatientById(id){
        //TODO: FilterDate for different encounters
        var result = await axios.get('https://localhost:44351/api/Patients/'+id)

        result.data.encounters.forEach(element => {
            element.date = new Date(element.date)
        });
        return result
    }
    //eslint-disable-next-line
    static async UpdatePatient(patient){
        return axios.put('https://localhost:44351/api/Patients/'+patient.id,patient)
    }
    //eslint-disable-next-line
    static async CreatePatient(patient){
        //TODO: CreatePatient API call
    }

    static async CreateEncounter(encounter){
        encounter.date = encounter.date.toISOString()
        encounter.Patient = { id: encounter.Patient.id }
        var result = await axios.post('https://localhost:44351/api/Encounters', encounter)
        return result
        
    }
}
