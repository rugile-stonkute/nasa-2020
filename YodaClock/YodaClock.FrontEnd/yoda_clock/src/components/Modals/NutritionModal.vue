<template>
  <div>
    
    <b-button id="left-left" @click="loadModal()">Nutrition</b-button>
    <b-modal
      size="xl"
      ref="nutrition-modal"
      title="Let's begin!"
      hide-footer
    >
    <b-button @click="addRow()">+</b-button>
      <b-row v-for="(row, index) in rows" :key="row.name">
        <b-form-input :list="'my-list-' + index" class="modal_inside_input-select" v-model="rows[index].productId"></b-form-input>
          <datalist :id="'my-list-' + index">
            <option>Manual Option</option>
            <option v-for="item in items" :key="item.id">{{item.name}} - Carbs: {{item.carb}}, Protein: {{item.protein}}, Fat: {{item.fat}}</option>
          </datalist>
          <b-form-input :list="'my-meal-' + index" class="modal_inside_input-meals" v-model="rows[index].mealId"></b-form-input>
          <datalist :id="'my-meal-' + index">
            <option>Manual Option</option>
            <option v-for="meal in meals" :key="meal.id">{{meal.name}}</option>
          </datalist>
          <b-form-input class="modal_inside_input-field"
                  type="number"
                    :id="'my-amount-' + index"
                    v-model.number="rows[index].amount"
                  ></b-form-input>

                  <b-form-input class="modal_inside_input-field"
                  type="time"
                    :id="'my-time-' + index"
                    v-model.number="rows[index].timestamp"
                  ></b-form-input>
                  <b-button variant="danger modal_inside_delete" @click="remove(index)">-</b-button>
      </b-row>
      <b-button @click="saveChanges">Save changes</b-button>
    </b-modal>
  </div>
</template>

<script>
  export default {
    data() {
      return {
        rows: [],
        items: [],
        meals: [],
        fields: ['name', 'carb', 'fat', 'protein'],
      }
    },
    methods: {
      loadModal() {
        this.items = this.$store.state.products;
        this.meals = this.$store.state.meals;
        this.rows = this.$store.state.nutritions;
        if(this.rows.length == 0) {
          this.rows.push({
            id: 0,
            productId: 0,
            mealId: 0,
            amount: 0,
            timestamp: 0
          });
        }
        this.$refs['nutrition-modal'].show();
      },
      addRow() {
        if(this.rows.length == 0 || this.rows[this.rows.length - 1].name != "") {
          this.rows.push({
            id: 0,
            productId: 0,
            mealId: 0,
            amount: 0,
            timestamp: 0
          });
        }
      },
      remove(index){
        this.rows.splice(index, 1);
      },
      async saveChanges() {
        let existNull = false;
        for(var i = 0; i < this.rows.length; i++) {
          if(this.rows[i].productId == 0 || this.rows[i].mealId == 0) {
            existNull = true;
            break;
          }
        }
        if(existNull) {
          alert("Please, don't leave empty rows");
        } else {
          this.rows = await this.communicationHelper.PostData("https://localhost:44334/nutritionChanges", this.rows);
        }
      },
    }
  }
</script>
