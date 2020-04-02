<template>
  <div>
    <h2 class="text-h5 text-weight-bolder text-blue-10 no-margin">URL QR Code</h2>
    <q-input filled v-model="url" class="q-pt-sm" placeholder="Your QR Code will be generated automatically." />
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
