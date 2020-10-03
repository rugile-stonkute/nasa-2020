<template>
  <div id="app">
    <Header />
    <MainPage />
  </div>
</template>

<script>
import Header from "./components/Layout/Header.vue"
import MainPage from './components/Layout/MainPage.vue'

export default {
  name: 'App',
  components: {
    Header,
    MainPage
  }
}
</script>