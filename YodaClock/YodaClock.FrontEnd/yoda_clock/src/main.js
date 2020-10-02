import Vue from 'vue'
import Vuex from 'vuex'
import App from './App.vue'
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

Vue.use(BootstrapVue)
Vue.use(IconsPlugin)

Vue.use(Vuex)
Vue.config.productionTip = false


const store = new Vuex.Store({
  state: {
    msg: "Front is I" 
  },
  mutations: {
  }
})

new Vue({
  render: h => h(App),
  store: store
}).$mount('#app')


