<template>
  <div>
    <h1 class="text-h4 text-weight-bolder h-color no-margin">Text QR Code</h1>
    <small class="text-caption">Your QR Code will be generated automatically.</small>
    <q-input filled v-model="string" class="q-pt-sm" type="textarea" rows="7" placeholder="Enter your text here"/>
  </div>
</template>

<script>
  export default {
    props: ['screenSize']
    , data() {
      return {
        string: null
      }
    }
    , watch: {
      string(val) {
        this.$emit('updateQR', val)
      }
    }
  }
</script>
