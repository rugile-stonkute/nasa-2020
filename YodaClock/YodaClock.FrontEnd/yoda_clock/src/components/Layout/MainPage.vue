<template>
  <div class="MainPage">
    <b-container class="container">
    <b-row>
      <b-col cols="10">
        <div class="block" id="progress-bar-container">
        <ProgressBar />
        </div>
      </b-col>
      <b-col cols="2">
       <b-button squared size="xl" id=submit-button variant="info"> Suggestions </b-button>
      </b-col>
    </b-row>
    <div class="button-container">
      <div id="left-left"><h3>Left-left</h3></div>
      <div id="left-right"><h3>left-right</h3></div>
      <div id="right-left"><h3>right-left</h3></div>
      <div id="right-right"><h3>right-right</h3></div>

    </div>
    <Tasks />
  </b-container>
    <!-- {{body}} -->
    <!-- <b-button @click="clickAction">Click</b-button> -->
    <Modal />
  </div>
</template>

<script>
import CommunicationHelper from "../../Helpers/CommunicationHelper.js"
import ProgressBar from "../ProgressBar.vue"
import Tasks from "../Tasks.vue"
import Modal from "./Modal.vue"

export default {
  name: 'MainPage',
  data() {
    return {
      communicationHelper: new CommunicationHelper(),
    }
  },
  methods: {
    async clickAction() {
      var response = await this.communicationHelper.PostData("https://localhost:44334/", { name: "Oh boiiii"});
      this.body = response.name;
    }
  },
  components:{
ProgressBar,
Tasks,
Modal
  }
}
</script>
<style scoped>
#submit-button{
  font-size: 25px;
  width:150px;
  padding:4px;
}
.button-container{
  float:left;
  width:80%;
  margin-top:1rem;
  margin-bottom: 4rem;
  display: flex;
  flex-wrap: wrap;
  justify-content: space-between;
}


.button-container > div{
  display: flex;
  justify-content: center;
  align-items: center;
  flex-grow: 0;
  flex-shrink: 0;
  flex-basis: 49.75%;
  margin-bottom: .5%; 
}
.button-container > div:hover{
  background-color:#312F2F;
  color:#FDFDFF;
}
#left-left{
height: 20vh;
}
#left-right{
height: 20vh;

}
#right-left{
height: 20vh;

}
#right-right{
height: 20vh;
}

</style>