<template>
  <div>
    <b-button id="left-left" @click="loadModal()">Nutrition</b-button>

    <b-modal ref="nutrition-modal" hide-footer scrollable title="Nutrition">
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
        this.items = this.$store.state.products;
        this.$refs['nutrition-modal'].show();
      }
    }
  }
</script>
