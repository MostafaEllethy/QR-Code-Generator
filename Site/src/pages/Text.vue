<template>
  <div>
    <q-input filled v-model="string"
             placeholder="Enter text you want to share."
             hint="Your QR Code will be generated automatically."
             :input-style="{fontSize: (screenSize > 2) ? '1.5rem' : '1.25rem', lineHeight: 1.1}"
             type="textarea"
             rows="7"
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
