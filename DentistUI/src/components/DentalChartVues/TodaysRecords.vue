
<template>
    <div class="control">
        <h2>Today's diagnoses</h2>
        <div class="list" 
        v-for="diagnosis in $parent.$data.diagnoses"
        v-bind:key="diagnosis.id">
            <div class="record" v-on:mouseover="onRecordHover($event,'red')" v-on:mouseleave="onRecordHover($event, 'rgb(19,18,18)')">
                <div class="name">
                    {{diagnosis.name}}
                </div>
                <div class="tooth">
                    {{diagnosis.tooth}}
                </div>
                <div class="surface">
                    {{diagnosis.surface}}
                </div>
            </div>
        </div>
        <h2>Today's procedures</h2>
        <div class="list" 
        v-for="procedure in $parent.$data.procedures"
        v-bind:key="procedure.id">
            <div class="name">
                {{procedure.name}}
            </div>
            <div class="tooth">
                {{procedure.tooth}}
            </div>
            <div class="surface">
                {{procedure.surface}}
            </div>
        </div>
        <div class="list">

        </div>
    </div>
</template>

<script>
export default {
    name: 'TodaysRecords',
    methods: {
        onRecordHover: function(event, color){
            var complement = color=="red"?"rgb(19, 18, 18)":"red";
            console.log(color)
            var localization = event.target.parentElement.getElementsByClassName("tooth")[0].innerText
            document.getElementById("t"+localization).children.forEach(child => {
                        if (child.style.fill == complement){
                            console.log("CHANGE COLOR TO"+ color)
                            child.style.fill = color
                        }
                    });
            console.log(document.getElementById("t"+localization))
      }
    },
}
</script>

<style scoped>
.control{
    display: flex;
    flex-direction: column;
    flex-wrap: wrap;
    justify-content: stretch;
}
div {
   /*  border: solid; */

    display: flex;
    flex-direction: column;
}
.list{
    flex-direction: row;
    font-size: 23px;
    flex-basis: 100%;
    justify-content: stretch;
}
.record{
    border-style: solid;
    justify-content: stretch;
    flex-direction: row;
    flex-basis: 100%;
}
.name{
    flex-basis: 60%;
}
.tooth{
    flex-basis: 10%;
}
.surface{
    flex-basis: 30%;
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
</style>