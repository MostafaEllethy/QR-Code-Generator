<template>
  <div>
    <h2 class="text-h5 text-weight-bolder text-blue-10 no-margin">SMS QR Code</h2>
    <small class="text-caption">Your QR Code will be generated automatically.</small>
    <q-form @submit.prevent="submit" class="q-pt-sm">
      <div class="row q-col-gutter-md">
        <div class="col-12">
          <q-input filled v-model="sms" placeholder="SMS Message" hint="Press <Enter> for new line." autogrow/>
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
