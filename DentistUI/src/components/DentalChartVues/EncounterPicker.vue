
<template>
  <div class="encounterPicker"> 
        <button v-on:click="showWindow()">
            <img src=" ">
            <label>{{ SelectedEncounterDate.toLocaleDateString() }}</label>      
        </button>
        <div  v-if="open" class="window">
            <div 
            v-for="encounter in encounters"
            :key="encounter.id"
            class="encounterButton"
            v-on:click="$emit('encounterChange', encounter.id)"
            >
            <div>{{encounter.date.toLocaleDateString()}}</div>
            </div>
        </div>
  </div>
</template>

<script>
export default {
  name: 'EncounterPicker',
 props:{
     SelectedEncounterDate: Date,
     encounters: []
 },
 data() {
     return {
        open: Boolean
     }
 },
 created() {
    this.open=false
 },
 methods: {
    showWindow: function(){this.open=!this.open},
 },
}
</script>
<style scoped>
.encounterPicker{
    text-align: center;
}
button{
    box-shadow:inset 0px 1px 0px 0px #ffffff;
    background:linear-gradient(to bottom, #ffffff 5%, #f6f6f6 100%);
    background-color:#ffffff;
    border-radius:6px;
    border:1px solid #dcdcdc;
    display:inline-block;
    cursor:pointer;
    color:#666666;
    font-family:Arial;
    font-size:25px;
    font-weight:bold;
    padding:6px 24px;
    text-decoration:none;
    text-shadow:0px 1px 0px #ffffff;
}
.window {
  position: absolute;
  border-radius: 4pt 4pt 0 0;
  border: solid;
  background-color: white;
  display: flex;
}
.encounterButton{
    font-size: 25px;
    border: solid;
    margin: 5px;
    padding: 5px;
}
</style>