<template>
  <div class="MainPage">
    {{body}}
    <b-button @click="clickAction">Click</b-button>
  </div>
</template>

<script>
export default {
  name: 'MainPage',
  data() {
    return {
      body: ""
    }
  },
  methods: {
    clickAction() {
      this.$store.commit("func");
      this.body = this.$store.state.body;
    }
  }
}
</script>