<template>
  <div class="header">
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
  </div>
  <div class="body">
    <nav>
      <encounter-picker
        :SelectedEncounterDate="SelectedEncounter.date"
        :encounters="Encounters"
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
        :procedureRecords="procedureRecords"
        v-on:mouseEnter="mouseEnter"
        v-on:mouseLeave="mouseLeave"
      ></dental-chart>
    </div>
    <div class="nav">
      <todays-records
        :Encounters="Encounters"
        :ToothRecords="
          Patient.toothRecords == null
            ? null
            : Patient.toothRecords.sort((
                a,
                b //sorted tooth records to display in select
              ) =>
                parseInt(a.tooth.localization) > parseInt(b.tooth.localization)
                  ? 1
                  : -1
              )
        "
        :SelectedRecord="formRecord"
        v-on:mouseEnter="mouseEnter"
        v-on:mouseLeave="mouseLeave"
        v-on:updateDiagnosis="updateDiagnosis"
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
import Process from '@/components/DentalChartVues/Process'
import {ClassificationsOfDiseaseEnum, ProceduresEnum} from '@/services/Enums'

export default {
  name: 'DentalChartPage',
  components: {
    DentalChart,
    EncounterPicker,
    ToolPicker,
    TodaysRecords,
    Process
  },
  data() {
    return {
      Patient: {},
      dentistName: 'MUDr. Michal Novák',
      SelectedEncounter: {
          date: new Date(),
          Patient: this.Patient,
          diagnoses: [],
        },
      toolSelected: null,
      Encounters: [],
      diagnoses: [],
      formRecord: null,
      procedureRecords: [],
    }
  },
  mounted: function () {
    PatientService.GetPatientById(this.$route.params.id)
      .then((response) => {
        this.Patient = response.data
        this.Encounters = response.data.encounters
        this.diagnoses = HelperService.unpackDiagnosisFromEncounters(this.Encounters)  //get all diagnoses in encounters
        this.procedureRecords = HelperService.unpackProcedureRecordsFromEncounters(this.Encounters)
        this.diagnoses.forEach(diagnosis => {
          HelperService.visualizeRecord(diagnosis)
        })
        this.procedureRecords.forEach(procedureRecord=>{
          HelperService.visualizeRecord(procedureRecord)
        })
        let today = new Date()
        var mockEncounter =  {
          date: new Date(),
          Patient: this.Patient,
          diagnoses: [],
          procedureRecords: [],
        }
        this.Encounters.push(mockEncounter)
        var encounter =  this.Encounters.find( 
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
      /* eslint-disable no-debugger */
      debugger
      /* eslint-enable no-debugger */
      this.SelectedEncounter.diagnoses[this.SelectedEncounter.diagnoses.findIndex(d=>d.id == diagnosis.id)] = diagnosis
      this.Encounters[this.Encounters.findIndex(e=>e.id==this.SelectedEncounter.id)] = this.SelectedEncounter
      this.Encounters.push(this.Encounters.pop())
      this.diagnoses = HelperService.unpackDiagnosisFromEncounters(this.Encounters)
    },
    toolChanged: function(tool){
      this.toolSelected = tool
    },
    selectedEncounterChange: function(id){
      this.SelectedEncounter = this.Encounters.find(e=>e.id==id)
      this.Encounters = this.Encounters.filter(e=>e.date <= this.SelectedEncounter.date)
      this.diagnoses= HelperService.unpackDiagnosisFromEncounters(this.Encounters)
      this.diagnoses= HelperService.unpackProcedureRecordsFromEncounters(this.Encounters)
    },

    cancelEdit: function(){     //for formRecord cancelEdit event
      this.formRecord = null
    },

    mouseEnter: function(localization){   //for event of mouseenter on tooth
      HelperService.selectTooth(localization)
    },

    mouseLeave: function(localization){   //for event of mouseleave on tooth
      HelperService.unselectTooth(localization)
    },

    addDiagnosis: async function(diagnosis){
      var result = await DiagnosesService.CreateDiagnosis(diagnosis)
      if (result.status >= 200 && result.status < 300) {
        this.SelectedEncounter.diagnoses.push(result.data)
        this.Encounters[this.Encounters.findIndex(e=>e.id==this.SelectedEncounter.id)] = this.SelectedEncounter
        this.diagnoses.push(result.data)
        HelperService.visualizeRecord(result.data)
      }
    },

    removeDiagnosis: async function(diagnosis){
      /* eslint-disable no-debugger */
      debugger
      /* eslint-enable no-debugger */
      var result = await DiagnosesService.DeleteDiagnosis(diagnosis.id)
      if (result.status >= 200 && result.status < 300) {
        /* eslint-disable no-debugger */
        debugger
        /* eslint-enable no-debugger */
        var localization = diagnosis.toothRecord.tooth.localization
        this.SelectedEncounter.diagnoses = this.SelectedEncounter.diagnoses.filter(d=>d.id != diagnosis.id)
        this.Encounters[this.Encounters.findIndex(e=>e.id==this.SelectedEncounter.id)] = this.SelectedEncounter
        this.diagnoses = this.diagnoses.filter(d=>d.id != diagnosis.id)
        var visualisationRecord  = this.getLastRecord(localization)
        if(visualisationRecord!= null){
          HelperService.visualizeRecord(visualisationRecord)
        }
        else{
          HelperService.clearVisualization(localization)
        }
      }
    },
    
    addProcedureRecord: async function(procedureRecord){
      /* eslint-disable no-debugger */
      debugger
      /* eslint-enable no-debugger */
      var result = await ProcedureRecordsService.CreateProcedureRecord(procedureRecord)
      if (result.status >= 200 && result.status < 300) {
        this.SelectedEncounter.procedureRecords.push(result.data)
        this.Encounters[this.Encounters.findIndex(e=>e.id==this.SelectedEncounter.id)] = this.SelectedEncounter
        this.procedureRecords.push(result.data)
        HelperService.visualizeRecord(result.data)
      }
    },

    removeProcedureRecord: async function(procedureRecord){
      var result = await ProcedureRecordsService.DeleteProcedureRecord(procedureRecord.id)
      if (result.status >= 200 && result.status < 300) {
        var localization = procedureRecord.toothRecord.tooth.localization
        this.SelectedEncounter.procedureRecords = this.SelectedEncounter.procedureRecords.filter(d=>d.id != procedureRecord.id)
        this.Encounters[this.Encounters.findIndex(e=>e.id==this.SelectedEncounter.id)] = this.SelectedEncounter
        this.procedureRecords = this.procedureRecords.filter(d=>d.id != procedureRecord.id)
        var visualisationRecord  = this.getLastRecord(localization)
        if(visualisationRecord!= null){
          HelperService.visualizeRecord(visualisationRecord)
        }
        else{
          HelperService.clearVisualization(localization)
        }
      }
    },

    getLastRecord: function(localization){
      var deleteDiagnoses = this.diagnoses.filter(d=>d.toothRecord.tooth.localization==localization) 
      var deleteProcedureRecords =  this.procedureRecords.filter(pr=>pr.toothRecord.tooth.localization==localization)
      return deleteProcedureRecords.length!=0 ? deleteProcedureRecords[deleteProcedureRecords.length-1] : deleteDiagnoses[deleteDiagnoses.length-1]
    },

    getTodaysEncounter: async function(){  
      var Encounter = this.SelectedEncounter
      if (typeof Encounter.id == 'undefined' || Encounter.id == null) {   //if encounter is non existent, create one
        var date = new Date()
        date.setUTCHours(0, 0, 0, 0)    //only date needed
        Encounter = {
          date: date,
          Patient: this.Patient
        }
        var result = await PatientService.CreateEncounter(Encounter)
        this.SelectedEncounter = result.data  //switch selected encounter with the placeholder
        this.Encounters.pop() //remove placeholder form encounter array
        this.Encounters.push(result.data) //add newly created encounter to encounter array
        return result.data
      }
      else{   //if encounter u
        return Encounter
      }
    },

    createDiagnosisObject: async function(classificationOfDiseaseId, localization){
      var Encounter = await this.getTodaysEncounter()
      return {
        ClassificationOfDisease: { id: classificationOfDiseaseId },
        Encounter: { 
            id: Encounter.id,
            Patient: { id: this.Patient.id }
        },
        ToothRecord: { 
            Tooth: {
                localization: localization
            }
        },
      };
    },
    
    createProcedureRecordObject: async function(procedureId, localization){
      var Encounter = await this.getTodaysEncounter()
      return {
        Procedure: { id: procedureId },
        Encounter: { 
            id: Encounter.id,
            Patient: { id: this.Patient.id }
        },
        ToothRecord: { 
            Tooth: {
                localization: localization
            }
        },
      };
    },
    
    onClick: async function (click) {   //main function servicing all the tool clicks
      var parent = click.target.parentElement
      var localization = parent.id.split('t')[1]
      var result = null
      var diagnosis = null
      var procedureRecord = null
      var Encounter = null
      var Patient = null
      switch (this.toolSelected) {
        case 'Decay':
          Encounter = await this.getTodaysEncounter()
          Patient = this.Patient
          diagnosis = await this.createDiagnosisObject(ClassificationsOfDiseaseEnum.Decay, localization)
          await this.addDiagnosis(diagnosis)
          break
        case 'WhiteFilling':
          Encounter = await this.getTodaysEncounter()
          procedureRecord = await this.createProcedureRecordObject(ProceduresEnum.WhiteFilling, localization)
          await this.addProcedureRecord(procedureRecord)
          break
        case 'Select':
          var record = this.getLastRecord(localization)
          if(record!=null){
            this.formRecord=record
          } 
          break
        case 'Delete':
          var deleteRecord = this.getLastRecord(localization)
          if(deleteRecord==null){
            break
          }
          if(deleteRecord.procedure==null){
            result = confirm("You're about to delete diagnosis " + deleteRecord.classificationOfDisease.displayName + " " + localization)
            if(result){
              await this.removeDiagnosis(deleteRecord) 
            }
         }
          else{
            result = confirm("You're about to delete procedure record " + deleteRecord.procedure.displayName + " " + localization)
            if(result){
              await this.removeProcedureRecord(deleteRecord) 
            }
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

.header {
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
