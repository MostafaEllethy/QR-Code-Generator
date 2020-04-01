<template>
  <div>
    <h2 class="text-h5 text-weight-bolder text-blue-10 no-margin">WiFi QR Code</h2>
    <q-form @submit.prevent="submit" class="q-pt-sm">
      <div class="row q-col-gutter-md">
        <div class="col-12">
          <div class="row items-center">
            <div class="col-xs-8">
              <q-input filled v-model="name" label="Network Name" placeholder="SSID" stack-label />
            </div>
            <div class="col-xs-4 text-center">
              <q-toggle v-model="hidden" label="Hidden" />
            </div>
          </div>
        </div>
        <div class="col-12">
          <div class="row items-center">
            <div class="col-xs-12  col-sm-3 text-subtitle2 text-weight-bold">
              Encryption <q-icon name="double_arrow" class="gt-xs" />
            </div>
            <div class="col-xs-12  col-sm-9">
              <q-btn-toggle spread v-model="encryption" push toggle-color="primary" :options="[
          {label: 'None', value: 'nopass'},
          {label: 'WPA/WPA2', value: 'WPA'},
          {label: 'WEB', value: 'WEP'} ]" />
            </div>
          </div>
        </div>
        <div class="col-12">
          <div class="row">
            <div class="col-xs-12">
              <q-input v-model="password" filled :type="showPwd ? 'text' : 'password'" label="Password">
                <template v-slot:append>
                  <q-icon :name="showPwd ? 'visibility' : 'visibility_off'"
                          class="cursor-pointer"
                          @click="showPwd = !showPwd" />
                </template>
              </q-input>
            </div>
          </div>
        </div>
        <div class="col-12">
          <div class="row justify-center">
            <div class="col-xs-12 col-sm-7 col-md-6 col-lg-3">
              <q-btn class="full-width q-pa-xs text-subtitle2" push label="Generate QR Code" type="submit" color="positive" />
            </div>
          </div>
        </div>
      </div>
    </q-form>
  </div>
</template>

<script>
  export default {
    data() {
      return {
        showPwd: false
        , name: ''
        , hidden: false
        , encryption: 'nopass'
        , password: ''
      }
    }
    , methods: {
      submit() {
        this.$emit('updateQR', 'WIFI:T:' + this.encryption + ';S:' + this.name + ';P:' + this.password + ';' + (this.hidden ? ('H:true;') : '') + ';')
      }
    }
  }
</script>
