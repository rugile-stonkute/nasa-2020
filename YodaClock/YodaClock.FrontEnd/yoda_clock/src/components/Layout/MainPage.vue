<template>
  <div class="MainPage">
    <b-container class="container">
    <b-row>
      <b-col cols="9">
        <div class="block">
          looo
        </div>
      </b-col>
      <b-col cols="3">
        <div class="block">
          looo
        </div>
      </b-col>
    </b-row>
  </b-container>
    <!-- {{body}} -->
    <!-- <b-button @click="clickAction">Click</b-button> -->
  </div>
</template>

<script>
import CommunicationHelper from "../../Helpers/CommunicationHelper.js"

export default {
  name: 'MainPage',
  data() {
    return {
      body: "Hello World",
      communicationHelper: new CommunicationHelper()
    }
  },
  methods: {
    async clickAction() {
      var response = await this.communicationHelper.PostData("https://localhost:44334/", { name: "Oh boiiii"});
      this.body = response.name;
    }
  }
}
</script>