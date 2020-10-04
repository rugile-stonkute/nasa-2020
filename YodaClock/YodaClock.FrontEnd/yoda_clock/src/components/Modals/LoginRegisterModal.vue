<template>
  <div>
    <b-modal
      size="xl"
      ref="login-register-modal"
      title="Let's begin!"
      hide-footer
    >
      <div class="d-block text-center">
        <b-form @submit="onSubmit">
          <b-container class="container">
            <b-row>
              <b-col cols="6">
                <div class="block">
                  <label for="username">Username:</label>
                  <b-form-input
                    id="username"
                    placeholder="Enter your username"
                    required
                    v-model="username"
                  ></b-form-input>
                  <br />
                  <label for="token"
                    >Token (if you have already registered):</label
                  >
                  <b-form-input
                    id="token"
                    placeholder="Enter your Token"
                    v-model="token"
                  ></b-form-input>
                  <br />
                  <br />
                  <br />
                  <br />
                  <br />
                  <b-form-file
                    v-model="import_file"
                    :state="Boolean(import_file)"
                    placeholder="Choose a file or drop it here..."
                    drop-placeholder="Drop file here..."
                    required
                  ></b-form-file>
                  <div class="mt-3">
                    Selected file: {{ import_file ? import_file.name : "" }}
                  </div>
                </div>
              </b-col>
              <b-col cols="6">
                <div class="block">
                  <label for="duration">Last sleep duration:</label>
                  <b-form-input
                  type="number"
                    id="duration"
                    required
                    v-model.number="sleepDuration"
                  ></b-form-input>
                  <br />
                  <label for="interruptions">Last sleep interruptions:</label>
                  <b-form-input
                  type="number"
                    id="interruptions"
                    required
                    v-model.number="sleepInterruptions"
                  ></b-form-input>
                  <br />
                  <label for="noise">Sound pollution:</label>
                  <b-form-input
                  type="number"
                    id="noise"
                    required
                    v-model.number="noise"
                  ></b-form-input>
                  <br />
                  <label for="illumination">Light pollution:</label>
                  <b-form-input
                  type="number"
                    id="illumination"
                    required
                    v-model.number="illumination"
                  ></b-form-input>
                </div>
              </b-col>
            </b-row>
            <b-button type="submit" class="mt-3" block>Proceed</b-button>
          </b-container>
        </b-form>
      </div>
    </b-modal>
  </div>
</template>

<script>
import CommunicationHelper from "../../Helpers/CommunicationHelper.js";

export default {
  data() {
    return {
      import_file: null,
      communicationHelper: new CommunicationHelper(),
      username: "",
      token: "",
      sleepDuration: "",
      sleepInterruptions: "",
      noise: "",
      illumination: "",
    };
  },
  mounted() {
    this.$refs["login-register-modal"].show();
  },
  methods: {
    async onSubmit(evt) {
      evt.preventDefault();
      // var data = [];
      // const reader = new FileReader();
      // reader.onload = e => data = e.target.result;

      // reader.readAsText(this.import_file);
      // console.log(data);
      var request = {
        username: this.username,
        token: this.token,
        precondition: {
          sleepDuration: parseInt(this.sleepDuration),
          sleepInterruptions: parseInt(this.sleepInterruptions),
          noise: parseInt(this.noise),
          illumination: parseInt(this.illumination),
        },
        plan: {
          name: "Astronaut",
          exercisePercentage: 40,
          excerciseTime: 120,
          carb: 268.85,
          fat: 61.39,
          protein: 76.09,
          environment: {
            noise: 52.57,
            illumination: 8,
          },
          dbResponses: [
            {
              db: 0,
              percentage: 0,
            },
            {
              db: 70,
              percentage: -5,
            },
            {
              db: 80,
              percentage: -10,
            },
            {
              db: 150,
              percentage: -15,
            },
          ],
          luxResponses: [
            {
              lux: 1,
              percentage: 0,
            },
            {
              lux: 50,
              percentage: -2.5,
            },
            {
              lux: 200,
              percentage: -10,
            },
            {
              lux: 1000,
              percentage: -20,
            },
            {
              lux: 25000,
              percentage: -40,
            },
          ],
          meals: [
            {
              name: "Breakfast",
              planMealTime: {
                percentage: 15,
                start: "8:30",
                end: "9:30",
              },
            },
            {
              name: "Lunch",
              planMealTime: {
                percentage: 21.6,
                start: "13:30",
                end: "14:30",
              },
            },
            {
              name: "Dinner",
              planMealTime: {
                percentage: 23.4,
                start: "17:30",
                end: "18:30",
              },
            },
            {
              name: "Snacks",
              planMealTime: {
                percentage: 0,
                start: "8:30",
                end: "18:30",
              },
            },
          ],
          naps: [
            {
              name: "Power nap (15 min)",
              percentage: 5,
            },
            {
              name: "30 min",
              percentage: 10,
            },
            {
              name: "60 min",
              percentage: 15,
            },
            {
              name: "Medication (melatonin)",
              percentage: 10,
            },
            {
              name: "Wearing sunglasses",
              percentage: 5,
            },
          ],
          products: [
            {
              name: "Cocoa",
              carb: 32,
              fat: 1.5,
              protein: 2.2,
            },
            {
              name: "Coffee",
              carb: 3.12,
              fat: 1.5,
              protein: 0.24,
            },
            {
              name: "Grape drink",
              carb: 12.4,
              fat: 0.12,
              protein: 0.31,
            },
            {
              name: "Grapefruit drink",
              carb: 29,
              fat: 0.25,
              protein: 0.5,
            },
            {
              name: "Grape Punch",
              carb: 32,
              fat: 0,
              protein: 0,
            },
            {
              name: "Orange - grapefruit drink",
              carb: 25.4,
              fat: 0.25,
              protein: 1.48,
            },
            {
              name: "Orange Juice",
              carb: 25.5,
              fat: 0,
              protein: 2,
            },
            {
              name: "Pineapple - Grapefruit drink",
              carb: 29,
              fat: 0.3,
              protein: 0.5,
            },
            {
              name: "Pineapple - Orange drink",
              carb: 24,
              fat: 0,
              protein: 1,
            },
            {
              name: "Bacon Squares",
              carb: 0.6,
              fat: 12,
              protein: 12,
            },
            {
              name: "Cinnamon Toasted Bread Cubes",
              carb: 77.2,
              fat: 19.3,
              protein: 14.3,
            },
            {
              name: "Canadian Bacon and Applesauce",
              carb: 1.1,
              fat: 2.2,
              protein: 17,
            },
            {
              name: "Cornflakes",
              carb: 31,
              fat: 2,
              protein: 6,
            },
            {
              name: "Fruit Coctail",
              carb: 32,
              fat: 0.1,
              protein: 1.3,
            },
            {
              name: "Sausage Patties",
              carb: 3,
              fat: 17,
              protein: 11,
            },
            {
              name: "Scrambled Eggs",
              carb: 1,
              fat: 6.7,
              protein: 6.1,
            },
            {
              name: "Peaches",
              carb: 14.3,
              fat: 0.4,
              protein: 1.4,
            },
            {
              name: "Spiced Fruit Cereal",
              carb: 34.5,
              fat: 3,
              protein: 0.5,
            },
            {
              name: "Apricot",
              carb: 3.9,
              fat: 0.1,
              protein: 0.5,
            },
            {
              name: "Brownies",
              carb: 39,
              fat: 9.9,
              protein: 2.9,
            },
            {
              name: "Caramel Candy",
              carb: 30.1,
              fat: 8.4,
              protein: 1.9,
            },
            {
              name: "Chocolate Bar",
              carb: 22,
              fat: 16,
              protein: 3,
            },
            {
              name: "Creamed Chicken Bites",
              carb: 0,
              fat: 8,
              protein: 6,
            },
            {
              name: "Cheese Crackers",
              carb: 18,
              fat: 8,
              protein: 3,
            },
            {
              name: "Cheese Sandwiches",
              carb: 23,
              fat: 12.67,
              protein: 9.1,
            },
            {
              name: "Beef Sandwiches",
              carb: 41,
              fat: 8.5,
              protein: 35,
            },
            {
              name: "Jellied Fruit Candy",
              carb: 36,
              fat: 0,
              protein: 0,
            },
            {
              name: "Beef Jerky",
              carb: 9,
              fat: 1.5,
              protein: 10,
            },
            {
              name: "Peanut Cubes",
              carb: 16,
              fat: 6,
              protein: 2,
            },
            {
              name: "Pecans",
              carb: 4,
              fat: 20,
              protein: 3,
            },
            {
              name: "Pineapple Fruitcake",
              carb: 69,
              fat: 13,
              protein: 5,
            },
            {
              name: "Sugar Cookies",
              carb: 24,
              fat: 8,
              protein: 1,
            },
            {
              name: "Turkey Bites",
              carb: 0.5,
              fat: 5,
              protein: 7,
            },
            {
              name: "Applesauce",
              carb: 14,
              fat: 0,
              protein: 0,
            },
            {
              name: "Banana Pudding",
              carb: 26,
              fat: 2,
              protein: 2,
            },
            {
              name: "Butterscotch Pudding",
              carb: 21,
              fat: 1,
              protein: 0,
            },
            {
              name: "Chocolate Pudding",
              carb: 29,
              fat: 2,
              protein: 2,
            },
            {
              name: "Cranberry - Orange Sauce",
              carb: 29,
              fat: 0,
              protein: 0.5,
            },
            {
              name: "Peach Ambrosia",
              carb: 11.1,
              fat: 0,
              protein: 2.8,
            },
            {
              name: "Chicken and Rice Soup",
              carb: 13,
              fat: 1.5,
              protein: 2,
            },
            {
              name: "Lobster Bisque",
              carb: 11,
              fat: 17,
              protein: 2,
            },
            {
              name: "Pea Soup",
              carb: 16,
              fat: 3.5,
              protein: 7,
            },
            {
              name: "Potato Soup",
              carb: 27,
              fat: 6,
              protein: 4,
            },
            {
              name: "Shrimp Cocktail",
              carb: 0,
              fat: 1,
              protein: 14,
            },
            {
              name: "Tomato Soup",
              carb: 22,
              fat: 19,
              protein: 5,
            },
            {
              name: "Tuna Salad",
              carb: 21,
              fat: 3,
              protein: 54,
            },
            {
              name: "Bread Slice",
              carb: 22,
              fat: 0,
              protein: 3,
            },
            {
              name: "Catsup",
              carb: 4,
              fat: 0,
              protein: 0,
            },
            {
              name: "Cheddar Cheese",
              carb: 1,
              fat: 9,
              protein: 7,
            },
            {
              name: "Chicken Salad",
              carb: 7,
              fat: 19,
              protein: 5,
            },
            {
              name: "Ham Salad",
              carb: 36,
              fat: 7,
              protein: 18,
            },
            {
              name: "Jelly",
              carb: 13,
              fat: 0,
              protein: 0,
            },
            {
              name: "Mustard",
              carb: 2,
              fat: 1,
              protein: 0,
            },
            {
              name: "Peanut Butter",
              carb: 6,
              fat: 16,
              protein: 8,
            },
            {
              name: "Beef Pot Roast",
              carb: 1,
              fat: 9,
              protein: 16,
            },
            {
              name: "Beef and Vegetables",
              carb: 54,
              fat: 2.5,
              protein: 10,
            },
            {
              name: "Beef Stew",
              carb: 21,
              fat: 8,
              protein: 12,
            },
            {
              name: "Chicken and Rice",
              carb: 54,
              fat: 10,
              protein: 19,
            },
            {
              name: "Chicken and Vegetables",
              carb: 29,
              fat: 5,
              protein: 18,
            },
            {
              name: "Chicken Stew",
              carb: 10.1,
              fat: 6.9,
              protein: 22.6,
            },
            {
              name: "Pork and Scalloped Potatoes",
              carb: 13.7,
              fat: 24.4,
              protein: 34,
            },
            {
              name: "Spaghetti, Meat Sauce",
              carb: 52.1,
              fat: 12.3,
              protein: 24.2,
            },
            {
              name: "Beef and Gravy",
              carb: 5,
              fat: 17.9,
              protein: 68.1,
            },
            {
              name: "Frankfurters",
              carb: 4.2,
              fat: 26,
              protein: 10,
            },
            {
              name: "Meatballs, Sauce",
              carb: 8.5,
              fat: 18,
              protein: 9,
            },
            {
              name: "Turkey and Gravy",
              carb: 4,
              fat: 3,
              protein: 21,
            },
          ],
          exercises: [
            {
              name: "ARED",
            },
            {
              name: "Treadmill",
            },
            {
              name: "CEVIS",
            },
          ],
        },
      };

      var result = await this.communicationHelper.PostData(
        "https://localhost:44334/LoginRegister",
        request
      );
      this.$store.state.user = {
        username: result.username,
        token: result.token,
        planId: result.planId,
      };
      

      this.$store.state.exercises = await this.communicationHelper.PostData(
        "https://localhost:44334/Exercises",
        request
      );
      this.$store.state.meals = await this.communicationHelper.PostData(
        "https://localhost:44334/meals",
        request
      );
      this.$store.state.naps = await this.communicationHelper.PostData(
        "https://localhost:44334/naps",
        request
      );
      this.$store.state.plan = await this.communicationHelper.PostData(
        "https://localhost:44334/plan",
        request
      );
      this.$store.state.planMealTimes = await this.communicationHelper.PostData(
        "https://localhost:44334/planMealTimes",
        request
      );
      this.$store.state.products = await this.communicationHelper.PostData(
        "https://localhost:44334/products",
        request
      );
      this.$store.state.userEnvironment = await this.communicationHelper.PostData(
        "https://localhost:44334/userEnvironment",
        request
      );
      this.$store.state.userMealExercises = await this.communicationHelper.PostData(
        "https://localhost:44334/userMealExercises",
        request
      );
      this.$store.state.userNaps = await this.communicationHelper.PostData(
        "https://localhost:44334/UserNaps",
        request
      );
      this.$store.state.userPrecondition = await this.communicationHelper.PostData(
        "https://localhost:44334/UserPrecondition",
        request
      );
      this.$store.state.userProductMeals = await this.communicationHelper.PostData(
        "https://localhost:44334/UserProductMeals",
        request
      );
      this.$store.state.dbResponses = await this.communicationHelper.PostData(
        "https://localhost:44334/DbResponses",
        request
      );
      this.$store.state.luxResponses = await this.communicationHelper.PostData(
        "https://localhost:44334/LuxResponses",
        request
      );
      
      this.$refs['login-register-modal'].hide();
    },
  },
};
</script>
