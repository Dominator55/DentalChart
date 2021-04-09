
<template>
  <div class="control">
    <select class="viewSelector" v-model="viewSelected">
      <option value="all">All diagnoses</option>
      <option value="untreated">Untreated diagnoses</option>
      <option value="byEncounter">By encounter</option>
    </select>
    <div class="list1" v-for="encounter in encounters" :key="encounter.id">
      <div class="row" v-on:click="onRecordClick( encounter)">
        {{ encounter.date.toLocaleDateString() }}
        <svg
          :id="'e' + encounter.id"
          :transform="encounter.expanded ? 'rotate(0)' : 'rotate(-90)'"
          version="1.1"
          xmlns="http://www.w3.org/2000/svg"
          xmlns:xlink="http://www.w3.org/1999/xlink"
          x="0px"
          y="0px"
          width="32px"
          height="32px"
          viewBox="0 0 512 512"
          style="enable-background: new 0 0 512 512"
          xml:space="preserve"
        >
          <path
            d="M98.9,184.7l1.8,2.1l136,156.5c4.6,5.3,11.5,8.6,19.2,8.6c7.7,0,14.6-3.4,19.2-8.6L411,187.1l2.3-2.6
                c1.7-2.5,2.7-5.5,2.7-8.7c0-8.7-7.4-15.8-16.6-15.8v0H112.6v0c-9.2,0-16.6,7.1-16.6,15.8C96,179.1,97.1,182.2,98.9,184.7z"
          />
        </svg>
      </div>
      <div class="list1" v-if="encounter.expanded">
        <div
          class="record"
          v-for="diagnosis in encounter.diagnoses"
          :key="diagnosis.id"
          v-on:mouseenter="
            $emit('mouseEnter', diagnosis.toothRecord.tooth.localization)
          "
          v-on:mouseleave="
            $emit('mouseLeave', diagnosis.toothRecord.tooth.localization)
          "
        >
          <div class="row">
            <div v-if="!diagnosis.expanded"
            @click="onRecordClick(diagnosis)"
            >
              {{ diagnosis.classificationOfDisease.displayName }}
              {{ diagnosis.toothRecord.tooth.localization }}
            </div>
            <diagnosis-form
              :diagnosis="diagnosis"
              :encounters="Encounters"
              :teeth="ToothRecords"
              v-if="diagnosis.expanded"
              v-on:updateDiagnosis="updateDiagnosis"
            />
            <svg
            @click="onRecordClick(diagnosis)"
              :id="'d' + diagnosis.id"
              :transform="diagnosis.expanded ? 'rotate(0)' : 'rotate(-90)'"
              version="1.1"
              xmlns="http://www.w3.org/2000/svg"
              xmlns:xlink="http://www.w3.org/1999/xlink"
              x="0px"
              y="0px"
              width="32px"
              height="32px"
              viewBox="0 0 512 512"
              style="enable-background: new 0 0 512 512"
              xml:space="preserve"
            >
              <path
                d="M98.9,184.7l1.8,2.1l136,156.5c4.6,5.3,11.5,8.6,19.2,8.6c7.7,0,14.6-3.4,19.2-8.6L411,187.1l2.3-2.6
                    c1.7-2.5,2.7-5.5,2.7-8.7c0-8.7-7.4-15.8-16.6-15.8v0H112.6v0c-9.2,0-16.6,7.1-16.6,15.8C96,179.1,97.1,182.2,98.9,184.7z"
              />
            </svg>
          </div>
        </div>
        <div
          class="record"
          v-for="procedureRecord in encounter.procedureRecords"
          :key="procedureRecord.id"
          v-on:mouseenter="
            $emit('mouseEnter', procedureRecord.toothRecord.tooth.localization)
          "
          v-on:mouseleave="
            $emit('mouseLeave', procedureRecord.toothRecord.tooth.localization)
          "
        >
          <div class="row">
            <div v-if="!procedureRecord.expanded"
            @click="onRecordClick(procedureRecord)">
              {{ procedureRecord.procedure.displayName }}
              {{ procedureRecord.toothRecord.tooth.localization }}
            </div>
            <procedure-record-form
              :procedureRecord="procedureRecord"
              :encounters="Encounters"
              :teeth="ToothRecords"
              v-if="procedureRecord.expanded"
            />
            <svg
            @click="onRecordClick(procedureRecord)"
              :id="'p' + procedureRecord.id"
              :transform="
                procedureRecord.expanded ? 'rotate(0)' : 'rotate(-90)'
              "
              version="1.1"
              xmlns="http://www.w3.org/2000/svg"
              xmlns:xlink="http://www.w3.org/1999/xlink"
              x="0px"
              y="0px"
              width="32px"
              height="32px"
              viewBox="0 0 512 512"
              style="enable-background: new 0 0 512 512"
              xml:space="preserve"
            >
              <path
                d="M98.9,184.7l1.8,2.1l136,156.5c4.6,5.3,11.5,8.6,19.2,8.6c7.7,0,14.6-3.4,19.2-8.6L411,187.1l2.3-2.6
                        c1.7-2.5,2.7-5.5,2.7-8.7c0-8.7-7.4-15.8-16.6-15.8v0H112.6v0c-9.2,0-16.6,7.1-16.6,15.8C96,179.1,97.1,182.2,98.9,184.7z"
              />
            </svg>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import DiagnosisForm from "./DiagnosisForm.vue";
import ProcedureRecordForm from "@/components/DentalChartVues/ProcedureRecordForm";
export default {
  components: { DiagnosisForm, ProcedureRecordForm },
  name: "RecordsList",
  props: {
    Encounters: Array,
    ToothRecords: Array,
    SelectedRecord: Object
  },
  methods: {
    onRecordClick: function (record) {
      record.expanded = !record.expanded;
    },
    updateDiagnosis: function(updateDiagnosis){
      this.$emit('updateDiagnosis', updateDiagnosis)
    }
  },
  watch: {
    Encounters: function (Encounters) {
      Encounters.map((e) => {
        e.expanded = true;
        e.diagnoses.map((d) => (d.expanded = false));
        e.procedureRecords.map((pr) => (pr.expanded = false));
      });
      this.encounters = Encounters;
    },
    SelectedRecord: function (newVal, oldVal) {
      if (oldVal != null) {
        var oldEncounterIndex = this.encounters.findIndex(
          (e) => e.id == oldVal.encounter.id
        );
        if (oldVal.classificationOfDisease != null) {
          var oldDiagnosisIndex = this.encounters[
            oldEncounterIndex
          ].diagnoses.findIndex((d) => d.id == oldVal.id);
          this.encounters[oldEncounterIndex].expanded = false;
          this.encounters[oldEncounterIndex].diagnoses[
            oldDiagnosisIndex
          ].expanded = false;
        } else {
          var oldProcedureRecordIndex = this.encounters[
            oldEncounterIndex
          ].procedureRecords.findIndex((d) => d.id == oldVal.id);
          this.encounters[oldEncounterIndex].expanded = false;
          this.encounters[oldEncounterIndex].procedureRecords[
            oldProcedureRecordIndex
          ].expanded = false;
        }
      }
      var newEncounterIndex = this.encounters.findIndex(
        (e) => e.id == newVal.encounter.id
      );
      if (newVal.classificationOfDisease != null) {
        this.encounters[newEncounterIndex].expanded = true;
        var newDiagnosisIndex = this.encounters[
          newEncounterIndex
        ].diagnoses.findIndex((d) => d.id == newVal.id);
        this.encounters[newEncounterIndex].diagnoses[
          newDiagnosisIndex
        ].expanded = true;
      } else {
        var newProcedureRecordIndex = this.encounters[
          newEncounterIndex
        ].procedureRecords.findIndex((d) => d.id == newVal.id);
        this.encounters[newEncounterIndex].expanded = false;
        this.encounters[newEncounterIndex].procedureRecords[
          newProcedureRecordIndex
        ].expanded = false;
      }
    },
  },
  data() {
    return {
      encounters: [],
      viewSelected: "byEncounter",
    };
  },
};
</script>

<style scoped>
.control {
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
.list1 {
  flex-direction: column;
  font-size: 23px;
  flex-basis: 100%;
  justify-content: left;
  text-align: left;
  align-content: flex-start;
}
.record {
  flex-direction: column;
  margin-left:30px;
  justify-content: space-between;
  flex-basis: 100%;
  flex-wrap: nowrap;
}
.name {
  flex-basis: 60%;
}
.date {
  flex-basis: 30%;
}
.tooth {
  flex-basis: 10%;
}

img {
  height: 40px;
  width: 40px;
}

label {
  margin: 5px;
}

.tool {
  flex-direction: row;
}
.viewSelector {
  font-size: 30px;
  color: rgb(47, 47, 75);
  border-width: 0px;
}
.row {
  flex-direction: row;
}
</style>