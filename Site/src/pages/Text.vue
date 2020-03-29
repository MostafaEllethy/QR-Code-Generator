<template>
  <div>
    <q-input outlined v-model="string" v-on:keyup="typing"
             placeholder="Enter your website, text or social media link."
             hint="Your QR Code will be generated automatically."
             :input-style="{fontSize: '1.5rem'}"
             type="textarea"
             rows="5"
             debounce="500" />
  </div>
</template>

<script>
  export default {
    data() {
      return {
        string: null
      }
    }
    , methods: {
      typing() {
        this.$emit('typing')
      }
    }
    , watch: {
      string(val) {
        this.$emit('updateQR', val)
      }
    }
  }
</script>
