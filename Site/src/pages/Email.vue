<template>
  <div>
    <h2 class="text-h5 text-weight-bolder text-blue-10 no-margin">Email QR Code</h2>
    <small class="text-caption">Your QR Code will be generated automatically.</small>
    <q-form @submit.prevent="submit" class="q-pt-sm">
      <div class="row q-col-gutter-md">
        <div class="col-12">
          <q-input filled v-model="email" placeholder="Email Address" />
        </div>
        <div class="col-12">
          <q-input filled v-model="subject" placeholder="Subject" autogrow/>
        </div>
        <div class="col-12">
          <q-input filled v-model="body" placeholder="Body" hint="Press <Enter> for new line." autogrow />
        </div>
      </div>
    </q-form>
  </div>
</template>

<script>
  export default {
    data() {
      return {
        email: ''
        , subject: ''
        , body: ''
      }
    }
    , computed: {
      qr() {
        return 'mailto:' + this.email + '?subject=' + this.subject + '&body=' + this.body;
      }
    }
    , watch: {
      qr(val) {
        this.$emit('updateQR', val)
      }
    }
  }
</script>
