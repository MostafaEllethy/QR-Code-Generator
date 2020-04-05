<template>
  <div>
    <h1 class="text-h4 text-weight-bolder h-color no-margin">SMS QR Code</h1>
    <small class="text-caption">Your QR Code will be generated automatically.</small>
    <q-form @submit.prevent="submit" class="q-pt-sm">
      <div class="row q-col-gutter-md">
        <div class="col-12">
          <q-input filled v-model="sms" placeholder="SMS Message" type="textarea" rows="7"/>
        </div>
      </div>
    </q-form>
  </div>
</template>

<script>
  export default {
    data() {
      return {
        sms: ''
      }
    }
    , computed: {
      qr() {
        return 'sms:' + this.sms;
      }
    }
    , watch: {
      qr(val) {
        this.$emit('updateQR', val)
      }
    }
  }
</script>
