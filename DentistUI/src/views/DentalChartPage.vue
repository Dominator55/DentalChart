<template>
    <Header>
        <div class="patientName">
            <img class="icon" src="../assets/person.png">
            <label>{{ this.Patient.name }}</label>
        </div>
        <div class="tabs">
            <button class="tabButton">Patient</button>
            <button class="tabButton">Dental Chart</button>
            <button class="tabButton">Report</button>
        </div>
        <div class="dentistName">
            <label>{{ Encounter.dentistName }}</label>
        </div>
    </Header>
    <div class="body">
        <nav>
            <encounter-picker :SelectedEncounterDate="Encounter.date" />
            <tool-picker></tool-picker>
        </nav>
        <div class="chart">
            <dental-chart :toothRecords="Patient.toothRecords" :toolSelected="toolSelected"></dental-chart>
        </div>
        <div class="nav">
            <todays-records/>
            <button class="tabButton" v-on:click="save">Save</button>
        </div>
    </div>
</template>

<script>
import DentalChart from '../components/DentalChartVues/DentalChart.vue'
import EncounterPicker from '../components/DentalChartVues/EncounterPicker.vue'
import ToolPicker from '../components/DentalChartVues/ToolPicker.vue'
import PatientService from '@/services/PatientsService'
import ToothRecordsService from '@/services/ToothRecordsService'
import TodaysRecords from '../components/DentalChartVues/TodaysRecords.vue'

export default {
    name: 'DentalChartPage',
    components: {
        DentalChart,
        EncounterPicker,
        ToolPicker,
        TodaysRecords
    },
    data() {
         return {
            Patient:{},
            Encounter: {
                date: new Date(),
                dentistName: "MUDr. Petr Machač",
                patientName: "Jana Nováková",
            },
            toolSelected: {
                color: "green"
            },
            diagnoses: [],
            procedures: []
        }

    },
    mounted: function(){
        console.log("mounted")
        PatientService.GetPatientById(this.$route.params.id).then(response=>{
            this.Patient = response.data
            }).catch(err=>{console.log(err)})
    },
    methods:{
        save: function(){
            document.getElementsByClassName("changed").forEach(element => {
                element.class=""
                var id = element.id.split('t')[1]
                var toothRecord = this.Patient.toothRecords.filter(t=>t.tooth.localization==id)[0]
                console.log(toothRecord)
                toothRecord.state=1;
                console.log(toothRecord)
                ToothRecordsService.UpdateToothRecord(toothRecord).then(diagnosis => {
                   console.log("pushing"+diagnosis)
                   this.diagnoses.push(diagnosis)
                })
            });
        }
    }
}
</script>

<style>
h2 {
    color: rgb(47, 47, 75);
}

.patientName {
    margin: 10px;
    text-align: left;
    flex: 1;
}

.dentistName {
    margin: 10px;
    flex: 1;
    text-align: right;
}

.tabs {
    text-align: center;
    flex: 3;
}

header {
    display: flex;
}

.body {
    display: flex;
    flex-wrap: nowrap;
    flex-direction: row;
    /* border: solid; */
    flex-basis: 100%;
}

.tabButton {
    background: linear-gradient(to bottom, #ffffff 5%, #f6f6f6 100%);
    background-color: #ffffff;
    border-radius: 20px;
    border: 2px solid #dcdcdc;
    cursor: pointer;
    color: #666666;
    font-family: Arial;
    font-size: 28px;
    font-weight: bold;
    padding: 20px 40px;
    text-decoration: none;
    margin: 10px;
}

.icon {
    width: 50px;
    height: 50px;
}

header {
    flex-basis: 100%;
}

label {
    font-size: 30px;
}

nav {
    margin: 20px;
    /* border:solid; */
    flex: 1;
    display: flex;
    flex-direction: column;
}

.chart {
    flex: 6;
}
</style>
