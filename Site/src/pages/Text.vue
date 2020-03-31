<template>
  <div>
    <q-input outlined v-model="string" v-on:keydown="typing"
             placeholder="Enter your website, text or social media link."
             hint="Your QR Code will be generated automatically."
             :input-style="{fontSize: (screenSize > 2) ? '1.5rem' : '1.25rem', lineHeight: 1.1}"
             type="textarea"
             rows="7"
             debounce="500" />
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
