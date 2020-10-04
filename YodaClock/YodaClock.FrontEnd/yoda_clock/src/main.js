import Vue from 'vue'
import Vuex from 'vuex'
import App from './App.vue'
import "../public/css/main.css"
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

Vue.use(BootstrapVue)
Vue.use(IconsPlugin)

Vue.use(Vuex)
Vue.config.productionTip = false


const store = new Vuex.Store({
  state: {
    body: ""
  },
  mutations: {
    func(state) {
      state.body += "Well shit";
    }
  }
})

new Vue({
  render: h => h(App),
  store: store
}).$mount('#app')


