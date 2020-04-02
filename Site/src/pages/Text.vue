<template>
  <div>
    <h2 class="text-h5 text-weight-bolder text-blue-10 no-margin">Text QR Code</h2>
    <q-input filled v-model="string" class="q-pt-sm" type="textarea" placeholder="Your QR Code will be generated automatically." hint="Press <Enter> for new line." autogrow />
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
