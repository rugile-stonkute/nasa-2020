<template>
  <div>
    <b-button id="left-left" @click="loadModal()">Environment</b-button>

    <b-modal ref="Exercise-modal" hide-footer title="Nutrition">
      <b-table striped hover :items="items"></b-table>
      <b-button @click="proceed()" class="mt-3" block>Proceed</b-button>
    </b-modal>
  </div>
</template>

<script>
  export default {
    data() {
      return {
        items: []
      }
    },
    methods: {
      proceed() {
        console.log("ok");
      },
      loadModal() {
        this.items = this.$store.state.exercises;
        //this.$refs['nutrition-modal'].show();
      }
    }
  }
</script>

<style scoped>
#left-left{
  width: 35vw;
  height: 25vh;
  font-size: 40px;
  }
</style>