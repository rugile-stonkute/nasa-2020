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
        <Suggestions />
      </b-col>
    </b-row>
    <div class="button-container">
      <NutritionModal />
      <ExerciseModal />
      <NapsModal />
      <EnvironmentModal />
    </div>
    <Tasks />
  </b-container>
    <LoginRegisterModal />
  </div>
</template>

<script>
import CommunicationHelper from "../../Helpers/CommunicationHelper.js"
import ProgressBar from "../ProgressBar.vue"
import Tasks from "../Tasks.vue"
import NutritionModal from "../Modals/NutritionModal.vue"
import LoginRegisterModal from "../Modals/LoginRegisterModal.vue"
import Suggestions from "../Modals/Suggestions.vue"
import ExerciseModal from "../Modals/ExerciseModal.vue"
import EnvironmentModal from "../Modals/EnvironmentModal.vue"
import NapsModal from "../Modals/NapsModal.vue"


export default {
  name: 'MainPage',
  components: {
    NutritionModal,
    ExerciseModal,
    LoginRegisterModal,
    ProgressBar,
    Tasks,
    Suggestions,
    EnvironmentModal,
    NapsModal
  },
  data() {
    return {
      communicationHelper: new CommunicationHelper(),
    }
  },
  methods: {
    openNutrition() {
      console.log(this.$bvModal);
      this.$bvModal.show('nutrition-modal');
    },
    async clickAction() {
      var response = await this.communicationHelper.PostData("https://localhost:44334/", { name: "Oh boiiii"});
      this.body = response.name;
    }
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

.button-container button{
  width: 49.75%;
}

.button-container > div:hover{
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