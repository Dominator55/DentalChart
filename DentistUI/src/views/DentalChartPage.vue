<template>
  <Header>
    <div class="patientName">
      <img class="icon" src="../assets/person.png" />
      <label>{{ this.Patient.name }}</label>
    </div>
    <process></process>
    <!-- <div class="tabs">
      <button class="tabButton">Patient</button>
      <button class="tabButton">Dental Chart</button>
      <button class="tabButton">Report</button>
    </div> -->
    <div class="dentistName">
      <label>{{ dentistName }}</label>
    </div>
  </Header>
  <div class="body">
    <nav>
      <encounter-picker
        :SelectedEncounterDate="SelectedEncounter.date"
        :encounters="Patient.encounters"
        v-on:encounterChange="selectedEncounterChange"
      />
      <tool-picker
        :toolSelected="toolSelected"
        v-on:toolChanged="toolChanged"
      />
    </nav>
    <div class="chart">
      <dental-chart
        :toothRecords="Patient.toothRecords"
        :toolSelected="toolSelected"
        :diagnoses="diagnoses"
        v-on:mouseEnter="mouseEnter"
        v-on:mouseLeave="mouseLeave"
      ></dental-chart>
    </div>
    <div class="nav">
      <diagnosis-form
        v-if="formDiagnosis != null"
        :diagnosis="formDiagnosis"
        :teeth="
          Patient.toothRecords.sort((a, b) =>     //sorted tooth records to display in select 
            parseInt(a.tooth.localization) > parseInt(b.tooth.localization)
              ? 1
              : -1
          )
        "
        :encounters="Patient.encounters"
        v-on:updateDiagnosis="updateDiagnosis"
        v-on:cancelEdit="cancelEdit"
      />
      <todays-records
        :Diagnoses="diagnoses"
        :Encounters="Patient.encounters"
        :ToothRecords="Patient.toothRecords"
        v-on:mouseEnter="mouseEnter"
        v-on:mouseLeave="mouseLeave"
      />
    </div>
  </div>
</template>

<script>
import DentalChart from '../components/DentalChartVues/DentalChart.vue'
import EncounterPicker from '../components/DentalChartVues/EncounterPicker.vue'
import ToolPicker from '../components/DentalChartVues/ToolPicker.vue'
import PatientService from '@/services/PatientsService'
import DiagnosesService from '@/services/DiagnosesService'
import ProcedureRecordsService from '@/services/ProcedureRecordsService'
import ToothRecordsService from '@/services/ToothRecordsService'
import TodaysRecords from '../components/DentalChartVues/RecordsList.vue'
import HelperService from '@/services/HelperService'
import DiagnosisForm from '../components/DentalChartVues/DiagnosisForm.vue'
import Process from '@/components/DentalChartVues/Process'

export default {
  name: 'DentalChartPage',
  components: {
    DentalChart,
    EncounterPicker,
    ToolPicker,
    TodaysRecords,
    DiagnosisForm,
    Process
  },
  data() {
    return {
      Patient: {},
      dentistName: 'MUDr. Petr Machač',
      SelectedEncounter: {
          date: new Date(),
          Patient: this.Patient,
          diagnoses: [],
        },
      toolSelected: null,
      diagnoses: [],
      formDiagnosis: null,
      procedureRecords: [],
    }
  },
  mounted: function () {
    PatientService.GetPatientById(this.$route.params.id)
      .then((response) => {
        this.Patient = response.data
        let encounters = response.data.encounters
        this.diagnoses = HelperService.unpackDiagnosisFromEncounters(encounters)  //get all diagnoses in encounters
        this.diagnoses.forEach(diagnosis => {
            HelperService.colorTooth(diagnosis.toothRecord.tooth.localization, 'rgb(255, 255, 255)', 'grey')
        })
        let today = new Date()
        var mockEncounter =  {
          date: new Date(),
          Patient: this.Patient,
          diagnoses: [],
          procedureRecords: [],
        }
        var encounter =  response.data.encounters.find( 
          (e) => e.date.toDateString() == today.toDateString()
        ) //finds encounter on this day if existent
        this.SelectedEncounter = encounter==null ? mockEncounter : encounter
      })
      .catch((err) => {
        console.log(err)
      })
  },
  methods: {
    updateDiagnosis: function(diagnosis){
      this.diagnoses[this.diagnoses.findIndex(d=>d.id == diagnosis.data.id)] = diagnosis.data
    },
    toolChanged: function(tool){
      this.toolSelected = tool
    },
    selectedEncounterChange: function(id){
      this.SelectedEncounter = this.Patient.encounters.find(e=>e.id==id)
      var encounters = this.Patient.encounters.filter(e=>e.date <= this.SelectedEncounter.date)
      this.diagnoses= HelperService.unpackDiagnosisFromEncounters(encounters)
      this.diagnoses= HelperService.unpackProcedureRecordsFromEncounters(encounters)
    },

    cancelEdit: function(){     //for formDiagnosis cancelEdit event
      this.formDiagnosis = null
    },

    mouseEnter: function(localization){   //for event of mouseenter on tooth
      HelperService.colorTooth(localization, 'rgb(0, 0, 0)','red')
    },

    mouseLeave: function(localization){   //for event of mouseleave on tooth
      HelperService.colorTooth(localization, 'red', 'rgb(0, 0, 0)')
    },

    onClick: async function (click) {   //main function servicing all the tool clicks
      var parent = click.target.parentElement
      var localization = parent.id.split('t')[1]
      var result = null
      var diagnosis = null
      var procedure = null
      var Encounter = null
      var Patient = null
      var date = null
      switch (this.toolSelected) {
        case 'Decay':
          Encounter = this.SelectedEncounter
          Patient = this.Patient
          if (typeof Encounter.id == 'undefined' || Encounter.id == null) {   //if encounter is non existent, create one
            date = new Date()
            date.setUTCHours(0, 0, 0, 0)    //only date needed
            Encounter = {
              date: date,
              Patient: this.Patient,
            }
            result = await PatientService.CreateEncounter(Encounter)
            this.SelectedEncounter = result.data  //switch selected encounter with the placeholder
          }
          diagnosis = {
            ClassificationOfDisease: { id: 1 },
            Encounter: { 
                id: Encounter.id,
                Patient: { id: Patient.id }
            },
            ToothRecord: { 
                Tooth: {
                    localization: localization
                }
            },
          };
          result = await DiagnosesService.CreateDiagnosis(diagnosis)
          if (result.status >= 200 && result.status < 300) {
            Encounter.diagnoses.push(result.data)
            this.SelectedEncounter = Encounter
            this.diagnoses.push(result.data)
            HelperService.colorTooth(localization, 'rgb(255, 255, 255)', 'grey')
          }
          break
        case 'Select':
          /* eslint-disable no-debugger */
          debugger
          /* eslint-enable no-debugger */
          diagnosis = this.diagnoses.find(d=>d.toothRecord.tooth.localization==localization)
          if(diagnosis!=null){
            this.formDiagnosis=diagnosis
          } 
          break
        case 'WhiteFilling':
          Encounter = this.SelectedEncounter
          Patient = this.Patient
          if (typeof Encounter.id == 'undefined' || Encounter.id == null) {   //if encounter is non existent, create one
            date = new Date()
            date.setUTCHours(0, 0, 0, 0)    //only date needed
            Encounter = {
              date: date,
              Patient: this.Patient,
            }
            result = await PatientService.CreateEncounter(Encounter)
            this.SelectedEncounter = result.data  //switch selected encounter with the placeholder
          }
          procedure = {
            Procedure: { id: 1 },
            Encounter: { 
                id: Encounter.id,
                Patient: { id: Patient.id }
            },
            ToothRecord: { 
                Tooth: {
                    localization: localization
                }
            },
          };
          /* eslint-disable no-debugger */
          debugger
          /* eslint-enable no-debugger */
          result = await ProcedureRecordsService.CreateProcedureRecord(procedure)
          if (result.status >= 200 && result.status < 300) {
            Encounter.procedureRecords.push(result.data)
            this.SelectedEncounter = Encounter
            this.procedureRecords.push(result.data)
            HelperService.colorTooth(localization, 'rgb(255, 255, 255)', 'grey')
          }
          break
      }
    },
  },
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
