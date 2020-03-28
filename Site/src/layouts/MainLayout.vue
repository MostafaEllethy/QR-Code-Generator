<template>
  <q-layout view="lHh Lpr lFf">
    <q-header elevated class="appHeader">
      <q-toolbar>
        <q-toolbar-title class="text-weight-medium">
         QR Code Generator
        </q-toolbar-title>
      </q-toolbar>
    </q-header>

    <q-page-container>
      <router-view />
    </q-page-container>
  </q-layout>
</template>

<script>
export default {
  name: 'MainLayout',

  data () {
    return {


    }
  }
}
</script>

<style lang="scss">
  .appHeader {
    background: linear-gradient(145deg,#0f477e 11%,#1976d2 75%);
  }
</style>
