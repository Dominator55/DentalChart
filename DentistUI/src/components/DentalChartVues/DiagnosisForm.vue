
<template>
  <div class="form" v-on:keyup.enter="save"> 
      <form>
         <select name="encounters" class="select" v-model="selectedEncounter.id" >
            <option
            class="option"       
            v-for="encounter in encounters" 
            :key="encounter.id"
            :value="encounter.id">
               {{encounter.date.toLocaleDateString()}}
            </option>
         </select>
         <br>
         <select name="classifications" class="select" >
            <option
            class="option"       
            v-for="classificationOfDisease in classificationsOfDisease" 
            :key="classificationOfDisease.id"
            :value="classificationOfDisease.id">
               {{classificationOfDisease.code+" "+classificationOfDisease.name}}
            </option>
         </select>
         <select name="teeth" class="select" v-model="selectedTooth.id" >
            <option
            class="option"       
            v-for="tooth in teeth" 
            :key="tooth.id"
            :value="tooth.id"
            >
               {{tooth.tooth.localization}}
            </option> 
         </select>                          
         <br>
         <textarea type="text" name="note" v-model="updateDiagnosis.note" class="multiline"/>
      </form>
      <button v-on:click="cancel">Cancel</button>
      <button v-on:click="save">Save</button>
      <button v-on:click="save">Treat</button>

  </div>
</template>

<script>
import DiagnosesService from '@/services/DiagnosesService'
export default {
  name: 'DiagnosisForm',
 props:{
    encounters: [],
    diagnosis: Object,
    teeth: []
 },
 data() {
     return {
        classificationsOfDisease: [],
        updateDiagnosis:{},
         selectedEncounter:{},
         selectedTooth: {}
     }
 },
 created() {
    this.open=false
 },
 methods: {
    cancel: function(){
       this.$emit('cancelEdit')
    },
    save: async function(){
       this.updateDiagnosis = await DiagnosesService.UpdateDiagnosis(this.updateDiagnosis, this.updateDiagnosis.id) 
       this.$emit('updateDiagnosis', this.updateDiagnosis)
    },

    delete: function(){}
 },
 mounted: async function(){
      var result = await DiagnosesService.GetClassificationsOfDisease()
      this.classificationsOfDisease = result.data
      this.selectedEncounter = this.diagnosis.encounter
      this.selectedTooth = this.diagnosis.toothRecord
      },
watch: { 
      diagnosis: function(newVal) { // watch i
            this.updateDiagnosis = newVal
            this.selectedEncounter = newVal.encounter
            this.selectedTooth = newVal.toothRecord
            
      }
 }
}
</script>
<style scoped>
.form{
   display: flex;
   font-size: 23px;
   flex-direction: column;
   flex-wrap: nowrap;
   flex-basis: 40%;
}
.select{
   font-size: 23px;
   flex-direction: row;
   flex-wrap: wrap;
   margin: 5px;
}
.multiline{
   font-size: 20px;
   flex-direction: row;
   flex-wrap: wrap;
   margin: 5px;

}
.option{
}
</style>