
<template>
    <div>
        <select class="viewSelector">
            <option>
            <label>Tools</label>
            </option>
        </select>
        <div class="tool" v-on:click="$emit('toolChanged', 'Select')" v-bind:class="getClass('Select')">
            <img src="../../assets/select.png">
            <label>Select</label>
        </div>
        <div class="tool" v-on:click="$emit('toolChanged', 'Delete')" v-bind:class="getClass('Delete')">
            <img src="../../assets/delete.png">
            <label>Delete</label>
        </div>
        <div class="tool" v-on:click="$emit('toolChanged', 'Decay')" v-bind:class="getClass('Decay')">
            <img src="../../assets/toothDecay.png">
            <label>Decay</label>
        </div>
        <div class="tool" v-on:click="$emit('toolChanged', 'Treat')" v-bind:class="getClass('Treat')">
            <img src="../../assets/tools.png">
            <label>Treat</label>
        </div>
        <div class="tool" v-on:click="$emit('toolChanged', 'Diagnose')" v-bind:class="getClass('Diagnose')">
            <img src="../../assets/Diagnosis.png">
            <label>Diagnose</label>
        </div>
        <div class="tool" v-on:click="$emit('toolChanged', 'WhiteFilling')" v-bind:class="getClass('WhiteFilling')">
            <img src="../../assets/Diagnosis.png">
            <label>White Filling</label>
        </div>
    </div>
</template>

<script>
import DiagnosesService from '@/services/DiagnosesService'

export default {
    name: 'DecayPicker',
    props:{
        toolSelected: String
    },
    methods: {
        onClickTool: function(name) {
            console.log(name);
            this.$parent.$data.toolSelected = name
            this.selectedTool = name
        },
        getClass: function(name) {
            if (name == this.toolSelected)
                return "toolSelected"
            else
                return "tool"
        }
    },
    data() {
        return {
            selectedTool: ""
        }
    },
}
</script>

<style scoped>
div {
    /* border: solid; */
    margin: 5px;
    display: flex;
    flex-direction: column;
}

img {
    height: 40px;
    width: 40px;
}

label {
    margin: 5px;
}

.viewSelector{
    font-size: 30px;
    color: rgb(47, 47, 75);
    border-width: 0px;
}
.tool {
    flex-direction: row;
}

.toolSelected {
    flex-direction: row;
    background-color: gray;
}
</style>