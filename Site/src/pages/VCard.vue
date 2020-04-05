<template>
  <div>
    <h1 class="text-h4 text-weight-bolder h-color no-margin">vCard QR Code</h1>
    <small class="text-caption">Your QR Code will be generated automatically.</small>
    <q-form @submit.prevent="submit" class="q-pt-sm">
      <div class="row q-col-gutter-md">
        <div class="col-6">
          <q-input filled v-model="firstName" placeholder="First Name" />
        </div>
        <div class="col-6">
          <q-input filled v-model="lastName" placeholder="Last Name" />
        </div>
        <div class="col-xs-12 col-sm-6">
          <q-input filled v-model="phoneMobile" placeholder="Phone (Mobile)" />
        </div>
        <div class="col-xs-12 col-sm-6">
          <q-input filled v-model="phoneWork" placeholder="Phone (Work)" />
        </div>
        <div class="col-6">
          <q-input filled v-model="organization" placeholder="Organization" />
        </div>
        <div class="col-6">
          <q-input filled v-model="title" placeholder="Title" />
        </div>
        <div class="col-12">
          <q-input filled v-model="email" placeholder="Email" />
        </div>
        <div class="col-12">
          <q-input filled v-model="street" placeholder="Street" />
        </div>
        <div class="col-6">
          <q-input filled v-model="city" placeholder="City" />
        </div>
        <div class="col-6">
          <q-input filled v-model="zip" placeholder="Zipcode" />
        </div>
        <div class="col-xs-12 col-sm-6">
          <q-input filled v-model="state" placeholder="State" />
        </div>
        <div class="col-6">
          <q-input filled v-model="country" placeholder="Country" />
        </div>
        <div class="col-12">
          <q-input filled v-model="website" placeholder="Website" />
        </div>
      </div>
    </q-form>
  </div>
</template>

<script>
  export default {
    data() {
      return {
        firstName: ''
        , lastName: ''
        , phoneMobile: ''
        , phoneWork: ''
        , organization: ''
        , title: ''
        , street: ''
        , city: ''
        , state: ''
        , country: ''
        , zip: ''
        , email: ''
        , website: ''
      }
    }
    , computed: {
      qr() {
        return 'BEGIN:VCARD\nVERSION:3.0\nN:' + this.lastName + ';' + this.firstName + ';;;\nTEL;TYPE=cell:' + this.phoneMobile + '\nTEL;TYPE=work:' + this.phoneWork + '\nORG:' + this.organization + '\nTITLE:' + this.title + '\nEMAIL:' + this.email + '\nADR;TYPE=home:;;' + this.street + ';' + this.city + ';' + this.state + ';' + this.zip + ';' + this.country + '\nURL:' + this.website + '\nEND: VCARD';
      }
    }
    , watch: {
      qr(val) {
        this.$emit('updateQR', val)
      }
    }
  }
</script>
