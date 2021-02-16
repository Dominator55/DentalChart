
<template>
    <div>
        <label class="header">Diagnosis</label>
        <div class="tool" v-on:click="onClickEncounter" v-bind:class="getClass('encounter')">
            <img src="../../assets/toothDecay.png">
            <label>Decay</label>
        </div>
    </div>
</template>

<script>

export default {
    name: 'EncounterPicker',
    methods: {
        onClickEncounter: function() {
            // this.$parent.$data.toolSelected = {
            //     onClickFunction: function(click, ) {
            //         var parent = click.target.parentElement
            //         parent.children.forEach(child => {
            //             if (child.style.fill != "rgb(19, 18, 18)") {
            //                 child.style.fill = "grey"
            //             }
            //         });
            //         parent.setAttribute("class", "changed")
            //         console.log(parent)
            //     }
            // }
            // this.selectedTool = "encounter"
            this.$parent.toolSelected = {
                onClickFunction: function(click, ){
                    var parent = click.target.parentElement
                    var localization = parent.id.split('t')[1]
                    var tooth = this.$parent.patient.to
                    this.$parent.diagnosis.push({
                    

                    })
                    parent.children.forEach(child => {
                        if (child.style.fill != "rgb(19, 18, 18)") {
                            child.style.fill = "grey"
                        }
                    });
                }
            }
        },
        getClass: function(name) {
            if (name == this.selectedTool)
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

.header {
    font-weight: bold;
}

.tool {
    flex-direction: row;
}

.toolSelected {
    flex-direction: row;
    background-color: gray;
}
</style>