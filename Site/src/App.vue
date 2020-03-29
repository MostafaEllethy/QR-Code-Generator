<template>
  <div id="q-app">
    <router-view />
  </div>
</template>

<script>
export default {
  name: 'App'
}
</script>

<style lang="scss">
/*@import url('https://fonts.googleapis.com/css2?family=Raleway:wght@500;700;800;900&display=swap');*/

  /*html, body {
    font-family: 'Raleway', sans-serif;
  }

  #app {
    font-family: 'Raleway', sans-serif;
  }*/

  #q-app {
    min-height: 100vh;
    background: #1A2980; /* fallback for old browsers */
    background: -webkit-linear-gradient(to left, #26c6da, #302b63); /* Chrome 10-25, Safari 5.1-6 */
    background: linear-gradient(to left, #26c6da, #302b63); /* W3C, IE 10+/ Edge, Firefox 16+, Chrome 26+, Opera 12+, Safari 7+ */
  }
</style>
