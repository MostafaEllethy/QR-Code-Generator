<template>
  <div>
    <q-input filled v-model="url" placeholder="URL" debounce="250" hint="Your QR Code will be generated automatically." />
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
