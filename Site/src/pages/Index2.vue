<template>
  <q-page class="flex flex-center">
    <router-link to="/">Go to Index1</router-link>
    <textarea rows="10" style="width: 500px" v-model="string">
</textarea>
    <canvas id="canvas"></canvas>
  </q-page>
</template>

<script>
  import QRCode from 'qrcode';

  export default {
    name: 'PageIndex',
    data() {
      return {
        string: ""
      }
    }, watch: {
      string(val) {
        if (val != null) {
          console.log(val);
          var canvas = document.getElementById('canvas');
          QRCode.toCanvas(canvas, val, { width: 250 });
        }
      }
    }
  }
</script>
