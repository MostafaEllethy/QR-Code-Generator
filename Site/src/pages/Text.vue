<template>
  <div>
    <q-input filled v-model="string"
             placeholder="Text"
             hint="Your QR Code will be generated automatically."
             type="textarea"
             autogrow
             debounce="250" />
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
