<template>
  <div>
    <h1 class="text-h4 text-weight-bolder h-color no-margin">URL QR Code</h1>
    <small class="text-caption">Your QR Code will be generated automatically.</small>
    <q-input filled v-model="url" class="q-pt-sm" placeholder="http://"/>
  </div>
</template>

<script>
  export default {
    data() {
      return {
        url: ""
      }
    }, watch: {
      url(val) {
        let string = val.toLowerCase();
        if (string.startsWith("http://") || string.startsWith("https://")) {
          this.$emit('updateQR', string)
        } else {
          this.$emit('updateQR', 'http://' + string)
        }
      }
    }
  }
</script>
