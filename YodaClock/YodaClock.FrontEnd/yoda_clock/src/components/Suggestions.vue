<template>
  <div>
    <b-button squared size="xl" id=submit-button variant="info" @click="toggleModal"> Suggestions </b-button>
    <b-modal ref="my-modal" hide-footer title="Using Component Methods">
      <div class="d-block text-center">
        <h3>Things that You should perform!</h3>
        <ol>
          <li>Have A Sleep</li>
          <li>Have some food</li>
        </ol>
      </div>
    </b-modal>
  </div>
</template>

<script>
  export default {
    methods: {

      toggleModal() {
        // We pass the ID of the button that we want to return focus to
        // when the modal has hidden
        this.$refs['my-modal'].toggle('#toggle-btn')
      }
    }
  }
</script>
<style scoped>
#submit-button{
  width:13vw;
  height:5.5vh;
  margin-top:5px;
}
</style>