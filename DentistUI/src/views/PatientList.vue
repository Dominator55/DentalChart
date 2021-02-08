<template>
  <div v-for="patient in patients" 
  v-bind:key="patient.id">
      <router-link :to="{ name: 'DentalChart', params: {id: patient.id}}"><label>{{patient.name}}</label></router-link>
      <router-view></router-view>
  </div>
</template>

<script>
// @ is an alias to /src'

import PatientService from '@/services/PatientService'

export default {
  name: 'Home',
  mounted: function(){
        console.log("mounted")
        PatientService.GetPatientsAsList().then(response=>{
          console.log(response.data)
          this.patients=response.data;
          }).catch(err=>{console.log(err)})
  },
  data() {
    return {
      patients: [],
      DentistName: "MUDr. Petr Machač",
      PatientName: "Jana Nováková"
    }
  },
}
</script>