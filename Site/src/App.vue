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
  #q-app {
    min-height: 100vh;
    background: #1A2980; /* fallback for old browsers */
    background: -webkit-linear-gradient(to right, #302b63, #00acc1); /* Chrome 10-25, Safari 5.1-6 */
    background: linear-gradient(to right, #302b63, #00acc1); /* W3C, IE 10+/ Edge, Firefox 16+, Chrome 26+, Opera 12+, Safari 7+ */
  }
</style>
