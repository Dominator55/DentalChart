
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
         <select name="procedures" class="select" >
            <option
            class="option"       
            v-for="procedure in procedures" 
            :key="procedure.id"
            :value="procedure.id">
               {{procedure.code+" "+procedure.displayName}}
            </option>
         </select>
         <select name="teeth" class="select" v-model="selectedTooth.id" >
            <option
            class="option"       
            v-for="toothRecord in teeth" 
            :key="toothRecord.id"
            :value="toothRecord.id"
            >
               {{toothRecord.tooth.localization}}
            </option> 
         </select>                          
         <br>
      </form>
      <button v-on:click="cancel">Cancel</button>
      <button v-on:click="save">Save</button>
      <button v-on:click="save">Treat</button>

  </div>
</template>

<script>
import ProcedureRecordsService from '@/services/ProcedureRecordsService'
export default {
  name: 'ProcedureRecordForm',
 props:{
    encounters: [],
    procedureRecord: Object,
    teeth: []
 },
 data() {
     return {
         procedures: [],
         updateProcedureRecord:{},
         selectedEncounter:{},
         selectedTooth: {}
     }
 },
 methods: {
    cancel: function(){
       this.$emit('cancelEdit')
    },
    save: async function(){
       /* eslint-disable no-debugger */
       debugger
       /* eslint-enable no-debugger */
       var result = await ProcedureRecordsService.UpdateProcedureRecord(this.updateProcedureRecord, this.updateProcedureRecord.id)
       this.updateProcedureRecord = result.data
       this.$emit('updateProcedureRecord', this.updateProcedureRecord)
    },

    delete: function(){}
 },
 mounted: async function(){
      var result = await ProcedureRecordsService.GetProcedures()
      this.procedures = result.data
      this.selectedEncounter = this.procedureRecord.encounter
      this.selectedTooth = this.procedureRecord.toothRecord
      this.updateProcedureRecord=this.procedureRecord
      },
watch: { 
      procedureRecord: function(newVal) { // watch i
            this.updateProcedureRecord = newVal
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