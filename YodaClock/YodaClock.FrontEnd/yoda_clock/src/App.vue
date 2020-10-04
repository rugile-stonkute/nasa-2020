<template>
  <div id="app">
    <Header />
    <MainPage />
    <b-button @click="darkThemeSwitch()"><b-icon icon="moon"></b-icon>
</b-button>
  </div>
</template>

<script>
import Header from "./components/Layout/Header.vue"
import MainPage from './components/Layout/MainPage.vue'
export default {
  name: 'App',
  components: {
    Header,
    MainPage,
  },
  methods: {
    _addDarkTheme() {
      let darkThemeLinkEl = document.createElement("link");
      darkThemeLinkEl.setAttribute("rel", "stylesheet");
      darkThemeLinkEl.setAttribute("href", "css/darktheme.css");
      darkThemeLinkEl.setAttribute("id", "dark-theme-style");

      let docHead = document.querySelector("head");
      docHead.append(darkThemeLinkEl);
    },
    _removeDarkTheme() {
      let darkThemeLinkEl = document.querySelector("#dark-theme-style");
      let parentNode = darkThemeLinkEl.parentNode;
      parentNode.removeChild(darkThemeLinkEl);
    },
    darkThemeSwitch() {
      let darkThemeLinkEl = document.querySelector("#dark-theme-style");
      if (!darkThemeLinkEl) {
        this._addDarkTheme();
        this.$store.state.progress = 80;
      } else {
        this._removeDarkTheme();
        this.$store.state.progress = 20;
      }
    }
  }
}

</script>