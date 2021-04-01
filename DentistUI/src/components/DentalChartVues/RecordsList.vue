
<template>
    <div class="control">
        <select class="viewSelector" v-model="viewSelected">
            <option value="all">All diagnoses</option>
            <option value="untreated">Untreated diagnoses</option>
            <option value="byEncounter">By encounter</option>
        </select>
        <div class="list1"
        v-for="encounter in encounters" 
        :key="encounter.id"
        >
            <div class="row" 
            v-on:click="onRecordClick('e',encounter)"
            >
                {{encounter.date.toLocaleDateString()}}
                <svg :id="'e'+encounter.id" :transform="encounter.expanded?'rotate(0)':'rotate(-90)'" version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px"
                width="32px" height="32px" viewBox="0 0 512 512" style="enable-background:new 0 0 512 512;" xml:space="preserve">
                <path d="M98.9,184.7l1.8,2.1l136,156.5c4.6,5.3,11.5,8.6,19.2,8.6c7.7,0,14.6-3.4,19.2-8.6L411,187.1l2.3-2.6
                c1.7-2.5,2.7-5.5,2.7-8.7c0-8.7-7.4-15.8-16.6-15.8v0H112.6v0c-9.2,0-16.6,7.1-16.6,15.8C96,179.1,97.1,182.2,98.9,184.7z"/>
                </svg>
            </div>
            <div class="list1"
            v-if="encounter.expanded"
            >
                <div class="record"
                v-for="diagnosis in encounter.diagnoses"
                :key="diagnosis.id"
                @click="onRecordClick('d',diagnosis)"
                v-on:mouseenter="$emit('mouseEnter',diagnosis.toothRecord.tooth.localization)" 
                v-on:mouseleave="$emit('mouseLeave',diagnosis.toothRecord.tooth.localization)"
                >
                <div class="row">
                    <div
                    v-if="!diagnosis.expanded"
                    >
                        {{diagnosis.classificationOfDisease.displayName}}
                        {{diagnosis.toothRecord.tooth.localization}}
                    </div>
                    <diagnosis-form 
                    :diagnosis="diagnosis"
                    :encounters="Encounters"
                    :teeth="ToothRecords"
                    v-if="diagnosis.expanded"/>
                    <svg :id="'d'+diagnosis.id" :transform="diagnosis.expanded?'rotate(0)':'rotate(-90)'" version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px"
                    width="32px" height="32px" viewBox="0 0 512 512" style="enable-background:new 0 0 512 512;" xml:space="preserve">
                    <path d="M98.9,184.7l1.8,2.1l136,156.5c4.6,5.3,11.5,8.6,19.2,8.6c7.7,0,14.6-3.4,19.2-8.6L411,187.1l2.3-2.6
                    c1.7-2.5,2.7-5.5,2.7-8.7c0-8.7-7.4-15.8-16.6-15.8v0H112.6v0c-9.2,0-16.6,7.1-16.6,15.8C96,179.1,97.1,182.2,98.9,184.7z"/>
                    </svg>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import HelperService from '@/services/HelperService'
import DiagnosisForm from './DiagnosisForm.vue'
export default {
  components: { DiagnosisForm },
    name: 'TodaysRecords',
    props:{
        Diagnoses: [],
        Encounters:[],
        ToothRecords:[]
    },
    methods: {
        onRecordHover: function(id, originalColor, resultColor){
            HelperService.colorTooth(id,originalColor, resultColor)
      },
      onRecordClick: function(prefix, record){
          record.expanded=!record.expanded
      }
    },
    watch:{
        Encounters: function(Encounters){
            /* eslint-disable no-debugger */
            debugger
            /* eslint-enable no-debugger */
            Encounters.map(e=>{
                e.expanded = true
                e.diagnoses.map(d=>d.expanded=false)    
            })
            this.encounters = Encounters
        }
    },
    data() {
        return {
            encounters:[],
            selectedDiagnosis:[]
        }
    },
}
</script>

<style scoped>
.control{
    display: flex;
    flex-direction: column;
    flex-wrap: nowrap;
    align-content: flex-start;
}
div {
   /*  border: solid; */

    display: flex;
    flex-direction: column;
}
.list1{
    flex-direction: column;
    font-size: 23px;
    flex-basis: 100%;
    justify-content: left;
    text-align: left;
    align-content: flex-start;
}
.record{
    flex-direction: column;
    justify-content:space-between;
    flex-basis: 100%;
    flex-wrap: nowrap;
}
.name{
    flex-basis: 60%;
}
.date{
    flex-basis: 30%;
}
.tooth{
    flex-basis: 10%;
}

img {
    height: 40px;
    width: 40px;
}

label {
    margin: 5px;
}

.header {
    font-weight: bold;
}

.tool {
    flex-direction: row;
}
.viewSelector{
    font-size: 30px;
    color: rgb(47, 47, 75);
    border-width: 0px;
}
.row{
    flex-direction: row;
}
</style>