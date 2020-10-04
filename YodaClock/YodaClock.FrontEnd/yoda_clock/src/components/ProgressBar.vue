<template>
  <div id='progress-bar'>
    <div v-bind:key="bar.id" v-for="bar in bars" class="row mb-1">
      <div class="col-sm-12 pt-1">
        <b-progress show-progress height="45px" :value="bar.value" variant="info" id=letters > </b-progress>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    data() {
      return {
        bars: [
          {  value: 70 },
        ],
        timer: null
      }
    },
    mounted() {
    
    },
    beforeDestroy() {
      clearInterval(this.timer)
      this.timer = null
    }
  }
</script>
<style scoped>
#letters{
  font-size: 30px;
  color:red;
}

</style>